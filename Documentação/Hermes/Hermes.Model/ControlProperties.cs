using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Model
{
  public class ControlProperties
  {
    private int colSpan;

    private BoardView hyperLink;

    private string id;

    private int rowSpan;

    private BoardView view;

    private int x;

    private int y;
    private int field;

    /// <summary>
    /// Ao gravar e carregar as propriedades específicas dos controles são armazenadas neste campo 
    /// </summary>
    private Dictionary<string, object> properties;
    /// <summary>
    /// Código para registrar o WebUserControl na página/controle
    /// </summary>
    private string ctrlRegCode;

    public string CtrlRegCode
    {
      get { return ctrlRegCode; }
      set { ctrlRegCode = value; }
    }
    /// <summary>
    /// Código para declarar o wuc com suas propriedades comuns
    /// </summary>
    private string ctrlDeclareCode;

    public string CtrlDeclareCode
    {
      get { return ctrlDeclareCode; }
      set { ctrlDeclareCode = value; }
    }
    /// <summary>
    /// Código para inicializar o wuc com suas propriedades dinâmicas
    /// </summary>
    private string ctrlInitCode;

    public string CtrlInitCode
    {
      get { return ctrlInitCode; }
      set { ctrlInitCode = value; }
    }
  
    public Dictionary<string, object> Properties
    {
      get { return properties; }
      set { properties = value; }
    }

    public int ColSpan
    {
      get { return colSpan; }
      set { colSpan = value; }
    }

    public string Id
    {
      get { return id; }
      set { id = value; }
    }

    public int RowSpan
    {
      get { return rowSpan; }
      set { rowSpan = value; }
    }

    public BoardView View
    {
      get { return view; }
    }

    public int X
    {
      get { return x; }
      set { x = value; }
    }

    public int Y
    {
      get { return y; }
      set { y = value; }
    }

    public BoardView HyperLink
    {
      get { return hyperLink; }
      set { hyperLink = value; }
    }
  }
}
