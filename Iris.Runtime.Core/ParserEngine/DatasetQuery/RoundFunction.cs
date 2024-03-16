namespace DatasetQuery
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    internal class RoundFunction : BaseFunction
    {
        private void CheckParamLength(int actual, int expected)
        {
            if (actual < expected)
            {
                throw new DataException(string.Format("The Round function requires {0} arguments.", expected));
            }
        }

        public override object Execute(object[] pars)
        {
            bool[] flagArray1;
            object[] objArray1;
            object[] objArray2;
            int num2;
            this.CheckParamLength(pars.Length, 1);
            object obj2 = DBNull.Value;
            if (pars[0] == DBNull.Value)
            {
                return obj2;
            }
            if (pars.Length == 1)
            {
                objArray2 = new object[1];
                num2 = 0;
                objArray2[0] = RuntimeHelpers.GetObjectValue(pars[num2]);
                objArray1 = objArray2;
                flagArray1 = new bool[] { true };
                if (flagArray1[0])
                {
                    pars[num2] = RuntimeHelpers.GetObjectValue(objArray1[0]);
                }
                return RuntimeHelpers.GetObjectValue(LateBinding.LateGet(null, typeof(Math), "Round", objArray1, null, flagArray1));
            }
            if (pars[1] == DBNull.Value)
            {
                return obj2;
            }
            this.CheckParamLength(pars.Length, 2);
            int num1 = IntegerType.FromObject(this.ConvertValue(RuntimeHelpers.GetObjectValue(pars[1]), typeof(int), 0));
            if (pars.Length != 2)
            {
                throw new DataException(string.Format("The Round function does not take {0} arguments.", pars.Length));
            }
            objArray1 = new object[2];
            num2 = 0;
            objArray1[0] = RuntimeHelpers.GetObjectValue(pars[num2]);
            objArray1[1] = num1;
            objArray2 = objArray1;
            flagArray1 = new bool[] { true, true };
            if (flagArray1[1])
            {
                num1 = IntegerType.FromObject(objArray2[1]);
            }
            if (flagArray1[0])
            {
                pars[num2] = RuntimeHelpers.GetObjectValue(objArray2[0]);
            }
            return RuntimeHelpers.GetObjectValue(LateBinding.LateGet(null, typeof(Math), "Round", objArray2, null, flagArray1));
        }


        public override int ParameterCount
        {
            get
            {
                return -1;
            }
        }

    }
}

