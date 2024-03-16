using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Dynamics.BusinessConnectorNet;
using Iris.Runtime.Model.BaseObjects;

namespace Iris.AxIntegration
{
  public class AxContext
  {
    public AxContext()
    {
      ax = new Axapta();
      objects = new Dictionary<string, AxaptaObject>();
      records = new Dictionary<string, AxaptaRecord>();
      containers = new Dictionary<string, AxaptaContainer>();
    }

    private Axapta ax;

    public Axapta Ax
    {
      get { return ax; }
      set { ax = value; }
    }

    private Dictionary<string, AxaptaObject> objects;
    public Dictionary<string, AxaptaObject> Objects
    {
      get { return objects; }
    }

    public List<string> GetObjectNames()
    {
      return GetNames<AxaptaObject>(objects);
    }

    private List<string> GetNames<T>(Dictionary<string, T> dictionary)
    {
      List<string> list = new List<string>();
      foreach (KeyValuePair<string, T> kvp in dictionary)
      {
        list.Add(kvp.Key);
      }
      return list;
    }

    private Dictionary<string, AxaptaRecord> records;

    public Dictionary<string, AxaptaRecord> Records
    {
      get { return records; }
    }

    public List<string> GetRecordNames()
    {
      return GetNames<AxaptaRecord>(records);
    }

    private Dictionary<string, AxaptaContainer> containers;

    public Dictionary<string, AxaptaContainer> Containers
    {
      get { return containers; }
    }

    public List<string> GetContainerNames()
    {
      return GetNames<AxaptaContainer>(containers);
    }
  }
}
