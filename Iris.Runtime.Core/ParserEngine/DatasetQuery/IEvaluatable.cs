namespace DatasetQuery
{
    using System;
    using System.Data;

    internal interface IEvaluatable
    {
        DataView Execute(DataSet dataset);
        int ExecuteNonQuery(DataSet dataset);
    }
}

