using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Data;
using Iris.Interfaces;
using Databridge.Interfaces;
namespace Iris.PropertyEditors
{
  /// <summary>
  /// Editor de propriedades para seleção de DBProviders
  /// </summary>
  public class ProviderEditor : UITypeEditor
  {
    /// <summary>
    /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"></see> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
    /// </returns>
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.DropDown;
    }

    /// <summary>
    /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> method.
    /// </summary>
    /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
    /// <param name="provider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
    /// <param name="value">The object to edit.</param>
    /// <returns>
    /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
    /// </returns>
    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if (context != null && context.Instance != null && provider != null)
      {
        edsvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
        if (edsvc != null)
        {
          // cria o combo do editor de propriedade...
          ListBox lb = new ListBox();
          //acessa o objeto
          IDataConnection Obj = (IDataConnection)context.Instance;

          lb.DataSource = DbProviderFactories.GetFactoryClasses();
          lb.DisplayMember = "Name";
          lb.ValueMember = "InvariantName";

          lb.SelectedIndexChanged += new EventHandler(SelectedIndexChanged);

          edsvc.DropDownControl(lb);

          value = lb.Text;
          Obj.InternalProvider = ((DataTable)lb.DataSource).Rows[lb.SelectedIndex]["InvariantName"].ToString();
        }
      }
      return value;
    }

    /// <summary>
    /// IWindowsFormsEditorService do editor
    /// </summary>
    protected IWindowsFormsEditorService edsvc = null;

    /// <summary>
    /// Evento de alteração de índice da tabela
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    protected void SelectedIndexChanged(object sender, EventArgs e)
    {
      if (edsvc != null)
        edsvc.CloseDropDown();
    }
  }
}
