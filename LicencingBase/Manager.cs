using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using Microsoft.Win32;
using System.Security.Principal;
using System.Windows.Forms;
using Databridge.Engine.Criptography;

namespace Databridge.Licence
{
  public class Manager
  {
    #region Mac Address

    public static string GetMacAddress()
    {
      ManagementClass oMClass = new ManagementClass("Win32_NetworkAdapterConfiguration");

      ManagementObjectCollection colMObj = oMClass.GetInstances();
      Dictionary<string, int> addresses = new Dictionary<string, int>();
      int max = 0;

      foreach (ManagementObject objMO in colMObj)
      {
        string macAddress = Convert.ToString(objMO["MacAddress"]);
        if (!string.IsNullOrEmpty(macAddress))
        {
          if (!addresses.ContainsKey(macAddress))
          {
            PropertyDataCollection pdc = objMO.Properties;
            int propCount = 0;
            foreach (PropertyData item in pdc)
            {
              if (objMO[item.Name] != null)
                propCount++;
            }

            addresses[macAddress] = propCount; ;

            if (propCount > max)
              max = propCount;
          }
        }
      }

      if (addresses.Count > 0)
      {
        List<string> selectedAddresses = addresses.Where(x => x.Value == max).Select(x => x.Key).ToList();
        //List<string> selectedAddresses = addresses.Select(x => x.Key).ToList();
        string mac = selectedAddresses[0];
        return mac;
        if (selectedAddresses.Count > 1)
        {
          for (int i = 1; i < selectedAddresses.Count; i++)
          {
            string[] bas = mac.Split(':');
            string[] address = selectedAddresses[i].Split(':');
            mac = "";
            for (int j = 0; j < bas.Length; j++)
            {
              int b1 = Convert.ToInt32(bas[j], 16);
              int b2 = Convert.ToInt32(address[j], 16);

              int b = (b1 + b2) % 256;

              mac += System.Convert.ToString(b, 16).PadLeft(2, '0') + ":";
            }
            mac = mac.TrimEnd(':');
          }
        }

        mac = mac.ToUpper();

        return mac += ":" + selectedAddresses.Count.ToString().PadLeft(2, '0');
      }
      else
      {
        return "";
      }

    }

    #endregion

    #region User and Computer Information

    public static string GetCurrentUser()
    {
      return WindowsIdentity.GetCurrent().Name;
    }

    public static string GetComputerName()
    {
      return SystemInformation.ComputerName;
    }

    #endregion

    #region Certificate

    private Cube certificate;
    public Cube Certificate
    {
      get
      {
        if (certificate == null)
          certificate = GetCertificate();

        if (certificate != null)
          return certificate;
        else
          return Cube.GetDefaultLongCube();
      }
      set { certificate = value; }
    }

    public Cube GetCertificate()
    {
      this.Certificate = LoadObjectDef<Cube>("Certificate");
      return this.Certificate;
    }

    public void InstallCertificate(Cube certificate,string organization)
    {
      this.certificate = null;
      SaveObjectDef(certificate, "Certificate");
      SaveValue(organization, "Organização");
      this.Certificate = certificate;
    }

    public void UnInstallCertificate()
    {
      Cube cube = Cube.GetDefaultLongCube();
      string rndKey = cube.GetRandomText(37);
      cube = new Cube(rndKey);
      this.certificate = cube;
      SaveObjectDef(cube, "Certificate");
    }

    #endregion

    #region Token

    public string GetToken()
    {
      DateTime date = DateTime.Now;
      return GetToken(date);
    }

    public string GetToken(DateTime date)
    {

      int dd = date.Day;
      int mm = date.Month;
      int yy = Convert.ToInt32(date.Year.ToString().Substring(2));
      int hh = date.Hour;
      int nn = date.Minute;
      int ss = date.Second;

      string d = Certificate.IntToString(dd, 0);
      string m = Certificate.IntToString(mm, 0);
      string y = Certificate.IntToString(yy, 0);
      string h = Certificate.IntToString(hh, 0);
      string n = Certificate.IntToString(nn, 0);
      string s = Certificate.IntToString(ss, 0);

      string word = Certificate.GetWordAt(dd, mm, yy, hh, nn, ss, 6);

      string token = d + m + y + h + n + s + word;

      string checkSum = Certificate.ResizeKey(token, 1);
      token += checkSum;

      token = Certificate.RComp(token);

      return token;
    }

    public bool ValidateToken(string token)
    {
      token = Certificate.UnRComp(token);

      string checkSum = Convert.ToString(token[token.Length - 1]);
      token = token.Remove(token.Length - 1);

      string tokenCheck = Certificate.ResizeKey(token, 1);

      if (tokenCheck != checkSum)
        throw new Exception("Dígito de verificação inválido");

      int dd = Certificate.StringToInt(token[0].ToString(), 0);
      int mm = Certificate.StringToInt(token[1].ToString(), 0);
      int yy = Certificate.StringToInt(token[2].ToString(), 0);

      int hh = Certificate.StringToInt(token[3].ToString(), 0);
      int nn = Certificate.StringToInt(token[4].ToString(), 0);
      int ss = Certificate.StringToInt(token[5].ToString(), 0);

      int era = Convert.ToInt32(DateTime.Today.Year.ToString().Remove(2)) * 100;

      DateTime tokenDate = new DateTime(yy + era, mm, dd, hh, nn, ss);

      TimeSpan ts = DateTime.Now - tokenDate;

      if (ts.TotalHours > 3)
        throw new Exception("Token expirado");

      string tokenWord = token.Substring(6);
      string checkWord = Certificate.GetWordAt(dd, mm, yy, hh, nn, ss, 6);

      if (tokenWord != checkWord)
        throw new Exception("Senha inválida");

      return true;


    }

    #endregion

    #region Registry

    private string RegistryPath
    {
      get
      {
        string path = Registry.LocalMachine + "\\Software\\DataBridge";
        return path;
      }
    }

    private Cube shortCube;
    private Cube ShortCube
    {
      get
      {
        if (shortCube == null)
        {
          shortCube = Cube.GetDefaultShortCube();
        }
        return shortCube;
      }
    }

    private string RegPath1
    {
      get
      {
        string macAddress = GetMacAddress();
        return Registry.LocalMachine + "\\Software\\"+ShortCube.UnRComp(macAddress);
      }
    }

    private string RegPath2
    {
      get
      {
        string macAddress = GetMacAddress();

        return Registry.LocalMachine + "\\Software\\" + ShortCube.UnRComp(ShortCube.UnRComp(macAddress));
      }
    }

    public void SaveObject(object obj, string valueName)
    {
      Cube cert = Certificate;
      string enObj = cert.EncryptObject(obj, valueName);
      Registry.SetValue(RegistryPath, valueName, enObj);
      Registry.SetValue(RegPath1, valueName, enObj);
      Registry.SetValue(RegPath2, valueName, enObj);
    }

    public T LoadObject<T>(string valueName)
    {
      string enObj = Convert.ToString(Registry.GetValue(RegistryPath, valueName, ""));
      string enObj1 = Convert.ToString(Registry.GetValue(RegPath1, valueName, ""));
      string enObj2 = Convert.ToString(Registry.GetValue(RegPath2, valueName, ""));

      //if ((enObj != enObj1) || (enObj2 != enObj))
      //  throw new Exception("Falha na validação da licença");

      if (string.IsNullOrEmpty(enObj))
        return default(T);

      return Certificate.DecryptObject<T>(enObj, GetMacAddress());
    }

    public void SaveObjectDef(object obj, string valueName)
    {
      Cube cert = Cube.GetDefaultLongCube();
      string enObj = cert.EncryptObject(obj, valueName);
      Registry.SetValue(RegistryPath, valueName, enObj);
      Registry.SetValue(RegPath1, valueName, enObj);
      Registry.SetValue(RegPath2, valueName, enObj);
    }

    public T LoadObjectDef<T>(string valueName)
    {
      try
      {
        string enObj = Convert.ToString(Registry.GetValue(RegistryPath, valueName, ""));
        string enObj1 = Convert.ToString(Registry.GetValue(RegPath1, valueName, ""));
        string enObj2 = Convert.ToString(Registry.GetValue(RegPath2, valueName, ""));

        //if ((enObj != enObj1) || (enObj2 != enObj))
        //  throw new Exception("Falha na validação da licença");

        if (string.IsNullOrEmpty(enObj))
          return default(T);
        Cube cert = Cube.GetDefaultLongCube();
        return cert.DecryptObject<T>(enObj, valueName);
      }
      catch
      {
        throw new Exception("Falha verificação de dados. Licença inválida!");
      }
    }

    public void SaveEnveloped(object obj, string valueName)
    {
      string envelope = Certificate.EnvelopeObject(obj, GetMacAddress());
      Registry.SetValue(RegistryPath, valueName, envelope);
      Registry.SetValue(RegPath1, valueName, envelope);
      Registry.SetValue(RegPath2, valueName, envelope);
    }
    
    public T LoadEnvelope<T>(string valueName)
    {
      string enObj = Convert.ToString(Registry.GetValue(RegistryPath, valueName, ""));
      string enObj1 = Convert.ToString(Registry.GetValue(RegPath1, valueName, ""));
      string enObj2 = Convert.ToString(Registry.GetValue(RegPath2, valueName, ""));


      //if ((enObj != enObj1) || (enObj2 != enObj))
      //  throw new Exception("Falha na validação da licença");

      if (string.IsNullOrEmpty(enObj))
        return default(T);

      return Certificate.UnEnvelopeObject<T>(enObj, GetMacAddress());
    }

    public void SaveValue(string value, string valueName)
    {
      string enStr = Certificate.CloseWithKey(value, GetMacAddress());
      Registry.SetValue(RegistryPath, valueName, enStr);
      Registry.SetValue(RegPath1, valueName, enStr);
      Registry.SetValue(RegPath2, valueName, enStr);
    }

    public string LoadValue(string valueName)
    {
      string enObj = Convert.ToString(Registry.GetValue(RegistryPath, valueName, ""));
      string enObj1 = Convert.ToString(Registry.GetValue(RegPath1, valueName, ""));
      string enObj2 = Convert.ToString(Registry.GetValue(RegPath2, valueName, ""));


      //if ((enObj != enObj1) || (enObj2 != enObj))
      //  throw new Exception("Falha na validação da licença");

      if (string.IsNullOrEmpty(enObj))
        return enObj;

      string str = Certificate.OpenWithKey(enObj, GetMacAddress());

      if (!string.IsNullOrEmpty(enObj) && string.IsNullOrEmpty(str))
        throw new Exception("Falha verificação de dados. Licença inválida!");

      return str;
    }

    public List<string> LoadRegisteredPlugins()
    {
      List<string> list = new List<string>();

      string regPlugins = LoadValue("Plugins");
      if (!string.IsNullOrEmpty(regPlugins))
      {
        string[] plugList = regPlugins.Split(';');

        foreach (string plugin in plugList)
        {
          if (plugin.EndsWith(".dll") && (plugin[1] == '|'))
            list.Add(plugin);
          else
            throw new Exception("Falha na carga dos plugins. Licença inválida!");
        }

      }

      return list;
    }

    #endregion


  }
}
