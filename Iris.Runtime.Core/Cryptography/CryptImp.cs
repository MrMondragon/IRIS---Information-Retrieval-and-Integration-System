using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.Cryptography
{
  public static class CryptImp
  {

    internal static Random rnd = new Random();

    public static string FixedComplement(String st, bool useLong)
    {
      return doFixedComplement(st, useLong);
    }

    public static string doFixedComplement(String st, bool useLong)
    {
      if (useLong)
        return doFixedComplement(st, CryptCore.GetLongCube());
      else
        return doFixedComplement(st, CryptCore.GetShortCube());
    }

    public static string FixedComplement(String st, CryCube cube)
    {
      return doFixedComplement(st, cube);
    }

    private static string doFixedComplement(String st, CryCube cube)
    {
      char target = cube.bases[0][rnd.Next(cube.bases[0].Length)];
      string result = doFixedComplement(st, cube, target);
      result += target.ToString();
      return result;
    }

    public static string FixedComplement(String st, bool useLong, char target)
    {
      return doFixedComplement(st, useLong, target);
    }

    private static string doFixedComplement(String st, bool useLong, char target)
    {
      if (useLong)
        return doFixedComplement(st, CryptCore.GetLongCube(), target);
      else
        return doFixedComplement(st, CryptCore.GetShortCube(), target);
    }

    public static string FixedComplement(String st, CryCube cube, char target)
    {
      return doFixedComplement(st, cube, target);
    }

    private static string doFixedComplement(String st, CryCube cube, char target)
    {
      int[] seq = CryptCore.GetSequence(target, cube);
      string result = "";

      for (int i = 0; i < st.Length; i++)
      {
        int idx = i % seq.Length;
        string b = cube.bases[seq[idx]];
        result += CryptCore.GetCharComplement(st[i], target, b);
      }
      return result;
    }

    public static string UnFixedComplement(String st, bool useLong)
    {
      return doUnFixedComplement(st, useLong);
    }

    private static string doUnFixedComplement(String st, bool useLong)
    {
      if (useLong)
        return doUnFixedComplement(st, CryptCore.GetLongCube());
      else
        return doUnFixedComplement(st, CryptCore.GetShortCube());
    }

    public static string UnFixedComplement(String st, CryCube cube)
    {
      return doUnFixedComplement(st, cube);
    }

    private static string doUnFixedComplement(String st, CryCube cube)
    {
      char target = st[st.Length - 1];
      string text = st.Remove(st.Length - 1);
      return doUnFixedComplement(text, cube, target);
    }

    public static string UnFixedComplement(String st, bool useLong, char target)
    {
      return doUnFixedComplement(st, useLong, target);
    }

    private static string doUnFixedComplement(String st, bool useLong, char target)
    {
      if (useLong)
        return doUnFixedComplement(st, CryptCore.GetLongCube(), target);
      else
        return doUnFixedComplement(st, CryptCore.GetShortCube(), target);
    }

    public static string UnFixedComplement(String st, CryCube cube, char target)
    {
      return doUnFixedComplement(st, cube, target);
    }

    private static string doUnFixedComplement(String st, CryCube cube, char target)
    {
      string result = "";
      int[] seq = CryptCore.GetSequence(target, cube);

      for (int i = 0; i < st.Length; i++)
      {
        int idx = i % seq.Length;
        string b = cube.bases[seq[idx]];
        string syl = target.ToString() + st[i].ToString();
        result += CryptCore.GenSubtract(syl, b);
      }
      return result;
    }


    public static string CloseWithKey(string st, string key, bool useLong)
    {
      return doCloseWithKey(st, key, useLong);
    }

    private static string doCloseWithKey(string st, string key, bool useLong)
    {
      if (useLong)
        return doCloseWithKey(st, key, CryptCore.GetLongCube());
      else
        return doCloseWithKey(st, key, CryptCore.GetShortCube());
    }

    public static string CloseWithKey(string st, string key, CryCube cube)
    {
      return doCloseWithKey(st, key, cube);
    }

    private static string doCloseWithKey(string st, string key, CryCube cube)
    {
      if (!((string.IsNullOrEmpty(st)) || (string.IsNullOrEmpty(key))))
      {
        for (int i = 0; i < key.Length; i++)
        {
          st = doFixedComplement(st, cube, key[i]);
        }

        char target = cube.bases[0][rnd.Next(cube.bases[0].Length)];
        int[] seq = CryptCore.GetSequence(target, cube);
        string b = cube.bases[seq[0]];

        char checkKey = CryptCore.GenContract(key, b);
        char checkWord = CryptCore.GenContract(st, b);

        st = doFixedComplement(st, cube, target);
        st = target.ToString() + st + checkKey.ToString() + checkWord.ToString();
      }
      return st;
    }

    public static string OpenWithKey(string st, string key, bool useLong)
    {
      return doOpenWithKey(st, key, useLong);
    }


    private static string doOpenWithKey(string st, string key, bool useLong)
    {
      if (useLong)
        return doOpenWithKey(st, key, CryptCore.GetLongCube());
      else
        return doOpenWithKey(st, key, CryptCore.GetShortCube());
    }

    public static string OpenWithKey(string st, string key, CryCube cube)
    {
      return doOpenWithKey(st, key, cube);
    }

    private static string doOpenWithKey(string st, string key, CryCube cube)
    {
      if (st.Length < 3)
        return "";

      char target = st[0];
      int[] seq = CryptCore.GetSequence(target, cube);
      string b = cube.bases[seq[0]];

      char checkKey = st[st.Length - 2];
      char checkWord = st[st.Length - 1];

      st = st.Substring(1, st.Length - 3);

      if (CryptCore.GenContract(key, b) != checkKey)
        return "";

      st = doUnFixedComplement(st, cube, target);

      if (CryptCore.GenContract(st, b) != checkWord)
        return "";

      for (int i = key.Length - 1; i >= 0; i--)
      {
        st = doUnFixedComplement(st, cube, key[i]);
      }

      return st;
    }

    public static bool ValidateWord(string st, bool useLong)
    {
      return doValidateWord(st, useLong);
    }

    private static bool doValidateWord(string st, bool useLong)
    {
      if (useLong)
        return doValidateWord(st, CryptCore.GetLongCube());
      else
        return doValidateWord(st, CryptCore.GetShortCube());
    }

    public static bool ValidateWord(string st, CryCube cube)
    {
      return doValidateWord(st, cube);
    }

    private static bool doValidateWord(string st, CryCube cube)
    {
      if (st.Length < 3)
        return false;
      char target = st[0];
      char checkWord = st[st.Length - 1];
      int[] seq = CryptCore.GetSequence(target, cube);
      string b = cube.bases[seq[0]];
      st = st.Substring(1, st.Length - 3);
      st = UnFixedComplement(st, cube, target);
      return (CryptCore.GenContract(st, b) == checkWord);
    }

    public static string GetKey(string st, byte keySize, CryCube cube)
    {
      return doGetKey(st, keySize, cube);
    }

    private static string doGetKey(string st, byte keySize, CryCube cube)
    {
      while (st.Length < keySize)
        st += UnFixedComplement(st, cube);


      while (st.Length > keySize)
      {
        st = UnFixedComplement(st, cube);
      }

      return st;
    }

    public static string ConvertTo(long val, CryCube cube, int baseIndex)
    {
      return CryptCore.GenCvTo(val, cube.bases[baseIndex]);
    }

    public static long ConvertFrom(string val, CryCube cube, int baseIndex)
    {
      return CryptCore.GenCvFrom(val, cube.bases[baseIndex]);
    }


    #region Controle de senha
    public static void GetUserPwd(ref string userName, out string pwd)
    {
      DateTime dt = DateTime.Today;
      string day = Convert.ToString(dt.Day).PadLeft(2, '0');
      string month = Convert.ToString(dt.Month).PadLeft(2, '0');
      string year = Convert.ToString(dt.Year);

      CryCube cube = new CryCube(userName);
      pwd = GetKey(userName, 2, cube) + day + month + year;
      pwd = CloseWithKey(pwd, userName, cube);
      userName = FixedComplement(userName, true);
    }

    public static bool ValidatePwd(string userName, string pwd)
    {
      userName = UnFixedComplement(userName, true);
      CryCube cube = new CryCube(userName);
      pwd = OpenWithKey(pwd, userName, cube);
      bool validPwd = false;
      if (!string.IsNullOrEmpty(pwd))
      {
        userName = GetKey(userName, 2, cube);

        int day = Convert.ToInt32(pwd.Substring(2, 2));
        int month = Convert.ToInt32(pwd.Substring(4, 2));
        int year = Convert.ToInt32(pwd.Substring(6, 4));
        pwd = pwd.Substring(0, 2);

        TimeSpan ts = DateTime.Today - (new DateTime(year, month, day));
        validPwd = (pwd == userName) & (ts.Days <= 1);
      }
      return validPwd;
    }

    #endregion

  }
}