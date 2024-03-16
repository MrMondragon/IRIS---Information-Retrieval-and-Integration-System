unit _dlgOperation;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _DialogTemplate, StdCtrls, Buttons, ExtCtrls;

type
  TdlgOperation = class(TdlgTemplate)
    pnlPropPasOpName: TPanel;
    edtName: TEdit;
    Label1: TLabel;
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    function Execute(Var aName: String): TModalResult;
    { Public declarations }
  end;

var
  dlgOperation: TdlgOperation;

implementation

uses _ISISForm;

/////////////////////////////////////////////////////////////////////////////////
//Método de execução do diálogo - Retorna o nome escolhido e o modal result

{$R *.dfm}

procedure TdlgOperation.FormShow(Sender: TObject);
begin
  edtName.Clear;
  edtName.SetFocus;
end;

function TdlgOperation.Execute(Var aName: String): TModalResult;
begin
  Result := ShowModal;
  aName:= edtName.Text;

  if Result = mrOk then begin

    If not ISISForm.SuperStructure.ValidateName(edtName.Text) then
      Result:= Execute(aName);

  end;
end;


end.
