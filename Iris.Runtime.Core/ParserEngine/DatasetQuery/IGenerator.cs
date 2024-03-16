namespace DatasetQuery
{
    using System.Data;
    using System.IO;

    internal interface IGenerator
    {
        Stream Generate(DataSet dataset);
    }
}

