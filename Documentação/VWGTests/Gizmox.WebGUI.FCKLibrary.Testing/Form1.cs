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

namespace Gizmox.WebGUI.FCKLibrary.Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.fckEditor1.Value = "This is a sample text...";
            //this.fckEditor1.SkinPath = "/FCKEditor/editor/skins/silver/";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.fckEditor1.Value);
        }
    }
}