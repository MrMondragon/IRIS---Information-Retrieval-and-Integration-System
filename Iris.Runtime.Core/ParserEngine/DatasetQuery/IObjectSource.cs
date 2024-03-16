namespace DatasetQuery
{
    using System.Data;

    public interface IObjectSource
    {
        DataTable ToTable();
    }
}

