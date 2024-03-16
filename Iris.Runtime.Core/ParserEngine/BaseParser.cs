using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using goldparser.lalr;
using goldparser;
using commons;
using Iris.Runtime.Core.ParserObjects;
using Iris.Runtime.Core.Expressions;
using System.Windows.Forms;

namespace Iris.Runtime.Core
{
  [Serializable]
  public class BaseParser
  {
    protected LALRParser parser;

    public BaseParser(string resName)
    {
      string baseName = "Iris.Runtime.Core.Properties.Resources";
      string resourceName = resName;
      byte[] buffer = ResourceUtil.GetByteArrayResource(
          System.Reflection.Assembly.GetExecutingAssembly(),
          baseName,
          resourceName);
      MemoryStream stream = new MemoryStream(buffer);
      Init(stream);
      stream.Close();
    }


    protected void Init(Stream stream)
    {
      CGTReader reader = new CGTReader(stream);
      parser = reader.CreateNewParser();
      parser.TrimReductions = false;
      parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

      parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
      parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
    }

    protected virtual Object CreateObjectFromTerminal(TerminalToken token)
    {
      return token.Text;
    }


    protected void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
    {
      string message = "Erro de sintaxe casusado pelo símbolo: '" + args.Token.ToString() + "'";
      throw new ParserException(message, args.Token);
    }

    protected void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
    {
      string message = "Erro de sintaxe casusado pelo símbolo: '" + args.UnexpectedToken.ToString() + "'";
      throw new ParserException(message, args.UnexpectedToken);
    }

  }
}
