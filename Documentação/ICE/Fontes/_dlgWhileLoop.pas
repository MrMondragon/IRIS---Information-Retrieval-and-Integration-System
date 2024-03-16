unit _dlgWhileLoop;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgOperation, StdCtrls, Buttons, ExtCtrls, _ISISForm, SynEdit;

type
  TdlgWhileLoop = class(TdlgOperation)
    pnlTestCon: TPanel;
    SynEdit1: TSynEdit;
    Label2: TLabel;
  private
    { Private declarations }
  public
    function Execute(Var aName: String; Var Txt: TStringList; Capt: String): 
        TModalResult;
    { Public declarations }
  end;

var
  dlgWhileLoop: TdlgWhileLoop;

implementation

function TdlgWhileLoop.Execute(Var aName: String; Var Txt: TStringList; Capt: 
    String): TModalResult;
var
  Er: Boolean;    
begin

  Result := ShowModal;
  aName:= edtName.Text;

  Caption:= 'Novo Loop '+ Capt;

  if Result = mrOk then begin

    Er:= not ISISForm.SuperStructure.ValidateName(edtName.Text);

    Txt.Assign(SynEdit1.Lines);

    If Er then begin
      Result:= Execute(aName, Txt,  Capt);
    end;
  end;
end;


{$R *.dfm}

end.
