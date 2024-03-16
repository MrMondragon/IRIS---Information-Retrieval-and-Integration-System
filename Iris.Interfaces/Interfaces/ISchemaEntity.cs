using System;
using Iris.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Iris.Runtime.Model.Entities
{
  public interface ISchemaEntity : IEntity
  {
    void CreateResultSets();
    string DisplayText { get; set; }
    string FileName { get; set; }
    string RawText { get; set; }
    string TablePrefix { get; set; }
  }
}
