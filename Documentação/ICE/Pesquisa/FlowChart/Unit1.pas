unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, dxflchrt, dxFcEdit, ImgList, StdCtrls, ExtCtrls, DB, ADODB,
  DBClient, Transactor;

type
  TForm1 = class(TForm)
    dxFlowChart1: TdxFlowChart;
    ImageList1: TImageList;
    pnlBox: TPanel;
    btnSelectedConnection: TButton;
    btnCreateObject: TButton;
    btnClear: TButton;
    btnCreateConn: TButton;
    btnDelete: TButton;
    btnImageIndex: TButton;
    btnCustomObject: TButton;
    btnTesteData: TButton;
    btnShowForm: TButton;
    std: TSimpleTransDataset;
    con: TADOConnection;
    procedure dxFlowChart1DblClick(Sender: TObject);
    procedure btnSelectedConnectionClick(Sender: TObject);
    procedure dxFlowChart1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure btnCreateObjectClick(Sender: TObject);
    procedure btnClearClick(Sender: TObject);
    procedure btnCreateConnClick(Sender: TObject);
    procedure btnDeleteClick(Sender: TObject);
    procedure dxFlowChart1CreateItem(Sender: TdxCustomFlowChart;
      Item: TdxFcItem);
    procedure btnImageIndexClick(Sender: TObject);
    procedure btnCustomObjectClick(Sender: TObject);
    procedure btnTesteDataClick(Sender: TObject);
    procedure btnShowFormClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

  TISCEObject = Class(TdxFcObject)
  public
   TagString: string;
  end;




var
  Form1: TForm1;

implementation

uses Unit2;

{$R *.dfm}

procedure TForm1.dxFlowChart1DblClick(Sender: TObject);
begin
  ShowFlowChartEditor(dxFlowChart1,'Teste');
end;

procedure TForm1.btnSelectedConnectionClick(Sender: TObject);
begin
  dxFlowChart1.SelectedObject:= dxFlowChart1.Objects[0];
  if dxFlowChart1.SelectedObject <> nil then
    begin
      dxFlowChart1.SelectedObject.ShapeWidth := 10;
      dxFlowChart1.SelectedObject.ShapeType := fcsDiamond;
      dxFlowChart1.SelectedObject.ShapeColor := clAqua;
    end;
end;

procedure TForm1.dxFlowChart1MouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
  P: TPoint;
begin
  if (ssCtrl in Shift) and (Button = mbLeft) then
  begin
    // Get chart point
    P := dxFlowChart1.ChartPoint(X,Y);
    // Create object at specified point
    dxFlowChart1.CreateObject(P.X,P.Y,60,40,fcsRectangle);
  end;

end;

procedure TForm1.btnCreateObjectClick(Sender: TObject);
begin
  dxFlowChart1.CreateObject(0,0,120,40,fcsRectangle);
end;

procedure TForm1.btnClearClick(Sender: TObject);
begin
  dxFlowChart1.Clear;
end;

procedure TForm1.btnCreateConnClick(Sender: TObject);
Var
  Src, Dst: TdxFcObject;
  Idx: Integer;
begin
  Src:= dxFlowChart1.SelectedObjects[0];
  Idx:= dxFlowChart1.SelectedObjectCount -1;
  Dst:= dxFlowChart1.SelectedObjects[Idx];

  dxFlowChart1.CreateConnection(Src,Dst,0,0);
end;

procedure TForm1.btnDeleteClick(Sender: TObject);
Var
  Src: TdxFcObject;
begin
  Src:= dxFlowChart1.SelectedObject;
  dxFlowChart1.DeleteObject(Src);

end;

procedure TForm1.dxFlowChart1CreateItem(Sender: TdxCustomFlowChart;
  Item: TdxFcItem);
begin
  if item is TdxFcConnection then
    with TdxFcConnection(Item) do
    begin
      ArrowSource.Width := 15;
      ArrowSource.Height := 15;
      ArrowSource.ArrowType := fcaEllipse;
      ArrowDest.Width := 15;
      ArrowDest.Height := 15;
      ArrowDest.ArrowType := fcaArrow;
      Color := clBlue;
      PenStyle:= PsDash;
      Style:= fclCurved;
    end;
end;

procedure TForm1.btnImageIndexClick(Sender: TObject);
begin
  dxFlowChart1.SelectedObject.ImageIndex:=3;
end;

procedure TForm1.btnCustomObjectClick(Sender: TObject);
var
  Ice: TISCEObject;
begin
  Ice:= TISCEObject.Create(dxFlowChart1);
  Ice.ImageIndex:=1;
  Ice.ShapeType:= fcsNone;
  Ice.SetBounds(5, 5, 30, 30);
  Ice.Visible:= True;
  Ice.TagString:= 'TesteTagString';
  Ice.Data:= btnCustomObject;
  Ice.CustomData:= 'CustomData';
end;

procedure TForm1.btnTesteDataClick(Sender: TObject);
var
  Obj:TdxFcObject;
  i: integer;
begin
  for i:= 0 to dxFlowChart1.ObjectCount -1 do
    if dxFlowChart1.Objects[i] is TISCEObject then begin
      Obj:= dxFlowChart1.Objects[i];
      ShowMessage(TButton(Obj.Data).Name);
    end;
end;

procedure TForm1.btnShowFormClick(Sender: TObject);
begin
//  Form2.Show;
end;

end.
