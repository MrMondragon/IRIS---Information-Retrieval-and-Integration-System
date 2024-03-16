using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Iris.Runtime.Model.DesignuSuport
{
  public static class TreeViewControl
  {
    public static void ExpandNode(TreeNode node)
    {
      if (node != null)
      {
        node.Expand();
        if (node.Parent != null)
          ExpandNode(node.Parent);
      }
    }

    /// <summary>
    /// Seleciona o node correspondente a um objeto na treeView
    /// </summary>
    /// <param name="obj">O objeto a ser localizado</param>
    /// <param name="Nodes">O grupo de nodes raiz para busca</param>
    public static TreeNode FindObjectNode(Object obj, TreeNodeCollection Nodes)
    {
      TreeNode result = null;
      foreach (TreeNode node in Nodes)
      {
        if (node.Tag == obj)
        {
          result = node;
        }
        else if (node.Nodes.Count > 0)
          result = FindObjectNode(obj, node.Nodes);

        if (result != null)
          break;
      }
      return result;
    }

    /// <summary>
    /// Localiza o node correspondente às coordenadas x,y
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static TreeNode FindTreeNode(Point pt, TreeNodeCollection Nodes)
    {
      TreeNode aNode = Nodes[0];
      while (aNode != null)
      {
        if (aNode.Bounds.Contains(pt))
        {
          return aNode;
        }
        aNode = aNode.NextVisibleNode;
      }

      return null;
    }
  }
}
