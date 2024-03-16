using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Iris.Steganographia
{
  public class BinaryValue
  {

    public BinaryValue(UInt32 value)
    {
      IntValue = value;
    }

    public BinaryValue(Byte value)
    {
      ByteValue = value;
    }

    public BinaryValue()
    {
      IntValue = 0;
    }

    public BinaryValue(string value)
    {
      ByteString = value;
    }

    public BinaryValue(bool[] bitArray, int index)
    {
      int nextByte = index + 8;
      if (nextByte >= bitArray.Length)
        nextByte = bitArray.Length;

      nextByte -= index;

      for (int i = 0; i < nextByte; i++)
      {
        this[7-i] = bitArray[i + index];
      }
    }

    public override string ToString()
    {
      return ByteString;
    }

    public Boolean this[int idx] 
    { 
      get
      {
        uint i = IntValue;
        i <<= 31 - idx;
        i >>= 31 - idx;
        i >>= idx;        
        return Convert.ToBoolean(Math.Abs(i));
      } 
      set
      {
        if (value != this[idx])
        {
          int signal;
          if (value)
            signal = 1;
          else
            signal = -1;

          IntValue += (uint)((1 << idx) * signal);
        }
      }
    }

    public string IntString
    {
      get
      {
        string s = "";
        for (int i = 31; i >= 0; i--)
        {
          s += Convert.ToInt32(this[i]).ToString();
        }
        return s;
      }
      set
      {
        value = value.PadLeft(32, '0');
        for (int i = 0; i < 32; i++)
        {
          int idx = Math.Abs(31 - i);
          this[i] = Convert.ToBoolean(Convert.ToByte(value[idx].ToString()));
        }
      }
    }


    public string ByteString
    {
      get
      {
        string s = "";
        for (int i = 7; i >= 0; i--)
        {
          s += Convert.ToByte(this[i]).ToString();
        }
        return s;
      }
      set
      {
        value = value.PadLeft(8, '0');
        for (int i = 0; i < 8; i++)
        {
          int idx = Math.Abs(7 - i);
          this[i] = Convert.ToBoolean(Convert.ToByte(value[idx].ToString()));
        }
      }
    }

    public bool IsByte()
    {
      return IntValue < 256;
    }

    public Byte ByteValue
    {
      get { return Convert.ToByte(IntValue); }
      set { IntValue = value; }
    }

    private uint intValue;
    public uint IntValue
    {
      get
      {
        return intValue;
      }
      set
      {
        intValue = value;
      }
    }



  }
}