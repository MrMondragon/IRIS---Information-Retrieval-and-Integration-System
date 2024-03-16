unit _PersistencyModule;

interface

uses
  SysUtils, Classes, JvComponent, JvgXMLSerializer, ICEObjects, Dialogs,
  xmldom, XMLIntf, msxmldom, XMLDoc, ADODB, Transactor, XMLSerializer,
  FlexCompress;

type
  TPersistencyModule = class(TDataModule)
    Serializer: TJvgXMLSerializer;
    SaveDialog1: TSaveDialog;
    OpenDialog1: TOpenDialog;
    XMLDocument1: TXMLDocument;
  private
    FStructure: TICEStructure;
    { Private declarations }
  public
    procedure SaveStructure(aStructure: TICEStructure);
    procedure LoadStructure(Var aStructure: TICEStructure);
    procedure FillDatasetList(xObj: IXMLNode);
    procedure FillVarList(xObj: IXMLNode);
    procedure FillConnectionList(xObj: IXMLNode);
    procedure FillShapedObjectList(xObj: IXMLNode);
    procedure FillDBConnectionList(xObj: IXMLNode);
    { Public declarations }
  end;

var
  PersistencyModule: TPersistencyModule;

implementation

uses _ISISForm;

{$R *.dfm}

procedure TPersistencyModule.SaveStructure(aStructure: TICEStructure);
var
  aStream: TFileStream;
begin
  if SaveDialog1.Execute then begin
    if FileExists(SaveDialog1.FileName) then
      DeleteFile(SaveDialog1.FileName);

    aStream:= TFileStream.Create(SaveDialog1.FileName,fmCreate);
    try
      Serializer.DefaultXMLHeader:= '<?xml version="1.0" encoding="UTF-8" standalone="yes" ?>';
      Serializer.Serialize(aStructure, aStream);
    finally
      aStream.Free;
    end;
  end;
end;

procedure TPersistencyModule.LoadStructure(Var aStructure: TICEStructure);
var
  xStructure: IXMLNode;
begin
  if OpenDialog1.Execute then begin
    XMLDocument1.LoadFromFile(OpenDialog1.FileName);
    XMLDocument1.Active:= True;

    if XMLDocument1.DocumentElement.NodeName = 'TICEStructure' then begin
      if XMLDocument1.DocumentElement.HasChildNodes then begin
        aStructure.Clear;
        FStructure:= aStructure;
        FStructure.Name:= '';

        xStructure:= XMLDocument1.DocumentElement;
        FStructure.Name:= xStructure.ChildNodes['Name'].Text;

        FillDBConnectionList(xStructure.ChildNodes['DBConnectionList']);
        FillDatasetList(xStructure.ChildNodes['DatasetList']);
        FillVarList(xStructure.ChildNodes['VarList']);
        FillShapedObjectList(xStructure.ChildNodes['ShapedObjectList']);
        FillConnectionList(xStructure.ChildNodes['ConnectionList']);

      end;
    end else raise exception.Create('Arquivo Inválido');
  end;
end;

procedure TPersistencyModule.FillDBConnectionList(xObj: IXMLNode);
var
  xDBConList: IXMLNodeList;
  xDBCon: IXMLNode;
  i: Integer;
  Obj: TICEDBConnection;
  aCon: TADOConnection;
  aOwner: TComponent;
begin
  if assigned(FStructure.DrawArea) then
    aOwner:= FStructure.DrawArea.Owner
  else
    aOwner:= nil;

  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    if xObj.ChildNodes[i].NodeName = 'TICEDBConnection' then begin
      xDBCon:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['DBConnection'];

      aCon:= TADOConnection.Create(aOwner);
      aCon.Name:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Name'].Text;
      aCon.CommandTimeout:= StrToIntDef(xDBCon.ChildNodes['CommandTimeout'].Text,0);
      aCon.ConnectionTimeout:= aCon.CommandTimeout;
      aCon.ConnectionString:= xDBCon.ChildNodes['ConnectionString'].Text;

      if xDBCon.ChildNodes['CursorLocation'].Text = 'clUseServer' then
        aCon.CursorLocation:= clUseServer
      else
        aCon.CursorLocation:= clUseClient;

      aCon.LoginPrompt:= False;

      Obj:= TICEDBConnection.Create(FStructure,aCon);

      if aOwner is TISISForm then
        TISISForm(aOwner).SendDBConnectionToList(Obj);
    end;
  end;
end;



procedure TPersistencyModule.FillDatasetList(xObj: IXMLNode);
var
  xDataset: IXMLNode;
  i: Integer;
  Obj: TICEDataset;
  aDataset: TADODataset;
  aOwner: TComponent;
  aName: String;
begin
  if assigned(FStructure.DrawArea) then
    aOwner:= FStructure.DrawArea.Owner
  else
    aOwner:= nil;

  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    if xObj.ChildNodes[i].NodeName = 'TICEDataset' then begin
      xDataset:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Dataset'];
      aName:= xDataset.ChildNodes.Nodes['Name'].Text;
      aDataset:= TADODataset.Create(aOwner);
      aDataset.Name:= aName;
      aDataset.CacheSize:= StrToIntDef(xDataset.ChildNodes['CacheSize'].Text,0);
      TICEDataset.Create(FStructure, aDataset);
    end;
  end;

end;

procedure TPersistencyModule.FillVarList(xObj: IXMLNode);
var
  i: Integer;
  aVar: TICEVar;
  aDatasetName: string;
  aDataset: TICEDataset;
begin
  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    if xObj.ChildNodes[i].NodeName = 'TICEVar' then begin
      aVar:= TICEVar.Create(FStructure, xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Name'].Text);
      aVar.Persistent:=  StrToBoolDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Persistent'].Text, false);
      if aVar.Persistent then begin
        aDatasetName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['DatasetName'].Text;
        aDataset:= FStructure.DatasetList.FindByName(aDatasetName);
        if assigned(aDataset) then begin
          aVar.Dataset:= aDataset;
          aVar.FieldName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['FieldName'].Text;
        end else
        aVar.Persistent:= False;
      end;
    end;
  end;
end;

procedure TPersistencyModule.FillConnectionList(xObj: IXMLNode);
begin

end;

procedure TPersistencyModule.FillShapedObjectList(xObj: IXMLNode);
begin

end;

end.
