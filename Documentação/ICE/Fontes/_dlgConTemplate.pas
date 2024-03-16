unit _dlgConTemplate;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, _DialogTemplate, StdCtrls, Buttons, ExtCtrls, ICEObjects, Mask,
  wwdbedit, Wwdotdot, Wwdbcomb;

type
  TdlgConTemplate = class(TdlgTemplate)
    pnlFonte: TPanel;
    lbFonte: TLabel;
    cbbFonte: TwwDBComboBox;
    pnlDestino: TPanel;
    lbDest: TLabel;
    cbbDestino: TwwDBComboBox;
  protected
    procedure LoadCombos(Txt: TStringList);
    { Private declarations }
  public
    { Public declarations }
  end;

var
  dlgConTemplate: TdlgConTemplate;

implementation

uses _ISISForm;

{$R *.dfm}

procedure TdlgConTemplate.LoadCombos(Txt: TStringList);
begin
  cbbFonte.Items.Assign(Txt);
  cbbFonte.ItemIndex:= 0;

  cbbDestino.Items.Assign(Txt);
  cbbDestino.ItemIndex:= Txt.Count -1;
end;

end.
