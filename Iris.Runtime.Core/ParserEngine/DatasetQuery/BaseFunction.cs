namespace DatasetQuery
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal abstract class BaseFunction
    {
        protected object ConvertValue(object value, Type type, [Optional] int size /* = 0 */)
        {
            return DataType.ConvertValue(RuntimeHelpers.GetObjectValue(value), type, size);
        }

        public abstract object Execute(object[] pars);

        public abstract int ParameterCount { get; }

    }
}

