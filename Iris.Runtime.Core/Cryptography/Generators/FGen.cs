using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Generators
{
  /// <summary>
  /// <para>
  /// very quick linear congruential generator which takes its modulus
  /// operation from the unflagged overflow of a 32-bit register
  /// </para>
  /// <remarks>
  /// see: http://www.shadlen.org/ichbin/random/generators.htm#quick
  /// </remarks>
  /// </summary>
  public class FGen : GenBase
  {
    #region Constructors

    public FGen() : this(Convert.ToInt32(DateTime.Now.Ticks & 0x000000007FFFFFFF)) { }

    public FGen(int seed)
      : base(seed)
    {
      i = Convert.ToUInt64(GetBaseNextInt32());
    }

    #endregion

    #region Member Variables

    private static readonly uint a = 1099087573;

    private ulong i;

    #endregion

    #region Methods

    public override int Next()
    {
      #region Execution

      i = a * i; // overflow occurs here!
      return ConvertToInt32(i);

      #endregion

    }

    #endregion
  }
}