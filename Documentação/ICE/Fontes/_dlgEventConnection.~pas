unit _dlgEventConnection;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgConTemplate, StdCtrls, Buttons, ExtCtrls, ICEObjects, Mask,
  wwdbedit, Wwdotdot, Wwdbcomb;

type
  TdlgEventConnection = class(TdlgConTemplate)
    pnlEvent: TPanel;
    cbbTipo: TwwDBComboBox;
    Label2: TLabel;
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    function Execute(Txt: TStringList; Var aEventType: TEventType; Var Src, Dst:
        TICEShapedObject): TModalResult;
    { Public declarations }
  end;

var
  dlgEventConnection: TdlgEventConnection;

implementation

uses _ISISForm;

function TdlgEventConnection.Execute(Txt: TStringList; Var aEventType: TEventType;
    Var Src, Dst: TICEShapedObject): TModalResult;
var
  Er: Boolean;
begin

  Er:= False;
  cbbTipo.ItemIndex:= 0;

  LoadCombos(Txt);

  result:= ShowModal;

  If Result = mrOk then begin

    case cbbTipo.ItemIndex of
      0: aEventType:= evCompletion;
      1: aEventType:= evSuccess;
      2: aEventType:= evFailure;
    end;

    if Er then Execute(Txt, aEventType, Src, Dst);

    Src:= ISISForm.SuperStructure.ShapedObjectList.FindByName(cbbFonte.Text);
    Dst:= ISISForm.SuperStructure.ShapedObjectList.FindByName(cbbDestino.Text);
  end;

end;


{$R *.dfm}

procedure TdlgEventConnection.FormShow(Sender: TObject);
begin
  inherited;
  cbbTipo.SetFocus;
end;

end.
