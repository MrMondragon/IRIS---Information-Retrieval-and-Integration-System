namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Text;

    internal class BinaryValue : DatasetQuery.Value
    {
        public BinaryValue(string v)
        {
            this.HEXINDEX = "0123456789abcdef          ABCDEF";
            this.Value = this.HexStringToByteArray(v);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private string ByteArrayToHex(byte[] data)
        {
            StringBuilder builder1 = new StringBuilder();
            int num2 = data.Length;
            for (int num1 = 0; num1 <= num2; num1++)
            {
                builder1.Append(this.HEXINDEX[(byte) (data[num1] >> (IntegerType.FromString(StringType.FromInteger(4) + StringType.FromInteger(15)) & 7))]);
                builder1.Append(this.HEXINDEX[IntegerType.FromString(StringType.FromByte(data[num1]) + StringType.FromInteger(15))]);
            }
            return builder1.ToString();
        }

        public override void CalculateRow(DataRow row)
        {
        }

        private byte[] HexStringToByteArray(string HexData)
        {
            int num2 = (int) Math.Round((double) (((double) HexData.Length) / 2));
            byte[] buffer1 = new byte[(num2 - 1) + 1];
            int num1 = 0;
            int num6 = num2 - 1;
            for (int num4 = 0; num4 <= num6; num4++)
            {
                char ch1 = HexData[num1];
                num1++;
                int num3 = 0;
                int num5 = this.HEXINDEX.IndexOf(ch1);
                if (num1 < HexData.Length)
                {
                    num3 = (num5 & 15) << 4;
                    ch1 = HexData[num1];
                    num1++;
                    num5 = this.HEXINDEX.IndexOf(ch1);
                }
                num3 += num5 & 15;
                buffer1[num4] = (byte) num3;
            }
            return buffer1;
        }

        public override object KeepRow(DataRow row)
        {
            return this.Value;
        }


        public override bool IsConstant
        {
            get
            {
                return true;
            }
        }


        private string HEXINDEX;
        public byte[] Value;
    }
}

