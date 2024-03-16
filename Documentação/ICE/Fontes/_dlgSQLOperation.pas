unit _dlgSQLOperation;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgOperation, StdCtrls, Buttons, ExtCtrls, ICEObjects, Mask,
  wwdbedit, Wwdotdot, Wwdbcomb;

type
  TdlgSQLOperation = class(TdlgOperation)
    pnlDBConnection: TPanel;
    Label2: TLabel;
    cbbConnection: TwwDBComboBox;
    pnlPrepareCommand: TPanel;
    cbxPrepareCommand: TCheckBox;
  private
    { Private declarations }
  public
    function Execute(Var aName: String; Txt: TStringList; Var ConName: String; Var 
        Prep: Boolean): TModalResult;
    { Public declarations }
  end;

var
  dlgSQLOperation: TdlgSQLOperation;

implementation

uses _ISISForm;

function TdlgSQLOperation.Execute(Var aName: String; Txt: TStringList; Var 
    ConName: String; Var Prep: Boolean): TModalResult;
var
  Er: Boolean;
begin
  cbbConnection.Items.Assign(Txt);
  ModalResult:= MrNone;

  Er:= False;
  if Txt.Count > 0 then
    cbbConnection.ItemIndex:= 0
  else begin
    MessageDlg('Voc� precisa criar conex�es de banco antes de criar Comandos SQL', mtError, [mbOK], 0);
    Result:= mrNone;
    exit;
  end;     

  Result := ShowModal;

  if Result = mrOk then begin
    aName:= edtName.Text;
    Prep:= cbxPrepareCommand.Checked;
    ConName:= cbbConnection.Text;
    If ConName = '' then begin
      MessageDlg('Deve ser especificada uma conex�o de banco!', mtError, [mbOK], 0);
      Er:= True;
    end;

    Er:= Er or (not ISISForm.SuperStructure.ValidateName(edtName.Text));

    If Er then
      Result:= Execute(aName, Txt, ConName, Prep);

  end;
end;


{$R *.dfm}

end.
