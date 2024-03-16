unit _dlgLookupPairs;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, fcButton, fcImgBtn, fcShapeBtn, Buttons, ExtCtrls, ADODB,
  PairList, ICEHelperObjects;

type
  TdlgLookupPairs = class(TForm)
    pnlTop: TPanel;
    pnlCampos1: TPanel;
    lbxCampos1: TListBox;
    pnlCampos2: TPanel;
    lbxCampos2: TListBox;
    pnlBtns: TPanel;
    pnlBottom: TPanel;
    btnCancel: TBitBtn;
    btnOk: TBitBtn;
    btnAdd: TfcShapeBtn;
    btnRemove: TfcShapeBtn;
    lbxPares: TListBox;
    pnlTab1: TPanel;
    pnlTab2: TPanel;
    pnlLookupField: TPanel;
    Label1: TLabel;
    cbbLookupField: TComboBox;
    Label2: TLabel;
    procedure btnAddClick(Sender: TObject);
    procedure btnRemoveClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
  private
    FFields1: TStringList;
    FFields2: TStringList;
    { Private declarations }
  public
    procedure SyncListHints(Sender: TListBox);
    function GetFieldName(Sender : TListBox): string;
    function Execute(Ds1, Ds2: TADODataset; var PL: TPairList):
        TModalResult;
    function ExecuteNL(Ds1, Ds2: TADODataset; var PL: TPairList): 
        TModalResult;
    { Public declarations }
  end;

var
  dlgLookupPairs: TdlgLookupPairs;

implementation

{$R *.dfm}

procedure TdlgLookupPairs.SyncListHints(Sender: TListBox);
begin
  Sender.Hint:= GetFieldName(Sender);
end;

function TdlgLookupPairs.GetFieldName(Sender : TListBox): string;
begin
  Result:= Sender.Items[Sender.itemIndex];
end;

procedure TdlgLookupPairs.btnAddClick(Sender: TObject);
var
  i: integer;
  B: Boolean;
begin

  B:= False;
  for i:= 0 to FFields1.Count -1 do
    B:= B or (FFields1[i] = GetFieldName(lbxCampos1));

  for i:= 0 to FFields2.Count -1 do
    B:= B or (FFields2[i] = GetFieldName(lbxCampos2));

  if B then
    raise exception.Create('Cada campo só pode constar uma vez da lista de pares.');

  lbxPares.Items.Add(GetFieldName(lbxCampos1)+' = '+GetFieldName(lbxCampos2));
  FFields1.Add(GetFieldName(lbxCampos1));
  FFields2.Add(GetFieldName(lbxCampos2));
  lbxPares.ItemIndex:= lbxPares.Items.Count -1;
end;

procedure TdlgLookupPairs.btnRemoveClick(Sender: TObject);
begin
  if lbxPares.Items.Count = 0 then exit;

  if lbxPares.ItemIndex = -1 then
    lbxPares.ItemIndex:= 0;

  FFields1.Delete(lbxPares.ItemIndex);
  FFields2.Delete(lbxPares.ItemIndex);

  lbxPares.Items.Delete(lbxPares.ItemIndex);

  lbxPares.ItemIndex:= lbxPares.Items.Count -1;

end;

procedure TdlgLookupPairs.FormCreate(Sender: TObject);
begin
  FFields1:= TStringList.Create;
  FFields2:= TStringList.Create;
end;

procedure TdlgLookupPairs.FormDestroy(Sender: TObject);
begin
  FFields1.Free;
  FFields2.Free;
end;

function TdlgLookupPairs.Execute(Ds1, Ds2: TADODataset; var PL:
    TPairList): TModalResult;
var
  i: integer;
  Lst1, Lst2: TStringList;
begin
  pnlTab1.Caption:= TICESQLUtil.GetTableNameFromSQL(Ds1.CommandText);
  pnlTab2.Caption:= TICESQLUtil.GetTableNameFromSQL(Ds2.CommandText);

  Label2.Caption:= 'Campos selecionados';

  lbxCampos1.Clear;
  lbxCampos2.Clear;
  lbxPares.Clear;

  if (not assigned(Ds1)) then
    Raise exception.create('Tabela Origem não atribuída.');

  if (not assigned(Ds2)) then
    Raise exception.create('Tabela Destino não atribuída.');

  TICEDatasetUtils.StartEmpty(Ds1);
  TICEDatasetUtils.StartEmpty(Ds2);

  if (Ds1.FieldCount = 0) or (Ds2.FieldCount = 0) then
    raise exception.Create('Tanto a tabela alvo quanto a tabela de lookup precisam de campos persistentes para esta operação.');

  for i:= 0 to Ds1.FieldCount -1 do
    lbxCampos1.Items.Add(Ds1.Fields[i].FieldName);

  for i:= 0 to Ds2.FieldCount -1 do
    lbxCampos2.Items.Add(Ds2.Fields[i].FieldName);

  Ds1.Close;
  Ds2.Close;

  lbxCampos1.ItemIndex:= 0;
  lbxCampos2.ItemIndex:= 0;

  cbbLookupField.Items.Assign(lbxCampos2.Items);


  for i:= 0 to lbxCampos2.Count -1 do begin
    if cbbLookupField.Items[i] = PL.StringTag then
      cbbLookupField.ItemIndex:= i
  end;

  if cbbLookupField.Text <> PL.StringTag then
    cbbLookupField.ItemIndex:= -1;

  Lst1:= TStringList.Create;
  Lst2:= TStringList.Create;

  if not assigned(PL) then
    PL:= TPairList.Create;

  if PL.Count > 0 then begin
    PL.GetLists(Lst1,Lst2);

    for i:= 0 to Lst1.Count -1 do
      lbxPares.Items.Add(Lst1[i] + ' = '+Lst2[i]);

    FFields1.Assign(Lst1);
    FFields2.Assign(Lst2);

  end;

  Result:= ShowModal;

  If Result = mrOk then begin
    Lst1.Assign(FFields1);
    Lst2.Assign(FFields2);

    PL.Clear;
    PL.SetFromPairs(Lst1,Lst2);
    PL.StringTag:= cbbLookupField.Text;
  end;

end;

function TdlgLookupPairs.ExecuteNL(Ds1, Ds2: TADODataset; var PL:
    TPairList): TModalResult;
begin
  Label1.Hide;
  cbbLookupField.Hide;
  pnlLookupField.Height:= 20;
  Label2.Caption:= 'Pares Selecionados';

  Result:= Execute(Ds1, Ds2, PL);
end;

end.
