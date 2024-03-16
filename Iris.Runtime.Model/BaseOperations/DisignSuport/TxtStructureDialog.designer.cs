namespace Iris.Runtime.Model.DesignuSuport
{
  /// <summary>
  /// Diálogo de edição de propriedades para edição de estrutura de arquivos txt
  /// </summary>
  partial class TxtStructureDialog
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TxtStructureDialog));
      this.prgProperties = new System.Windows.Forms.PropertyGrid();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.grpStruct = new System.Windows.Forms.GroupBox();
      this.tvStructure = new System.Windows.Forms.TreeView();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnSort = new System.Windows.Forms.Button();
      this.btnImport = new System.Windows.Forms.Button();
      this.imlCommands = new System.Windows.Forms.ImageList(this.components);
      this.btnRemoveMaster = new System.Windows.Forms.Button();
      this.btnMoveDown = new System.Windows.Forms.Button();
      this.btnMoveUp = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnExcluir = new System.Windows.Forms.Button();
      this.btnCreate = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.splitter2 = new System.Windows.Forms.Splitter();
      this.gbxFields = new System.Windows.Forms.GroupBox();
      this.lbxFields = new System.Windows.Forms.ListBox();
      this.panel4 = new System.Windows.Forms.Panel();
      this.btnCloneField = new System.Windows.Forms.Button();
      this.btnFromModel = new System.Windows.Forms.Button();
      this.btnMoveFieldDown = new System.Windows.Forms.Button();
      this.btnMoveFieldUp = new System.Windows.Forms.Button();
      this.btnClearFields = new System.Windows.Forms.Button();
      this.btnDeleteField = new System.Windows.Forms.Button();
      this.btnNewField = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.panel1.SuspendLayout();
      this.grpStruct.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.gbxFields.SuspendLayout();
      this.panel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Location = new System.Drawing.Point(0, 476);
      this.panel1.Size = new System.Drawing.Size(350, 30);
      // 
      // prgProperties
      // 
      this.prgProperties.Dock = System.Windows.Forms.DockStyle.Right;
      this.prgProperties.Location = new System.Drawing.Point(353, 0);
      this.prgProperties.Name = "prgProperties";
      this.prgProperties.Size = new System.Drawing.Size(293, 506);
      this.prgProperties.TabIndex = 8;
      this.prgProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.prgProperties_PropertyValueChanged);
      // 
      // splitter1
      // 
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
      this.splitter1.Location = new System.Drawing.Point(350, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(3, 506);
      this.splitter1.TabIndex = 9;
      this.splitter1.TabStop = false;
      // 
      // grpStruct
      // 
      this.grpStruct.Controls.Add(this.tvStructure);
      this.grpStruct.Controls.Add(this.panel2);
      this.grpStruct.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grpStruct.Location = new System.Drawing.Point(0, 0);
      this.grpStruct.Name = "grpStruct";
      this.grpStruct.Size = new System.Drawing.Size(350, 251);
      this.grpStruct.TabIndex = 10;
      this.grpStruct.TabStop = false;
      this.grpStruct.Text = "Tipos de Linha";
      // 
      // tvStructure
      // 
      this.tvStructure.AllowDrop = true;
      this.tvStructure.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvStructure.Location = new System.Drawing.Point(3, 16);
      this.tvStructure.Name = "tvStructure";
      this.tvStructure.Size = new System.Drawing.Size(285, 232);
      this.tvStructure.TabIndex = 6;
      this.tvStructure.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvStructure_ItemDrag);
      this.tvStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStructure_AfterSelect);
      this.tvStructure.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvStructure_DragDrop);
      this.tvStructure.DragOver += new System.Windows.Forms.DragEventHandler(this.tvStructure_DragOver);
      this.tvStructure.Enter += new System.EventHandler(this.tvStructure_Enter);
      this.tvStructure.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvStructure_KeyUp);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnSort);
      this.panel2.Controls.Add(this.btnImport);
      this.panel2.Controls.Add(this.btnRemoveMaster);
      this.panel2.Controls.Add(this.btnMoveDown);
      this.panel2.Controls.Add(this.btnMoveUp);
      this.panel2.Controls.Add(this.btnClear);
      this.panel2.Controls.Add(this.btnExcluir);
      this.panel2.Controls.Add(this.btnCreate);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(288, 16);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(59, 232);
      this.panel2.TabIndex = 0;
      // 
      // btnSort
      // 
      this.btnSort.Location = new System.Drawing.Point(3, 204);
      this.btnSort.Name = "btnSort";
      this.btnSort.Size = new System.Drawing.Size(53, 23);
      this.btnSort.TabIndex = 7;
      this.btnSort.Text = "Sort";
      this.btnSort.UseVisualStyleBackColor = true;
      this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
      // 
      // btnImport
      // 
      this.btnImport.ImageList = this.imlCommands;
      this.btnImport.Location = new System.Drawing.Point(3, 90);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new System.Drawing.Size(53, 23);
      this.btnImport.TabIndex = 6;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
      // btnRemoveMaster
      // 
      this.btnRemoveMaster.ImageKey = "BuilderDialog_RemoveAll.bmp";
      this.btnRemoveMaster.ImageList = this.imlCommands;
      this.btnRemoveMaster.Location = new System.Drawing.Point(3, 175);
      this.btnRemoveMaster.Name = "btnRemoveMaster";
      this.btnRemoveMaster.Size = new System.Drawing.Size(53, 23);
      this.btnRemoveMaster.TabIndex = 5;
      this.btnRemoveMaster.UseVisualStyleBackColor = true;
      this.btnRemoveMaster.Click += new System.EventHandler(this.btnRemoveMaster_Click);
      // 
      // btnMoveDown
      // 
      this.btnMoveDown.ImageKey = "BuilderDialog_movedown.bmp";
      this.btnMoveDown.ImageList = this.imlCommands;
      this.btnMoveDown.Location = new System.Drawing.Point(3, 146);
      this.btnMoveDown.Name = "btnMoveDown";
      this.btnMoveDown.Size = new System.Drawing.Size(53, 23);
      this.btnMoveDown.TabIndex = 4;
      this.btnMoveDown.UseVisualStyleBackColor = true;
      this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
      // 
      // btnMoveUp
      // 
      this.btnMoveUp.ImageIndex = 5;
      this.btnMoveUp.ImageList = this.imlCommands;
      this.btnMoveUp.Location = new System.Drawing.Point(3, 117);
      this.btnMoveUp.Name = "btnMoveUp";
      this.btnMoveUp.Size = new System.Drawing.Size(53, 23);
      this.btnMoveUp.TabIndex = 3;
      this.btnMoveUp.UseVisualStyleBackColor = true;
      this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
      // 
      // btnClear
      // 
      this.btnClear.ImageList = this.imlCommands;
      this.btnClear.Location = new System.Drawing.Point(3, 61);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(53, 23);
      this.btnClear.TabIndex = 2;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnExcluir
      // 
      this.btnExcluir.ImageIndex = 3;
      this.btnExcluir.ImageList = this.imlCommands;
      this.btnExcluir.Location = new System.Drawing.Point(3, 32);
      this.btnExcluir.Name = "btnExcluir";
      this.btnExcluir.Size = new System.Drawing.Size(53, 23);
      this.btnExcluir.TabIndex = 1;
      this.btnExcluir.UseVisualStyleBackColor = true;
      this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
      // 
      // btnCreate
      // 
      this.btnCreate.ImageIndex = 7;
      this.btnCreate.ImageList = this.imlCommands;
      this.btnCreate.Location = new System.Drawing.Point(3, 3);
      this.btnCreate.Name = "btnCreate";
      this.btnCreate.Size = new System.Drawing.Size(53, 23);
      this.btnCreate.TabIndex = 0;
      this.btnCreate.UseVisualStyleBackColor = true;
      this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.splitter2);
      this.panel3.Controls.Add(this.grpStruct);
      this.panel3.Controls.Add(this.gbxFields);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(350, 476);
      this.panel3.TabIndex = 11;
      // 
      // splitter2
      // 
      this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter2.Location = new System.Drawing.Point(0, 248);
      this.splitter2.Name = "splitter2";
      this.splitter2.Size = new System.Drawing.Size(350, 3);
      this.splitter2.TabIndex = 12;
      this.splitter2.TabStop = false;
      // 
      // gbxFields
      // 
      this.gbxFields.Controls.Add(this.lbxFields);
      this.gbxFields.Controls.Add(this.panel4);
      this.gbxFields.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.gbxFields.Location = new System.Drawing.Point(0, 251);
      this.gbxFields.Name = "gbxFields";
      this.gbxFields.Size = new System.Drawing.Size(350, 225);
      this.gbxFields.TabIndex = 11;
      this.gbxFields.TabStop = false;
      this.gbxFields.Text = "Campos";
      // 
      // lbxFields
      // 
      this.lbxFields.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbxFields.FormattingEnabled = true;
      this.lbxFields.Location = new System.Drawing.Point(3, 16);
      this.lbxFields.Name = "lbxFields";
      this.lbxFields.Size = new System.Drawing.Size(285, 206);
      this.lbxFields.TabIndex = 0;
      this.lbxFields.SelectedIndexChanged += new System.EventHandler(this.lbxFields_SelectedIndexChanged);
      this.lbxFields.Enter += new System.EventHandler(this.lbxFields_Enter);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.btnCloneField);
      this.panel4.Controls.Add(this.btnFromModel);
      this.panel4.Controls.Add(this.btnMoveFieldDown);
      this.panel4.Controls.Add(this.btnMoveFieldUp);
      this.panel4.Controls.Add(this.btnClearFields);
      this.panel4.Controls.Add(this.btnDeleteField);
      this.panel4.Controls.Add(this.btnNewField);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel4.Location = new System.Drawing.Point(288, 16);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(59, 206);
      this.panel4.TabIndex = 1;
      // 
      // btnCloneField
      // 
      this.btnCloneField.ImageList = this.imlCommands;
      this.btnCloneField.Location = new System.Drawing.Point(3, 32);
      this.btnCloneField.Name = "btnCloneField";
      this.btnCloneField.Size = new System.Drawing.Size(53, 23);
      this.btnCloneField.TabIndex = 5;
      this.btnCloneField.Text = "Clone";
      this.btnCloneField.UseVisualStyleBackColor = true;
      this.btnCloneField.Click += new System.EventHandler(this.btnCloneField_Click);
      // 
      // btnFromModel
      // 
      this.btnFromModel.Location = new System.Drawing.Point(3, 177);
      this.btnFromModel.Name = "btnFromModel";
      this.btnFromModel.Size = new System.Drawing.Size(53, 23);
      this.btnFromModel.TabIndex = 6;
      this.btnFromModel.Text = "Import";
      this.btnFromModel.UseVisualStyleBackColor = true;
      this.btnFromModel.Click += new System.EventHandler(this.btnFromModel_Click);
      // 
      // btnMoveFieldDown
      // 
      this.btnMoveFieldDown.ImageIndex = 4;
      this.btnMoveFieldDown.ImageList = this.imlCommands;
      this.btnMoveFieldDown.Location = new System.Drawing.Point(3, 148);
      this.btnMoveFieldDown.Name = "btnMoveFieldDown";
      this.btnMoveFieldDown.Size = new System.Drawing.Size(53, 23);
      this.btnMoveFieldDown.TabIndex = 4;
      this.btnMoveFieldDown.UseVisualStyleBackColor = true;
      this.btnMoveFieldDown.Click += new System.EventHandler(this.btnMoveFieldDown_Click);
      // 
      // btnMoveFieldUp
      // 
      this.btnMoveFieldUp.ImageIndex = 5;
      this.btnMoveFieldUp.ImageList = this.imlCommands;
      this.btnMoveFieldUp.Location = new System.Drawing.Point(3, 119);
      this.btnMoveFieldUp.Name = "btnMoveFieldUp";
      this.btnMoveFieldUp.Size = new System.Drawing.Size(53, 23);
      this.btnMoveFieldUp.TabIndex = 3;
      this.btnMoveFieldUp.UseVisualStyleBackColor = true;
      this.btnMoveFieldUp.Click += new System.EventHandler(this.btnMoveFieldUp_Click);
      // 
      // btnClearFields
      // 
      this.btnClearFields.ImageList = this.imlCommands;
      this.btnClearFields.Location = new System.Drawing.Point(3, 90);
      this.btnClearFields.Name = "btnClearFields";
      this.btnClearFields.Size = new System.Drawing.Size(53, 23);
      this.btnClearFields.TabIndex = 2;
      this.btnClearFields.Text = "Clear";
      this.btnClearFields.UseVisualStyleBackColor = true;
      this.btnClearFields.Click += new System.EventHandler(this.btnClearFields_Click);
      // 
      // btnDeleteField
      // 
      this.btnDeleteField.ImageIndex = 3;
      this.btnDeleteField.ImageList = this.imlCommands;
      this.btnDeleteField.Location = new System.Drawing.Point(3, 61);
      this.btnDeleteField.Name = "btnDeleteField";
      this.btnDeleteField.Size = new System.Drawing.Size(53, 23);
      this.btnDeleteField.TabIndex = 1;
      this.btnDeleteField.UseVisualStyleBackColor = true;
      this.btnDeleteField.Click += new System.EventHandler(this.btnDeleteField_Click);
      // 
      // btnNewField
      // 
      this.btnNewField.ImageIndex = 7;
      this.btnNewField.ImageList = this.imlCommands;
      this.btnNewField.Location = new System.Drawing.Point(3, 3);
      this.btnNewField.Name = "btnNewField";
      this.btnNewField.Size = new System.Drawing.Size(53, 23);
      this.btnNewField.TabIndex = 0;
      this.btnNewField.UseVisualStyleBackColor = true;
      this.btnNewField.Click += new System.EventHandler(this.btnNewField_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.Title = "Importar campos do modelo";
      // 
      // TxtStructureDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(646, 506);
      this.ControlBox = true;
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.prgProperties);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.KeyPreview = true;
      this.Name = "TxtStructureDialog";
      this.Text = "Estrutura do Arquivo";
      this.Shown += new System.EventHandler(this.TxtStructureDialog_Shown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtStructureDialog_KeyUp);
      this.Controls.SetChildIndex(this.prgProperties, 0);
      this.Controls.SetChildIndex(this.splitter1, 0);
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.panel3, 0);
      this.panel1.ResumeLayout(false);
      this.grpStruct.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.gbxFields.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PropertyGrid prgProperties;
    private System.Windows.Forms.Splitter splitter1;
    private System.Windows.Forms.GroupBox grpStruct;
    private System.Windows.Forms.TreeView tvStructure;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnMoveDown;
    private System.Windows.Forms.Button btnMoveUp;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnExcluir;
    private System.Windows.Forms.Button btnCreate;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Splitter splitter2;
    private System.Windows.Forms.GroupBox gbxFields;
    private System.Windows.Forms.ListBox lbxFields;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Button btnMoveFieldDown;
    private System.Windows.Forms.Button btnMoveFieldUp;
    private System.Windows.Forms.Button btnClearFields;
    private System.Windows.Forms.Button btnDeleteField;
    private System.Windows.Forms.Button btnNewField;
    private System.Windows.Forms.ImageList imlCommands;
    private System.Windows.Forms.Button btnRemoveMaster;
    private System.Windows.Forms.Button btnCloneField;
    private System.Windows.Forms.Button btnImport;
    private System.Windows.Forms.Button btnSort;
    private System.Windows.Forms.Button btnFromModel;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
  }
}