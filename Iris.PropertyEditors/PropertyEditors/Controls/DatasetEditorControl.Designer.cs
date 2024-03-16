namespace Iris.PropertyEditors.PropertyEditors.Controls
{
  partial class DatasetEditorControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatasetEditorControl));
      this.surface = new MindFusion.Diagramming.WinForms.FlowChart();
      this.SuspendLayout();
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
      this.surface.BackBrush = new MindFusion.Drawing.SolidBrush("#FFFFFFFF");
      this.surface.Behavior = MindFusion.Diagramming.WinForms.BehaviorType.Modify;
      this.surface.CellFrameStyle = MindFusion.Diagramming.WinForms.CellFrameStyle.Simple;
      this.surface.DocExtents = ((System.Drawing.RectangleF)(resources.GetObject("surface.DocExtents")));
      this.surface.Dock = System.Windows.Forms.DockStyle.Fill;
      this.surface.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.surface.GridSizeX = 8F;
      this.surface.GridSizeY = 8F;
      this.surface.GridStyle = MindFusion.Diagramming.WinForms.GridStyle.Lines;
      this.surface.InplaceEditFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.surface.Location = new System.Drawing.Point(0, 0);
      this.surface.MeasureUnit = System.Drawing.GraphicsUnit.Pixel;
      this.surface.Name = "surface";
      this.surface.RoutingOptions.GridSize = 16F;
      this.surface.RoutingOptions.NodeVicinitySize = 48F;
      this.surface.SelHandleSize = 6F;
      this.surface.ShadowColor = System.Drawing.SystemColors.ControlDarkDark;
      this.surface.Size = new System.Drawing.Size(564, 336);
      this.surface.SnapToAnchor = MindFusion.Diagramming.WinForms.SnapToAnchor.OnCreateOrModify;
      this.surface.TabIndex = 3;
      this.surface.TableCaptionHeight = 20F;
      this.surface.TableColWidth = 150F;
      this.surface.TableHandlesStyle = MindFusion.Diagramming.WinForms.HandlesStyle.SquareHandles2;
      this.surface.TableRowCount = 0;
      this.surface.TableRowHeight = 18F;
      this.surface.TablesScrollable = true;
      // 
      // DatasetEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.surface);
      this.Name = "DatasetEditorControl";
      this.Size = new System.Drawing.Size(564, 336);
      this.ResumeLayout(false);

    }

    #endregion

    private MindFusion.Diagramming.WinForms.FlowChart surface;
  }
}
