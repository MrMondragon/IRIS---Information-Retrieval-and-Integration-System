#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace VWGScripting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myScripts1.Register();
            myScripts1.SelectFile();
        }

        private void myScripts1_FileSelected(object sender, System.EventArgs e)
        {
            textBox1.Text = myScripts1.SelectedFile;
        }
    }
}