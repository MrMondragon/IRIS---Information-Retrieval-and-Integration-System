unit _dlgControlStructure;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, wwdbedit, StdCtrls, Mask, Wwdotdot, Buttons, ExtCtrls, Grids,
  wwDataInspector;

type
  TdlgControlStructure = class(TForm)
    dtiInspector: TwwDataInspector;
    pnlBtns: TPanel;
    btnCancel: TBitBtn;
    btnOk: TBitBtn;
    procedure FormKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    function Execute(Var aName: String): TModalResult;
    { Public declarations }
  end;

var
  dlgControlStructure: TdlgControlStructure;

implementation

uses _ISISForm;

function TdlgControlStructure.Execute(Var aName: String):TModalResult;
var
  Er: Boolean;
begin
  Er:= False;
  Result := ShowModal;
  aName:= dtiInspector.Items[0].EditText;

  if Result = mrOk then begin

    if ISISForm.SuperStructure.ShapedObjectList.FindByName(aName) <> nil then begin
      MessageBox(0, 'O nome digitado já existe na estrutura.', 'Erro', MB_ICONSTOP or MB_OK);
      Er:= True;
    end;

    if aName = '' then begin
      MessageBox(0, 'Nome Inválido', 'Erro', MB_ICONSTOP or MB_OK);
      Er:= True;
    end;


    If Er then
      Result:= Execute(aName);
  end;

end;

{$R *.dfm}

procedure TdlgControlStructure.FormKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  if Key = VK_RETURN then
    ModalResult:= MrOk;
end;

procedure TdlgControlStructure.FormShow(Sender: TObject);
begin
  dtiInspector.SetFocus;
  dtiInspector.GetItemByCaption('Nome');
end;

end.
