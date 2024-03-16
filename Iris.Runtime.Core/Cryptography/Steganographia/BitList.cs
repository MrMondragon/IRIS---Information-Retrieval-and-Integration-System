using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Steganographia
{
  public class BitList
  {
    private bool[] internalList;
    public BitList(byte[] _bytes)
    {
      internalList = new bool[_bytes.Length * 8];
      for (int i = 0; i < _bytes.Length; i++)
      {
        BinaryValue bValue = new BinaryValue(_bytes[i]);
        for (int j = 0; j < 8; j++)
        {
          internalList[(8 * i) + j] = bValue[7-j];
        }        
      }
    }

    public byte[] GetBytes()
    {
      byte[] bytes = new byte[internalList.Length / 8];
      int idx = 0;
      for (int i = 0; i < internalList.Length; i+=8)
      {
        BinaryValue bValue = new BinaryValue(internalList, i);
        bytes[idx] = bValue.ByteValue;
        idx++;
      }
      return bytes;
    }

    public int Length
    {
      get { return internalList.Length; }
    }

    public bool this[int idx]
    {
      get { return internalList[idx]; }
      set { internalList[idx] = value; }
    }

  }
}