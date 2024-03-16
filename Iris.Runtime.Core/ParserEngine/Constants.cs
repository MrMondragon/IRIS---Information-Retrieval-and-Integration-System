namespace Iris.Runtime.Core
{
  public enum SQLSymbolConstants : int
  {
    SYMBOL_EOF = 0, // (EOF)
    SYMBOL_ERROR = 1, // (Error)
    SYMBOL_WHITESPACE = 2, // (Whitespace)
    SYMBOL_COMMENTEND = 3, // (Comment End)
    SYMBOL_COMMENTLINE = 4, // (Comment Line)
    SYMBOL_COMMENTSTART = 5, // (Comment Start)
    SYMBOL_MINUS = 6, // -
    SYMBOL_EXCLAMEQ = 7, // !=
    SYMBOL_PERCENT = 8, // %
    SYMBOL_LPARAN = 9, // (
    SYMBOL_RPARAN = 10, // )
    SYMBOL_TIMES = 11, // *
    SYMBOL_COMMA = 12, // ,
    SYMBOL_DIV = 13, // /
    SYMBOL_COLON = 14, // :
    SYMBOL_PLUS = 15, // +
    SYMBOL_LT = 16, // <
    SYMBOL_LTEQ = 17, // <=
    SYMBOL_LTGT = 18, // <>
    SYMBOL_EQ = 19, // =
    SYMBOL_GT = 20, // >
    SYMBOL_GTEQ = 21, // >=
    SYMBOL_ALL = 22, // ALL
    SYMBOL_AND = 23, // AND
    SYMBOL_AS = 24, // AS
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
    SYMBOL_CHECKSUM_AGG = 36, // CheckSum_AGG
    SYMBOL_CONVERT = 37, // CONVERT
    SYMBOL_COUNT = 38, // Count
    SYMBOL_COUNT_BIG = 39, // Count_Big
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
    SYMBOL_SQL_VARIANT = 98, // Sql_Variant
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

  public enum SQLRuleConstants : int
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
    RULE_INSERTSTM_INSERT_ID_VALUES_LPARAN_RPARAN = 10, // <Insert Stm> ::= INSERT <Into> Id <Insert Columns> VALUES ( <Insert List> )
    RULE_INSERTCOLUMNS_LPARAN_RPARAN = 11, // <Insert Columns> ::= ( <Insert Column List> )
    RULE_INSERTCOLUMNS = 12, // <Insert Columns> ::= 
    RULE_INSERTCOLUMNLIST_ID = 13, // <Insert Column List> ::= Id
    RULE_INSERTCOLUMNLIST_ID_COMMA = 14, // <Insert Column List> ::= Id , <Insert Column List>
    RULE_INTO_INTO = 15, // <Into> ::= INTO
    RULE_INTO = 16, // <Into> ::= 
    RULE_INSERTUPDATEITEM = 17, // <Insert Update Item> ::= <Txt Expression>
    RULE_INSERTUPDATEITEM_DEFAULT = 18, // <Insert Update Item> ::= DEFAULT
    RULE_INSERTLIST_COMMA = 19, // <Insert List> ::= <Insert List> , <Insert Update Item>
    RULE_INSERTLIST = 20, // <Insert List> ::= <Insert Update Item>
    RULE_UPDATESTM_UPDATE_ID_SET = 21, // <Update Stm> ::= UPDATE Id SET <Assign List> <Update From> <Where Clause>
    RULE_UPDATEFROM = 22, // <Update From> ::= <From Clause>
    RULE_UPDATEFROM2 = 23, // <Update From> ::= 
    RULE_ASSIGNLIST_ID_EQ_COMMA = 24, // <Assign List> ::= Id = <Insert Update Item> , <Assign List>
    RULE_ASSIGNLIST_ID_EQ = 25, // <Assign List> ::= Id = <Insert Update Item>
    RULE_DELETESTM_DELETE_FROM_ID = 26, // <Delete Stm> ::= DELETE FROM Id <Where Clause>
    RULE_SELECTSTM_SELECT = 27, // <Select Stm> ::= SELECT <Columns> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause> <Union>
    RULE_COLUMNS_TIMES = 28, // <Columns> ::= <ColumnRestriction> *
    RULE_COLUMNS = 29, // <Columns> ::= <ColumnRestriction> <Column List>
    RULE_COLUMNRESTRICTION = 30, // <ColumnRestriction> ::= <Restriction>
    RULE_COLUMNRESTRICTION_TOP_INTEGERLITERAL = 31, // <ColumnRestriction> ::= TOP IntegerLiteral
    RULE_COLUMNRESTRICTION_TOP_INTEGERLITERAL_PERCENT = 32, // <ColumnRestriction> ::= TOP IntegerLiteral PERCENT
    RULE_COLUMNLIST_COMMA = 33, // <Column List> ::= <Column Item> , <Column List>
    RULE_COLUMNLIST = 34, // <Column List> ::= <Column Item>
    RULE_COLUMNITEM = 35, // <Column Item> ::= <Column Source>
    RULE_COLUMNITEM_ID = 36, // <Column Item> ::= <Column Source> Id
    RULE_COLUMNITEM_AS_ID = 37, // <Column Item> ::= <Column Source> AS Id
    RULE_COLUMNSOURCE = 38, // <Column Source> ::= <Value>
    RULE_COLUMNSOURCE_ID_EQ_CASE_END = 39, // <Column Source> ::= Id = CASE <Txt Expression> <When Chain> <Case Else> END
    RULE_COLUMNSOURCE_ID_EQ_CASE_END2 = 40, // <Column Source> ::= Id = CASE <When Chain> <Case Else> END
    RULE_CASEELSE_ELSE = 41, // <Case Else> ::= ELSE <Value>
    RULE_CASEELSE = 42, // <Case Else> ::= 
    RULE_WHENCHAIN = 43, // <When Chain> ::= <When Case>
    RULE_WHENCHAIN2 = 44, // <When Chain> ::= <When Case> <When Chain>
    RULE_WHENCASE_WHEN_THEN = 45, // <When Case> ::= WHEN <Txt Expression> THEN <Value>
    RULE_RESTRICTION_DISTINCT = 46, // <Restriction> ::= DISTINCT
    RULE_RESTRICTION = 47, // <Restriction> ::= 
    RULE_FUNCTION = 48, // <Function> ::= <Aggregate Fn>
    RULE_FUNCTION2 = 49, // <Function> ::= <Date Time Fn>
    RULE_FUNCTION3 = 50, // <Function> ::= <Convert Fn>
    RULE_AGGREGATEFN_COUNT_LPARAN_TIMES_RPARAN = 51, // <Aggregate Fn> ::= Count ( * )
    RULE_AGGREGATEFN_COUNT_BIG_LPARAN_RPARAN = 52, // <Aggregate Fn> ::= Count_Big ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_COUNT_LPARAN_RPARAN = 53, // <Aggregate Fn> ::= Count ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_AVG_LPARAN_RPARAN = 54, // <Aggregate Fn> ::= Avg ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_MIN_LPARAN_RPARAN = 55, // <Aggregate Fn> ::= Min ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_MAX_LPARAN_RPARAN = 56, // <Aggregate Fn> ::= Max ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_STDEV_LPARAN_RPARAN = 57, // <Aggregate Fn> ::= StDev ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_STDEVP_LPARAN_RPARAN = 58, // <Aggregate Fn> ::= StDevP ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_SUM_LPARAN_RPARAN = 59, // <Aggregate Fn> ::= Sum ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_VAR_LPARAN_RPARAN = 60, // <Aggregate Fn> ::= Var ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_VARP_LPARAN_RPARAN = 61, // <Aggregate Fn> ::= VarP ( <Restriction> <Txt Expression> )
    RULE_AGGREGATEFN_CHECKSUM_LPARAN_TIMES_RPARAN = 62, // <Aggregate Fn> ::= CheckSum ( * )
    RULE_AGGREGATEFN_CHECKSUM_LPARAN_RPARAN = 63, // <Aggregate Fn> ::= CheckSum ( <Txt Expression> )
    RULE_AGGREGATEFN_CHECKSUM_AGG_LPARAN_RPARAN = 64, // <Aggregate Fn> ::= CheckSum_AGG ( <Restriction> <Txt Expression> )
    RULE_DATETIMEFN_DATEADD_LPARAN_ID_COMMA_INTEGERLITERAL_COMMA_RPARAN = 65, // <Date Time Fn> ::= DATEADD ( Id , IntegerLiteral , <Txt Expression> )
    RULE_DATETIMEFN_DATEDIFF_LPARAN_ID_COMMA_COMMA_RPARAN = 66, // <Date Time Fn> ::= DATEDIFF ( Id , <Txt Expression> , <Txt Expression> )
    RULE_DATETIMEFN_DATENAME_LPARAN_ID_COMMA_RPARAN = 67, // <Date Time Fn> ::= DATENAME ( Id , <Txt Expression> )
    RULE_DATETIMEFN_DATEPART_LPARAN_ID_COMMA_RPARAN = 68, // <Date Time Fn> ::= DATEPART ( Id , <Txt Expression> )
    RULE_DATETIMEFN_DAY_LPARAN_RPARAN = 69, // <Date Time Fn> ::= DAY ( <Txt Expression> )
    RULE_DATETIMEFN_GETDATE_LPARAN_RPARAN = 70, // <Date Time Fn> ::= GETDATE ( )
    RULE_DATETIMEFN_GETUTCDATE_LPARAN_RPARAN = 71, // <Date Time Fn> ::= GETUTCDATE ( )
    RULE_DATETIMEFN_MONTH_LPARAN_RPARAN = 72, // <Date Time Fn> ::= MONTH ( <Txt Expression> )
    RULE_DATETIMEFN_YEAR_LPARAN_RPARAN = 73, // <Date Time Fn> ::= YEAR ( <Txt Expression> )
    RULE_CONVERTFN_CAST_LPARAN_AS_RPARAN = 74, // <Convert Fn> ::= CAST ( <Txt Expression> AS <Data Type> )
    RULE_CONVERTFN_CONVERT_LPARAN_COMMA_RPARAN = 75, // <Convert Fn> ::= CONVERT ( <Data Type> , <Txt Expression> )
    RULE_CONVERTFN_CONVERT_LPARAN_COMMA_COMMA_INTEGERLITERAL_RPARAN = 76, // <Convert Fn> ::= CONVERT ( <Data Type> , <Txt Expression> , IntegerLiteral )
    RULE_DATATYPE = 77, // <Data Type> ::= <Base Type>
    RULE_DATATYPE_LPARAN_INTEGERLITERAL_RPARAN = 78, // <Data Type> ::= <Base Type> ( IntegerLiteral )
    RULE_DATATYPE_LPARAN_INTEGERLITERAL_COMMA_INTEGERLITERAL_RPARAN = 79, // <Data Type> ::= <Base Type> ( IntegerLiteral , IntegerLiteral )
    RULE_BASETYPE_BIGINT = 80, // <Base Type> ::= Bigint
    RULE_BASETYPE_DECIMAL = 81, // <Base Type> ::= Decimal
    RULE_BASETYPE_INT = 82, // <Base Type> ::= Int
    RULE_BASETYPE_NUMERIC = 83, // <Base Type> ::= Numeric
    RULE_BASETYPE_SMALLINT = 84, // <Base Type> ::= Smallint
    RULE_BASETYPE_MONEY = 85, // <Base Type> ::= Money
    RULE_BASETYPE_TINYINT = 86, // <Base Type> ::= Tinyint
    RULE_BASETYPE_SMALLMONEY = 87, // <Base Type> ::= Smallmoney
    RULE_BASETYPE_BIT = 88, // <Base Type> ::= Bit
    RULE_BASETYPE_FLOAT = 89, // <Base Type> ::= Float
    RULE_BASETYPE_REAL = 90, // <Base Type> ::= Real
    RULE_BASETYPE_DATETIME = 91, // <Base Type> ::= Datetime
    RULE_BASETYPE_SMALLDATETIME = 92, // <Base Type> ::= Smalldatetime
    RULE_BASETYPE_CHAR = 93, // <Base Type> ::= Char
    RULE_BASETYPE_TEXT = 94, // <Base Type> ::= Text
    RULE_BASETYPE_VARCHAR = 95, // <Base Type> ::= Varchar
    RULE_BASETYPE_NCHAR = 96, // <Base Type> ::= Nchar
    RULE_BASETYPE_NTEXT = 97, // <Base Type> ::= Ntext
    RULE_BASETYPE_NVARCHAR = 98, // <Base Type> ::= Nvarchar
    RULE_BASETYPE_BINARY = 99, // <Base Type> ::= Binary
    RULE_BASETYPE_IMAGE = 100, // <Base Type> ::= Image
    RULE_BASETYPE_VARBINARY = 101, // <Base Type> ::= Varbinary
    RULE_BASETYPE_CURSOR = 102, // <Base Type> ::= Cursor
    RULE_BASETYPE_TIMESTAMP = 103, // <Base Type> ::= Timestamp
    RULE_BASETYPE_SQL_VARIANT = 104, // <Base Type> ::= Sql_Variant
    RULE_BASETYPE_UNIQUEIDENTIFIER = 105, // <Base Type> ::= Uniqueidentifier
    RULE_FROMCLAUSE_FROM = 106, // <From Clause> ::= FROM <From List> <Join Chain>
    RULE_FROMLIST_COMMA = 107, // <From List> ::= <From Member> , <From List>
    RULE_FROMLIST_CROSS_JOIN = 108, // <From List> ::= <From Member> CROSS JOIN <From List>
    RULE_FROMLIST = 109, // <From List> ::= <From Member>
    RULE_FROMMEMBER_ID = 110, // <From Member> ::= Id
    RULE_FROMMEMBER_ID_ID = 111, // <From Member> ::= Id Id
    RULE_FROMMEMBER_ID_AS_ID = 112, // <From Member> ::= Id AS Id
    RULE_FROMMEMBER_LPARAN_RPARAN_ID = 113, // <From Member> ::= ( <Select Stm> ) Id
    RULE_FROMMEMBER_LPARAN_RPARAN_AS_ID = 114, // <From Member> ::= ( <Select Stm> ) AS Id
    RULE_JOINCHAIN = 115, // <Join Chain> ::= <Join> <Join Chain>
    RULE_JOINCHAIN2 = 116, // <Join Chain> ::= 
    RULE_JOIN_ON = 117, // <Join> ::= <Join Type> <Join List> <Join Chain> ON <Expression>
    RULE_JOINTYPE_INNER_JOIN = 118, // <Join Type> ::= INNER JOIN
    RULE_JOINTYPE_LEFT_JOIN = 119, // <Join Type> ::= LEFT JOIN
    RULE_JOINTYPE_LEFT_OUTER_JOIN = 120, // <Join Type> ::= LEFT OUTER JOIN
    RULE_JOINTYPE_RIGHT_JOIN = 121, // <Join Type> ::= RIGHT JOIN
    RULE_JOINTYPE_RIGHT_OUTER_JOIN = 122, // <Join Type> ::= RIGHT OUTER JOIN
    RULE_JOINTYPE_FULL_JOIN = 123, // <Join Type> ::= FULL JOIN
    RULE_JOINTYPE_FULL_OUTER_JOIN = 124, // <Join Type> ::= FULL OUTER JOIN
    RULE_JOINTYPE_JOIN = 125, // <Join Type> ::= JOIN
    RULE_JOINLIST = 126, // <Join List> ::= <Join Member>
    RULE_JOINLIST_COMMA = 127, // <Join List> ::= <Join Member> , <Join List>
    RULE_JOINMEMBER = 128, // <Join Member> ::= <From Member>
    RULE_JOINMEMBER2 = 129, // <Join Member> ::= <Join Chain>
    RULE_WHERECLAUSE_WHERE = 130, // <Where Clause> ::= WHERE <Expression>
    RULE_WHERECLAUSE = 131, // <Where Clause> ::= 
    RULE_GROUPCLAUSE_GROUP_BY = 132, // <Group Clause> ::= GROUP BY <Group List>
    RULE_GROUPCLAUSE = 133, // <Group Clause> ::= 
    RULE_GROUPLIST_COMMA = 134, // <Group List> ::= <Group Item> , <Group List>
    RULE_GROUPLIST = 135, // <Group List> ::= <Group Item>
    RULE_GROUPITEM_ID = 136, // <Group Item> ::= Id
    RULE_GROUPITEM_INTEGERLITERAL = 137, // <Group Item> ::= IntegerLiteral
    RULE_GROUPITEM = 138, // <Group Item> ::= <Function>
    RULE_ORDERCLAUSE_ORDER_BY = 139, // <Order Clause> ::= ORDER BY <Order List>
    RULE_ORDERCLAUSE = 140, // <Order Clause> ::= 
    RULE_ORDERLIST_ID_COMMA = 141, // <Order List> ::= Id <Order Type> , <Order List>
    RULE_ORDERLIST_ID = 142, // <Order List> ::= Id <Order Type>
    RULE_ORDERTYPE_ASC = 143, // <Order Type> ::= ASC
    RULE_ORDERTYPE_DESC = 144, // <Order Type> ::= DESC
    RULE_ORDERTYPE = 145, // <Order Type> ::= 
    RULE_HAVINGCLAUSE_HAVING = 146, // <Having Clause> ::= HAVING <Expression>
    RULE_HAVINGCLAUSE = 147, // <Having Clause> ::= 
    RULE_UNION_UNION = 148, // <Union> ::= UNION <Select Stm>
    RULE_UNION_UNION_ALL = 149, // <Union> ::= UNION ALL <Select Stm>
    RULE_UNION = 150, // <Union> ::= 
    RULE_TXTEXPRESSION = 151, // <Txt Expression> ::= <Expression>
    RULE_TXTEXPRESSION_COMMA = 152, // <Txt Expression> ::= <Expression> , <Txt Expression>
    RULE_EXPRESSION = 153, // <Expression> ::= <Expression> <Logic Operator> <Expression>
    RULE_EXPRESSION_NOT_LPARAN_RPARAN = 154, // <Expression> ::= NOT ( <Expression> )
    RULE_EXPRESSION2 = 155, // <Expression> ::= <Operation>
    RULE_EXPRESSION_LPARAN_RPARAN = 156, // <Expression> ::= ( <Expression> )
    RULE_OPERATION_BETWEEN_AND = 157, // <Operation> ::= <Value> BETWEEN <Value> AND <Value>
    RULE_OPERATION_NOT_BETWEEN_AND = 158, // <Operation> ::= <Value> NOT BETWEEN <Value> AND <Value>
    RULE_OPERATION_IS_NOT_NULL = 159, // <Operation> ::= <Value> IS NOT NULL
    RULE_OPERATION_IS_NULL = 160, // <Operation> ::= <Value> IS NULL
    RULE_OPERATION_LIKE = 161, // <Operation> ::= <Value> LIKE <Value>
    RULE_OPERATION_IN = 162, // <Operation> ::= <Value> IN <Tuple>
    RULE_OPERATION_NOT_IN = 163, // <Operation> ::= <Value> NOT IN <Tuple>
    RULE_OPERATION = 164, // <Operation> ::= <Value> <Comp Operator> <Value>
    RULE_OPERATION2 = 165, // <Operation> ::= <Value>
    RULE_COMPOPERATOR_EQ = 166, // <Comp Operator> ::= =
    RULE_COMPOPERATOR_LTGT = 167, // <Comp Operator> ::= <>
    RULE_COMPOPERATOR_EXCLAMEQ = 168, // <Comp Operator> ::= !=
    RULE_COMPOPERATOR_GT = 169, // <Comp Operator> ::= >
    RULE_COMPOPERATOR_GTEQ = 170, // <Comp Operator> ::= >=
    RULE_COMPOPERATOR_LT = 171, // <Comp Operator> ::= <
    RULE_COMPOPERATOR_LTEQ = 172, // <Comp Operator> ::= <=
    RULE_LOGICOPERATOR_AND = 173, // <Logic Operator> ::= AND
    RULE_LOGICOPERATOR_OR = 174, // <Logic Operator> ::= OR
    RULE_VALUE = 175, // <Value> ::= <Tuple>
    RULE_VALUE2 = 176, // <Value> ::= <Function>
    RULE_VALUE3 = 177, // <Value> ::= <Parameter>
    RULE_VALUE_ID = 178, // <Value> ::= Id
    RULE_VALUE_INTEGERLITERAL = 179, // <Value> ::= IntegerLiteral
    RULE_VALUE_REALLITERAL = 180, // <Value> ::= RealLiteral
    RULE_VALUE_STRINGLITERAL = 181, // <Value> ::= StringLiteral
    RULE_VALUE4 = 182, // <Value> ::= <Value> <Arith Operator> <Value>
    RULE_VALUE_LPARAN_RPARAN = 183, // <Value> ::= ( <Value> <Arith Operator> <Value> )
    RULE_VALUE_MINUS = 184, // <Value> ::= - <Value>
    RULE_VALUE_XEVALEXPRESION = 185, // <Value> ::= XEvalExpresion
    RULE_VALUE_NULL = 186, // <Value> ::= NULL
    RULE_ARITHOPERATOR_PLUS = 187, // <Arith Operator> ::= +
    RULE_ARITHOPERATOR_MINUS = 188, // <Arith Operator> ::= -
    RULE_ARITHOPERATOR_TIMES = 189, // <Arith Operator> ::= *
    RULE_ARITHOPERATOR_DIV = 190, // <Arith Operator> ::= /
    RULE_ARITHOPERATOR_PERCENT = 191, // <Arith Operator> ::= %
    RULE_PARAMETER_COLON_ID = 192, // <Parameter> ::= : Id
    RULE_TUPLE_LPARAN_RPARAN = 193, // <Tuple> ::= ( <Select Stm> )
    RULE_TUPLE_LPARAN_RPARAN2 = 194  // <Tuple> ::= ( <Txt Expression> )
  }

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
////////////////////////////////////////////////////////////////////////
  enum IRISSQLSymbolConstants : int
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
    SYMBOL_CARET = 16, // '^'
    SYMBOL_LBRACE = 17, // '{'
    SYMBOL_PIPE = 18, // '|'
    SYMBOL_RBRACE = 19, // '}'
    SYMBOL_TILDE = 20, // '~'
    SYMBOL_PLUS = 21, // '+'
    SYMBOL_LT = 22, // '<'
    SYMBOL_LTEQ = 23, // '<='
    SYMBOL_LTGT = 24, // '<>'
    SYMBOL_EQ = 25, // '='
    SYMBOL_GT = 26, // '>'
    SYMBOL_GTEQ = 27, // '>='
    SYMBOL_ACTION = 28, // ACTION
    SYMBOL_ADD = 29, // ADD
    SYMBOL_ALL = 30, // ALL
    SYMBOL_ALTER = 31, // ALTER
    SYMBOL_AND = 32, // AND
    SYMBOL_AS = 33, // AS
    SYMBOL_ASC = 34, // ASC
    SYMBOL_BETWEEN = 35, // BETWEEN
    SYMBOL_BY = 36, // BY
    SYMBOL_CASCADE = 37, // CASCADE
    SYMBOL_CASE = 38, // CASE
    SYMBOL_CASESENSITIVE = 39, // CASESENSITIVE
    SYMBOL_CAST = 40, // CAST
    SYMBOL_CHECK = 41, // CHECK
    SYMBOL_CLUSTERED = 42, // CLUSTERED
    SYMBOL_COLLATE = 43, // COLLATE
    SYMBOL_COLUMN = 44, // COLUMN
    SYMBOL_COMPRESSED = 45, // COMPRESSED
    SYMBOL_CONSTRAINT = 46, // CONSTRAINT
    SYMBOL_CONVERT = 47, // CONVERT
    SYMBOL_CREATE = 48, // CREATE
    SYMBOL_CROSS = 49, // CROSS
    SYMBOL_DATABASE = 50, // DATABASE
    SYMBOL_DEFAULT = 51, // DEFAULT
    SYMBOL_DELETE = 52, // DELETE
    SYMBOL_DESC = 53, // DESC
    SYMBOL_DIFFGRAM = 54, // DIFFGRAM
    SYMBOL_DISTINCT = 55, // DISTINCT
    SYMBOL_DROP = 56, // DROP
    SYMBOL_ELSE = 57, // ELSE
    SYMBOL_EMPTY = 58, // EMPTY
    SYMBOL_END = 59, // END
    SYMBOL_ENFORCECONSTRAINTS = 60, // ENFORCECONSTRAINTS
    SYMBOL_ERROR2 = 61, // ERROR
    SYMBOL_EXISTS = 62, // EXISTS
    SYMBOL_FMTONLY = 63, // FMTONLY
    SYMBOL_FOR = 64, // FOR
    SYMBOL_FOREIGN = 65, // FOREIGN
    SYMBOL_FROM = 66, // FROM
    SYMBOL_FULL = 67, // FULL
    SYMBOL_GROUP = 68, // GROUP
    SYMBOL_HAVING = 69, // HAVING
    SYMBOL_HEXLITERAL = 70, // HexLiteral
    SYMBOL_IDENDIFIER = 71, // Idendifier
    SYMBOL_IDENTIFIER = 72, // Identifier
    SYMBOL_IDENTITY = 73, // IDENTITY
    SYMBOL_IGNORE = 74, // IGNORE
    SYMBOL_IGNORECHANGES = 75, // IGNORECHANGES
    SYMBOL_IGNORESCHEMA = 76, // IGNORESCHEMA
    SYMBOL_IN = 77, // IN
    SYMBOL_INDEX = 78, // INDEX
    SYMBOL_INNER = 79, // INNER
    SYMBOL_INSERT = 80, // INSERT
    SYMBOL_INTEGERLITERAL = 81, // IntegerLiteral
    SYMBOL_INTO = 82, // INTO
    SYMBOL_IS = 83, // IS
    SYMBOL_JOIN = 84, // JOIN
    SYMBOL_KEY = 85, // KEY
    SYMBOL_LEFT = 86, // LEFT
    SYMBOL_LIKE = 87, // LIKE
    SYMBOL_MATCHED = 88, // MATCHED
    SYMBOL_MERGE = 89, // MERGE
    SYMBOL_MISSINGSCHEMAACTION = 90, // MISSINGSCHEMAACTION
    SYMBOL_NAMESPACE = 91, // NAMESPACE
    SYMBOL_NO = 92, // NO
    SYMBOL_NOCHECK = 93, // NOCHECK
    SYMBOL_NONCLUSTERED = 94, // NONCLUSTERED
    SYMBOL_NOT = 95, // NOT
    SYMBOL_NULL = 96, // NULL
    SYMBOL_OFF = 97, // OFF
    SYMBOL_ON = 98, // ON
    SYMBOL_OPENROWSET = 99, // OPENROWSET
    SYMBOL_OR = 100, // OR
    SYMBOL_ORDER = 101, // ORDER
    SYMBOL_OUTER = 102, // OUTER
    SYMBOL_PERCENT2 = 103, // PERCENT
    SYMBOL_PIVOT = 104, // PIVOT
    SYMBOL_PREFIX = 105, // PREFIX
    SYMBOL_PRESERVECHANGES = 106, // PRESERVECHANGES
    SYMBOL_PRIMARY = 107, // PRIMARY
    SYMBOL_REALLITERAL = 108, // RealLiteral
    SYMBOL_REFERENCES = 109, // REFERENCES
    SYMBOL_RENAME = 110, // RENAME
    SYMBOL_RIGHT = 111, // RIGHT
    SYMBOL_ROWCOUNT = 112, // ROWCOUNT
    SYMBOL_ROWGUIDCOL = 113, // ROWGUIDCOL
    SYMBOL_SAVE = 114, // SAVE
    SYMBOL_SCHEMA = 115, // SCHEMA
    SYMBOL_SELECT = 116, // SELECT
    SYMBOL_SET = 117, // SET
    SYMBOL_SOURCE = 118, // SOURCE
    SYMBOL_STRINGLITERAL = 119, // StringLiteral
    SYMBOL_TABLE = 120, // TABLE
    SYMBOL_TARGET = 121, // TARGET
    SYMBOL_THEN = 122, // THEN
    SYMBOL_TO = 123, // TO
    SYMBOL_TOP = 124, // TOP
    SYMBOL_TRUNCATE = 125, // TRUNCATE
    SYMBOL_UNION = 126, // UNION
    SYMBOL_UNIQUE = 127, // UNIQUE
    SYMBOL_UNPIVOT = 128, // UNPIVOT
    SYMBOL_UPDATE = 129, // UPDATE
    SYMBOL_USE = 130, // USE
    SYMBOL_USING = 131, // USING
    SYMBOL_VALUES = 132, // VALUES
    SYMBOL_WHEN = 133, // WHEN
    SYMBOL_WHERE = 134, // WHERE
    SYMBOL_WITH = 135, // WITH
    SYMBOL_WRITEHIERARCHY = 136, // WRITEHIERARCHY
    SYMBOL_ACTION2 = 137, // <Action>
    SYMBOL_ALIAS = 138, // <alias>
    SYMBOL_ALLDISTINCT = 139, // <all distinct>
    SYMBOL_ALTERCHECKCLAUSE = 140, // <alter check clause>
    SYMBOL_ALTERCOLUMNDROP = 141, // <alter column drop>
    SYMBOL_ALTERCOLUMNSET = 142, // <alter column set>
    SYMBOL_ALTERDATABASESTM = 143, // <Alter Database Stm>
    SYMBOL_ALTERNULL = 144, // <Alter Null>
    SYMBOL_ALTERTABLESTM = 145, // <Alter Table Stm>
    SYMBOL_ALTERTYPE = 146, // <alter type>
    SYMBOL_ANDSEARCH = 147, // <and search>
    SYMBOL_ARGUMENTLIST = 148, // <Argument List>
    SYMBOL_ARGUMENTLISTOPT = 149, // <Argument List Opt>
    SYMBOL_ASSIGNLIST = 150, // <Assign List>
    SYMBOL_CASE2 = 151, // <case>
    SYMBOL_CASEELSE = 152, // <caseelse>
    SYMBOL_CASESENSITIVE2 = 153, // <casesensitive>
    SYMBOL_CASETYPE = 154, // <casetype>
    SYMBOL_CASEWHEN = 155, // <casewhen>
    SYMBOL_CASEWHENLIST = 156, // <casewhen list>
    SYMBOL_CHECKCONSTRAINT = 157, // <Check Constraint>
    SYMBOL_CHECKNOCHECK = 158, // <check nocheck>
    SYMBOL_CLUSTEREDUNCLUSTERED = 159, // <Clustered UnClustered>
    SYMBOL_COLLATION = 160, // <collation>
    SYMBOL_COLUMN2 = 161, // <column>
    SYMBOL_COLUMNCONSTRAINT = 162, // <Column Constraint>
    SYMBOL_COLUMNCONSTRAINTTYPE = 163, // <Column Constraint Type>
    SYMBOL_COLUMNDEFINITION = 164, // <Column Definition>
    SYMBOL_COLUMNLIST = 165, // <Column List>
    SYMBOL_COLUMNSOURCE = 166, // <Column Source>
    SYMBOL_COLUMNS = 167, // <Columns>
    SYMBOL_COMPARISONS = 168, // <comparisons>
    SYMBOL_COMPRESSED2 = 169, // <compressed>
    SYMBOL_CONSTRAINTCOLUMN = 170, // <Constraint Column>
    SYMBOL_CONSTRAINTCOLUMNLIST = 171, // <Constraint Column List>
    SYMBOL_CONSTRAINTCOLUMNS = 172, // <Constraint Columns>
    SYMBOL_CONSTRAINTLIST = 173, // <Constraint List>
    SYMBOL_CREATECOLUMN = 174, // <Create Column>
    SYMBOL_CREATECOLUMNS = 175, // <Create Columns>
    SYMBOL_CREATEDATABASESTM = 176, // <Create Database Stm>
    SYMBOL_CREATEFORMAT = 177, // <create format>
    SYMBOL_CREATEINDEXSTM = 178, // <Create Index Stm>
    SYMBOL_CREATETABLESTM = 179, // <Create Table Stm>
    SYMBOL_DATABASENAME = 180, // <database name>
    SYMBOL_DATABASEOPTIONS = 181, // <database options>
    SYMBOL_DBOPTION = 182, // <db option>
    SYMBOL_DBOPTIONSLIST = 183, // <db options list>
    SYMBOL_DEFAULTCONSTRAINT = 184, // <Default Constraint>
    SYMBOL_DELETESTM = 185, // <Delete Stm>
    SYMBOL_DROPCLAUSE = 186, // <drop clause>
    SYMBOL_DROPDATABASESTM = 187, // <Drop Database Stm>
    SYMBOL_DROPINDEXSTM = 188, // <Drop Index Stm>
    SYMBOL_DROPLIST = 189, // <drop list>
    SYMBOL_DROPTABLESTM = 190, // <Drop Table Stm>
    SYMBOL_ENFORCECONSTRAINTS2 = 191, // <enforceconstraints>
    SYMBOL_EXPRESSION = 192, // <Expression>
    SYMBOL_EXPRESSIONLIST = 193, // <Expression List>
    SYMBOL_FILE = 194, // <file>
    SYMBOL_FORCOLUMN = 195, // <For Column>
    SYMBOL_FORCE = 196, // <force>
    SYMBOL_FOREIGNKEY = 197, // <Foreign Key>
    SYMBOL_FROM2 = 198, // <From>
    SYMBOL_FROMCLAUSE = 199, // <From Clause>
    SYMBOL_FUNCTIONARGS = 200, // <function args>
    SYMBOL_GROUPCLAUSE = 201, // <Group Clause>
    SYMBOL_HAVINGCLAUSE = 202, // <Having Clause>
    SYMBOL_IDLIST = 203, // <Id List>
    SYMBOL_IDENTIFIERLIST = 204, // <Identifier List>
    SYMBOL_IDENTITYCONSTRAINT = 205, // <Identity Constraint>
    SYMBOL_INSERTARRAYS = 206, // <Insert Arrays>
    SYMBOL_INSERTCOLUMNS = 207, // <Insert Columns>
    SYMBOL_INSERTLIST = 208, // <Insert List>
    SYMBOL_INSERTSTM = 209, // <Insert Stm>
    SYMBOL_INSERTUPDATEITEM = 210, // <Insert Update Item>
    SYMBOL_INTEGERVALUE = 211, // <Integer Value>
    SYMBOL_INTO2 = 212, // <into>
    SYMBOL_INTOCLAUSE = 213, // <Into Clause>
    SYMBOL_JOINTYPE = 214, // <join type>
    SYMBOL_JOINEDTABLE = 215, // <Joined Table>
    SYMBOL_MERGEOPTION = 216, // <merge option>
    SYMBOL_MERGEOPTIONS = 217, // <merge options>
    SYMBOL_MERGEOPTIONSLIST = 218, // <merge options list>
    SYMBOL_MERGESOURCE = 219, // <merge source>
    SYMBOL_MERGESTM = 220, // <Merge Stm>
    SYMBOL_MERGE_MATCHED = 221, // <merge_matched>
    SYMBOL_MERGE_NOT_MATCHED = 222, // <merge_not_matched>
    SYMBOL_MISSINGSCHEMAACTION2 = 223, // <missing schema action>
    SYMBOL_MULTEXPRESSION = 224, // <Mult Expression>
    SYMBOL_NAMESPACE2 = 225, // <namespace>
    SYMBOL_NOT2 = 226, // <not>
    SYMBOL_NULLNOTNULL = 227, // <Null Not Null>
    SYMBOL_ONOFF = 228, // <OnOff>
    SYMBOL_OPTIONALIDENTIFIERLIST = 229, // <optional identifier list>
    SYMBOL_ORDERCLAUSE = 230, // <Order Clause>
    SYMBOL_ORDERLIST = 231, // <Order List>
    SYMBOL_ORDERTYPE = 232, // <Order Type>
    SYMBOL_PARAMETER = 233, // <Parameter>
    SYMBOL_PIVOT_CLAUSE = 234, // <pivot_clause>
    SYMBOL_PIVOTEDTABLE = 235, // <Pivoted Table>
    SYMBOL_PREDICATE = 236, // <predicate>
    SYMBOL_PREFIX2 = 237, // <prefix>
    SYMBOL_PRESERVECHANGES2 = 238, // <preserve changes>
    SYMBOL_PRIMARYKEY = 239, // <Primary Key>
    SYMBOL_PRIMARYUNIQUE = 240, // <Primary Unique>
    SYMBOL_REFCOLUMNS = 241, // <Ref Columns>
    SYMBOL_RESTRICTION = 242, // <Restriction>
    SYMBOL_ROWGUIDCOL2 = 243, // <RowGuidCol>
    SYMBOL_ROWSETFUNCTION = 244, // <rowset function>
    SYMBOL_ROWSETSOURCE = 245, // <rowset source>
    SYMBOL_RULE = 246, // <Rule>
    SYMBOL_SAVEFORMAT = 247, // <save format>
    SYMBOL_SAVESCHEMA = 248, // <save schema>
    SYMBOL_SAVESTM = 249, // <Save Stm>
    SYMBOL_SCHEMAACTION = 250, // <schema action>
    SYMBOL_SEARCHLIST = 251, // <search list>
    SYMBOL_SELECTSTM = 252, // <Select Stm>
    SYMBOL_SETSTM = 253, // <Set Stm>
    SYMBOL_SORTTYPE = 254, // <Sort Type>
    SYMBOL_SOURCE2 = 255, // <source>
    SYMBOL_SPECIALFUNCTION = 256, // <special function>
    SYMBOL_SQLSTM = 257, // <SQL Stm>
    SYMBOL_STYLE = 258, // <style>
    SYMBOL_TABLECONSTRAINT = 259, // <Table Constraint>
    SYMBOL_TABLECONSTRAINTTYPE = 260, // <Table Constraint Type>
    SYMBOL_TABLESOURCE = 261, // <table source>
    SYMBOL_TABLESOURCELIST = 262, // <table source list>
    SYMBOL_TARGET2 = 263, // <target>
    SYMBOL_TOP2 = 264, // <top>
    SYMBOL_TRUNCATESTM = 265, // <Truncate Stm>
    SYMBOL_TYPE = 266, // <Type>
    SYMBOL_UNARYEXP = 267, // <Unary Exp>
    SYMBOL_UNION2 = 268, // <Union>
    SYMBOL_UNIONSTM = 269, // <Union Stm>
    SYMBOL_UNIQUE2 = 270, // <Unique>
    SYMBOL_UNPIVOT_CLAUSE = 271, // <unpivot_clause>
    SYMBOL_UNPIVOTEDTABLE = 272, // <Unpivoted Table>
    SYMBOL_UPDATESTM = 273, // <Update Stm>
    SYMBOL_USESCHEMA = 274, // <use schema>
    SYMBOL_VALUE = 275, // <Value>
    SYMBOL_WHENCONDITION = 276, // <when condition>
    SYMBOL_WHENCONDITIONLIST = 277, // <when condition list>
    SYMBOL_WHENMATCHED = 278, // <when matched>
    SYMBOL_WHENSOURCENOTMATCHED = 279, // <when source not matched>
    SYMBOL_WHENTARGETNOTMATCHED = 280, // <when target not matched>
    SYMBOL_WHERECLAUSE = 281, // <Where Clause>
    SYMBOL_WITHCHECKNOCHECK = 282, // <with check nocheck>
    SYMBOL_WITHVALUES = 283, // <With Values>
    SYMBOL_WRITEHIERARCHY2 = 284, // <write hierarchy>
    SYMBOL_XEVAL = 285  // <XEval>
  };

  enum IRISSQLRuleConstants : int
  {
    RULE_TYPE_IDENTIFIER = 0, // <Type> ::= Identifier
    RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_RPARAN = 1, // <Type> ::= Identifier '(' IntegerLiteral ')'
    RULE_TYPE_IDENTIFIER_LPARAN_INTEGERLITERAL_COMMA_INTEGERLITERAL_RPARAN = 2, // <Type> ::= Identifier '(' IntegerLiteral ',' IntegerLiteral ')'
    RULE_SQLSTM = 3, // <SQL Stm> ::= <Union Stm>
    RULE_SQLSTM2 = 4, // <SQL Stm> ::= <Insert Stm>
    RULE_SQLSTM3 = 5, // <SQL Stm> ::= <Update Stm>
    RULE_SQLSTM4 = 6, // <SQL Stm> ::= <Delete Stm>
    RULE_SQLSTM5 = 7, // <SQL Stm> ::= <Truncate Stm>
    RULE_SQLSTM6 = 8, // <SQL Stm> ::= <Create Table Stm>
    RULE_SQLSTM7 = 9, // <SQL Stm> ::= <Create Index Stm>
    RULE_SQLSTM8 = 10, // <SQL Stm> ::= <Drop Table Stm>
    RULE_SQLSTM9 = 11, // <SQL Stm> ::= <Drop Index Stm>
    RULE_SQLSTM10 = 12, // <SQL Stm> ::= <Set Stm>
    RULE_SQLSTM11 = 13, // <SQL Stm> ::= <Save Stm>
    RULE_SQLSTM12 = 14, // <SQL Stm> ::= <Create Database Stm>
    RULE_SQLSTM13 = 15, // <SQL Stm> ::= <Drop Database Stm>
    RULE_SQLSTM14 = 16, // <SQL Stm> ::= <Merge Stm>
    RULE_SQLSTM15 = 17, // <SQL Stm> ::= <Alter Table Stm>
    RULE_SQLSTM16 = 18, // <SQL Stm> ::= <Alter Database Stm>
    RULE_SQLSTM17 = 19, // <SQL Stm> ::= <search list>
    RULE_ALTERDATABASESTM_ALTER_DATABASE_IDENTIFIER = 20, // <Alter Database Stm> ::= ALTER DATABASE Identifier <database options>
    RULE_ALTERDATABASESTM_ALTER_DATABASE_IDENTIFIER_RENAME_TO_IDENTIFIER = 21, // <Alter Database Stm> ::= ALTER DATABASE Identifier RENAME TO Identifier
    RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER = 22, // <Alter Table Stm> ::= ALTER TABLE Identifier <alter type>
    RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER_RENAME_TO_IDENTIFIER = 23, // <Alter Table Stm> ::= ALTER TABLE Identifier RENAME TO Identifier
    RULE_ALTERTABLESTM_ALTER_TABLE_IDENTIFIER_RENAME_IDENTIFIER_TO_IDENTIFIER = 24, // <Alter Table Stm> ::= ALTER TABLE Identifier RENAME <column> Identifier TO Identifier
    RULE_COLUMN_COLUMN = 25, // <column> ::= COLUMN
    RULE_COLUMN = 26, // <column> ::= 
    RULE_ALTERTYPE_ALTER_COLUMN_IDENTIFIER = 27, // <alter type> ::= ALTER COLUMN Identifier <Type> <collation> <Alter Null> <alter column set> <alter column drop>
    RULE_ALTERTYPE_ADD = 28, // <alter type> ::= <with check nocheck> ADD <Create Columns>
    RULE_ALTERTYPE_DROP = 29, // <alter type> ::= DROP <drop list>
    RULE_ALTERTYPE_CONSTRAINT = 30, // <alter type> ::= <check nocheck> CONSTRAINT <alter check clause>
    RULE_ALTERCOLUMNSET_SET = 31, // <alter column set> ::= SET <Default Constraint>
    RULE_ALTERCOLUMNSET_SET2 = 32, // <alter column set> ::= SET <Identity Constraint>
    RULE_ALTERCOLUMNSET_ADD_ROWGUIDCOL = 33, // <alter column set> ::= ADD ROWGUIDCOL
    RULE_ALTERCOLUMNSET_SET_ROWGUIDCOL = 34, // <alter column set> ::= SET ROWGUIDCOL
    RULE_ALTERCOLUMNSET = 35, // <alter column set> ::= 
    RULE_ALTERCOLUMNDROP_DROP_DEFAULT = 36, // <alter column drop> ::= DROP DEFAULT
    RULE_ALTERCOLUMNDROP_DROP_IDENTITY = 37, // <alter column drop> ::= DROP IDENTITY
    RULE_ALTERCOLUMNDROP_DROP_ROWGUIDCOL = 38, // <alter column drop> ::= DROP ROWGUIDCOL
    RULE_ALTERCOLUMNDROP = 39, // <alter column drop> ::= 
    RULE_ALTERNULL = 40, // <Alter Null> ::= <Null Not Null>
    RULE_ALTERNULL2 = 41, // <Alter Null> ::= 
    RULE_WITHCHECKNOCHECK_WITH_CHECK = 42, // <with check nocheck> ::= WITH CHECK
    RULE_WITHCHECKNOCHECK_WITH_NOCHECK = 43, // <with check nocheck> ::= WITH NOCHECK
    RULE_WITHCHECKNOCHECK = 44, // <with check nocheck> ::= 
    RULE_DROPLIST_COMMA = 45, // <drop list> ::= <drop list> ',' <drop clause>
    RULE_DROPLIST = 46, // <drop list> ::= <drop clause>
    RULE_DROPCLAUSE_COLUMN_IDENTIFIER = 47, // <drop clause> ::= COLUMN Identifier
    RULE_DROPCLAUSE_CONSTRAINT_IDENTIFIER = 48, // <drop clause> ::= CONSTRAINT Identifier
    RULE_CHECKNOCHECK_CHECK = 49, // <check nocheck> ::= CHECK
    RULE_CHECKNOCHECK_NOCHECK = 50, // <check nocheck> ::= NOCHECK
    RULE_ALTERCHECKCLAUSE_ALL = 51, // <alter check clause> ::= ALL
    RULE_ALTERCHECKCLAUSE = 52, // <alter check clause> ::= <Identifier List>
    RULE_MERGESTM_MERGE_IDENTIFIER_USING_ON = 53, // <Merge Stm> ::= MERGE <top> <into> Identifier <alias> USING <table source> ON <search list> <when condition list>
    RULE_MERGESTM_MERGE_DATABASE_IDENTIFIER_USING_IDENTIFIER = 54, // <Merge Stm> ::= MERGE DATABASE Identifier USING <merge source> Identifier <merge options>
    RULE_MERGESTM_MERGE_TABLE_IDENTIFIER_USING_TABLE_IDENTIFIER = 55, // <Merge Stm> ::= MERGE TABLE Identifier USING TABLE Identifier <merge options>
    RULE_MERGESOURCE_DATABASE = 56, // <merge source> ::= DATABASE
    RULE_MERGESOURCE_TABLE = 57, // <merge source> ::= TABLE
    RULE_MERGEOPTIONS_SET = 58, // <merge options> ::= SET <merge options list>
    RULE_MERGEOPTIONS = 59, // <merge options> ::= 
    RULE_MERGEOPTIONSLIST_COMMA = 60, // <merge options list> ::= <merge options list> ',' <merge option>
    RULE_MERGEOPTIONSLIST = 61, // <merge options list> ::= <merge option>
    RULE_MERGEOPTION = 62, // <merge option> ::= <preserve changes>
    RULE_MERGEOPTION2 = 63, // <merge option> ::= <missing schema action>
    RULE_PRESERVECHANGES_PRESERVECHANGES = 64, // <preserve changes> ::= PRESERVECHANGES <OnOff>
    RULE_MISSINGSCHEMAACTION_MISSINGSCHEMAACTION = 65, // <missing schema action> ::= MISSINGSCHEMAACTION <schema action>
    RULE_SCHEMAACTION_ERROR = 66, // <schema action> ::= ERROR
    RULE_SCHEMAACTION_IGNORE = 67, // <schema action> ::= IGNORE
    RULE_WHENCONDITIONLIST = 68, // <when condition list> ::= <when condition list> <when condition>
    RULE_WHENCONDITIONLIST2 = 69, // <when condition list> ::= <when condition>
    RULE_WHENCONDITION = 70, // <when condition> ::= <when matched>
    RULE_WHENCONDITION2 = 71, // <when condition> ::= <when target not matched>
    RULE_WHENCONDITION3 = 72, // <when condition> ::= <when source not matched>
    RULE_WHENMATCHED_WHEN_MATCHED_THEN = 73, // <when matched> ::= WHEN MATCHED <and search> THEN <merge_matched>
    RULE_WHENTARGETNOTMATCHED_WHEN_NOT_MATCHED_THEN = 74, // <when target not matched> ::= WHEN <target> NOT MATCHED <and search> THEN <merge_not_matched>
    RULE_TARGET_TARGET = 75, // <target> ::= TARGET
    RULE_TARGET = 76, // <target> ::= 
    RULE_WHENSOURCENOTMATCHED_WHEN_SOURCE_NOT_MATCHED_THEN = 77, // <when source not matched> ::= WHEN SOURCE NOT MATCHED <and search> THEN <merge_matched>
    RULE_ANDSEARCH_AND = 78, // <and search> ::= AND <search list>
    RULE_ANDSEARCH = 79, // <and search> ::= 
    RULE_MERGE_MATCHED_UPDATE_SET = 80, // <merge_matched> ::= UPDATE SET <Assign List>
    RULE_MERGE_MATCHED_DELETE = 81, // <merge_matched> ::= DELETE
    RULE_MERGE_NOT_MATCHED_INSERT_VALUES_LPARAN_RPARAN = 82, // <merge_not_matched> ::= INSERT <Insert Columns> VALUES '(' <Insert List> ')'
    RULE_SAVESTM_SAVE_DATABASE_IDENTIFIER = 83, // <Save Stm> ::= SAVE DATABASE Identifier <into> <file> <save format>
    RULE_SAVESTM_SAVE_TABLE_IDENTIFIER_STRINGLITERAL = 84, // <Save Stm> ::= SAVE TABLE Identifier <into> StringLiteral <save format> <write hierarchy>
    RULE_FILE_STRINGLITERAL = 85, // <file> ::= StringLiteral
    RULE_FILE = 86, // <file> ::= 
    RULE_SAVEFORMAT_IDENTIFIER = 87, // <save format> ::= Identifier <compressed> <save schema>
    RULE_SAVEFORMAT = 88, // <save format> ::= 
    RULE_SAVESCHEMA_IGNORESCHEMA = 89, // <save schema> ::= IGNORESCHEMA
    RULE_SAVESCHEMA_DIFFGRAM = 90, // <save schema> ::= DIFFGRAM
    RULE_SAVESCHEMA = 91, // <save schema> ::= 
    RULE_COMPRESSED_COMPRESSED = 92, // <compressed> ::= COMPRESSED
    RULE_COMPRESSED = 93, // <compressed> ::= 
    RULE_WRITEHIERARCHY_WRITEHIERARCHY = 94, // <write hierarchy> ::= WRITEHIERARCHY
    RULE_WRITEHIERARCHY = 95, // <write hierarchy> ::= 
    RULE_CREATEDATABASESTM_CREATE_DATABASE = 96, // <Create Database Stm> ::= CREATE DATABASE <database name> <source> <database options>
    RULE_DATABASENAME_AS_IDENTIFIER = 97, // <database name> ::= AS Identifier
    RULE_DATABASENAME_IDENTIFIER = 98, // <database name> ::= Identifier
    RULE_DATABASENAME = 99, // <database name> ::= 
    RULE_SOURCE_EMPTY = 100, // <source> ::= EMPTY
    RULE_SOURCE_FROM = 101, // <source> ::= FROM <create format>
    RULE_CREATEFORMAT_IDENTIFIER_STRINGLITERAL = 102, // <create format> ::= Identifier <compressed> StringLiteral <use schema>
    RULE_USESCHEMA_USE_SCHEMA_STRINGLITERAL = 103, // <use schema> ::= USE SCHEMA <compressed> StringLiteral <namespace> <prefix>
    RULE_USESCHEMA = 104, // <use schema> ::= 
    RULE_NAMESPACE_NAMESPACE_STRINGLITERAL = 105, // <namespace> ::= NAMESPACE StringLiteral
    RULE_NAMESPACE = 106, // <namespace> ::= 
    RULE_PREFIX_PREFIX_STRINGLITERAL = 107, // <prefix> ::= PREFIX StringLiteral
    RULE_PREFIX = 108, // <prefix> ::= 
    RULE_DATABASEOPTIONS_SET = 109, // <database options> ::= SET <db options list>
    RULE_DATABASEOPTIONS = 110, // <database options> ::= 
    RULE_DBOPTIONSLIST_COMMA = 111, // <db options list> ::= <db options list> ',' <db option>
    RULE_DBOPTIONSLIST = 112, // <db options list> ::= <db option>
    RULE_DBOPTION = 113, // <db option> ::= <casesensitive>
    RULE_DBOPTION2 = 114, // <db option> ::= <enforceconstraints>
    RULE_CASESENSITIVE_CASESENSITIVE = 115, // <casesensitive> ::= CASESENSITIVE <OnOff>
    RULE_ENFORCECONSTRAINTS_ENFORCECONSTRAINTS = 116, // <enforceconstraints> ::= ENFORCECONSTRAINTS <OnOff>
    RULE_DROPDATABASESTM_DROP_DATABASE_IDENTIFIER = 117, // <Drop Database Stm> ::= DROP DATABASE Identifier <force>
    RULE_FORCE_IGNORECHANGES = 118, // <force> ::= IGNORECHANGES
    RULE_FORCE = 119, // <force> ::= 
    RULE_SETSTM_SET_FMTONLY = 120, // <Set Stm> ::= SET FMTONLY <OnOff>
    RULE_SETSTM_SET_ROWCOUNT_INTEGERLITERAL = 121, // <Set Stm> ::= SET ROWCOUNT IntegerLiteral
    RULE_ONOFF_ON = 122, // <OnOff> ::= ON
    RULE_ONOFF_OFF = 123, // <OnOff> ::= OFF
    RULE_ONOFF = 124, // <OnOff> ::= 
    RULE_CREATETABLESTM_CREATE_TABLE_IDENTIFIER_LPARAN_RPARAN = 125, // <Create Table Stm> ::= CREATE TABLE Identifier '(' <Create Columns> ')'
    RULE_CREATECOLUMNS_COMMA = 126, // <Create Columns> ::= <Create Columns> ',' <Create Column>
    RULE_CREATECOLUMNS = 127, // <Create Columns> ::= <Create Column>
    RULE_CREATECOLUMN = 128, // <Create Column> ::= <Column Definition>
    RULE_CREATECOLUMN_IDENTIFIER_AS = 129, // <Create Column> ::= Identifier AS <Expression>
    RULE_CREATECOLUMN_IDENTIFIER_AS_STRINGLITERAL = 130, // <Create Column> ::= Identifier <Type> AS StringLiteral
    RULE_CREATECOLUMN2 = 131, // <Create Column> ::= <Table Constraint>
    RULE_TABLECONSTRAINT_CONSTRAINT_IDENTIFIER = 132, // <Table Constraint> ::= CONSTRAINT Identifier <Table Constraint Type>
    RULE_TABLECONSTRAINT = 133, // <Table Constraint> ::= <Table Constraint Type>
    RULE_TABLECONSTRAINTTYPE = 134, // <Table Constraint Type> ::= <Primary Key>
    RULE_TABLECONSTRAINTTYPE2 = 135, // <Table Constraint Type> ::= <Foreign Key>
    RULE_TABLECONSTRAINTTYPE3 = 136, // <Table Constraint Type> ::= <Check Constraint>
    RULE_TABLECONSTRAINTTYPE4 = 137, // <Table Constraint Type> ::= <Default Constraint>
    RULE_COLUMNDEFINITION_IDENTIFIER = 138, // <Column Definition> ::= Identifier <Type> <collation> <Constraint List>
    RULE_COLLATION_COLLATE_IDENTIFIER = 139, // <collation> ::= COLLATE Identifier
    RULE_COLLATION = 140, // <collation> ::= 
    RULE_CONSTRAINTLIST = 141, // <Constraint List> ::= <Constraint List> <Column Constraint>
    RULE_CONSTRAINTLIST2 = 142, // <Constraint List> ::= <Column Constraint>
    RULE_CONSTRAINTLIST3 = 143, // <Constraint List> ::= 
    RULE_COLUMNCONSTRAINT_CONSTRAINT_IDENTIFIER = 144, // <Column Constraint> ::= CONSTRAINT Identifier <Column Constraint Type>
    RULE_COLUMNCONSTRAINT = 145, // <Column Constraint> ::= <Column Constraint Type>
    RULE_COLUMNCONSTRAINTTYPE = 146, // <Column Constraint Type> ::= <Null Not Null>
    RULE_COLUMNCONSTRAINTTYPE2 = 147, // <Column Constraint Type> ::= <Default Constraint>
    RULE_COLUMNCONSTRAINTTYPE3 = 148, // <Column Constraint Type> ::= <Identity Constraint>
    RULE_COLUMNCONSTRAINTTYPE4 = 149, // <Column Constraint Type> ::= <RowGuidCol>
    RULE_COLUMNCONSTRAINTTYPE5 = 150, // <Column Constraint Type> ::= <Primary Key>
    RULE_COLUMNCONSTRAINTTYPE6 = 151, // <Column Constraint Type> ::= <Foreign Key>
    RULE_COLUMNCONSTRAINTTYPE7 = 152, // <Column Constraint Type> ::= <Check Constraint>
    RULE_NULLNOTNULL_NULL = 153, // <Null Not Null> ::= NULL
    RULE_NULLNOTNULL_NOT_NULL = 154, // <Null Not Null> ::= NOT NULL
    RULE_ROWGUIDCOL_ROWGUIDCOL = 155, // <RowGuidCol> ::= ROWGUIDCOL
    RULE_DEFAULTCONSTRAINT_DEFAULT = 156, // <Default Constraint> ::= DEFAULT <Expression> <For Column> <With Values>
    RULE_FORCOLUMN_FOR_IDENTIFIER = 157, // <For Column> ::= FOR Identifier
    RULE_FORCOLUMN = 158, // <For Column> ::= 
    RULE_WITHVALUES_WITH_VALUES = 159, // <With Values> ::= WITH VALUES
    RULE_WITHVALUES = 160, // <With Values> ::= 
    RULE_IDENTITYCONSTRAINT_IDENTITY = 161, // <Identity Constraint> ::= IDENTITY
    RULE_IDENTITYCONSTRAINT_IDENTITY_LPARAN_COMMA_RPARAN = 162, // <Identity Constraint> ::= IDENTITY '(' <Integer Value> ',' <Integer Value> ')'
    RULE_INTEGERVALUE_MINUS_INTEGERLITERAL = 163, // <Integer Value> ::= '-' IntegerLiteral
    RULE_INTEGERVALUE_PLUS_INTEGERLITERAL = 164, // <Integer Value> ::= '+' IntegerLiteral
    RULE_INTEGERVALUE_INTEGERLITERAL = 165, // <Integer Value> ::= IntegerLiteral
    RULE_PRIMARYKEY = 166, // <Primary Key> ::= <Primary Unique> <Clustered UnClustered> <Constraint Columns>
    RULE_PRIMARYUNIQUE_PRIMARY_KEY = 167, // <Primary Unique> ::= PRIMARY KEY
    RULE_PRIMARYUNIQUE_UNIQUE = 168, // <Primary Unique> ::= UNIQUE
    RULE_CLUSTEREDUNCLUSTERED_CLUSTERED = 169, // <Clustered UnClustered> ::= CLUSTERED
    RULE_CLUSTEREDUNCLUSTERED_NONCLUSTERED = 170, // <Clustered UnClustered> ::= NONCLUSTERED
    RULE_CLUSTEREDUNCLUSTERED = 171, // <Clustered UnClustered> ::= 
    RULE_CONSTRAINTCOLUMNS_LPARAN_RPARAN = 172, // <Constraint Columns> ::= '(' <Constraint Column List> ')'
    RULE_CONSTRAINTCOLUMNS = 173, // <Constraint Columns> ::= 
    RULE_FOREIGNKEY_FOREIGN_KEY_REFERENCES_IDENTIFIER = 174, // <Foreign Key> ::= FOREIGN KEY REFERENCES Identifier <Ref Columns> <Rule> <Rule>
    RULE_FOREIGNKEY_FOREIGN_KEY_LPARAN_RPARAN_REFERENCES_IDENTIFIER = 175, // <Foreign Key> ::= FOREIGN KEY '(' <Constraint Column List> ')' REFERENCES Identifier <Ref Columns> <Rule> <Rule>
    RULE_FOREIGNKEY_REFERENCES_IDENTIFIER = 176, // <Foreign Key> ::= REFERENCES Identifier <Ref Columns> <Rule> <Rule>
    RULE_RULE_ON_DELETE = 177, // <Rule> ::= ON DELETE <Action>
    RULE_RULE_ON_UPDATE = 178, // <Rule> ::= ON UPDATE <Action>
    RULE_RULE = 179, // <Rule> ::= 
    RULE_ACTION_CASCADE = 180, // <Action> ::= CASCADE
    RULE_ACTION_NO_ACTION = 181, // <Action> ::= NO ACTION
    RULE_ACTION_SET_DEFAULT = 182, // <Action> ::= SET DEFAULT
    RULE_ACTION_SET_NULL = 183, // <Action> ::= SET NULL
    RULE_REFCOLUMNS_LPARAN_RPARAN = 184, // <Ref Columns> ::= '(' <Id List> ')'
    RULE_REFCOLUMNS = 185, // <Ref Columns> ::= 
    RULE_CHECKCONSTRAINT_CHECK = 186, // <Check Constraint> ::= CHECK <search list>
    RULE_CONSTRAINTCOLUMNLIST_COMMA = 187, // <Constraint Column List> ::= <Constraint Column List> ',' <Constraint Column>
    RULE_CONSTRAINTCOLUMNLIST = 188, // <Constraint Column List> ::= <Constraint Column>
    RULE_CONSTRAINTCOLUMN_IDENTIFIER = 189, // <Constraint Column> ::= Identifier <Sort Type>
    RULE_CREATEINDEXSTM_CREATE_INDEX_IDENTIFIER_ON_IDENTIFIER_LPARAN_RPARAN = 190, // <Create Index Stm> ::= CREATE <Unique> <Clustered UnClustered> INDEX Identifier ON Identifier '(' <Constraint Column List> ')'
    RULE_UNIQUE_UNIQUE = 191, // <Unique> ::= UNIQUE
    RULE_UNIQUE = 192, // <Unique> ::= 
    RULE_DROPTABLESTM_DROP_TABLE_IDENTIFIER = 193, // <Drop Table Stm> ::= DROP TABLE Identifier
    RULE_DROPINDEXSTM_DROP_INDEX = 194, // <Drop Index Stm> ::= DROP INDEX <Identifier List>
    RULE_IDENTIFIERLIST_COMMA_IDENTIFIER = 195, // <Identifier List> ::= <Identifier List> ',' Identifier
    RULE_IDENTIFIERLIST_IDENTIFIER = 196, // <Identifier List> ::= Identifier
    RULE_INSERTSTM_INSERT_IDENTIFIER = 197, // <Insert Stm> ::= INSERT <into> Identifier <Insert Columns> <Union Stm>
    RULE_INSERTSTM_INSERT_IDENTIFIER_VALUES = 198, // <Insert Stm> ::= INSERT <into> Identifier <Insert Columns> VALUES <Insert Arrays>
    RULE_INSERTSTM_INSERT_IDENTIFIER_DEFAULT_VALUES = 199, // <Insert Stm> ::= INSERT <into> Identifier DEFAULT VALUES
    RULE_INSERTCOLUMNS_LPARAN_RPARAN = 200, // <Insert Columns> ::= '(' <Id List> ')'
    RULE_INSERTCOLUMNS = 201, // <Insert Columns> ::= 
    RULE_INTO_INTO = 202, // <into> ::= INTO
    RULE_INTO = 203, // <into> ::= 
    RULE_INSERTUPDATEITEM = 204, // <Insert Update Item> ::= <Expression>
    RULE_INSERTUPDATEITEM_DEFAULT = 205, // <Insert Update Item> ::= DEFAULT
    RULE_INSERTLIST_COMMA = 206, // <Insert List> ::= <Insert List> ',' <Insert Update Item>
    RULE_INSERTLIST = 207, // <Insert List> ::= <Insert Update Item>
    RULE_INSERTARRAYS_LPARAN_RPARAN_COMMA = 208, // <Insert Arrays> ::= '(' <Insert List> ')' ',' <Insert Arrays>
    RULE_INSERTARRAYS_LPARAN_RPARAN = 209, // <Insert Arrays> ::= '(' <Insert List> ')'
    RULE_UPDATESTM_UPDATE_IDENTIFIER_SET = 210, // <Update Stm> ::= UPDATE Identifier SET <Assign List> <From Clause> <Where Clause>
    RULE_ASSIGNLIST_IDENTIFIER_EQ_COMMA = 211, // <Assign List> ::= Identifier '=' <Insert Update Item> ',' <Assign List>
    RULE_ASSIGNLIST_IDENTIFIER_EQ = 212, // <Assign List> ::= Identifier '=' <Insert Update Item>
    RULE_DELETESTM_DELETE_IDENTIFIER = 213, // <Delete Stm> ::= DELETE <From> Identifier <Where Clause>
    RULE_FROM_FROM = 214, // <From> ::= FROM
    RULE_FROM = 215, // <From> ::= 
    RULE_TRUNCATESTM_TRUNCATE_TABLE_IDENTIFIER = 216, // <Truncate Stm> ::= TRUNCATE TABLE Identifier
    RULE_UNIONSTM = 217, // <Union Stm> ::= <Select Stm> <Union> <Union Stm>
    RULE_UNIONSTM2 = 218, // <Union Stm> ::= <Select Stm>
    RULE_UNION_UNION_ALL = 219, // <Union> ::= UNION ALL
    RULE_UNION_UNION = 220, // <Union> ::= UNION
    RULE_SELECTSTM_SELECT = 221, // <Select Stm> ::= SELECT <Columns> <Into Clause> <From Clause> <Where Clause> <Group Clause> <Having Clause> <Order Clause>
    RULE_COLUMNS_TIMES = 222, // <Columns> ::= <Restriction> <top> '*'
    RULE_COLUMNS = 223, // <Columns> ::= <Restriction> <top> <Column List>
    RULE_TOP_TOP_INTEGERLITERAL_PERCENT = 224, // <top> ::= TOP IntegerLiteral PERCENT
    RULE_TOP_TOP_INTEGERLITERAL = 225, // <top> ::= TOP IntegerLiteral
    RULE_TOP = 226, // <top> ::= 
    RULE_COLUMNLIST_COMMA = 227, // <Column List> ::= <Column Source> ',' <Column List>
    RULE_COLUMNLIST = 228, // <Column List> ::= <Column Source>
    RULE_COLUMNSOURCE_IDENTIFIER_EQ = 229, // <Column Source> ::= Identifier '=' <Expression>
    RULE_COLUMNSOURCE_STRINGLITERAL_EQ = 230, // <Column Source> ::= StringLiteral '=' <Expression>
    RULE_COLUMNSOURCE = 231, // <Column Source> ::= <Expression> <alias>
    RULE_COLUMNSOURCE_IDENDIFIER = 232, // <Column Source> ::= Idendifier
    RULE_ALIAS_AS_IDENTIFIER = 233, // <alias> ::= AS Identifier
    RULE_ALIAS_AS_STRINGLITERAL = 234, // <alias> ::= AS StringLiteral
    RULE_ALIAS_IDENTIFIER = 235, // <alias> ::= Identifier
    RULE_ALIAS = 236, // <alias> ::= 
    RULE_ALLDISTINCT_ALL = 237, // <all distinct> ::= ALL
    RULE_ALLDISTINCT_DISTINCT = 238, // <all distinct> ::= DISTINCT
    RULE_RESTRICTION = 239, // <Restriction> ::= <all distinct>
    RULE_RESTRICTION2 = 240, // <Restriction> ::= 
    RULE_INTOCLAUSE_INTO_IDENTIFIER = 241, // <Into Clause> ::= INTO Identifier
    RULE_INTOCLAUSE = 242, // <Into Clause> ::= 
    RULE_FROMCLAUSE_FROM = 243, // <From Clause> ::= FROM <table source list>
    RULE_FROMCLAUSE = 244, // <From Clause> ::= 
    RULE_TABLESOURCELIST_COMMA = 245, // <table source list> ::= <table source> ',' <table source list>
    RULE_TABLESOURCELIST_CROSS_JOIN = 246, // <table source list> ::= <table source> CROSS JOIN <table source list>
    RULE_TABLESOURCELIST = 247, // <table source list> ::= <table source>
    RULE_TABLESOURCE_IDENTIFIER = 248, // <table source> ::= Identifier <alias>
    RULE_TABLESOURCE_LPARAN_RPARAN = 249, // <table source> ::= '(' <Union Stm> ')' <alias> <optional identifier list>
    RULE_TABLESOURCE = 250, // <table source> ::= <Joined Table>
    RULE_TABLESOURCE2 = 251, // <table source> ::= <Pivoted Table>
    RULE_TABLESOURCE3 = 252, // <table source> ::= <Unpivoted Table>
    RULE_TABLESOURCE4 = 253, // <table source> ::= <rowset function>
    RULE_OPTIONALIDENTIFIERLIST_LPARAN_RPARAN = 254, // <optional identifier list> ::= '(' <Identifier List> ')'
    RULE_OPTIONALIDENTIFIERLIST = 255, // <optional identifier list> ::= 
    RULE_JOINEDTABLE_JOIN_ON = 256, // <Joined Table> ::= <table source> <join type> JOIN <table source> ON <search list>
    RULE_JOINEDTABLE_LPARAN_RPARAN = 257, // <Joined Table> ::= '(' <Joined Table> ')'
    RULE_JOINTYPE_INNER = 258, // <join type> ::= INNER
    RULE_JOINTYPE_LEFT = 259, // <join type> ::= LEFT
    RULE_JOINTYPE_LEFT_OUTER = 260, // <join type> ::= LEFT OUTER
    RULE_JOINTYPE_RIGHT = 261, // <join type> ::= RIGHT
    RULE_JOINTYPE_RIGHT_OUTER = 262, // <join type> ::= RIGHT OUTER
    RULE_JOINTYPE_FULL = 263, // <join type> ::= FULL
    RULE_JOINTYPE_FULL_OUTER = 264, // <join type> ::= FULL OUTER
    RULE_JOINTYPE = 265, // <join type> ::= 
    RULE_ROWSETFUNCTION_OPENROWSET_LPARAN_STRINGLITERAL_COMMA_STRINGLITERAL_COMMA_RPARAN = 266, // <rowset function> ::= OPENROWSET '(' StringLiteral ',' StringLiteral ',' <rowset source> ')' <alias>
    RULE_ROWSETFUNCTION_OPENROWSET_LPARAN_STRINGLITERAL_COMMA_RPARAN = 267, // <rowset function> ::= OPENROWSET '(' StringLiteral ',' <rowset source> ')' <alias>
    RULE_ROWSETSOURCE_IDENTIFIER = 268, // <rowset source> ::= Identifier
    RULE_ROWSETSOURCE_STRINGLITERAL = 269, // <rowset source> ::= StringLiteral
    RULE_PIVOTEDTABLE_PIVOT = 270, // <Pivoted Table> ::= <table source> PIVOT <pivot_clause> <alias>
    RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN = 271, // <pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier IN '(' <Column List> ')' ')'
    RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_RPARAN = 272, // <pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier ')'
    RULE_PIVOT_CLAUSE_LPARAN_IDENTIFIER_LPARAN_IDENTIFIER_RPARAN_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN2 = 273, // <pivot_clause> ::= '(' Identifier '(' Identifier ')' FOR Identifier IN '(' <Union Stm> ')' ')'
    RULE_UNPIVOTEDTABLE_UNPIVOT = 274, // <Unpivoted Table> ::= <table source> UNPIVOT <unpivot_clause> <alias>
    RULE_UNPIVOT_CLAUSE_LPARAN_IDENTIFIER_FOR_IDENTIFIER_IN_LPARAN_RPARAN_RPARAN = 275, // <unpivot_clause> ::= '(' Identifier FOR Identifier IN '(' <Column List> ')' ')'
    RULE_WHERECLAUSE_WHERE = 276, // <Where Clause> ::= WHERE <search list>
    RULE_WHERECLAUSE = 277, // <Where Clause> ::= 
    RULE_GROUPCLAUSE_GROUP_BY = 278, // <Group Clause> ::= GROUP BY <Id List>
    RULE_GROUPCLAUSE_GROUP_BY_ALL = 279, // <Group Clause> ::= GROUP BY ALL
    RULE_GROUPCLAUSE = 280, // <Group Clause> ::= 
    RULE_IDLIST_COMMA = 281, // <Id List> ::= <Expression> <alias> ',' <Id List>
    RULE_IDLIST = 282, // <Id List> ::= <Expression> <alias>
    RULE_ORDERCLAUSE_ORDER_BY = 283, // <Order Clause> ::= ORDER BY <Order List>
    RULE_ORDERCLAUSE = 284, // <Order Clause> ::= 
    RULE_ORDERLIST_COMMA = 285, // <Order List> ::= <Order Type> <Sort Type> ',' <Order List>
    RULE_ORDERLIST = 286, // <Order List> ::= <Order Type> <Sort Type>
    RULE_ORDERTYPE_IDENTIFIER = 287, // <Order Type> ::= Identifier
    RULE_ORDERTYPE_INTEGERLITERAL = 288, // <Order Type> ::= IntegerLiteral
    RULE_SORTTYPE_ASC = 289, // <Sort Type> ::= ASC
    RULE_SORTTYPE_DESC = 290, // <Sort Type> ::= DESC
    RULE_SORTTYPE = 291, // <Sort Type> ::= 
    RULE_HAVINGCLAUSE_HAVING = 292, // <Having Clause> ::= HAVING <search list>
    RULE_HAVINGCLAUSE = 293, // <Having Clause> ::= 
    RULE_SEARCHLIST_AND = 294, // <search list> ::= <search list> AND <not> <predicate> <alias>
    RULE_SEARCHLIST_OR = 295, // <search list> ::= <search list> OR <not> <predicate> <alias>
    RULE_SEARCHLIST = 296, // <search list> ::= <not> <predicate> <alias>
    RULE_NOT_NOT = 297, // <not> ::= NOT
    RULE_NOT = 298, // <not> ::= 
    RULE_PREDICATE = 299, // <predicate> ::= <comparisons>
    RULE_PREDICATE_LIKE = 300, // <predicate> ::= <Expression> <not> LIKE <Expression>
    RULE_PREDICATE_BETWEEN_AND = 301, // <predicate> ::= <Expression> <not> BETWEEN <Expression> AND <Expression>
    RULE_PREDICATE_IS_NULL = 302, // <predicate> ::= <Expression> IS <not> NULL
    RULE_PREDICATE_IN_LPARAN_RPARAN = 303, // <predicate> ::= <Expression> <not> IN '(' <Union Stm> ')'
    RULE_PREDICATE_IN_LPARAN_RPARAN2 = 304, // <predicate> ::= <Expression> <not> IN '(' <Expression List> ')'
    RULE_PREDICATE_EXISTS_LPARAN_RPARAN = 305, // <predicate> ::= EXISTS '(' <Union Stm> ')'
    RULE_COMPARISONS_GT = 306, // <comparisons> ::= <Expression> '>' <Expression>
    RULE_COMPARISONS_LT = 307, // <comparisons> ::= <Expression> '<' <Expression>
    RULE_COMPARISONS_LTEQ = 308, // <comparisons> ::= <Expression> '<=' <Expression>
    RULE_COMPARISONS_GTEQ = 309, // <comparisons> ::= <Expression> '>=' <Expression>
    RULE_COMPARISONS_EQ = 310, // <comparisons> ::= <Expression> '=' <Expression>
    RULE_COMPARISONS_LTGT = 311, // <comparisons> ::= <Expression> '<>' <Expression>
    RULE_COMPARISONS_EXCLAMEQ = 312, // <comparisons> ::= <Expression> '!=' <Expression>
    RULE_COMPARISONS = 313, // <comparisons> ::= <Expression>
    RULE_EXPRESSIONLIST_COMMA = 314, // <Expression List> ::= <Expression> ',' <Expression List>
    RULE_EXPRESSIONLIST = 315, // <Expression List> ::= <Expression>
    RULE_EXPRESSION_PLUS = 316, // <Expression> ::= <Expression> '+' <Mult Expression>
    RULE_EXPRESSION_MINUS = 317, // <Expression> ::= <Expression> '-' <Mult Expression>
    RULE_EXPRESSION_AMP = 318, // <Expression> ::= <Expression> '&' <Mult Expression>
    RULE_EXPRESSION_PIPE = 319, // <Expression> ::= <Expression> '|' <Mult Expression>
    RULE_EXPRESSION_CARET = 320, // <Expression> ::= <Expression> '^' <Mult Expression>
    RULE_EXPRESSION = 321, // <Expression> ::= <Mult Expression>
    RULE_MULTEXPRESSION_TIMES = 322, // <Mult Expression> ::= <Mult Expression> '*' <Unary Exp>
    RULE_MULTEXPRESSION_DIV = 323, // <Mult Expression> ::= <Mult Expression> '/' <Unary Exp>
    RULE_MULTEXPRESSION_PERCENT = 324, // <Mult Expression> ::= <Mult Expression> '%' <Unary Exp>
    RULE_MULTEXPRESSION = 325, // <Mult Expression> ::= <Unary Exp>
    RULE_UNARYEXP_MINUS = 326, // <Unary Exp> ::= '-' <Value>
    RULE_UNARYEXP_PLUS = 327, // <Unary Exp> ::= '+' <Value>
    RULE_UNARYEXP_TILDE = 328, // <Unary Exp> ::= '~' <Value>
    RULE_UNARYEXP = 329, // <Unary Exp> ::= <Value>
    RULE_VALUE_LPARAN_RPARAN = 330, // <Value> ::= '(' <search list> ')'
    RULE_VALUE_LPARAN_RPARAN2 = 331, // <Value> ::= '(' <Select Stm> ')'
    RULE_VALUE_INTEGERLITERAL = 332, // <Value> ::= IntegerLiteral
    RULE_VALUE_HEXLITERAL = 333, // <Value> ::= HexLiteral
    RULE_VALUE_REALLITERAL = 334, // <Value> ::= RealLiteral
    RULE_VALUE_STRINGLITERAL = 335, // <Value> ::= StringLiteral
    RULE_VALUE_NULL = 336, // <Value> ::= NULL
    RULE_VALUE = 337, // <Value> ::= <case>
    RULE_VALUE_IDENTIFIER = 338, // <Value> ::= Identifier <Argument List Opt>
    RULE_VALUE2 = 339, // <Value> ::= <special function>
    RULE_VALUE3 = 340, // <Value> ::= <Parameter>
    RULE_VALUE4 = 341, // <Value> ::= <XEval>
    RULE_PARAMETER_COLON_IDENTIFIER = 342, // <Parameter> ::= ':' Identifier
    RULE_XEVAL_LBRACE_STRINGLITERAL_RBRACE = 343, // <XEval> ::= '{' StringLiteral '}'
    RULE_CASE_CASE_END = 344, // <case> ::= CASE <casetype> <casewhen list> <caseelse> END
    RULE_CASETYPE = 345, // <casetype> ::= <Expression>
    RULE_CASETYPE2 = 346, // <casetype> ::= 
    RULE_CASEWHENLIST = 347, // <casewhen list> ::= <casewhen> <casewhen list>
    RULE_CASEWHENLIST2 = 348, // <casewhen list> ::= <casewhen>
    RULE_CASEWHEN_WHEN_THEN = 349, // <casewhen> ::= WHEN <search list> THEN <Expression>
    RULE_CASEELSE_ELSE = 350, // <caseelse> ::= ELSE <Expression>
    RULE_CASEELSE = 351, // <caseelse> ::= 
    RULE_SPECIALFUNCTION_CAST_LPARAN_AS_RPARAN = 352, // <special function> ::= CAST '(' <Expression> AS <Type> ')'
    RULE_SPECIALFUNCTION_CONVERT_LPARAN_COMMA_RPARAN = 353, // <special function> ::= CONVERT '(' <Type> ',' <Expression> <style> ')'
    RULE_STYLE_COMMA_INTEGERLITERAL = 354, // <style> ::= ',' IntegerLiteral
    RULE_STYLE_COMMA_STRINGLITERAL = 355, // <style> ::= ',' StringLiteral
    RULE_STYLE = 356, // <style> ::= 
    RULE_ARGUMENTLISTOPT_LPARAN_RPARAN = 357, // <Argument List Opt> ::= '(' <Restriction> <Argument List> ')'
    RULE_ARGUMENTLISTOPT = 358, // <Argument List Opt> ::= 
    RULE_ARGUMENTLIST_COMMA = 359, // <Argument List> ::= <Argument List> ',' <function args>
    RULE_ARGUMENTLIST = 360, // <Argument List> ::= <function args>
    RULE_FUNCTIONARGS_TIMES = 361, // <function args> ::= '*'
    RULE_FUNCTIONARGS = 362, // <function args> ::= <Expression> <alias>
    RULE_FUNCTIONARGS2 = 363  // <function args> ::= 
  };


}
