using System;
using System.IO;
using goldparser;
using commons;

namespace Iris.Engine
{
  [Serializable]
  public abstract class BaseParser<T>
  {
    protected LALRParser parser;
    protected ExecutionContext context;

    public BaseParser(string resName)
    {
      string baseName = "Iris.Engine.Properties.Resources";
      string resourceName = resName;
      byte[] buffer = ResourceUtil.GetByteArrayResource(
          System.Reflection.Assembly.GetExecutingAssembly(),
          baseName,
          resourceName);
      MemoryStream stream = new MemoryStream(buffer);
      Init(stream);
      stream.Close();
    }

    public virtual T Parse(string source, ExecutionContext context)
    {
      this.context = context;
      return Parse(source);
    }

    public abstract T Parse(string source);

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
