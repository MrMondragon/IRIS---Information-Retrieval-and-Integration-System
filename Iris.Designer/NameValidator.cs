using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Runner
{
  public static class NameValidator
  {
    public static bool ValidateName(string name)
    {

      List<string> list = new List<string>(reservedWords);
      if (list.Contains(name))
      {
        MessageBox.Show(name+" é uma palavra reservada e não pode ser utilizada como nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      bool result = true;
      for (int i = 0; i < name.Length; i++)
      {
        result &= ValidateLetter(name[i], i);
        if (!result)
        {
          MessageBox.Show("Caractere inválido: "+name[i].ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return false;
        }
      }

      return true;
    }

    private static bool ValidateLetter(Char letter, int letIndex)
    {
      bool lOk = ((letter >= 'A') && (letter <= 'Z')) || ((letter >= 'a') && (letter <= 'z'));
      lOk |= letter == '_';

      if (letIndex > 0)
        lOk |= (letter >= '0') && (letter <= '9');


      return lOk;
    }


    public static string[] reservedWords = new string[] {"abstract","event","new","struct","as",
      "explicit","null","switch","base","extern","object","this","bool","false","operator","throw",
      "break","finally","out","true","byte","fixed","override","try","case","float","params",
      "typeof","catch","for","private","uint","char","foreach","protected","ulong","checked",
      "goto","public","unchecked","class","if","readonly","unsafe","const","implicit","ref",
      "ushort","continue","in","return","using","decimal","int","sbyte","virtual","default",
      "interface","sealed","volatile","delegate","internal","short","void","do","is","sizeof",
      "while","double","lock","stackalloc","else","long","static","enum","namespace","string"};

  }
}
