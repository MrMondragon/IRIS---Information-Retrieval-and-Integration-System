namespace Iris.Runtime.Core.Iris.ExpressionEditor
{
  partial class ExpressionEditorControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpressionEditorControl));
      this.imlTreeNodes = new System.Windows.Forms.ImageList(this.components);
      this.ppgExpressions = new System.Windows.Forms.PropertyGrid();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.rbNot = new System.Windows.Forms.RadioButton();
      this.rbOr = new System.Windows.Forms.RadioButton();
      this.rbAnd = new System.Windows.Forms.RadioButton();
      this.tvExpressions = new System.Windows.Forms.TreeView();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnText = new System.Windows.Forms.Button();
      this.imlCommands = new System.Windows.Forms.ImageList(this.components);
      this.btnTree = new System.Windows.Forms.Button();
      this.btnOutDent = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnIndent = new System.Windows.Forms.Button();
      this.btnMoveDown = new System.Windows.Forms.Button();
      this.btnMoveUp = new System.Windows.Forms.Button();
      this.btnNew = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.splitter2 = new System.Windows.Forms.Splitter();
      this.tbExpression = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // imlTreeNodes
      // 
      this.imlTreeNodes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTreeNodes.ImageStream")));
      this.imlTreeNodes.TransparentColor = System.Drawing.Color.Transparent;
      this.imlTreeNodes.Images.SetKeyName(0, "Blank.bmp");
      this.imlTreeNodes.Images.SetKeyName(1, "E.bmp");
      this.imlTreeNodes.Images.SetKeyName(2, "OU.bmp");
      this.imlTreeNodes.Images.SetKeyName(3, "NOT.bmp");
      // 
      // ppgExpressions
      // 
      this.ppgExpressions.Dock = System.Windows.Forms.DockStyle.Right;
      this.ppgExpressions.Location = new System.Drawing.Point(341, 0);
      this.ppgExpressions.Name = "ppgExpressions";
      this.ppgExpressions.Size = new System.Drawing.Size(187, 360);
      this.ppgExpressions.TabIndex = 2;
      this.ppgExpressions.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppgExpressions_PropertyValueChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Controls.Add(this.tvExpressions);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(341, 360);
      this.panel1.TabIndex = 4;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.rbNot);
      this.groupBox1.Controls.Add(this.rbOr);
      this.groupBox1.Controls.Add(this.rbAnd);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupBox1.Location = new System.Drawing.Point(0, 317);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(286, 43);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Tipo";
      // 
      // rbNot
      // 
      this.rbNot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.rbNot.AutoSize = true;
      this.rbNot.Location = new System.Drawing.Point(232, 18);
      this.rbNot.Name = "rbNot";
      this.rbNot.Size = new System.Drawing.Size(48, 17);
      this.rbNot.TabIndex = 2;
      this.rbNot.Text = "NÃO";
      this.rbNot.UseVisualStyleBackColor = true;
      this.rbNot.CheckedChanged += new System.EventHandler(this.rbNot_CheckedChanged);
      // 
      // rbOr
      // 
      this.rbOr.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.rbOr.AutoSize = true;
      this.rbOr.Location = new System.Drawing.Point(113, 18);
      this.rbOr.Name = "rbOr";
      this.rbOr.Size = new System.Drawing.Size(41, 17);
      this.rbOr.TabIndex = 1;
      this.rbOr.Text = "OU";
      this.rbOr.UseVisualStyleBackColor = true;
      this.rbOr.CheckedChanged += new System.EventHandler(this.rbOr_CheckedChanged);
      // 
      // rbAnd
      // 
      this.rbAnd.AutoSize = true;
      this.rbAnd.Location = new System.Drawing.Point(6, 18);
      this.rbAnd.Name = "rbAnd";
      this.rbAnd.Size = new System.Drawing.Size(32, 17);
      this.rbAnd.TabIndex = 0;
      this.rbAnd.Text = "E";
      this.rbAnd.UseVisualStyleBackColor = true;
      this.rbAnd.CheckedChanged += new System.EventHandler(this.rbAnd_CheckedChanged);
      // 
      // tvExpressions
      // 
      this.tvExpressions.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvExpressions.ImageIndex = 1;
      this.tvExpressions.ImageList = this.imlTreeNodes;
      this.tvExpressions.Location = new System.Drawing.Point(0, 0);
      this.tvExpressions.Name = "tvExpressions";
      this.tvExpressions.SelectedImageIndex = 0;
      this.tvExpressions.Size = new System.Drawing.Size(286, 360);
      this.tvExpressions.TabIndex = 7;
      this.tvExpressions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvExpressions_AfterSelect);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnClear);
      this.panel2.Controls.Add(this.btnText);
      this.panel2.Controls.Add(this.btnTree);
      this.panel2.Controls.Add(this.btnOutDent);
      this.panel2.Controls.Add(this.btnDelete);
      this.panel2.Controls.Add(this.btnIndent);
      this.panel2.Controls.Add(this.btnMoveDown);
      this.panel2.Controls.Add(this.btnMoveUp);
      this.panel2.Controls.Add(this.btnNew);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(286, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(55, 360);
      this.panel2.TabIndex = 6;
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(4, 245);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(43, 23);
      this.btnClear.TabIndex = 8;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnText
      // 
      this.btnText.ImageList = this.imlCommands;
      this.btnText.Location = new System.Drawing.Point(4, 216);
      this.btnText.Name = "btnText";
      this.btnText.Size = new System.Drawing.Size(43, 23);
      this.btnText.TabIndex = 7;
      this.btnText.Text = "Text";
      this.btnText.UseVisualStyleBackColor = true;
      this.btnText.Click += new System.EventHandler(this.btnText_Click);
      // 
      // imlCommands
      // 
      this.imlCommands.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCommands.ImageStream")));
      this.imlCommands.TransparentColor = System.Drawing.Color.Fuchsia;
      this.imlCommands.Images.SetKeyName(0, "BuilderDialog_RemoveAll.bmp");
      this.imlCommands.Images.SetKeyName(1, "BuilderDialog_add.bmp");
      this.imlCommands.Images.SetKeyName(2, "BuilderDialog_AddAll.bmp");
      this.imlCommands.Images.SetKeyName(3, "BuilderDialog_delete.bmp");
      this.imlCommands.Images.SetKeyName(4, "BuilderDialog_movedown.bmp");
      this.imlCommands.Images.SetKeyName(5, "BuilderDialog_moveup.bmp");
      this.imlCommands.Images.SetKeyName(6, "BuilderDialog_remove.bmp");
      this.imlCommands.Images.SetKeyName(7, "New.bmp");
      // 
      // btnTree
      // 
      this.btnTree.ImageList = this.imlCommands;
      this.btnTree.Location = new System.Drawing.Point(4, 187);
      this.btnTree.Name = "btnTree";
      this.btnTree.Size = new System.Drawing.Size(43, 23);
      this.btnTree.TabIndex = 6;
      this.btnTree.Text = "Tree";
      this.btnTree.UseVisualStyleBackColor = true;
      this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
      // 
      // btnOutDent
      // 
      this.btnOutDent.ImageIndex = 0;
      this.btnOutDent.ImageList = this.imlCommands;
      this.btnOutDent.Location = new System.Drawing.Point(4, 129);
      this.btnOutDent.Name = "btnOutDent";
      this.btnOutDent.Size = new System.Drawing.Size(43, 23);
      this.btnOutDent.TabIndex = 5;
      this.btnOutDent.UseVisualStyleBackColor = true;
      this.btnOutDent.Click += new System.EventHandler(this.btnOutDent_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.ImageIndex = 3;
      this.btnDelete.ImageList = this.imlCommands;
      this.btnDelete.Location = new System.Drawing.Point(4, 158);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(43, 23);
      this.btnDelete.TabIndex = 4;
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnIndent
      // 
      this.btnIndent.ImageIndex = 2;
      this.btnIndent.ImageList = this.imlCommands;
      this.btnIndent.Location = new System.Drawing.Point(4, 100);
      this.btnIndent.Name = "btnIndent";
      this.btnIndent.Size = new System.Drawing.Size(43, 23);
      this.btnIndent.TabIndex = 3;
      this.btnIndent.UseVisualStyleBackColor = true;
      this.btnIndent.Click += new System.EventHandler(this.btnIndent_Click);
      // 
      // btnMoveDown
      // 
      this.btnMoveDown.ImageIndex = 4;
      this.btnMoveDown.ImageList = this.imlCommands;
      this.btnMoveDown.Location = new System.Drawing.Point(4, 71);
      this.btnMoveDown.Name = "btnMoveDown";
      this.btnMoveDown.Size = new System.Drawing.Size(43, 23);
      this.btnMoveDown.TabIndex = 2;
      this.btnMoveDown.UseVisualStyleBackColor = true;
      this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
      // 
      // btnMoveUp
      // 
      this.btnMoveUp.ImageIndex = 5;
      this.btnMoveUp.ImageList = this.imlCommands;
      this.btnMoveUp.Location = new System.Drawing.Point(4, 42);
      this.btnMoveUp.Name = "btnMoveUp";
      this.btnMoveUp.Size = new System.Drawing.Size(43, 23);
      this.btnMoveUp.TabIndex = 1;
      this.btnMoveUp.UseVisualStyleBackColor = true;
      this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
      // 
      // btnNew
      // 
      this.btnNew.ImageIndex = 7;
      this.btnNew.ImageList = this.imlCommands;
      this.btnNew.Location = new System.Drawing.Point(4, 13);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(43, 23);
      this.btnNew.TabIndex = 0;
      this.btnNew.UseVisualStyleBackColor = true;
      this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.splitter1);
      this.panel3.Controls.Add(this.panel1);
      this.panel3.Controls.Add(this.ppgExpressions);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(528, 360);
      this.panel3.TabIndex = 5;
      // 
      // splitter1
      // 
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
      this.splitter1.Location = new System.Drawing.Point(338, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(3, 360);
      this.splitter1.TabIndex = 5;
      this.splitter1.TabStop = false;
      // 
      // splitter2
      // 
      this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter2.Location = new System.Drawing.Point(0, 360);
      this.splitter2.Name = "splitter2";
      this.splitter2.Size = new System.Drawing.Size(528, 3);
      this.splitter2.TabIndex = 7;
      this.splitter2.TabStop = false;
      // 
      // tbExpression
      // 
      this.tbExpression.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.tbExpression.Location = new System.Drawing.Point(0, 363);
      this.tbExpression.Multiline = true;
      this.tbExpression.Name = "tbExpression";
      this.tbExpression.Size = new System.Drawing.Size(528, 95);
      this.tbExpression.TabIndex = 9;
      this.tbExpression.Validated += new System.EventHandler(this.tbExpression_Validated);
      // 
      // ExpressionEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.splitter2);
      this.Controls.Add(this.tbExpression);
      this.Name = "ExpressionEditorControl";
      this.Size = new System.Drawing.Size(528, 458);
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PropertyGrid ppgExpressions;
    private System.Windows.Forms.ImageList imlTreeNodes;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TreeView tvExpressions;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.ImageList imlCommands;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnIndent;
    private System.Windows.Forms.Button btnMoveDown;
    private System.Windows.Forms.Button btnMoveUp;
    private System.Windows.Forms.Button btnOutDent;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btnText;
    private System.Windows.Forms.Button btnTree;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.Splitter splitter2;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton rbNot;
    private System.Windows.Forms.RadioButton rbOr;
    private System.Windows.Forms.RadioButton rbAnd;
    private System.Windows.Forms.TextBox tbExpression;


  }
}
