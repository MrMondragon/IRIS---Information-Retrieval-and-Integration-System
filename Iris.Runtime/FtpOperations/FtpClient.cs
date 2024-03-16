using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using Iris.Interfaces;
using System.Text.RegularExpressions;


namespace Iris.Runtime.Model.Operations.FtpOperations
{

  public class FtpClient
  {


    private IProccessLog log;

    public IProccessLog Log
    {
      get { return log; }
      set { log = value; }
    }

    private IOperation operation;

    public IOperation Operation
    {
      get { return operation; }
      set { operation = value; }
    }

    private string host = null;
    private string user = null;
    private string pass = null;
    private FtpWebRequest ftpRequest = null;
    private FtpWebResponse ftpResponse = null;
    private Stream ftpStream = null;
    private int bufferSize = 2048;

    /* Construct Object */
    public FtpClient(string hostIP, string userName, string password, IProccessLog log)
    {
      host = hostIP;
      user = userName;
      pass = password;
      this.log = log;
    }

    /* Download File */
    public void Download(string remoteFile, string localFile)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(remoteFile);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Get the FTP Server's Response Stream */
      ftpStream = ftpResponse.GetResponseStream();
      /* Open a File Stream to Write the Downloaded File */
      using (FileStream localFileStream = new FileStream(localFile, FileMode.Create))
      {
        /* Buffer for the Downloaded Data */
        byte[] byteBuffer = new byte[bufferSize];
        int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
        /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
        while (bytesRead > 0)
        {
          localFileStream.Write(byteBuffer, 0, bytesRead);
          bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
        }
        /* Resource Cleanup */
        ftpStream.Close();
        ftpResponse.Close();
        ftpRequest = null;
      }
    }

    /* Upload File */
    public void Upload(string remoteFile, string localFile)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(remoteFile);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
      /* Establish Return Communication with the FTP Server */
      ftpStream = ftpRequest.GetRequestStream();
      /* Open a File Stream to Read the File for Upload */
      using (FileStream localFileStream = new FileStream(localFile, FileMode.Open))
      {
        /* Buffer for the Downloaded Data */
        byte[] byteBuffer = new byte[bufferSize];
        int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
        /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
        while (bytesSent != 0)
        {
          ftpStream.Write(byteBuffer, 0, bytesSent);
          bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
        }
        /* Resource Cleanup */
        ftpStream.Close();
        ftpRequest = null;
      }
    }

    /* Delete File */
    public void Delete(string deleteFile)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(deleteFile);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Resource Cleanup */
      ftpResponse.Close();
      ftpRequest = null;
      return;
    }

    /* Delete File */
    public void RemoveDir(string delDir)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(delDir);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Resource Cleanup */
      ftpResponse.Close();
      ftpRequest = null;
      return;
    }


    /* Rename File */
    public void Rename(string currentFileNameAndPath, string newFileName)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(currentFileNameAndPath);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.Rename;
      /* Rename the File */
      ftpRequest.RenameTo = newFileName;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Resource Cleanup */
      ftpResponse.Close();
      ftpRequest = null;
      return;
    }

    /* Create a New Directory on the FTP Server */
    public void MakeDir(string newDirectory)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(newDirectory);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Resource Cleanup */
      ftpResponse.Close();
      ftpRequest = null;
      return;
    }

    /* Get the Date/Time a File was Created */
    public string getFileCreatedDateTime(string fileName)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(fileName);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Establish Return Communication with the FTP Server */
      ftpStream = ftpResponse.GetResponseStream();
      /* Get the FTP Server's Response Stream */
      StreamReader ftpReader = new StreamReader(ftpStream);
      /* Store the Raw Response */
      string fileInfo = null;
      /* Read the Full Response Stream */
      try { fileInfo = ftpReader.ReadToEnd(); }
      catch (Exception ex) { Console.WriteLine(ex.ToString()); }
      /* Resource Cleanup */
      ftpReader.Close();
      ftpStream.Close();
      ftpResponse.Close();
      ftpRequest = null;
      /* Return File Created Date Time */
      return fileInfo;
      /* Return an Empty string Array if an Exception Occurs */
    }

    /* Get the Size of a File */
    public string getFileSize(string fileName)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(fileName);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Establish Return Communication with the FTP Server */
      ftpStream = ftpResponse.GetResponseStream();
      /* Get the FTP Server's Response Stream */
      StreamReader ftpReader = new StreamReader(ftpStream);
      /* Store the Raw Response */
      string fileInfo = null;
      /* Read the Full Response Stream */
      try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }
      catch (Exception ex) { Console.WriteLine(ex.ToString()); }
      /* Resource Cleanup */
      ftpReader.Close();
      ftpStream.Close();
      ftpResponse.Close();
      ftpRequest = null;
      /* Return File Size */
      return fileInfo;
    }

    /* List Directory Contents File/Folder Name Only */
    public string[] DirectoryListSimple(string directory)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(directory);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Establish Return Communication with the FTP Server */
      ftpStream = ftpResponse.GetResponseStream();
      /* Get the FTP Server's Response Stream */
      StreamReader ftpReader = new StreamReader(ftpStream);
      /* Store the Raw Response */
      string directoryRaw = null;
      /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
      try
      {
        while (ftpReader.Peek() != -1)
        {
          directoryRaw += ftpReader.ReadLine() + "|";
        }
      }
      catch (Exception ex) { Console.WriteLine(ex.ToString()); }
      /* Resource Cleanup */
      ftpReader.Close();
      ftpStream.Close();
      ftpResponse.Close();
      ftpRequest = null;
      /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
      string[] directoryList = null;
      if (!string.IsNullOrEmpty(directoryRaw))
        directoryList = directoryRaw.Split("|".ToCharArray());

      return directoryList;
    }

    public bool DirectoryExists(string directory)
    {
      try
      {
        string[] entries;
        entries = DirectoryListSimple(directory);
        return true;
      }
      catch (Exception Ex)
      {
        if (Ex.Message.Contains("450"))
          return false;
        else
          throw Ex;
      }
    }

    /* List Directory Contents in Detail (Name, Size, Created, etc.) */
    private string[] DirectoryListDetailed(string directory)
    {
      /* Create an FTP Request */
      ftpRequest = CreateWebRequest(directory);
      /* Log in to the FTP Server with the User Name and Password Provided */
      ftpRequest.Credentials = new NetworkCredential(user, pass);
      /* When in doubt, use these options */
      ftpRequest.UseBinary = true;
      ftpRequest.UsePassive = true;
      ftpRequest.KeepAlive = true;
      /* Specify the Type of FTP Request */
      ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
      /* Establish Return Communication with the FTP Server */
      ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
      /* Establish Return Communication with the FTP Server */
      ftpStream = ftpResponse.GetResponseStream();
      /* Get the FTP Server's Response Stream */
      StreamReader ftpReader = new StreamReader(ftpStream);
      /* Store the Raw Response */
      string directoryRaw = null;
      /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
      try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
      catch (Exception ex) { Console.WriteLine(ex.ToString()); }
      /* Resource Cleanup */
      ftpReader.Close();
      ftpStream.Close();
      ftpResponse.Close();
      ftpRequest = null;
      /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
      string[] directoryList = directoryRaw.Split("|".ToCharArray());
      return directoryList;
    }

    private FtpWebRequest CreateWebRequest(string name)
    {
      ChangeDir(name);
      return (FtpWebRequest)FtpWebRequest.Create(host);
    }

    public void ChangeDir(string name)
    {
      if (!host.ToLower().StartsWith("ftp://"))
        host = "ftp://" + host;

      if (!host.EndsWith("/" + name))
        host = host + "/" + name;
    }

    internal string[] GetFileList(string Dir, string Mask)
    {
      IEnumerable<string> files = DirectoryListSimple(Dir).Select(x => x.Substring(x.LastIndexOf('/') + 1));


      string mask = "^" + Mask.Replace(".", @"\.") + "$";
      mask = mask.Replace('?', '.').Replace("*", ".*");
      files = files.Where(x => (!string.IsNullOrEmpty(x)) && (Regex.IsMatch(x, mask)));

      return files.ToArray();
    }
  }
}