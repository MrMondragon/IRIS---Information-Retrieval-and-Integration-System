using System;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.Operations.Control;
using Iris.Runtime.Model.BaseObjects;
using System.Drawing;
using Iris.Designer.Properties;
using System.Resources;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Reflection;
using Iris.Runtime.Model.Entities;
using MindFusion.Diagramming.WinForms;
using Iris.Runtime.Model.Operations;
using Iris.Runtime.Model.PropertyEditors.Interfaces;
using Iris.Runtime.Model;
using Iris.Interfaces;
using Iris.Runtime.Model.Operations.SchemaOperations;

namespace Iris.Designer.VisualObjects
{
  [Serializable]
  public class VisualOperation : Table, Iris.Designer.VisualObjects.IVisualOperation, IComparable<VisualOperation>
  {
    public VisualOperation(FlowChart flowChart, Type opType,
      Structure _structure, string _name, float x, float y)
      : base(flowChart)
    {
      operation = OpearationFactory.CreateOperation(opType, _structure, _name);
      Init(flowChart, _structure, x, y);
    }

    public VisualOperation(FlowChart flowChart, IOperation aOperation,
      Structure aStructure, float x, float y)
      : base(flowChart)
    {
      operation = aOperation;
      Init(flowChart, aStructure, x, y);
    }


    private Guid? id;
    public Guid Id 
    {
      get
      {
        if (!id.HasValue)
          id = Guid.NewGuid();
        return id.Value;
      }
      set
      {
        id = value;
      }
    }


    private void Init(FlowChart flowChart, Structure aStructure, float x, float y)
    {
      id = Guid.NewGuid();
      Tag = operation;
      this.BoundingRect = new RectangleF(x, y, 50, 50);
      surface = flowChart;

      ((IOperation)operation).AfterNameChange += OnNameChange;

      if (operation is Operation)
        ((Operation)operation).StatusChange += OnStatusChange;

      if (operation is IDynamicIOOperation)
      {
        ((IDynamicIOOperation)operation).BeforeRefreshIO += OnBeforeRefreshIO;
        ((IDynamicIOOperation)operation).AfterRefreshIO += OnAfterRefreshIO;
      }

      InitTable(x, y);
      Surface.Add(this);

      foreach (Box btn in buttons.AttachedObjects)
        Surface.Add(btn);

      structure = aStructure;

      if ((structure.StartPoint == null) && (!(operation is IEntity)))
        structure.StartPoint = (Operation)operation;

      Surface.Selection.Clear();
      Surface.Selection.AddObject(this);
    }

    private Structure structure;

    private void OnNameChange(object sender, EventArgs e)
    {
      this.Caption = operation.Name;
    }

    private void OnStatusChange(object sender, EventArgs e)
    {
      SetupColors();
      if (((Operation)Operation).Status == ExecutionStatus.Failure)
        Surface.BringIntoView(this);
    }

    internal class LinkHelper
    {
      internal LinkHelper(string _iO, Arrow link, bool _input)
      {
        if (_input)
        {
          targetIdx = link.OrgnIndex;
          vO = (VisualOperation)link.Origin;
        }
        else
        {
          targetIdx = link.DestIndex;
          vO = (VisualOperation)link.Destination;
        }
        iO = _iO;
        input = _input;
        linkColor = link.PenColor;
      }
      internal VisualOperation vO;
      internal int targetIdx;
      internal string iO;
      internal bool input;
      internal Color linkColor;
    }

    private List<LinkHelper> tmpIO;
    internal List<LinkHelper> TmpIO
    {
      get { return tmpIO; }
    }

    private void OnBeforeRefreshIO(object sender, EventArgs e)
    {

      #region Cria lista de links prévios

      tmpIO = new List<LinkHelper>();

      for (int i = 0; i < Rows.Count; i++)
      {
        Row row = Rows[i];
        LinkHelper helper;

        for (int j = 0; j < row.IncomingArrows.Count; j++)
        {
          if (i == 0)
            helper = new LinkHelper("Start", row.IncomingArrows[j], true);
          else
            helper = new LinkHelper(((Operation)operation).GetInputName(i - 1), row.IncomingArrows[j], true);

          tmpIO.Add(helper);
        }

        for (int j = 0; j < row.OutgoingArrows.Count; j++)
        {
          if (i == 0)
            helper = new LinkHelper("Success", row.OutgoingArrows[j], false);
          else if (i == 1)
            helper = new LinkHelper("Failure", row.OutgoingArrows[j], false);
          else
            helper = new LinkHelper(((Operation)operation).GetOutputName(i - 2), row.OutgoingArrows[j], false);

          tmpIO.Add(helper);
        }
      }

      #endregion
    }

    private void OnAfterRefreshIO(object sender, EventArgs e)
    {

      #region Exclui os links visuais

      for (int i = 0; i < RowCount; i++)
      {
        Row row = Rows[i];

        while (row.IncomingArrows.Count > 0)
        {
          Surface.DeleteObject(row.IncomingArrows[0]);
        }

        while (row.OutgoingArrows.Count > 0)
        {
          Surface.DeleteObject(row.OutgoingArrows[0]);
        }
      }

      #endregion

      //Recria as linhas      
      CreateRows();

      RecreateLinks();
    }

    private void RecreateLinks()
    {
      foreach (LinkHelper helper in tmpIO)
      {
        string[] io;
        if (helper.input)
        {
          io = new string[((Operation)operation).InputCount];
          for (int i = 0; i < ((Operation)operation).InputCount; i++)
          {
            io[i] = ((Operation)operation).GetInputName(i);
          }
        }
        else
        {
          io = new string[((Operation)operation).OutputCount];
          for (int i = 0; i < ((Operation)operation).OutputCount; i++)
          {
            io[i] = ((Operation)operation).GetOutputName(i);
          }
        }

        Arrow link = null;

        string label = helper.iO;

        if (label == "Start")
          link = TryCreateLink(helper.vO, helper.targetIdx, this, 0, helper);
        else if (label == "Success")
          link = TryCreateLink(this, 0, helper.vO, helper.targetIdx, helper);
        else if (label == "Failure")
          link = TryCreateLink(this, 1, helper.vO, helper.targetIdx, helper);
        else
        {
          for (int i = 0; i < io.Length; i++)
          {
            if (io[i] == label)
            {
              if (helper.input)
                link = TryCreateLink(helper.vO, helper.targetIdx, this, i + 1, helper);
              else
                link = TryCreateLink(this, i + 2, helper.vO, helper.targetIdx, helper);
              break;
            }
          }
        }

        if (link != null)
        {
          link.Tag = new VisualLink(link);
          link.ArrowHead = ArrowHead.BowArrow;
          link.Pen = new MindFusion.Drawing.Pen(helper.linkColor);
          link.Brush = new MindFusion.Drawing.SolidBrush(helper.linkColor);
        }
      }
    }

    private Arrow TryCreateLink(VisualOperation origin, int origIdx, VisualOperation destination, int destIdx, LinkHelper helper)
    {
      bool create;

      if (helper.input)
      {
        if (helper.iO == "Start")
          create = (origin.Operation.OnSuccess == this.Operation);
        else
          create = (((Operation)operation).GetInput(helper.iO) == origin.Operation);

        foreach (Arrow arrow in this.Rows[destIdx].IncomingArrows)
        {
          create &= (arrow.Origin != origin);
        }
      }
      else
      {
        if (helper.iO == "Success")
          create = (((Operation)operation).OnSuccess == destination.operation);
        else if (helper.iO == "Failure")
          create = (((Operation)operation).OnFailure == destination.operation);
        else
          create = (((Operation)operation).GetOutput(helper.iO) == destination.Operation);

        foreach (Arrow arrow in this.Rows[destIdx].OutgoingArrows)
        {
          create &= (arrow.Destination != destination);
        }
      }
      if (create)
        return Surface.CreateArrow(origin, origIdx, destination, destIdx);
      else
        return null;
    }


    private void SetupColors()
    {
      Color color = Color.White;

      if (operation is IEntity)
      {
        if (operation is SchemaEntity)
          color = Color.LightSlateGray;
        else
        {
          color = Color.DarkKhaki;
        }
      }
      else
      {
        switch (((Operation)operation).Status)
        {
          case ExecutionStatus.WaitingExecution:
            color = Color.White;
            break;
          case ExecutionStatus.PreparingInputs:
            color = Color.Silver;
            break;
          case ExecutionStatus.Running:
            color = Color.Goldenrod;
            break;
          case ExecutionStatus.Success:
            color = Color.Green;
            break;
          case ExecutionStatus.Failure:
            color = Color.Red;
            break;
        }
      }

      color = SetColor(color);
    }

    internal Color SetColor(Color color)
    {
      float totalh = this.BoundingRect.Height;

      // set table properties
      MindFusion.Drawing.LinearGradientBrush tbrush = new
        MindFusion.Drawing.LinearGradientBrush(Color.LightBlue, Color.LightBlue, 90);

      Color midColor = Color.DarkGoldenrod;
      if (operation is SchemaEntity)
        midColor = Color.DarkSlateGray;

      ColorBlend blend = new ColorBlend(4);
      blend.Colors[0] = color;
      blend.Colors[1] = midColor;
      blend.Colors[2] = color;
      blend.Colors[3] = color;
      blend.Positions[0] = 0;
      blend.Positions[1] = CaptionHeight / totalh;
      blend.Positions[2] = CaptionHeight / totalh;
      blend.Positions[3] = 1;
      tbrush.InterpolationColors = blend;

      this.Brush = tbrush;
      return color;
    }

    private IOperation operation;

    public IOperation Operation
    {
      get { return operation; }
      set { operation = value; }
    }

    private FlowChart surface;

    public FlowChart Surface
    {
      get { return surface; }
      internal set { surface = value; }
    }

    private Group buttons;
    private Box statusButton;
    private float rowHeight;// Surface.TableRowHeight;
    private float captionHeigth;
    private float colWidth;

    private void InitTable(float x, float y)
    {
      // create a table
      rowHeight = 12;// Surface.TableRowHeight;
      captionHeigth = 24;
      
      colWidth = 47;
      if ((operation is BaseSchemaOperation) || (operation.GetType().Name == "InvokeWebService")||(operation.LargeObject) )
        colWidth = 94;


      this.Font = new Font(surface.Font.FontFamily, 7, FontStyle.Bold);

      Caption = Operation.Name;

      // add buttons to the table
      buttons = Surface.CreateGroup(this);

      CreateTypeButton();
      if (operation == ((Structure)operation.Structure).StartPoint)
        SetStartPoint();

      this.ColumnCount = 4;
      this.RowHeight = rowHeight;
      this.Scrollable = false;
      this.EnabledHandles = Handles.Move;
      this.CellFrameStyle = CellFrameStyle.None;
      this.HandlesStyle = HandlesStyle.HatchHandles3;
      this.Columns[0].Width = rowHeight;
      this.Columns[3].Width = rowHeight;
      this.Columns[1].Width = colWidth;
      this.Columns[2].Width = colWidth;
      this.Style = TableStyle.RoundedRectangle;
      this.CaptionColor = Color.Black;


      CreateRows();
    }

    internal void CreateRows()
    {
      if ((operation is IEntity))
      {
        //Row 0 -> Start -- Success
        RowCount = 1;
        SetupRowAnchors(0, PlugType.Input, "Entrada", PlugType.Output, "Saída");
      }
      else
      {
        int count = ((Operation)operation).InputCount + 1;
        int defaultOutputs;
        if (operation is Entity)
          defaultOutputs = 1;
        else
          defaultOutputs = 2;


        if ((((Operation)operation).OutputCount + defaultOutputs) > count)
          count = ((Operation)operation).OutputCount + defaultOutputs;


        if (RowCount != count)
        {
          while (RowCount < count)
          {
            AddRow();
          }
          RowCount = count;
        }

        //Row 0 -> Start -- Success
        SetupRowAnchors(0, PlugType.Start, "Início", PlugType.Success, "Sucesso");
        //Row 1 -> Input[0] -- Failure
        string input0 = "";
        PlugType img0 = PlugType.None;
        if (((Operation)operation).InputCount > 0)
        {
          input0 = ((Operation)operation).GetInputName(0);
          img0 = PlugType.Input;
        }
        SetupRowAnchors(1, img0, input0, PlugType.Failure, "Falha");

        //Demais rows, com inputs e outputs auxiliares
        for (int i = 0; i < count; i++)
        {
          string inputN = "";
          PlugType inImgN = PlugType.None;
          if (((Operation)operation).InputCount > (i + 1))
          {
            inputN = ((Operation)operation).GetInputName(i + 1);
            inImgN = PlugType.Input;
          }

          string outputN = "";
          PlugType outImgN = PlugType.None;
          if (((Operation)operation).OutputCount > (i))
          {
            outputN = ((Operation)operation).GetOutputName(i);
            outImgN = PlugType.Output;
          }
          SetupRowAnchors(i + 2, inImgN, inputN, outImgN, outputN);
        }

      }

      float totalh;

      if ((operation is ResultSet) || (operation is ScalarVar))
        totalh = (captionHeigth * 2);
      else
        totalh = (captionHeigth + (this.RowCount * RowHeight) + rowHeight);

      RectangleF bRect = new RectangleF(BoundingRect.Left, BoundingRect.Top, (2 * colWidth) + (2 * rowHeight), totalh);
      this.BoundingRect = bRect;
      SetupColors();

    }

    private void SetupRowAnchors(int row, PlugType leftType, string leftLabel,
      PlugType rightType, string rightLabel)
    {
      Bitmap leftImage = GetImageFromPlugType(leftType);
      Bitmap rightImage = GetImageFromPlugType(rightType);

      if ((leftImage != null) || (rightImage != null))
      {
        ArrayList al = new ArrayList();
        if (leftImage != null)
        {
          this[0, row].ImageAlign = ImageAlign.Center;
          this[0, row].Tag = leftType;
          this[0, row].Image = leftImage;
          this[1, row].Text = leftLabel;
          al.Add(new AnchorPoint(52, 42, true, false, GetColorFromType(leftType), 0));
        }

        if (rightImage != null)
        {
          this[3, row].ImageAlign = ImageAlign.Center;
          this[3, row].Image = rightImage;
          this[3, row].Tag = rightType;
          this[2, row].Text = rightLabel;
          this[2, row].TextFormat.Alignment = StringAlignment.Far;
          al.Add(new AnchorPoint(48, 42, false, true, GetColorFromType(rightType), 3));
        }

        this.Rows[row].AnchorPattern = new AnchorPattern(
        (AnchorPoint[])al.ToArray(typeof(AnchorPoint)));
      }

      if (row < this.RowCount)
      {
        if (leftImage == null)
        {
          this[0, row].Image = null;
          this[1, row].Text = "";
        }

        if (rightImage == null)
        {
          this[3, row].Image = null;
          this[2, row].Text = "";
        }
      }
    }

    private Color GetColorFromType(PlugType pt)
    {
      Color color = Color.White;
      switch (pt)
      {
        case PlugType.Success:
          color = Color.LightGreen;
          break;
        case PlugType.Failure:
          color = Color.Red;
          break;
        case PlugType.Input:
          color = Color.Gold;
          break;
        case PlugType.Output:
          color = Color.Gold;
          break;
        case PlugType.Start:
          color = Color.Green;
          break;
      }
      return color;
    }

    private Bitmap GetImageFromPlugType(PlugType pt)
    {
      if (pt == PlugType.None)
        return null;
      else
        return (Bitmap)Plugs.ResourceManager.GetObject(pt.ToString());
    }

    private void CreateTypeButton()
    {
      string opName = Operation.GetType().ToString();
      opName = opName.Substring(opName.LastIndexOf('.') + 1);
      Bitmap img = (Bitmap)Resources.ResourceManager.GetObject(opName);
      if (img == null)
      {
        MethodInfo getIcon = Operation.GetType().GetMethod("GetIcon");
        if (getIcon != null)
        {
          img = (Bitmap)getIcon.Invoke(null, null);
        }
      }
      CreateButton(BoundingRect.Left + 3, BoundingRect.Top + 3, img, 0);
    }

    private Box CreateButton(float x, float y, Bitmap image, int corner)
    {
      RectangleF rc = this.BoundingRect;
      Box btn = new Box(surface);
      btn.BoundingRect = new RectangleF(x, y, 16, 16);
      btn.Transparent = true;
      btn.Image = image;
      btn.ImageAlign = ImageAlign.Center;
      buttons.AttachToCorner(btn, corner);
      btn.Locked = true;
      return btn;
    }

    public void SetStartPoint()
    {
      statusButton = CreateButton(BoundingRect.Right - 20, BoundingRect.Top + 3, Resources.StartPoint, 1);
      surface.Add(statusButton);
    }

    public void ResetStatus()
    {
      if (statusButton != null)
      {
        buttons.Detach(statusButton);
        Surface.DeleteObject(statusButton);
        statusButton = null;
      }
    }

    public void SetEndPoint()
    {
      statusButton = CreateButton(BoundingRect.Right - 20, BoundingRect.Top + 3, Resources.EndPoint, 1);
      surface.Add(statusButton);
    }

    public void SetOutputPoint()
    {
      statusButton = CreateButton(BoundingRect.Right - 31, BoundingRect.Top + 3, Resources.OutputPoint, 1);
      surface.Add(statusButton);
    }

    internal void SetExceptionHandler()
    {
      statusButton = CreateButton(BoundingRect.Right - 20, BoundingRect.Top + 3, Resources.dex, 1);
      surface.Add(statusButton);
    }

    internal void Delete()
    {
      while (buttons.AttachedObjects.Count > 0)
        Surface.DeleteObject(buttons.AttachedObjects[0]);

      structure.Operations.Remove((IOperation)operation);
      if (operation == structure.StartPoint)
      {
        if (structure.Operations.Count > 0)
          structure.StartPoint = (Operation)structure.Operations[0];
        else
          structure.StartPoint = null;
      }

      if (operation == structure.RunningOper)
        structure.RunningOper = structure.StartPoint;

      for (int i = 0; i < Rows.Count; i++)
      {
        while (Rows[i].IncomingArrows.Count > 0)
        {
          VisualLink link = (VisualLink)Rows[i].IncomingArrows[0].Tag;
          Arrow arrow = Rows[i].IncomingArrows[0];
          link.Delete();
          surface.DeleteObject(arrow);
        }

        while (Rows[i].OutgoingArrows.Count > 0)
        {
          VisualLink link = (VisualLink)Rows[i].OutgoingArrows[0].Tag;
          Arrow arrow = Rows[i].OutgoingArrows[0];
          link.Delete();
          surface.DeleteObject(arrow);
        }
      }

      if(operation is Operation)
        ((Operation)operation).Delete();
    }

    public override string ToString()
    {

      return this.CaptionPlainText;
    }


    public int CompareTo(VisualOperation other)
    {
      float xGap = Math.Abs(this.BoundingRect.Left - other.BoundingRect.Left);
      float yGap = Math.Abs(this.BoundingRect.Top - other.BoundingRect.Top);
      if(yGap> this.BoundingRect.Height)
        return this.BoundingRect.Top.CompareTo(other.BoundingRect.Top);
      else
        return this.BoundingRect.Left.CompareTo(other.BoundingRect.Left);
    }
  }

  public enum PlugType
  {
    None,
    Success,
    Failure,
    Input,
    Output,
    Start
  }
}
