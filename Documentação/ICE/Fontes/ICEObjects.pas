unit ICEObjects;

interface

uses
  SysUtils, Windows, Messages, Classes, Graphics, Controls, DB,
  Forms, Dialogs, dxflchrt, ADODB, ADOConEd, PairList, CryBaby, XMLIntf,
  CryBabyImp, ICEXMLSerializer, XMLDoc, xmldom, ICEHelperObjects;

type

  TICEObjectStatus = (sttReady, sttRunning, sttDisabled, sttSuccess, sttFailure);
  TObjClass = (clsNone, clsChoice, clsOperation, clsLoop, clsPseudoState, clsConnection);
  TOprType = (otNone, otPascal, otSQL, otClientCursor, otDataTransport, otSubStructure);
  TConType = (ctNone, ctDyn, ctControl, ctDepend, ctEvent);
  TEventType = (evNone, evCompletion, evSuccess, evFailure);
  TStructType = (stNone, stFor, stWhile, stDynChoice, stEndPoint, stStartPoint);

  TICEStructure = class;
  TICEShapedObject = Class;
  TISISObject = class;
  TICEEventConnection = class;
  TISISConnection = class;
  TICEConnection = class;
  TICEEndPoint = class;

  TICEStructuredObject = class(TObject)
  protected
    FICEStructure: TICEStructure;
  public
    constructor Create(aStructure: TICEStructure); virtual;
  end;

  TICEPersistenceBase = class(TICEStructuredObject)
  public
    procedure LoadConnectionList(aStream: TStream); virtual; abstract;
    procedure LoadDatasetList(aStream: TStream); virtual; abstract;
    procedure LoadDBConnectionList(aStream: TStream); virtual; abstract;
    procedure LoadFromFile(FileName: String); virtual; abstract;
    procedure LoadFromStream(aStream: TStream); virtual; abstract;
    procedure LoadShapedObjectList(aStream: TStream); virtual; abstract;
    procedure LoadVarList(aStream: TStream); virtual; abstract;
    procedure SaveConnectionList(aStream: TStream); virtual; abstract;
    procedure SaveDatasetList(aStream: TStream); virtual; abstract;
    procedure SaveDBConnectionList(aStream: TStream); virtual; abstract;
    procedure SaveShapedObjectList(aStream: TStream); virtual; abstract;
    procedure SaveToFile(FileName: String); virtual; abstract;
    procedure SaveToStream(aStream: TStream); virtual; abstract;
    procedure SaveVarList(aStream: TStream); virtual; abstract;
  end;

  TICEXMLPersistence = class(TICEPersistenceBase)
  private
    FICEXMLSerializer: TICEXMLSerializer;
    procedure FillConnectionList(xObj: IXMLNode);
    procedure FillDatasetList(xObj: IXMLNode);
    procedure FillDBConnectionList(xObj: IXMLNode);
    procedure FillShapedObjectList(xObj: IXMLNode);
    procedure FillVarList(xObj: IXMLNode);
    procedure Unserialize(XMLDoc: TXMLDocument);
  public
    constructor Create(aStructure: TICEStructure); override;
    destructor Destroy; override;
    function GetXMLDoc: TXMLDocument;
    procedure KillXMLDoc(Var XMLDoc: TXMLDocument);
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

  TICELister = class(TICEStructuredObject)
  public
    procedure FillTxtWithDatasets(Var Txt: TStringList);
    procedure FillTxtWithDBConnections(Var Txt: TStringList);
    procedure FillTxtWithVars(Var Txt: TStringList);
  end;


  TICEObject = class(TCollectionItem)
  private
    FName: string;
    FStructure: TICEStructure;
    function GetStructure: TICEStructure;
    procedure SetStructure(Value: TICEStructure);
  protected
    procedure SetName(const Value: string);
  public
    constructor Create(aStructure: TICEStructure); virtual;
    procedure Assign(Source: TPersistent); override;
    function GetObjClass: TObjClass; virtual;
    procedure Init; virtual;
    procedure SetCollection(Value: TCollection); override;
    procedure UpdateObject; virtual;
    procedure UpdateShape; virtual;
    property Structure: TICEStructure read GetStructure write SetStructure;
  published
    property Name: string read FName write SetName;
    property ObjClass: TObjClass read GetObjClass;
  end;
  

  TICEConnectionRef = class(TICEObject)
  private
    FConnection: TICEConnection;
  public
    constructor Create(aStructure: TICEStructure); override;
    property Connection: TICEConnection read FConnection;
  end;
  
  TICEConnection = class(TICEObject)
  private
    FBreakPoint: Boolean;
    FConnection: TISISConnection;
    FConType: TConType;
    FDestination: TICEShapedObject;
    FLineColor: TColor;
    FRef: TICEConnectionRef;
    FSource: TICEShapedObject;
    function GetDestinationName: string;
    function GetPersistentPoints: string;
    function GetSourceName: string;
    function GetSrcConPoint: Integer;
    function GetDstConPoint: Integer;
    procedure SetDestinationName(const Value: string);
    procedure SetPersistentPoints(const Value: string);
    procedure SetSourceName(const Value: string);
    procedure SetSrcConPoint(const Value: Integer);
    procedure SetDstConPoint(const Value: Integer);
  protected
    procedure InitRef;
    procedure InitShape; virtual;
  public
    constructor Create(aStructure: TICEStructure; Dst, Src: TICEShapedObject;
        aName: String = ''); Overload;virtual;
    constructor Create(aStructure: TICEStructure; aName: String = ''); overload;
        virtual;
    destructor Destroy; override;
    procedure Connect(Dst, Src: TICEShapedObject); virtual;
    procedure CreateShape; virtual;
    procedure doConnect; virtual;
    function Execute: Boolean; virtual;
    function GetObjClass: TObjClass; override;
    procedure UpdateObject; override;
    procedure UpdateShape; override;
    property Connection: TISISConnection read FConnection write FConnection;
    property Destination: TICEShapedObject read FDestination write FDestination;
    property LineColor: TColor read FLineColor write FLineColor;
    property Ref: TICEConnectionRef read FRef;
    property Source: TICEShapedObject read FSource write FSource;
  published
    property BreakPoint: Boolean read FBreakPoint write FBreakPoint;
    property ConType: TConType read FConType write FConType;
    property DestinationName: string read GetDestinationName write
        SetDestinationName;
    property PersistentPoints: string read GetPersistentPoints write
        SetPersistentPoints;
    property SourceName: string read GetSourceName write SetSourceName;
    property SrcConPoint: Integer read GetSrcConPoint write SetSrcConPoint;
    property DstConPoint: Integer read GetDstConPoint write SetDstConPoint;
  end;
  
  TICEControlConnection = class(TICEConnection)
  protected
    procedure InitShape; override;
  public
    constructor Create(aStructure: TICEStructure; Dst, Src: TICEShapedObject;
        aName: String = ''); overload; override;
    constructor Create(aStructure: TICEStructure; aName: String = ''); overload;
        override;
  end;
  
  TICEConnectionRefList = class;

  TICEShapedObject = class(TICEObject)
  private
    FCaption: string;
    FColor: TColor;
    FImageIndex: Integer;
    FISISObject: TISISObject;
    FShapeHeigth: Integer;
    FShapeLeft: Integer;
    FShapeStyle: TPenStyle;
    FShapeTop: Integer;
    FShapeType: TdxFcShapeType;
    FShapeWidth: Integer;
    FTxtHeigth: Integer;
    FTxtLeft: Integer;
    FTxtObject: TISISObject;
    FTxtTop: Integer;
    FTxtWidth: Integer;
    function GetName: string;
  protected
    procedure CreateShape; virtual;
    procedure SetName(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            virtual;
    destructor Destroy; override;
    procedure Connect(Connection: TICEConnection); virtual;
    procedure Disconnect(Connection: TICEConnection); virtual;
    function Execute: Boolean; virtual;
    procedure Init; override;
    procedure UpdateObject; override;
    procedure UpdateShape; override;
    property Caption: string read FCaption write FCaption;
    property Color: TColor read FColor write FColor;
    property ImageIndex: Integer read FImageIndex write FImageIndex;
    property ISISObject: TISISObject read FISISObject write FISISObject;
    property ShapeStyle: TPenStyle read FShapeStyle write FShapeStyle;
    property ShapeType: TdxFcShapeType read FShapeType write FShapeType;
    property TxtObject: TISISObject read FTxtObject write FTxtObject;
  published
    property Name: string read GetName write SetName;
    property ShapeHeigth: Integer read FShapeHeigth write FShapeHeigth;
    property ShapeLeft: Integer read FShapeLeft write FShapeLeft;
    property ShapeTop: Integer read FShapeTop write FShapeTop;
    property ShapeWidth: Integer read FShapeWidth write FShapeWidth;
    property TxtHeigth: Integer read FTxtHeigth write FTxtHeigth;
    property TxtLeft: Integer read FTxtLeft write FTxtLeft;
    property TxtTop: Integer read FTxtTop write FTxtTop;
    property TxtWidth: Integer read FTxtWidth write FTxtWidth;
  end;
  
  TICEOperation = class(TICEShapedObject)
  private
    FDependencyList: TICEConnectionRefList;
    FOnCompletion: TICEEventConnection;
    FOnFailure: TICEEventConnection;
    FOnSuccess: TICEEventConnection;
    FStatus: TICEObjectStatus;
    procedure SetOnCompletion(Value: TICEEventConnection);
    procedure SetOnFailure(Value: TICEEventConnection);
    procedure SetOnSuccess(Value: TICEEventConnection);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            override;
    procedure AttribConnection(Connection: TICEConnection); virtual;
    function CheckDependencies: Boolean;
    procedure Connect(Connection: TICEConnection); override;
    procedure Disconnect(Connection: TICEConnection); override;
    function Execute: Boolean; override;
    function GetObjClass: TObjClass; override;
    procedure Init; override;
    procedure InternalExecute; virtual;
    property DependencyList: TICEConnectionRefList read FDependencyList;
    property OnCompletion: TICEEventConnection read FOnCompletion write
            SetOnCompletion;
    property OnFailure: TICEEventConnection read FOnFailure write SetOnFailure;
    property OnSuccess: TICEEventConnection read FOnSuccess write SetOnSuccess;
  published
    property Status: TICEObjectStatus read FStatus write FStatus;
  end;
  
  TICELoop = class(TICEOperation)
  private
    FLoopConnection: TICEControlConnection;
    procedure SetLoopConnection(Value: TICEControlConnection);
  public
    procedure AttribConnection(Connection: TICEConnection); override;
    procedure Connect(Connection: TICEConnection); override;
    procedure CreateShape; override;
    procedure Disconnect(Connection: TICEConnection); override;
    procedure Init; override;
    property LoopConnection: TICEControlConnection read FLoopConnection write
            SetLoopConnection;
  end;
  
  TICEDBObject = class(TICEObject)
  end;

  TICEDBConnection = class(TICEDBObject)
  private
    FDBConnection: TADOConnection;
    FName: string;
  protected
    procedure SetName(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; aConnection: TADOConnection);
            reintroduce;
    function EditConnection: string;
  published
    property DBConnection: TADOConnection read FDBConnection write
            FDBConnection;
    property Name: string read FName write SetName;
  end;
  
  TICEDataset = class(TICEDBObject)
  private
    FDataset: TADODataset;
    FDatasource: TDatasource;
    FICEDBConnection: TICEDBConnection;
    FMasterDS: TICEDataset;
    FName: string;
    FSQL: string;
    function GetCacheSize: Integer;
    function GetICEDBCName: string;
    function GetMasterDSName: string;
    function GetSQL: string;
    procedure SetCacheSize(const Value: Integer);
    procedure SetICEDBCName(const Value: string);
    procedure SetICEDBConnection(const Value: TICEDBConnection);
    procedure SetMasterDS(Value: TICEDataset);
    procedure SetMasterDSName(const Value: string);
    procedure SetSQL(const Value: string);
  protected
    procedure SetName(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; aDataset: TADODataset; DBCName:
        String);overload;
    constructor Create(astructure: TICEStructure); overload;
    procedure StartEmpty;
    procedure StartFull;
    property CacheSize: Integer read GetCacheSize write SetCacheSize;
    property Dataset: TADODataset read FDataset write FDataset;
    property Datasource: TDatasource read FDatasource;
    property ICEDBConnection: TICEDBConnection read FICEDBConnection write
        SetICEDBConnection;
    property MasterDS: TICEDataset read FMasterDS write SetMasterDS;
    property SQL: string read GetSQL write SetSQL;
  published
    property ICEDBCName: string read GetICEDBCName write SetICEDBCName;
    property MasterDSName: string read GetMasterDSName write SetMasterDSName;
    property Name: string read FName write SetName;
    property PersistentSQL: string read FSQL write FSQL;
  end;
  
  TICEVar = class(TICEObject)
  private
    FDataset: TICEDataset;
    FDatasetName: string;
    FDescription: string;
    FFieldName: string;
    FPersistent: Boolean;
    FValue: Variant;
    function GetValue: Variant;
    procedure SetDataset(Value: TICEDataset);
    procedure SetValue(Value: Variant);
  public
    constructor Create(aStructure: TICEStructure; aName: String);
    property Dataset: TICEDataset read FDataset write SetDataset;
  published
    property DatasetName: string read FDatasetName;
    property Description: string read FDescription write FDescription;
    property FieldName: string read FFieldName write FFieldName;
    property Persistent: Boolean read FPersistent write FPersistent;
    property Value: Variant read GetValue write SetValue;
  end;
  
  TICETypedList = class(TOwnedCollection)
  protected
    function GetItem(Index: Integer): TICEObject;
    procedure SetItem(Index: Integer; Value: TICEObject);
  public
    destructor Destroy; override;
    function Add: TICEObject;
    procedure AddItem(aItem: TICEObject);
    procedure DeleteByName(ItemName: String);
    function FindByName(ItemName: String): TICEObject;
    function Insert(Index: Integer): TICEObject;
    procedure InsertItem(Index: Integer; aItem: TICEObject);
    function NameExists(aName: String): Boolean;
    procedure RemoveItem(aItem: TICEObject);
    property Items[Index: Integer]: TICEObject read GetItem write SetItem;
            default;
  published
    property Count;
  end;
  
  TICEConnectionRefList = class(TICETypedList)
  protected
    function GetItem(Index: Integer): TICEConnectionRef;
    procedure SetItem(Index: Integer; Value: TICEConnectionRef);
  public
    constructor Create(AOwner: TPersistent);
    function Add: TICEConnectionRef;
    function FindByName(ItemName: String): TICEConnectionRef;
    property Items[Index: Integer]: TICEConnectionRef read GetItem write
            SetItem; default;
  end;


  TICEConditionalList = class(TICEConnectionRefList)
  public
    function FindByValue(aValue: Variant): TICEConnectionRef;
    function ValueExists(aValue: Variant): Boolean;
  end;
  
  TICEConnectionList = class(TICETypedList)
  protected
    function GetItem(Index: Integer): TICEConnection;
    procedure SetItem(Index: Integer; Value: TICEConnection);
  public
    constructor Create(AOwner: TPersistent);
    function Add: TICEConnection;
    function FindByName(ItemName: String): TICEConnection;
    function FindFirstByDest(Dest: TICEShapedObject): TICEConnection;
    function FindFirstBySource(Source: TICEShapedObject): TICEConnection;
    function FindNextByDest(Dest: TICEShapedObject): TICEConnection;
    function FindNextBySource(Source: TICEShapedObject): TICEConnection;
    property Items[Index: Integer]: TICEConnection read GetItem write SetItem;
            default;
  end;
  

  TICEDependencyConnection = class(TICEConnection)
  private
    FTestStatus: TICEObjectStatus;
  protected
    procedure InitShape; override;
  public
    constructor Create(aStructure: TICEStructure; Dst, Src: TICEShapedObject;
        aStatus: TICEObjectStatus; aName: String = ''); overload;
    constructor Create(aStructure: TICEStructure; aStatus: TICEObjectStatus; aName:
        String = ''); overload;
    function Execute: Boolean;
  published
    property TestStatus: TICEObjectStatus read FTestStatus write FTestStatus;
  end;
  
  TICEDatasetList = class(TICETypedList)
  private
  protected
    function GetItem(Index: Integer): TICEDataset;
    procedure SetItem(Index: Integer; Value: TICEDataset);
  public
    constructor Create(AOwner: TPersistent); overload;
    constructor Create(AOwner: TPersistent; SQL, DatasetName: String); overload;
    function Add: TICEDataset;
    procedure DeleteByTableName(TableName: String);
    function FindByName(ItemName: String): TICEDataset;
    function FindByTableName(TableName: String): TADODataset;
    property Items[Index: Integer]: TICEDataset read GetItem write SetItem;
            default;
  end;
  
  TICEDBConnectionList = class(TICETypedList)
  private
  protected
    function GetItem(Index: Integer): TICEDBConnection;
    procedure SetItem(Index: Integer; Value: TICEDBConnection);
  public
    constructor Create(AOwner: TPersistent); overload;
    constructor Create(AOwner: TPersistent; ConString: String; Name: String);
            overload;
    function Add: TICEDBConnection;
    function CreateWithDialog: TADOConnection;
    function FindByName(ItemName: String): TICEDBConnection;
    property Items[Index: Integer]: TICEDBConnection read GetItem write SetItem;
            default;
  end;
  
  TICEStartPoint = class;

  TICEObjectList = class(TICETypedList)
  protected
    function GetItem(Index: Integer): TICEShapedObject;
    procedure SetItem(Index: Integer; Value: TICEShapedObject);
  public
    constructor Create(AOwner: TPersistent);
    function Add: TICEShapedObject;
    function FindByName(ItemName: String): TICEShapedObject;
    property Items[Index: Integer]: TICEShapedObject read GetItem write SetItem;
            default;
  end;
  
  TICEVarList = class(TICETypedList)
  protected
    function GetItem(Index: Integer): TICEVar;
    procedure SetItem(Index: Integer; Value: TICEVar);
  public
    constructor Create(AOwner: TPersistent);
    function Add: TICEVar;
    function FindByName(ItemName: String): TICEVar;
    function Max: TICEVar;
    function Min: TICEVar;
    property Items[Index: Integer]: TICEVar read GetItem write SetItem; default;
  end;
  
  TICEEventConnection = class(TICEConnection)
  private
    FEventType: TEventType;
  protected
    procedure InitShape; override;
  public
    constructor Create(aStructure: TICEStructure; aEventType: TEventType; Dst, Src:
        TICEShapedObject; aName: String = ''); overload;
    constructor Create(aStructure: TICEStructure; aEventType: TEventType; aName:
        String = ''); overload;
  published
    property EventType: TEventType read FEventType write FEventType;
  end;
  
  TICEConditionalConnection = class(TICEConnection)
  private
    FElseValue: Boolean;
    FValue: Variant;
  protected
    procedure InitShape; override;
  public
    constructor Create(aStructure: TICEStructure; Dst, Src: TICEShapedObject;
        aValue: Variant; aElseValue: Boolean; aName: String = ''); overload;
    constructor Create(aStructure: TICEStructure; aValue: Variant; aElseValue:
        Boolean; aName: String = ''); overload;
  published
    property ElseValue: Boolean read FElseValue write FElseValue;
    property Value: Variant read FValue write FValue;
  end;

  TICEStructure = class(TICEObject)
  private
    FActiveEndPoint: TICEEndPoint;
    FConnectionList: TICEConnectionList;
    FDatasetList: TICEDatasetList;
    FDBConnectionList: TICEDBConnectionList;
    FDrawArea: TdxFlowChart;
    FEventLog: TStringList;
    FICELister: TICELister;
    FICEPersistence: TICEPersistenceBase;
    FShapedObjectList: TICEObjectList;
    FVarList: TICEVarList;
    function GetStartPoint: TICEStartPoint;
  public
    constructor Create(aStructure: TICEStructure; aDrawArea: TdxFlowChart;
            aName: String);
    destructor Destroy; override;
    procedure Clear;
    function CreateObject(X,Y: Integer; ObjName: String; ObjClass: TObjClass;
            OprType: TOprType; StructType: TStructType): TICEShapedObject;
    function Execute: Variant; dynamic;
    procedure GetConnectionPoints(Var PSrc, PDst: Integer; Src, Dst :
            TdxfcObject);
    procedure Init; override;
    procedure LogEvent(MSG: String);
    function ValidateName(aName: String; SilentMode: Boolean = false): Boolean;
    property ActiveEndPoint: TICEEndPoint read FActiveEndPoint;
    property DrawArea: TdxFlowChart read FDrawArea write FDrawArea;
    property EventLog: TStringList read FEventLog write FEventLog;
    property ICELister: TICELister read FICELister;
    property ICEPersistence: TICEPersistenceBase read FICEPersistence write
            FICEPersistence;
    property StartPoint: TICEStartPoint read GetStartPoint;
  published
    property ConnectionList: TICEConnectionList read FConnectionList;
    property DatasetList: TICEDatasetList read FDatasetList;
    property DBConnectionList: TICEDBConnectionList read FDBConnectionList;
    property ShapedObjectList: TICEObjectList read FShapedObjectList;
    property VarList: TICEVarList read FVarList;
  end;
  
  TICEDataTransport = class(TICEOperation)
  private
    FCorrespondences: TPairList;
    FDstDataset: TICEDataset;
    FSrcDataset: TICEDataset;
    function GetDstDatasetName: string;
    function GetCorrespondencesAsString: string;
    function GetSrcDatasetName: string;
    procedure SetDstDataset(Value: TICEDataset);
            procedure SetDstDatasetName(const Value: string);
    procedure SetCorrespondencesAsString(const Value: string);
    procedure SetSrcDataset(Value: TICEDataset);
    procedure SetSrcDatasetName(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            override;
    procedure Disconnect(Connection: TICEConnection); override;
    procedure Init; override;
    procedure InternalExecute; override;
    property Correspondences: TPairList read FCorrespondences write
        FCorrespondences;
    property DstDataset: TICEDataset read FDstDataset write SetDstDataset;
    property SrcDataset: TICEDataset read FSrcDataset write SetSrcDataset;
  published
    property DstDatasetName: string read GetDstDatasetName write SetDstDatasetName;
    property CorrespondencesAsString: string read GetCorrespondencesAsString write
        SetCorrespondencesAsString;
    property SrcDatasetName: string read GetSrcDatasetName write SetSrcDatasetName;
  end;
  
  TICEPasOperation = class(TICEOperation)
  private
    FScript: string;
    function GetScript: string;
    procedure SetScript(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            override;
    procedure Compile;
    procedure Debug;
    procedure Init; override;
    procedure InternalExecute; override;
    property Script: string read GetScript write SetScript;
  published
    property PersistentScript: string read FScript write FScript;
  end;
  
  TICESqlDataCursor = class(TICEOperation)
  private
    FICEDataset: TICEDataset;
    FICEDatasetName: string;
    FOperation: TICEConnection;
    FOperationName: string;
    procedure SetICEDataset(const Value: TICEDataset);
    procedure SetOperation(Value: TICEConnection);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            override;
    procedure AttribConnection(Connection: TICEConnection); override;
    procedure Connect(Connection: TICEConnection); override;
    procedure Init; override;
    procedure InternalExecute; override;
    property ICEDataset: TICEDataset read FICEDataset write SetICEDataset;
    property Operation: TICEConnection read FOperation write SetOperation;
  published
    property ICEDatasetName: string read FICEDatasetName;
    property OperationName: string read FOperationName;
  end;
  
  TICESubStructure = class(TICEOperation)
  private
    FSubStructure: TICEStructure;
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            virtual;
    procedure Init; override;
    procedure InternalExecute; override;
  published
    property SubStructure: TICEStructure read FSubStructure write FSubStructure;
  end;
  
  TICESqlOperation = class(TICEOperation)
  private
    FICEDBConnection: TICEDBConnection;
    FPrepareCommand: Boolean;
    FSQLCommand: string;
    function GetICEDBConnectionName: string;
    function GetSQLCommand: string;
    procedure SetICEDBConnection(Value: TICEDBConnection);
  procedure SetICEDBConnectionName(const Value: string);
    procedure SetSQLCommand(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            override;
    function CompileSQL: string;
    procedure Init; override;
    procedure InternalExecute; override;
    property ICEDBConnection: TICEDBConnection read FICEDBConnection write
            SetICEDBConnection;
    property SQLCommand: string read GetSQLCommand write SetSQLCommand;
  published
    property ICEDBConnectionName: string read GetICEDBConnectionName write
        SetICEDBConnectionName;
    property PersistentSQL: string read FSQLCommand write FSQLCommand;
    property PrepareCommand: Boolean read FPrepareCommand write FPrepareCommand;
  end;
  
  TICEPseudoState = class(TICEShapedObject)
  public
    function GetObjClass: TObjClass; override;
    procedure Init; override;
  end;
  
  TICEDynamicChoice = class(TICEShapedObject)
  private
    FTestList: TICEConditionalList;
    FTestVar: TICEVar;
    function GetTestVarName: string;
    procedure SetTestVar(Value: TICEVar);
    procedure SetTestVarName(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
    destructor Destroy; override;
    procedure Connect(Connection: TICEConnection); override;
    procedure Disconnect(Connection: TICEConnection); override;
    function Execute: Boolean; override;
    function GetObjClass: TObjClass; override;
    procedure Init; override;
    property TestList: TICEConditionalList read FTestList;
    property TestVar: TICEVar read FTestVar write SetTestVar;
  published
    property TestVarName: string read GetTestVarName write SetTestVarName;
  end;
  
  TICEForLoop = class(TICELoop)
  private
    FLoopVar: TICEVar;
    FMax: Double;
    FMin: Double;
    function GetLoopVarName: string;
    procedure SetLoopVar(Value: TICEVar);
  procedure SetLoopVarName(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            override;
    procedure Init; override;
    property LoopVar: TICEVar read FLoopVar write SetLoopVar;
  published
    property LoopVarName: string read GetLoopVarName write SetLoopVarName;
    property Max: Double read FMax write FMax;
    property Min: Double read FMin write FMin;
  end;
  
  TICEStartPoint = class(TICEPseudoState)
  private
    FOnStart: TICEEventConnection;
    procedure SetOnStart(Value: TICEEventConnection);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            override;
    destructor Destroy; override;
    procedure Connect(Connection: TICEConnection); override;
    procedure Disconnect(Connection: TICEConnection); override;
    function Execute: Boolean; override;
    procedure Init; override;
    property OnStart: TICEEventConnection read FOnStart write SetOnStart;
  end;
  
  TICEEndPoint = class(TICEPseudoState)
  private
    FResultDataset: TICEDataset;
    FResultVar: TICEVar;
  public
    procedure Connect(Connection: TICEConnection); override;
    procedure Init; override;
    property ResultDataset: TICEDataset read FResultDataset;
    property ResultVar: TICEVar read FResultVar;
  published
  end;
  
  TICEWhileLoop = class(TICELoop)
  private
    FRepeatStyle: Boolean;
    FTestCondition: string;
    function GetTestCondition: string;
    procedure SetTestCondition(const Value: string);
  public
    constructor Create(aStructure: TICEStructure; X,Y: Integer; aName: String);
            override;
    procedure Init; override;
    property TestCondition: string read GetTestCondition write SetTestCondition;
  published
    property PersistentTestCondition: string read FTestCondition write
        FTestCondition;
    property RepeatStyle: Boolean read FRepeatStyle write FRepeatStyle;
  end;
  
  TISISConnection = class(TdxfcConnection)
  private
    FICEConnection: TICEConnection;
    FIsChanged: Boolean;
  public
    property ICEConnection: TICEConnection read FICEConnection write
            FICEConnection;
    property IsChanged: Boolean read FIsChanged write FIsChanged;
  published
    property PenStyle;
    property PointDest;
    property PointSource;
    property Style;
  end;
  
  TISISObject = class(TdxFcObject)
  private
    FICEObject: TICEShapedObject;
    FIsChanged: Boolean;
    FParent: TdxFcObject;
    procedure SetICEObject(Value: TICEShapedObject);
  public
    property ICEObject: TICEShapedObject read FICEObject write SetICEObject;
    property IsChanged: Boolean read FIsChanged write FIsChanged;
    property Parent: TdxFcObject read FParent write FParent;
  published
    property Height;
    property Left;
    property ShapeStyle;
    property ShapeType;
    property ShapeWidth;
    property Text;
    property Top;
    property Width;
    property ZOrder;
  end;
  
  TICEStringParser = class(TObject)
  private
  public
    class function ICEStatusToStr(aStatus: TICEObjectStatus): string;
    class function ICEClassToStr(aClass: TObjClass): string;
    class function ICEConTypeToStr(aConType: TConType): string;
    class function ICEEventTypeToStr(aEventType: TEventType): string;
    class function ICEOprTypeToStr(aOprType: TOprType): string;
    class function ICEStructTypeToStr(aStructType: TStructType): string;
    class function ParseSymbols(St: String): string;
    class function StrToICEStatus(aStatus: String): TICEObjectStatus;
    class function StrToICEClass(aClass: String): TObjClass;
    class function StrToICEConType(aConType: string): TConType;
    class function StrToICEEventType(aEventType: string): TEventType;
    class function StrToICEOprType(aOprType: string): TOprType;
    class function ClassStrToICEOprType(aStr: String): TOprType;
    class function StrToStructType(aStructType: string): TStructType;
    class function unParseSymbols(St: String): string;
  end;

implementation

uses Math;


{
******************************* TICEDBConnection *******************************
}
constructor TICEDBConnection.Create(aStructure: TICEStructure; aConnection:
        TADOConnection);
begin
  inherited Create(aStructure);
  SetCollection(Structure.DBConnectionList);
  DBConnection:= aConnection;
  Name:= aConnection.Name;
end;

function TICEDBConnection.EditConnection: string;
begin
  EditConnectionString(DBConnection);
  Result:= DBConnection.ConnectionString;
end;

procedure TICEDBConnection.SetName(const Value: string);
begin
  if FName <> Value then
  begin
    FName := Value;
    DBConnection.Name:= Value;
    Inherited SetName(Value);
  end;
end;



{
******************************** TICETypedList *********************************
}
destructor TICETypedList.Destroy;
begin
//  While Count > 0 do
//    Items[0].Free;
  inherited;
end;

function TICETypedList.Add: TICEObject;
begin
  Result :=  TICEObject(inherited Add);
end;

procedure TICETypedList.AddItem(aItem: TICEObject);
begin
  if aItem is ItemClass then
     aItem.SetCollection(Self);
end;

procedure TICETypedList.DeleteByName(ItemName: String);
var
  Idx: Integer;
begin
  Idx:= FindByName(ItemName).Index;
  Delete(Idx);
end;

function TICETypedList.FindByName(ItemName: String): TICEObject;
var
  I: Integer;
begin
  Result:= Nil;
  For i:= 0 to count -1 do
    if TICEObject(Items[i]).Name = ItemName then begin
      Result:= TICEObject(Items[i]);
      Exit;
    end;
end;

function TICETypedList.GetItem(Index: Integer): TICEObject;
begin
  Result := TICEShapedObject(inherited GetItem(Index));
end;

function TICETypedList.Insert(Index: Integer): TICEObject;
begin
  Result := TICEObject(inherited Insert(Index));
end;

procedure TICETypedList.InsertItem(Index: Integer; aItem: TICEObject);
begin
  AddItem(aItem);
  aItem.Index:= Index;
end;

function TICETypedList.NameExists(aName: String): Boolean;
var
  I: Integer;
begin
  Result:= False;
  For i:= 0 to count -1 do
    if TICEObject(Items[i]).Name = aName then begin
      Result:= True;
      Exit;
    end;
end;

procedure TICETypedList.RemoveItem(aItem: TICEObject);
begin
  aItem.SetCollection(Nil);
end;

procedure TICETypedList.SetItem(Index: Integer; Value: TICEObject);
begin
  TICEShapedObject(Items[Index]).Assign(Value);
end;

{
********************************** TICEObject **********************************
}
constructor TICEObject.Create(aStructure: TICEStructure);
begin
  //Classes descendentes devem chamar SetCollection
  //para se adicionar às listas adequadas
  inherited Create(nil);
  Structure:= aStructure;
end;

procedure TICEObject.Assign(Source: TPersistent);
begin
  if Source is (TICEObject) then begin
     Name:= TICEObject(Source).Name;
     Structure:= TICEObject(Source).Structure;
     inherited Assign(TCollectionItem(Source));
  end;
end;

function TICEObject.GetObjClass: TObjClass;
begin
  Result:= clsNone;
end;

function TICEObject.GetStructure: TICEStructure;
begin
  Result := FStructure;
end;

procedure TICEObject.Init;
begin
end;

procedure TICEObject.SetCollection(Value: TCollection);
begin
  inherited SetCollection(Value);
end;

procedure TICEObject.SetName(const Value: string);
begin
  if FName <> Value then
  begin
    FName := Value;
  end;
end;

procedure TICEObject.SetStructure(Value: TICEStructure);
begin
  if FStructure <> Value then
  begin
  FStructure := Value;
  end;
end;

procedure TICEObject.UpdateObject;
begin
end;

procedure TICEObject.UpdateShape;
begin
end;

{
**************************** TICEConnectionRefList *****************************
}
constructor TICEConnectionRefList.Create(AOwner: TPersistent);
begin
  inherited Create(AOwner, TICEConnectionRef);
end;

function TICEConnectionRefList.Add: TICEConnectionRef;
begin
  Result :=  TICEConnectionRef(inherited Add);
end;

function TICEConnectionRefList.FindByName(ItemName: String): TICEConnectionRef;
begin
  Result:= TICEConnectionRef( inherited FindByName(ItemName));
end;

function TICEConnectionRefList.GetItem(Index: Integer): TICEConnectionRef;
begin
  Result := TICEConnectionRef(inherited GetItem(Index));
end;

procedure TICEConnectionRefList.SetItem(Index: Integer; Value:
        TICEConnectionRef);
begin
  TICEConnectionRef(Items[Index]).Assign(Value);
end;

{
****************************** TICEConnectionRef *******************************
}
constructor TICEConnectionRef.Create(aStructure: TICEStructure);
begin
  inherited Create(aStructure);
  SetCollection(nil);
end;

{
******************************** TICEConnection ********************************
}
constructor TICEConnection.Create(aStructure: TICEStructure; Dst, Src:
    TICEShapedObject; aName: String = '');
begin
  Source:= Src;
  Destination:= Dst;
  Create(aStructure,aName);
  doConnect;
end;

constructor TICEConnection.Create(aStructure: TICEStructure; aName: String =
    '');
begin
  inherited Create(aStructure);
  Name:= aName;
  InitRef;
  ConType:= CtNone;
end;

destructor TICEConnection.Destroy;
begin
  if assigned(Source) then
    Source.Disconnect(Self);
  Source:= Nil;
  Destination:= Nil;
  
  if assigned(Connection) then begin
    Connection.Free;
    Connection:= Nil;
  end;
  
  inherited;
end;

procedure TICEConnection.Connect(Dst, Src: TICEShapedObject);
begin
  Source:= Src;
  Destination:= Dst;
end;

procedure TICEConnection.CreateShape;
begin
  if not assigned(Structure.DrawArea) then
    exit;
  
  if assigned(Connection) then Connection.Free;
  
  Connection:= TISISConnection.Create(Structure.DrawArea);
  
  UpdateShape;
  
end;

procedure TICEConnection.doConnect;
begin
  Source.Connect(Self);
end;

function TICEConnection.Execute: Boolean;
begin
  Result:= Destination.Execute;
end;

function TICEConnection.GetDestinationName: string;
begin
  if assigned(Destination) then
   Result:= Destination.Name;
end;

function TICEConnection.GetObjClass: TObjClass;
begin
  Result:= clsConnection;
end;

function TICEConnection.GetPersistentPoints: string;
var
  i: Integer;
  StPoints: TPairList;
begin
  StPoints:= TPairList.Create;
  if Connection.PointCount > 0 then begin
    for i:= 0 to Connection.PointCount -1 do
      StPoints.AddPair(IntToStr(Connection.Points[i].X), IntToStr(Connection.Points[i].Y));
  end;
  Result := StPoints.Text;
  StPoints.Free;
end;

function TICEConnection.GetSourceName: string;
begin
  if assigned(Source) then
   Result:= Source.Name;
end;

function TICEConnection.GetSrcConPoint: Integer;
begin
  Result:= 0;
  if assigned(Connection) then
    Result:= Connection.PointSource;
end;

function TICEConnection.GetDstConPoint: Integer;
begin
  Result:= 0;
  if assigned(Connection) then
    Result:= Connection.PointDest;
end;

procedure TICEConnection.InitRef;
var
  Idx: Integer;
  Tmp: string;
begin
  FRef:= TICEConnectionRef.Create(Structure);

  if Name = '' then begin
    Idx:= Random(36)+1;

    repeat
      Tmp:= ExpandToB36(B36[idx],18);
      Name:= 'Con'+Tmp;
    until (Structure.ValidateName(Name, true));

     FRef.Name:= 'Ref'+Tmp;

  end else begin
    FRef.Name:= 'Ref'+Copy(Name, 4, Length(Name));
  end;

  SetCollection(Structure.ConnectionList);

  FRef.FConnection:= Self;
end;

procedure TICEConnection.InitShape;
begin
  Connect(Destination, Source);
  CreateShape;
end;

procedure TICEConnection.SetDestinationName(const Value: string);
begin
  Destination:= Structure.ShapedObjectList.FindByName(Value);
end;

procedure TICEConnection.SetPersistentPoints(const Value: string);
var
  Xs, Ys: String;
  P: TPoint;
  i: Integer;
  StPoints: TPairList;
begin
  StPoints:= TPairList.Create;
  if Value <> '' then
    StPoints.Text:= Value;

  if StPoints.Count > 0 then
    for i:= 0 to StPoints.Count -1 do begin
      StPoints.GetPair(i, Xs, Ys);
      P.X:= StrToIntDef(Xs, 0);
      P.Y:= StrToIntDef(Ys, 0);

      Connection.AddPoint(P);
    end;

    StPoints.Free;
end;

procedure TICEConnection.SetSourceName(const Value: string);
begin
  Source:= Structure.ShapedObjectList.FindByName(Value);
end;

procedure TICEConnection.SetSrcConPoint(const Value: Integer);
begin
  Connection.SetObjectSource(Source.ISISObject,Value);
end;

procedure TICEConnection.SetDstConPoint(const Value: Integer);
begin
  Connection.SetObjectDest(Destination.ISISObject,Value);
end;

procedure TICEConnection.UpdateObject;
var
  Src, Dst: TICEShapedObject;
begin
  Src:= TICEShapedObject(TISISObject(Connection.ObjectSource).IceObject);
  Dst:= TICEShapedObject(TISISObject(Connection.ObjectDest).IceObject);

  if (Src <> Source) or (Dst <> Destination) then begin
    if (Src <> Source) then begin
      Source.Disconnect(Self);
      Source:= Src;
    end;

    Destination:= Dst;

    Source.Connect(Self);
  end;

end;

procedure TICEConnection.UpdateShape;
var
  P1, P2: Integer;
begin
  With Connection do begin
    Color := LineColor;
    PenStyle:= psSolid;
    Style:= fclStraight;
    ArrowSource.ArrowType:= fcaEllipse;
    ArrowSource.Height:= 10;
    ArrowSource.Width:= 10;
    ArrowSource.Color:= clWhite;
    ArrowDest.ArrowType:= fcaArrow;
    ArrowDest.Height:= 10;
    ArrowDest.Width:= 10;
    ArrowDest.Color:= LineColor;
    Structure.GetConnectionPoints(P1,P2, Source.ISISObject,Destination.ISISObject);
    SetObjectSource(Source.ISISObject,P1);
    SetObjectDest(Destination.ISISObject,P2);
    ICEConnection:= Self;
  end;
end;

{
**************************** TICEControlConnection *****************************
}
constructor TICEControlConnection.Create(aStructure: TICEStructure; Dst, Src:
    TICEShapedObject; aName: String = '');
begin
  inherited Create(aStructure, Dst, Src, aName);
  InitShape;
  doConnect;
end;

constructor TICEControlConnection.Create(aStructure: TICEStructure; aName:
    String = '');
begin
  inherited Create(aStructure, aName);
  InitRef;
  ConType:= ctControl;
end;

procedure TICEControlConnection.InitShape;
begin
  LineColor:= clBlack;
  inherited;
end;


{
******************************* TICEShapedObject *******************************
}
constructor TICEShapedObject.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure);
  Name:= aName;
  ShapeLeft:= X;
  ShapeTop:= Y;
  
  if assigned(Structure) then begin
    SetCollection(Structure.ShapedObjectList);
    CreateShape;
  end;
end;

destructor TICEShapedObject.Destroy;
var
  i: Integer;
  KillList: TICEConnectionList;
begin
  KillList:= TICEConnectionList.Create(nil);
  if assigned(Structure) then
    if Structure.ConnectionList.Count > 0 then begin
      for i:= 0 to Structure.ConnectionList.Count -1 do begin
        if (Structure.ConnectionList.Items[i].Source = Self)
          or (Structure.ConnectionList.Items[i].Destination = Self) then begin
            KillList.AddItem(Structure.ConnectionList.Items[i]);
          end;
      end;
    end;

//  while KillList.Count > 0 do begin
//    Disconnect(Structure.ConnectionList.Items[0]);
//    KillList.Items[0].Free;
//  end;


  KillList.Free;

  if assigned(FISISObject) then
     FISISObject.Free;
  if assigned(FTxtObject) then
     FTxtObject.Free;

  inherited Destroy;
end;

procedure TICEShapedObject.Connect(Connection: TICEConnection);
begin
end;

procedure TICEShapedObject.CreateShape;
var
  Canvas: TCanvas;
begin
  if not assigned(Structure.DrawArea) then
    exit;
  
  Init;
  
  if assigned(ISISObject) then ISISObject.Free;
  if assigned(TxtObject) then TxtObject.Free;

  if Name = '' then Name:= 'Teste';

  ISISObject:= TISISObject.Create(Structure.DrawArea);
  Canvas:= TForm(Structure.DrawArea.Owner).Canvas;
  TxtObject:= TISISObject.Create(Structure.DrawArea);

  TxtHeigth := Canvas.TextHeight(Name)+2;
  TxtWidth:= Canvas.TextWidth(Name)+3;
  TxtTop:= ShapeTop+ShapeHeigth;
  TxtLeft:= Trunc((ShapeWidth-TxtWidth)/2) + ShapeLeft;

  ISISObject.AddToUnion(TxtObject);
  TxtObject.Parent:= ISISObject;
  ISISObject.ICEObject:= Self;
  TxtObject.IceObject:= Self;

  UpdateShape;
end;

procedure TICEShapedObject.Disconnect(Connection: TICEConnection);
begin
  //
end;

function TICEShapedObject.Execute: Boolean;
begin
  Result:= true;
end;

function TICEShapedObject.GetName: string;
begin
  Result:= FName;
end;

procedure TICEShapedObject.Init;
begin
  inherited Init;
  ShapeWidth:= 43;
  ShapeHeigth:= 43;
end;

procedure TICEShapedObject.SetName(const Value: string);
begin
  if FName <> Value then
  begin
    FName := Value;
    if assigned(TxtObject) then
      TxtObject.Text:= Value;
  
  end;
end;

procedure TICEShapedObject.UpdateObject;
begin
  ShapeLeft:= ISISObject.Left;
  ShapeTop:= ISISObject.Top;
  ShapeWidth:= ISISObject.Width;
  ShapeHeigth:= ISISObject.Height;
  Color:= ISISObject.ShapeColor;
  ShapeType:= ISISObject.ShapeType;
  ShapeStyle:= ISISObject.ShapeStyle;
  Caption:= ISISObject.Text;
  ImageIndex:= ISISObject.ImageIndex;
  
  Name:= TxtObject.Text;
  TxtHeigth:= TxtObject.Height;
  TxtWidth:= TxtObject.Width;
  TxtTop:= TxtObject.Top;
  TxtLeft:= TxtObject.Left;
end;

procedure TICEShapedObject.UpdateShape;
begin
  if not assigned(ISISObject) then
     exit;
  
  ISISObject.Left:= ShapeLeft;
  ISISObject.Top:= ShapeTop;
  ISISObject.Width:= ShapeWidth;
  ISISObject.Height:= ShapeHeigth;
  ISISObject.BkColor:= Color;
  ISISObject.ShapeType:= ShapeType;
  ISISObject.ShapeStyle:= ShapeStyle;
  ISISObject.Text:= Caption;
  ISISObject.ImageIndex:= ImageIndex;
  ISISObject.VertImagePos:= fcvpCenter;
  ISISObject.HorzImagePos:= fchpCenter;
  
  if not assigned(TxtObject) then
     exit;
  
  TxtObject.Text:= Name;
  TxtObject.VertTextPos:= fcvpUp;
  TxtObject.HorzTextPos:= fchpLeft;
  TxtObject.Height:= TxtHeigth;
  TxtObject.Width:= TxtWidth;
  TxtObject.Top:= TxtTop;
  TxtObject.Left:= TxtLeft;
end;

{
******************************** TICEOperation *********************************
}
constructor TICEOperation.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, aName);
  FDependencyList:= TICEConnectionRefList.Create(Self);
  if assigned(TxtObject) then
    TxtObject.Text:= aName;
  Status:= sttReady;
end;

procedure TICEOperation.AttribConnection(Connection: TICEConnection);
begin
  if Connection is TICEEventConnection then begin
    case TICEEventConnection(Connection).EventType of
      evSuccess: begin
        OnSuccess:= TICEEventConnection(Connection);
        if assigned (OnCompletion) then
          Disconnect(OnCompletion);
      end;
      evFailure: begin
        OnFailure:= TICEEventConnection(Connection);
      end;
      evCompletion: begin
        OnCompletion:= TICEEventConnection(Connection);
        if assigned (OnSuccess) then
          Disconnect(OnSuccess);
      end;
    end;
  end else if Connection is TICEDependencyConnection then
    DependencyList.AddItem(TICEDependencyConnection(Connection).Ref);
end;

function TICEOperation.CheckDependencies: Boolean;
var
  i: Integer;
  Con: TICEDependencyConnection;
begin
  Result:= True;
  for i:= 0 to DependencyList.Count-1 do begin
    Con:= TICEDependencyConnection(DependencyList[i].Connection);
    Result:= Result and Con.Execute;
  end;
end;

procedure TICEOperation.Connect(Connection: TICEConnection);
begin
  inherited Connect(Connection);
  if (not ((Connection is TICEEventConnection)
  or (Connection is TICEDependencyConnection))) then begin
    raise exception.create('Apenas conxões de evento ou dependência podem ser ligadas a operações.');
  end;
  
  AttribConnection(Connection);
end;

procedure TICEOperation.Disconnect(Connection: TICEConnection);
var
  i: Integer;
begin
  inherited Disconnect(Connection);
  if Connection is TICEEventConnection then begin
    case TICEEventConnection(Connection).FEventType of
      evCompletion: FOnCompletion:= Nil;
      evSuccess: FOnSuccess:= Nil;
      evFailure: FOnFailure:= Nil;
    end;
  
  end else if Connection is TICEDependencyConnection then begin
    for i:= 0 to DependencyList.Count -1 do
      if DependencyList.Items[i].Connection = Connection then
        DependencyList.RemoveItem(Connection.Ref);
  
  end;
end;

function TICEOperation.Execute: Boolean;
begin
  Structure.LogEvent('Início da execução do objeto '+Name);
  If CheckDependencies then begin
    try

      InternalExecute;
      Structure.LogEvent('Término da execução do objeto '+Name);

      if assigned(FOnSuccess) then
        OnSuccess.Execute
      else if assigned(FOnCompletion) then
        OnCompletion.Execute;
    except
      on E: Exception do begin
        Structure.LogEvent('Erro no objeto '+Name +' - '+ E.Message);
        If assigned(FOnFailure) then
          OnFailure.Execute
        else if assigned(FOnCompletion) then
          OnCompletion.Execute;
      end;
    end;
  end else begin
    Status:= sttFailure;
    raise exception.Create('Falha de dependência');
  end;
  Result:= True;
end;

function TICEOperation.GetObjClass: TObjClass;
begin
  Result:= clsOperation;
end;

procedure TICEOperation.Init;
begin
  inherited Init;
  Status:= sttReady;
end;

procedure TICEOperation.InternalExecute;
begin
  Status:= sttRunning;
  
end;

procedure TICEOperation.SetOnCompletion(Value: TICEEventConnection);
begin
  if FOnCompletion <> Value then
  begin
    if assigned(FOnSuccess) then
      FreeAndNil(FOnSuccess);
    FOnCompletion := Value;
  end;
end;

procedure TICEOperation.SetOnFailure(Value: TICEEventConnection);
begin
  if FOnFailure <> Value then
  begin
    FOnFailure := Value;
  end;
end;

procedure TICEOperation.SetOnSuccess(Value: TICEEventConnection);
begin
  if FOnSuccess <> Value then
  begin
    If assigned(FOnCompletion) then
       FreeAndNil(FOnCompletion);
    FOnSuccess := Value;
  end;
end;

{
*********************************** TICELoop ***********************************
}
procedure TICELoop.AttribConnection(Connection: TICEConnection);
begin
  inherited AttribConnection(Connection);
  If Connection is TICEControlConnection then
    LoopConnection:= TICEControlConnection(Connection);
end;

procedure TICELoop.Connect(Connection: TICEConnection);
begin
  if (not ((Connection is TICEEventConnection)
  or (Connection is TICEControlConnection))) then begin
    raise exception.create('Apenas conxões de evento ou controle podem ser ligadas a estruturas de controle.');
  end;
  
  
  
  AttribConnection(Connection);
end;

procedure TICELoop.CreateShape;
begin
  inherited CreateShape;
    ISISObject.HorzTextPos:= fchpRight;
    ISISObject.HorzImagePos:= fchpLeft;
end;

procedure TICELoop.Disconnect(Connection: TICEConnection);
begin
  //Desconexão para loops
end;

procedure TICELoop.Init;
begin
  inherited Init;
  ShapeWidth:= 70;
end;

procedure TICELoop.SetLoopConnection(Value: TICEControlConnection);
begin
  if FLoopConnection <> Value then
  begin
    If assigned(FLoopConnection) then
       FreeAndNil(FLoopConnection);
    FLoopConnection := Value;
  end;
end;

{
*********************************** TICEVar ************************************
}
constructor TICEVar.Create(aStructure: TICEStructure; aName: String);
begin
  inherited Create(aStructure);
  SetCollection(Structure.VarList);
  Name:= aName;
end;

function TICEVar.GetValue: Variant;
begin
  if assigned(FDataset) then begin
    if FFieldName <> '' then begin
      FValue:= Dataset.Dataset.FieldByName(FFieldName).Value;
    end;
  end;
  Result := FValue;
end;

procedure TICEVar.SetDataset(Value: TICEDataset);
begin
  if FDataset <> Value then
  begin
    If Value <> Nil then
      FDatasetName:= Value.Name
    else
      FDatasetName:= '';
  
    FDataset := Value;
  end;
end;

procedure TICEVar.SetValue(Value: Variant);
begin
  if FValue <> Value then
  begin
  if assigned(FDataset) then begin
    if FFieldName <> '' then begin
  
      if (Dataset.Dataset.State in [dsInsert, dsEdit]) then
        Dataset.Dataset.Post;
  
      Dataset.Dataset.Edit;
      Dataset.Dataset.FieldByName(FFieldName).Value:= Value;
      Dataset.Dataset.Post
  
    end;
  end;
  FValue := Value;
  end;
end;

{
***************************** TICEConditionalList ******************************
}
function TICEConditionalList.FindByValue(aValue: Variant): TICEConnectionRef;
var
  i: Integer;
  CC: TICEConditionalConnection;
begin
  result:= nil;
  for i:= 0 to Count -1 do begin
    If Items[i].Connection is TICEConditionalConnection then begin
      CC:= TICEConditionalConnection(Items[i].Connection);
      If aValue = CC.Value then begin
        Result:= Items[i];
        exit;
      end;
    end;
  end;
end;

function TICEConditionalList.ValueExists(aValue: Variant): Boolean;
var
  i: Integer;
  CC: TICEConditionalConnection;
begin
  result:= false;
  for i:= 0 to Count -1 do begin
    If Items[i].Connection is TICEConditionalConnection then begin
      CC:= TICEConditionalConnection(Items[i].Connection);
      If aValue = CC.Value then begin
        Result:= True;
        exit;
      end;
    end;
  end;
end;

{
*************************** TICEDependencyConnection ***************************
}
constructor TICEDependencyConnection.Create(aStructure: TICEStructure; Dst,
    Src: TICEShapedObject; aStatus: TICEObjectStatus; aName: String = '');
begin
  Source:= Src;
  Destination:= Dst;
  Create(aStructure, aStatus, aName);
  InitShape;
  doConnect;
end;

constructor TICEDependencyConnection.Create(aStructure: TICEStructure; aStatus:
    TICEObjectStatus; aName: String = '');
begin
  inherited Create(aStructure, aName);
  InitRef;
  TestStatus:= aStatus;
  ConType:= ctDepend;
end;

function TICEDependencyConnection.Execute: Boolean;
begin
  Result:= TICEOperation(Destination).Status = TestStatus;
end;

procedure TICEDependencyConnection.InitShape;
begin
  LineColor:= clGray;
  inherited;
  Connection.PenStyle:= psDash;
end;

{
******************************* TICEDatasetList ********************************
}
constructor TICEDatasetList.Create(AOwner: TPersistent);
begin
  inherited Create(AOwner, TICEDataset);
end;

constructor TICEDatasetList.Create(AOwner: TPersistent; SQL, DatasetName:
        String);
begin
    // TODO -cMM: TICEDatasetList.Create default body inserted
  //  inherited C;
end;

function TICEDatasetList.Add: TICEDataset;
begin
  Result :=  TICEDataset(inherited Add);
end;

procedure TICEDatasetList.DeleteByTableName(TableName: String);
begin
end;

function TICEDatasetList.FindByName(ItemName: String): TICEDataset;
begin
  Result:= TICEDataset( inherited FindByName(ItemName));
end;

function TICEDatasetList.FindByTableName(TableName: String): TADODataset;
begin
  { TODO : FindByTableName }
  result:= nil;
end;

function TICEDatasetList.GetItem(Index: Integer): TICEDataset;
begin
  Result := TICEDataset(inherited GetItem(Index));
end;

procedure TICEDatasetList.SetItem(Index: Integer; Value: TICEDataset);
begin
  TICEDataset(Items[Index]).Assign(Value);
end;

{
***************************** TICEDBConnectionList *****************************
}
constructor TICEDBConnectionList.Create(AOwner: TPersistent);
begin
  inherited Create(AOwner, TICEDBConnection);
end;

constructor TICEDBConnectionList.Create(AOwner: TPersistent; ConString: String;
        Name: String);
begin
    // TODO -cMM: TICEDBConnectionList.Create default body inserted
  //  inherited;
end;

function TICEDBConnectionList.Add: TICEDBConnection;
begin
  Result :=  TICEDBConnection(inherited Add);
end;

function TICEDBConnectionList.CreateWithDialog: TADOConnection;
begin
  { TODO : CreateWithDialog }
  result:= nil;
end;

function TICEDBConnectionList.FindByName(ItemName: String): TICEDBConnection;
begin
  Result:= TICEDBConnection( inherited FindByName(ItemName));
end;

function TICEDBConnectionList.GetItem(Index: Integer): TICEDBConnection;
begin
  Result := TICEDBConnection(inherited GetItem(Index));
end;

procedure TICEDBConnectionList.SetItem(Index: Integer; Value: TICEDBConnection);
begin
  TICEDBConnection(Items[Index]).Assign(Value);
end;

{
******************************** TICEObjectList ********************************
}
constructor TICEObjectList.Create(AOwner: TPersistent);
begin
  inherited Create(AOwner, TICEShapedObject);
end;

function TICEObjectList.Add: TICEShapedObject;
begin
  Result :=  TICEShapedObject(inherited Add);
end;

function TICEObjectList.FindByName(ItemName: String): TICEShapedObject;
begin
  Result:= TICEShapedObject( inherited FindByName(ItemName));
end;

function TICEObjectList.GetItem(Index: Integer): TICEShapedObject;
begin
  Result := TICEShapedObject(inherited GetItem(Index));
end;

procedure TICEObjectList.SetItem(Index: Integer; Value: TICEShapedObject);
begin
  TICEShapedObject(Items[Index]).Assign(Value);
end;

{
********************************* TICEVarList **********************************
}
constructor TICEVarList.Create(AOwner: TPersistent);
begin
  inherited Create(AOwner, TICEVar);
end;

function TICEVarList.Add: TICEVar;
begin
  Result :=  TICEVar(inherited Add);
end;

function TICEVarList.FindByName(ItemName: String): TICEVar;
begin
  Result:= TICEVar( inherited FindByName(ItemName));
end;

function TICEVarList.GetItem(Index: Integer): TICEVar;
begin
  Result := TICEVar(inherited GetItem(Index));
end;

function TICEVarList.Max: TICEVar;
begin
  { TODO : Max }
  result:= nil;
end;

function TICEVarList.Min: TICEVar;
begin
  { TODO : Min }
  result:= nil;
end;

procedure TICEVarList.SetItem(Index: Integer; Value: TICEVar);
begin
  TICEVar(Items[Index]).Assign(Value);
end;

{
***************************** TICEEventConnection ******************************
}
constructor TICEEventConnection.Create(aStructure: TICEStructure; aEventType:
    TEventType; Dst, Src: TICEShapedObject; aName: String = '');
begin
  Source:= Src;
  Destination:= Dst;
  Create(aStructure, aEventType, aName);
  InitShape;
  doConnect;
end;

{
***************************** TICEEventConnection ******************************
}
constructor TICEEventConnection.Create(aStructure: TICEStructure; aEventType:
    TEventType; aName: String = '');
begin
  inherited Create(aStructure, aName);
  EventType:= aEventType;
  ConType:= ctEvent;
end;

procedure TICEEventConnection.InitShape;
begin
  Case EventType of
     evCompletion: begin
        LineColor:= clBlue;
      end;
      evSuccess: begin
        LineColor:= clGreen;
      end;
      evFailure: begin
        LineColor:= clRed;
      end;
      evNone: begin
        LineColor:= clBlack;
      end;
  end;
  inherited;
end;

{
************************** TICEConditionalConnection ***************************
}
constructor TICEConditionalConnection.Create(aStructure: TICEStructure; Dst,
    Src: TICEShapedObject; aValue: Variant; aElseValue: Boolean; aName: String
    = '');
begin
  Source:= Src;
  Destination:= Dst;
  Create(aStructure, aValue, ElseValue, aName);
  InitShape;
  doConnect;
end;

{
************************** TICEConditionalConnection ***************************
}
constructor TICEConditionalConnection.Create(aStructure: TICEStructure; aValue:
    Variant; aElseValue: Boolean; aName: String = '');
begin
  inherited Create(aStructure, aName);
  FValue:= aValue;
  FElseValue:= aElseValue;
  ConType:= ctDyn;
end;

procedure TICEConditionalConnection.InitShape;
begin
  FLineColor:= clOlive;
  inherited;
end;

{
******************************** TICEStructure *********************************
}
constructor TICEStructure.Create(aStructure: TICEStructure; aDrawArea:
        TdxFlowChart; aName: String);
begin
  inherited Create(aStructure);
  FDrawArea:= aDrawArea;
  FDatasetList:= TICEDatasetList.Create(Self);
  FDBConnectionList:= TICEDBConnectionList.Create(Self);
  FVarList:= TICEVarList.Create(Self);
  FShapedObjectList:= TICEObjectList.Create(Self);
  FConnectionList:= TICEConnectionList.Create(Self);
  FICELister:= TICELister.Create(Self);
  FEventLog:= TStringList.Create;

  TICEStartPoint.Create(Self,36,36, 'SartPoint');
  Name:= aName;
end;

destructor TICEStructure.Destroy;
begin
  FDatasetList.Free;
  FDBConnectionList.Free;
  FShapedObjectList.Free;
  FVarList.Free;
  FEventLog.Free;
  FConnectionList.Free;
  inherited Destroy;
end;

procedure TICEStructure.Clear;
begin
  FEventLog.clear;
  FDatasetList.Clear;
  FDBConnectionList.Clear;
  FVarList.Clear;
  FShapedObjectList.Clear;
  FConnectionList.Clear;
end;

function TICEStructure.CreateObject(X,Y: Integer; ObjName: String; ObjClass:
        TObjClass; OprType: TOprType; StructType: TStructType):
        TICEShapedObject;
var
  Obj: TICEShapedObject;
begin
  Obj:= Nil;
  
  Case ObjClass of
    clsOperation: Case OprType of
      otPascal: Obj:= TICEPasOperation.Create(Self,X,Y, ObjName);
      otSQL: Obj:= TICESqlOperation.Create(Self,X,Y, ObjName);
      otClientCursor: Obj:= TICESqlDataCursor.Create(Self,X,Y, ObjName);
      otDataTransport: Obj:= TICEDataTransport.Create(Self,X,Y, ObjName);
      otSubStructure: Obj:= TICESubStructure.Create(Self,X,Y, ObjName);
    end;
    clsLoop: Case StructType of
      stFor: Obj:= TICEForLoop.Create(Self,X,Y, ObjName);
      stWhile: Obj:= TICEWhileLoop.Create(Self,X,Y, ObjName);
    end;
    clsChoice: Obj:= TICEDynamicChoice.Create(Self,X,Y, ObjName);
    clsPseudoState: Case StructType of
      stEndPoint: Obj:= TICEEndPoint.Create(Self, X,Y, ObjName);
      stStartPoint: Obj:= TICEStartPoint.Create(Self, X, Y, ObjName);
    end;
  end;
  
  Result:= Obj;
  
end;

function TICEStructure.Execute: Variant;
begin
  EventLog.Clear;
  LogEvent('Iniciado');
  StartPoint.Execute;
  LogEvent('Terminado');
end;

procedure TICEStructure.GetConnectionPoints(Var PSrc, PDst: Integer; Src, Dst :
        TdxfcObject);
var
  P1, P2: TPoint;
  TX: Integer;
begin
    //  0  1   2  3  4
    //  15           5
    //  14           6
    //  13           7
    //  12 11 10  9  8
  P1.X:= Trunc(Src.Width /2)+ Src.Left;
  P1.Y:= Trunc(Src.Height /2)+ Src.Top;
  
  P2.X:= Trunc(Dst.Width /2)+ Dst.Left;
  P2.Y:= Trunc(Dst.Height /2)+ Dst.Top;
  
  TX:= P1.X - P2.X;
  
  if (P1.X < P2.X) and (Abs(TX) > 10) then begin
      // S D
      PSrc:= 6;
      PDst:= 14;
  end else
  if (P1.X > P2.X) and (Abs(TX) > 10) then begin
      //D S
      PSrc:= 14;
      PDst:= 6;
  end else
  if Abs(Tx) < 10 then begin
    if P1.Y < P2.Y then begin
      //S
      //D
      PSrc:= 10;
      PDst:= 2;
    end else begin
      //D
      //S
      PSrc:= 2;
      PDst:= 10;
    end;
  end;
end;

function TICEStructure.GetStartPoint: TICEStartPoint;
begin
  Result:= TICEStartPoint(ShapedObjectList.FindByName('StartPoint'));
end;

procedure TICEStructure.Init;
begin
  inherited;
  
end;

procedure TICEStructure.LogEvent(MSG: String);
begin
  EventLog.Add(MSG+' - '+TimeToStr(Now));
end;

function TICEStructure.ValidateName(aName: String; SilentMode: Boolean =
        false): Boolean;
var
  i: Integer;
  O: Integer;
begin
  Result:= True;
  
  if VarList.NameExists(aName) or ConnectionList.NameExists(aName)
  or DatasetList.NameExists(aName) or DBConnectionList.NameExists(aName)
  or ShapedObjectList.NameExists(aName) then begin
    Result:= False;
    if not SilentMode then
      MessageDlg('O nome digitado já existe na estrutura!', mtError, [mbOK], 0);
    Exit;
  end;
  
  if aName = '' then begin
    Result:= False;
    if not SilentMode then
      MessageDlg('Nomes nulos não são permitidos!', mtError, [mbOK], 0);
    Exit;
  end;
  
  O:= Ord(aName[1]);
  
  if not (((O >= 65) and (O <= 90)) or
          ((O >= 97) and (O <= 122)))
  then begin
    Result:= False;
    if not SilentMode then
      MessageDlg('O primeiro caractere do nome deve ser uma letra!', mtError, [mbOK], 0);
    Exit;
  end;
  
  for i:= 1 to Length(aName) do begin
    O:= Ord(aName[i]);
  
    if not (((O >= 65) and (O <= 90)) or
            ((O >= 97) and (O <= 122)) or
            ((O >= 48) and (O <= 57)) or
            (aName[i] = '_'))
    then begin
      Result:= False;
      if not SilentMode then
        MessageDlg('Carctere inválido '+QuotedStr(aName[i]), mtError, [mbOK], 0);
      Exit;
    end;
  end;
  
end;

{
****************************** TICEDataTransport *******************************
}
constructor TICEDataTransport.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, aName);
  Correspondences:= TPairList.Create;
end;

procedure TICEDataTransport.Disconnect(Connection: TICEConnection);
begin
  //Desconexão para DTs
end;

function TICEDataTransport.GetDstDatasetName: string;
begin
  if assigned(DstDataset) then
    Result:= DstDataset.Name;
end;

function TICEDataTransport.GetCorrespondencesAsString: string;
begin
  Result:= Correspondences.Text;
end;

function TICEDataTransport.GetSrcDatasetName: string;
begin
  if assigned(SrcDataset) then
    Result := SrcDataset.Name;
end;

procedure TICEDataTransport.Init;
begin
  inherited Init;
  ImageIndex:= 1;
  ShapeType:= fcsRoundRect;
  Color:= $0080FFFF;
end;

procedure TICEDataTransport.InternalExecute;
var
  i: Integer;
  F1, F2: string;
begin
  inherited InternalExecute;

  SrcDataset.StartFull;
  DstDataset.StartEmpty;

  Repeat
    DstDataset.Dataset.Insert;

    For i:= 0 to Correspondences.Count -1 do begin
      F1:= Correspondences.GetValue(i);
      F2:= Correspondences.GetKey(i);
      DstDataset.Dataset.FieldByName(F1).Value:= SrcDataset.Dataset.FieldByName(F2).Value;
    end;

    DstDataset.Dataset.Post;
    SrcDataset.Dataset.Next;
  Until SrcDataset.Dataset.Eof;

  DstDataset.Dataset.UpdateBatch;
end;

procedure TICEDataTransport.SetDstDataset(Value: TICEDataset);
begin
  if FDstDataset <> Value then
  begin
    FDstDataset := Value;
  end;
end;

procedure TICEDataTransport.SetDstDatasetName(const Value: string);
begin
  DstDataset:= Structure.DatasetList.FindByName(Value);
end;

procedure TICEDataTransport.SetCorrespondencesAsString(const Value: string);
begin
  Correspondences.Text:= Value;
end;

procedure TICEDataTransport.SetSrcDataset(Value: TICEDataset);
begin
  if FSrcDataset <> Value then
  begin
    FSrcDataset := Value;
  end;
end;

procedure TICEDataTransport.SetSrcDatasetName(const Value: string);
begin
  SrcDataset:= Structure.DatasetList.FindByName(Value);
end;

{
******************************* TICEPasOperation *******************************
}
constructor TICEPasOperation.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, aName);
  Script:='Begin'#13#13'End;';
end;

procedure TICEPasOperation.Compile;
begin
end;

procedure TICEPasOperation.Debug;
begin
end;

function TICEPasOperation.GetScript: string;
begin
  Result := TICEStringParser.unParseSymbols(FScript);
end;

procedure TICEPasOperation.Init;
begin
  inherited Init;
  ImageIndex:= 8;
  ShapeType:= fcsRoundRect;
  Color:= $0080FFFF;
end;

procedure TICEPasOperation.InternalExecute;
begin
  inherited InternalExecute;
end;

procedure TICEPasOperation.SetScript(const Value: string);
begin
  if FScript <> TICEStringParser.ParseSymbols(Value) then
  begin
    FScript := TICEStringParser.ParseSymbols(Value);
  end;
end;

{
****************************** TICESqlDataCursor *******************************
}
constructor TICESqlDataCursor.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, aName);
end;

procedure TICESqlDataCursor.AttribConnection(Connection: TICEConnection);
begin
  inherited AttribConnection(Connection);
  if Connection is TICEControlConnection then begin
     Operation:= TICEControlConnection(Connection);
  end;
end;

procedure TICESqlDataCursor.Connect(Connection: TICEConnection);
begin
  if (Connection is TICEConditionalConnection) then begin
    raise exception.create('Conexões condicionais não podem ser ligadas a cursores de dados.');
  end;
  
  AttribConnection(Connection);
end;

procedure TICESqlDataCursor.Init;
begin
  inherited Init;
  ImageIndex:= 2;
  ShapeType:= fcsRoundRect;
  Color:= $0080FFFF;
end;

procedure TICESqlDataCursor.InternalExecute;
begin
  inherited InternalExecute;
end;

procedure TICESqlDataCursor.SetICEDataset(const Value: TICEDataset);
begin
  if FICEDataset <> Value then
  begin
    if Value <> Nil then
      FICEDatasetName:= Value.Name
    else
    FICEDataset := Value;
  end;
end;

procedure TICESqlDataCursor.SetOperation(Value: TICEConnection);
begin
  if FOperation <> Value then
  begin
  if assigned(FOperation) then
     FreeAndNil(FOperation);
  
  if Value <> Nil then
    FOperationName:= Value.Name
  else
    FOperationName:= '';
    FOperation := Value;
  end;
end;

{
****************************** TICEConnectionList ******************************
}
constructor TICEConnectionList.Create(AOwner: TPersistent);
begin
  inherited Create(AOwner, TICEConnection);
end;

function TICEConnectionList.Add: TICEConnection;
begin
  Result :=  TICEConnection(inherited Add);
end;

function TICEConnectionList.FindByName(ItemName: String): TICEConnection;
begin
  Result:= TICEConnection( inherited FindByName(ItemName));
end;

function TICEConnectionList.FindFirstByDest(Dest: TICEShapedObject):
        TICEConnection;
begin
  { TODO : FindFirstByDest }
  result:= nil;
end;

function TICEConnectionList.FindFirstBySource(Source: TICEShapedObject):
        TICEConnection;
begin
  { TODO : FindFirstBySource }
  result:= nil;
end;

function TICEConnectionList.FindNextByDest(Dest: TICEShapedObject):
        TICEConnection;
begin
  { TODO : FindNextByDest }
  result:= nil;
end;

function TICEConnectionList.FindNextBySource(Source: TICEShapedObject):
        TICEConnection;
begin
  { TODO : FindNextBySource }
  result:= nil;
end;

function TICEConnectionList.GetItem(Index: Integer): TICEConnection;
begin
  Result := TICEConnection(inherited GetItem(Index));
end;

procedure TICEConnectionList.SetItem(Index: Integer; Value: TICEConnection);
begin
  TICEConnection(Items[Index]).Assign(Value);
end;

{
******************************* TICESubStructure *******************************
}
constructor TICESubStructure.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, aName);
end;

procedure TICESubStructure.Init;
begin
  inherited Init;
  ImageIndex:= 3;
  ShapeType:= fcsRectangle;
  Color:= $0080FFFF;
end;

procedure TICESubStructure.InternalExecute;
begin
  inherited InternalExecute;
end;

{
******************************* TICESqlOperation *******************************
}
constructor TICESqlOperation.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, aName);
  
end;

function TICESqlOperation.CompileSQL: string;
var
  i, P: Integer;
  Vf: Integer;
  S1, S2: string;
  VarName: string;
  ICEVar: TICEVar;
  Txt: TStringList;
  TempCommand: TStringList;
begin
  //comentários nos formatos /* */ e { } não são suportados.
  //{ } é utilizado como delimitador de parâmetro
  
  TempCommand:= TStringList.Create;
  Txt:= TStringList.Create;
  Result:= '';
  
  TempCommand.Text:= SQLCommand;
  
  //elimina comentários
  For i:= 0 to TempCommand.Count -1 do begin
    P:= Pos('--',TempCommand[i]);
    if P <> 0 then
      S1:= Copy(TempCommand[i],1, P-1)
    else
      S1:= TempCommand[i];
  
    P:= Pos('//',S1);
    if P <> 0 then
      S1:= Copy(S1,1, P-1);
  
    Txt.Add(Trim(S1));
  end;
  
  //Substitui parâmetros por valores
  For i:= 0 to Txt.Count -1 do begin
    S1:= Txt[i];
  
    P:= Pos('{', S1);
  
    While P > 0 do begin
      S2:= Copy(S1,P+1,Length(S1));
      Vf:= Pos('}',S2);
  
      VarName:= Trim(Copy(S2,1,Vf-1));
  
      ICEVar:= Structure.VarList.FindByName(VarName);
  
      Txt[i]:= Copy(S1,0,P-1)+' '+ ICEVar.Value +' '+Copy(S2,Vf+1,Length(S2));
  
      S1:= Txt[i];
      P:= Pos('{', S1);
    end;
  
  end;
  
  //Adiciona as linhas à string de retorno
  For i:= 0 to Txt.Count -1 do begin
    Result:= Result+ ' ' + Trim(Txt[i]);
  end;
  
  Result:= Trim(Result);
  
  TempCommand.Free;
  Txt.Free;
end;

function TICESqlOperation.GetICEDBConnectionName: string;
begin
  if assigned(FICEDBConnection) then
    Result:= FICEDBConnection.Name;
end;

function TICESqlOperation.GetSQLCommand: string;
begin
  Result := TICEStringParser.unParseSymbols(FSQLCommand);
end;

procedure TICESqlOperation.Init;
begin
  inherited Init;
  ImageIndex:= 4;
  ShapeType:= fcsRoundRect;
  Color:= $0080FFFF;
end;

procedure TICESqlOperation.InternalExecute;
var
  Cmd: TADOCommand;
begin
  inherited InternalExecute;
  Cmd:= TADOCommand.Create(nil);
  Cmd.Connection:= ICEDBConnection.DBConnection;
  Cmd.CommandTimeout:= ICEDBConnection.DBConnection.CommandTimeout;

  Cmd.CommandText:= CompileSQL;
  Cmd.Prepared:= PrepareCommand;
  Cmd.Execute;
  Cmd.Free;
  Status:= sttSuccess;
end;

procedure TICESqlOperation.SetICEDBConnection(Value: TICEDBConnection);
begin
  if FICEDBConnection <> Value then
  begin

    FICEDBConnection := Value;
  end;
end;

procedure TICESqlOperation.SetICEDBConnectionName(const Value: string);
begin
  FICEDBConnection:= Structure.DBConnectionList.FindByName(Value);
end;

procedure TICESqlOperation.SetSQLCommand(const Value: string);
begin
  if FSQLCommand <> TICEStringParser.ParseSymbols(Value) then
  begin
    FSQLCommand := TICEStringParser.ParseSymbols(Value);
  end;
end;


{
******************************* TICEPseudoState ********************************
}
function TICEPseudoState.GetObjClass: TObjClass;
begin
  Result:= clsPseudoState;
end;

procedure TICEPseudoState.Init;
begin
  inherited Init;
  ShapeWidth:= 19;
  ShapeHeigth:= 19;
end;

{
****************************** TICEDynamicChoice *******************************
}
constructor TICEDynamicChoice.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, aName);
  FTestList:= TICEConditionalList.Create(Self);
end;

destructor TICEDynamicChoice.Destroy;
var
  i: Integer;
begin
  TestList.Free;
  inherited Destroy;
end;

procedure TICEDynamicChoice.Connect(Connection: TICEConnection);
var
  CC: TICEConditionalConnection;
begin
  inherited Connect(Connection);
  if not (Connection is TICEConditionalConnection) then begin
     raise exception.create('Apenas conexões condicionais podem ser ligadas a objetos de escolha');
  end;
  
    if TestList.ValueExists(TICEConditionalConnection(Connection).Value) then
       raise exception.create('O valor indicado já se encontra na lista de escolhas.');
  
    CC:= TICEConditionalConnection(Connection);
    TestList.AddItem(CC.Ref);
end;

procedure TICEDynamicChoice.Disconnect(Connection: TICEConnection);
var
  I: Integer;
begin
  inherited Disconnect(Connection);
  for i:= 0 to TestList.Count do
    if TestList.Items[i].Connection = Connection then
      TestList.RemoveItem(Connection.Ref);
end;

function TICEDynamicChoice.Execute: Boolean;
begin
  // TODO -cMM: TICEDynamicChoice.Execute default body inserted
  Result := true;
end;

function TICEDynamicChoice.GetObjClass: TObjClass;
begin
  Result:= clsChoice;
end;

function TICEDynamicChoice.GetTestVarName: string;
begin
  Result:= TestVar.Name;
end;

procedure TICEDynamicChoice.Init;
begin
  inherited Init;
  ShapeWidth:= 63;
  ImageIndex:= 15;
  ShapeType:= fcsDiamond;
  Color:= $00FFB56A;
end;

procedure TICEDynamicChoice.SetTestVar(Value: TICEVar);
begin
  if FTestVar <> Value then
  begin
    FTestVar := Value;
  end;
end;

procedure TICEDynamicChoice.SetTestVarName(const Value: string);
begin
  TestVar:= FStructure.VarList.FindByName(Value);
end;

{
********************************* TICEForLoop **********************************
}
constructor TICEForLoop.Create(aStructure: TICEStructure; X,Y: Integer; aName:
        String);
begin
  inherited Create(aStructure, X, Y, aName);
end;

function TICEForLoop.GetLoopVarName: string;
begin
  if assigned(LoopVar) then
    Result:= LoopVar.Name;
end;

procedure TICEForLoop.Init;
begin
  inherited Init;
  ImageIndex:= 12;
  ShapeType:= fcsEllipse;
  Color:= $0080FF80;
  Caption:= 'For';
end;

procedure TICEForLoop.SetLoopVar(Value: TICEVar);
begin
  if FLoopVar <> Value then
  begin
    FLoopVar := Value;
  end;
end;

procedure TICEForLoop.SetLoopVarName(const Value: string);
begin
  LoopVar:= Structure.VarList.FindByName(Value);
end;

{
******************************** TICEStartPoint ********************************
}
constructor TICEStartPoint.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, 'Start Point');
end;

destructor TICEStartPoint.Destroy;
begin
  inherited Destroy;
end;

procedure TICEStartPoint.Connect(Connection: TICEConnection);
begin
  inherited Connect(Connection);
  if not (Connection is TICEEventConnection) then begin
    raise exception.create('Apenas conxões de evento podem ser ligadas a pontos de início.');
  end;

  TICEEventConnection(Connection).EventType:= evCompletion;
  
  OnStart:= TICEEventConnection(Connection);
end;

procedure TICEStartPoint.Disconnect(Connection: TICEConnection);
begin
  inherited Disconnect(Connection);
  if FOnStart = Connection then FOnStart:= Nil;
  
end;

function TICEStartPoint.Execute: Boolean;
begin
  if assigned(FOnStart) then
    Result:= OnStart.Execute
  else
    Result:= false;
end;

procedure TICEStartPoint.Init;
begin
  inherited Init;
  ImageIndex:= 11;
  ShapeType:= fcsNone;
  Color:= clNone;
  Name:= 'StartPoint';
end;

procedure TICEStartPoint.SetOnStart(Value: TICEEventConnection);
begin
  if FOnStart <> Value then
  begin
  if assigned(FOnStart) then
    FreeAndNil(FOnStart);
  FOnStart := Value;
  end;
end;

procedure TICEEndPoint.Connect(Connection: TICEConnection);
begin
  { TODO : Nenhuma conexão pode ser originada no EndPoint }
end;

{
********************************* TICEEndPoint *********************************
}
procedure TICEEndPoint.Init;
begin
  inherited Init;
  ImageIndex:= 10;
  ShapeType:= fcsNone;
  Color:= clNone;
end;

{
******************************** TICEWhileLoop *********************************
}
constructor TICEWhileLoop.Create(aStructure: TICEStructure; X,Y: Integer;
        aName: String);
begin
  inherited Create(aStructure, X, Y, aName);
end;

function TICEWhileLoop.GetTestCondition: string;
begin
  Result := TICEStringParser.unParseSymbols(FTestCondition);
end;

procedure TICEWhileLoop.Init;
begin
  inherited Init;
  ImageIndex:= 9;
  ShapeType:= fcsEllipse;
  Color:= $0080FF80;
  Caption:= 'While';
end;

procedure TICEWhileLoop.SetTestCondition(const Value: string);
begin
  if FTestCondition <> TICEStringParser.ParseSymbols(Value) then
  begin
    FTestCondition := TICEStringParser.ParseSymbols(Value);
  end;
end;

{
********************************* TICEDataset **********************************
}
constructor TICEDataset.Create(aStructure: TICEStructure; aDataset:
    TADODataset; DBCName: String);
begin
  inherited Create(aStructure);
  SetCollection(Structure.DatasetList);
  FDataset:= aDataset;
  FDatasource:= TDataSource.Create(Nil);
  FDatasource.DataSet:= FDataset;
  Name:= FDataset.Name;
  ICEDBCName:= DBCName;
end;

constructor TICEDataset.Create(astructure: TICEStructure);
begin
  inherited Create(aStructure);
  SetCollection(Structure.DatasetList);
end;

function TICEDataset.GetCacheSize: Integer;
begin
  Result := Dataset.CacheSize;
end;

function TICEDataset.GetICEDBCName: string;
begin
  if assigned(ICEDBConnection) then
    Result:= ICEDBConnection.Name
  else
    Result:= '';
end;

function TICEDataset.GetMasterDSName: string;
begin
  if assigned(MasterDS) then
    Result := FMasterDS.Name
  else
    Result:= '';
end;

function TICEDataset.GetSQL: string;
begin
   if FSQL = '' then
    FSQL:= Dataset.CommandText;

  Result := Trim(TICEStringParser.unParseSymbols(FSQL));

end;

procedure TICEDataset.SetCacheSize(const Value: Integer);
begin
  Dataset.CacheSize:= Value;
end;

procedure TICEDataset.SetICEDBCName(const Value: string);
begin
  if Value <> ICEDBCName then
    ICEDBConnection:= Structure.DBConnectionList.FindByName(Value);
end;

procedure TICEDataset.SetICEDBConnection(const Value: TICEDBConnection);
begin
  if Value <> FICEDBConnection then begin
    FICEDBConnection:= Value;
    Dataset.Connection:= FICEDBConnection.DBConnection;
  end;
end;

procedure TICEDataset.SetMasterDS(Value: TICEDataset);
begin
  if FMasterDS <> Value then
  begin
    FMasterDS := Value;

    if Value <> Nil then
      Dataset.DataSource:= Value.Datasource
    else
      Dataset.DataSource:= Nil;

  end;
end;

procedure TICEDataset.SetMasterDSName(const Value: string);
begin
  if Value <> MasterDSName then
    MasterDS:= Structure.DatasetList.FindByName(Value);

end;

procedure TICEDataset.SetName(const Value: string);
begin
  if FName <> Value then
  begin
    FName := Value;
    Dataset.Name:= Value;
    Datasource.Name:= 'ds'+Value;
    Inherited SetName(Value);
  end;
end;

procedure TICEDataset.SetSQL(const Value: string);
begin
  if FSQL <> TICEStringParser.ParseSymbols(Value) then
  begin
    FSQL := Trim(TICEStringParser.ParseSymbols(Value));
    Dataset.CommandText:= FSQL;
  end;
end;

procedure TICEDataset.StartEmpty;
begin
   TICEDatasetUtils.StartEmpty(Dataset);
end;

procedure TICEDataset.StartFull;
begin
  Dataset.CommandText:= SQL;
  Dataset.Open;
end;                   

{
********************************* TISISObject **********************************
}
procedure TISISObject.SetICEObject(Value: TICEShapedObject);
begin
  Data:= Value;
  FICEObject:= Value;
end;

class function TICEStringParser.ICEStatusToStr(aStatus: TICEObjectStatus):
    string;
begin
  Case aStatus of
    sttReady: result:= 'sttReady';
    sttRunning: result:='sttRunning';
    sttDisabled: result:= 'sttDisabled';
    sttSuccess: result:='sttSuccess';
    sttFailure: result:= 'sttFailure';
    else result:= '';
  end;
end;

class function TICEStringParser.ICEClassToStr(aClass: TObjClass): string;
begin
  Case aClass of
    clsNone: result:= 'clsNone';
    clsChoice: result:='clsChoice';
    clsOperation: result:='clsOperation';
    clsLoop: result:= 'clsLoop';
    clsPseudoState: result:='clsPseudoState';
    clsConnection: result:= 'clsConnection';
    else result:= '';
  end;
end;

class function TICEStringParser.ICEOprTypeToStr(aOprType: TOprType): string;
begin

  Case aOprType of
    otNone: result:= 'otNone';
    otPascal: result:='otPascal';
    otSQL: result:='otSQL';
    otClientCursor: result:= 'otClientCursor';
    otDataTransport: result:='otDataTransport';
    otSubStructure: result:= 'otSubStructure';
    else result:= '';
  end;
end;

class function TICEStringParser.ICEConTypeToStr(aConType: TConType): string;
begin

  Case aConType of
    ctNone: result:= 'ctNone';
    ctDyn: result:='ctDyn';
    ctControl: result:='ctControl';
    ctDepend: result:= 'ctDepend';
    ctEvent: result:='ctEvent';
    else result:= '';
  end;
end;

class function TICEStringParser.ICEEventTypeToStr(aEventType: TEventType):
    string;
begin
  Case aEventType of
    evNone: result:= 'evNone';
    evCompletion: result:='evCompletion';
    evSuccess: result:='evSuccess';
    evFailure: result:= 'evFailure';
    else result:= '';
  end;
end;

class function TICEStringParser.ICEStructTypeToStr(aStructType: TStructType):
    string;
begin
  Case aStructType of
    stNone: result:= 'stNone';
    stFor: result:='stFor';
    stWhile: result:='stWhile';
    stDynChoice: result:= 'stDynChoice';
    stEndPoint: result:='stEndPoint';
    stStartPoint: result:= 'stStartPoint';
    else result:= '';
  end;
end;

class function TICEStringParser.ParseSymbols(St: String): string;
begin
  Result:= St;
  Result:= StringReplace(Result,'>','|M', [rfReplaceAll]);
  Result:= StringReplace(Result,'<','|m', [rfReplaceAll]);
  Result:= StringReplace(Result,'&','|e', [rfReplaceAll]);
  Result:= StringReplace(Result,'/','|d', [rfReplaceAll]);
  Result:= StringReplace(Result,'?','|i', [rfReplaceAll]);
end;

class function TICEStringParser.StrToICEStatus(aStatus: String):
    TICEObjectStatus;
begin
  if aStatus = 'sttRunning' then result:= sttRunning
  else if aStatus = 'sttDisabled' then result:= sttDisabled
  else if aStatus = 'sttSuccess' then result:= sttSuccess
  else if aStatus = 'sttFailure' then result:= sttFailure
  else result:= sttReady;
end;

class function TICEStringParser.StrToICEClass(aClass: String): TObjClass;
begin
  if aClass = 'clsChoice' then result:= clsChoice
  else if aClass = 'clsOperation' then result:= clsOperation
  else if aClass = 'clsLoop' then result:= clsLoop
  else if aClass = 'clsPseudoState' then result:= clsPseudoState
  else if aClass = 'clsConnection' then result:= clsConnection
  else result:= clsNone;
end;

class function TICEStringParser.StrToICEOprType(aOprType: string): TOprType;
begin
  if aOprType = 'otPascal' then result:= otPascal
  else if aOprType = 'otSQL' then result:= otSQL
  else if aOprType = 'otClientCursor' then result:= otClientCursor
  else if aOprType = 'otDataTransport' then result:= otDataTransport
  else if aOprType = 'otSubStructure' then result:= otSubStructure
  else result:= otNone;
end;

class function TICEStringParser.StrToICEConType(aConType: string): TConType;
begin
  if aConType = 'ctDyn' then result:= ctDyn
  else if aConType = 'ctControl' then result:= ctControl
  else if aConType = 'ctDepend' then result:= ctDepend
  else if aConType = 'ctEvent' then result:= ctEvent
  else result:= ctNone;
end;

class function TICEStringParser.StrToICEEventType(aEventType: string):
    TEventType;
begin
  if aEventType = 'evCompletion' then result:= evCompletion
  else if aEventType = 'evCompletion' then result:= evCompletion
  else if aEventType = 'evSuccess' then result:= evSuccess
  else if aEventType = 'evFailure' then result:= evFailure
  else result:= evNone;
end;

class function TICEStringParser.ClassStrToICEOprType(aStr: String): TOprType;
begin
  if aStr = 'TICEPasOperation' then result:= otPascal
  else if aStr = 'TICESqlOperation' then result:= otSQL
  else if aStr = 'TICESqlDataCursor' then result:= otClientCursor
  else if aStr = 'TICEDataTransport' then result:= otDataTransport
  else if aStr = 'TICESubStructure' then result:= otSubStructure
  else result:= otNone;
end;

class function TICEStringParser.StrToStructType(aStructType: string):
    TStructType;
begin
  if aStructType = 'stFor' then result:= stFor
  else if aStructType = 'stWhile' then result:= stWhile
  else if aStructType = 'stDynChoice' then result:= stDynChoice
  else if aStructType = 'stEndPoint' then result:= stEndPoint
  else if aStructType = 'stStartPoint' then result:= stStartPoint
  else result:= stNone;
end;

class function TICEStringParser.unParseSymbols(St: String): string;
begin
  Result:= St;
  Result:= StringReplace(Result,'|M','>', [rfReplaceAll]);
  Result:= StringReplace(Result,'|m','<', [rfReplaceAll]);
  Result:= StringReplace(Result,'|e','&', [rfReplaceAll]);
  Result:= StringReplace(Result,'|d','/', [rfReplaceAll]);
  Result:= StringReplace(Result,'|i','?', [rfReplaceAll]);
end;

/////////////////////////////////////////////////////////////////////////////////
//Preenche uma lista de Datasets
{
********************************** TICELister **********************************
}
procedure TICELister.FillTxtWithDatasets(Var Txt: TStringList);
var
  i: Integer;
begin
  For i:= 0 to FICEStructure.DatasetList.Count -1 do
    Txt.Add(FICEStructure.DatasetList[i].Name);
end;

procedure TICELister.FillTxtWithDBConnections(Var Txt: TStringList);
var
  i: Integer;
begin
  For i:= 0 to FICEStructure.DBConnectionList.Count -1 do
    Txt.Add(FICEStructure.DBConnectionList[i].Name);
end;

procedure TICELister.FillTxtWithVars(Var Txt: TStringList);
var
  i: Integer;
begin
  for i:= 0 to FICEStructure.VarList.Count -1 do
    Txt.Add(FICEStructure.VarList[i].Name);
end;

/////////////////////////////////////////////////////////////////////////////////
//Preenche uma lista de DBConnections
/////////////////////////////////////////////////////////////////////////////////
//Preenche uma stringlist com os nomes das variáveis da estrutura
{
***************************** TICEStructuredObject *****************************
}
constructor TICEStructuredObject.Create(aStructure: TICEStructure);
begin
  FICEStructure:= aStructure;
end;

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



  FICEStructure:= aStructure;
  
end;

destructor TICEXMLPersistence.Destroy;
begin
  FICEXMLSerializer.Free;
  inherited;
end;

procedure TICEXMLPersistence.FillConnectionList(xObj: IXMLNode);
var
  aStatus: TICEObjectStatus;
  ElseValue: Boolean;
  aValue: Variant;
  aEventType: TEventType;
  aName: string;
  NodeName: string;
  i: Integer;
  CType: TConType;
  aConn: TICEConnection;

  BreakPoint: Boolean;
  DstName, SrcName, PersistentPoints: String;
  DstPt, SrcPt: Integer;
begin
  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    NodeName:= xObj.ChildNodes[i].NodeName;
    if (NodeName <> 'Count') then begin
      CType:= TICEStringParser.StrToICEConType(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['ConType'].Text);

      BreakPoint:= StrToBoolDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['BreakPoint'].Text, False);
      DstName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['DestinationName'].Text;
      SrcName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['SourceName'].Text;
      PersistentPoints:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['PersistentPoints'].Text;
      DstPt:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['DstConPoint'].Text,0);
      SrcPt:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['SrcConPoint'].Text,0);
      aName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Name'].Text;

      Case CType of
        ctEvent: begin
          aEventType:= TICEStringParser.StrToICEEventType(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['EventType'].Text);
          aConn:= TICEEventConnection.Create(FICEStructure,aEventType, aName);
        end;
        ctControl: begin
          aConn:= TICEControlConnection.Create(FICEStructure, aName);
        end;
        ctDyn: begin
          aValue:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Value'].Text;
          ElseValue:= StrToBoolDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Value'].Text,False);
          aConn:= TICEConditionalConnection.Create(FICEStructure,aValue,ElseValue,aName);
        end;
        ctDepend: begin
          aStatus:= TICEStringParser.StrToICEStatus(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['TestStatus'].Text);
          aConn:= TICEDependencyConnection.Create(FICEStructure,aStatus,aName);
        end;
        else
          exit;
      end;

      aConn.BreakPoint:= BreakPoint;
      aConn.DestinationName:= DstName;
      aConn.SourceName:= SrcName;

      aConn.InitShape;

      aConn.DstConPoint:= DstPt;
      aConn.SrcConPoint:= SrcPt;
      aConn.doConnect;

      aConn.PersistentPoints:= PersistentPoints;

    end;
  end;
end;

procedure TICEXMLPersistence.FillDatasetList(xObj: IXMLNode);
var
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
      aName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Name'].Text;
      aDataset:= TADODataset.Create(aOwner);
      aDataset.CommandText:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['PersistentSQL'].Text;
      aDataset.Name:= aName;
      aDataset.CacheSize:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['CacheSize'].Text,1);
      if aDataset.CacheSize < 1 then
         aDataset.CacheSize:= 1;
      TICEDataset.Create(FICEStructure, aDataset, xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['ICEDBCName'].Text);
    end;
  end;
end;

procedure TICEXMLPersistence.FillDBConnectionList(xObj: IXMLNode);
var
  xDBCon: IXMLNode;
  i: Integer;
  aCon: TADOConnection;
  aOwner: TComponent;
  aName: String;
begin
  if assigned(FICEStructure.DrawArea) then
    aOwner:= FICEStructure.DrawArea.Owner
  else
    aOwner:= nil;

  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    if xObj.ChildNodes[i].NodeName = 'TICEDBConnection' then begin

      aName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Name'].Text;
      xDBCon:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['DBConnection'];

      aCon:= TADOConnection.Create(aOwner);
      aCon.Name:= aName;
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
var
  OprType: TOprType;
  i: Integer;
  NodeName: String;
  aName: String;
  ShapeH, ShapeW, ShapeT, ShapeL: Integer;
  TxtH, TxtW, TxtT, TxtL: Integer;
  aShapedObject: TICEShapedObject;
  ObjClass: TObjClass;

  procedure InitProps;
  begin
      aName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Name'].Text;
      ShapeH:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['ShapeHeigth'].Text, 43);
      ShapeW:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['ShapeWidth'].Text, 43);
      ShapeT:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['ShapeTop'].Text, 0);
      ShapeL:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['ShapeLeft'].Text, 0);

      TxtH:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['TxtHeigth'].Text, 43);
      TxtW:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['TxtWidth'].Text, 43);
      TxtT:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['TxtTop'].Text, 0);
      TxtL:= StrToIntDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['TxtLeft'].Text, 0);
  end;

  procedure SetTxtProps;
  begin
    aShapedObject.TxtHeigth:= TxtH;
    aShapedObject.TxtWidth:= TxtW;
    aShapedObject.TxtTop:= TxtT;
    aShapedObject.TxtLeft:= TxtL;
  end;
begin
  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    NodeName:= xObj.ChildNodes[i].NodeName;
    if (NodeName <> 'Count') then begin

      ObjClass:= TICEStringParser.StrToICEClass(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['ObjClass'].Text);
      InitProps;

      Case ObjClass of
        clsOperation:Begin
          OprType:= TICEStringParser.ClassStrToICEOprType(NodeName);
          Case OprType of
            otPascal:Begin
              aShapedObject:= TICEPasOperation.Create(FICEStructure,ShapeL,ShapeT,aName);
              TICEPasOperation(aShapedObject).PersistentScript:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['PersistentScript'].Text;
            end;
            otSQL:Begin
              aShapedObject:= TICESqlOperation.Create(FICEStructure,ShapeL,ShapeT,aName);
              TICESqlOperation(aShapedObject).PrepareCommand:= StrToBoolDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['PrepareCommand'].Text, false);
              TICESqlOperation(aShapedObject).PersistentSQL:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['PersistentSQL'].Text;
              TICESqlOperation(aShapedObject).ICEDBConnectionName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['ICEDBConnectionName'].Text;
             end;
            otClientCursor:Begin
              aShapedObject:= TICESqlDataCursor.Create(FICEStructure,ShapeL,ShapeT,aName);
            end;
            otDataTransport:Begin
              aShapedObject:= TICEDataTransport.Create(FICEStructure,ShapeL,ShapeT,aName);
              TICEDataTransport(aShapedObject).DstDatasetName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['DstDatasetName'].Text;
              TICEDataTransport(aShapedObject).SrcDatasetName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['SrcDatasetName'].Text;
              TICEDataTransport(aShapedObject).CorrespondencesAsString:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['CorrespondencesAsString'].Text;
            end;
            otSubStructure:Begin
               { TODO : Substructre load }
            end;
          end;
        end;
        clsChoice:Begin
          aShapedObject:= TICEDynamicChoice.Create(FICEStructure,ShapeL,ShapeT,aName);
        end;
        clsLoop:Begin
          if (NodeName = 'TICEForLoop') then begin
            aShapedObject:= TICEForLoop.Create(FICEStructure,ShapeL,ShapeT,aName);
            TICEForLoop(aShapedObject).Max:= StrToFloatDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Max'].Text, 0);
            TICEForLoop(aShapedObject).Min:= StrToFloatDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Min'].Text, 0);
            TICEForLoop(aShapedObject).LoopVarName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['LoopVarName'].Text;
          end else begin
            aShapedObject:= TICEWhileLoop.Create(FICEStructure,ShapeL,ShapeT,aName);
            TICEWhileLoop(aShapedObject).RepeatStyle:= StrToBoolDef(xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['RepeatStyle'].Text, false);
            TICEWhileLoop(aShapedObject).PersistentTestCondition:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['PersistentTestCondition'].Text;
          end;
        end;
        clsPseudoState:Begin
          if (NodeName = 'TICEStartPoint') then begin
            aShapedObject:= TICEStartPoint.Create(FICEStructure,ShapeL,ShapeT,aName);
          end else begin
            aShapedObject:= TICEEndPoint.Create(FICEStructure,ShapeL,ShapeT,aName);
          end;
        end;

        else
          exit;


      end;
      SetTxtProps;

    end;
  end;
end;

procedure TICEXMLPersistence.FillVarList(xObj: IXMLNode);
var
  i: Integer;
  aVar: TICEVar;
  aDatasetName: string;
  aDataset: TICEDataset;
  xVar: IXMLNode;
  aName: String;
begin
  For i:= 0 to xObj.ChildNodes.Count -1 do begin
    if xObj.ChildNodes[i].NodeName = 'TICEVar' then begin
      aName:= xObj.ChildNodes.Nodes[i].ChildNodes.Nodes['Name'].Text;
      xVar:= xObj.ChildNodes.Nodes[i];
      aVar:= TICEVar.Create(FICEStructure, aName);
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

function TICEXMLPersistence.GetXMLDoc: TXMLDocument;
var
  aComp: TComponent;
  XMLDoc: TXMLDocument;
begin
  aComp:= TComponent.Create(nil);

  XMLDoc:= TXMLDocument.Create(aComp);
  With XMLDoc do begin
    DOMVendor:= GetDOMVendor('MSXML');
    NodeIndentStr := '  ';
    Options := [doNodeAutoCreate,doAttrNull,doAutoPrefix,doNamespaceDecl];
  end;
  Result := XMLDoc;
end;

procedure TICEXMLPersistence.KillXMLDoc(Var XMLDoc: TXMLDocument);
begin
  XMLDoc.Owner.Free;
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
var
  XMLDoc: TXMLDocument;
begin
  XMLDoc:= GetXMLDoc;
  XMLDoc.LoadFromFile(FileName);
  XMLDoc.Active:= True;
  Unserialize(XMLDoc);
  KillXMLDoc(XMLDoc);
end;

procedure TICEXMLPersistence.LoadFromStream(aStream: TStream);
var
  XMLDoc: TXMLDocument;
begin
  XMLDoc:= GetXMLDoc;
  XMLDoc.LoadFromStream(aStream);
  Unserialize(XMLDoc);
  KillXMLDoc(XMLDoc);
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
var
  aStream: TFileStream;
begin
  if FileExists(FileName) then
    if (MessageDlg('Deseja sobrescrever o arquivo?', mtConfirmation, [mbYes, mbNo], 0) = mrNo) then
      exit
    else
      DeleteFile(PCHAR(FileName));
  
  aStream:= TFileStream.Create(FileName,fmCreate);
  try
    SaveToStream(aStream);
  finally
    aStream.Free;
  end;
end;

procedure TICEXMLPersistence.SaveToStream(aStream: TStream);
begin
  FICEXMLSerializer.Serialize(FICEStructure, aStream);
end;

procedure TICEXMLPersistence.SaveVarList(aStream: TStream);
begin
end;

procedure TICEXMLPersistence.Unserialize(XMLDoc: TXMLDocument);
var
  xStructure: IXMLNode;
begin
  XMLDoc.Active:= True;
  if XMLDoc.DocumentElement.NodeName = 'TICEStructure' then begin
    if XMLDoc.DocumentElement.HasChildNodes then begin
      FICEStructure.Clear;

      xStructure:= XMLDoc.DocumentElement;
      FICEStructure.Name:= xStructure.ChildNodes['Name'].Text;

      FillDBConnectionList(xStructure.ChildNodes['DBConnectionList']);
      FillDatasetList(xStructure.ChildNodes['DatasetList']);
      FillVarList(xStructure.ChildNodes['VarList']);
      FillShapedObjectList(xStructure.ChildNodes['ShapedObjectList']);
      FillConnectionList(xStructure.ChildNodes['ConnectionList']);

    end;
  end else raise exception.Create('Arquivo Inválido');
end;






end.
