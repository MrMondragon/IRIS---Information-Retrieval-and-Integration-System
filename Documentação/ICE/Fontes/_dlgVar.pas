unit _dlgVar;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgOperation, StdCtrls, Buttons, ExtCtrls;

type
  TdlgVar = class(TdlgOperation)
  private
    { Private declarations }
  public
    function Execute(Var aName: String): TModalResult;
    { Public declarations }
  end;

var
  dlgVar: TdlgVar;

implementation

uses _ISISForm;

{$R *.dfm}

function TdlgVar.Execute(Var aName: String): TModalResult;
begin
  Result := ShowModal;
  aName:= edtName.Text;

  if Result = mrOk then begin

    if not ISISForm.SuperStructure.ValidateName(aName) then
      Result:= Execute(aName);

  end;
end;

end.
