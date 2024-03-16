unit _dlgDBConnection;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _DialogTemplate, StdCtrls, Wwdbspin, Mask, wwdbedit, Wwdotdot,
  Buttons, ExtCtrls, ICEObjects, ADOConEd, ADODB;

type
  TdlgDBConnection = class(TdlgTemplate)
    pnlDBCConnectionString: TPanel;
    cdgConnectionString: TwwDBComboDlg;
    pnlDBCLocation: TPanel;
    cbxDBCClientSide: TCheckBox;
    pnlDBCTimeOut: TPanel;
    speDBCTimeOut: TwwDBSpinEdit;
    pnlDBCName: TPanel;
    edtName: TEdit;
    procedure FormShow(Sender: TObject);
    procedure cdgConnectionStringCustomDlg(Sender: TObject);
  private
    FADOConnection: TADOConnection;
    { Private declarations }
  public
    function Execute(Var aADOConnection: TADOConnection): TModalResult;
    function CreateObject(Var aADOConnection: TADOConnection): Boolean;
    { Public declarations }
  end;

var
  dlgDBConnection: TdlgDBConnection;

implementation

uses _ISISForm;

{$R *.dfm}

procedure TdlgDBConnection.FormShow(Sender: TObject);
begin
  inherited;
  edtName.SetFocus;
end;

function TdlgDBConnection.Execute(Var aADOConnection: TADOConnection):
    TModalResult;
begin
  if assigned(aADOConnection) then
    FreeAndNil(aADOConnection);

  aADOConnection:= TADOConnection.Create(ISISForm);

  FADOConnection:= aADOConnection;
  FADOConnection.LoginPrompt:= False;

  speDBCTimeOut.Value:= 30;

  Result := ShowModal;

  if Result = mrOk then begin
    if not CreateObject(aADOConnection) then
      Result:= Execute(aADOConnection);
  end;
end;

procedure TdlgDBConnection.cdgConnectionStringCustomDlg(Sender: TObject);
begin
  inherited;
  EditConnectionString(FADOConnection);
  cdgConnectionString.Text:= FADOConnection.ConnectionString;
end;

function TdlgDBConnection.CreateObject(Var aADOConnection: TADOConnection):
    Boolean;
begin
  Result:= True;
  if not ISISForm.SuperStructure.ValidateName(edtName.Text) then begin
    Result:= False;
    Exit;
  end;

  aADOConnection.Name:= edtName.Text;
  aADOConnection.CommandTimeout:= Trunc(speDBCTimeOut.Value);
  aADOConnection.ConnectionTimeout:= Trunc(speDBCTimeOut.Value);
  if cbxDBCClientSide.Checked then
    aADOConnection.CursorLocation:= clUseClient
  else
    aADOConnection.CursorLocation:= clUseServer;
  aADOConnection.ConnectionString:= cdgConnectionString.Text;
end;

end.
