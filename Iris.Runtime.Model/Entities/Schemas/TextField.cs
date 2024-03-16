using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Iris.Runtime.Core;
using System.Data;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using Iris.Runtime.Model.PropertyEditors;
using System.Globalization;
using Databridge.Engine.Parsers;
using Databridge.Engine;
using Databridge.Engine.Extensions;

namespace Iris.Runtime.Model
{
  [Serializable]
  public class TextField : TextObject, Iris.Runtime.Model.Entities.Txt.ITextField
  {

    private TextLine line;
    [Browsable(false)]
    public TextLine Line
    {
      get { return line; }
    }

    private TextField()
    {
      DataType = typeof(System.String);
      Align = AlignType.Left;
      AbortOnError = true;
      TrimEnd = true;
      TrimStart = true;
      PaddingChar = ' ';
      TrimChars = "";
      AnoRef = 1950;
    }

    public TextField(TextLine _line)
      : this()
    {
      line = _line;
      line.Fields.Add(this);
    }

    public TextField(TextLine _line, int pos)
      : this()
    {
      line = _line;
      line.Fields.Insert(pos, this);
    }

    private int size;
    [Browsable(true), Category("Campo"), DisplayName("Tamanho"), Description("Tamanho (em caracteres) do campo no araquivo. Utilizado apenas para linhas de tipo Delimitado.")]
    public int Size
    {
      get { return size; }
      set { size = value; }
    }

    private Type dataType;
    [Browsable(true), Category("Campo"), DisplayName("Tipo de dados"), Description("Tipo para o qual os dados do campo devem ser convertidos")]
    [Editor(typeof(TypeSelectorEditor), typeof(UITypeEditor))]
    public Type DataType
    {
      get { return dataType; }
      set
      {
        dataType = value;

        if (dataType == typeof(DateTime))
          mask = Line.Schema.DefaultDateTimeMask;
        else
          mask = "";
      }
    }

    private object defaultValue;
    [Browsable(true), Category("Campo"), DisplayName("Valor Default"), Description("Valor utilizado quando o campo estiver em branco")]
    [Editor(typeof(TxtFieldDefaultValueEditor), typeof(UITypeEditor))]
    public object DefaultValue
    {
      get { return defaultValue; }
      set { defaultValue = value; }
    }



    private bool readOnly;
    [Browsable(true), Category("Campo"), DisplayName("Somente leitura"), Description("Indica se o campo pode ser alterado pelo usu�rio ou se ser� gerenciado pelo sistema")]
    public bool ReadOnly
    {
      get { return readOnly; }
      set
      {
        readOnly = value;
        if (!readOnly)
          autoInc = false;
      }
    }

    private bool trimStart;
    [Browsable(true), Category("Campo"), DisplayName("Left Trim"), Description("Indica se devem ser removidos espa�os em branco do in�cio do valor do campo")]
    public bool TrimStart
    {
      get { return trimStart; }
      set { trimStart = value; }
    }

    private bool trimEnd;
    [Browsable(true), Category("Campo"), DisplayName("Right Trim"), Description("Indica se devem ser removidos espa�os em branco do final do valor do campo")]
    public bool TrimEnd
    {
      get { return trimEnd; }
      set { trimEnd = value; }
    }

    private string mask;
    [Browsable(true), Category("Valida��o"), DisplayName("M�scara"), Description("M�scara de valida��o do campo. Utilizar 'd' para dia, 'm' para m�s, 'y' para ano, 'h' para hora, 'n' para minuto, 's' para segundo e 'g' para milissegundo, ou outras para campos texto")]
    public string Mask
    {
      get
      {
        if ((DataType == typeof(string)) || (DataType == typeof(DateTime)))
          return mask;
        else
          return "M�scaras somente s�o v�lidas para campos Texto e Data/Hora";
      }
      set
      {
        if ((DataType == typeof(string)) || (DataType == typeof(DateTime)))
          mask = value;
      }
    }

    private int anoRef;
    [Browsable(true), Category("Valida��o"), DisplayName("Ano Refer�ncia"), Description("Utilizado para campos Data/Hora com dois d�gitos. Anos menores que este valor ser�o acrescidos de 2000, enquanto que anos maiores ser�o acrescidos de 1900")]
    [DefaultValue(1950)]
    public int AnoRef
    {
      get { return anoRef; }
      set { anoRef = value; }
    }

    [Browsable(true), Category("Posi��o"), DisplayName("In�cio"), Description("Posi��o de in�cio do campo na linha")]
    public int PosInicio
    {
      get
      {
        int inicio = 0;
        int index = line.Fields.IndexOf(this);

        for (int i = 0; i < index; i++)
          inicio += line.Fields[i].Size;

        return inicio + 1;
      }
    }

    [Browsable(true), Category("Posi��o"), DisplayName("T�rmino"), Description("Posi��o de t�rmino do campo na linha")]
    public int PosFinal
    {
      get
      {
        return PosInicio + Size;
      }
    }

    [Browsable(true), Category("Posi��o"), DisplayName("Ordem"), Description("Ordem de t�rmino do campo na linha")]
    public int Order
    {
      get
      {
        return line.Fields.IndexOf(this) + 1;

      }
    }

    private char paddingChar;
    [Browsable(true), Category("Campo"), DisplayName("Caractere de preenchimento"), Description("Caractere que ser� utilizado para preencher o tamanho do campo, caso o valor seja menor que o mesmo")]
    public char PaddingChar
    {
      get { return paddingChar; }
      set { paddingChar = value; }
    }

    private AlignType align;
    [Browsable(true), Category("Campo"), DisplayName("Alinhamento"), Description("Left para esquerda e Right para direita")]
    public AlignType Align
    {
      get { return align; }
      set { align = value; }
    }


    public string ConvertToString(object value)
    {
      string result = "";
      if (!Convert.IsDBNull(value))
      {

        if (DataType == typeof(DateTime))
        {
          result = DateTimeToString((DateTime)value);
        }
        else if (DataType == typeof(string))
        {
          if (!string.IsNullOrEmpty(mask))
          {
            MaskedTextProvider formatter = new MaskedTextProvider(mask);
            formatter.Add(Convert.ToString(value));
            result = formatter.ToString();
          }
          else
            result = Convert.ToString(value);
        }
        else
          result = Convert.ToString(value);

        if (((DataType == typeof(float)) || (DataType == typeof(decimal)) || (DataType == typeof(Single)) ||
          (DataType == typeof(Double)) || (DataType == typeof(long))) && (!string.IsNullOrEmpty(Line.Schema.DecimalSeparator)))
        {
          result = result.Replace(".", Line.Schema.DecimalSeparator).Replace(",", Line.Schema.DecimalSeparator);
        }
        else if (!string.IsNullOrEmpty(Line.Schema.CharsToRemove))
        {
          for (int i = 0; i < Line.Schema.CharsToRemove.Length; i++)
          {
            string stChar = Line.Schema.CharsToRemove[i].ToString();
            result = result.Replace(stChar, "");
          }
        }

      }

      if (Size <= 1000)
      {
        if (Align == AlignType.Left)
          result = result.PadRight(Size, PaddingChar);
        else
          result = result.PadLeft(Size, PaddingChar);
      }

      if (TrimStart)
        result = result.TrimStart();
      if (TrimEnd)
        result = result.TrimEnd();


      return result.Replace(this.line.Delimiter.ToString(), "��"); ;
    }

    private string DateTimeToString(DateTime date)
    {
      string value = mask;

      SetPart(ref value, 'd', date.Day);
      SetPart(ref value, 'm', date.Month);
      SetPart(ref value, 'y', date.Year);

      SetPart(ref value, 'h', date.Hour);
      SetPart(ref value, 'n', date.Minute);
      SetPart(ref value, 's', date.Second);
      SetPart(ref value, 'g', date.Millisecond);

      return value;
    }

    private void SetPart(ref string formattedString, char part, int value)
    {
      int inicio = formattedString.IndexOf(part);
      if (inicio != -1)
      {
        int fim = formattedString.LastIndexOf(part) + 1;
        int length = fim - inicio;
        string stringValue = value.ToString();
        if (stringValue.Length < length)
        {
          if (part == 'y')
          {
            if (value > 50)
              stringValue = "19" + stringValue;
            else
              stringValue = "20" + stringValue;
          }
          else
            stringValue = stringValue.PadLeft(length, '0');
        }
        string partText = formattedString.Substring(inicio, length);
        formattedString = formattedString.Replace(partText, stringValue);
      }
    }

    [NonSerialized, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private List<string> nullValues;

    public object ConvertToType(string value)
    {
      if (nullValues == null)
      {
        if (!string.IsNullOrEmpty(Line.Schema.NullValues))
          nullValues = Line.Schema.NullValues.Split('|').ToList();
        else
          nullValues = new List<string>();
      }

      if (nullValues.Contains(value))
        return DBNull.Value;

      try
      {
        if (AutoInc)
          return Line.Schema.GetAutoInc(Line.Name + "." + this.Name);
        else if (ParentRef)
          return Line.Schema.GetKey(Line.Master.Table.TableName, Line.Link[this.Name]);

        value = Validate(value);

        if (string.IsNullOrEmpty(value))
        {
          if (DefaultValue != null)
            return DefaultValue;
          else
            return DBNull.Value;
        }

        switch (DataType.ToString())
        {
          case "System.Int16":
            return Convert.ToInt16(value);

          case "System.Int32":
            return Convert.ToInt32(value);

          case "System.Int64":
            return Convert.ToInt64(value);

          case "System.UInt16":
            return Convert.ToUInt16(value);

          case "System.UInt32":
            return Convert.ToUInt32(value);

          case "System.UInt64":
            return Convert.ToUInt64(value);

          case "System.Byte":
            return Convert.ToByte(value);

          case "System.SByte":
            return Convert.ToSByte(value);

          case "System.Decimal":
            {
              value = TreatValue(value);

              return Convert.ToDecimal(value.Replace('.',
                CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]).Replace(',',
                CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));

            }
          case "System.Double":
            {
              value = TreatValue(value);
              return Convert.ToDouble(value.Replace('.',
              CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]).Replace(',',
              CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            }

          case "System.Float":
          case "System.Single":
            {
              value = TreatValue(value);

              return Convert.ToSingle(value.Replace('.',
              CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]).Replace(',',
              CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            }
          case "System.DateTime":
            {
              return ConvertToDate(value);
            }

          case "System.Boolean":
            return Convert.ToBoolean(value);

          default:
            return Convert.ToString(value);

        }
      }
      catch
      {
        if (AbortOnError)
          throw;
        else if (DefaultValue != null)
          return DefaultValue;
        else
          return DBNull.Value;
      }
    }

    private string TreatValue(string value)
    {
      if (value.EndsWith("-"))
      {
        value = value.Trim('-');
        value = $"-{value}";
      }
      if (value.Contains(".") && (value.Contains(",")))
      {
        if (value.IndexOf(".") < value.IndexOf(","))
          value = value.Extract(".");
        else
        {
          value = value.Extract(",");
        }
      }
      return value;
    }

    private DateTime ConvertToDate(string value)
    {
      int dia = GetPart(value, 'd');
      int mes = GetPart(value, 'm');
      int ano = GetPart(value, 'y');

      if ((ano > 9999) || (ano < 1755))
      {
        string anoStr = Convert.ToString(ano);
        anoStr = anoStr.PadLeft(4, '0');
        ano = Convert.ToInt32(anoStr.Substring(2));
      }

      if (ano < 100)
      {
        int dec = Convert.ToInt32(AnoRef.ToString().Substring(2));
        int mil = Convert.ToInt32(AnoRef.ToString().Remove(2)) * 100;

        if (ano < dec)
          ano += mil + 100;
        else
          ano += mil;
      }

      int hora = GetPart(value, 'h');
      int minuto = GetPart(value, 'n');
      int segundo = GetPart(value, 's');
      int mSegundo = GetPart(value, 'g');

      if ((dia == 0) && (mes == 0) && (ano.ToString().EndsWith("00")))
      {
        DateTime dt = new DateTime();
        dt = dt.AddHours(hora);
        dt = dt.AddMinutes(minuto);
        dt = dt.AddSeconds(segundo);
        return dt;

      }
      else
        return new DateTime(ano, mes, dia, hora, minuto, segundo, mSegundo);
    }

    private int GetPart(string value, char ch)
    {
      int inicio = Mask.IndexOf(ch);
      if (inicio != -1)
      {
        int length = Mask.LastIndexOf(ch) - inicio + 1;
        string part = value.Substring(inicio, length);

        if ((ch == 'm') && (length > 2))
          return DecodeMonth(part);
        else
          return Convert.ToInt32(part);
      }
      else
        return 0;
    }

    private static string[] monthsPort = new string[]{"janeiro", "fevereiro", "mar�o", "abril", "maio",
      "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"};
    private static string[] monthsEng = new string[]{"january", "february", "march", "april", "may",
      "june", "july", "august", "september", "october", "november", "december"};


    private int DecodeMonth(string part)
    {
      part = part.ToLower();
      for (int i = 0; i < 12; i++)
      {
        if ((CompareIndex(part, monthsPort[i])) || (CompareIndex(part, monthsEng[i])))
          return i + 1;
      }
      throw new Exception(string.Format("Valor {0} inv�lido como m�s no campo {1}, utilizando a m�scara {2}", part, this.Name, this.Mask));
    }

    private bool CompareIndex(string part, string month)
    {
      if (month.Length > part.Length)
        month = month.Remove(part.Length);
      else if (month.Length < part.Length)
        month = month.PadLeft(PaddingChar);

      return part == month;
    }


    private bool primaryKey;
    [Browsable(true), Category("Campo"), DisplayName("Chave Prim�ria"), Description("Indica se o campo faz parte da chave prim�ria da linha")]
    public bool PrimaryKey
    {
      get { return primaryKey; }
      set { primaryKey = value; }
    }

    private bool required;
    [Browsable(true), Category("Valida��o"), DisplayName("Obrigat�rio"), Description("Indica se o preenchimento do campo � obrigat�rio")]
    public bool Required
    {
      get { return required; }
      set { required = value; }
    }

    private bool autoInc;
    [Browsable(true), Category("Campo"), DisplayName("Auto Incremento"), Description("Indica se o valor do campo ser� gerado pelo sistema de forma autom�tica")]
    public bool AutoInc
    {
      get { return autoInc; }
      set { autoInc = value; }
    }

    private string trimChars;
    [Browsable(true), Category("Campo"), DisplayName("Trim Chars"), Description("Conjunto de caracteres, entre aspas simples e separados por v�rgulas, que devem ser removidos do in�cio ou do final do campo, conforme indicado nas propriedades TrimStart e TrimEnd")]
    public string TrimChars
    {
      get { return trimChars; }
      set { trimChars = value; }
    }


    private bool parentRef;
    [Browsable(false)]
    public bool ParentRef
    {
      get { return parentRef; }
      set { parentRef = value; }
    }

    private bool abortOnError;
    [Browsable(true), Category("Campo"), DisplayName("Abortar em caso de erro"), Description("Indica se a importa��o deve ser abortada em caso de um valor inv�lido (true) ou se o valor default deve ser usado neste caso (false)")]
    public bool AbortOnError
    {
      get { return abortOnError; }
      set { abortOnError = value; }
    }

    private string Validate(string value)
    {
      if (!string.IsNullOrEmpty(TrimChars))
      {
        string[] charParts = TrimChars.Split(',');
        List<char> charList = new List<char>();
        foreach (string item in charParts)
        {
          charList.Add(item[1]);
        }

        char[] chars = charList.ToArray();

        if (TrimStart)
          value = value.TrimStart(chars);

        if (TrimEnd)
          value = value.TrimEnd(chars);

      }
      else
      {
        if (TrimStart)
          value = value.TrimStart();

        if (TrimEnd)
          value = value.TrimEnd();
      }

      string message = "";

      if (string.IsNullOrEmpty(value))
      {
        if (Required && (DefaultValue == null))
          message = "Campo de preenchimento obrigat�rio: " + Name;
        else
          return Convert.ToString(DefaultValue);
      }

      XEvalParser parser = Line.parser;
      bool expValidated = true;

      if (!string.IsNullOrEmpty(ValidationXpression))
      {
        try
        {
          Dictionary<string, object> pars = new Dictionary<string, object>();
          pars["value"] = value;
          ExecutionContext context = Line.GetContext(pars);
          expValidated = Convert.ToBoolean(parser.Parse(ValidationXpression, context));
        }
        catch (Exception e)
        {
          message = e.Message;
        }
      }

      if (string.IsNullOrEmpty(message) && ((DataType == typeof(string)) && (!string.IsNullOrEmpty(mask))))
      {
        int pos = -1;
        MaskedTextResultHint hint;
        MaskedTextProvider validator = new MaskedTextProvider(mask);
        if (!validator.VerifyString(value, out pos, out hint))
        {
          message = String.Format("Erro de valida��o na posi��o {0}: {1}", pos, MaskHintToString(hint));
        }
      }

      if ((string.IsNullOrEmpty(message)) && (Size > 0) && (value.Length > Size))
      {
        message = String.Format("Erro de valida��o: tamanho inv�lido do campo {0}.{1}", this.Line.Name, this.Name);
      }

      if (!string.IsNullOrEmpty(message))
      {
        if (AbortOnError)
          throw new Exception(message);
        else
          return Convert.ToString(DefaultValue);
      }
      else
      {
        if (!expValidated)
          throw new Exception("Falha de valida��o para o campo " + Name);
        else
          return value;
      }

    }

    private string MaskHintToString(MaskedTextResultHint hint)
    {
      switch (hint)
      {
        case MaskedTextResultHint.AlphanumericCharacterExpected:
          return "Caractere alfa-num�rico esperado";
        case MaskedTextResultHint.AsciiCharacterExpected:
          return "Caractere ASCII esperado";
        case MaskedTextResultHint.CharacterEscaped:
          return "Caractere ignorado";
        case MaskedTextResultHint.DigitExpected:
          return "D�gito esperado";
        case MaskedTextResultHint.InvalidInput:
          return "Input inv�lido";
        case MaskedTextResultHint.LetterExpected:
          return "Letra esperada";
        case MaskedTextResultHint.NoEffect:
          return "Sem efeito";
        case MaskedTextResultHint.NonEditPosition:
          return "Posi��o n�o edit�vel";
        case MaskedTextResultHint.PositionOutOfRange:
          return "Posi��o fora da faixa de edi��o";
        case MaskedTextResultHint.PromptCharNotAllowed:
          return "Caractere inv�lido";
        case MaskedTextResultHint.SideEffect:
          return "Efeito colateral";
        case MaskedTextResultHint.SignedDigitExpected:
          return "D�gito ou sinal esperado";
        case MaskedTextResultHint.Success:
          return "Sucesso";
        case MaskedTextResultHint.UnavailableEditPosition:
          return "Posi��o de edi��o n�o dispon�vel";
        case MaskedTextResultHint.Unknown:
          return "Desconhecido";
        default:
          return "";
      }
    }



    internal DataColumn CreateColumn()
    {
      DataColumn column = new DataColumn(Name, DataType);
      column.AllowDBNull = !this.Required;
      return column;
    }

    [Browsable(true), Category("Valida��o"), DisplayName("Express�o de Valida��o"), Description("Utilize a vari�vel &&value para acessar o valor do campo a ser validado")]
    public override string ValidationXpression
    {
      get
      {
        return base.ValidationXpression;
      }
      set
      {
        base.ValidationXpression = value;
      }
    }

    public override string ToString()
    {
      if (!string.IsNullOrEmpty(Name))
        return Name;
      else
      {
        int i = Line.Fields.IndexOf(this);
        return Line.Name + "[" + i.ToString() + "]";

      }
    }

  }
}
