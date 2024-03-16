using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;

namespace Iris.PropertyEditors
{
  /// <summary>
  /// Classe base para todos os editores de propriedade do projeto
  /// </summary>
  public abstract class GenericEditor : System.Drawing.Design.UITypeEditor
  {
    /// <summary>
    /// IWindowsFormsEditorService compartilhado pelos membros dos editores que derivam desta classe
    /// </summary>
    protected IWindowsFormsEditorService edsvc = null;
  }
}
