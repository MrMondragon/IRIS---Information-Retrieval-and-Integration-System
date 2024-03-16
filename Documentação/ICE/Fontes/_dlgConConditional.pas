unit _dlgConConditional;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgConTemplate, StdCtrls, Buttons, ExtCtrls, ICEObjects, Mask,
  wwdbedit, Wwdotdot, Wwdbcomb;

type
  TdlgConConditional = class(TdlgConTemplate)
    pnlElse: TPanel;
    Label1: TLabel;
    cbxElseValue: TCheckBox;
    pnlValTest: TPanel;
    edtValue: TEdit;
    Label4: TLabel;
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    function Execute(Objs: TStringList; Var Src, Dst: TICEShapedObject; var aValue: 
        Variant; var aElseValue: Boolean): TModalResult;
    { Public declarations }
  end;

var
  dlgConConditional: TdlgConConditional;

implementation

uses _ISISForm;

{$R *.dfm}

function TdlgConConditional.Execute(Objs: TStringList; Var Src, Dst: 
    TICEShapedObject; var aValue: Variant; var aElseValue: Boolean): 
    TModalResult;
var
  Er: Boolean;
begin

  Er:= False;

  LoadCombos(Objs);

  result:= ShowModal;

  If Result = mrOk then begin
    aValue:= edtValue.Text;
    aElseValue:= cbxElseValue.Checked;

    if Er then Execute(Objs, Src, Dst, aValue, aElseValue);

    Src:= ISISForm.SuperStructure.ShapedObjectList.FindByName(cbbFonte.Text);
    Dst:= ISISForm.SuperStructure.ShapedObjectList.FindByName(cbbDestino.Text);

  end;
end;




procedure TdlgConConditional.FormShow(Sender: TObject);
begin
  inherited;
  edtValue.SetFocus;
end;

end.
