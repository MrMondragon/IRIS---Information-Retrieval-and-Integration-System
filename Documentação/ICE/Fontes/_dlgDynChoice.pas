unit _dlgDynChoice;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _DialogTemplate, StdCtrls, Buttons, ExtCtrls, ICEObjects,
  _dlgOperation, Mask, wwdbedit, Wwdotdot, Wwdbcomb;

type
  TdlgDynChoice = class(TdlgOperation)
    pnlVars: TPanel;
    Label2: TLabel;
    cbbVars: TwwDBComboBox;
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    function Execute(Vars: TStringList; var aName: String; Var ICEVar: TICEVar): 
        TModalResult;
    { Public declarations }
  end;

var
  dlgDynChoice: TdlgDynChoice;

implementation

uses _ISISForm;

function TdlgDynChoice.Execute(Vars: TStringList; var aName: String; Var
    ICEVar: TICEVar): TModalResult;
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
      Result:= Execute(Vars, aName, ICEVar);

    ICEVar:= ISISForm.SuperStructure.VarList.FindByName(cbbVars.Text);


  end;


end;

{$R *.dfm}

procedure TdlgDynChoice.FormShow(Sender: TObject);
begin
  edtName.Clear;
  edtName.SetFocus;
end;

end.
