using System;
using System.Collections.Generic;
using System.Text;
using goldparser;
using Iris.Runtime.Core.ParserObjects;
using Iris.Runtime.Core.ParserEngine.ParserObjects;
using Iris.Interfaces;

namespace Iris.Runtime.Core.ParserEngine
{
  public class MergerParser : BaseParser
  {
    public MergerParser(IStructure structure)
      : base("Merger")
    {
      xevalParser = new XEvalParser(structure);
    }

    XEvalParser xevalParser;

    public MergedObject Parse(string source)
    {
      MergedObject obj = null;
      if (!String.IsNullOrEmpty(source))
      {

        NonterminalToken token = parser.Parse(source);
        if (token != null)
        {
          obj = new MergedObject();
          obj = (MergedObject)CreateObject(token, obj);
        }
      }

      return obj;
    }

    private Object CreateObject(Token token, MergedObject obj)
    {
      if (token is TerminalToken)
        return CreateObjectFromTerminal((TerminalToken)token);
      else
        return CreateObjectFromNonterminal((NonterminalToken)token, obj);
    }

    private string GetFullText(NonterminalToken token, MergedObject obj)
    {
      string value = "";
      for (int i = 0; i < token.Tokens.Length; i++)
      {
        value += GetText(token, i, obj) + " ";
      }
      return value;
    }

    private string GetText(NonterminalToken token, int idx, MergedObject obj)
    {
      string text = Convert.ToString(CreateObject(token.Tokens[idx], obj));
      return text;
    }

    ////////////////////////////////////////////////////////////////
    //Rule Section
    ////////////////////////////////////////////////////////////////
    public Object CreateObjectFromNonterminal(NonterminalToken token, MergedObject obj)
    {
      switch (token.Rule.Id)
      {
        case (int)MergerRuleConstants.RULE_MESSAGE:
        //<Message> ::= <Words>
        case (int)MergerRuleConstants.RULE_MESSAGE_NEWLINE:
        //<Message> ::= <Words> NewLine <Message>
        case (int)MergerRuleConstants.RULE_MESSAGE_NEWLINE2:
          //<Message> ::= NewLine <Message>
          {
            obj.Text= GetFullText(token, obj);
            return obj;
          }
        case (int)MergerRuleConstants.RULE_MESSAGE2:
          //<Message> ::= 
          return null;

        case (int)MergerRuleConstants.RULE_WORD:
        //<Word> ::= <XEval>
        case (int)MergerRuleConstants.RULE_WORDS:
        //<Words> ::= <Word>
        case (int)MergerRuleConstants.RULE_WORDS2:
        //<Words> ::= <Word> <Words>
        case (int)MergerRuleConstants.RULE_WORD_BASEWORD:
        //<Word> ::= BaseWord
        case (int)MergerRuleConstants.RULE_XPRESSION_BASEWORD:
        //<Xpression> ::= BaseWord
        case (int)MergerRuleConstants.RULE_XPRESSION_BASEWORD2:
        //<Xpression> ::= BaseWord <Xpression>
          return GetFullText(token, obj);

        case (int)MergerRuleConstants.RULE_XEVAL_LBRACE_RBRACE:
          //<XEval> ::= { <Xpression> }
          {
            string txt = GetFullText(token, obj);
            int parIdx = obj.Parameters.Count;
            int xprLength = txt.Length;
            string parName = ":P"+parIdx.ToString()+"_"+xprLength;
            object value =  xevalParser.Parse(GetText(token, 1, obj));
            obj.Parameters[parName] = value;
            return txt;
          }          
      }
      throw new RuleException("Unknown rule");
    }
  }
}