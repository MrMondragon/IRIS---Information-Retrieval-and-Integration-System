using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Databridge.Engine.Criptography;

namespace CryptoTest
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      textBox1.Text = "Teste";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Cube cube = new Cube("base");
      textBox2.Text = cube.FRComp(textBox1.Text);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Cube cube = new Cube("base");

      List<string> list1 = new List<string>();
      List<string> list2 = new List<string>();

      for (int i = 0; i < 20000; i++)
      {
        string cryp = cube.FRComp(textBox1.Text);
        if (!list1.Contains(cryp))
          list1.Add(cryp);

        cryp = cube.RComp(textBox1.Text);

        if (!list2.Contains(cryp))
          list2.Add(cryp);
      }

      textBox2.Text = string.Format("{0} variações em 20000 iterações", list2.Count);
      textBox3.Text = string.Format("{0} variações em 20000 iterações", list1.Count);

    }
  }
}
