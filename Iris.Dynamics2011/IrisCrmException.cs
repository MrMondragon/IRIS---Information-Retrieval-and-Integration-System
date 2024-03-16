using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Dynamics2011
{
  public class IrisCrmException: Exception
  {
    public IrisCrmException(string message, string propertyName, string propertyValue):
      base(message)
    {
      this.propertyName = propertyName;
      this.propertyValue = propertyValue;
    }

    private string propertyName;

    public string PropertyName
    {
      get { return propertyName; }
    }

    private string propertyValue;

    public string PropertyValue
    {
      get { return propertyValue; }
    }


  }
}
