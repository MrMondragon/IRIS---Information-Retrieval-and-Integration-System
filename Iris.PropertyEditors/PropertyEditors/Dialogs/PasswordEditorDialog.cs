using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors;

namespace Iris.PropertyEditors.Dialogs
{
  public partial class PasswordEditorDialog : BaseDialog
  {
    public PasswordEditorDialog()
    {
      InitializeComponent();
    }

    private string senhaAtual;

    public DialogResult Execute(string _senhaAtual)
    {
      senhaAtual = _senhaAtual;
      tbAtual.Clear();
      tbConfirm.Clear();
      tbNova.Clear();
      tbAtual.Visible = !String.IsNullOrEmpty(senhaAtual);
      lbSenhaAtual.Visible = !String.IsNullOrEmpty(senhaAtual);

      DialogResult result = ShowDialog();
      if (result == DialogResult.OK)
      {
        if (tbAtual.Text != senhaAtual)
        {
          MessageBox.Show("A senha atual não confere", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return Execute(senhaAtual);
        }
        else if (tbNova.Text != tbConfirm.Text)
        {
          MessageBox.Show("A confirmação da senha não confere", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return Execute(senhaAtual);
        }
      }
      return result;
    }


    public string Senha
    {
      get
      {
        if ((tbAtual.Text == senhaAtual) && (tbNova.Text == tbConfirm.Text))
          return tbNova.Text;
        else
          return senhaAtual;
      }
    }

  }
}