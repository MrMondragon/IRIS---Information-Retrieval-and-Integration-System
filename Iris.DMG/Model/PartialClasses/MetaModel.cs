using System.Data.Common;
namespace Iris.DMG.Model
{
  public partial class MetaModel
  {
    public MetaModel(DbConnection connection)
      : base(connection, false)
    {
    }
  }

}
