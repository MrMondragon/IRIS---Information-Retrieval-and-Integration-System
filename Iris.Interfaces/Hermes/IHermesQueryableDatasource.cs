using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Iris.Interfaces.Hermes
{
  public interface IHermesQueryableDatasource: IHermesDatasource
  {
    DataTable ExecQuery(string query, Dictionary<string, object> parameters);
    int ExecuteNonQuery(string Sql, Dictionary<string, object> parameters);
    object ExecuteScalar(string Sql, Dictionary<string, object> parameters);
  }
}
