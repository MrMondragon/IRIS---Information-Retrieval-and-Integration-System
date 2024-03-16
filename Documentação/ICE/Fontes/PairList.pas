unit PairList;

interface

uses  SysUtils, Windows, Messages, Classes, Graphics, Controls, DB,
  Forms, Dialogs;


type

  TPairList = class(TStringList)
  private
    FMainPair: Integer;
    FStringTag: string;
  public
    procedure GetPair(Idx: Integer; Var Key, Value: String);
    procedure AddPair(Key, Value: String);
    procedure GetLists(Var Keys, Values: TStringList);
    procedure SetFromPairs(Keys, Values: TStringList);
    function FindKey(K: String): Integer;
    function FindValue(V: String): Integer;
    constructor Create;
    function GetKey(Idx: Integer): string;
    function GetValue(Idx: Integer): string;
    procedure Assign(Source: TPersistent); override;
  published
    property MainPair: Integer read FMainPair write FMainPair stored True;
    property StringTag: string read FStringTag write FStringTag stored True;
  end;


implementation

constructor TPairList.Create;
begin
  inherited;
  MainPair:= -1;
end;

procedure TPairList.AddPair(Key, Value: String);
begin
  Add(Key+'='+Value);
end;

procedure TPairList.Assign(Source: TPersistent);
begin
  If Source is TPairList then begin
    MainPair:= TPairList(Source).MainPair;
    StringTag:= TPairList(Source).StringTag;
  end;

  inherited Assign(Source);
end;

function TPairList.FindKey(K: String): Integer;
var
  i: Integer;
  TmpK, TmpV: String;
begin
  Result:= -1;
  For i:= 0 to Count -1 do begin
    GetPair(i, TmpK, TmpV);
    if TmpK = K then Result:= i;
  end;
end;

function TPairList.FindValue(V: String): Integer;
var
  i: Integer;
  TmpK, TmpV: String;
begin
  Result:= -1;
  For i:= 0 to Count -1 do begin
    GetPair(i, TmpK, TmpV);
    if TmpV = V then Result:= i;
  end;
end;

function TPairList.GetKey(Idx: Integer): string;
var
  P: Integer;
begin
  P:= Pos('=', Strings[Idx]);
  Result:= Copy(Strings[Idx], 1, P-1);
end;

procedure TPairList.GetLists(Var Keys, Values: TStringList);
var
  K, V: String;
  I: Integer;
begin
  For i:= 0 to Count -1 do begin
    GetPair(I,K,V);
    Keys.Add(K);
    Values.Add(V);
  end;
end;

procedure TPairList.GetPair(Idx: Integer; Var Key, Value: String);
var
  P: Integer;
begin
  P:= Pos('=', Strings[Idx]);
  Key:= Copy(Strings[Idx], 1, P-1);
  Value:= Copy(Strings[Idx],P+1,Length(Strings[Idx]));
end;

function TPairList.GetValue(Idx: Integer): string;
var
  P: Integer;
begin
  P:= Pos('=', Strings[Idx]);
  Result:= Copy(Strings[Idx],P+1,Length(Strings[Idx]));
end;

procedure TPairList.SetFromPairs(Keys, Values: TStringList);
var
  I: Integer;
begin
  for i:= 0 to Keys.Count-1 do
    AddPair(Keys[i],Values[i]);
end;


end.

