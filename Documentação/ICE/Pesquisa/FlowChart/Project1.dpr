program Project1;

uses
  Forms,
  _ISISForm in '_ISISForm.pas' {ISISForm};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TISISForm, ISISForm);
  Application.Run;
end.
