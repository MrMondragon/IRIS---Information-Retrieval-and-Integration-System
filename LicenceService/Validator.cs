using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Databridge.Engine.Criptography;

namespace LicenceService
{
  internal static class Validator
  {

    internal static bool ValidateToken(string token, Cube cube)
    {
      token = cube.UnRComp(token);

      string checkSum = Convert.ToString(token[token.Length - 1]);
      token = token.Remove(token.Length - 1);

      string tokenCheck = cube.ResizeKey(token, 1);

      if (tokenCheck != checkSum)
        throw new Exception("Dígito de verificação inválido");

      int dd = cube.StringToInt(token[0].ToString(), 0);
      int mm = cube.StringToInt(token[1].ToString(), 0);
      int yy = cube.StringToInt(token[2].ToString(), 0);

      int hh = cube.StringToInt(token[3].ToString(), 0);
      int nn = cube.StringToInt(token[4].ToString(), 0);
      int ss = cube.StringToInt(token[5].ToString(), 0);

      int era = Convert.ToInt32(DateTime.Today.Year.ToString().Remove(2)) * 100;

      DateTime tokenDate = new DateTime(yy + era, mm, dd, hh, nn, ss);

      TimeSpan ts = DateTime.Now - tokenDate;

      if (ts.TotalHours > 3)
        throw new Exception("Token expirado");

      string tokenWord = token.Substring(6);
      string checkWord = cube.GetWordAt(dd, mm, yy, hh, nn, ss, 6);

      if (tokenWord != checkWord)
        throw new Exception("Senha inválida");

      return true;
    }

  }
}