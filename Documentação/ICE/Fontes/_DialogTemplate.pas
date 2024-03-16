unit _DialogTemplate;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, wwdbedit, StdCtrls, Mask, Wwdotdot, Buttons, ExtCtrls, Grids,
  wwDataInspector;

type
  TdlgTemplate = class(TForm)
    pnlBtns: TPanel;
    btnCancel: TBitBtn;
    btnOk: TBitBtn;
    pnlValues: TPanel;
    procedure FormKeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  dlgTemplate: TdlgTemplate;

implementation

uses _ISISForm;

{$R *.dfm}

procedure TdlgTemplate.FormKeyPress(Sender: TObject; var Key: Char);
begin
  if (Key = #13) then
    ModalResult:= mrOk;
end;

end.
