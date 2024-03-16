using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Iris.Runtime.Core;
using System.Data;
using Iris.PropertyEditors.PropertyEditors;
using System.Drawing.Design;
using Iris.Runtime.Model.PropertyEditors;

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

        if(dataType == typeof(DateTime))
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
    [Browsable(true), Category("Campo"), DisplayName("Somente leitura"), Description("Indica se o campo pode ser alterado pelo usuário ou se será gerenciado pelo sistema")]
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
    [Browsable(true), Category("Campo"), DisplayName("Left Trim"), Description("Indica se devem ser removidos espaços em branco do início do valor do campo")]
    public bool TrimStart
    {
      get { return trimStart; }
      set { trimStart = value; }
    }

    private bool trimEnd;
    [Browsable(true), Category("Campo"), DisplayName("Right Trim"), Description("Indica se devem ser removidos espaços em branco do final do valor do campo")]
    public bool TrimEnd
    {
      get { return trimEnd; }
      set { trimEnd = value; }
    }

    string mask;
    [Browsable(true), Category("Validação"), DisplayName("Máscara"), Description("Máscara de validação do campo. Utilizar 'd' para dia, 'm' para mês, 'y' para ano, 'h' para hora, 'n' para minuto, 's' para segundo e 'g' para milissegundo, ou outras para campos texto")]
    public string Mask
    {
      get
      {
        if ((DataType == typeof(string)) || (DataType == typeof(DateTime)))
          return mask;
        else
          return "Máscaras somente são válidas para campos Texto e Data/Hora";
      }
      set
      {
        if ((DataType == typeof(string)) || (DataType == typeof(DateTime)))
          mask = value;
      }
    }

    [Browsable(true), Category("Posição"), DisplayName("Início"), Description("Posição de início do campo na linha")]
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

    [Browsable(true), Category("Posição"), DisplayName("Término"), Description("Posição de término do campo na linha")]
    public int PosFinal
    {
      get
      {
        return PosInicio + Size;
      }
    }

    [Browsable(true), Category("Posição"), DisplayName("Ordem"), Description("Ordem de término do campo na linha")]
    public int Order
    {
      get
      {
        return line.Fields.IndexOf(this)+1;

      }
    }

    private char paddingChar;
    [Browsable(true), Category("Campo"), DisplayName("Caractere de preenchimento"), Description("Caractere que será utilizado para preencher o tamanho do campo, caso o valor seja menor que o mesmo")]
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
      }

      if (Size <= 1000)
      {
        if (Align == AlignType.Left)
          result = result.PadRight(Size, PaddingChar);
        else
          result = result.PadLeft(Size, PaddingChar);
      }

      return result.Replace(this.line.Delimiter.ToString(), "¬¬"); ;
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
        int fim = formattedString.LastIndexOf(part)+1;
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

    public object ConvertToType(string value)
    {
      try
      {
        if (AutoInc)
          return Line.Schema.GetAutoInc(Line.Name+"."+this.Name);
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

          case "System.Float":
          case "System.Decimal":
            return Convert.ToDecimal(value);

          case "System.Double":
            return Convert.ToDouble(value);

          case "System.Single":
            return Convert.ToSingle(value);

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

    private DateTime ConvertToDate(string value)
    {
      int dia = GetPart(value, 'd');
      int mes = GetPart(value, 'm');
      int ano = GetPart(value, 'y');

      int hora = GetPart(value, 'h');
      int minuto = GetPart(value, 'n');
      int segundo = GetPart(value, 's');
      int mSegundo = GetPart(value, 'g');

      return new DateTime(ano, mes, dia, hora, minuto, segundo, mSegundo);
    }

    private int GetPart(string value, char ch)
    {
      int inicio = Mask.IndexOf(ch);
      if (inicio != -1)
      {
        int length = Mask.LastIndexOf(ch) - inicio + 1;

        string part = value.Substring(inicio, length);
        return Convert.ToInt32(part);
      }
      else
        return 0;
    }

    private bool primaryKey;
    [Browsable(true), Category("Campo"), DisplayName("Chave Primária"), Description("Indica se o campo faz parte da chave primária da linha")]
    public bool PrimaryKey
    {
      get { return primaryKey; }
      set { primaryKey = value; }
    }

    private bool required;
    [Browsable(true), Category("Validação"), DisplayName("Obrigatório"), Description("Indica se o preenchimento do campo é obrigatório")]
    public bool Required
    {
      get { return required; }
      set { required = value; }
    }

    private bool autoInc;
    [Browsable(true), Category("Campo"), DisplayName("Auto Incremento"), Description("Indica se o valor do campo será gerado pelo sistema de forma automática")]
    public bool AutoInc
    {
      get { return autoInc; }
      set { autoInc = value; }
    }

    private bool parentRef;
    [Browsable(false)]
    public bool ParentRef
    {
      get { return parentRef; }
      set { parentRef = value; }
    }

    private bool abortOnError;
    [Browsable(true), Category("Campo"), DisplayName("Abortar em caso de erro"), Description("Indica se a importação deve ser abortada em caso de um valor inválido (true) ou se o valor default deve ser usado neste caso (false)")]
    public bool AbortOnError
    {
      get { return abortOnError; }
      set { abortOnError = value; }
    }

    private string Validate(string value)
    {
      if (TrimStart)
        value = value.TrimStart();

      if (TrimEnd)
        value = value.TrimEnd();
    
      string message = "";
      
      if (string.IsNullOrEmpty(value))
      {
        if (Required && (DefaultValue == null))
          message = "Campo de preenchimento obrigatório: " + Name;
        else
          return Convert.ToString(DefaultValue);
      }

      XEvalParser parser = Line.Schema.Structure.XevalPrarser;

      try
      {
        Dictionary<string, object> pars = new Dictionary<string,object>();
        pars["value"] = value;
        Convert.ToBoolean(parser.Parse(ValidationXpression, pars));
      }
      catch (Exception e)
      {
        message = e.Message;
      }

      if (string.IsNullOrEmpty(message) && ((DataType == typeof(string))&&(!string.IsNullOrEmpty(mask))))
      {
        int pos = -1;
        MaskedTextResultHint hint;
        MaskedTextProvider validator = new MaskedTextProvider(mask);
        if (!validator.VerifyString(value, out pos, out hint))
        {
          message = String.Format("Erro de validação na posição {0}: {1}", pos, MaskHintToString(hint));
        }
      }

      if ((string.IsNullOrEmpty(message)) && (Size > 0) && (value.Length > Size))
      {
        message = String.Format("Erro de validação: tamanho inválido do campo {0}.{1}", this.Line.Name, this.Name);
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
        if (!string.IsNullOrEmpty(ValidationXpression))
        {
          Dictionary<string, object> args = new Dictionary<string, object>();
          args["value"] = value;
          if (Convert.ToBoolean(parser.Parse(ValidationXpression, args)))
            return value;
          else
            throw new Exception("Falha de validação para o campo " + Name);
        }
        else
          return value;
      }

    }

    private string MaskHintToString(MaskedTextResultHint hint)
    {
      switch (hint)
      {
        case MaskedTextResultHint.AlphanumericCharacterExpected:
          return "Caractere alfa-numérico esperado";
        case MaskedTextResultHint.AsciiCharacterExpected:
          return "Caractere ASCII esperado";
        case MaskedTextResultHint.CharacterEscaped:
          return "Caractere ignorado";
        case MaskedTextResultHint.DigitExpected:
          return "Dígito esperado";
        case MaskedTextResultHint.InvalidInput:
          return "Input inválido";
        case MaskedTextResultHint.LetterExpected:
          return "Letra esperada";
        case MaskedTextResultHint.NoEffect:
          return "Sem efeito";
        case MaskedTextResultHint.NonEditPosition:
          return "Posição não editável";
        case MaskedTextResultHint.PositionOutOfRange:
          return "Posição fora da faixa de edição";
        case MaskedTextResultHint.PromptCharNotAllowed:
          return "Caractere inválido";
        case MaskedTextResultHint.SideEffect:
          return "Efeito colateral";
        case MaskedTextResultHint.SignedDigitExpected:
          return "Dígito ou sinal esperado";
        case MaskedTextResultHint.Success:
          return "Sucesso";
        case MaskedTextResultHint.UnavailableEditPosition:
          return "Posição de edição não disponível";
        case MaskedTextResultHint.Unknown:
          return "Desconhecido";
        default:
          return "";
      }
    }

    private XEvalParser parser
    {
      get { return Line.Schema.Structure.XevalPrarser; }
    }

    internal DataColumn CreateColumn()
    {
      DataColumn column = new DataColumn(Name, DataType);
      column.AllowDBNull = !this.Required;
      return column;
    }

    [Browsable(true), Category("Validação"), DisplayName("Expressão de Validação"), Description("Utilize a variável &&value para acessar o valor do campo a ser validado")]
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
