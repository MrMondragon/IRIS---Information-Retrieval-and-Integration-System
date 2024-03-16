namespace Iris.PropertyEditors.Dialogs
{
  partial class FieldMapEditorDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldMapEditorDialog));
      this.surface = new MindFusion.Diagramming.WinForms.FlowChart();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnAutoLink = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabMapping = new System.Windows.Forms.TabPage();
      this.tabText = new System.Windows.Forms.TabPage();
      this.txtText = new QWhale.Editor.SyntaxEdit(this.components);
      this.panel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabMapping.SuspendLayout();
      this.tabText.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnClear);
      this.panel1.Controls.Add(this.btnAutoLink);
      this.panel1.Location = new System.Drawing.Point(0, 459);
      this.panel1.Size = new System.Drawing.Size(784, 30);
      this.panel1.Controls.SetChildIndex(this.btnAutoLink, 0);
      this.panel1.Controls.SetChildIndex(this.btnClear, 0);
      this.panel1.Controls.SetChildIndex(this.btnCancel, 0);
      this.panel1.Controls.SetChildIndex(this.btnOk, 0);
      // 
      // surface
      // 
      this.surface.AllowRefLinks = false;
      this.surface.AntiAlias = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      this.surface.ArrowBase = MindFusion.Diagramming.WinForms.ArrowHead.RevTriangle;
      this.surface.ArrowBaseSize = 10F;
      this.surface.ArrowCascadeOrientation = MindFusion.Diagramming.WinForms.Orientation.Horizontal;
      this.surface.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.surface.ArrowEndsMovable = false;
      this.surface.ArrowHead = MindFusion.Diagramming.WinForms.ArrowHead.BowArrow;
      this.surface.ArrowHeadSize = 16F;
      this.surface.ArrowIntermSize = 16F;
      this.surface.ArrowSegments = ((short)(3));
      this.surface.ArrowStyle = MindFusion.Diagramming.WinForms.ArrowStyle.Cascading;
      this.surface.Behavior = MindFusion.Diagramming.WinForms.BehaviorType.CreateArrow;
      this.surface.CellFrameStyle = MindFusion.Diagramming.WinForms.CellFrameStyle.Simple;
      this.surface.DocExtents = ((System.Drawing.RectangleF)(resources.GetObject("surface.DocExtents")));
      this.surface.Dock = System.Windows.Forms.DockStyle.Fill;
      this.surface.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.surface.GridSizeX = 8F;
      this.surface.GridSizeY = 8F;
      this.surface.GridStyle = MindFusion.Diagramming.WinForms.GridStyle.Lines;
      this.surface.InplaceEditFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.surface.Location = new System.Drawing.Point(3, 3);
      this.surface.MeasureUnit = System.Drawing.GraphicsUnit.Pixel;
      this.surface.Name = "surface";
      this.surface.RoutingOptions.GridSize = 16F;
      this.surface.RoutingOptions.NodeVicinitySize = 48F;
      this.surface.SelHandleSize = 6F;
      this.surface.ShadowColor = System.Drawing.SystemColors.ControlDarkDark;
      this.surface.Size = new System.Drawing.Size(770, 427);
      this.surface.SnapToAnchor = MindFusion.Diagramming.WinForms.SnapToAnchor.OnCreateOrModify;
      this.surface.TabIndex = 2;
      this.surface.TableCaptionHeight = 20F;
      this.surface.TableColWidth = 150F;
      this.surface.TableHandlesStyle = MindFusion.Diagramming.WinForms.HandlesStyle.SquareHandles2;
      this.surface.TableRowCount = 0;
      this.surface.TableRowHeight = 18F;
      this.surface.TablesScrollable = true;
      this.surface.ArrowCreated += new MindFusion.Diagramming.WinForms.ArrowEvent(this.surface_ArrowCreated);
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.Location = new System.Drawing.Point(706, 4);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 23);
      this.btnClear.TabIndex = 2;
      this.btnClear.Text = "Limpar";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnAutoLink
      // 
      this.btnAutoLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAutoLink.Location = new System.Drawing.Point(604, 3);
      this.btnAutoLink.Name = "btnAutoLink";
      this.btnAutoLink.Size = new System.Drawing.Size(96, 23);
      this.btnAutoLink.TabIndex = 3;
      this.btnAutoLink.Text = "Corresp. Autom.";
      this.btnAutoLink.UseVisualStyleBackColor = true;
      this.btnAutoLink.Click += new System.EventHandler(this.btnAutoLink_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabMapping);
      this.tabControl1.Controls.Add(this.tabText);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(784, 459);
      this.tabControl1.TabIndex = 3;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // tabMapping
      // 
      this.tabMapping.Controls.Add(this.surface);
      this.tabMapping.Location = new System.Drawing.Point(4, 22);
      this.tabMapping.Name = "tabMapping";
      this.tabMapping.Padding = new System.Windows.Forms.Padding(3);
      this.tabMapping.Size = new System.Drawing.Size(776, 433);
      this.tabMapping.TabIndex = 0;
      this.tabMapping.Text = "Mapeamento";
      this.tabMapping.UseVisualStyleBackColor = true;
      // 
      // tabText
      // 
      this.tabText.Controls.Add(this.txtText);
      this.tabText.Location = new System.Drawing.Point(4, 22);
      this.tabText.Name = "tabText";
      this.tabText.Padding = new System.Windows.Forms.Padding(3);
      this.tabText.Size = new System.Drawing.Size(776, 463);
      this.tabText.TabIndex = 1;
      this.tabText.Text = "Texto";
      this.tabText.UseVisualStyleBackColor = true;
      // 
      // txtText
      // 
      this.txtText.BackColor = System.Drawing.SystemColors.Window;
      this.txtText.BorderStyle = QWhale.Common.EditBorderStyle.Fixed3D;
      this.txtText.Braces.BracesOptions = QWhale.Editor.BracesOptions.None;
      this.txtText.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtText.Font = new System.Drawing.Font("Courier New", 10F);
      this.txtText.Gutter.LineNumbersAlignment = System.Drawing.StringAlignment.Near;
      this.txtText.LineSeparator.Options = QWhale.Editor.SeparatorOptions.None;
      this.txtText.Location = new System.Drawing.Point(3, 3);
      this.txtText.Name = "txtText";
      this.txtText.Pages.PageType = QWhale.Editor.PageType.Normal;
      this.txtText.Pages.Rulers = QWhale.Editor.EditRulers.None;
      this.txtText.Pages.RulerUnits = QWhale.Editor.RulerUnits.Inches;
      this.txtText.Scroll.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
      this.txtText.Size = new System.Drawing.Size(770, 457);
      this.txtText.TabIndex = 1;
      this.txtText.Text = "";
      // 
      // FieldMapEditorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 489);
      this.ControlBox = true;
      this.Controls.Add(this.tabControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Name = "FieldMapEditorDialog";
      this.Text = "Correspondências";
      this.Controls.SetChildIndex(this.panel1, 0);
      this.Controls.SetChildIndex(this.tabControl1, 0);
      this.panel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabMapping.ResumeLayout(false);
      this.tabText.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private MindFusion.Diagramming.WinForms.FlowChart surface;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnAutoLink;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabMapping;
    private System.Windows.Forms.TabPage tabText;
    private QWhale.Editor.SyntaxEdit txtText;
  }
}