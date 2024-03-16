namespace Iris.Engine
{

/////////////////////////////////////////////////////////////////////////////

  enum XEvalSymbolConstants : int
  {
    SYMBOL_EOF = 0, // (EOF)
    SYMBOL_ERROR = 1, // (Error)
    SYMBOL_WHITESPACE = 2, // (Whitespace)
    SYMBOL_MINUS = 3, // -
    SYMBOL_EXCLAMEQ = 4, // !=
    SYMBOL_NUM = 5, // #
    SYMBOL_PERCENT = 6, // %
    SYMBOL_AMP = 7, // &
    SYMBOL_LPARAN = 8, // (
    SYMBOL_RPARAN = 9, // )
    SYMBOL_TIMES = 10, // *
    SYMBOL_COMMA = 11, // ,
    SYMBOL_DIV = 12, // /
    SYMBOL_AT = 13, // @
    SYMBOL_LBRACKET = 14, // [
    SYMBOL_RBRACKET = 15, // ]
    SYMBOL_PLUS = 16, // +
    SYMBOL_LT = 17, // <
    SYMBOL_LTEQ = 18, // <=
    SYMBOL_LTGT = 19, // <>
    SYMBOL_EQEQ = 20, // ==
    SYMBOL_GT = 21, // >
    SYMBOL_GTEQ = 22, // >=
    SYMBOL_AND = 23, // AND
    SYMBOL_AVG = 24, // Avg
    SYMBOL_AVGDISTINCT = 25, // AvgDistinct
    SYMBOL_BETWEEN = 26, // BETWEEN
    SYMBOL_COUNT = 27, // Count
    SYMBOL_COUNTDISTINCT = 28, // CountDistinct
    SYMBOL_DATE = 29, // Date
    SYMBOL_DD = 30, // Dd
    SYMBOL_ID = 31, // Id
    SYMBOL_IS = 32, // IS
    SYMBOL_LIKE = 33, // LIKE
    SYMBOL_MAX = 34, // Max
    SYMBOL_MIN = 35, // Min
    SYMBOL_NOT = 36, // NOT
    SYMBOL_NOW = 37, // Now
    SYMBOL_NULL = 38, // NULL
    SYMBOL_NUMBER = 39, // Number
    SYMBOL_OR = 40, // OR
    SYMBOL_REQUESTOBJECT = 41, // RequestObject
    SYMBOL_STRING = 42, // String
    SYMBOL_SUBSTRING = 43, // Substring
    SYMBOL_SUM = 44, // Sum
    SYMBOL_SUMDISTINCT = 45, // SumDistinct
    SYMBOL_TODAY = 46, // Today
    SYMBOL_YY = 47, // Yy
    SYMBOL_ADDEXP = 48, // <Add Exp>
    SYMBOL_ANDEXP = 49, // <And Exp>
    SYMBOL_DATAFIELD = 50, // <DataField>
    SYMBOL_DATATABLE = 51, // <DataTable>
    SYMBOL_DATE2 = 52, // <Date>
    SYMBOL_EXPRESSION = 53, // <Expression>
    SYMBOL_EXTERNALPARAM = 54, // <External Param>
    SYMBOL_EXTERNALVAR = 55, // <External Var>
    SYMBOL_FUNCTION = 56, // <Function>
    SYMBOL_MULTEXP = 57, // <Mult Exp>
    SYMBOL_NEGATEEXP = 58, // <Negate Exp>
    SYMBOL_NOTEXP = 59, // <Not Exp>
    SYMBOL_PREDEXP = 60, // <Pred Exp>
    SYMBOL_VALUE = 61, // <Value>
    SYMBOL_VAR = 62  // <Var>
  };

  enum XEvalRuleConstants : int
  {
    RULE_EXPRESSION_OR = 0, // <Expression> ::= <And Exp> OR <Expression>
    RULE_EXPRESSION = 1, // <Expression> ::= <And Exp>
    RULE_EXPRESSION2 = 2, // <Expression> ::= 
    RULE_ANDEXP_AND = 3, // <And Exp> ::= <Not Exp> AND <And Exp>
    RULE_ANDEXP = 4, // <And Exp> ::= <Not Exp>
    RULE_NOTEXP_NOT = 5, // <Not Exp> ::= NOT <Pred Exp>
    RULE_NOTEXP = 6, // <Not Exp> ::= <Pred Exp>
    RULE_PREDEXP_BETWEEN_AND = 7, // <Pred Exp> ::= <Add Exp> BETWEEN <Add Exp> AND <Add Exp>
    RULE_PREDEXP_IS_NOT_NULL = 8, // <Pred Exp> ::= <Value> IS NOT NULL
    RULE_PREDEXP_IS_NULL = 9, // <Pred Exp> ::= <Value> IS NULL
    RULE_PREDEXP_LIKE_STRING = 10, // <Pred Exp> ::= <Add Exp> LIKE String
    RULE_PREDEXP_EQEQ = 11, // <Pred Exp> ::= <Add Exp> == <Add Exp>
    RULE_PREDEXP_LTGT = 12, // <Pred Exp> ::= <Add Exp> <> <Add Exp>
    RULE_PREDEXP_EXCLAMEQ = 13, // <Pred Exp> ::= <Add Exp> != <Add Exp>
    RULE_PREDEXP_GT = 14, // <Pred Exp> ::= <Add Exp> > <Add Exp>
    RULE_PREDEXP_GTEQ = 15, // <Pred Exp> ::= <Add Exp> >= <Add Exp>
    RULE_PREDEXP_LT = 16, // <Pred Exp> ::= <Add Exp> < <Add Exp>
    RULE_PREDEXP_LTEQ = 17, // <Pred Exp> ::= <Add Exp> <= <Add Exp>
    RULE_PREDEXP = 18, // <Pred Exp> ::= <Add Exp>
    RULE_ADDEXP_PLUS = 19, // <Add Exp> ::= <Add Exp> + <Mult Exp>
    RULE_ADDEXP_MINUS = 20, // <Add Exp> ::= <Add Exp> - <Mult Exp>
    RULE_ADDEXP = 21, // <Add Exp> ::= <Mult Exp>
    RULE_MULTEXP_TIMES = 22, // <Mult Exp> ::= <Mult Exp> * <Negate Exp>
    RULE_MULTEXP_DIV = 23, // <Mult Exp> ::= <Mult Exp> / <Negate Exp>
    RULE_MULTEXP_PERCENT = 24, // <Mult Exp> ::= <Mult Exp> % <Negate Exp>
    RULE_MULTEXP = 25, // <Mult Exp> ::= <Negate Exp>
    RULE_NEGATEEXP_MINUS = 26, // <Negate Exp> ::= - <Value>
    RULE_NEGATEEXP = 27, // <Negate Exp> ::= <Value>
    RULE_VALUE_NUMBER = 28, // <Value> ::= Number
    RULE_VALUE_DD = 29, // <Value> ::= Dd
    RULE_VALUE_YY = 30, // <Value> ::= Yy
    RULE_VALUE_STRING = 31, // <Value> ::= String
    RULE_VALUE = 32, // <Value> ::= <Var>
    RULE_VALUE2 = 33, // <Value> ::= <Function>
    RULE_VALUE3 = 34, // <Value> ::= <Date>
    RULE_VALUE_LPARAN_RPARAN = 35, // <Value> ::= ( <Expression> )
    RULE_VAR = 36, // <Var> ::= <External Var>
    RULE_VAR2 = 37, // <Var> ::= <DataTable>
    RULE_VAR3 = 38, // <Var> ::= <DataField>
    RULE_VAR4 = 39, // <Var> ::= <External Param>
    RULE_EXTERNALVAR_AT_ID = 40, // <External Var> ::= @ Id
    RULE_DATATABLE_NUM_ID = 41, // <DataTable> ::= # Id
    RULE_DATAFIELD_LBRACKET_NUMBER_RBRACKET_LBRACKET_ID_RBRACKET = 42, // <DataField> ::= <DataTable> [ Number ] [ Id ]
    RULE_DATAFIELD_LBRACKET_RBRACKET_LBRACKET_ID_RBRACKET = 43, // <DataField> ::= <DataTable> [ <External Var> ] [ Id ]
    RULE_EXTERNALPARAM_AMP_ID = 44, // <External Param> ::= & Id
    RULE_DATE_DATE_LPARAN_DD_DIV_DD_DIV_YY_RPARAN = 45, // <Date> ::= Date ( Dd / Dd / Yy )
    RULE_DATE_TODAY = 46, // <Date> ::= Today
    RULE_DATE_NOW = 47, // <Date> ::= Now
    RULE_FUNCTION_COUNT_LPARAN_COMMA_ID_RPARAN = 48, // <Function> ::= Count ( <DataTable> , Id )
    RULE_FUNCTION_AVG_LPARAN_COMMA_ID_RPARAN = 49, // <Function> ::= Avg ( <DataTable> , Id )
    RULE_FUNCTION_MIN_LPARAN_COMMA_ID_RPARAN = 50, // <Function> ::= Min ( <DataTable> , Id )
    RULE_FUNCTION_MAX_LPARAN_COMMA_ID_RPARAN = 51, // <Function> ::= Max ( <DataTable> , Id )
    RULE_FUNCTION_SUM_LPARAN_COMMA_ID_RPARAN = 52, // <Function> ::= Sum ( <DataTable> , Id )
    RULE_FUNCTION_COUNTDISTINCT_LPARAN_COMMA_ID_RPARAN = 53, // <Function> ::= CountDistinct ( <DataTable> , Id )
    RULE_FUNCTION_AVGDISTINCT_LPARAN_COMMA_ID_RPARAN = 54, // <Function> ::= AvgDistinct ( <DataTable> , Id )
    RULE_FUNCTION_SUMDISTINCT_LPARAN_COMMA_ID_RPARAN = 55, // <Function> ::= SumDistinct ( <DataTable> , Id )
    RULE_FUNCTION_COUNT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN = 56, // <Function> ::= Count ( <DataTable> , Id , String )
    RULE_FUNCTION_AVG_LPARAN_COMMA_ID_COMMA_STRING_RPARAN = 57, // <Function> ::= Avg ( <DataTable> , Id , String )
    RULE_FUNCTION_MIN_LPARAN_COMMA_ID_COMMA_STRING_RPARAN = 58, // <Function> ::= Min ( <DataTable> , Id , String )
    RULE_FUNCTION_MAX_LPARAN_COMMA_ID_COMMA_STRING_RPARAN = 59, // <Function> ::= Max ( <DataTable> , Id , String )
    RULE_FUNCTION_SUM_LPARAN_COMMA_ID_COMMA_STRING_RPARAN = 60, // <Function> ::= Sum ( <DataTable> , Id , String )
    RULE_FUNCTION_COUNTDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN = 61, // <Function> ::= CountDistinct ( <DataTable> , Id , String )
    RULE_FUNCTION_AVGDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN = 62, // <Function> ::= AvgDistinct ( <DataTable> , Id , String )
    RULE_FUNCTION_SUMDISTINCT_LPARAN_COMMA_ID_COMMA_STRING_RPARAN = 63, // <Function> ::= SumDistinct ( <DataTable> , Id , String )
    RULE_FUNCTION_SUBSTRING_LPARAN_COMMA_NUMBER_COMMA_NUMBER_RPARAN = 64, // <Function> ::= Substring ( <Value> , Number , Number )
    RULE_FUNCTION_REQUESTOBJECT_LPARAN_ID_RPARAN = 65, // <Function> ::= RequestObject ( Id )
    RULE_FUNCTION_LBRACKET_NUMBER_RBRACKET = 66, // <Function> ::= <Var> [ Number ]
    RULE_FUNCTION_LBRACKET_NUMBER_COMMA_NUMBER_RBRACKET = 67  // <Function> ::= <Var> [ Number , Number ]
  };
////////////////////////////////////////////////////////////////////////////
  enum MergerSymbolConstants : int
  {
    SYMBOL_EOF = 0, // (EOF)
    SYMBOL_ERROR = 1, // (Error)
    SYMBOL_WHITESPACE = 2, // (Whitespace)
    SYMBOL_LBRACE = 3, // {
    SYMBOL_RBRACE = 4, // }
    SYMBOL_BASEWORD = 5, // BaseWord
    SYMBOL_NEWLINE = 6, // NewLine
    SYMBOL_MESSAGE = 7, // <Message>
    SYMBOL_WORD = 8, // <Word>
    SYMBOL_WORDS = 9, // <Words>
    SYMBOL_XEVAL = 10, // <XEval>
    SYMBOL_XPRESSION = 11  // <Xpression>
  };

  enum MergerRuleConstants : int
  {
    RULE_MESSAGE = 0, // <Message> ::= <Words>
    RULE_MESSAGE_NEWLINE = 1, // <Message> ::= <Words> NewLine <Message>
    RULE_MESSAGE_NEWLINE2 = 2, // <Message> ::= NewLine <Message>
    RULE_MESSAGE2 = 3, // <Message> ::= 
    RULE_WORDS = 4, // <Words> ::= <Word>
    RULE_WORDS2 = 5, // <Words> ::= <Word> <Words>
    RULE_WORD_BASEWORD = 6, // <Word> ::= BaseWord
    RULE_WORD = 7, // <Word> ::= <XEval>
    RULE_XEVAL_LBRACE_RBRACE = 8, // <XEval> ::= { <Xpression> }
    RULE_XPRESSION_BASEWORD = 9, // <Xpression> ::= BaseWord
    RULE_XPRESSION_BASEWORD2 = 10  // <Xpression> ::= BaseWord <Xpression>
  };
////////////////////////////////////////////////////////////////////////////
  enum QuerySymbolConstants : int
  {
    SYMBOL_EOF = 0, // (EOF)
    SYMBOL_ERROR = 1, // (Error)
    SYMBOL_WHITESPACE = 2, // (Whitespace)
    SYMBOL_COMMENTEND = 3, // (Comment End)
    SYMBOL_COMMENTLINE = 4, // (Comment Line)
    SYMBOL_COMMENTSTART = 5, // (Comment Start)
    SYMBOL_MINUS = 6, // '-'
    SYMBOL_EXCLAMEQ = 7, // '!='
    SYMBOL_PERCENT = 8, // '%'
    SYMBOL_AMP = 9, // '&'
    SYMBOL_LPARAN = 10, // '('
    SYMBOL_RPARAN = 11, // ')'
    SYMBOL_TIMES = 12, // '*'
    SYMBOL_COMMA = 13, // ','
    SYMBOL_DIV = 14, // '/'
    SYMBOL_COLON = 15, // ':'
    SYMBOL_SEMI = 16, // ';'
    SYMBOL_CARET = 17, // '^'
    SYMBOL_PIPE = 18, // '|'
    SYMBOL_TILDE = 19, // '~'
    SYMBOL_PLUS = 20, // '+'
    SYMBOL_LT = 21, // '<'
    SYMBOL_LTEQ = 22, // '<='
    SYMBOL_LTGT = 23, // '<>'
    SYMBOL_EQ = 24, // '='
    SYMBOL_GT = 25, // '>'
    SYMBOL_GTEQ = 26, // '>='
    SYMBOL_ALL = 27, // ALL
    SYMBOL_AND = 28, // AND
    SYMBOL_AS = 29, // AS
    SYMBOL_ASC = 30, // ASC
    SYMBOL_BETWEEN = 31, // BETWEEN
    SYMBOL_BY = 32, // BY
    SYMBOL_CASE = 33, // CASE
    SYMBOL_CAST = 34, // CAST
    SYMBOL_CONVERT = 35, // CONVERT
    SYMBOL_CROSS = 36, // CROSS
    SYMBOL_DECLARE = 37, // DECLARE
    SYMBOL_DEFAULT = 38, // DEFAULT
    SYMBOL_DELETE = 39, // DELETE
    SYMBOL_DESC = 40, // DESC
    SYMBOL_DISTINCT = 41, // DISTINCT
    SYMBOL_ELSE = 42, // ELSE
    SYMBOL_END = 43, // END
    SYMBOL_EVAL = 44, // EVAL
    SYMBOL_EXISTS = 45, // EXISTS
    SYMBOL_FROM = 46, // FROM
    SYMBOL_FULL = 47, // FULL
    SYMBOL_GO = 48, // GO
    SYMBOL_GROUP = 49, // GROUP
    SYMBOL_HAVING = 50, // HAVING
    SYMBOL_IDENDIFIER = 51, // Idendifier
    SYMBOL_IDENTIFIER = 52, // Identifier
    SYMBOL_IN = 53, // IN
    SYMBOL_INNER = 54, // INNER
    SYMBOL_INSERT = 55, // INSERT
    SYMBOL_INTEGERLITERAL = 56, // IntegerLiteral
    SYMBOL_INTO = 57, // INTO
    SYMBOL_IS = 58, // IS
    SYMBOL_JOIN = 59, // JOIN
    SYMBOL_LEFT = 60, // LEFT
    SYMBOL_LIKE = 61, // LIKE
    SYMBOL_NOT = 62, // NOT
    SYMBOL_NULL = 63, // NULL
    SYMBOL_ON = 64, // ON
    SYMBOL_OR = 65, // OR
    SYMBOL_ORDER = 66, // ORDER
    SYMBOL_OUTER = 67, // OUTER
    SYMBOL_PERCENT2 = 68, // PERCENT
    SYMBOL_REALLITERAL = 69, // RealLiteral
    SYMBOL_RIGHT = 70, // RIGHT
    SYMBOL_SELECT = 71, // SELECT
    SYMBOL_SET = 72, // SET
    SYMBOL_STRINGLITERAL = 73, // StringLiteral
    SYMBOL_TABLE = 74, // TABLE
    SYMBOL_THEN = 75, // THEN
    SYMBOL_TOP = 76, // TOP
    SYMBOL_TRUNCATE = 77, // TRUNCATE
    SYMBOL_UNION = 78, // UNION
    SYMBOL_UPDATE = 79, // UPDATE
    SYMBOL_VALUES = 80, // VALUES
    SYMBOL_WHEN = 81, // WHEN
    SYMBOL_WHERE = 82, // WHERE
    SYMBOL_XEVALEXPRESION = 83, // XEvalExpresion
    SYMBOL_ALIAS = 84, // <alias>
    SYMBOL_ALLDISTINCT = 85, // <all distinct>
    SYMBOL_ARGUMENTLIST = 86, // <Argument List>
    SYMBOL_ARGUMENTLISTOPT = 87, // <Argument List Opt>
    SYMBOL_ASSIGNLIST = 88, // <Assign List>
    SYMBOL_BASEEXPRESSION = 89, // <base expression>
    SYMBOL_CASE2 = 90, // <case>
    SYMBOL_CASEELSE = 91, // <caseelse>
    SYMBOL_CASETYPE = 92, // <casetype>
    SYMBOL_CASEWHEN = 93, // <casewhen>
    SYMBOL_CASEWHENLIST = 94, // <casewhen list>
    SYMBOL_COLUMNLIST = 95, // <Column List>
    SYMBOL_COLUMNSOURCE = 96, // <Column Source>
    SYMBOL_COLUMNS = 97, // <Columns>
    SYMBOL_COMPARISON = 98, // <comparison>
    SYMBOL_DECLARESTM = 99, // <Declare Stm>
    SYMBOL_DECLAREVARIABLE = 100, // <Declare Variable>
    SYMBOL_DECLAREVARIABLES = 101, // <Declare Variables>
    SYMBOL_DEFAULTVALUE = 102, // <Default Value>
    SYMBOL_DELETESTM = 103, // <Delete Stm>
    SYMBOL_EVALSTM = 104, // <Eval Stm>
    SYMBOL_EXPRESSION = 105, // <Expression>
    SYMBOL_EXPRESSIONLIST = 106, // <Expression List>
    SYMBOL_FROM2 = 107, // <From>
    SYMBOL_FROMCLAUSE = 108, // <From Clause>
    SYMBOL_FUNCTIONARGS = 109, // <function args>
    SYMBOL_GO2 = 110, // <Go>
    SYMBOL_GROUPCLAUSE = 111, // <Group Clause>
    SYMBOL_HAVINGCLAUSE = 112, // <Having Clause>
    SYMBOL_IDLIST = 113, // <Id List>
    SYMBOL_INSERTARRAYS = 114, // <Insert Arrays>
    SYMBOL_INSERTCOLUMNS = 115, // <Insert Columns>
    SYMBOL_INSERTLIST = 116, // <Insert List>
    SYMBOL_INSERTSTM = 117, // <Insert Stm>
    SYMBOL_INTO2 = 118, // <Into>
    SYMBOL_INTOCLAUSE = 119, // <Into Clause>
    SYMBOL_JOINTYPE = 120, // <join type>
    SYMBOL_JOINEDTABLE = 121, // <Joined Table>
    SYMBOL_MULTEXPRESSION = 122, // <Mult Expression>
    SYMBOL_NOT2 = 123, // <not>
    SYMBOL_ORDERCLAUSE = 124, // <Order Clause>
    SYMBOL_ORDERLIST = 125, // <Order List>
    SYMBOL_ORDERTYPE = 126, // <Order Type>
    SYMBOL_PARAMETER = 127, // <Parameter>
    SYMBOL_PREDICATE = 128, // <predicate>
    SYMBOL_RESTRICTION = 129, // <Restriction>
    SYMBOL_SEARCHLIST = 130, // <search list>
    SYMBOL_SELECTSTM = 131, // <Select Stm>
    SYMBOL_SETSTM = 132, // <Set Stm>
    SYMBOL_SORTTYPE = 133, // <Sort Type>
    SYMBOL_SPECIALFUNCTION = 134, // <special function>
    SYMBOL_SQLSTM = 135, // <SQL Stm>
    SYMBOL_SQLSTMS = 136, // <SQL Stms>
    SYMBOL_STYLE = 137, // <style>
    SYMBOL_TABLESOURCE = 138, // <table source>
    SYMBOL_TABLESOURCELIST = 139, // <table source list>
    SYMBOL_TOP2 = 140, // <top>
    SYMBOL_TRUNCATESTM = 141, // <Truncate Stm>
    SYMBOL_TYPE = 142, // <Type>
    SYMBOL_UNARYEXP = 143, // <Unary Exp>
    SYMBOL_UNION2 = 144, // <Union>
    SYMBOL_UNIONSTM = 145, // <Union Stm>
    SYMBOL_UPDATESTM = 146, // <Update Stm>
    SYMBOL_VALUE = 147, // <Value>
    SYMBOL_WHERECLAUSE = 148  // <Where Clause>
  };

  enum QueryRuleConstants : int
  {
    RULE_TYPE_IDENTIFIER = 0, // <Type> ::= Identifier
    RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_RPARAN = 1, // <Type> ::= Identifier '(' IntegerLiteral ')'
    RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_COMMA_INTEGERLITERAL_RPARAN = 2, // <Type> ::= Identifier '(' IntegerLiteral ',' IntegerLiteral ')'
    RULE_SQLSTMS = 3, // <SQL Stms> ::= <SQL Stm> <Go> <SQL Stms>
    RULE_SQLSTMS2 = 4, // <SQL Stms> ::= <SQL Stm> <Go>
    RULE_SQLSTM = 5, // <SQL Stm> ::= <Union Stm>
    RULE_SQLSTM2 = 6, // <SQL Stm> ::= <Insert Stm>
    RULE_SQLSTM3 = 7, // <SQL Stm> ::= <Update Stm>
    RULE_SQLSTM4 = 8, // <SQL Stm> ::= <Delete Stm>
    RULE_SQLSTM5 = 9, // <SQL Stm> ::= <Truncate Stm>
    RULE_SQLSTM6 = 10, // <SQL Stm> ::= <Set Stm>
    RULE_SQLSTM7 = 11, // <SQL Stm> ::= <Declare Stm>
    RULE_SQLSTM8 = 12, // <SQL Stm> ::= <Eval Stm>
    RULE_GO_GO = 13, // <Go> ::= GO
    RULE_GO_SEMI = 14, // <Go> ::= ';'
    RULE_GO = 15, // <Go> ::= 
    RULE_EVALSTM_EVAL = 16, // <Eval Stm> ::= EVAL <base expression>
    RULE_DECLARESTM_DECLARE = 17, // <Declare Stm> ::= DECLARE <Declare Variables>
    RULE_DECLAREVARIABLES_COMMA = 18, // <Declare Variables> ::= <Declare Variables> ',' <Declare Variable>
    RULE_DECLAREVARIABLES = 19, // <Declare Variables> ::= <Declare Variable>
    RULE_DECLAREVARIABLE_IDENTIFIER = 20, // <Declare Variable> ::= Identifier <Type> <Default Value>
    RULE_DEFAULTVALUE_EQ = 21, // <Default Value> ::= '=' <Expression>
    RULE_DEFAULTVALUE = 22, // <Default Value> ::= 
    RULE_SETSTM_SET_IDENTIFIER_EQ = 23, // <Set Stm> ::= SET Identifier '=' <Expression>
    RULE_INSERTSTM_INSERT_IDENTIFIER = 24, // <Insert Stm> ::= INSERT <Into> Identifier <Insert Columns> <Union Stm>
    RULE_INSERTSTM_INSERT_IDENTIFIER_VALUES = 25, // <Insert Stm> ::= INSERT <Into> Identifier <Insert Columns> VALUES <Insert Arrays>
    RULE_INSERTSTM_INSERT_IDENTIFIER_DEFAULT_VALUES = 26, // <Insert Stm> ::= INSERT <Into> Identifier DEFAULT VALUES
    RULE_INSERTSTM_INSERT_IDENTIFIER_SET = 27, // <Insert Stm> ::= INSERT <Into> Identifier SET <Assign List>
    RULE_INSERTCOLUMNS_LPARAN_RPARAN = 28, // <Insert Columns> ::= '(' <Id List> ')'
    RULE_INSERTCOLUMNS = 29, // <Insert Columns> ::= 
    RULE_INTO_INTO = 30, // <Into> ::= INTO
    RULE_INTO = 31, // <Into> ::= 
    RULE_INSERTLIST_COMMA = 32, // <Insert List> ::= <Insert List> ',' <Expression>
    RULE_INSERTLIST = 33, // <Insert List> ::= <Expression>
    RULE_INSERTARRAYS_LPARAN_RPARAN_COMMA = 34, // <Insert Arrays> ::= '(' <Insert List> ')' ',' <Insert Arrays>
    RULE_INSERTARRAYS_LPARAN_RPARAN = 35, // <Insert Arrays> ::= '(' <Insert List> ')'
    RULE_UPDATESTM_UPDATE_IDENTIFIER_SET = 36, // <Update Stm> ::= UPDATE Identifier SET <Assign List> <From Clause> <Where Clause>
    RULE_ASSIGNLIST_IDENTIFIER_EQ_COMMA = 37, // <Assign List> ::= Identifier '=' <Expression> ',' <Assign List>
    RULE_ASSIGNLIST_IDENTIFIER_EQ = 38, // <Assign List> ::= Identifier '=' <Expression>
    RULE_DELETESTM_DELETE_IDENTIFIER = 39, // <Delete Stm> ::= DELETE <From> Identifier <Where Clause>
    RULE_FROM_FROM = 40, // <From> ::= FROM
    RULE_FROM = 41, // <From> ::= 
    RULE_TRUNCATESTM_TRUNCATE_TABLE_IDENTIFIER = 42, // <Truncate Stm> ::= TRUNCATE TABLE Identifier
    RULE_UNIONSTM = 43, // <Union Stm> ::= <Select Stm> <Union> <Union Stm>
    RULE_UNIONSTM2 = 44, // <Union Stm> ::= <Select Stm>
    RULE_UNION_UNION_ALL = 45, // <Union> ::= UNION ALL
    RULE_UNION_UNION = 46, // <Union> ::= UNION
    RULE_SELECTSTM_SELECT = 47, // <Select Stm> ::= SELECT <Columns> <Into Clause> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause>
    RULE_COLUMNS_TIMES = 48, // <Columns> ::= <Restriction> <top> '*'
    RULE_COLUMNS = 49, // <Columns> ::= <Restriction> <top> <Column List>
    RULE_TOP_TOP_INTEGERLITERAL_PERCENT = 50, // <top> ::= TOP IntegerLiteral PERCENT
    RULE_TOP_TOP_INTEGERLITERAL = 51, // <top> ::= TOP IntegerLiteral
    RULE_TOP = 52, // <top> ::= 
    RULE_COLUMNLIST_COMMA = 53, // <Column List> ::= <Column Source> ',' <Column List>
    RULE_COLUMNLIST = 54, // <Column List> ::= <Column Source>
    RULE_COLUMNSOURCE_IDENTIFIER_EQ = 55, // <Column Source> ::= Identifier '=' <Expression>
    RULE_COLUMNSOURCE = 56, // <Column Source> ::= <Expression> <alias>
    RULE_COLUMNSOURCE_IDENDIFIER = 57, // <Column Source> ::= Idendifier
    RULE_ALIAS_AS_IDENTIFIER = 58, // <alias> ::= AS Identifier
    RULE_ALIAS_AS_STRINGLITERAL = 59, // <alias> ::= AS StringLiteral
    RULE_ALIAS_IDENTIFIER = 60, // <alias> ::= Identifier
    RULE_ALIAS = 61, // <alias> ::= 
    RULE_ALLDISTINCT_ALL = 62, // <all distinct> ::= ALL
    RULE_ALLDISTINCT_DISTINCT = 63, // <all distinct> ::= DISTINCT
    RULE_RESTRICTION = 64, // <Restriction> ::= <all distinct>
    RULE_RESTRICTION2 = 65, // <Restriction> ::= 
    RULE_INTOCLAUSE_INTO_IDENTIFIER = 66, // <Into Clause> ::= INTO Identifier
    RULE_INTOCLAUSE = 67, // <Into Clause> ::= 
    RULE_FROMCLAUSE_FROM = 68, // <From Clause> ::= FROM <table source list>
    RULE_FROMCLAUSE = 69, // <From Clause> ::= 
    RULE_TABLESOURCELIST_COMMA = 70, // <table source list> ::= <table source> ',' <table source list>
    RULE_TABLESOURCELIST_CROSS_JOIN = 71, // <table source list> ::= <table source> CROSS JOIN <table source list>
    RULE_TABLESOURCELIST = 72, // <table source list> ::= <table source>
    RULE_TABLESOURCE_IDENTIFIER = 73, // <table source> ::= Identifier <alias>
    RULE_TABLESOURCE_LPARAN_RPARAN = 74, // <table source> ::= '(' <Union Stm> ')' <alias>
    RULE_TABLESOURCE_LPARAN_RPARAN2 = 75, // <table source> ::= '(' <table source list> ')' <alias>
    RULE_TABLESOURCE = 76, // <table source> ::= <Joined Table>
    RULE_JOINEDTABLE_JOIN_ON = 77, // <Joined Table> ::= <table source> <join type> JOIN <table source> ON <search list>
    RULE_JOINEDTABLE_LPARAN_RPARAN = 78, // <Joined Table> ::= '(' <Joined Table> ')'
    RULE_JOINTYPE_INNER = 79, // <join type> ::= INNER
    RULE_JOINTYPE_LEFT = 80, // <join type> ::= LEFT
    RULE_JOINTYPE_LEFT_OUTER = 81, // <join type> ::= LEFT OUTER
    RULE_JOINTYPE_RIGHT = 82, // <join type> ::= RIGHT
    RULE_JOINTYPE_RIGHT_OUTER = 83, // <join type> ::= RIGHT OUTER
    RULE_JOINTYPE_FULL = 84, // <join type> ::= FULL
    RULE_JOINTYPE_FULL_OUTER = 85, // <join type> ::= FULL OUTER
    RULE_JOINTYPE = 86, // <join type> ::= 
    RULE_WHERECLAUSE_WHERE = 87, // <Where Clause> ::= WHERE <search list>
    RULE_WHERECLAUSE = 88, // <Where Clause> ::= 
    RULE_GROUPCLAUSE_GROUP_BY = 89, // <Group Clause> ::= GROUP BY <Id List>
    RULE_GROUPCLAUSE_GROUP_BY_ALL = 90, // <Group Clause> ::= GROUP BY ALL
    RULE_GROUPCLAUSE = 91, // <Group Clause> ::= 
    RULE_IDLIST_COMMA = 92, // <Id List> ::= <Expression> <alias> ',' <Id List>
    RULE_IDLIST = 93, // <Id List> ::= <Expression> <alias>
    RULE_ORDERCLAUSE_ORDER_BY = 94, // <Order Clause> ::= ORDER BY <Order List>
    RULE_ORDERCLAUSE = 95, // <Order Clause> ::= 
    RULE_ORDERLIST_COMMA = 96, // <Order List> ::= <Order Type> <Sort Type> ',' <Order List>
    RULE_ORDERLIST = 97, // <Order List> ::= <Order Type> <Sort Type>
    RULE_ORDERTYPE_IDENTIFIER = 98, // <Order Type> ::= Identifier
    RULE_ORDERTYPE_INTEGERLITERAL = 99, // <Order Type> ::= IntegerLiteral
    RULE_SORTTYPE_ASC = 100, // <Sort Type> ::= ASC
    RULE_SORTTYPE_DESC = 101, // <Sort Type> ::= DESC
    RULE_SORTTYPE = 102, // <Sort Type> ::= 
    RULE_HAVINGCLAUSE_HAVING = 103, // <Having Clause> ::= HAVING <search list>
    RULE_HAVINGCLAUSE = 104, // <Having Clause> ::= 
    RULE_BASEEXPRESSION = 105, // <base expression> ::= <search list>
    RULE_BASEEXPRESSION2 = 106, // <base expression> ::= <predicate>
    RULE_SEARCHLIST_AND = 107, // <search list> ::= <search list> AND <not> <predicate> <alias>
    RULE_SEARCHLIST_OR = 108, // <search list> ::= <search list> OR <not> <predicate> <alias>
    RULE_SEARCHLIST = 109, // <search list> ::= <not> <predicate> <alias>
    RULE_NOT_NOT = 110, // <not> ::= NOT
    RULE_NOT = 111, // <not> ::= 
    RULE_PREDICATE = 112, // <predicate> ::= <comparison>
    RULE_PREDICATE2 = 113, // <predicate> ::= <Expression>
    RULE_PREDICATE_LIKE = 114, // <predicate> ::= <Expression> <not> LIKE <Expression>
    RULE_PREDICATE_BETWEEN_AND = 115, // <predicate> ::= <Expression> <not> BETWEEN <Expression> AND <Expression>
    RULE_PREDICATE_IS_NULL = 116, // <predicate> ::= <Expression> IS <not> NULL
    RULE_PREDICATE_IN_LPARAN_RPARAN = 117, // <predicate> ::= <Expression> <not> IN '(' <Union Stm> ')'
    RULE_PREDICATE_IN_LPARAN_RPARAN2 = 118, // <predicate> ::= <Expression> <not> IN '(' <Expression List> ')'
    RULE_PREDICATE_EXISTS_LPARAN_RPARAN = 119, // <predicate> ::= EXISTS '(' <Union Stm> ')'
    RULE_COMPARISON_GT = 120, // <comparison> ::= <Expression> '>' <Expression>
    RULE_COMPARISON_LT = 121, // <comparison> ::= <Expression> '<' <Expression>
    RULE_COMPARISON_LTEQ = 122, // <comparison> ::= <Expression> '<=' <Expression>
    RULE_COMPARISON_GTEQ = 123, // <comparison> ::= <Expression> '>=' <Expression>
    RULE_COMPARISON_EQ = 124, // <comparison> ::= <Expression> '=' <Expression>
    RULE_COMPARISON_LTGT = 125, // <comparison> ::= <Expression> '<>' <Expression>
    RULE_COMPARISON_EXCLAMEQ = 126, // <comparison> ::= <Expression> '!=' <Expression>
    RULE_EXPRESSIONLIST_COMMA = 127, // <Expression List> ::= <Expression> ',' <Expression List>
    RULE_EXPRESSIONLIST = 128, // <Expression List> ::= <Expression>
    RULE_EXPRESSION_PLUS = 129, // <Expression> ::= <Expression> '+' <Mult Expression>
    RULE_EXPRESSION_MINUS = 130, // <Expression> ::= <Expression> '-' <Mult Expression>
    RULE_EXPRESSION_AMP = 131, // <Expression> ::= <Expression> '&' <Mult Expression>
    RULE_EXPRESSION_PIPE = 132, // <Expression> ::= <Expression> '|' <Mult Expression>
    RULE_EXPRESSION_CARET = 133, // <Expression> ::= <Expression> '^' <Mult Expression>
    RULE_EXPRESSION = 134, // <Expression> ::= <Mult Expression>
    RULE_MULTEXPRESSION_TIMES = 135, // <Mult Expression> ::= <Mult Expression> '*' <Unary Exp>
    RULE_MULTEXPRESSION_DIV = 136, // <Mult Expression> ::= <Mult Expression> '/' <Unary Exp>
    RULE_MULTEXPRESSION_PERCENT = 137, // <Mult Expression> ::= <Mult Expression> '%' <Unary Exp>
    RULE_MULTEXPRESSION = 138, // <Mult Expression> ::= <Unary Exp>
    RULE_UNARYEXP_MINUS = 139, // <Unary Exp> ::= '-' <Value>
    RULE_UNARYEXP_PLUS = 140, // <Unary Exp> ::= '+' <Value>
    RULE_UNARYEXP_TILDE = 141, // <Unary Exp> ::= '~' <Value>
    RULE_UNARYEXP = 142, // <Unary Exp> ::= <Value>
    RULE_VALUE_LPARAN_RPARAN = 143, // <Value> ::= '(' <search list> ')'
    RULE_VALUE_LPARAN_RPARAN2 = 144, // <Value> ::= '(' <Union Stm> ')'
    RULE_VALUE_INTEGERLITERAL = 145, // <Value> ::= IntegerLiteral
    RULE_VALUE_REALLITERAL = 146, // <Value> ::= RealLiteral
    RULE_VALUE_STRINGLITERAL = 147, // <Value> ::= StringLiteral
    RULE_VALUE_NULL = 148, // <Value> ::= NULL
    RULE_VALUE_DEFAULT = 149, // <Value> ::= DEFAULT
    RULE_VALUE = 150, // <Value> ::= <case>
    RULE_VALUE_IDENTIFIER = 151, // <Value> ::= Identifier <Argument List Opt>
    RULE_VALUE2 = 152, // <Value> ::= <special function>
    RULE_VALUE3 = 153, // <Value> ::= <Parameter>
    RULE_VALUE_XEVALEXPRESION = 154, // <Value> ::= XEvalExpresion
    RULE_PARAMETER_COLON_IDENTIFIER = 155, // <Parameter> ::= ':' Identifier
    RULE_CASE_CASE_END = 156, // <case> ::= CASE <casetype> <casewhen list> <caseelse> END
    RULE_CASETYPE = 157, // <casetype> ::= <Expression>
    RULE_CASETYPE2 = 158, // <casetype> ::= 
    RULE_CASEWHENLIST = 159, // <casewhen list> ::= <casewhen> <casewhen list>
    RULE_CASEWHENLIST2 = 160, // <casewhen list> ::= <casewhen>
    RULE_CASEWHEN_WHEN_THEN = 161, // <casewhen> ::= WHEN <search list> THEN <Expression>
    RULE_CASEELSE_ELSE = 162, // <caseelse> ::= ELSE <Expression>
    RULE_CASEELSE = 163, // <caseelse> ::= 
    RULE_SPECIALFUNCTION_CAST_LPARAN_AS_RPARAN = 164, // <special function> ::= CAST '(' <Expression> AS <Type> ')'
    RULE_SPECIALFUNCTION_CONVERT_LPARAN_COMMA_RPARAN = 165, // <special function> ::= CONVERT '(' <Type> ',' <Expression> <style> ')'
    RULE_STYLE_COMMA_INTEGERLITERAL = 166, // <style> ::= ',' IntegerLiteral
    RULE_STYLE_COMMA_STRINGLITERAL = 167, // <style> ::= ',' StringLiteral
    RULE_STYLE = 168, // <style> ::= 
    RULE_ARGUMENTLISTOPT_LPARAN_RPARAN = 169, // <Argument List Opt> ::= '(' <Restriction> <Argument List> ')'
    RULE_ARGUMENTLISTOPT = 170, // <Argument List Opt> ::= 
    RULE_ARGUMENTLIST_COMMA = 171, // <Argument List> ::= <Argument List> ',' <function args>
    RULE_ARGUMENTLIST = 172, // <Argument List> ::= <function args>
    RULE_FUNCTIONARGS_TIMES = 173, // <function args> ::= '*'
    RULE_FUNCTIONARGS = 174, // <function args> ::= <Expression> <alias>
    RULE_FUNCTIONARGS2 = 175  // <function args> ::= 
  };


}
