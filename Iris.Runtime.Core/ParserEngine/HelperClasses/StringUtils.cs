using System;
using System.Collections.Generic;
using System.Text;


  internal static class StringUtils
  {
    public static string FormatSpaces(String st)
    {
      st = st.Replace("  ", " ");
      st = st.Replace(" , ", ", ");
      st = st.Replace(" )", ")");
      st = st.Replace("( ", "(");

      if ((st.IndexOf("  ") > -1) || 
          (st.IndexOf(" , ") > -1) ||
          (st.IndexOf("( ") > -1) ||
          (st.IndexOf(" )") > -1)) 

        st = FormatSpaces(st);
      return st;
    }
  }

