unit _dlgDataset;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _DialogTemplate, Wwdbspin, Wwdotdot, Mask, wwdbedit, Wwdbcomb,
  StdCtrls, Buttons, ExtCtrls, ADODB, _dlgEditSQL, _dlgLookupPairs,
  PairList;

type
  TdlgDataset = class(TdlgTemplate)
    pnlDtsName: TPanel;
    edtDtsName: TEdit;
    pnlMasterSource: TPanel;
    cbbMasterDts: TwwDBComboBox;
    pnlMasterFields: TPanel;
    cdgMasterFields: TwwDBComboDlg;
    pnlCacheSize: TPanel;
    speCacheSize: TwwDBSpinEdit;
    pnlSQL: TPanel;
    cdgSQL: TwwDBComboDlg;
    pnlDBConnection: TPanel;
    cbbDBConnection: TwwDBComboBox;
    procedure cdgSQLCustomDlg(Sender: TObject);
    procedure cdgMasterFieldsCustomDlg(Sender: TObject);
    procedure cbbDBConnectionCloseUp(Sender: TwwDBComboBox;
      Select: Boolean);
  private
    FDataset: TADODataset;
    { Private declarations }
  public
    function Execute(Var aDataset: TADODataset; Var MasterName, DBCName, SQL,
        MasterFields: String): TModalResult;
    function CreateObject(Var aDataset: TADODataset): Boolean;
    { Public declarations }
  end;

var
  dlgDataset: TdlgDataset;

implementation

uses _ISISForm;

{$R *.dfm}

function TdlgDataset.Execute(Var aDataset: TADODataset; Var MasterName,
    DBCName, SQL, MasterFields: String): TModalResult;
var
  Txt: TStringList;
begin
  if assigned(aDataset) then
    FreeAndNil(aDataset);

  aDataset:= TADODataset.Create(ISISForm);
  FDataset:= aDataset;

  Txt:= TStringList.Create;

  ISISForm.SuperStructure.ICELister.FillTxtWithDatasets(Txt);
  cbbMasterDts.Items.Assign(Txt);

  Txt.Clear;

  ISISForm.SuperStructure.ICELister.FillTxtWithDBConnections(Txt);
  cbbDBConnection.Items.Assign(Txt);

  Txt.Free;

  Result:= ShowModal;

  if Result = mrOk then begin
    MasterName:= cbbMasterDts.Text;
    DBCName:= cbbDBConnection.Text;
    SQL:= cdgSQL.Text;

    if not CreateObject(aDataset) then
      Result:= Execute(aDataset, MasterName, DBCName, SQL, MasterFields);
  end;

end;

function TdlgDataset.CreateObject(Var aDataset: TADODataset): Boolean;
begin
  Result:= True;
  if not ISISForm.SuperStructure.ValidateName(edtDtsName.Text) then begin
    Result:= False;
    Exit;
  end;

  aDataset.Name:= edtDtsName.Text;

  If cbbDBConnection.Text = '' then begin
    MessageDlg('N�o foi atribu�da uma conex�o.', mtError, [mbOK], 0);
    Result:= False;
    Exit;
  end;

  aDataset.Connection:= ISISForm.SuperStructure.DBConnectionList.FindByName(cbbDBConnection.Text).DBConnection;
  aDataset.CursorLocation:= aDataset.Connection.CursorLocation;
  aDataset.CommandTimeout:= aDataset.Connection.CommandTimeout;
  aDataset.CacheSize:= Trunc(speCacheSize.Value);
end;

procedure TdlgDataset.cdgSQLCustomDlg(Sender: TObject);
var
  SQL: TStringList;
  Con: TADOConnection;
begin
  inherited;
  If cbbDBConnection.Text = '' then begin
    MessageDlg('N�o foi atribu�da uma conex�o.', mtError, [mbOK], 0);
    Exit;
  end else begin
    SQL:= TStringList.Create;
    If cdgSQL.Text <> '' then
      SQL.Text:= cdgSQL.Text;

    Con:= ISISForm.SuperStructure.DBConnectionList.FindByName(cbbDBConnection.Text).DBConnection;

    dlgEditSQL:= TdlgEditSQL.Create(Self);

    if dlgEditSQL.Execute(Con, SQL) = mrOk then begin
      FDataset.CommandText:= SQL.Text;
      cdgSQL.Text:= SQL.Text;
    end;

    dlgEditSQL.Free;
    SQL.Free;
  end;
end;

procedure TdlgDataset.cdgMasterFieldsCustomDlg(Sender: TObject);
var
  Ds: TADODataset;
begin
  inherited;
  if cbbMasterDts.Text = '' then
    exit;

  Ds:= ISISForm.SuperStructure.DatasetList.FindByName(cbbMasterDts.Text).Dataset;

  ISISForm.EditMasterFields(FDataset, Ds);

  cdgMasterFields.Text:= FDataset.MasterFields;
end;

procedure TdlgDataset.cbbDBConnectionCloseUp(Sender: TwwDBComboBox;
  Select: Boolean);
begin
  inherited;
  if cbbDBConnection.Text <> '' then
    FDataset.Connection:= ISISForm.SuperStructure.DBConnectionList.FindByName(cbbDBConnection.Text).DBConnection;
end;

end.
