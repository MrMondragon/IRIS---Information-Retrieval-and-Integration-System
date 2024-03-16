unit _dlgConControl;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgConTemplate, StdCtrls, Buttons, ExtCtrls, ICEObjects, Mask,
  wwdbedit, Wwdotdot, Wwdbcomb;

type
  TdlgConControl = class(TdlgConTemplate)
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    function Execute(Txt: TStringList; Var Src, Dst: TICEShapedObject): 
        TModalResult;
    { Public declarations }
  end;

var
  dlgConControl: TdlgConControl;

implementation

uses _ISISForm;

function TdlgConControl.Execute(Txt: TStringList; Var Src, Dst:
    TICEShapedObject): TModalResult;
var
  Er: Boolean;
begin

  Er:= False;

  LoadCombos(Txt);

  result:= ShowModal;

  If Result = mrOk then begin

    if Er then Execute(Txt, Src, Dst);

    Src:= ISISForm.SuperStructure.ShapedObjectList.FindByName(cbbFonte.Text);
    Dst:= ISISForm.SuperStructure.ShapedObjectList.FindByName(cbbDestino.Text);
  end;


end;


{$R *.dfm}

procedure TdlgConControl.FormShow(Sender: TObject);
begin
  inherited;
  cbbFonte.SetFocus;
end;

end.
