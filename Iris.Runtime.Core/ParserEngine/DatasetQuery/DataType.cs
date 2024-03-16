namespace DatasetQuery
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal class DataType
    {
        public DataType(Type type, [Optional] int theSize /* = 1 */, [Optional] int theScale /* = 0 */, [Optional] int Precision /* = 0 */)
        {
            this.DotNetType = type;
            this.Size = theSize;
            this.Scale = theScale;
            precision = Precision;
        }

        public object ConvertValue(object value)
        {
            return DataType.ConvertValue(RuntimeHelpers.GetObjectValue(value), this.DotNetType, this.Size);
        }

        public static object ConvertValue(object value, Type type, [Optional] int size /* = 0 */)
        {
            string text1 = "Explicit conversion from data type {0} to {1} is not allowed.";
            if (value == DBNull.Value)
            {
                return value;
            }
            if (type.IsArray)
            {
                string text7 = type.Name;
                if (StringType.StrCmp(text7, "Byte[]", false) == 0)
                {
                    if (StringType.StrCmp(value.GetType().Name, "Byte[]", false) != 0)
                    {
                        MemoryStream stream1 = new MemoryStream();
                        BinaryWriter writer1 = new BinaryWriter(stream1);
                        if (value is DateTime)
                        {
                            value = DateType.FromObject(value).ToFileTime();
                        }
                        else if (value is Guid)
                        {
                            value = ((Guid) value).ToByteArray();
                        }
                        if (value is string)
                        {
                            writer1.Write(StringType.FromObject(value).ToCharArray());
                            if ((size > 0) && (size < 0x7fffffff))
                            {
                                stream1.SetLength((long) size);
                            }
                            return stream1.ToArray();
                        }
                        object[] objArray1 = new object[] { RuntimeHelpers.GetObjectValue(value) };
                        bool[] flagArray1 = new bool[] { true };
                        LateBinding.LateCall(writer1, null, "Write", objArray1, null, flagArray1);
                        if (flagArray1[0])
                        {
                            value = RuntimeHelpers.GetObjectValue(objArray1[0]);
                        }
                        if ((size > 0) && (size < 0x7fffffff))
                        {
                            stream1.SetLength((long) size);
                        }
                        return stream1.ToArray();
                    }
                    byte[] buffer2 = (byte[]) value;
                    if ((size > 0) & (size < 0x7fffffff))
                    {
                        buffer2 = (byte[]) Utils.CopyArray((Array) buffer2, new byte[(size - 1) + 1]);
                    }
                    return buffer2;
                }
                if (StringType.StrCmp(text7, "Char[]", false) != 0)
                {
                    throw new NotSupportedException("Array type " + type.Name);
                }
                return StringType.FromObject(value).ToCharArray();
            }
            if (value.GetType().IsArray)
            {
                MemoryStream stream2 = new MemoryStream((byte[]) value);
                BinaryReader reader1 = new BinaryReader(stream2);
                string text6 = type.Name;
                if (StringType.StrCmp(text6, "Int32", false) == 0)
                {
                    int num1 = 0;
                    if (reader1.BaseStream.Length >= 4)
                    {
                        return reader1.ReadInt32();
                    }
                    if (reader1.BaseStream.Length >= 2)
                    {
                        return reader1.ReadInt16();
                    }
                    if (reader1.BaseStream.Length == 1)
                    {
                        num1 = reader1.ReadByte();
                    }
                    return num1;
                }
                if (StringType.StrCmp(text6, "Boolean", false) != 0)
                {
                    if (StringType.StrCmp(text6, "Byte", false) != 0)
                    {
                        if (StringType.StrCmp(text6, "DateTime", false) == 0)
                        {
                            long num2 = 0;
                            if (reader1.BaseStream.Length >= 8)
                            {
                                num2 = reader1.ReadInt64();
                            }
                            else if (reader1.BaseStream.Length >= 4)
                            {
                                num2 = reader1.ReadInt32();
                            }
                            else if (reader1.BaseStream.Length >= 2)
                            {
                                num2 = reader1.ReadInt16();
                            }
                            else if (reader1.BaseStream.Length == 1)
                            {
                                num2 = reader1.ReadByte();
                            }
                            try
                            {
                                return DateTime.FromFileTime(num2);
                            }
                            catch (Exception exception13)
                            {
                                ProjectData.SetProjectError(exception13);
                                Exception exception1 = exception13;
                                throw new DataException(exception1.Message, exception1);
                            }
                        }
                        if (StringType.StrCmp(text6, "Decimal", false) == 0)
                        {
                            decimal num3= 0;
                            if (reader1.BaseStream.Length >= 0x10)
                            {
                                return reader1.ReadDecimal();
                            }
                            if (reader1.BaseStream.Length >= 8)
                            {
                                return new decimal(reader1.ReadInt64());
                            }
                            if (reader1.BaseStream.Length >= 4)
                            {
                                return new decimal(reader1.ReadInt32());
                            }
                            if (reader1.BaseStream.Length >= 2)
                            {
                                return new decimal(reader1.ReadInt16());
                            }
                            if (reader1.BaseStream.Length == 1)
                            {
                                num3 = new decimal(reader1.ReadByte());
                            }
                            return num3;
                        }
                        if (StringType.StrCmp(text6, "Double", false) == 0)
                        {
                            double num4 = 0.0;
                            long num5 = 0;
                            if (reader1.BaseStream.Length >= 8)
                            {
                                num4 = reader1.ReadDouble();
                                reader1.BaseStream.Position = 0;
                                num5 = reader1.ReadInt64();
                            }
                            else if (reader1.BaseStream.Length >= 4)
                            {
                                num4 = reader1.ReadInt32();
                            }
                            else if (reader1.BaseStream.Length >= 2)
                            {
                                num4 = reader1.ReadInt16();
                            }
                            else if (reader1.BaseStream.Length == 1)
                            {
                                num4 = reader1.ReadByte();
                            }
                            if (double.IsNaN(num4))
                            {
                                return num5;
                            }
                            return num4;
                        }
                        if (StringType.StrCmp(text6, "Int64", false) == 0)
                        {
                            long num6=0;
                            if (reader1.BaseStream.Length >= 8)
                            {
                                return reader1.ReadInt64();
                            }
                            if (reader1.BaseStream.Length >= 4)
                            {
                                return (long) reader1.ReadInt32();
                            }
                            if (reader1.BaseStream.Length >= 2)
                            {
                                return (long) reader1.ReadInt16();
                            }
                            if (reader1.BaseStream.Length == 1)
                            {
                                num6 = reader1.ReadByte();
                            }
                            return num6;
                        }
                        if (StringType.StrCmp(text6, "Object", false) != 0)
                        {
                            if (StringType.StrCmp(text6, "Int16", false) == 0)
                            {
                                short num7=0;
                                if (reader1.BaseStream.Length >= 2)
                                {
                                    return reader1.ReadInt16();
                                }
                                if (reader1.BaseStream.Length == 1)
                                {
                                    num7 = reader1.ReadByte();
                                }
                                return num7;
                            }
                            if (StringType.StrCmp(text6, "Single", false) == 0)
                            {
                                float single1=0;
                                if (reader1.BaseStream.Length >= 4)
                                {
                                    return reader1.ReadSingle();
                                }
                                if (reader1.BaseStream.Length >= 2)
                                {
                                    return (float) reader1.ReadInt16();
                                }
                                if (reader1.BaseStream.Length == 1)
                                {
                                    single1 = reader1.ReadByte();
                                }
                                return single1;
                            }
                            if (StringType.StrCmp(text6, "String", false) == 0)
                            {
                                if ((size < 0) || (reader1.BaseStream.Length < size))
                                {
                                    size = (int) reader1.BaseStream.Length;
                                }
                                string text3 = new string(reader1.ReadChars(size));
                                if (size < 0x7fffffff)
                                {
                                    text3 = text3.PadRight(size);
                                    if (text3.Length > size)
                                    {
                                        text3 = text3.Substring(0, size);
                                    }
                                }
                                return text3;
                            }
                            if (StringType.StrCmp(text6, "DBNull", false) == 0)
                            {
                                throw new DataException(string.Format(text1, value.GetType().ToString(), type.Name));
                            }
                            if (StringType.StrCmp(text6, "Guid", false) == 0)
                            {
                                byte[] buffer3 = reader1.ReadBytes(0x10);
                                buffer3 = (byte[]) Utils.CopyArray((Array) buffer3, new byte[0x10]);
                                return new Guid(buffer3);
                            }
                            throw new NotSupportedException("Binary to data type " + type.Name);
                        }
                        return RuntimeHelpers.GetObjectValue(value);
                    }
                    return reader1.ReadByte();
                }
                return reader1.ReadBoolean();
            }
            string text5 = type.Name;
            if (StringType.StrCmp(text5, "Int32", false) == 0)
            {
                if (value is long)
                {
                    if (ObjectType.ObjTst(value, 0x7fffffff, false) > 0)
                    {
                        value = 0x7fffffff;
                    }
                }
                else if (((value is float) || (value is double)) && (ObjectType.ObjTst(value, 0x7fffffff, false) >= 0))
                {
                    value = 0x7fffffff;
                }
                try
                {
                    return IntegerType.FromObject(value);
                }
                catch (Exception exception14)
                {
                    ProjectData.SetProjectError(exception14);
                    Exception exception2 = exception14;
                    throw new DataException(exception2.Message, exception2);
                }
            }
            if (StringType.StrCmp(text5, "Boolean", false) == 0)
            {
                if (!Information.IsNumeric(RuntimeHelpers.GetObjectValue(value)) && (value is string))
                {
                    throw new DataException(string.Format(text1, value.GetType().ToString(), type.Name));
                }
                if (value is Guid)
                {
                    throw new DataException(string.Format(text1, value.GetType().ToString(), type.Name));
                }
                try
                {
                    if (ObjectType.ObjTst(value, 0, false) > 0)
                    {
                        return 1;
                    }
                    return 0;
                }
                catch (Exception exception15)
                {
                    ProjectData.SetProjectError(exception15);
                    Exception exception3 = exception15;
                    throw new DataException(exception3.Message, exception3);
                }
            }
            if (StringType.StrCmp(text5, "Byte", false) == 0)
            {
                try
                {
                    return ByteType.FromObject(value);
                }
                catch (Exception exception16)
                {
                    ProjectData.SetProjectError(exception16);
                    Exception exception4 = exception16;
                    throw new DataException(exception4.Message, exception4);
                }
            }
            if (StringType.StrCmp(text5, "DateTime", false) == 0)
            {
                object obj1;
                if (value is DateTime)
                {
                    return RuntimeHelpers.GetObjectValue(value);
                }
                if (value is string)
                {
                    try
                    {
                        return DateTime.Parse(StringType.FromObject(value));
                    }
                    catch (Exception exception17)
                    {
                        ProjectData.SetProjectError(exception17);
                        Exception exception5 = exception17;
                        throw new DataException(exception5.Message, exception5);
                    }
                }
                try
                {
                    obj1 = DateTime.FromFileTime(LongType.FromObject(value));
                }
                catch (Exception exception18)
                {
                    ProjectData.SetProjectError(exception18);
                    Exception exception6 = exception18;
                    throw new DataException(exception6.Message, exception6);
                }
                return obj1;
            }
            if (StringType.StrCmp(text5, "Double", false) == 0)
            {
                try
                {
                    return DoubleType.FromObject(value);
                }
                catch (Exception exception19)
                {
                    ProjectData.SetProjectError(exception19);
                    Exception exception7 = exception19;
                    throw new DataException(exception7.Message, exception7);
                }
            }
            if (StringType.StrCmp(text5, "Decimal", false) == 0)
            {
                try
                {
                    return DecimalType.FromObject(value);
                }
                catch (Exception exception20)
                {
                    ProjectData.SetProjectError(exception20);
                    Exception exception8 = exception20;
                    throw new DataException(exception8.Message, exception8);
                }
            }
            if (StringType.StrCmp(text5, "Int64", false) == 0)
            {
                try
                {
                    return LongType.FromObject(value);
                }
                catch (Exception exception21)
                {
                    ProjectData.SetProjectError(exception21);
                    Exception exception9 = exception21;
                    throw new DataException(exception9.Message, exception9);
                }
            }
            if (StringType.StrCmp(text5, "Object", false) == 0)
            {
                return RuntimeHelpers.GetObjectValue(value);
            }
            if (StringType.StrCmp(text5, "Int16", false) == 0)
            {
                try
                {
                    return ShortType.FromObject(value);
                }
                catch (Exception exception22)
                {
                    ProjectData.SetProjectError(exception22);
                    Exception exception10 = exception22;
                    throw new DataException(exception10.Message, exception10);
                }
            }
            if (StringType.StrCmp(text5, "Single", false) == 0)
            {
                try
                {
                    return SingleType.FromObject(value);
                }
                catch (Exception exception23)
                {
                    ProjectData.SetProjectError(exception23);
                    Exception exception11 = exception23;
                    throw new DataException(exception11.Message, exception11);
                }
            }
            if (StringType.StrCmp(text5, "String", false) == 0)
            {
                if (value is string)
                {
                    return RuntimeHelpers.GetObjectValue(value);
                }
                if (Information.IsDate(RuntimeHelpers.GetObjectValue(value)))
                {
                    value = DateType.FromObject(value).ToString();
                }
                else if (value is Guid)
                {
                    value = ((Guid) value).ToString();
                }
                string text4 = StringType.FromObject(value);
                if ((size > 0) && (size < 0x7fffffff))
                {
                    text4 = text4.PadRight(size);
                    if (text4.Length > size)
                    {
                        text4 = text4.Substring(0, size);
                    }
                }
                return text4;
            }
            if (StringType.StrCmp(text5, "DBNull", false) != 0)
            {
                if (StringType.StrCmp(text5, "Guid", false) != 0)
                {
                    throw new NotSupportedException("Data type " + type.Name);
                }
                if (!(value is Guid))
                {
                    if (value is string)
                    {
                        try
                        {
                            return new Guid(StringType.FromObject(value));
                        }
                        catch (Exception exception24)
                        {
                            ProjectData.SetProjectError(exception24);
                            Exception exception12 = exception24;
                            throw new DataException(exception12.Message, exception12);
                        }
                    }
                    throw new DataException(string.Format(text1, value.GetType().ToString(), type.Name));
                }
                return RuntimeHelpers.GetObjectValue(value);
            }
            return DBNull.Value;
        }

        public static object MaxValue(Type type)
        {
            string text1 = type.Name;
            if (StringType.StrCmp(text1, "Int32", false) != 0)
            {
                if (StringType.StrCmp(text1, "Byte", false) != 0)
                {
                    if (StringType.StrCmp(text1, "DateTime", false) != 0)
                    {
                        if (StringType.StrCmp(text1, "Double", false) != 0)
                        {
                            if ((StringType.StrCmp(text1, "Decimal", false) != 0) && (StringType.StrCmp(text1, "String", false) != 0))
                            {
                                if (StringType.StrCmp(text1, "Int64", false) != 0)
                                {
                                    if (StringType.StrCmp(text1, "Int16", false) != 0)
                                    {
                                        if (StringType.StrCmp(text1, "Single", false) != 0)
                                        {
                                            throw new NotSupportedException();
                                        }
                                        return 3.402823E+38f;
                                    }
                                    return (short) 0x7fff;
                                }
                                return 0x7fffffffffffffff;
                            }
                            return new decimal(-1, -1, -1, false, 0);
                        }
                        return 1.7976931348623157E+308;
                    }
                    return DateTime.MaxValue;
                }
                return (byte) 0xff;
            }
            return 0x7fffffff;
        }

        public static object MinValue(Type type)
        {
            string text1 = type.Name;
            if (StringType.StrCmp(text1, "Int32", false) != 0)
            {
                if (StringType.StrCmp(text1, "Byte", false) != 0)
                {
                    if (StringType.StrCmp(text1, "DateTime", false) != 0)
                    {
                        if (StringType.StrCmp(text1, "Double", false) != 0)
                        {
                            if ((StringType.StrCmp(text1, "Decimal", false) != 0) && (StringType.StrCmp(text1, "String", false) != 0))
                            {
                                if (StringType.StrCmp(text1, "Int64", false) != 0)
                                {
                                    if (StringType.StrCmp(text1, "Int16", false) != 0)
                                    {
                                        if (StringType.StrCmp(text1, "Single", false) != 0)
                                        {
                                            throw new NotSupportedException();
                                        }
                                        return -3.402823E+38f;
                                    }
                                    return (short) (-32768);
                                }
                                return -9223372036854775808;
                            }
                            return new decimal(-1, -1, -1, true, 0);
                        }
                        return -1.7976931348623157E+308;
                    }
                    return DateTime.MinValue;
                }
                return (byte) 0;
            }
            return -2147483648;
        }


        public Type DotNetType;
        public int precision;
        public int Scale;
        public int Size;
    }
}

