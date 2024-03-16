using Iris.DMG.CyM.Social;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebTester
{
  public partial class Form1 : Form
  {
   
    public Form1()
    {
      InitializeComponent();

      IWebDriver driver = new ChromeDriver();
      driver.Url = "https://www.facebook.com";

      string html = driver.PageSource;

    }
  }
}

