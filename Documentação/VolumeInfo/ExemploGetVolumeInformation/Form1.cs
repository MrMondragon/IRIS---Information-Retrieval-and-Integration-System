using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using RM.Lib;

namespace ExemploGetVolumeInformation
{
  public partial class Form1 : Form
  {
    [DllImport("kernel32.dll")]
    private static extern long GetVolumeInformationA(string lpRootPathName, StringBuilder lpVolumeNameBuffer, uint nVolumeNameSize, ref uint lpVolumeSerialNumber, ref uint lpMaximumComponentLength, ref uint lpFileSystemFlags, StringBuilder lpFileSystemNameBuffer, uint nFileSystemNameSize);

    public struct VolumeInformation
    {
      public char DriveLetter;
      public string Label;
      public UInt32 SerialNumber;
      public string HexSerialNumber;
      public string FileSystemName;
    }

    public Form1()
    {
      InitializeComponent();

      foreach (string drive in Environment.GetLogicalDrives())
        drives.Items.Add(drive);
    }

    private VolumeInformation GetVolumeInformation(char driveLetter)
    {
      // Retorno da função
      VolumeInformation volInf = new VolumeInformation();

      // Variáveis auxiliares
      string lpRootPathName = driveLetter.ToString() + ":\\";
      uint lpMaximumComponentLength = 0;
      uint volumeFlags = new UInt32();
      StringBuilder lpVolumeNameBuffer = new StringBuilder(256);
      StringBuilder lpFileSystemNameBuffer = new StringBuilder(256);

      // Recupera as configurações do drive
      long sucess = GetVolumeInformationA(lpRootPathName, lpVolumeNameBuffer, (uint)lpVolumeNameBuffer.Capacity, ref volInf.SerialNumber, ref lpMaximumComponentLength, ref volumeFlags, lpFileSystemNameBuffer, (uint)lpFileSystemNameBuffer.Capacity);

      if (sucess == 0)
        throw new Exception("Não foi possível recuperar as informações do drive " + driveLetter.ToString() + ":\\");
      else
      {
        // Preenche a estrutura de retorno
        volInf.DriveLetter = driveLetter;
        volInf.Label = lpVolumeNameBuffer.ToString();
        volInf.HexSerialNumber = String.Format("{0:X}", volInf.SerialNumber);
        volInf.FileSystemName = lpFileSystemNameBuffer.ToString();
      }

      return volInf;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (!String.IsNullOrEmpty(drives.Text))
      {
        log.Text = String.Empty;

        char drive = drives.Text[0];
        VolumeInformation volInf = this.GetVolumeInformation(drive);

        log.Text += "Letra do drive: " + volInf.DriveLetter.ToString() + Environment.NewLine;
        log.Text += "Nome do sistema de arquivos: " + volInf.FileSystemName.ToString() + Environment.NewLine;
        log.Text += "Número de séria (hexadecimal): " + volInf.HexSerialNumber.ToString() + Environment.NewLine;
        log.Text += "Número de série (inteiro): " + volInf.SerialNumber.ToString() + Environment.NewLine;
        log.Text += "Nome: " + volInf.Label.ToString() + Environment.NewLine;
      }
    }
  }
}