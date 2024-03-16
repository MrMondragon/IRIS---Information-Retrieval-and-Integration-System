unit _dlgDataTransport;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgOperation, Wwdotdot, Mask, wwdbedit, Wwdbcomb, StdCtrls,
  Buttons, ExtCtrls, PairList, ADODB, _dlgLookupPairs;

type
  TdlgDataTransport = class(TdlgOperation)
    pnlDts1: TPanel;
    Label2: TLabel;
    pnlDts2: TPanel;
    Label3: TLabel;
    pnlPairList: TPanel;
    Label4: TLabel;
    cbbFonte: TwwDBComboBox;
    cbbDestino: TwwDBComboBox;
    cdgCampos: TwwDBComboDlg;
    procedure cdgCamposCustomDlg(Sender: TObject);
  private
    FPL: TPairList;
    { Private declarations }
  public
    function Execute(Var aName: String; Var Txt: TStringList; Var Dts1, Dts2:
        String; Var PL: TPairList): TModalResult;
    { Public declarations }
  end;

var
  dlgDataTransport: TdlgDataTransport;

implementation

uses _ISISForm;

function TdlgDataTransport.Execute(Var aName: String; Var Txt: TStringList;
    Var Dts1, Dts2: String; Var PL: TPairList): TModalResult;
begin
  cbbFonte.Items.Assign(Txt);
  cbbDestino.Items.Assign(Txt);
  cbbFonte.ItemIndex:= 0;
  cbbDestino.ItemIndex:= 0;
  FPL:= PL;

  Result := ShowModal;

  if Result = mrOk then begin
    aName:= edtName.Text;
    Dts1:= cbbFonte.Text;
    Dts2:= cbbDestino.Text;

    If not ISISForm.SuperStructure.ValidateName(edtName.Text) then
      Result:= Execute(aName, Txt, Dts1, Dts2, PL);

  end;
end;

{$R *.dfm}

procedure TdlgDataTransport.cdgCamposCustomDlg(Sender: TObject);
var
  D1, D2: TADODataset;
begin
  inherited;
  If (cbbFonte.Text = '') or (cbbDestino.Text = '') then begin
    MessageDlg('Favor definir os dataset antes de atribuir a correspondência de campos', mtError, [mbOK], 0);
    Exit;
  end;

  D1:= ISISForm.SuperStructure.DatasetList.FindByName(cbbFonte.Text).Dataset;
  D2:= ISISForm.SuperStructure.DatasetList.FindByName(cbbDestino.Text).Dataset;

  dlgLookupPairs:= TdlgLookupPairs.Create(Self);

  if dlgLookupPairs.ExecuteNL(D1,D2,FPL) = mrOk then
    cdgCampos.Text:= FPL.Text;
end;

end.
