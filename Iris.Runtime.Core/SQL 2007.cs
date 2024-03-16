
namespace Iris.Runtime.Core
{
  enum SymbolConstants : int
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
    SYMBOL_LPARAN = 9, // '('
    SYMBOL_RPARAN = 10, // ')'
    SYMBOL_TIMES = 11, // '*'
    SYMBOL_COMMA = 12, // ','
    SYMBOL_DIV = 13, // '/'
    SYMBOL_COLON = 14, // ':'
    SYMBOL_PLUS = 15, // '+'
    SYMBOL_LT = 16, // '<'
    SYMBOL_LTEQ = 17, // '<='
    SYMBOL_LTGT = 18, // '<>'
    SYMBOL_EQ = 19, // '='
    SYMBOL_GT = 20, // '>'
    SYMBOL_GTEQ = 21, // '>='
    SYMBOL_ALL = 22, // ALL
    SYMBOL_AND = 23, // AND
    SYMBOL_AS = 24, // as
    SYMBOL_ASC = 25, // ASC
    SYMBOL_AVG = 26, // Avg
    SYMBOL_BETWEEN = 27, // BETWEEN
    SYMBOL_BIGINT = 28, // Bigint
    SYMBOL_BINARY = 29, // Binary
    SYMBOL_BIT = 30, // Bit
    SYMBOL_BY = 31, // BY
    SYMBOL_CASE = 32, // CASE
    SYMBOL_CAST = 33, // CAST
    SYMBOL_CHAR = 34, // Char
    SYMBOL_CHECKSUM = 35, // CheckSum
    SYMBOL_CHECKSUM_AGG = 36, // 'CheckSum_AGG'
    SYMBOL_CONVERT = 37, // CONVERT
    SYMBOL_COUNT = 38, // Count
    SYMBOL_COUNT_BIG = 39, // 'Count_Big'
    SYMBOL_CROSS = 40, // CROSS
    SYMBOL_CURSOR = 41, // Cursor
    SYMBOL_DATEADD = 42, // DATEADD
    SYMBOL_DATEDIFF = 43, // DATEDIFF
    SYMBOL_DATENAME = 44, // DATENAME
    SYMBOL_DATEPART = 45, // DATEPART
    SYMBOL_DATETIME = 46, // Datetime
    SYMBOL_DAY = 47, // DAY
    SYMBOL_DECIMAL = 48, // Decimal
    SYMBOL_DEFAULT = 49, // DEFAULT
    SYMBOL_DELETE = 50, // DELETE
    SYMBOL_DESC = 51, // DESC
    SYMBOL_DISTINCT = 52, // DISTINCT
    SYMBOL_ELSE = 53, // ELSE
    SYMBOL_END = 54, // END
    SYMBOL_FLOAT = 55, // Float
    SYMBOL_FROM = 56, // FROM
    SYMBOL_FULL = 57, // FULL
    SYMBOL_GETDATE = 58, // GETDATE
    SYMBOL_GETUTCDATE = 59, // GETUTCDATE
    SYMBOL_GO = 60, // GO
    SYMBOL_GROUP = 61, // GROUP
    SYMBOL_HAVING = 62, // HAVING
    SYMBOL_ID = 63, // Id
    SYMBOL_IMAGE = 64, // Image
    SYMBOL_IN = 65, // IN
    SYMBOL_INNER = 66, // INNER
    SYMBOL_INSERT = 67, // INSERT
    SYMBOL_INT = 68, // Int
    SYMBOL_INTEGERLITERAL = 69, // IntegerLiteral
    SYMBOL_INTO = 70, // INTO
    SYMBOL_IS = 71, // IS
    SYMBOL_JOIN = 72, // JOIN
    SYMBOL_LEFT = 73, // LEFT
    SYMBOL_LIKE = 74, // LIKE
    SYMBOL_MAX = 75, // Max
    SYMBOL_MIN = 76, // Min
    SYMBOL_MONEY = 77, // Money
    SYMBOL_MONTH = 78, // MONTH
    SYMBOL_NCHAR = 79, // Nchar
    SYMBOL_NOT = 80, // NOT
    SYMBOL_NTEXT = 81, // Ntext
    SYMBOL_NULL = 82, // NULL
    SYMBOL_NUMERIC = 83, // Numeric
    SYMBOL_NVARCHAR = 84, // Nvarchar
    SYMBOL_ON = 85, // ON
    SYMBOL_OR = 86, // OR
    SYMBOL_ORDER = 87, // ORDER
    SYMBOL_OUTER = 88, // OUTER
    SYMBOL_PERCENT2 = 89, // PERCENT
    SYMBOL_REAL = 90, // Real
    SYMBOL_REALLITERAL = 91, // RealLiteral
    SYMBOL_RIGHT = 92, // RIGHT
    SYMBOL_SELECT = 93, // SELECT
    SYMBOL_SET = 94, // SET
    SYMBOL_SMALLDATETIME = 95, // Smalldatetime
    SYMBOL_SMALLINT = 96, // Smallint
    SYMBOL_SMALLMONEY = 97, // Smallmoney
    SYMBOL_SQL_VARIANT = 98, // 'Sql_Variant'
    SYMBOL_STDEV = 99, // StDev
    SYMBOL_STDEVP = 100, // StDevP
    SYMBOL_STRINGLITERAL = 101, // StringLiteral
    SYMBOL_SUM = 102, // Sum
    SYMBOL_TEXT = 103, // Text
    SYMBOL_THEN = 104, // THEN
    SYMBOL_TIMESTAMP = 105, // Timestamp
    SYMBOL_TINYINT = 106, // Tinyint
    SYMBOL_TOP = 107, // TOP
    SYMBOL_UNION = 108, // UNION
    SYMBOL_UNIQUEIDENTIFIER = 109, // Uniqueidentifier
    SYMBOL_UPDATE = 110, // UPDATE
    SYMBOL_VALUES = 111, // VALUES
    SYMBOL_VAR = 112, // Var
    SYMBOL_VARBINARY = 113, // Varbinary
    SYMBOL_VARCHAR = 114, // Varchar
    SYMBOL_VARP = 115, // VarP
    SYMBOL_WHEN = 116, // WHEN
    SYMBOL_WHERE = 117, // WHERE
    SYMBOL_XEVALEXPRESION = 118, // XEvalExpresion
    SYMBOL_YEAR = 119, // YEAR
    SYMBOL_AGGREGATEFN = 120, // <Aggregate Fn>
    SYMBOL_ARITHOPERATOR = 121, // <Arith Operator>
    SYMBOL_ASSIGNLIST = 122, // <Assign List>
    SYMBOL_BASETYPE = 123, // <Base Type>
    SYMBOL_CASEELSE = 124, // <Case Else>
    SYMBOL_COLUMNITEM = 125, // <Column Item>
    SYMBOL_COLUMNLIST = 126, // <Column List>
    SYMBOL_COLUMNSOURCE = 127, // <Column Source>
    SYMBOL_COLUMNRESTRICTION = 128, // <ColumnRestriction>
    SYMBOL_COLUMNS = 129, // <Columns>
    SYMBOL_COMPOPERATOR = 130, // <Comp Operator>
    SYMBOL_CONVERTFN = 131, // <Convert Fn>
    SYMBOL_DATATYPE = 132, // <Data Type>
    SYMBOL_DATETIMEFN = 133, // <Date Time Fn>
    SYMBOL_DELETESTM = 134, // <Delete Stm>
    SYMBOL_EXPRESSION = 135, // <Expression>
    SYMBOL_FROMCLAUSE = 136, // <From Clause>
    SYMBOL_FROMLIST = 137, // <From List>
    SYMBOL_FROMMEMBER = 138, // <From Member>
    SYMBOL_FUNCTION = 139, // <Function>
    SYMBOL_GO2 = 140, // <GO>
    SYMBOL_GROUPCLAUSE = 141, // <Group Clause>
    SYMBOL_GROUPITEM = 142, // <Group Item>
    SYMBOL_GROUPLIST = 143, // <Group List>
    SYMBOL_HAVINGCLAUSE = 144, // <Having Clause>
    SYMBOL_INSERTCOLUMNLIST = 145, // <Insert Column List>
    SYMBOL_INSERTCOLUMNS = 146, // <Insert Columns>
    SYMBOL_INSERTLIST = 147, // <Insert List>
    SYMBOL_INSERTSTM = 148, // <Insert Stm>
    SYMBOL_INSERTUPDATEITEM = 149, // <Insert Update Item>
    SYMBOL_INTO2 = 150, // <Into>
    SYMBOL_JOIN2 = 151, // <Join>
    SYMBOL_JOINCHAIN = 152, // <Join Chain>
    SYMBOL_JOINLIST = 153, // <Join List>
    SYMBOL_JOINMEMBER = 154, // <Join Member>
    SYMBOL_JOINTYPE = 155, // <Join Type>
    SYMBOL_LOGICOPERATOR = 156, // <Logic Operator>
    SYMBOL_OPERATION = 157, // <Operation>
    SYMBOL_ORDERCLAUSE = 158, // <Order Clause>
    SYMBOL_ORDERLIST = 159, // <Order List>
    SYMBOL_ORDERTYPE = 160, // <Order Type>
    SYMBOL_PARAMETER = 161, // <Parameter>
    SYMBOL_QUERIES = 162, // <Queries>
    SYMBOL_QUERY = 163, // <Query>
    SYMBOL_RESTRICTION = 164, // <Restriction>
    SYMBOL_SELECTSTM = 165, // <Select Stm>
    SYMBOL_TUPLE = 166, // <Tuple>
    SYMBOL_TXTEXPRESSION = 167, // <Txt Expression>
    SYMBOL_UNION2 = 168, // <Union>
    SYMBOL_UPDATEFROM = 169, // <Update From>
    SYMBOL_UPDATESTM = 170, // <Update Stm>
    SYMBOL_VALUE = 171, // <Value>
    SYMBOL_WHENCASE = 172, // <When Case>
    SYMBOL_WHENCHAIN = 173, // <When Chain>
    SYMBOL_WHERECLAUSE = 174  // <Where Clause>
  };

  enum RuleConstants : int
  {
    RULE_QUERIES = 0, // <Queries> ::= <Query>
    RULE_QUERIES2 = 1, // <Queries> ::= <Query> <Queries>
    RULE_QUERY = 2, // <Query> ::= <Select Stm>
    RULE_QUERY2 = 3, // <Query> ::= <Expression>
    RULE_QUERY3 = 4, // <Query> ::= <Insert Stm> <GO>
    RULE_QUERY4 = 5, // <Query> ::= <Update Stm> <GO>
    RULE_QUERY5 = 6, // <Query> ::= <Delete Stm> <GO>
    RULE_GO_GO = 7, // <GO> ::= GO
    RULE_GO = 8, // <GO> ::= 
    RULE_INSERTSTM_INSERT_ID = 9, // <Insert Stm> ::= INSERT <Into> Id <Insert Columns> <Select Stm>
    RULE_INSERTSTM_INSERT_ID_VALUES_LPARAN_RPARAN = 10, // <Insert Stm> ::= INSERT <Into> Id <Insert Columns> VALUES '(' <Insert List> ')'
    RULE_INSERTCOLUMNS_LPARAN_RPARAN = 11, // <Insert Columns> ::= '(' <Insert Column List> ')'
    RULE_INSERTCOLUMNS = 12, // <Insert Columns> ::= 
    RULE_INSERTCOLUMNLIST_ID = 13, // <Insert Column List> ::= Id
    RULE_INSERTCOLUMNLIST_ID_COMMA = 14, // <Insert Column List> ::= Id ',' <Insert Column List>
    RULE_INTO_INTO = 15, // <Into> ::= INTO
    RULE_INTO = 16, // <Into> ::= 
    RULE_INSERTUPDATEITEM = 17, // <Insert Update Item> ::= <Txt Expression>
    RULE_INSERTUPDATEITEM_DEFAULT = 18, // <Insert Update Item> ::= DEFAULT
    RULE_INSERTLIST_COMMA = 19, // <Insert List> ::= <Insert List> ',' <Insert Update Item>
    RULE_INSERTLIST = 20, // <Insert List> ::= <Insert Update Item>
    RULE_UPDATESTM_UPDATE_ID_SET = 21, // <Update Stm> ::= UPDATE Id SET <Assign List> <Update From> <Where Clause>
    RULE_UPDATEFROM = 22, // <Update From> ::= <From Clause>
    RULE_UPDATEFROM2 = 23, // <Update From> ::= 
    RULE_ASSIGNLIST_ID_EQ_COMMA = 24, // <Assign List> ::= Id '=' <Insert Update Item> ',' <Assign List>
    RULE_ASSIGNLIST_ID_EQ = 25, // <Assign List> ::= Id '=' <Insert Update Item>
    RULE_DELETESTM_DELETE_FROM_ID = 26, // <Delete Stm> ::= DELETE FROM Id <Where Clause>
    RULE_SELECTSTM_SELECT = 27, // <Select Stm> ::= SELECT <Columns> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause> <Union>
    RULE_SELECTSTM_LPARAN_RPARAN_ID = 28, // <Select Stm> ::= '(' <Select Stm> ')' Id
    RULE_SELECTSTM_LPARAN_RPARAN_AS_ID = 29, // <Select Stm> ::= '(' <Select Stm> ')' as Id
    RULE_COLUMNS_TIMES = 30, // <Columns> ::= <ColumnRestriction> '*'
    RULE_COLUMNS = 31, // <Columns> ::= <ColumnRestriction> <Column List>
    RULE_COLUMNRESTRICTION = 32, // <ColumnRestriction> ::= <Restriction>
    RULE_COLUMNRESTRICTION_TOP_INTEGERLITERAL = 33, // <ColumnRestriction> ::= TOP IntegerLiteral
    RULE_COLUMNRESTRICTION_TOP_INTEGERLITERAL_PERCENT = 34, // <ColumnRestriction> ::= TOP IntegerLiteral PERCENT
    RULE_COLUMNLIST_COMMA = 35, // <Column List> ::= <Column Item> ',' <Column List>
    RULE_COLUMNLIST = 36, // <Column List> ::= <Column Item>
    RULE_COLUMNITEM = 37, // <Column Item> ::= <Column Source>
    RULE_COLUMNITEM_ID = 38, // <Column Item> ::= <Column Source> Id
    RULE_COLUMNITEM_AS_ID = 39, // <Column Item> ::= <Column Source> as Id
    RULE_COLUMNSOURCE = 40, // <Column Source> ::= <Value>
    RULE_COLUMNSOURCE_ID_EQ_CASE_END = 41, // <Column Source> ::= Id '=' CASE <Txt Expression> <When Chain> <Case Else> END
    RULE_COLUMNSOURCE_ID_EQ_CASE_END2 = 42, // <Column Source> ::= Id '=' CASE <When Chain> <Case Else> END
    RULE_CASEELSE_ELSE = 43, // <Case Else> ::= ELSE <Value>
    RULE_CASEELSE = 44, // <Case Else> ::= 
    RULE_WHENCHAIN = 45, // <When Chain> ::= <When Case>
    RULE_WHENCHAIN2 = 46, // <When Chain> ::= <When Case> <When Chain>
    RULE_WHENCASE_WHEN_THEN = 47, // <When Case> ::= WHEN <Txt Expression> THEN <Value>
    RULE_RESTRICTION_DISTINCT = 48, // <Restriction> ::= DISTINCT
    RULE_RESTRICTION = 49, // <Restriction> ::= 
    RULE_FUNCTION = 50, // <Function> ::= <Aggregate Fn>
    RULE_FUNCTION2 = 51, // <Function> ::= <Date Time Fn>
    RULE_FUNCTION3 = 52, // <Function> ::= <Convert Fn>
    RULE_AGGREGATEFN_COUNT_LPARAN_TIMES_RPARAN = 53, // <Aggregate Fn> ::= Count '(' '*' ')'
    RULE_AGGREGATEFN_COUNT_BIG_LPARAN_RPARAN = 54, // <Aggregate Fn> ::= 'Count_Big' '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_COUNT_LPARAN_RPARAN = 55, // <Aggregate Fn> ::= Count '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_AVG_LPARAN_RPARAN = 56, // <Aggregate Fn> ::= Avg '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_MIN_LPARAN_RPARAN = 57, // <Aggregate Fn> ::= Min '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_MAX_LPARAN_RPARAN = 58, // <Aggregate Fn> ::= Max '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_STDEV_LPARAN_RPARAN = 59, // <Aggregate Fn> ::= StDev '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_STDEVP_LPARAN_RPARAN = 60, // <Aggregate Fn> ::= StDevP '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_SUM_LPARAN_RPARAN = 61, // <Aggregate Fn> ::= Sum '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_VAR_LPARAN_RPARAN = 62, // <Aggregate Fn> ::= Var '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_VARP_LPARAN_RPARAN = 63, // <Aggregate Fn> ::= VarP '(' <Restriction> <Txt Expression> ')'
    RULE_AGGREGATEFN_CHECKSUM_LPARAN_TIMES_RPARAN = 64, // <Aggregate Fn> ::= CheckSum '(' '*' ')'
    RULE_AGGREGATEFN_CHECKSUM_LPARAN_RPARAN = 65, // <Aggregate Fn> ::= CheckSum '(' <Txt Expression> ')'
    RULE_AGGREGATEFN_CHECKSUM_AGG_LPARAN_RPARAN = 66, // <Aggregate Fn> ::= 'CheckSum_AGG' '(' <Restriction> <Txt Expression> ')'
    RULE_DATETIMEFN_DATEADD_LPARAN_ID_COMMA_INTEGERLITERAL_COMMA_RPARAN = 67, // <Date Time Fn> ::= DATEADD '(' Id ',' IntegerLiteral ',' <Txt Expression> ')'
    RULE_DATETIMEFN_DATEDIFF_LPARAN_ID_COMMA_COMMA_RPARAN = 68, // <Date Time Fn> ::= DATEDIFF '(' Id ',' <Txt Expression> ',' <Txt Expression> ')'
    RULE_DATETIMEFN_DATENAME_LPARAN_ID_COMMA_RPARAN = 69, // <Date Time Fn> ::= DATENAME '(' Id ',' <Txt Expression> ')'
    RULE_DATETIMEFN_DATEPART_LPARAN_ID_COMMA_RPARAN = 70, // <Date Time Fn> ::= DATEPART '(' Id ',' <Txt Expression> ')'
    RULE_DATETIMEFN_DAY_LPARAN_RPARAN = 71, // <Date Time Fn> ::= DAY '(' <Txt Expression> ')'
    RULE_DATETIMEFN_GETDATE_LPARAN_RPARAN = 72, // <Date Time Fn> ::= GETDATE '(' ')'
    RULE_DATETIMEFN_GETUTCDATE_LPARAN_RPARAN = 73, // <Date Time Fn> ::= GETUTCDATE '(' ')'
    RULE_DATETIMEFN_MONTH_LPARAN_RPARAN = 74, // <Date Time Fn> ::= MONTH '(' <Txt Expression> ')'
    RULE_DATETIMEFN_YEAR_LPARAN_RPARAN = 75, // <Date Time Fn> ::= YEAR '(' <Txt Expression> ')'
    RULE_CONVERTFN_CAST_LPARAN_AS_RPARAN = 76, // <Convert Fn> ::= CAST '(' <Txt Expression> as <Data Type> ')'
    RULE_CONVERTFN_CONVERT_LPARAN_COMMA_RPARAN = 77, // <Convert Fn> ::= CONVERT '(' <Data Type> ',' <Txt Expression> ')'
    RULE_CONVERTFN_CONVERT_LPARAN_COMMA_COMMA_INTEGERLITERAL_RPARAN = 78, // <Convert Fn> ::= CONVERT '(' <Data Type> ',' <Txt Expression> ',' IntegerLiteral ')'
    RULE_DATATYPE = 79, // <Data Type> ::= <Base Type>
    RULE_DATATYPE_LPARAN_INTEGERLITERAL_RPARAN = 80, // <Data Type> ::= <Base Type> '(' IntegerLiteral ')'
    RULE_DATATYPE_LPARAN_INTEGERLITERAL_COMMA_INTEGERLITERAL_RPARAN = 81, // <Data Type> ::= <Base Type> '(' IntegerLiteral ',' IntegerLiteral ')'
    RULE_BASETYPE_BIGINT = 82, // <Base Type> ::= Bigint
    RULE_BASETYPE_DECIMAL = 83, // <Base Type> ::= Decimal
    RULE_BASETYPE_INT = 84, // <Base Type> ::= Int
    RULE_BASETYPE_NUMERIC = 85, // <Base Type> ::= Numeric
    RULE_BASETYPE_SMALLINT = 86, // <Base Type> ::= Smallint
    RULE_BASETYPE_MONEY = 87, // <Base Type> ::= Money
    RULE_BASETYPE_TINYINT = 88, // <Base Type> ::= Tinyint
    RULE_BASETYPE_SMALLMONEY = 89, // <Base Type> ::= Smallmoney
    RULE_BASETYPE_BIT = 90, // <Base Type> ::= Bit
    RULE_BASETYPE_FLOAT = 91, // <Base Type> ::= Float
    RULE_BASETYPE_REAL = 92, // <Base Type> ::= Real
    RULE_BASETYPE_DATETIME = 93, // <Base Type> ::= Datetime
    RULE_BASETYPE_SMALLDATETIME = 94, // <Base Type> ::= Smalldatetime
    RULE_BASETYPE_CHAR = 95, // <Base Type> ::= Char
    RULE_BASETYPE_TEXT = 96, // <Base Type> ::= Text
    RULE_BASETYPE_VARCHAR = 97, // <Base Type> ::= Varchar
    RULE_BASETYPE_NCHAR = 98, // <Base Type> ::= Nchar
    RULE_BASETYPE_NTEXT = 99, // <Base Type> ::= Ntext
    RULE_BASETYPE_NVARCHAR = 100, // <Base Type> ::= Nvarchar
    RULE_BASETYPE_BINARY = 101, // <Base Type> ::= Binary
    RULE_BASETYPE_IMAGE = 102, // <Base Type> ::= Image
    RULE_BASETYPE_VARBINARY = 103, // <Base Type> ::= Varbinary
    RULE_BASETYPE_CURSOR = 104, // <Base Type> ::= Cursor
    RULE_BASETYPE_TIMESTAMP = 105, // <Base Type> ::= Timestamp
    RULE_BASETYPE_SQL_VARIANT = 106, // <Base Type> ::= 'Sql_Variant'
    RULE_BASETYPE_UNIQUEIDENTIFIER = 107, // <Base Type> ::= Uniqueidentifier
    RULE_FROMCLAUSE_FROM = 108, // <From Clause> ::= FROM <From List> <Join Chain>
    RULE_FROMLIST_COMMA = 109, // <From List> ::= <From Member> ',' <From List>
    RULE_FROMLIST_CROSS_JOIN = 110, // <From List> ::= <From Member> CROSS JOIN <From List>
    RULE_FROMLIST = 111, // <From List> ::= <From Member>
    RULE_FROMMEMBER_ID = 112, // <From Member> ::= Id
    RULE_FROMMEMBER_ID_ID = 113, // <From Member> ::= Id Id
    RULE_FROMMEMBER_ID_AS_ID = 114, // <From Member> ::= Id as Id
    RULE_FROMMEMBER_LPARAN_RPARAN_ID = 115, // <From Member> ::= '(' <Select Stm> ')' Id
    RULE_FROMMEMBER_LPARAN_RPARAN_AS_ID = 116, // <From Member> ::= '(' <Select Stm> ')' as Id
    RULE_JOINCHAIN = 117, // <Join Chain> ::= <Join> <Join Chain>
    RULE_JOINCHAIN2 = 118, // <Join Chain> ::= 
    RULE_JOIN_ON = 119, // <Join> ::= <Join Type> <Join List> <Join Chain> ON <Expression>
    RULE_JOINTYPE_INNER_JOIN = 120, // <Join Type> ::= INNER JOIN
    RULE_JOINTYPE_LEFT_JOIN = 121, // <Join Type> ::= LEFT JOIN
    RULE_JOINTYPE_LEFT_OUTER_JOIN = 122, // <Join Type> ::= LEFT OUTER JOIN
    RULE_JOINTYPE_RIGHT_JOIN = 123, // <Join Type> ::= RIGHT JOIN
    RULE_JOINTYPE_RIGHT_OUTER_JOIN = 124, // <Join Type> ::= RIGHT OUTER JOIN
    RULE_JOINTYPE_FULL_JOIN = 125, // <Join Type> ::= FULL JOIN
    RULE_JOINTYPE_FULL_OUTER_JOIN = 126, // <Join Type> ::= FULL OUTER JOIN
    RULE_JOINTYPE_JOIN = 127, // <Join Type> ::= JOIN
    RULE_JOINLIST = 128, // <Join List> ::= <Join Member>
    RULE_JOINLIST_COMMA = 129, // <Join List> ::= <Join Member> ',' <Join List>
    RULE_JOINMEMBER = 130, // <Join Member> ::= <From Member>
    RULE_JOINMEMBER2 = 131, // <Join Member> ::= <Join Chain>
    RULE_WHERECLAUSE_WHERE = 132, // <Where Clause> ::= WHERE <Expression>
    RULE_WHERECLAUSE = 133, // <Where Clause> ::= 
    RULE_GROUPCLAUSE_GROUP_BY = 134, // <Group Clause> ::= GROUP BY <Group List>
    RULE_GROUPCLAUSE = 135, // <Group Clause> ::= 
    RULE_GROUPLIST_COMMA = 136, // <Group List> ::= <Group Item> ',' <Group List>
    RULE_GROUPLIST = 137, // <Group List> ::= <Group Item>
    RULE_GROUPITEM_ID = 138, // <Group Item> ::= Id
    RULE_GROUPITEM_INTEGERLITERAL = 139, // <Group Item> ::= IntegerLiteral
    RULE_GROUPITEM = 140, // <Group Item> ::= <Function>
    RULE_ORDERCLAUSE_ORDER_BY = 141, // <Order Clause> ::= ORDER BY <Order List>
    RULE_ORDERCLAUSE = 142, // <Order Clause> ::= 
    RULE_ORDERLIST_ID_COMMA = 143, // <Order List> ::= Id <Order Type> ',' <Order List>
    RULE_ORDERLIST_ID = 144, // <Order List> ::= Id <Order Type>
    RULE_ORDERTYPE_ASC = 145, // <Order Type> ::= ASC
    RULE_ORDERTYPE_DESC = 146, // <Order Type> ::= DESC
    RULE_ORDERTYPE = 147, // <Order Type> ::= 
    RULE_HAVINGCLAUSE_HAVING = 148, // <Having Clause> ::= HAVING <Expression>
    RULE_HAVINGCLAUSE = 149, // <Having Clause> ::= 
    RULE_UNION_UNION = 150, // <Union> ::= UNION <Select Stm>
    RULE_UNION_UNION_ALL = 151, // <Union> ::= UNION ALL <Select Stm>
    RULE_UNION = 152, // <Union> ::= 
    RULE_TXTEXPRESSION = 153, // <Txt Expression> ::= <Expression>
    RULE_TXTEXPRESSION_COMMA = 154, // <Txt Expression> ::= <Expression> ',' <Txt Expression>
    RULE_EXPRESSION = 155, // <Expression> ::= <Expression> <Logic Operator> <Expression>
    RULE_EXPRESSION_NOT_LPARAN_RPARAN = 156, // <Expression> ::= NOT '(' <Expression> ')'
    RULE_EXPRESSION2 = 157, // <Expression> ::= <Operation>
    RULE_EXPRESSION_LPARAN_RPARAN = 158, // <Expression> ::= '(' <Expression> ')'
    RULE_OPERATION_BETWEEN_AND = 159, // <Operation> ::= <Value> BETWEEN <Value> AND <Value>
    RULE_OPERATION_NOT_BETWEEN_AND = 160, // <Operation> ::= <Value> NOT BETWEEN <Value> AND <Value>
    RULE_OPERATION_IS_NOT_NULL = 161, // <Operation> ::= <Value> IS NOT NULL
    RULE_OPERATION_IS_NULL = 162, // <Operation> ::= <Value> IS NULL
    RULE_OPERATION_LIKE = 163, // <Operation> ::= <Value> LIKE <Value>
    RULE_OPERATION_IN = 164, // <Operation> ::= <Value> IN <Tuple>
    RULE_OPERATION_NOT_IN = 165, // <Operation> ::= <Value> NOT IN <Tuple>
    RULE_OPERATION = 166, // <Operation> ::= <Value> <Comp Operator> <Value>
    RULE_OPERATION2 = 167, // <Operation> ::= <Value>
    RULE_COMPOPERATOR_EQ = 168, // <Comp Operator> ::= '='
    RULE_COMPOPERATOR_LTGT = 169, // <Comp Operator> ::= '<>'
    RULE_COMPOPERATOR_EXCLAMEQ = 170, // <Comp Operator> ::= '!='
    RULE_COMPOPERATOR_GT = 171, // <Comp Operator> ::= '>'
    RULE_COMPOPERATOR_GTEQ = 172, // <Comp Operator> ::= '>='
    RULE_COMPOPERATOR_LT = 173, // <Comp Operator> ::= '<'
    RULE_COMPOPERATOR_LTEQ = 174, // <Comp Operator> ::= '<='
    RULE_LOGICOPERATOR_AND = 175, // <Logic Operator> ::= AND
    RULE_LOGICOPERATOR_OR = 176, // <Logic Operator> ::= OR
    RULE_VALUE = 177, // <Value> ::= <Tuple>
    RULE_VALUE2 = 178, // <Value> ::= <Function>
    RULE_VALUE3 = 179, // <Value> ::= <Parameter>
    RULE_VALUE_ID = 180, // <Value> ::= Id
    RULE_VALUE_INTEGERLITERAL = 181, // <Value> ::= IntegerLiteral
    RULE_VALUE_REALLITERAL = 182, // <Value> ::= RealLiteral
    RULE_VALUE_STRINGLITERAL = 183, // <Value> ::= StringLiteral
    RULE_VALUE4 = 184, // <Value> ::= <Value> <Arith Operator> <Value>
    RULE_VALUE_LPARAN_RPARAN = 185, // <Value> ::= '(' <Value> <Arith Operator> <Value> ')'
    RULE_VALUE_MINUS = 186, // <Value> ::= '-' <Value>
    RULE_VALUE_XEVALEXPRESION = 187, // <Value> ::= XEvalExpresion
    RULE_VALUE_NULL = 188, // <Value> ::= NULL
    RULE_ARITHOPERATOR_PLUS = 189, // <Arith Operator> ::= '+'
    RULE_ARITHOPERATOR_MINUS = 190, // <Arith Operator> ::= '-'
    RULE_ARITHOPERATOR_TIMES = 191, // <Arith Operator> ::= '*'
    RULE_ARITHOPERATOR_DIV = 192, // <Arith Operator> ::= '/'
    RULE_ARITHOPERATOR_PERCENT = 193, // <Arith Operator> ::= '%'
    RULE_PARAMETER_COLON_ID = 194, // <Parameter> ::= ':' Id
    RULE_TUPLE_LPARAN_RPARAN = 195, // <Tuple> ::= '(' <Select Stm> ')'
    RULE_TUPLE_LPARAN_RPARAN2 = 196  // <Tuple> ::= '(' <Txt Expression> ')'
  };

}
