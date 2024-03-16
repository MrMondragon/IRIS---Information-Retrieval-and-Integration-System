unit _ISISForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, fcButton, fcImgBtn, fcShapeBtn, ExtCtrls, ImgList, ActnList,
  fcClearPanel, fcButtonGroup, fcOutlookBar, ComCtrls, SynEdit, dxflchrt,
  SynHighlighterSQL, SynEditHighlighter, SynHighlighterPas, StdCtrls,
  ToolWin, ICEObjects, ISISObjects;

type

  TISISForm = class(TForm)
    SynPasSyn1: TSynPasSyn;
    SynSQLSyn1: TSynSQLSyn;
    pagTools: TPageControl;
    StatusBar1: TStatusBar;
    Splitter1: TSplitter;
    pnlMain: TPanel;
    MainDrawArea: TdxFlowChart;
    SynEdit1: TSynEdit;
    Splitter2: TSplitter;
    tabTools: TTabSheet;
    olbToolBar: TfcOutlookBar;
    olbToolBarfcShapeBtn1: TfcShapeBtn;
    ActionList1: TActionList;
    actPasObject: TAction;
    actSQLObject: TAction;
    actTransObject: TAction;
    actClientCursor: TAction;
    ImageList2: TImageList;
    actSubStructure: TAction;
    actCompletionConnection: TAction;
    actSuccessConnection: TAction;
    actFailureConnection: TAction;
    actStartPoint: TAction;
    actEndPoint: TAction;
    actBooleanChoice: TAction;
    actSwitch: TAction;
    actFor: TAction;
    actWhile: TAction;
    actRepeat: TAction;
    pnlObjs: TPanel;
    btnSubStruct: TfcShapeBtn;
    btnCursor: TfcShapeBtn;
    btnTransport: TfcShapeBtn;
    btnSQL: TfcShapeBtn;
    btnPas: TfcShapeBtn;
    olbToolBarfcShapeBtn2: TfcShapeBtn;
    pnlConnections: TPanel;
    btnCompletion: TfcShapeBtn;
    btnSuccess: TfcShapeBtn;
    btnFailure: TfcShapeBtn;
    olbToolBarfcShapeBtn3: TfcShapeBtn;
    pnlStructs: TPanel;
    btnStartPoint: TfcShapeBtn;
    btnEndPoint: TfcShapeBtn;
    btnBoolChoice: TfcShapeBtn;
    btnDynChoice: TfcShapeBtn;
    btnFor: TfcShapeBtn;
    btnWhile: TfcShapeBtn;
    btnRepeat: TfcShapeBtn;
    actStructureConnection: TAction;
    btnStructureConnection: TfcShapeBtn;
    actAlignV: TAction;
    actAlignH: TAction;
    actDelete: TAction;
    actNudgeUp: TAction;
    actNudgeDown: TAction;
    actNudgeLeft: TAction;
    actNudgeRight: TAction;
    ToolBar1: TToolBar;
    btnAlignV: TToolButton;
    btnAlignH: TToolButton;
    btnNudgeUp: TToolButton;
    btnNudgeDown: TToolButton;
    btnNudgeLeft: TToolButton;
    btnNudgeRight: TToolButton;
    btnDelete: TToolButton;
    procedure actPasObjectExecute(Sender: TObject);
    procedure actSQLObjectExecute(Sender: TObject);
    procedure actTransObjectExecute(Sender: TObject);
    procedure actClientCursorExecute(Sender: TObject);
    procedure MainDrawAreaMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure MainDrawAreaCreateItem(Sender: TdxCustomFlowChart;
      Item: TdxFcItem);
    procedure actSubStructureExecute(Sender: TObject);
    procedure actCompletionConnectionExecute(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure actSuccessConnectionExecute(Sender: TObject);
    procedure actFailureConnectionExecute(Sender: TObject);
    procedure MainDrawAreaDeletion(Sender: TdxCustomFlowChart;
      Item: TdxFcItem);
    procedure actStartPointExecute(Sender: TObject);
    procedure actEndPointExecute(Sender: TObject);
    procedure actBooleanChoiceExecute(Sender: TObject);
    procedure actSwitchExecute(Sender: TObject);
    procedure actForExecute(Sender: TObject);
    procedure actWhileExecute(Sender: TObject);
    procedure actRepeatExecute(Sender: TObject);
    procedure actStructureConnectionExecute(Sender: TObject);
    procedure actNudgeUpExecute(Sender: TObject);
    procedure actNudgeDownExecute(Sender: TObject);
    procedure actNudgeLeftExecute(Sender: TObject);
    procedure actNudgeRightExecute(Sender: TObject);
    procedure actDeleteExecute(Sender: TObject);
    procedure actAlignVExecute(Sender: TObject);
    procedure actAlignHExecute(Sender: TObject);
    procedure FormKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
  private
    FObjClass: TObjClass;
    FConType: TConType;
    FEventType: TEventType;
    FOprType: TOprType;
    FStructType: TStructType;
    FSuperStructure: TICEStructure;
    procedure ResetButtonsState(aPnl: TPanel);
    procedure SetObjClass(Value: TObjClass);
    procedure SetConType(Value: TConType);
    procedure SetEventType(Value: TEventType);
    procedure SetOprType(Value: TOprType);
    procedure SetStructType(Value: TStructType);
    { Private declarations }
  public
    procedure doDrawConnection;
    procedure doDrawObject;
    property ObjClass: TObjClass read FObjClass write SetObjClass;
    property ConType: TConType read FConType write SetConType;
    property EventType: TEventType read FEventType write SetEventType;
    property OprType: TOprType read FOprType write SetOprType;
    property StructType: TStructType read FStructType write SetStructType;
    property SuperStructure: TICEStructure read FSuperStructure write
        FSuperStructure;
    { Public declarations }
  end;

var
  ISISForm: TISISForm;

implementation

uses Math;

{$R *.dfm}

/////////////////////////////////////////////////////////////////////////////////
//Inicialização do form
procedure TISISForm.FormCreate(Sender: TObject);
begin
  ObjClass:= clsNone;
  EventType:= evNone;
  StructType:= stNone;
  OprType:= otNone;
  ConType:= ctNone;

  SuperStructure:= TICEStructure.Create(Nil);
  SuperStructure.DrawArea:= MainDrawArea;

  olbToolBar.ActivePage:= olbToolBarfcShapeBtn1;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o otPascal como tipo de objeto a ser criado
procedure TISISForm.actPasObjectExecute(Sender: TObject);
begin
  ObjClass:= clsOperation;
  OprType:= otPascal;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o otSQL como tipo de objeto a ser criado
procedure TISISForm.actSQLObjectExecute(Sender: TObject);
begin
  ObjClass:= clsOperation;
  OprType:= otSQL;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o otTrans como tipo de objeto a ser criado
procedure TISISForm.actTransObjectExecute(Sender: TObject);
begin
  ObjClass:= clsOperation;
  OprType:= otDataTransport;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o otClientCursor como tipo de objeto a ser criado
procedure TISISForm.actClientCursorExecute(Sender: TObject);
begin
  ObjClass:= clsOperation;
  OprType:= otClientCursor;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o otSubStructure como tipo de objeto a ser criado
procedure TISISForm.actSubStructureExecute(Sender: TObject);
begin
  ObjClass:= clsOperation;
  OprType:= otSubStructure;
end;

/////////////////////////////////////////////////////////////////////////////////
//MouseDown
procedure TISISForm.MainDrawAreaMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
begin

  //Limpa a seleção se o hittest for nulo
  if MainDrawArea.GetHitTestAt(X,Y) = [htNowhere] then
    MainDrawArea.ClearSelection;

  //desenha o objeto
  if ObjClass in [clsOperation, clsControlStructure] then begin
    SuperStructure.CreateObject(X,Y, ObjClass, OprType, StructType);
    ObjClass:= clsNone;
    OprType:= otNone;
    StructType:= stNone;
  end;


  //  if ObjClass in [otPascal, otSQL, otClientCursor, otDataTransport, otSubStructure] then begin
//    DrawObject(X,Y, ObjClass, MainDrawArea, FShapeH, FShapeW,'x');
//    ObjClass:= otNone;
//  end else if ObjClass = otControlStructure then begin
//    DrawControlStructure(X,Y,FStructType, MainDrawArea, FShapeH, FShapeW,'x');
//    FStructType:= stNone;
//    ObjClass:= otNone;
//  end;

  //Retorna todos os botões de dois estados ao estado normal
  ResetButtonsState(pnlObjs);
  ResetButtonsState(pnlStructs);

end;

/////////////////////////////////////////////////////////////////////////////////
//Desenha os objetos
/////////////////////////////////////////////////////////////////////////////////
//OnCreateItem de MainDrawArea
procedure TISISForm.MainDrawAreaCreateItem(Sender: TdxCustomFlowChart;
  Item: TdxFcItem);
begin
  //impede a criação acidental de conexões automáticas
//  if item is TdxFcConnection then
//      if ObjClass <> otConnection then abort;
end;

/////////////////////////////////////////////////////////////////////////////////
//Retorna todos os botões de dois estados para o estado normal
procedure TISISForm.ResetButtonsState(aPnl: TPanel);
var
  i: Integer;
begin
  for i:= 0 to aPnl.ControlCount -1 do
    if aPnl.Controls[i] is TfcShapeBtn then
      TfcShapeBtn(aPnl.Controls[i]).Down:= False;
end;

/////////////////////////////////////////////////////////////////////////////////
//Desenha as conexões
/////////////////////////////////////////////////////////////////////////////////
//Determina os pontos iniciais de conexão

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o tipo de conexão ctCompletion
procedure TISISForm.actCompletionConnectionExecute(Sender: TObject);
begin
  FEventType:= evCompletion;
  doDrawConnection;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o tipo de conexão ctSuccess
procedure TISISForm.actSuccessConnectionExecute(Sender: TObject);
begin
  FEventType:= evSuccess;
  doDrawConnection;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o tipo de conexão ctFailure
procedure TISISForm.actFailureConnectionExecute(Sender: TObject);
begin
  FEventType:= evFailure;
  doDrawConnection;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o tipo de conexão ctStructure
procedure TISISForm.actStructureConnectionExecute(Sender: TObject);
begin
  FEventType:= evNone;
  doDrawConnection;
end;

/////////////////////////////////////////////////////////////////////////////////
//Remove objetos do modelo
procedure TISISForm.MainDrawAreaDeletion(Sender: TdxCustomFlowChart;
  Item: TdxFcItem);
var
  ObjAux, Obj: TIceObject;
begin
//  if Item is TIceObject then begin
//    Obj:= TIceObject(Item);
//
//    if Obj.Parent <> nil then begin
//      Obj.Parent.ClearUnion;
//      Obj.Parent.Free;
//    end else if Obj.IsUnion then  begin
//      while Obj.ObjectCount > 0 do begin
//        ObjAux:= TIceObject(Obj.Objects[0]);
//        Obj.RemoveFromUnion(ObjAux);
//        ObjAux.Parent:= Nil;
//        ObjAux.Free;
//      end;
//    end;
//  end;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stStartPoint como tipo de objeto a ser criado
procedure TISISForm.actStartPointExecute(Sender: TObject);
begin
  StructType:= stStartPoint;
  ObjClass:= clsControlStructure;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stEndPoint como tipo de objeto a ser criado
procedure TISISForm.actEndPointExecute(Sender: TObject);
begin
  StructType:= stEndPoint;
  ObjClass:= clsControlStructure;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stBoolChoice como tipo de objeto a ser criado
procedure TISISForm.actBooleanChoiceExecute(Sender: TObject);
begin
  FStructType:= stBoolChoice;
    FObjClass:= clsControlStructure;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stDynChoice como tipo de objeto a ser criado
procedure TISISForm.actSwitchExecute(Sender: TObject);
begin
  FStructType:= stDynChoice;
  FObjClass:= clsControlStructure;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stFor como tipo de objeto a ser criado
procedure TISISForm.actForExecute(Sender: TObject);
begin
  FStructType:= stFor;
  FObjClass:= clsControlStructure;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stFor como tipo de objeto a ser criado
procedure TISISForm.actWhileExecute(Sender: TObject);
begin
  FStructType:= stWhile;
  FObjClass:= clsControlStructure;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stRepeat como tipo de objeto a ser criado
procedure TISISForm.actRepeatExecute(Sender: TObject);
begin
  FStructType:= stRepeat;
  FObjClass:= clsControlStructure;
end;

/////////////////////////////////////////////////////////////////////////////////
//Desenha as estruturas de controle
/////////////////////////////////////////////////////////////////////////////////
//Retorna o tipo de objeto
/////////////////////////////////////////////////////////////////////////////////
//Move o objeto um ponto para cima
procedure TISISForm.actNudgeUpExecute(Sender: TObject);
var
  j,i: Integer;
begin
  For i:= 0 to MainDrawArea.SelCount -1 do begin
    MainDrawArea.SelectedObjects[i].Top:= MainDrawArea.SelectedObjects[i].Top -1;
    if MainDrawArea.SelectedObjects[i].ObjectCount > 0 then
      for j:= 0 to MainDrawArea.SelectedObjects[i].ObjectCount -1 do
        MainDrawArea.SelectedObjects[i].Objects[j].Top:= MainDrawArea.SelectedObjects[i].Objects[j].Top -1;
  end;
end;

/////////////////////////////////////////////////////////////////////////////////
//Move o objeto um ponto para baixo
procedure TISISForm.actNudgeDownExecute(Sender: TObject);
var
  j,i: Integer;
begin
  For i:= 0 to MainDrawArea.SelCount -1 do begin
    MainDrawArea.SelectedObjects[i].Top:= MainDrawArea.SelectedObjects[i].Top +1;
    if MainDrawArea.SelectedObjects[i].ObjectCount > 0 then
      for j:= 0 to MainDrawArea.SelectedObjects[i].ObjectCount -1 do
        MainDrawArea.SelectedObjects[i].Objects[j].Top:= MainDrawArea.SelectedObjects[i].Objects[j].Top +1;
  end;

end;

/////////////////////////////////////////////////////////////////////////////////
//Move o objeto um ponto para a esquerda
procedure TISISForm.actNudgeLeftExecute(Sender: TObject);
var
  i,j: Integer;
begin
  For i:= 0 to MainDrawArea.SelCount -1 do begin
    MainDrawArea.SelectedObjects[i].Left:= MainDrawArea.SelectedObjects[i].Left -1;
    if MainDrawArea.SelectedObjects[i].ObjectCount > 0 then
      for j:= 0 to MainDrawArea.SelectedObjects[i].ObjectCount -1 do
        MainDrawArea.SelectedObjects[i].Objects[j].Left:= MainDrawArea.SelectedObjects[i].Objects[j].Left -1;
  end;

end;

/////////////////////////////////////////////////////////////////////////////////
//Move o objeto um ponto para a direita
procedure TISISForm.actNudgeRightExecute(Sender: TObject);
var
  i, j: Integer;
begin
  For i:= 0 to MainDrawArea.SelCount -1 do begin
    MainDrawArea.SelectedObjects[i].Left:= MainDrawArea.SelectedObjects[i].Left +1;
    if MainDrawArea.SelectedObjects[i].ObjectCount > 0 then
      for j:= 0 to MainDrawArea.SelectedObjects[i].ObjectCount -1 do
        MainDrawArea.SelectedObjects[i].Objects[j].Left:= MainDrawArea.SelectedObjects[i].Objects[j].Left +1;
  end;
end;

/////////////////////////////////////////////////////////////////////////////////
//Deleta os objetos selecionados
procedure TISISForm.actDeleteExecute(Sender: TObject);
begin
  MainDrawArea.DeleteSelection;
end;

procedure TISISForm.actAlignVExecute(Sender: TObject);
var
  RefX, X: integer;
  i,j: Integer;
begin
  if MainDrawArea.SelCount < 2 then exit;

  RefX:= MainDrawArea.SelectedObjects[0].Left + Trunc(MainDrawArea.SelectedObjects[0].Width /2);

  for i:= 1 to MainDrawArea.SelCount -1 do begin
    X:= MainDrawArea.SelectedObjects[i].Left + Trunc(MainDrawArea.SelectedObjects[i].Width /2);
    MainDrawArea.SelectedObjects[i].Left:= MainDrawArea.SelectedObjects[i].Left + (RefX - X);
    if MainDrawArea.SelectedObjects[i].ObjectCount > 0 then
      for j:= 0 to MainDrawArea.SelectedObjects[i].ObjectCount -1 do
        MainDrawArea.SelectedObjects[i].Objects[j].Left:= MainDrawArea.SelectedObjects[i].Objects[j].Left +(RefX - X);
  end;

end;

procedure TISISForm.actAlignHExecute(Sender: TObject);
var
  RefY, Y: integer;
  i,j: Integer;
begin
  if MainDrawArea.SelCount < 2 then exit;

  RefY:= MainDrawArea.SelectedObjects[0].Top + Trunc(MainDrawArea.SelectedObjects[0].Height /2);

  for i:= 1 to MainDrawArea.SelCount -1 do begin
    Y:= MainDrawArea.SelectedObjects[i].Top + Trunc(MainDrawArea.SelectedObjects[i].Height /2);
    MainDrawArea.SelectedObjects[i].Top:= MainDrawArea.SelectedObjects[i].Top + (RefY - Y);
    if MainDrawArea.SelectedObjects[i].ObjectCount > 0 then
      for j:= 0 to MainDrawArea.SelectedObjects[i].ObjectCount -1 do
        MainDrawArea.SelectedObjects[i].Objects[j].Top:= MainDrawArea.SelectedObjects[i].Objects[j].Top +(RefY - Y);
  end;

end;

procedure TISISForm.doDrawConnection;
begin
//  DrawConnection(FEventType,MainDrawArea);
//  FEventType:= ctNone;
//  FObjClass:= otNone;
end;

procedure TISISForm.SetObjClass(Value: TObjClass);
begin
  if FObjClass <> Value then
  begin
    FObjClass := Value;
  end;
end;

procedure TISISForm.SetConType(Value: TConType);
begin
  if FConType <> Value then
  begin
    FConType := Value;
  end;
end;

procedure TISISForm.SetEventType(Value: TEventType);
begin
  if FEventType <> Value then
  begin
    FEventType := Value;
  end;
end;

procedure TISISForm.SetOprType(Value: TOprType);
begin
  if FOprType <> Value then
  begin
    FOprType := Value;
  end;
end;

procedure TISISForm.SetStructType(Value: TStructType);
begin
  if FStructType <> Value then
  begin
    FStructType := Value;
  end;
end;

procedure TISISForm.doDrawObject;
begin
  // TODO -cMM: TForm2.doDrawObject default body inserted
end;

procedure TISISForm.FormKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
var
  i: Integer;
begin
  //tratamento de deleção
  if (key = VK_DELETE) then begin
    While MainDrawArea.SelCount > 0 do begin
      TICEShapedObject(TISISObject(MainDrawArea.SelectedObjects[0]).Data).Free;
    end;
  end;
end;

end.
