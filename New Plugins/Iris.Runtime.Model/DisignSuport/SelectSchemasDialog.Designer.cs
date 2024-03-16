namespace Iris.Designer.Dialogs
{
  partial class SelectSchemasDialog
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
      this.tvwSchemas = new System.Windows.Forms.TreeView();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnInvert = new System.Windows.Forms.Button();
      this.btnNenhum = new System.Windows.Forms.Button();
      this.btnTodos = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 238);
      this.panel1.Size = new System.Drawing.Size(296, 30);
      // 
      // tvwSchemas
      // 
      this.tvwSchemas.CheckBoxes = true;
      this.tvwSchemas.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvwSchemas.Location = new System.Drawing.Point(0, 35);
      this.tvwSchemas.Name = "tvwSchemas";
      this.tvwSchemas.Size = new System.Drawing.Size(296, 203);
      this.tvwSchemas.TabIndex = 2;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnInvert);
      this.panel2.Controls.Add(this.btnNenhum);
      this.panel2.Controls.Add(this.btnTodos);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(296, 35);
      this.panel2.TabIndex = 3;
      // 
      // btnInvert
      // 
      this.btnInvert.Location = new System.Drawing.Point(208, 6);
      this.btnInvert.Name = "btnInvert";
      this.btnInvert.Size = new System.Drawing.Size(75, 23);
      this.btnInvert.TabIndex = 5;
      this.btnInvert.Text = "Inverter";
      this.btnInvert.UseVisualStyleBackColor = true;
      this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
      // 
      // btnNenhum
      // 
      this.btnNenhum.Location = new System.Drawing.Point(102, 6);
      this.btnNenhum.Name = "btnNenhum";
      this.btnNenhum.Size = new System.Drawing.Size(100, 23);
      this.btnNenhum.TabIndex = 4;
      this.btnNenhum.Text = "Desmarcar Todos";
      this.btnNenhum.UseVisualStyleBackColor = true;
      this.btnNenhum.Click += new System.EventHandler(this.btnNenhum_Click);
      // 
      // btnTodos
      // 
      this.btnTodos.Location = new System.Drawing.Point(12, 6);
      this.btnTodos.Name = "btnTodos";
      this.btnTodos.Size = new System.Drawing.Size(84, 23);
      this.btnTodos.TabIndex = 3;
      this.btnTodos.Text = "Marcar Todos";
      this.btnTodos.UseVisualStyleBackColor = true;
      this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
      // 
      // SelectSchemasDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(296, 268);
      this.Controls.Add(this.tvwSchemas);
      this.Controls.Add(this.panel2);
      this.Name = "SelectSchemasDialog";
      this.Text = "SelectSchemasDialog";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.panel2, 0);
      this.Controls.SetChildIndex(this.tvwSchemas, 0);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView tvwSchemas;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnInvert;
    private System.Windows.Forms.Button btnNenhum;
    private System.Windows.Forms.Button btnTodos;


  }
}