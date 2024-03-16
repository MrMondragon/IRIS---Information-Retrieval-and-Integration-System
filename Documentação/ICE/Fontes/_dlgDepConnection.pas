unit _dlgDepConnection;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _dlgConTemplate, StdCtrls, Buttons, ExtCtrls, ICEObjects, Mask,
  wwdbedit, Wwdotdot, Wwdbcomb;

type
  TdlgDepConnection = class(TdlgConTemplate)
    pnlStatus: TPanel;
    Label2: TLabel;
    cbbStatus: TwwDBComboBox;
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    function Execute(Txt: TStringList; Var aStatus: TICEObjectStatus; Var Src, Dst:
        TICEShapedObject): TModalResult;
    { Public declarations }
  end;

var
  dlgDepConnection: TdlgDepConnection;

implementation

uses _ISISForm;

function TdlgDepConnection.Execute(Txt: TStringList; Var aStatus:
    TICEObjectStatus; Var Src, Dst: TICEShapedObject): TModalResult;
var
  Er: Boolean;
begin

  Er:= False;

  cbbStatus.ItemIndex:= 0;

  LoadCombos(Txt);

  result:= ShowModal;

  If Result = mrOk then begin
    case cbbStatus.ItemIndex of
      0: aStatus:= sttReady;
      1: aStatus:= sttRunning;
      2: aStatus:= sttDisabled;
      3: aStatus:= sttSuccess;
      4: aStatus:= sttFailure;
    end;

    if Er then Execute(Txt, aStatus, Src, Dst);

    Src:= ISISForm.SuperStructure.ShapedObjectList.FindByName(cbbFonte.Text);
    Dst:= ISISForm.SuperStructure.ShapedObjectList.FindByName(cbbDestino.Text);
  end;


end;


{$R *.dfm}

procedure TdlgDepConnection.FormShow(Sender: TObject);
begin
  inherited;
  cbbStatus.SetFocus;
end;

end.
