namespace Gizmox.WebGUI.FCKLibrary.Testing
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
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.fckEditor1 = new Gizmox.WebGUI.FCKLibrary.FCKEditor();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.button1.ClientSize = new System.Drawing.Size(97, 23);
            this.button1.Location = new System.Drawing.Point(27, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show Value";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fckEditor1
            // 
            this.fckEditor1.BackColor = System.Drawing.Color.White;
            this.fckEditor1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.fckEditor1.ClientSize = new System.Drawing.Size(670, 405);
            this.fckEditor1.Location = new System.Drawing.Point(24, 55);
            this.fckEditor1.Name = "fckEditor1";
            this.fckEditor1.Size = new System.Drawing.Size(670, 405);
            this.fckEditor1.TabIndex = 0;
            this.fckEditor1.Text = "fckEditor1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(706, 599);
            this.Controls.Add(this.fckEditor1);
            this.Controls.Add(this.button1);
            this.Size = new System.Drawing.Size(706, 599);
            this.Text = "FCKEditor Testing";
            this.ResumeLayout(false);

        }

        #endregion

        private FCKEditor fckEditor1;
        private Gizmox.WebGUI.Forms.Button button1;
    }
}