using System;
using System.Net;
namespace Iris.Interfaces
{
  public interface ICredentialOperation
  {
    NetworkCredential Credentials { get; set; }
    NetworkCredential WebCredentials { get; set; }
  }
}
