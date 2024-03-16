using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;

namespace Iris.PropertyEditors
{
  /// <summary>
  /// Classe base para editores de propriedade baseados em listas
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class BaseListEditor<T> : GenericEditor
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
    /// Rotina de preenchimento da lista de valores
    /// </summary>
    /// <param name="obj">A instância que está sendo editada.</param>
    /// <returns>A lista preenchida com os valores que serão apresentados no designer</returns>
    protected abstract List<T> GetItems(Object obj);

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
          //acessa o objeto
          Object Obj = context.Instance;

          // cria o combo do editor de propriedade...
          ListBox lb = new ListBox();
          lb.Items.Add("");
          foreach (T oo in GetItems(Obj))
          {
            lb.Items.Add(oo);
          }

          lb.SelectedItem = value;

          lb.SelectedIndexChanged += new EventHandler(SelectedIndexChanged);

          edsvc.DropDownControl(lb);

          if (lb.SelectedIndex == 0)
            return null;
          else
            return lb.SelectedItem;
        }
      }
      return value;
    }

    /// <summary>
    /// Evento de seleção da lista de opções
    /// </summary>
    /// <param name="sender">o objeto que disparou o evento</param>
    /// <param name="e">lista de argumentos do evento</param>
    protected void SelectedIndexChanged(object sender, EventArgs e)
    {
      if (edsvc != null)
        edsvc.CloseDropDown();
    }

    /// <summary>
    /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs"></see>.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs"></see> that indicates what to paint and where to paint it.</param>
    public override void PaintValue(PaintValueEventArgs e)
    {
      if (e.Value != null)
        base.PaintValue(e);
    }  
  }
}
