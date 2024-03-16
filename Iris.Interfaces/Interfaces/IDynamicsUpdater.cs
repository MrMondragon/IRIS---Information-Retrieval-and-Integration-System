using System;
using System.Net;
namespace Iris.DynamicsServices
{
  interface IDynamicsUpdater
  {
    NetworkCredential WebCredentials { get; set; }
  }
}
