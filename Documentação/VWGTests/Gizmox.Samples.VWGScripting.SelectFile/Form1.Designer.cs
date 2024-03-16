namespace VWGScripting
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.myScripts1 = new VWGScripting.MyScripts();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.button1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.button1.ClientSize = new System.Drawing.Size(75, 23);
            this.button1.Location = new System.Drawing.Point(72, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.textBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.textBox1.ClientSize = new System.Drawing.Size(319, 20);
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(72, 54);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = false;
            this.textBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(319, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.textBox1.Validator = null;
            this.textBox1.WordWrap = false;

            this.myScripts1.FileSelected += new System.EventHandler(myScripts1_FileSelected);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(515, 344);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.DockPadding.All = 0;
            this.DockPadding.Bottom = 0;
            this.DockPadding.Left = 0;
            this.DockPadding.Right = 0;
            this.DockPadding.Top = 0;
            this.Size = new System.Drawing.Size(515, 344);
            this.Text = "Form1";
            this.ResumeLayout(false);

        }



        #endregion

        private MyScripts myScripts1;
        private Gizmox.WebGUI.Forms.Button button1;
        private Gizmox.WebGUI.Forms.TextBox textBox1;
    }
}