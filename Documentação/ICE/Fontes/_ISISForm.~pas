unit _ISISForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, fcButton, fcImgBtn, fcShapeBtn, ExtCtrls, ImgList, ActnList,
  fcClearPanel, fcButtonGroup, fcOutlookBar, ComCtrls, SynEdit, dxflchrt,
  SynHighlighterSQL, SynEditHighlighter, SynHighlighterPas, StdCtrls,
  ToolWin, ICEObjects, JvgSplit, JvComponent, JvInspector, JvExControls,
  JvgListBox, Grids, wwDataInspector, Menus, wwcheckbox, Mask, wwdbedit, ActiveX,
  Wwdotdot, Wwdbspin, ADODB, DB, DBClient, Transactor, Wwdbcomb, PairList,
  _dlgLookupPairs, _dlgEditSQL, wwSpeedButton, wwDBNavigator, wwclearpanel,
  Wwdbigrd, Wwdbgrid, fcLabel, xmldom, XMLIntf, msxmldom, XMLDoc, ICEHelperObjects;


type
  TISISSpecialistObject = class(TObject)
  end;

type
  TISISListManager = class(TISISSpecialistObject)
  private
    procedure ClearLists;
    procedure RefreshLists;
  public
  end;

type
  TISISInspectorControler = class(TISISSpecialistObject)
  private
    procedure ClearDatasetInspector;
    procedure ClearDBCInspector;
    procedure ClearVarInspector;
    procedure DatasetToInspector;
    procedure DBCToInspector;
    procedure InspectorToDataset;
    procedure InspectorToDBC;
    procedure InspectorToPasOperation;
    procedure InspectorTOSQLOperation;
    procedure InspectorToVar;
    procedure PasOperationToInspector;
    procedure RefreshInspector;
    procedure SQLOperationToInspector;
    procedure VarToInspector;
  public
  end;

type
  TISISObjectManager = class(TISISSpecialistObject)
  private
    function CreateDataTransport(X,Y: Integer): TICEDataTransport;
    function CreateDynChoice(X,Y: Integer): TICEDynamicChoice;
    function CreateForLoop(X,Y: Integer): TICEForLoop;
    procedure CreatePasOperation(X,Y: Integer);
    function CreateSQLOperation(X,Y: Integer): TICESqlOperation;
    function CreateWhileLoop(X,Y: Integer): TICEWhileLoop;
    procedure EditConnectionString(aName: String);
    procedure EditDatasetSQL;
    procedure EditPasObject;
    procedure EditSQLObject;
  end;

type
  TISISForm = class(TForm)
    SynPasSyn: TSynPasSyn;
    SynSQLSyn: TSynSQLSyn;
    pagTools: TPageControl;
    StatusBar1: TStatusBar;
    pnlMain: TPanel;
    MainDrawArea: TdxFlowChart;
    tabTools: TTabSheet;
    olbToolBar: TfcOutlookBar;
    btnOperations: TfcShapeBtn;
    ActionList1: TActionList;
    actPasObject: TAction;
    actSQLObject: TAction;
    actTransObject: TAction;
    actClientCursor: TAction;
    MainImageList: TImageList;
    actSubStructure: TAction;
    actStartPoint: TAction;
    actEndPoint: TAction;
    actSwitch: TAction;
    actFor: TAction;
    actWhile: TAction;
    pnlOperations: TPanel;
    btnSubStruct: TfcShapeBtn;
    btnCursor: TfcShapeBtn;
    btnTransport: TfcShapeBtn;
    btnSQL: TfcShapeBtn;
    btnPas: TfcShapeBtn;
    btnConnections: TfcShapeBtn;
    pnlConnections: TPanel;
    btnCompletion: TfcShapeBtn;
    btnFailure: TfcShapeBtn;
    btnStructures: TfcShapeBtn;
    pnlStructs: TPanel;
    btnStartPoint: TfcShapeBtn;
    btnEndPoint: TfcShapeBtn;
    btnDynChoice: TfcShapeBtn;
    btnFor: TfcShapeBtn;
    btnWhile: TfcShapeBtn;
    actDependencyConnection: TAction;
    btnStructureConnection: TfcShapeBtn;
    actAlignV: TAction;
    actAlignH: TAction;
    actDelete: TAction;
    actNudgeUp: TAction;
    actNudgeDown: TAction;
    actNudgeLeft: TAction;
    actNudgeRight: TAction;
    tbrMainBar: TToolBar;
    btnAlignV: TToolButton;
    btnAlignH: TToolButton;
    btnNudgeUp: TToolButton;
    btnNudgeDown: TToolButton;
    btnNudgeLeft: TToolButton;
    btnNudgeRight: TToolButton;
    btnDelete: TToolButton;
    actEventConnection: TAction;
    ScriptSpliter: TJvgSplitter;
    ppmVars: TPopupMenu;
    ppmDatasets: TPopupMenu;
    ppmDBConnections: TPopupMenu;
    actNewVar: TAction;
    actNewVar1: TMenuItem;
    btnVars: TfcShapeBtn;
    pnlVars: TPanel;
    lbxVars: TJvgListBox;
    btnDBConnections: TfcShapeBtn;
    btnDatasets: TfcShapeBtn;
    Splitter1: TSplitter;
    actControlConnection: TAction;
    btnConditionalCon: TfcShapeBtn;
    actConditionalConnection: TAction;
    pnlDBConnections: TPanel;
    lbxDBConnections: TJvgListBox;
    pnlDBCProps: TPanel;
    pnlDBCName: TPanel;
    edtDBCName: TEdit;
    pnlDBCTimeOut: TPanel;
    pnlDBCLocation: TPanel;
    pnlDBCConnectionString: TPanel;
    speDBCTimeOut: TwwDBSpinEdit;
    cdgConnectionString: TwwDBComboDlg;
    cbxDBCClientSide: TCheckBox;
    pnlDatasets: TPanel;
    actNewDBConnection: TAction;
    NovaConexodeBancodeDados1: TMenuItem;
    pnlDtsInspector: TPanel;
    lbxDatasets: TJvgListBox;
    pnlVarProps: TPanel;
    pnlVarName: TPanel;
    edtVarName: TEdit;
    pnlPersistent: TPanel;
    cbxVarPersistent: TCheckBox;
    pnlValor: TPanel;
    edtVarValue: TEdit;
    pnlDescricao: TPanel;
    edtVarDesc: TEdit;
    pnlVarCampo: TPanel;
    pnlDataset: TPanel;
    pnlDtsName: TPanel;
    edtDtsName: TEdit;
    pnlMasterSource: TPanel;
    pnlMasterFields: TPanel;
    pnlCacheSize: TPanel;
    pnlSQL: TPanel;
    cbbMasterDts: TwwDBComboBox;
    cdgMasterFields: TwwDBComboDlg;
    speCacheSize: TwwDBSpinEdit;
    cdgSQL: TwwDBComboDlg;
    actNewDataset: TAction;
    NovoDataset1: TMenuItem;
    pagBottomArea: TPageControl;
    tabCodigo: TTabSheet;
    CodeArea: TSynEdit;
    tabOutput: TTabSheet;
    OutputBox: TRichEdit;
    tabResultSet: TTabSheet;
    wwDBGrid1: TwwDBGrid;
    wwDBNavigator1: TwwDBNavigator;
    wwDBNavigator1First: TwwNavButton;
    wwDBNavigator1PriorPage: TwwNavButton;
    wwDBNavigator1Prior: TwwNavButton;
    wwDBNavigator1Next: TwwNavButton;
    wwDBNavigator1NextPage: TwwNavButton;
    wwDBNavigator1Last: TwwNavButton;
    wwDBNavigator1Insert: TwwNavButton;
    wwDBNavigator1Delete: TwwNavButton;
    wwDBNavigator1Edit: TwwNavButton;
    wwDBNavigator1Post: TwwNavButton;
    wwDBNavigator1Cancel: TwwNavButton;
    wwDBNavigator1Refresh: TwwNavButton;
    tbrCodeBar: TToolBar;
    btnApply: TToolButton;
    btnCancel: TToolButton;
    btnRun: TToolButton;
    btnTest: TToolButton;
    actCancelCode: TAction;
    actOkCode: TAction;
    actRun: TAction;
    actTestCode: TAction;
    lbObjectName: TfcLabel;
    tabPropriedades: TTabSheet;
    TabsImageList: TImageList;
    pnlPropsBkg: TPanel;
    pagProps: TPageControl;
    tabPropSQLOperation: TTabSheet;
    pnlPropsSQLOperation: TPanel;
    pnlSQLOpName: TPanel;
    edtSQLOpName: TEdit;
    pnlSQLOpConnection: TPanel;
    pnlSQLOpPrepareCommand: TPanel;
    cbbSQLOpDBConnection: TwwDBComboBox;
    cbxSQLPropPrepareCommand: TCheckBox;
    tabPropPasOperation: TTabSheet;
    pnlPropPasOperation: TPanel;
    pnlPropPasOpName: TPanel;
    edtPropPasOpName: TEdit;
    actRunStructure: TAction;
    btnRunStructure: TToolButton;
    btnSave: TToolButton;
    btnLoadStructure: TToolButton;
    btnS1: TToolButton;
    btnClear: TToolButton;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    XMLDocument1: TXMLDocument;
    pnlDtsDBC: TPanel;
    cbbDtsDBC: TwwDBComboBox;
    cbbVarDts: TwwDBComboBox;
    procedure actPasObjectExecute(Sender: TObject);
    procedure actSQLObjectExecute(Sender: TObject);
    procedure actTransObjectExecute(Sender: TObject);
    procedure actClientCursorExecute(Sender: TObject);
    procedure MainDrawAreaMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure MainDrawAreaCreateItem(Sender: TdxCustomFlowChart;
      Item: TdxFcItem);
    procedure actSubStructureExecute(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure actStartPointExecute(Sender: TObject);
    procedure actEndPointExecute(Sender: TObject);
    procedure actSwitchExecute(Sender: TObject);
    procedure actForExecute(Sender: TObject);
    procedure actWhileExecute(Sender: TObject);
    procedure actNudgeUpExecute(Sender: TObject);
    procedure actNudgeDownExecute(Sender: TObject);
    procedure actNudgeLeftExecute(Sender: TObject);
    procedure actNudgeRightExecute(Sender: TObject);
    procedure actDeleteExecute(Sender: TObject);
    procedure actAlignVExecute(Sender: TObject);
    procedure actAlignHExecute(Sender: TObject);
    procedure FormKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure actEventConnectionExecute(Sender: TObject);
    procedure actDependencyConnectionExecute(Sender: TObject);
    procedure MainDrawAreaChange(Sender: TdxCustomFlowChart;
      Item: TdxFcItem);
    procedure MainDrawAreaMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure actNewVarExecute(Sender: TObject);
    procedure lbxVarsChange(Sender: TObject; OldSelItemIndex,
      SelItemIndex: Integer);
    procedure cbxVarPersistentExit(Sender: TObject);
    procedure lbxVarsClick(Sender: TObject);
    procedure edtVarDescKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure actControlConnectionExecute(Sender: TObject);
    procedure actConditionalConnectionExecute(Sender: TObject);
    procedure actNewDBConnectionExecute(Sender: TObject);
    procedure cdgConnectionStringCustomDlg(Sender: TObject);
    procedure speDBCTimeOutKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure cbxDBCClientSideClick(Sender: TObject);
    procedure lbxDBConnectionsChange(Sender: TObject; OldSelItemIndex,
      SelItemIndex: Integer);
    procedure actNewDatasetExecute(Sender: TObject);
    procedure cdgMasterFieldsCustomDlg(Sender: TObject);
    procedure edtDtsNameKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure lbxDatasetsChange(Sender: TObject; OldSelItemIndex,
      SelItemIndex: Integer);
    procedure edtDtsNameExit(Sender: TObject);
    procedure actCancelCodeExecute(Sender: TObject);
    procedure actOkCodeExecute(Sender: TObject);
    procedure actOkCodeUpdate(Sender: TObject);
    procedure CodeAreaEnter(Sender: TObject);
    procedure CodeAreaExit(Sender: TObject);
    procedure pagBottomAreaChange(Sender: TObject);
    procedure pagPropsChange(Sender: TObject);
    procedure edtSQLOpNameKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure edtSQLOpNameExit(Sender: TObject);
    procedure actRunStructureExecute(Sender: TObject);
    procedure cdgSQLCustomDlg(Sender: TObject);
    procedure btnSaveClick(Sender: TObject);
    procedure btnLoadStructureClick(Sender: TObject);
    procedure btnClearClick(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure cbbDtsDBCDropDown(Sender: TObject);
    procedure cbbMasterDtsDropDown(Sender: TObject);  private
    FObjClass: TObjClass;
    FOprType: TOprType;
    FStructType: TStructType;
    FSuperStructure: TICEStructure;
    FChangedClass: TObjClass;
    FInserting: Boolean;  //Utilizado na manutenção de listas e inspectors
    FISISInspectorControler: TISISInspectorControler;
    FISISListManager: TISISListManager;
    FISISObjectManager: TISISObjectManager;
    procedure doDrawObject(X,Y: Integer);
    procedure GetActiveScript(Var Txt: String; Var Obj: TICEObject);
    procedure FillTxtWithSelection(Var Txt: TStringList);
    procedure ResetButtonsState(aPnl: TPanel);
    procedure SendDBConnectionToList(DBC: TICEDBConnection);
    procedure UpdateCodeVisible;
    { Private declarations }
  public
    procedure EditMasterFields(Var aDataset: TADODataset; MasterDts: TADODataset);
    property ObjClass: TObjClass read FObjClass write FObjClass;
    property OprType: TOprType read FOprType write FOprType;
    property StructType: TStructType read FStructType write FStructType;
    property SuperStructure: TICEStructure read FSuperStructure write
        FSuperStructure;
    property ChangedClass: TObjClass read FChangedClass write FChangedClass;
    property Inserting: Boolean read FInserting write FInserting;
    { Public declarations }
  end;


var
  ISISForm: TISISForm;

implementation

uses Math, _dlgOperation, _dlgEventConnection, _dlgDepConnection, _dlgVar,
  _dlgDynChoice, _dlgForLoop, _dlgWhileLoop, _dlgConControl,
  _dlgConConditional, _dlgDBConnection, _dlgDataset, _dlgSQLOperation,
  _dlgDataTransport;

{$R *.dfm}

/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////           Métodos e Eventos do Form                   /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//Inicialização do form
procedure TISISForm.FormCreate(Sender: TObject);
begin
  FISISInspectorControler:= TISISInspectorControler.Create;
  FISISObjectManager:= TISISObjectManager.Create;
  FISISListManager:= TISISListManager.Create;

  pagTools.ActivePageIndex:= 0;
  pagBottomArea.ActivePageIndex:= 0;
  Inserting:= False;

  ObjClass:= clsNone;
  StructType:= stNone;
  OprType:= otNone;

  SuperStructure:= TICEStructure.Create(Nil, MainDrawArea, 'SuperStructure');
  SuperStructure.ICEPersistence:= TICEXMLPersistence.Create(SuperStructure);

  olbToolBar.ActivePage:= btnOperations;

  Randomize;

  actCancelCodeExecute(nil);
end;

/////////////////////////////////////////////////////////////////////////////////
//MouseDown
procedure TISISForm.MainDrawAreaMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
  Ht: TdxfcHitTest;
begin

  Ht:= MainDrawArea.GetHitTestAt(X,Y);

  //Limpa a seleção se o hittest for nulo
  if Ht = [htNowhere] then
    MainDrawArea.ClearSelection
  else if (MainDrawArea.SelCount = 1) then begin //só envia dados caso apenas um obj esteja selecionado
    if (Ht = [htOnObject, htByObject]) then begin
      if Button = mbLeft then begin
        //Altera as páginas do inspector de acordo com o objeto selecionado
        if TISISObject(MainDrawArea.SelectedObject).ICEObject is TICESqlOperation then begin
          pagProps.ActivePage:= tabPropSQLOperation;
          if (ssDouble in Shift) then begin
            //Chama editores especializados
            FISISObjectManager.EditSQLObject;
          end;
        end else if TISISObject(MainDrawArea.SelectedObject).ICEObject is TICEPasOperation then begin
          pagProps.ActivePage:= tabPropPasOperation;
          if (ssDouble in Shift) then begin
            //Chama editores especializados
            FISISObjectManager.EditPasObject;
          end;
        end else
          pagProps.ActivePage:= Nil;

        pagPropsChange(nil);
      end;

    end else if (Ht = [htOnConnection]) then begin
      //Envia propriedades da conexão para o inspector

    end;
  end else begin
    pagProps.ActivePage:= Nil;
  end;


  //cria objetos
  if ObjClass in [clsOperation, clsLoop, clsChoice, clsPseudoState] then begin
    doDrawObject(X,Y);
  end;

  //Retorna todos os botões de dois estados ao estado normal
  ResetButtonsState(pnlOperations);
  ResetButtonsState(pnlStructs);

  //Atualiza a área de código
  actCancelCodeExecute(nil);
  
end;

/////////////////////////////////////////////////////////////////////////////////
//MouseUp
procedure TISISForm.MainDrawAreaMouseUp(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
var
  i: Integer;
begin
  //Atualiza a área de código
  actCancelCodeExecute(nil);

  for i:= 0 to MainDrawArea.SelectedConnectionCount -1 do begin
    if TISISConnection(MainDrawArea.SelectedConnections[i]).IsChanged then begin
      TISISConnection(MainDrawArea.SelectedConnections[i]).IsChanged:= False;
      TISISConnection(MainDrawArea.SelectedConnections[i]).ICEConnection.UpdateObject;
    end;
  end;
end;

/////////////////////////////////////////////////////////////////////////////////
//Form KeyUp
procedure TISISForm.FormKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  //tratamento de deleção de componentes
  if Self.ActiveControl = MainDrawArea then begin
      if (key = VK_DELETE) then
        actDeleteExecute(nil)
  end;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnCreateItem de MainDrawArea
procedure TISISForm.MainDrawAreaCreateItem(Sender: TdxCustomFlowChart;
  Item: TdxFcItem);
begin
  //impede a criação acidental de conexões automáticas
  if item is TdxFcConnection then
      if ObjClass <> clsConnection then abort;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnChange de MainDrawArea
procedure TISISForm.MainDrawAreaChange(Sender: TdxCustomFlowChart;
  Item: TdxFcItem);
begin
  if Item is TISISConnection then
    TISISConnection(Item).IsChanged:= True
  else
    TISISObject(Item).IsChanged:= True;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnChange de pagBottomArea
procedure TISISForm.pagBottomAreaChange(Sender: TObject);
begin
  if pagBottomArea.ActivePage = tabPropriedades then begin
    pagPropsChange(nil);
  end;
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
/////////////////////////////////////////////////////////////////////////////////
/////////////                  Área de Código                       /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//Ação de cancelamento da área de código.
procedure TISISForm.actCancelCodeExecute(Sender: TObject);
var
  Obj: TICEObject;
  Txt: String;
begin
  UpdateCodeVisible;

  CodeArea.Lines.Clear;

  GetActiveScript(Txt, Obj);

  If Assigned(Obj) then begin
    CodeArea.Enabled:= True;
    CodeArea.ReadOnly:= False;

    if (Obj is TICEPasOperation) then begin
      CodeArea.Highlighter:= SynPasSyn;
      lbObjectName.Caption:=' Pas Operation '+Obj.Name+' ';
    end else if (Obj is TICESqlOperation)  then begin
      CodeArea.Highlighter:= SynSQLSyn;
      lbObjectName.Caption:=' SQL Command '+Obj.Name+' ';
    end;

    CodeArea.Lines.Text:= Txt;

  end else begin
    CodeArea.Enabled:= False;
    CodeArea.ReadOnly:= True;
    lbObjectName.Caption:=' Desabilitado ';
  end;

end;

/////////////////////////////////////////////////////////////////////////////////
//Ação de confirmação da área de código
procedure TISISForm.actOkCodeExecute(Sender: TObject);
var
  Obj: TICEObject;
  Txt: String;
begin

  GetActiveScript(Txt, Obj);

  If Assigned(Obj) then begin

    Txt:= CodeArea.Lines.Text;

    if (Obj is TICEPasOperation) then
      TICEPasOperation(Obj).Script:= Txt
    else if (Obj is TICESqlOperation)  then
      TICESqlOperation(Obj).SQLCommand:= Txt;

  end;

end;

/////////////////////////////////////////////////////////////////////////////////
//Update das ações de Confirmação e Cancelamento
procedure TISISForm.actOkCodeUpdate(Sender: TObject);
begin
  TAction(Sender).Enabled:= CodeArea.Enabled;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnEnter da área de código
procedure TISISForm.CodeAreaEnter(Sender: TObject);
begin
  CodeArea.CaretX:= 0;
  CodeArea.CaretY:= 0;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnExit da área de código
procedure TISISForm.CodeAreaExit(Sender: TObject);
begin
  actOkCode.Execute;
end;

/////////////////////////////////////////////////////////////////////////////////
//Atualização de visibilidade da área de código
procedure TISISForm.UpdateCodeVisible;
var
  Obj: TICEObject;
  Txt: String;
begin

  GetActiveScript(Txt, Obj);
  if Assigned(Obj) then
    tabCodigo.Visible:= (Obj is TICESqlOperation) or (Obj is TICEPasOperation)
  else
    tabCodigo.Visible:= false;
  tabCodigo.TabVisible:= tabCodigo.Visible;

end;

/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////              Barra de Ferramentas                     /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

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
  { TODO 3: teste para ver o painel ativo e deletar objetos não visuais }

  if MainDrawArea.SelectedObject is TISISObject then
    if TISISObject(MainDrawArea.SelectedObject).ICEObject is TICEStartPoint
    then
      Raise exception.Create('O ponto de início não pode ser excluído.');

  While MainDrawArea.SelectedConnectionCount > 0 do
    if MainDrawArea.SelectedConnections[0] is TISISConnection then
      TISISConnection(MainDrawArea.SelectedConnections[0]).ICEConnection.Free;

  While MainDrawArea.SelCount > 0 do
    if MainDrawArea.SelectedObjects[0] is TISISObject then
      TISISObject(MainDrawArea.SelectedObjects[0]).ICEObject.Free;

end;

/////////////////////////////////////////////////////////////////////////////////
//Alinhamento Vertical
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
      for j:= 0 to MainDrawArea.SelectedObjects[i].ObjectCount -1 do begin
        MainDrawArea.SelectedObjects[i].Objects[j].Left:= MainDrawArea.SelectedObjects[i].Objects[j].Left +(RefX - X);
        TISISObject(MainDrawArea.SelectedObjects[i].Objects[j]).ICEObject.UpdateObject;
      end;
  end;

end;

/////////////////////////////////////////////////////////////////////////////////
//Alinhamento Horizontal
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
      for j:= 0 to MainDrawArea.SelectedObjects[i].ObjectCount -1 do begin
        MainDrawArea.SelectedObjects[i].Objects[j].Top:= MainDrawArea.SelectedObjects[i].Objects[j].Top +(RefY - Y);
        TISISObject(MainDrawArea.SelectedObjects[i].Objects[j]).ICEObject.UpdateObject;
      end;
  end;

end;

/////////////////////////////////////////////////////////////////////////////////
//Execução da Estrutura
procedure TISISForm.actRunStructureExecute(Sender: TObject);
var
  i: Integer;
begin
  pagBottomArea.ActivePage:= tabOutput;

  OutputBox.Clear;


  SuperStructure.Execute;

  for i:= 0 to SuperStructure.EventLog.Count -1 do
    OutputBox.Lines.Add(SuperStructure.EventLog[i]);

end;


/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////                    Objetos                            /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

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
//Seleciona o stStartPoint como tipo de objeto a ser criado
procedure TISISForm.actStartPointExecute(Sender: TObject);
begin
  StructType:= stStartPoint;
  ObjClass:= clsPseudoState;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stEndPoint como tipo de objeto a ser criado
procedure TISISForm.actEndPointExecute(Sender: TObject);
begin
  StructType:= stEndPoint;
  ObjClass:= clsPseudoState;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stDynChoice como tipo de objeto a ser criado
procedure TISISForm.actSwitchExecute(Sender: TObject);
begin
  FStructType:= stDynChoice;
  FObjClass:= clsChoice;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stFor como tipo de objeto a ser criado
procedure TISISForm.actForExecute(Sender: TObject);
begin
  FStructType:= stFor;
  FObjClass:= clsLoop;
end;

/////////////////////////////////////////////////////////////////////////////////
//Seleciona o stFor como tipo de objeto a ser criado
procedure TISISForm.actWhileExecute(Sender: TObject);
begin
  FStructType:= stWhile;
  FObjClass:= clsLoop;
end;

/////////////////////////////////////////////////////////////////////////////////
//Desenha objetos
procedure TISISForm.doDrawObject(X,Y: Integer);
var
  Obj: TICEShapedObject;
  aName: String;
begin
  { TODO 2 : controle de existência de objetos dependentes (variáveis, datasets, etc) }
  { TODO 1 : Diálogos de criação dos objetos }
  { TODO 1 : Criação de métodos individuais dos objetos }

  Obj:= Nil;

  if (ObjClass in [clsOperation, clsPseudoState])
  then begin
    if OprType = otSQL then begin

      Obj:= FISISObjectManager.CreateSQLOperation(X,Y);

    end else if OprType = otDataTransport then begin

      Obj:= FISISObjectManager.CreateDataTransport(X,Y);

    end else begin

      dlgOperation:= TdlgOperation.Create(Self);
      if dlgOperation.Execute(aName) = mrOk then
        Obj:= SuperStructure.CreateObject(X,Y, aName, ObjClass, OprType, StructType);
      dlgOperation.Free;

    end;
  end else if (ObjClass = clsChoice) then begin

    Obj:= FISISObjectManager.CreateDynChoice(X,Y);

  end else if (ObjClass = clsLoop) then begin
    case StructType of
      stFor: begin

        Obj:= FISISObjectManager.CreateForLoop(X,Y);

      end;
      stWhile: begin

        Obj:= FISISObjectManager.CreateWhileLoop(X,Y);

      end;
    end;
  end;

  MainDrawArea.ClearSelection;
  if assigned(Obj) then
    MainDrawArea.SelectedObject:= Obj.ISISObject;

  ObjClass:= clsNone;
  OprType:= otNone;
  StructType:= stNone;

end;

/////////////////////////////////////////////////////////////////////////////////
//Retorna o objeto ativo e o script correspondente ou Nil e Nil
procedure TISISForm.GetActiveScript(Var Txt: String; Var Obj: TICEObject);
begin
  Txt:= '';
  Obj:= Nil;

  if MainDrawArea.SelCount = 1 then begin

    if MainDrawArea.SelectedObject is TISISObject then
      Obj:= TISISObject(MainDrawArea.SelectedObject).ICEObject
    else exit;

    if (Obj is TICEPasOperation)  or (Obj is TICESqlOperation) then begin

      if (Obj is TICEPasOperation) then
        Txt:= TICEPasOperation(Obj).Script
      else if (Obj is TICESqlOperation)  then
        Txt:= TICESqlOperation(Obj).SQLCommand;

    end;
  end;

end;


/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////                   Conexões                            /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//Cria conexões de evento
procedure TISISForm.actEventConnectionExecute(Sender: TObject);
var
  EventType: TEventType;
  Txt: TStringList;
  Src, Dst: TICEShapedObject;
begin
  if MainDrawArea.SelCount < 2 then exit;

  FObjClass:= clsConnection;

  Txt:= TStringList.Create;

  FillTxtWithSelection(Txt);

  dlgEventConnection:= TdlgEventConnection.Create(self);

  if dlgEventConnection.Execute(Txt, EventType, Src, Dst) = mrOk then
    TICEEventConnection.Create(SuperStructure, EventType, Dst, Src);

  dlgEventConnection.Free;

end;

/////////////////////////////////////////////////////////////////////////////////
//Cria conexões de dependência
procedure TISISForm.actDependencyConnectionExecute(Sender: TObject);
var
  aStatus: TICEObjectStatus;
  Txt: TStringList;
  Src, Dst: TICEShapedObject;
begin
  if MainDrawArea.SelCount < 2 then exit;

  FObjClass:= clsConnection;

  Txt:= TStringList.Create;

  FillTxtWithSelection(Txt);

  dlgDepConnection:= TdlgDepConnection.Create(Self);

  if dlgDepConnection.Execute(Txt, aStatus, Src, Dst) = mrOk then
    TICEDependencyConnection.Create(SuperStructure,Dst,Src,aStatus);

  dlgDepConnection.Free;

end;

/////////////////////////////////////////////////////////////////////////////////
//Cria conexões de controle
procedure TISISForm.actControlConnectionExecute(Sender: TObject);
var
  Txt: TStringList;
  Src, Dst: TICEShapedObject;
begin
  if MainDrawArea.SelCount < 2 then exit;

  FObjClass:= clsConnection;

  Txt:= TStringList.Create;

  FillTxtWithSelection(Txt);

  dlgConControl:= TdlgConControl.Create(self);

  if dlgConControl.Execute(Txt, Src, Dst) = mrOk then
    TICEControlConnection.Create(SuperStructure, Dst, Src);

  dlgConControl.Free;
end;

/////////////////////////////////////////////////////////////////////////////////
//Cria conexões condicionais
procedure TISISForm.actConditionalConnectionExecute(Sender: TObject);
var
  Objs: TStringList;
  Src, Dst: TICEShapedObject;
  aValue: Variant;
  aElseValue: Boolean;
begin
  Objs:= TStringList.Create;

  FillTxtWithSelection(Objs);

  dlgConConditional:= TdlgConConditional.Create(Self);

  if dlgConConditional.Execute(Objs,Src,Dst, aValue, aElseValue) = mrOk then begin
    TICEConditionalConnection.Create(SuperStructure,Dst,Src, aValue, aElseValue);

  end;
end;

/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////                   Variáveis                           /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//Cria Variáveis
procedure TISISForm.actNewVarExecute(Sender: TObject);
var
  aName: String;
begin
  dlgVar:= TdlgVar.Create(Self);
  try
    if dlgVar.Execute(aName) = mrOk then begin
      TICEVar.Create(SuperStructure,aName);
      Inserting:= True;
      lbxVars.Items.Add(aName);
      lbxVars.ItemIndex:= lbxVars.Count -1;
      FISISInspectorControler.VarToInspector;
      Inserting:= False;
    end;
  finally
    dlgVar.Free;
  end;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnKeyUp dos controles de edição de variável
procedure TISISForm.edtVarDescKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  if key = VK_Return then
    FISISInspectorControler.InspectorToVar;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnChange da lista de variáveis
procedure TISISForm.lbxVarsChange(Sender: TObject; OldSelItemIndex,
  SelItemIndex: Integer);
begin
  if Inserting then
    Inserting:= False
  else
    if lbxVars.Count > 0 then
      FISISInspectorControler.VarToInspector
    else
      FISISInspectorControler.ClearVarInspector;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnExit dos controles de edição de variáveis
procedure TISISForm.cbxVarPersistentExit(Sender: TObject);
begin
  FISISInspectorControler.InspectorToVar;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnClick da lista de variáveis
procedure TISISForm.lbxVarsClick(Sender: TObject);
begin
  if lbxVars.Count > 0 then
    FISISInspectorControler.VarToInspector;
end;


/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////                   DBConnections                       /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//Cria Conexões de banco
procedure TISISForm.actNewDBConnectionExecute(Sender: TObject);
var
  aConnection: TADOConnection;
  DBC: TICEDBConnection;
begin
  dlgDBConnection:= TdlgDBConnection.Create(Self);
  aConnection:= Nil;
  try
    if dlgDBConnection.Execute(aConnection) = mrOk then begin
      DBC:= TICEDBConnection.Create(SuperStructure, aConnection);
      SendDBConnectionToList(DBC);
    end;
  finally
    dlgDBConnection.Free;
  end;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnCustomDialog de cdgConnectionString
procedure TISISForm.cdgConnectionStringCustomDlg(Sender: TObject);
begin
  FISISObjectManager.EditConnectionString(lbxDBConnections.Items[lbxDBConnections.ItemIndex]);
end;

/////////////////////////////////////////////////////////////////////////////////
//OnKeyUp dos controles de edição de variável
procedure TISISForm.speDBCTimeOutKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  if key = VK_Return then
    FISISInspectorControler. InspectorToDBC;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnClick do controle de ClientSide do inspector
procedure TISISForm.cbxDBCClientSideClick(Sender: TObject);
begin
  FISISInspectorControler.DBCToInspector;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnChange da lista de conexões
procedure TISISForm.lbxDBConnectionsChange(Sender: TObject;
  OldSelItemIndex, SelItemIndex: Integer);
begin
  if Inserting then
    Inserting:= False
  else
    if lbxDBConnections.Count > 0 then
      FISISInspectorControler.DBCToInspector
    else
      FISISInspectorControler.ClearDBCInspector;
end;

/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////                   Datasets                            /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//Novo Dataset
procedure TISISForm.actNewDatasetExecute(Sender: TObject);
var
  aDataset: TADODataset;
  DBCName, MasterName, aSQL, MasterFields: String;
begin
  dlgDataset:= TdlgDataset.Create(self);
  if dlgDataset.Execute(aDataset, MasterName, DBCName, aSQL, MasterFields) = mrOk then begin
    with TICEDataset.Create(SuperStructure,aDataset, DBCName) do begin
      MasterDSName:= MasterName;
      ICEDBCName:= DBCName;
      SQL:= aSQL;
      MasterFields:= MasterFields;
    end;
    Inserting:= True;
    lbxDatasets.Items.Add(aDataset.Name);
    lbxDatasets.ItemIndex:= lbxDatasets.Count -1;
    Inserting:= False;
    FISISInspectorControler.DatasetToInspector;
  end;
  dlgDataset.Free;
end;

/////////////////////////////////////////////////////////////////////////////////
//Edição de MasterFields
procedure TISISForm.EditMasterFields(Var aDataset: TADODataset; MasterDts:
    TADODataset);
var
  IFN, MF: TStringList;
  PL: TPairList;
  I: Integer;
begin
  inherited;

  if ADataset.Active then
    ADataset.Close;

  if not assigned(MasterDts) then
    exit;

  IFN:= TStringList.Create;
  MF:= TStringList.Create;

  PL:= TPairList.Create;

  if ADataset.IndexFieldNames <> '' then begin

    TICESQLUtil.GetKeyFromStr(ADataset.IndexFieldNames, IFN);
    TICESQLUtil.GetKeyFromStr(ADataset.MasterFields, MF);

    For i:= 0 to MF.Count -1 do
      PL.AddPair(IFN[i],MF[i]);

  end;

  dlgLookupPairs:= TdlgLookupPairs.Create(Self);

  { TODO : LookupPairs.Execute }
  //dlgLookupPairs.ExecuteNL(ADataset, MasterDts, PL);


  ADataset.IndexFieldNames:= '';
  ADataset.MasterFields:= '';

  For i:= 0 to PL.Count -1 do begin
    ADataset.IndexFieldNames:= ADataset.IndexFieldNames+PL.GetKey(i)+';';
    ADataset.MasterFields:= ADataset.MasterFields+PL.GetValue(i)+';';
  end;

  ADataset.IndexFieldNames:= Copy(ADataset.IndexFieldNames,1, Length(ADataset.IndexFieldNames) -1);
  ADataset.MasterFields:= Copy(ADataset.MasterFields,1, Length(ADataset.MasterFields) -1);

  dlgLookupPairs.Free;
  MF.Free;
  IFN.Free;
end;


/////////////////////////////////////////////////////////////////////////////////
//Edição de MasterFields
procedure TISISForm.cdgMasterFieldsCustomDlg(Sender: TObject);
var
  aDataset, Ds: TADODataset;
  aName: String;
begin
  aName:= lbxDatasets.Items[lbxDatasets.ItemIndex];
  aDataset:= SuperStructure.DatasetList.FindByName(aName).Dataset;

  if cbbMasterDts.Text = '' then
    exit;

  Ds:= SuperStructure.DatasetList.FindByName(aName).MasterDS.Dataset;

  EditMasterFields(aDataset, Ds);

  cdgMasterFields.Text:= aDataset.MasterFields;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnKeyUp dos componentes de edição
procedure TISISForm.edtDtsNameKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  if key = VK_Return then
    FISISInspectorControler.InspectorToDataset;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnChange da lista de datasets
procedure TISISForm.lbxDatasetsChange(Sender: TObject; OldSelItemIndex,
  SelItemIndex: Integer);
begin
  if Inserting then
    Inserting:= False
  else
    if lbxDatasets.Count > 0 then
      FISISInspectorControler.DatasetToInspector
    else
      FISISInspectorControler.ClearDatasetInspector;
end;

/////////////////////////////////////////////////////////////////////////////////
//Exit dos componentes de edição
procedure TISISForm.edtDtsNameExit(Sender: TObject);
begin
  FISISInspectorControler.DatasetToInspector;
end;

/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////                    Propriedades                       /////////////
/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//OnChange do paginador de propriedades
procedure TISISForm.pagPropsChange(Sender: TObject);
begin
  if pagProps.ActivePage = tabPropSQLOperation then begin
    cbbSQLOpDBConnection.Width:= edtSQLOpName.Width;
    FISISInspectorControler.SQLOperationToInspector;
  end else if pagProps.ActivePage = tabPropPasOperation then begin
    FISISInspectorControler.PasOperationToInspector;

  end;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnKeyUp dos controles de edição
procedure TISISForm.edtSQLOpNameKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  if Key = VK_Return then
    FISISInspectorControler.InspectorTOSQLOperation;
end;

/////////////////////////////////////////////////////////////////////////////////
//OnExit dos controles de edição
procedure TISISForm.edtSQLOpNameExit(Sender: TObject);
begin
  FISISInspectorControler.InspectorTOSQLOperation;
end;

procedure TISISForm.cdgSQLCustomDlg(Sender: TObject);
begin
  FISISObjectManager.EditDatasetSQL;
end;

procedure TISISForm.btnSaveClick(Sender: TObject);
begin
  if SaveDialog1.Execute then
    SuperStructure.ICEPersistence.SaveToFile(SaveDialog1.FileName);
end;

procedure TISISForm.btnLoadStructureClick(Sender: TObject);
begin
  if OpenDialog1.Execute then begin
    SuperStructure.ICEPersistence.LoadFromFile(OpenDialog1.FileName);
    FISISListManager.RefreshLists;
    FISISInspectorControler.RefreshInspector;
  end;
end;

procedure TISISForm.btnClearClick(Sender: TObject);
begin
  SuperStructure.Clear;
end;

/////////////////////////////////////////////////////////////////////////////////
//Carrega Txt com a lista de objetos selecionados
procedure TISISForm.FillTxtWithSelection(Var Txt: TStringList);
var
  i, Idx: Integer;
begin
  for i:= 0 to MainDrawArea.SelCount -1 do
    if not (Txt.Find(TISISObject(MainDrawArea.SelectedObjects[i]).ICEObject.Name, idx)) then
      Txt.Add(TISISObject(MainDrawArea.SelectedObjects[i]).ICEObject.Name);
end;

/////////////////////////////////////////////////////////////////////////////////
//Envia propriedades da Conexão para o Inspector
procedure TISISForm.SendDBConnectionToList(DBC: TICEDBConnection);
begin
  Inserting:= True;
  lbxDBConnections.Items.Add(DBC.Name);
  lbxDBConnections.ItemIndex:= lbxDBConnections.Count -1;
  FISISInspectorControler.DBCToInspector;
  Inserting:= False;
end;

/////////////////////////////////////////////////////////////////////////////////
//Limpeza de Inspector
procedure TISISInspectorControler.ClearDatasetInspector;
begin
  ISISForm.edtDtsName.Clear;
  ISISForm.cbbMasterDts.Clear;
  ISISForm.cdgMasterFields.Clear;
  ISISForm.speCacheSize.Clear;
  ISISForm.cdgSQL.Clear;
end;

/////////////////////////////////////////////////////////////////////////////////
//Limpa os dados do inspector
procedure TISISInspectorControler.ClearDBCInspector;
begin
  ISISForm.edtDBCName.Text:= '';
  ISISForm.speDBCTimeOut.Text:= '';
  ISISForm.cbxDBCClientSide.Checked:= False;
  ISISForm.cdgConnectionString.Text:= '';
end;

/////////////////////////////////////////////////////////////////////////////////
//Limpa os dados do inspector
procedure TISISInspectorControler.ClearVarInspector;
begin
  ISISForm.edtVarName.Text:= '';
  ISISForm.edtVarValue.Text:= '';
  ISISForm.edtVarDesc.Text:= '';
  ISISForm.cbxVarPersistent.Checked:= False;
end;

/////////////////////////////////////////////////////////////////////////////////
//Atualiza os dados do inspector com as propriedades do dataset
procedure TISISInspectorControler.DatasetToInspector;
var
  aName: String;
  aDataset: TICEDataset;
begin
  aName:= ISISForm.lbxDatasets.Items[ISISForm.lbxDatasets.ItemIndex];
  aDataset:= ISISForm.SuperStructure.DatasetList.FindByName(aName);
  ISISForm.edtDtsName.Text:= aDataset.Name;

  if assigned(aDataset.MasterDS) then
    ISISForm.cbbMasterDts.Text:= aDataset.MasterDS.Name
  else
    ISISForm.cbbMasterDts.Text:= '';

  ISISForm.cdgMasterFields.Text:= aDataset.Dataset.MasterFields;
  ISISForm.speCacheSize.Value:= aDataset.CacheSize;
  ISISForm.cdgSQL.Text:= aDataset.SQL;
  ISISForm.cbbDtsDBC.Text:= aDataset.ICEDBCName;
end;

/////////////////////////////////////////////////////////////////////////////////
//Envia propriedades da Conexão para o Inspector
procedure TISISInspectorControler.DBCToInspector;
var
  aConnection: TICEDBConnection;
  aName: String;
begin
  aName:= ISISForm.lbxDBConnections.Items[ISISForm.lbxDBConnections.ItemIndex];
  aConnection:= ISISForm.SuperStructure.DBConnectionList.FindByName(aName);

  ISISForm.edtDBCName.Text:= aName;
  ISISForm.speDBCTimeOut.Value:= aConnection.DBConnection.CommandTimeout;
  ISISForm.cbxDBCClientSide.Checked:= (aConnection.DBConnection.CursorLocation = clUseClient);
  ISISForm.cdgConnectionString.Text:= aConnection.DBConnection.ConnectionString;
end;

/////////////////////////////////////////////////////////////////////////////////
//Atualiza as propriedades do dataset com os dados do inspector
procedure TISISInspectorControler.InspectorToDataset;
var
  aName: String;
  aDataset: TICEDataset;
begin
  aName:= ISISForm.lbxDatasets.Items[ISISForm.lbxDatasets.ItemIndex];
  aDataset:= ISISForm.SuperStructure.DatasetList.FindByName(aName);

  if (ISISForm.edtDtsName.Text <> aName) and (not ISISForm.Inserting) then begin
    if ISISForm.SuperStructure.ValidateName(ISISForm.edtDtsName.Text) then begin
      aDataset.Name:= ISISForm.edtDtsName.Text;
      ISISForm.lbxDatasets.Items[ISISForm.lbxDatasets.ItemIndex]:= ISISForm.edtDtsName.Text;
    end;
  end;

  aDataset.MasterDSName:= ISISForm.cbbMasterDts.Text;
  aDataset.CacheSize:= Trunc(ISISForm.speCacheSize.Value);
  aDataset.ICEDBCName:= ISISForm.cbbDtsDBC.Text;
  aDataset.SQL:= ISISForm.cdgSQL.Text;
end;

/////////////////////////////////////////////////////////////////////////////////
//Atualiza propriedades da Conexão com o Inspector
procedure TISISInspectorControler.InspectorToDBC;
var
  aConnection: TICEDBConnection;
  aName: String;
begin
  aName:= ISISForm.lbxDBConnections.Items[ISISForm.lbxDBConnections.ItemIndex];
  aConnection:= ISISForm.SuperStructure.DBConnectionList.FindByName(aName);

  if (ISISForm.edtDBCName.Text <> aName) and (not ISISForm.Inserting) then begin
    if ISISForm.SuperStructure.ValidateName(ISISForm.edtDBCName.Text) then begin
      aConnection.Name:= ISISForm.edtDBCName.Text;
      ISISForm.lbxDBConnections.Items[ISISForm.lbxDBConnections.ItemIndex]:= ISISForm.edtDBCName.Text;
    end;
  end;

  aConnection.DBConnection.CommandTimeout:= Trunc(ISISForm.speDBCTimeOut.Value);
  aConnection.DBConnection.ConnectionTimeout:= Trunc(ISISForm.speDBCTimeOut.Value);

  if ISISForm.cbxDBCClientSide.Checked then
    aConnection.DBConnection.CursorLocation:= clUseClient
  else
    aConnection.DBConnection.CursorLocation:= clUseServer;

  aConnection.DBConnection.ConnectionString:= ISISForm.cdgConnectionString.Text;
end;

/////////////////////////////////////////////////////////////////////////////////
//Envio das propriedades do Inspector para objetos PasOperation
procedure TISISInspectorControler.InspectorToPasOperation;
var
  PasOp: TICEPasOperation;
begin
  PasOp:= TICEPasOperation(TISISObject(ISISForm.MainDrawArea.SelectedObject).ICEObject);
  PasOp.Name:= ISISForm.edtPropPasOpName.Text;
end;

/////////////////////////////////////////////////////////////////////////////////
//Envio das propriedades do Inspector para objetos SQLOperation
procedure TISISInspectorControler.InspectorTOSQLOperation;
Var
  SqlObj: TICESqlOperation;
begin
  SqlObj:= TICESqlOperation(TISISObject(ISISForm.MainDrawArea.SelectedObject).ICEObject);

  SqlObj.Name:= ISISForm.edtSQLOpName.Text;
  SqlObj.ICEDBConnection.Name:= ISISForm.cbbSQLOpDBConnection.Text;
  SqlObj.PrepareCommand:= ISISForm.cbxSQLPropPrepareCommand.Checked;
end;

/////////////////////////////////////////////////////////////////////////////////
//Envia conteúdo do inspector para as variáveis
procedure TISISInspectorControler.InspectorToVar;
var
  ICEVar: TICEVar;
  aName: String;
begin
  aName:= ISISForm.lbxVars.Items[ISISForm.lbxVars.ItemIndex];
  ICEVar:= ISISForm.SuperStructure.VarList.FindByName(aName);
  ICEVar.Value:= ISISForm.edtVarValue.Text;
  ICEVar.Description:= ISISForm.edtVarDesc.Text;
  ICEVar.Persistent:= ISISForm.cbxVarPersistent.Checked;
  if (ISISForm.edtVarName.Text <> aName) and (not ISISForm.Inserting) then begin
    if ISISForm.SuperStructure.ValidateName(ISISForm.edtVarName.Text) then begin
      IceVar.Name:= ISISForm.edtVarName.Text;
      ISISForm.lbxVars.Items[ISISForm.lbxVars.ItemIndex]:= ISISForm.edtVarName.Text;
    end;
  end;
end;

/////////////////////////////////////////////////////////////////////////////////
/////////////                    Pas Operation                      /////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//Envio das propriedades de objetos PasOperation para o Inspector
procedure TISISInspectorControler.PasOperationToInspector;
var
  PasOp: TICEPasOperation;
begin
  PasOp:= TICEPasOperation(TISISObject(ISISForm.MainDrawArea.SelectedObject).ICEObject);
  ISISForm.edtPropPasOpName.Text:= PasOp.Name;
end;

procedure TISISInspectorControler.RefreshInspector;
begin
  if ISISForm.lbxDatasets.Items.Count > 0 then begin
    ISISForm.lbxDatasets.ItemIndex:= 0;
    DatasetToInspector;
  end;

  if ISISForm.lbxDBConnections.Items.Count > 0 then begin
    ISISForm.lbxDBConnections.ItemIndex:= 0;
    DBCToInspector;
  end;

  if ISISForm.lbxVars.Items.Count > 0 then begin
    ISISForm.lbxVars.ItemIndex:= 0;
    VarToInspector;
  end;
end;

/////////////////////////////////////////////////////////////////////////////////
/////////////                    SQL Command                        /////////////
/////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////
//Envio das propriedades de objetos SQLOperation para o Inspector
procedure TISISInspectorControler.SQLOperationToInspector;
Var
  SqlObj: TICESqlOperation;
begin
  SqlObj:= TICESqlOperation(TISISObject(ISISForm.MainDrawArea.SelectedObject).ICEObject);
  ISISForm.edtSQLOpName.Text:= SqlObj.Name;
  ISISForm.cbbSQLOpDBConnection.Text:= SqlObj.ICEDBConnection.Name;
  ISISForm.cbxSQLPropPrepareCommand.Checked:= SqlObj.PrepareCommand;
end;

/////////////////////////////////////////////////////////////////////////////////
//Envia conteúdo das variáveis para o inspector
procedure TISISInspectorControler.VarToInspector;
var
  ICEVar: TICEVar;
  aName: String;
begin
  aName:= ISISForm.lbxVars.Items[ISISForm.lbxVars.ItemIndex];
  ICEVar:= ISISForm.SuperStructure.VarList.FindByName(aName);
  ISISForm.edtVarName.Text:= ICEVar.Name;
  ISISForm.edtVarValue.Text:= ICEVar.Value;
  ISISForm.edtVarDesc.Text:= ICEVar.Description;
  ISISForm.cbxVarPersistent.Checked:= ICEVar.Persistent;
end;

/////////////////////////////////////////////////////////////////////////////////
//Criação de operações DataTransport
function TISISObjectManager.CreateDataTransport(X,Y: Integer):
    TICEDataTransport;
var
  Txt: TStringList;
  aName: String;
  PL: TPairList;
  Dts1, Dts2: String;
begin
  Result:= Nil;

  Txt:= TStringList.Create;
  PL:= TPairList.Create;


  ISISForm.SuperStructure.ICELister.FillTxtWithDatasets(Txt);
  dlgDataTransport:= TdlgDataTransport.Create(ISISForm);
  if dlgDataTransport.Execute(aName, Txt, Dts1,Dts2, PL) = mrOk then begin
    Result:= TICEDataTransport(ISISForm.SuperStructure.CreateObject(X,Y,aName,clsOperation,otDataTransport,stNone));
    Result.SrcDataset:= ISISForm.SuperStructure.DatasetList.FindByName(Dts1);
    Result.DstDataset:= ISISForm.SuperStructure.DatasetList.FindByName(Dts2);
    Result.Correspondences.Assign(PL);
  end;
  dlgDataTransport.Free;
  Txt.Free;
end;

/////////////////////////////////////////////////////////////////////////////////
//Criação de Pontos de escolha dinâmica
function TISISObjectManager.CreateDynChoice(X,Y: Integer): TICEDynamicChoice;
var
  Txt: TStringList;
  aName: String;
  ICEVar: TICEVar;
begin
  Result:= Nil;

  dlgDynChoice:= TdlgDynChoice.Create(ISISForm);
  Txt:= TStringList.Create;

  ISISForm.SuperStructure.ICELister.FillTxtWithVars(Txt);

  if dlgDynChoice.Execute(Txt, aName, ICEVar) = mrOk then begin
    Result:= TICEDynamicChoice(ISISForm.SuperStructure.CreateObject(X,Y, aName, clsChoice, otNone, stDynChoice));
    Result.TestVar:= ICEVar;
  end;

  Txt.Free;
  dlgDynChoice.Free;

end;

/////////////////////////////////////////////////////////////////////////////////
//Criação de loops For
function TISISObjectManager.CreateForLoop(X,Y: Integer): TICEForLoop;
var
  Txt: TStringList;
  ICEVar: TICEVar;
  Max, Min: Double;
  aName: String;
begin
  Result:= Nil;

  dlgForLoop:= TdlgForLoop.Create(ISISForm);
  Txt:= TStringList.Create;

  ISISForm.SuperStructure.ICELister.FillTxtWithVars(Txt);

  if dlgForLoop.Execute(Txt, aName, ICEVar, Max, Min) = mrOk then begin
    Result:= TICEForLoop(ISISForm.SuperStructure.CreateObject(X,Y, aName, clsLoop, otNone, stFor));

    Result.Max:= Max;
    Result.Min:= Min;
    Result.LoopVar:= ICEVar;
  end;
  Txt.Free;
  dlgForLoop.Free;
end;

/////////////////////////////////////////////////////////////////////////////////
//Criação de operações pascal script
procedure TISISObjectManager.CreatePasOperation(X,Y: Integer);
begin
  // TODO -cMM: TISISForm.CreatePasObject default body inserted
end;

/////////////////////////////////////////////////////////////////////////////////
//Criação de operações SQL
function TISISObjectManager.CreateSQLOperation(X,Y: Integer): TICESqlOperation;
var
  Txt: TStringList;
  aName, ConName: String;
  B: Boolean;
begin
  Txt:= TStringList.Create;
  ISISForm.SuperStructure.ICELister.FillTxtWithDBConnections(Txt);
  result:= Nil;

  dlgSQLOperation:= TdlgSQLOperation.Create(ISISForm);
  if dlgSQLOperation.Execute(aName, Txt, ConName, B) = mrOk then begin
    Result:= TICESqlOperation(ISISForm.SuperStructure.CreateObject(X,Y, aName, clsOperation, otSQL, stNone));
    Result.ICEDBConnection:= ISISForm.SuperStructure.DBConnectionList.FindByName(ConName);
    Result.PrepareCommand:= B;
  end;

  dlgSQLOperation.Free;
  Txt.Free;
end;

/////////////////////////////////////////////////////////////////////////////////
//Criação de loops while
function TISISObjectManager.CreateWhileLoop(X,Y: Integer): TICEWhileLoop;
var
  Txt: TStringList;
  aName: String;
begin
  Result:= Nil;

  dlgWhileLoop:= TdlgWhileLoop.Create(ISISForm);
  Txt:= TStringList.Create;

  if dlgWhileLoop.Execute(aName, Txt, 'While') = mrOk then begin
    Result:= TICEWhileLoop(ISISForm.SuperStructure.CreateObject(X,Y, aName, clsLoop, otNone, stWhile));
    Result.TestCondition:= Txt.Text;
  end;
  dlgWhileLoop.Free;
  Txt.Free;
end;

/////////////////////////////////////////////////////////////////////////////////
//Chamada para a edição de ConnectionString do objeto ICEDBConnection
procedure TISISObjectManager.EditConnectionString(aName: String);
var
  aConnection: TICEDBConnection;
begin
  aConnection:= ISISForm.SuperStructure.DBConnectionList.FindByName(aName);
  ISISForm.cdgConnectionString.Text:= aConnection.EditConnection;
end;

/////////////////////////////////////////////////////////////////////////////////
//Edição de SQL de datasets
procedure TISISObjectManager.EditDatasetSQL;
var
  SQL: TStringList;
  Con: TADOConnection;
  aDataset: TICEDataset;
  aName: String;
begin

  aName:= ISISForm.lbxDatasets.Items[ISISForm.lbxDatasets.ItemIndex];
  aDataset:= ISISForm.SuperStructure.DatasetList.FindByName(aName);
  Con:= aDataset.ICEDBConnection.DBConnection;

  SQL:= TStringList.Create;
  If ISISForm.cdgSQL.Text <> '' then
    SQL.Text:= ISISForm.cdgSQL.Text;

  dlgEditSQL:= TdlgEditSQL.Create(ISISForm);

  if dlgEditSQL.Execute(Con, SQL) = mrOk then begin
    aDataset.SQL:= SQL.Text;
    ISISForm.cdgSQL.Text:= SQL.Text;
  end;

  dlgEditSQL.Free;
  SQL.Free;
end;

/////////////////////////////////////////////////////////////////////////////////
//Diálogo de edição de código pascal
procedure TISISObjectManager.EditPasObject;
begin
  // TODO -cMM: TISISForm.EditPasObject default body inserted
end;

/////////////////////////////////////////////////////////////////////////////////
//Edição de objetos SQL
procedure TISISObjectManager.EditSQLObject;
begin
  // TODO -cMM: TISISForm.EditSQLObject default body inserted
end;

procedure TISISForm.FormDestroy(Sender: TObject);
begin
  FISISInspectorControler.Free;
  FISISObjectManager.Free;
  FSuperStructure.Free;
  FISISListManager.Free;
end;

procedure TISISListManager.ClearLists;
begin
  ISISForm.lbxDBConnections.Clear;
  ISISForm.lbxVars.Clear;
  ISISForm.lbxDatasets.Clear;
end;

procedure TISISListManager.RefreshLists;
var
  Txt: TStringList;
begin
  ClearLists;

  Txt:= TStringList.Create;

  ISISForm.Inserting:= True;

  ISISForm.SuperStructure.ICELister.FillTxtWithDBConnections(Txt);
  ISISForm.lbxDBConnections.Items.Assign(Txt);

  Txt.Clear;
  ISISForm.SuperStructure.ICELister.FillTxtWithDatasets(Txt);
  ISISForm.lbxDatasets.Items.Assign(Txt);

  Txt.Clear;
  ISISForm.SuperStructure.ICELister.FillTxtWithVars(Txt);
  ISISForm.lbxVars.Items.Assign(Txt);

  ISISForm.Inserting:= False;
end;

procedure TISISForm.cbbDtsDBCDropDown(Sender: TObject);
var
  Txt: TStringList;
begin
  Txt:= TStringList.Create;
  SuperStructure.ICELister.FillTxtWithDBConnections(Txt);
  cbbDtsDBC.Items.Assign(Txt);
  Txt.Free;
end;

procedure TISISForm.cbbMasterDtsDropDown(Sender: TObject);
var
  Txt: TStringList;
begin
  Txt:= TStringList.Create;
  SuperStructure.ICELister.FillTxtWithDatasets(Txt);
  TwwDBComboBox(Sender).Items.Assign(Txt);
  Txt.Free;
end;

end.
