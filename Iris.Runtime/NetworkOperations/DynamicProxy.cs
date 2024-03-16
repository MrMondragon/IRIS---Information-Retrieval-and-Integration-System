using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Web.Services.Description;
using System.Xml.Serialization;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using Iris.Runtime.Model.Entities;

namespace Iris.Runtime.Core.Networking
{
  [Serializable]
  public class DynamicProxy
  {
    //Location of the WSDL file
    private Uri uri = null;
    //Services exposed by the WSDL file
    private ServiceDescription serviceDesc = null;
    //Name of the web service
    private String serviceName;
    ////Web methods available on a particular service
    //private MethodInfo[] webMethods; 
    //Proxy assembly to the web service
    private Assembly proxyAssembly;

    private IWebProxy webProxy;

    #region Constructor
    public DynamicProxy(Uri uri, IWebProxy webProxy)
    {
      this.uri = uri;
      ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
      this.webProxy = webProxy;
    }


    #endregion

    #region Public Methods
    public Boolean CheckValidationResult(Object sender,
    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
    System.Security.Cryptography.X509Certificates.X509Chain chain,
    System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
      if ((sslPolicyErrors == SslPolicyErrors.None) ||
      ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors) ||
      ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch) ||
      ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) == SslPolicyErrors.RemoteCertificateNotAvailable))
        return true;

      return false;
    }

    /// <summary>
    /// Create the proxy assembly for the web service and get a list of public methods on that proxy assembly
    /// </summary>
    /// <returns>A MethodInfo array with information about all the public methods of the proxy class.</returns>
    public MethodInfo[] GetWebMethods()
    {
      if (serviceDesc == null) serviceDesc = GetServiceDescription();
      if (serviceDesc == null)
        throw new InvalidOperationException("Unable to generate the proxy assembly.");
      serviceName = serviceDesc.Services[0].Name;

      if (proxyAssembly == null)
      {
        proxyAssembly = GenerateProxyAssembly();
        if (proxyAssembly == null)
          throw new InvalidOperationException("Unable to generate the proxy assembly.");
      }

      //'Use reflection to find the methods on the service requested by the user
      Type service = proxyAssembly.GetType(serviceName);
      return service.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.IgnoreCase |
      BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public);
    }

    /// <summary>
    /// Given the name of a web service and a method on that service get the list of parameters
    /// </summary>
    /// <param name="methodName">The web method to call.</param>
    /// <returns>A ParameterInfo array with information about all the parameters</returns>
    /// <remarks></remarks>
    public ParameterInfo[] GetParameters(String methodName)
    {
      if (proxyAssembly == null) return null;

      Type serviceType = proxyAssembly.GetType(serviceName);
      return serviceType.GetMethod(methodName).GetParameters();
    }

    /// <summary>
    /// Instantiate the proxy class and call one of its methods.
    /// </summary>
    /// <param name="methodName">The name of the web method to call</param>
    /// <param name="params">An array of objects that represent the parameters to the web method</param>
    /// <returns>Whatever the web method returns</returns>
    /// <remarks></remarks>
    public Object Invoke(String methodName, Object[] parms)
    {
      if (proxyAssembly == null) return null;

      Type assemblyType = proxyAssembly.GetType(serviceName);
      MethodInfo methodInfo = assemblyType.GetMethod(methodName);
      var instance = Activator.CreateInstance(assemblyType);
      if (instance != null)
      {
        if (webProxy != null)
        {
          MemberInfo[] mi = instance.GetType().GetMember("Proxy", BindingFlags.GetProperty | BindingFlags.IgnoreCase
            | BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

          PropertyInfo pi = (PropertyInfo)mi[0];

          pi.SetValue(instance, webProxy, null);
        }

        if (Credentials != null)
        {
          ((WebClientProtocol)instance).Credentials = Credentials;
          ((WebClientProtocol)instance).PreAuthenticate = true;
        }

        return methodInfo.Invoke(instance, parms);
      }
      else
      {
        throw new InvalidOperationException("Unable to create an instance of the proxy class");
      }
    }

    /// <summary>
    /// Calls GetType on one of the types in the proxy assembly
    /// </summary>
    /// <param name="typeName">Type name of the object that you want to get the type for</param>
    /// <returns>The type from the proxy assembly</returns>
    /// <remarks>The type is from the proxy assembly so it will only have the public interface to the type</remarks>
    public Type GetRemoteType(String typeName)
    {
      if (proxyAssembly == null) return null;
      return proxyAssembly.GetType(typeName);
    }

    public Type[] GetTypes()
    {
      if (proxyAssembly == null)
        return null;

      return proxyAssembly.GetTypes().Where(x => x.BaseType.Name != "SoapHttpClientProtocol").ToArray();
    }

    public Object ConvertParameterDataType(object paramValue, ParameterInfo pi)
    {
      if (paramValue == null) return null;
      if (pi.ParameterType.FullName == "System.String") return Convert.ToString(paramValue);
      if (pi.ParameterType.IsPrimitive)
      {
        return Convert.ChangeType(paramValue, pi.ParameterType);
      }
      if (pi.ParameterType.IsEnum)
      {
        Type enumType = GetRemoteType(pi.ParameterType.Name);
        return System.Enum.Parse(enumType, Convert.ToString(paramValue), true);
      }
      if((pi.ParameterType.IsArray)&&(paramValue is DataView))
      {
        DataView dv = ((DataView)paramValue);
        Type type = GetRemoteType(pi.ParameterType.Name);
        ConstructorInfo ci = type.GetConstructors().FirstOrDefault();
        Object objArray = null;
        if (ci != null)
        {
          objArray = ci.Invoke(new object[] { dv.Count });
          Array array = (Array)objArray;

          for (int i = 0; i < dv.Count; i++)
          {
            object objItem = DataRowToObject(dv[i], pi);

            array.SetValue(objItem, i);
          }
        }
        return objArray;
      }
      if ((paramValue is DataRow) || (paramValue is DataRowView))
      {
        return DataRowToObject(paramValue, pi);
      }
      if (paramValue.GetType() == pi.ParameterType)
        return paramValue;


      throw new ArgumentException("Unable to convert parameter to a simple type.", pi.Name);
    }


    private object DataRowToObject(object paramValue, ParameterInfo pi)
    {
      DataRow row;
      if (paramValue is DataRow)
        row = (DataRow)paramValue;
      else
        row = ((DataRowView)paramValue).Row;

      Type type = GetRemoteType(pi.ParameterType.Name.TrimEnd('[',']'));
      ConstructorInfo ci = type.GetConstructors().Where(x => x.GetParameters().Count() == 0).FirstOrDefault();
      if (ci != null)
      {
        Object obj = ci.Invoke(new object[] { });
        if (obj != null)
        {
          PropertyInfo[] pis = type.GetProperties();
          FieldInfo[] fis = type.GetFields();
          foreach (DataColumn col in row.Table.Columns)
          {
            PropertyInfo pInfo = pis.Where(x => x.Name == col.ColumnName).FirstOrDefault();
            if (pInfo != null)
              pInfo.SetValue(obj, row[col], new object[] { });
            else
            {
              FieldInfo fInfo = fis.Where(x => x.Name == col.ColumnName).FirstOrDefault();
              if (fInfo != null)
                fInfo.SetValue(obj, row[col]);
            }
          }
          return obj;
        }
      }

      return null;
    }
    #endregion

    #region Private Methods

    /// <summary>
    /// Gets the services exposed by the URI.
    /// </summary>
    /// <returns>A ServiceDescription object populated with information about the services in the WSDL.</returns>
    private ServiceDescription GetServiceDescription()
    {
      if (uri == null) return null;

      WebRequest webReq = WebRequest.Create(uri);
      webReq.Proxy = webProxy;
      if (Credentials != null)
        webReq.Credentials = Credentials;
      Stream reqStrm = webReq.GetResponse().GetResponseStream();
      return ServiceDescription.Read(reqStrm);
    }

    [NonSerialized]
    private NetworkCredential credentials;

    public NetworkCredential Credentials
    {
      get { return credentials; }
      set { credentials = value; }
    }

    /// <summary>
    /// Dynamically generate a proxy assembly for the web service described in the WSDL.
    /// </summary>
    /// <returns>An assembly that is a proxy class for the web service defined in the WSDL</returns>
    /// <remarks>This method uses the ServiceDescription so if it does not exist and can not be created thorw an exception.</remarks>
    private Assembly GenerateProxyAssembly()
    {
      //Check the pre-requesites
      if (serviceDesc == null)
      {
        serviceDesc = GetServiceDescription();
        if (serviceDesc == null)
        {
          throw new InvalidOperationException("Unable to create the ServiceDescription for the specified URI.");
        }
      }

      //Import the information about the service
      ServiceDescriptionImporter servImport = new ServiceDescriptionImporter();
      servImport.AddServiceDescription(serviceDesc, String.Empty, String.Empty);
      servImport.ProtocolName = "Soap";
      servImport.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;

      //Set up to generate the code
      CodeNamespace ns = new CodeNamespace();
      CodeCompileUnit ccu = new CodeCompileUnit();
      ccu.Namespaces.Add(ns);
      ServiceDescriptionImportWarnings warnings = servImport.Import(ns, ccu);
      //If we didn't find any methods there will be nothing to call later so just stop now.
      if ((warnings == ServiceDescriptionImportWarnings.NoCodeGenerated) ||
      (warnings == ServiceDescriptionImportWarnings.NoMethodsGenerated)) return null;

      CSharpCodeProvider prov = new CSharpCodeProvider();

      //Generate the code
      StringWriter sw = new StringWriter(CultureInfo.CurrentCulture);
      prov.GenerateCodeFromNamespace(ns, sw, null);

      //Create the assembly
      CompilerParameters param = new CompilerParameters(new String[] { "System.dll", "System.Xml.dll", "System.Web.Services.dll", "System.Data.dll" });
      param.GenerateExecutable = false;
      param.GenerateInMemory = true;
      param.TreatWarningsAsErrors = false;
      param.WarningLevel = 4;
      CompilerResults results = new CompilerResults(null);
      results = prov.CompileAssemblyFromSource(param, sw.ToString());
      return results.CompiledAssembly;
    }
    #endregion
  }
}
