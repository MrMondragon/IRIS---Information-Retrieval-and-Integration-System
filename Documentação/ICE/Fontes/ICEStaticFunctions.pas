unit ICEStaticFunctions;

interface

uses Classes, SysUtils;

  procedure GetKeyFromStr(Str: String; Var Lst: TStringList);
  function ParseSymbols(St: String): String;
  function unParseSymbols(St: String): String;

implementation

procedure GetKeyFromStr(Str: String; Var Lst: TStringList);
var
  P: Integer;
  FieldName: string;
begin
  repeat
    P:= pos(';',Str);
    if P = 0 then FieldName:= Str else begin
      FieldName:= Copy(Str,0, P-1);
      Str:= Copy(Str,P+1,length(Str));
    end;
    Lst.Add(FieldName);
  Until P = 0;
end;

function ParseSymbols(St: String): String;
begin
  Result:= St;
  Result:= StringReplace(Result,'>','|M', [rfReplaceAll]);
  Result:= StringReplace(Result,'<','|m', [rfReplaceAll]);
  Result:= StringReplace(Result,'&','|e', [rfReplaceAll]);
  Result:= StringReplace(Result,'/','|d', [rfReplaceAll]);
  Result:= StringReplace(Result,'?','|i', [rfReplaceAll]);
end;

function unParseSymbols(St: String): String;
begin
  Result:= St;
  Result:= StringReplace(Result,'|M','>', [rfReplaceAll]);
  Result:= StringReplace(Result,'|m','<', [rfReplaceAll]);
  Result:= StringReplace(Result,'|e','&', [rfReplaceAll]);
  Result:= StringReplace(Result,'|d','/', [rfReplaceAll]);
  Result:= StringReplace(Result,'|i','?', [rfReplaceAll]);
end;


end.
