unit _dlgForLoop;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgDynChoice, fcCombo, fcCalcEdit, StdCtrls, Buttons, ExtCtrls,
  ICEObjects, Mask, wwdbedit, Wwdotdot, Wwdbcomb;

type
  TdlgForLoop = class(TdlgDynChoice)
    pnlMax: TPanel;
    Label4: TLabel;
    cedMax: TfcCalcEdit;
    pnlMin: TPanel;
    Label3: TLabel;
    cedMin: TfcCalcEdit;
  private
    { Private declarations }
  public
    function Execute(Vars: TStringList; var aName: String; Var ICEVar: TICEVar; Var
        Max,Min: Double): TModalResult;
    { Public declarations }
  end;

var
  dlgForLoop: TdlgForLoop;

implementation

uses _ISISForm;

function TdlgForLoop.Execute(Vars: TStringList; var aName: String; Var ICEVar:
    TICEVar; Var Max,Min: Double): TModalResult;
var
  Er: Boolean;
begin

  cbbVars.Items.Assign(Vars);
  cbbVars.ItemIndex:= 0;



  Result := ShowModal;
  aName:= edtName.Text;

  if Result = mrOk then begin

    Er:= not ISISForm.SuperStructure.ValidateName(edtName.Text);

    if cbbVars.Text = '' then begin
      Er:= True;
      MessageDlg('Variável não preenchida.', mtError, [mbOK], 0);
    end;

    if Er then
      Result:= Execute(Vars, aName, ICEVar, Max, Min);

    ICEVar:= ISISForm.SuperStructure.VarList.FindByName(cbbVars.Text);
    Max:= cedMax.Value;
    Min:= cedMin.Value;

  end;


end;



{$R *.dfm}

end.
