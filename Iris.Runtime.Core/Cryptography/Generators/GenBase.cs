using System;
using System.Collections.Generic;
using System.Text;
using Iris.Cryptography;

namespace Iris.Generators
{
  public abstract class GenBase : Random
  {
    #region Constructors

    public GenBase() { }

    public GenBase(int seed)
      : base(seed)
    {
    }

    #endregion

    #region Methods

    protected int GetBaseNextInt32()
    {
      return base.Next();
    }

    protected uint GetBaseNextUInt32()
    {
      return ConvertToUInt32(base.Next());
    }

    protected double GetBaseNextDouble()
    {
      return base.NextDouble();
    }

    #endregion

    #region Overrides

    /// <summary>
    /// Returns a nonnegative random number.
    /// </summary>
    /// <returns>
    /// A 32-bit signed uinteger greater than or equal to zero and less than <see cref="F:System.uint32.MaxValue"></see>.
    /// </returns>
    public abstract override int Next();

    /// <summary>
    /// Returns a nonnegative random number less than the specified maximum.
    /// </summary>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to zero.</param>
    /// <returns>
    /// A 32-bit signed uinteger greater than or equal to zero, and less than maxValue; that is, the range of return values includes zero but not maxValue.
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">maxValue is less than zero. </exception>
    public override int Next(int maxValue)
    {
      int value = Next(0, maxValue);
      if(value >= maxValue)
        value = maxValue-1;
      return value;
    }

    /// <summary>
    /// Returns a random number within a specified range.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
    /// <returns>
    /// A 32-bit signed uinteger greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">minValue is greater than maxValue. </exception>
    public override int Next(int minValue, int maxValue)
    {
      return Convert.ToInt32((maxValue - minValue) * Sample() + minValue);
    }

    /// <summary>
    /// Returns a random number between 0.0 and 1.0.
    /// </summary>
    /// <returns>
    /// A double-precision floating pouint number greater than or equal to 0.0, and less than 1.0.
    /// </returns>
    public override double NextDouble()
    {
      return Sample();
    }

    /// <summary>
    /// Fills the elements of a specified array of bytes with random numbers.
    /// </summary>
    /// <param name="buffer">An array of bytes to contain random numbers.</param>
    /// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
    public override void NextBytes(byte[] buffer)
    {
      int i, j, tmp;

      // fill the part of the buffer that can be covered by full Int32s
      for (i = 0; i < buffer.Length - 4; i += 4)
      {
        tmp = Next();

        buffer[i] = Convert.ToByte(tmp & 0x000000FF);
        buffer[i + 1] = Convert.ToByte((tmp & 0x0000FF00) >> 8);
        buffer[i + 2] = Convert.ToByte((tmp & 0x00FF0000) >> 16);
        buffer[i + 3] = Convert.ToByte((tmp & 0xFF000000) >> 24);
      }

      tmp = Next();

      // fill the rest of the buffer
      for (j = 0; j < buffer.Length % 4; j++)
      {
        buffer[i + j] = Convert.ToByte(((tmp & (0x000000FF << (8 * j))) >> (8 * j)));
      }
    }

    /// <summary>
    /// Returns a random number between 0.0 and 1.0.
    /// </summary>
    /// <returns>
    /// A double-precision floating pouint number greater than or equal to 0.0, and less than 1.0.
    /// </returns>
    protected override double Sample()
    {

      // generates a random number on [0,1) 
      return Convert.ToDouble(Next()) / 2147483648.0; // divided by 2^31 (Int32 absolute value)
    }

    #endregion

    #region Utility Methods

    protected static UInt32 ConvertToUInt32(Int32 value)
    {
      return BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);

    }

    protected static Int32 ConvertToInt32(UInt32 value)
    {
      return BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

    }

    protected static Int32 ConvertToInt32(UInt64 value)
    {
      return BitConverter.ToInt32(BitConverter.GetBytes(value & 0x000000007fffffff), 0);

    }

    #endregion

    #region Makers

    internal static string longBase = " !#$%&()+,-.0123456789;=@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmnopqrstuvwxyz{}~¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ/:?*<>|";
    internal static string shortBase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// Makes the bases.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="useLong">if set to <c>true</c> [use long].</param>
    /// <returns></returns>
    internal string[] MakeBases(bool useLong)
    {
      List<string> list = new List<string>();
      string b;
      if (useLong)
        b = longBase;
      else
        b = shortBase;

      int n = b.Length;

      for (int i = 0; i < n; i++)
      {
        string newBase;
        do
        {
          newBase = MakeBase(b);
        } while (list.Contains(newBase));
        list.Add(newBase);
      }
      return list.ToArray();
    }

    /// <summary>
    /// Makes the base.
    /// </summary>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    private string MakeBase(string b)
    {
      string result = "";
      while (b.Length > 0)
      {
        int idx = Next(b.Length);
        if (idx == b.Length)
          idx--;
        result += b[idx].ToString();
        b = b.Remove(idx, 1);
      }
      return result;
    }

    /// <summary>
    /// Makes the sequences.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <returns></returns>
    internal string[] MakeSequences(bool useLong)
    {
      string b;
      if (useLong)
        b = longBase;
      else
        b = shortBase;

      int n = b.Length;

      List<string> list = new List<string>();
      string baseSeq = "";
      for (int i = 0; i < n; i++)
      {
        baseSeq += i.ToString() + ",";
      }
      baseSeq = baseSeq.Remove(baseSeq.Length - 1);

      for (int i = 0; i < n; i++)
      {
        string seq;
        do
        {
          seq = MakeSequence(baseSeq);
        } while (list.Contains(seq));
        list.Add(seq);
      }
      return list.ToArray();
    }

    /// <summary>
    /// Makes the sequence.
    /// </summary>
    /// <param name="seq">The seq.</param>
    /// <returns></returns>
    private string MakeSequence(string seq)
    {
      string result = "";
      List<string> list = new List<string>(seq.Split(','));

      while (list.Count > 0)
      {
        int idx = Next(list.Count);
        if (idx == list.Count)
          idx--;
        result += list[idx] + ",";
        list.RemoveAt(idx);
      }
      return result.Remove(result.Length - 1);
    }


    public static int[] ScrambleSequence(int size, string key)
    {
      Random rnd = GenBase.GetGenerator(key);

      int[] seq = new int[size];

      for (int i = 0; i < size; i++)
      {
        seq[i] = i;
      }

      for (int i = 0; i < size; i++)
      {
        int idx = rnd.Next(size);

        int v = seq[idx];
        seq[idx] = seq[i];
        seq[i] = v;
      }

      return seq;
    }
    #endregion

    #region Factory Methods
    public static GenBase GetGenerator(char ch, int seed)
    {
      switch (ch)
      {
        case 'A':
          return new AGen(seed);
        case 'B':
          return new BGen(seed);
        case 'C':
          return new CGen(seed);
        case 'D':
          return new DGen(seed);
        case 'E':
          return new EGen(seed);
        case 'F':
          return new FGen(seed);
        case 'G':
          return new GGen(seed);
        case 'H':
          return new HGen(seed);
        default:
          return null;
      }
    }

    public static GenBase GetGenerator(string key, CryCube cube)
    {
      string b = "ABCDEFGH";
      int seed = CryptCore.KeyToInt32(key, cube);
      key = CryptCore.CvB1ToB2(key, longBase, b);
      char k = CryptCore.GenContract(key, b);
      return GetGenerator(k, seed);      
    }

    public static GenBase GetGenerator(string key)
    {
      return GetGenerator(key, CryptCore.GetLongCube());
    }
    #endregion
  }
}
