program ISISProject;

{%ToDo 'ISISProject.todo'}

uses
  Forms,
  _ISISForm in '_ISISForm.pas' {ISISForm},
  ICEObjects in 'ICEObjects.pas',
  _DialogTemplate in '_DialogTemplate.pas' {dlgTemplate},
  _dlgOperation in '_dlgOperation.pas' {dlgOperation},
  _dlgVar in '_dlgVar.pas' {dlgVar},
  _dlgConTemplate in '_dlgConTemplate.pas' {dlgConTemplate},
  _dlgDynChoice in '_dlgDynChoice.pas' {dlgDynChoice},
  _dlgForLoop in '_dlgForLoop.pas' {dlgForLoop},
  _dlgWhileLoop in '_dlgWhileLoop.pas' {dlgWhileLoop},
  _dlgDepConnection in '_dlgDepConnection.pas' {dlgDepConnection},
  _dlgEventConnection in '_dlgEventConnection.pas' {dlgEventConnection},
  _dlgConControl in '_dlgConControl.pas' {dlgConControl},
  _dlgConConditional in '_dlgConConditional.pas' {dlgConConditional},
  _dlgDBConnection in '_dlgDBConnection.pas' {dlgDBConnection},
  _dlgDataset in '_dlgDataset.pas' {dlgDataset},
  _dlgSQLOperation in '_dlgSQLOperation.pas' {dlgSQLOperation},
  _dlgDataTransport in '_dlgDataTransport.pas' {dlgDataTransport},
  ICEXMLSerializer in 'ICEXMLSerializer.pas',
  _dlgLookupPairs in '_dlgLookupPairs.pas' {dlgLookupPairs},
  PairList in 'PairList.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TISISForm, ISISForm);
  Application.CreateForm(TdlgLookupPairs, dlgLookupPairs);
  Application.Run;
end.
