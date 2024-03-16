using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Runtime.Core.ParserEngine.ParserObjects
{
  [Serializable]
  public class MergedObject: SimpleParserObject
  {
    public string MergedText
    {
      get
      {
        string tmpText = ParamText;
        List<string> keys = new List<string>(Parameters.Keys);
        for (int i = 0; i < keys.Count; i++)
        {
          tmpText = tmpText.Replace(keys[i], Convert.ToString(Parameters[keys[i]]));
        }

        return tmpText;
      }
    }

    public string ParamText
    {
      get
      {
        string tmpText = this.Text;
        int parIdx = 0;
        List<string> keys = new List<string>(Parameters.Keys); 
        while (tmpText.IndexOf('{') != -1)
        {
          string key = keys[parIdx];
          int parStart = tmpText.IndexOf('{');
          int parLength = Convert.ToInt32(key.Substring(key.IndexOf('_') + 1));
          tmpText = tmpText.Substring(0, parStart - 1) + key + tmpText.Substring(parStart+parLength + 1);
          parIdx++;
        }

        return tmpText.Trim();
      }
    }

  }
}
