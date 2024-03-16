unit ICEPersistence;

interface

uses
  SysUtils, Windows, Messages, Classes, Graphics, Controls, DB, ADODB,
  Forms, Dialogs, ICEObjects, ICEXMLSerializer, XMLDoc, XMLIntf;

type

  TICEXMLPersistence = class(TICEPersistenceBase)
  private
    FICEXMLSerializer: TICEXMLSerializer;
    FXMLDoc: TXMLDocument;
    procedure FillConnectionList(xObj: IXMLNode);
    procedure FillDatasetList(xObj: IXMLNode);
    procedure FillDBConnectionList(xObj: IXMLNode);
    procedure FillShapedObjectList(xObj: IXMLNode);
    procedure FillVarList(xObj: IXMLNode);
  public
    constructor Create(aStructure: TICEStructure); override;
    destructor Destroy; override;
    procedure LoadConnectionList(aStream: TStream); override;
    procedure LoadDatasetList(aStream: TStream); override;
    procedure LoadDBConnectionList(aStream: TStream); override;
    procedure LoadFromFile(FileName: String); override;
    procedure LoadFromStream(aStream: TStream); override;
    procedure LoadShapedObjectList(aStream: TStream); override;
    procedure LoadVarList(aStream: TStream); override;
    procedure SaveConnectionList(aStream: TStream); override;
    procedure SaveDatasetList(aStream: TStream); override;
    procedure SaveDBConnectionList(aStream: TStream); override;
    procedure SaveShapedObjectList(aStream: TStream); override;
    procedure SaveToFile(FileName: String); override;
    procedure SaveToStream(aStream: TStream); override;
    procedure SaveVarList(aStream: TStream); override;
  end;
  
implementation

{
****************************** TICEXMLPersistence ******************************
}
constructor TICEXMLPersistence.Create(aStructure: TICEStructure);
begin
  FICEXMLSerializer:= TICEXMLSerializer.Create;
  
  with FICEXMLSerializer do begin
    ExcludeEmptyValues := False;
    ExcludeDefaultValues := False;
    ReplaceReservedSymbols := True;
    IgnoreUnknownTags := False;
    DefaultXMLHeader:= '<?xml version="1.0" encoding="UTF-8" standalone="yes" ?>';
  end;
  
  FXMLDoc:= TXMLDocument.Create(nil);
  
  FICEStructure:= aStructure;
  
end;

destructor TICEXMLPersistence.Destroy;
begin
  FICEXMLSerializer.Free;
  FXMLDoc.Free;
  inherited;
end;

procedure TICEXMLPersistence.FillConnectionList(xObj: IXMLNode);
begin
  
end;

procedure TICEXMLPersistence.FillDatasetList(xObj: IXMLNode);
var
  xDataset: IXMLNode;
  i: Integer;
  aDataset: TADODataset;
  aOwner: TComponent;
  aName: string;
begin
  if assigned(FICEStructure.DrawArea) then
    aOwner:= FICEStructure.DrawArea.Owner
  else
    aOwner:= nil;
  
  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    if xObj.ChildNodes[i].NodeName = 'TICEDataset' then begin
      xDataset:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Dataset'];
      aName:= xDataset.ChildNodes.Nodes['Name'].Text;
      aDataset:= TADODataset.Create(aOwner);
      aDataset.Name:= aName;
      aDataset.CacheSize:= StrToIntDef(xDataset.ChildNodes['CacheSize'].Text,0);
      TICEDataset.Create(FICEStructure, aDataset);
    end;
  end;
  
end;

procedure TICEXMLPersistence.FillDBConnectionList(xObj: IXMLNode);
var
  xDBCon: IXMLNode;
  i: Integer;
  aCon: TADOConnection;
  aOwner: TComponent;
begin
  if assigned(FICEStructure.DrawArea) then
    aOwner:= FICEStructure.DrawArea.Owner
  else
    aOwner:= nil;
  
  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    if xObj.ChildNodes[i].NodeName = 'TICEDBConnection' then begin
      xDBCon:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['DBConnection'];
  
      aCon:= TADOConnection.Create(aOwner);
      aCon.Name:= xDBCon.ChildNodes.Nodes['Name'].Text;
      aCon.CommandTimeout:= StrToIntDef(xDBCon.ChildNodes['CommandTimeout'].Text,0);
      aCon.ConnectionTimeout:= aCon.CommandTimeout;
      aCon.ConnectionString:= xDBCon.ChildNodes['ConnectionString'].Text;
  
      if xDBCon.ChildNodes['CursorLocation'].Text = 'clUseServer' then
        aCon.CursorLocation:= clUseServer
      else
        aCon.CursorLocation:= clUseClient;
  
      aCon.LoginPrompt:= False;
  
      TICEDBConnection.Create(FICEStructure,aCon);
    end;
  end;
end;

procedure TICEXMLPersistence.FillShapedObjectList(xObj: IXMLNode);
begin
  
end;

procedure TICEXMLPersistence.FillVarList(xObj: IXMLNode);
var
  i: Integer;
  aVar: TICEVar;
  aDatasetName: string;
  aDataset: TICEDataset;
  xVar: IXMLNode;
begin
  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    if xObj.ChildNodes[i].NodeName = 'TICEVar' then begin
      xVar:= xObj.ChildNodes.Nodes[i];
      aVar:= TICEVar.Create(FICEStructure, xVar.ChildNodes.Nodes['Name'].Text);
      aVar.Persistent:=  StrToBoolDef(xVar.ChildNodes.Nodes['Persistent'].Text, false);
      if aVar.Persistent then begin
        aDatasetName:= xVar.ChildNodes.Nodes['DatasetName'].Text;
        aDataset:= FICEStructure.DatasetList.FindByName(aDatasetName);
        if assigned(aDataset) then begin
          aVar.Dataset:= aDataset;
          aVar.FieldName:= xVar.ChildNodes.Nodes['FieldName'].Text;
        end else
        aVar.Persistent:= False;
      end;
    end;
  end;
end;

procedure TICEXMLPersistence.LoadConnectionList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.LoadDatasetList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.LoadDBConnectionList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.LoadFromFile(FileName: String);
begin
  // TODO -cMM: TICEStructure.LoadFromFile default body inserted
end;

procedure TICEXMLPersistence.LoadFromStream(aStream: TStream);
var
  xStructure: IXMLNode;
begin
  
  FXMLDoc.LoadFromStream(aStream);
  FXMLDoc.Active:= True;
  
  if FXMLDoc.DocumentElement.NodeName = 'TICEStructure' then begin
    if FXMLDoc.DocumentElement.HasChildNodes then begin
      FICEStructure.Clear;
  
      xStructure:= FXMLDoc.DocumentElement;
      FICEStructure.Name:= xStructure.ChildNodes['Name'].Text;
  
      FillDBConnectionList(xStructure.ChildNodes['DBConnectionList']);
      FillDatasetList(xStructure.ChildNodes['DatasetList']);
      FillVarList(xStructure.ChildNodes['VarList']);
      FillShapedObjectList(xStructure.ChildNodes['ShapedObjectList']);
      FillConnectionList(xStructure.ChildNodes['ConnectionList']);
  
    end;
  end else raise exception.Create('Arquivo Inv�lido');
  
end;

procedure TICEXMLPersistence.LoadShapedObjectList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.LoadVarList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.SaveConnectionList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.SaveDatasetList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.SaveDBConnectionList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.SaveShapedObjectList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.SaveToFile(FileName: String);
begin
  // TODO -cMM: TICEStructure.SaveToFile default body inserted
end;

procedure TICEXMLPersistence.SaveToStream(aStream: TStream);
begin
  FICEXMLSerializer.Serialize(FICEStructure, aStream);
end;

procedure TICEXMLPersistence.SaveVarList(aStream: TStream);
begin
end;


end.
