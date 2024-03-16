namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Text;

    internal class Utilities
    {
        public static string AvoidDuplicateColumnName(DataColumnCollection cols, string name)
        {
            string text2 = "";
            while (cols.Contains(name + text2))
            {
                if (StringType.StrCmp(text2, "", false) == 0)
                {
                    text2 = StringType.FromInteger(0);
                }
                text2 = StringType.FromDouble(DoubleType.FromString(text2) + 1);
            }
            return (name + text2);
        }

        public static DataColumn CloneColumn(DataColumn s)
        {
            string text1 = s.Table.TableName.ToLower() + ".";
            if ((StringType.StrCmp(text1, ".", false) != 0) && !s.ColumnName.ToLower().StartsWith(text1))
            {
                text1 = s.Table.TableName + "." + s.ColumnName;
            }
            else
            {
                text1 = s.ColumnName;
            }
            DataColumn column2 = new DataColumn(text1, s.DataType);
            column2.AllowDBNull = true;
            return column2;
        }

        internal static bool ColumnEqual(object A, object B)
        {
            if ((A == DBNull.Value) & (B == DBNull.Value))
            {
                return true;
            }
            if ((A == DBNull.Value) | (B == DBNull.Value))
            {
                return false;
            }
            return (ObjectType.ObjTst(A, B, false) == 0);
        }

        private static string ColumnsToString(DataColumnCollection Columns)
        {
            StringBuilder builder1 = new StringBuilder();
            foreach (DataColumn column1 in Columns)
            {
                builder1.Append(column1.ColumnName).Append(",");
            }
            return builder1.ToString().TrimEnd(new char[] { ',' });
        }

        public static object CompareEqual(object obj, object Value)
        {
            if (obj is bool)
            {
                return (ObjectType.ObjTst(obj, BooleanType.FromObject(Value), false) == 0);
            }
            return (ObjectType.ObjTst(obj, Value, false) == 0);
        }

        public static object ComputeScalar(DataSet ds, IEvaluatable eval)
        {
            DataTable table1 = eval.Execute(ds).Table;
            if (table1.Rows.Count > 0)
            {
                return RuntimeHelpers.GetObjectValue(table1.Rows[0][0]);
            }
            return DBNull.Value;
        }

        public static void Distinct(DataView view)
        {
            view.Sort = Utilities.ColumnsToString(view.Table.Columns);
            ArrayList list1 = new ArrayList();
            DataRow row1 = null;
            int num2 = view.Count - 1;
            for (int num1 = 0; num1 <= num2; num1++)
            {
                if ((row1 == null) || !Utilities.RowEqual(row1, view[num1].Row, view.Table.Columns.Count))
                {
                    row1 = view[num1].Row;
                }
                else
                {
                    list1.Add(view[num1].Row);
                }
            }
            foreach (DataRow row2 in list1)
            {
                view.Table.Rows.Remove(row2);
            }
        }

        public static bool Exists(DataSet ds, IEvaluatable eval)
        {
            return (eval.Execute(ds).Table.Rows.Count > 0);
        }

        public static DataColumn GetColumn(DataColumnCollection cols, string name)
        {
            DataColumn column1 = cols[name];
            if (column1 == null)
            {
                foreach (DataColumn column2 in cols)
                {
                    if (((string.Compare(column2.ColumnName, column2.Table.TableName + "." + name, true) == 0) || (string.Compare(name, Strings.Mid(column2.ColumnName, column2.ColumnName.IndexOf(".") + 2), true) == 0)) || (string.Compare(name, column2.Table.TableName + "." + column2.ColumnName, true) == 0))
                    {
                        return column2;
                    }
                }
            }
            return column1;
        }

        private static bool RowEqual(DataRow First, DataRow Second, int ColumnCount)
        {
            int num2 = ColumnCount - 1;
            for (int num1 = 0; num1 <= num2; num1++)
            {
                if (!Utilities.ColumnEqual(RuntimeHelpers.GetObjectValue(First[num1]), RuntimeHelpers.GetObjectValue(Second[num1])))
                {
                    return false;
                }
            }
            return true;
        }

        public static DataTable ToTable(DataView dv)
        {
            DataTable table1 = new DataTable();
            table1.Locale = dv.Table.Locale;
            table1.CaseSensitive = dv.Table.CaseSensitive;
            table1.TableName = dv.Table.TableName;
            table1.Namespace = dv.Table.Namespace;
            table1.Prefix = dv.Table.Prefix;
            string[] textArray1 = new string[(dv.Table.Columns.Count - 1) + 1];
            int num6 = textArray1.Length - 1;
            for (int num2 = 0; num2 <= num6; num2++)
            {
                textArray1[num2] = dv.Table.Columns[num2].ColumnName;
            }
            int[] numArray1 = new int[(textArray1.Length - 1) + 1];
            ArrayList list1 = new ArrayList();
            int num5 = textArray1.Length - 1;
            for (int num1 = 0; num1 <= num5; num1++)
            {
                DataColumn column1 = dv.Table.Columns[textArray1[num1]];
                table1.Columns.Add(column1.ColumnName, column1.DataType);
                numArray1[num1] = dv.Table.Columns.IndexOf(column1.ColumnName);
            }
            int num4 = dv.Count - 1;
            for (int num3 = 0; num3 <= num4; num3++)
            {
                table1.Rows.Add(dv[num3].Row.ItemArray);
            }
            return table1;
        }

        public static void TruncateToMaxRows(DataView view, int maxrows)
        {
            while (view.Count > maxrows)
            {
                view[maxrows].Delete();
            }
        }

    }
}

