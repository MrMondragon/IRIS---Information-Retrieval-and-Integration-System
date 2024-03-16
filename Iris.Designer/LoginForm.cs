using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Databridge.Engine.Criptography;

namespace Iris.Designer
{
  public partial class Login : Form
  {
    public Login()
    {
      InitializeComponent();
    }

    public static bool TestPWD()
    {
      //if (DateTime.Today > (new DateTime(2014, 05, 21)))
      //  throw new Exception("Esta versão de treinamento expirou. Favor entrar em contato com a DataBridge (suporte@databridge.inf.br)");


#if workCopy
      Login login = new Login();

      if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        if (string.IsNullOrEmpty(login.txtPWD.Text))
          return false;

        Cube cube = Cube.GetDefaultLongCube();
        string str = "G)©>Ä´ºÈÃÓ";
        return cube.UnRComp(login.txtPWD.Text) == str;
      }
      else
        return false;
#else
      return true;
#endif
    }
  }
}
