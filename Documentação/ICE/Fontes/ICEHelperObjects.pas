unit ICEHelperObjects;

interface

uses classes, SysUtils, DB, ADODB;

type
  TICESQLUtil = class(TObject)
  public
    class function GetCriterio(Const SQL: String): string;
    class procedure GetKeyFromStr(Str: String; Var Lst: TStringList);
    class function GetTableNameFromSQL(Const SQL: String): string;
    class function GetWhereClause(Const SQL: String): String;
    class function ReplaceWhere(Const SQL, NewWhere: String; Pure: Boolean): string;
    class procedure SQLParts(Const SQL:String; Var Select: String; Var From:
        String; Var Where: String; Var GroupBy: String; Var Having: String; Var
        OrderBy: String);
  end;

  TICEDatasetUtils = class(TObject)
  private
  public
    class procedure CreatePersistentFields(Dataset: TDataset);
    class procedure StartEmpty(Dataset: TADODataset);
  end;

implementation

class function TICESQLUtil.GetCriterio(Const SQL: String): string;
var
  Where, Criterio: string;
begin
  //retorna o critério de comparação da cláusula where de uma sentença sql
  //envolto em parênteses

  Where:= GetWhereClause(SQL);

  if (Where <> '') and (Length(Where) > 6) then begin
      Criterio:= Copy(Where,6,Length(Where));
      Result:= '('+Criterio+') ';
  end else result:= '';

end;

{
*********************************** TICEUtil ***********************************
}
class procedure TICESQLUtil.GetKeyFromStr(Str: String; Var Lst: TStringList);
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

class function TICESQLUtil.GetTableNameFromSQL(Const SQL: String): string;
var
  i, j, k: Integer;
  Aux: string;
begin
  //extrai o nome da tabela de uma sentença sql
  Aux:=UpperCase(SQL);
  Aux:=trim(copy(Aux,pos('FROM ',Aux)+5,length(Aux)));
  i:=pos(' ',Aux);
  j:=pos(#$0D#$0A,Aux);
  k:=pos(',',Aux);
  if (j > 0) and (j < i) then i:=j;
  if (k > 0) and (k < i) then i:=k;
  if i > 0 then begin
    Aux:=copy(Aux,1,i-1);
    i:=pos(',',Aux);
    if i > 0 then Aux:=copy(Aux,1,i-1);
  end;

  Result:= Aux;
end;

class function TICESQLUtil.GetWhereClause(Const SQL: String): String;
var
  Na: String;
begin
  //retorna a cláusula where de uma sentença sql
  SQLParts(SQL,Na,Na,Result,Na,Na,Na);

end;

class function TICESQLUtil.ReplaceWhere(Const SQL, NewWhere: String; Pure:
    Boolean): string;
var
  Select: string;
  From: string;
  NA: string;
  GroupBy: string;
  Having: string;
  OrderBy: string;
begin

  //substitui a cláusula where de um sql

  SQLParts(SQL, Select,From,NA,GroupBy,Having,OrderBy);
  Result:= Select+' '+From+' where '+NewWhere;

  if not pure then Result:= Result+GroupBy+Having+OrderBy;

end;

class procedure TICESQLUtil.SQLParts(Const SQL:String; Var Select: String; Var
    From: String; Var Where: String; Var GroupBy: String; Var Having: String;
    Var OrderBy: String);
var
  UpperCaseSQL: string;
  StartPoint, EndPoint: Integer;
begin
  //Retorna cada uma das partes de uma sentença sql
  Select:= '';
  From:= '';
  Where:= '';
  GroupBy:='';
  Having:='';
  OrderBy:='';

  UpperCaseSQL:= UpperCase(SQL);

  StartPoint:= 1;
  EndPoint:= Pos('FROM', UpperCaseSQL);

  Select:= Copy(SQL, StartPoint, EndPoint-1)+' ';

  StartPoint:= EndPoint;
  EndPoint:= Pos('WHERE', UpperCaseSQL);
  if EndPoint = 0 then EndPoint:= Pos('GROUP BY', UpperCaseSQL);
  if EndPoint = 0 then EndPoint:= Pos('HAVING', UpperCaseSQL);
  if EndPoint = 0 then EndPoint:= Pos('ORDER BY', UpperCaseSQL);
  if EndPoint = 0 then begin
    EndPoint:= Length(UpperCaseSQL);
    From:= Copy(SQL, StartPoint, EndPoint)+' ';
  end else
    From:= Copy(SQL, StartPoint, ((EndPoint -1) - StartPoint))+' ';

  StartPoint:= Pos('WHERE', UpperCaseSQL);
  if StartPoint > 0 then begin
    EndPoint:= Pos('GROUP BY', UpperCaseSQL);
    if EndPoint = 0 then EndPoint:= Pos('HAVING', UpperCaseSQL);
    if EndPoint = 0 then EndPoint:= Pos('ORDER BY', UpperCaseSQL);
    if EndPoint = 0 then begin
      EndPoint:= Length(UpperCaseSQL);
      Where:= Copy(SQL, StartPoint, EndPoint);
    end else
      Where:= Copy(SQL, StartPoint, ((EndPoint -1) - StartPoint));
  end;

  StartPoint:= Pos('GROUP BY', UpperCaseSQL);
  if StartPoint > 0 then begin
    EndPoint:= Pos('HAVING', UpperCaseSQL);
    if EndPoint = 0 then EndPoint:= Pos('ORDER BY', UpperCaseSQL);
    if EndPoint = 0 then begin
      EndPoint:= Length(UpperCaseSQL);
      GroupBy:= Copy(SQL, StartPoint, EndPoint);
    end else
      GroupBy:= Copy(SQL, StartPoint, ((EndPoint -1) - StartPoint));
  end;

  StartPoint:= Pos('HAVING', UpperCaseSQL);
  if StartPoint > 0 then begin
    EndPoint:= Pos('ORDER BY', UpperCaseSQL);
    if EndPoint = 0 then begin
      EndPoint:= Length(UpperCaseSQL);
      Having:= Copy(SQL, StartPoint, EndPoint);
    end else
      Having:= Copy(SQL, StartPoint, ((EndPoint -1) - StartPoint));
  end;

  StartPoint:= Pos('ORDER BY', UpperCaseSQL);
  if StartPoint > 0 then begin
    EndPoint:= Length(UpperCaseSQL);

    OrderBy:= Copy(SQL, StartPoint, EndPoint);
  end;

  Select:= Trim(Select);
  From:= Trim(From);
  Where:= Trim(Where);
  GroupBy:= Trim(GroupBy);
  Having:=Trim(Having);
  OrderBy:=Trim(OrderBy);

end;

class procedure TICEDatasetUtils.CreatePersistentFields(Dataset: TDataset);
var
  i: Integer;
begin
  Dataset.Open;
  Dataset.Close;
  for i:= 0 to Dataset.FieldDefs.Count -1 do
    Dataset.FieldDefs[i].CreateField(Dataset);
end;

class procedure TICEDatasetUtils.StartEmpty(Dataset: TADODataset);
begin
  Dataset.CommandText:= TICESQLUtil.ReplaceWhere(Dataset.CommandText, '1 = 2', true);
  Dataset.Open;
end;


end.
