using System;
using System.Collections.Generic;
using System.Text;
using Iris.Generators;

namespace Iris.Cryptography
{
  [Serializable]
  public class CryCube
  {
    public string[] bases;
    public string[] sequences;    

    public CryCube(string key)
    {
      GenBase generator = GenBase.GetGenerator(key);
      bases = generator.MakeBases(true);
      sequences = generator.MakeSequences(true);
    }

    public CryCube(string[] _bases, string[] _sequences)
    {
      bases = _bases;
      sequences = _sequences;
    }

    public bool IsEqual(CryCube cube)
    {
      for (int i = 0; i < bases.Length; i++)
      {
        if(bases[i] != cube.bases[i])
          return false;
      }

      for (int i = 0; i < sequences.Length; i++)
      {
        if (sequences[i] != cube.sequences[i])
          return false;
      }

      return true;
    }
  }
}