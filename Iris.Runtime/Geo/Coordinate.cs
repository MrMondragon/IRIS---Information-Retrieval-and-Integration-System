using System;


namespace Iris.Runtime.Geo
{
  /// <summary>
  /// The original idea of comming up with a coordinate that used public accessors and an
  /// Coordinate interface was actually quite slow, given that every access point was
  /// multiplied across many instances.
  /// </summary>
  [Serializable]
  public struct Coordinate : IComparable<Coordinate>, IComparable
  {
    #region Private Variables

    /// <summary>
    /// The X or horizontal, or longitudinal ordinate
    /// </summary>
    public double X;
    /// <summary>
    /// The Y or vertical, or latitudinal ordinate
    /// </summary>
    public double Y;
    /// <summary>
    /// The Z or up or altitude ordinate
    /// </summary>
    public double Z;

    #endregion

    #region Constructors

   

    /// <summary>
    /// Creates a 2D coordinate with NaN for the Z and M values
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Coordinate(double x, double y)
    {
      X = x;
      Y = y;
      Z = double.NaN;
    }

    /// <summary>
    /// Creates a new coordinate with the specified values
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public Coordinate(double x, double y, double z)
    {
      X = x;
      Y = y;
      Z = z;
    }




    /// <summary>
    /// Constructs a new instance of the coordinate
    /// </summary>
    /// <param name="c"></param>
    public Coordinate(Coordinate c)
    {
      X = c.X;
      Y = c.Y;
      Z = c.Z;
    }


    #endregion

    #region Methods

    /// <summary>
    /// Compares the X, Y and Z values with the specified item.
    /// If the Z value is NaN then only the X and Y values are considered
    /// </summary>
    /// <param name="obj">This should be either a Coordiante or an Coordinate</param>
    /// <returns>Boolean, true if the two are equal</returns>
    public override bool Equals(object obj)
    {
      if (obj is Coordinate == false)
      {
        Coordinate ic = (Coordinate)obj ;
        if (ic == null) return false;
        if (double.IsNaN(Z) || double.IsNaN(ic.Z)) return (ic.X == X && ic.Y == Y);
        return (ic.X == X && ic.Y == Y && ic.Z == Z);
      }
      Coordinate c = (Coordinate)obj;
      if (double.IsNaN(Z) || double.IsNaN(c.Z)) return (c.X == X && c.Y == Y);
      return (c.X == X && c.Y == Y && c.Z == Z);
    }

    /// <summary>
    /// returns the simple base.GetHashCode
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      if (double.IsNaN(Z))
        return X.GetHashCode() ^ Y.GetHashCode();
      else
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }

    /// <summary>
    /// Returns the underlying two dimensional array of coordinates
    /// </summary>
    /// <returns></returns>
    public double[] ToArray()
    {
      return double.IsNaN(Z) ? new[] { X, Y } : new[] { X, Y, Z };
    }

    /// <summary>
    /// Returns Euclidean 2D distance from Coordinate p.
    /// </summary>
    /// <param name="end"><i>Coordinate</i> with which to do the distance comparison.</param>
    /// <returns>Double, the distance between the two locations.</returns>
    public double Distance(Coordinate end)
    {
      double dx = end.X - X;
      double dy = end.Y - Y;
      return Math.Sqrt(dx * dx + dy * dy);
    }

    /// <summary>
    /// Returns whether the planar projections of the two <i>Coordinate</i>s are equal.
    /// </summary>
    /// <param name="b">The Coordinate with which to do the 2D comparison.</param>
    /// <returns>
    /// <c>true</c> if the x- and y-coordinates are equal;
    /// the Z coordinates do not have to be equal.
    /// </returns>
    public bool Equals2D(Coordinate b)
    {
      if (X == b.X && Y == b.Y) return true;
      return false;
    }

    /// <summary>
    /// Returns true if other has the same values for x, y and z.
    /// </summary>
    /// <param name="b">The second ICoordiante for a 3D comparison</param>
    /// <returns><c>true</c> if <c>other</c> is a <c>Coordinate</c> with the same values for x, y and z.</returns>
    public bool Equals3D(Coordinate b)
    {
      return (X == b.X) && (Y == b.Y) && ((Z == b.Z)
                                          || (Double.IsNaN(Z) && Double.IsNaN(b.Z)));
    }



    /// <summary>
    /// Returns a <c>string</c> of the form <I>(x, y, z)</I> .
    /// </summary>
    /// <returns><c>string</c> of the form <I>(x, y, z)</I></returns>
    public new string ToString()
    {
      string result = "(" + X;
      for (int i = 1; i < NumOrdinates; i++)
      {
        result += ", " + this[i];
      }
      result += ")";
      return result;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets a pre-defined coordinate that has double.NaN for all the values.
    /// </summary>
    public static Coordinate Empty
    {
      get { return new Coordinate(double.NaN, double.NaN); }
    }

    /// <summary>
    /// Gets or sets the double value associated with the specified ordinate index
    /// </summary>
    /// <param name="index">The zero-based integer index of the ordinate</param>
    /// <returns>A double value representing a single ordinate</returns>
    public double this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return X;
          case 1:
            return Y;
          case 2:
            return Z;
          default:
            throw new IndexOutOfRangeException();
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            X = value;
            return;
          case 1:
            Y = value;
            return;
          case 2:
            Z = value;
            return;
          default:
            throw new IndexOutOfRangeException();
        }
      }
    }

    /// <summary>
    /// This is not a true length, but simply tests the Z value.  If the Z value
    /// is NaN then the value is 2.  Otherwise this is 3.
    /// </summary>
    public int NumOrdinates
    {
      get
      {
        return double.IsNaN(Z) ? 2 : 3;
      }
    }

    #region IComparable Members

    /// <summary>
    /// Compares this object with the specified object for order.
    /// Since Coordinates are 2.5D, this routine ignores the z value when making the comparison.
    /// Returns
    ///    -1 : this.x lowerthan other.x || ((this.x == other.x) AND (this.y lowerthan other.y))
    ///    0  : this.x == other.x AND this.y = other.y
    ///    1  : this.x greaterthan other.x || ((this.x == other.x) AND (this.y greaterthan other.y))
    /// </summary>
    /// <param name="other"><c>Coordinate</c> with which this <c>Coordinate</c> is being compared.</param>
    /// <returns>
    /// A negative integer, zero, or a positive integer as this <c>Coordinate</c>
    ///         is less than, equal to, or greater than the specified <c>Coordinate</c>.
    /// </returns>
    int IComparable.CompareTo(object other)
    {
      Coordinate otherCoord = (Coordinate) other;
      if (otherCoord == null) throw new ArgumentException();
      if (X < otherCoord.X)
        return -1;
      if (X > otherCoord.X)
        return 1;
      if (Y < otherCoord.Y)
        return -1;
      if (Y > otherCoord.Y)
        return 1;
      return 0;
    }

    #endregion

    #region IComparable<Coordinate> Members

    /// <summary>
    /// Compares this object with the specified object for order.
    /// Since Coordinates are 2.5D, this routine ignores the z value when making the comparison.
    /// Returns
    ///    -1 : this.x lowerthan other.x || ((this.x == other.x) AND (this.y lowerthan other.y))
    ///    0  : this.x == other.x AND this.y = other.y
    ///    1  : this.x greaterthan other.x || ((this.x == other.x) AND (this.y greaterthan other.y))
    /// </summary>
    /// <param name="other"><c>Coordinate</c> with which this <c>Coordinate</c> is being compared.</param>
    /// <returns>
    /// A negative integer, zero, or a positive integer as this <c>Coordinate</c>
    ///         is less than, equal to, or greater than the specified <c>Coordinate</c>.
    /// </returns>
    public int CompareTo(Coordinate other)
    {
      Coordinate otherCoord = other;
      if (otherCoord == null) throw new ArgumentException();
      if (X < otherCoord.X)
        return -1;
      if (X > otherCoord.X)
        return 1;
      if (Y < otherCoord.Y)
        return -1;
      if (Y > otherCoord.Y)
        return 1;
      return 0;
    }

    #endregion

    /// <summary>
    /// If either X or Y is defined as NaN, then this coordinate is considered empty.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
      return (double.IsNaN(X) || double.IsNaN(Y));
    }

    #endregion


    /// <summary>
    ///
    /// </summary>
    /// <param name="obj1"></param>
    /// <param name="obj2"></param>
    /// <returns></returns>
    public static bool operator ==(Coordinate obj1, Coordinate obj2)
    {
      return Equals(obj1, obj2);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="obj1"></param>
    /// <param name="obj2"></param>
    /// <returns></returns>
    public static bool operator !=(Coordinate obj1, Coordinate obj2)
    {
      return !(obj1 == obj2);
    }

    /// <summary>
    /// Overloaded + operator.
    /// </summary>
    public static Coordinate operator +(Coordinate coord1, Coordinate coord2)
    {
      // returns Coordinate as a specific implementatino of Coordinate
      return new Coordinate(coord1.X + coord2.X, coord1.Y + coord2.Y, coord1.Z + coord2.Z);
    }

    /// <summary>
    /// Overloaded + operator.
    /// </summary>
    public static Coordinate operator +(Coordinate coord1, double d)
    {
      return new Coordinate(coord1.X + d, coord1.Y + d, coord1.Z + d);
    }

    /// <summary>
    /// Overloaded + operator.
    /// </summary>
    public static Coordinate operator +(double d, Coordinate coord1)
    {
      return coord1 + d;
    }

    /// <summary>
    /// Overloaded * operator.
    /// </summary>
    public static Coordinate operator *(Coordinate coord1, Coordinate coord2)
    {
      return new Coordinate(coord1.X * coord2.X, coord1.Y * coord2.Y, coord1.Z * coord2.Z);
    }

    /// <summary>
    /// Overloaded * operator.
    /// </summary>
    public static Coordinate operator *(Coordinate coord1, double d)
    {
      return new Coordinate(coord1.X * d, coord1.Y * d, coord1.Z * d);
    }

    /// <summary>
    /// Overloaded * operator.
    /// </summary>
    public static Coordinate operator *(double d, Coordinate coord1)
    {
      return coord1 * d;
    }

    /// <summary>
    /// Overloaded - operator.
    /// </summary>
    public static Coordinate operator -(Coordinate coord1, Coordinate coord2)
    {
      return new Coordinate(coord1.X - coord2.X, coord1.Y - coord2.Y, coord1.Z - coord2.Z);
    }

    /// <summary>
    /// Overloaded - operator.
    /// </summary>
    public static Coordinate operator -(Coordinate coord1, double d)
    {
      return new Coordinate(coord1.X - d, coord1.Y - d, coord1.Z - d);
    }

    /// <summary>
    /// Overloaded - operator.
    /// </summary>
    public static Coordinate operator -(double d, Coordinate coord1)
    {
      return coord1 - d;
    }

    /// <summary>
    /// Overloaded / operator.
    /// </summary>
    public static Coordinate operator /(Coordinate coord1, Coordinate coord2)
    {
      return new Coordinate(coord1.X / coord2.X, coord1.Y / coord2.Y, coord1.Z / coord2.Z);
    }

    /// <summary>
    /// Overloaded / operator.
    /// </summary>
    public static Coordinate operator /(Coordinate coord1, double d)
    {
      return new Coordinate(coord1.X / d, coord1.Y / d, coord1.Z / d);
    }

    /// <summary>
    /// Overloaded / operator.
    /// </summary>
    public static Coordinate operator /(double d, Coordinate coord1)
    {
      return coord1 / d;
    }


    /*
POINT (-47.5014066696167 -23.501367683042805)
LINESTRING (-47.470482090703278 -23.470042977948815, -47.47086009228272 -23.47026297689165)
POLYGON ((-47.482129706468093 -23.436367146560354, -47.482091943494922 -23.436353595124928, -47.482055525189935 -23.436337207170556, 
     ...
     * -47.482129706468093 -23.436367146560354))
     * */
    public static Coordinate ParsePoint(string point)
    {
      string[] coords = point.Replace("POINT", "").Replace("(", "").Replace(")", "").Trim().Split(' ');

      double x = Convert.ToDouble(coords[0].Replace('.',','));
      double y = Convert.ToDouble(coords[1].Replace('.',','));

      return new Coordinate(x, y);
    }


  }
}