
unit ICEXMLSerializer;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, TypInfo;

type
  TOnGetXMLHeader = procedure (Sender: TObject; var Value: string) of object;
  TBeforeParsingEvent = procedure (Sender: TObject; Buffer: PChar) of object;
  EICEXMLSerializerException = class(Exception)
  end;
  
  XMLSerializerException = class(Exception)
  end;
  
  EICEXMLOpenTagNotFoundException = class(XMLSerializerException)
  end;
  
  EICEXMLCloseTagNotFoundException = class(XMLSerializerException)
  end;
  
  EICEXMLUnknownPropertyException = class(XMLSerializerException)
  end;
  
  TICEXMLSerializerException = class of XMLSerializerException;


  TICEXMLSerializer = class(TObject)
  private
    Buffer: PChar;
    BufferEnd: PChar;
    BufferLength: DWORD;
    FBeforeParsing: TBeforeParsingEvent;
    FExcludeDefaultValues: Boolean;
    FExcludeEmptyValues: Boolean;
    FGenerateFormattedXML: Boolean;
    FIgnoreUnknownTags: Boolean;
    FOnGetXMLHeader: TOnGetXMLHeader;
    FReplaceReservedSymbols: Boolean;
    FStrongConformity: Boolean;
    FWrapCollections: Boolean;
    OutStream: TStream;
    TokenPtr: PChar;
    procedure Check(Expr: Boolean; const Msg: string; E:
            TICEXMLSerializerException);
    function DupStr(const Str: string; Count: Integer): string;
    function IIF(AExpression: Boolean; const IfTrue, IfFalse: string): string;
            overload;
    function IIF(AExpression: Boolean; IfTrue, IfFalse: Variant): Variant;
            overload;
    procedure WriteOutStream(const Value: string);
  protected
    procedure DeSerializeInternal(Component: TObject; ComponentTagName: string;
            ParentBlockEnd: PChar = nil);
    procedure GenerateDTDInternal(Component: TObject; DTDList: TStrings;
            Stream: TStream; const ComponentTagName: string);
    procedure SerializeInternal(Component: TObject; Level: Integer = 1);
    procedure SetPropertyValue(Component: TObject; PropInfo: PPropInfo; Value,
            ValueEnd: PChar; ParentBlockEnd: PChar);
  public
    DefaultXMLHeader: string;
    tickCount: DWORD;
    tickCounter: DWORD;
    constructor Create;
    procedure DeSerialize(Component: TObject; Stream: TStream);
    procedure GenerateDTD(Component: TObject; Stream: TStream);
    procedure Serialize(Component: TObject; Stream: TStream);
  published
    property BeforeParsing: TBeforeParsingEvent read FBeforeParsing write
            FBeforeParsing;
    property ExcludeDefaultValues: Boolean read FExcludeDefaultValues write
            FExcludeDefaultValues;
    property ExcludeEmptyValues: Boolean read FExcludeEmptyValues write
            FExcludeEmptyValues;
    property GenerateFormattedXML: Boolean read FGenerateFormattedXML write
            FGenerateFormattedXML default True;
    property IgnoreUnknownTags: Boolean read FIgnoreUnknownTags write
            FIgnoreUnknownTags;
    property OnGetXMLHeader: TOnGetXMLHeader read FOnGetXMLHeader write
            FOnGetXMLHeader;
    property ReplaceReservedSymbols: Boolean read FReplaceReservedSymbols write
            FReplaceReservedSymbols;
    property StrongConformity: Boolean read FStrongConformity write
            FStrongConformity default True;
    property WrapCollections: Boolean read FWrapCollections write
            FWrapCollections default True;
  end;
  
implementation

const
  ORDINAL_TYPES = [tkInteger, tkChar, tkEnumeration, tkSet];

var
  TAB: string;
  CR: string;

resourcestring
  RsOpenXMLTagNotFound = 'Open tag not found: <%s>';
  RsCloseXMLTagNotFound = 'Close tag not found: </%s>';
  RsUnknownProperty = 'Unknown property: %s';

{
****************************** TICEXMLSerializer *******************************
}
constructor TICEXMLSerializer.Create;
begin
  inherited Create;
  //...defaults
  FGenerateFormattedXML := True;
  FStrongConformity := True;
  FWrapCollections := True;
end;

procedure TICEXMLSerializer.Check(Expr: Boolean; const Msg: string; E:
        TICEXMLSerializerException);
begin
  if not Expr then
    raise E.Create('XMLSerializerException'#13#10#13#10 + Msg);
end;

procedure TICEXMLSerializer.DeSerialize(Component: TObject; Stream: TStream);
begin
  GetMem(Buffer, Stream.Size);
  try
    { Retrievign data from stream  [translated] }
    Stream.Read(Buffer[0], Stream.Size + 1);
  
    if Assigned(BeforeParsing) then
      BeforeParsing(Self, Buffer);
  
    { Setting current pointer of reading data  [translated] }
    TokenPtr := Buffer;
    BufferLength := Stream.Size - 1;
    BufferEnd := Buffer + BufferLength;
    { Calling loader  [translated] }
    DeSerializeInternal(Component, Component.ClassName);
  finally
    FreeMem(Buffer);
  end;
end;

procedure TICEXMLSerializer.DeSerializeInternal(Component: TObject;
        ComponentTagName: string; ParentBlockEnd: PChar = nil);
var
  BlockStart, BlockEnd, TagStart, TagEnd: PChar;
  TagName, TagValue, TagValueEnd: PChar;
  TypeInf: PTypeInfo;
  TypeData: PTypeData;
  PropIndex: Integer;
  AName: string;
  PropList: PPropList;
  NumProps: Word;
  
  { Searching object for property with given name  [translated] }
  
  function FindProperty(TagName: PChar): Integer;
  var
    I: Integer;
  begin
    Result := -1;
    for I := 0 to NumProps - 1 do
      if CompareStr(PropList^[I]^.Name, TagName) = 0 then
      begin
        Result := I;
        Break;
      end;
  end;
  
  procedure SkipSpaces(var TagEnd: PChar);
  begin
    while TagEnd[0] <= #33 do
      Inc(TagEnd);
  end;
  
  
  function StrPosExt(const Str1, Str2: PChar; Str1Len: DWORD): PChar; assembler;
  asm
        PUSH    EDI
        PUSH    ESI
        PUSH    EBX
        OR      EAX,EAX
        JE      @@2
        OR      EDX,EDX
        JE      @@2
        MOV     EBX,EAX
        MOV     EDI,EDX
        XOR     AL,AL
  
        push ECX
  
        MOV     ECX,0FFFFFFFFH
        REPNE   SCASB
        NOT     ECX
        DEC     ECX
  
        JE      @@2
        MOV     ESI,ECX
  
        pop ECX
  
        SUB     ECX,ESI
        JBE     @@2
        MOV     EDI,EBX
        LEA     EBX,[ESI-1]
  @@1:  MOV     ESI,EDX
        LODSB
        REPNE   SCASB
        JNE     @@2
        MOV     EAX,ECX
        PUSH    EDI
        MOV     ECX,EBX
        REPE    CMPSB
        POP     EDI
        MOV     ECX,EAX
        JNE     @@1
        LEA     EAX,[EDI-1]
        JMP     @@3
  @@2:  XOR     EAX,EAX
  @@3:  POP     EBX
        POP     ESI
        POP     EDI
  end;
  
begin
  { Playing with RTTI }
  TypeInf := Component.ClassInfo;
  AName := TypeInf^.Name;
  TypeData := GetTypeData(TypeInf);
  NumProps := TypeData^.PropCount;
  
  if not WrapCollections and (Component is TCollection) then
    ComponentTagName := TCollection(Component).ItemClass.ClassName;
  
  GetMem(PropList, NumProps * SizeOf(Pointer));
  try
    GetPropInfos(TypeInf, PropList);
  
  
    { Looking for opening tag  [translated] }
    BlockStart := StrPosExt(TokenPtr, PChar('<' + ComponentTagName + '>'),
      BufferEnd - TokenPtr { = BufferLength});
  
  
    { If tag is not found and is not required - skip it  [translated] }
    if (BlockStart = nil) and not StrongConformity then
      exit;
  
  
    { Otherwise Check its presence  [translated] }
    Check(BlockStart <> nil, Format(RsOpenXMLTagNotFound,
      [ComponentTagName]), EICEXMLOpenTagNotFoundException);
    Inc(BlockStart, Length(ComponentTagName) + 2);
  
  
    { Looking for closing tag  [translated] }
    BlockEnd := StrPosExt(BlockStart, PChar('</' + ComponentTagName + '>'),
      BufferEnd - BlockStart + 3 + Length(ComponentTagName) {BufferLength});
    Check(BlockEnd <> nil, Format(RsCloseXMLTagNotFound,
      [ComponentTagName]), EICEXMLCloseTagNotFoundException);
  
  
    { Checking the closing tag to be nested within parent tag  [translated] }
    Check((ParentBlockEnd = nil) or (BlockEnd < ParentBlockEnd),
      Format(RsCloseXMLTagNotFound, [ComponentTagName]),
      EICEXMLCloseTagNotFoundException);
  
    TagEnd := BlockStart;
    SkipSpaces(TagEnd);
  
  
    { XML parser [translated] }
    while (TagEnd < BlockEnd) { and (TagEnd >= TokenPtr)} do
    begin
  
      { fast search for "<" and ">"  [translated] }
      asm
        MOV CL, '<'
        MOV EDX, Pointer(TagEnd)
        DEC EDX
  @@1:  INC EDX
        MOV AL, Byte[EDX]
        CMP AL, CL
        JNE @@1
        MOV TagStart, EDX
  
        MOV CL, '>'
  @@2:  INC EDX
        MOV AL, Byte[EDX]
        CMP AL, CL
        JNE @@2
        MOV TagEnd, EDX
      end;
  
      GetMem(TagName, TagEnd - TagStart + 1);
      try
  
        { Tag Name - Tag Name  [translated] }
        StrLCopy(TagName, TagStart + 1, TagEnd - TagStart - 1);
  
  
        { TagEnd - Closing tag   [translated] }
        TagEnd := StrPosExt(TagEnd, PChar('</' + TagName + '>'),
          BufferEnd - TagEnd + 3 + Length(TagName) { = BufferLength});
  
        //Inc(TagStart, Length('</' + TagName + '>')-1);
  
  
        { Beginning of the next nested("children") tag [translated] }
        TagValue := TagStart + Length('</' + TagName + '>') - 1;
        TagValueEnd := TagEnd;
  
  
        { Looking for property matching the tag  [translated] }
        PropIndex := FindProperty(TagName);
  
        if not WrapCollections and (PropIndex = -1) then
          PropIndex := FindProperty(PChar(TagName + 's'))
        else
          TokenPtr := TagStart;
  
        if not IgnoreUnknownTags then
          Check(PropIndex <> -1, Format(RsUnknownProperty, [TagName]),
            EICEXMLUnknownPropertyException);
  
        if PropIndex <> -1 then
          SetPropertyValue(Component, PropList^[PropIndex], TagValue,
            TagValueEnd, BlockEnd);
  
        Inc(TagEnd, Length('</' + TagName + '>'));
        SkipSpaces(TagEnd);
      finally
        FreeMem(TagName);
      end;
    end;
  finally
    FreeMem(PropList);//, NumProps * SizeOf(Pointer));
  end;
end;

function TICEXMLSerializer.DupStr(const Str: string; Count: Integer): string;
var
  I: Integer;
begin
  Result := '';
  for I := 1 to Count do
    Result := Result + Str;
end;

procedure TICEXMLSerializer.GenerateDTD(Component: TObject; Stream: TStream);
var
  DTDList: TStringList;
begin
  DTDList := TStringList.Create;
  try
    GenerateDTDInternal(Component, DTDList, Stream, Component.ClassName);
  finally
    DTDList.Free;
  end;
end;

procedure TICEXMLSerializer.GenerateDTDInternal(Component: TObject; DTDList:
        TStrings; Stream: TStream; const ComponentTagName: string);
var
  PropInfo: PPropInfo;
  TypeInf, PropTypeInf: PTypeInfo;
  TypeData: PTypeData;
  I: Integer;
  AName, PropName, TagContent: string;
  PropList: PPropList;
  NumProps: Word;
  PropObject: TObject;
  
  const
    PCDATA = '#PCDATA';
  
    procedure addElement(const ElementName: string; Data: string);
    var
      S: string;
    begin
      if DTDList.IndexOf(ElementName) <> -1 then
        exit;
      DTDList.Add(ElementName);
      S := '<!ELEMENT ' + ElementName + ' ';
      if Data = '' then
        Data := PCDATA;
      S := S + '(' + Data + ')>'#13#10;
      Stream.Write(PChar(S)[0], Length(S));
    end;
  
begin
  { Playing with RTTI }
  TypeInf := Component.ClassInfo;
  AName := TypeInf^.Name;
  TypeData := GetTypeData(TypeInf);
  NumProps := TypeData^.PropCount;
  
  GetMem(PropList, NumProps * SizeOf(Pointer));
  try
  
    { Getting list of properties  [translated] }
    GetPropInfos(TypeInf, PropList);
    TagContent := '';
  
    for I := 0 to NumProps - 1 do
    begin
      PropName := PropList^[I]^.Name;
  
      PropTypeInf := PropList^[I]^.PropType^;
      PropInfo := PropList^[I];
  
  
      { Skip types that are not supported [translated] }
      if not (PropTypeInf^.Kind in [tkDynArray, tkArray, tkRecord,
        tkInterface, tkMethod]) then
      begin
        if TagContent <> '' then
          TagContent := TagContent + '|';
        TagContent := TagContent + PropName;
      end;
  
      case PropTypeInf^.Kind of
        tkInteger, tkChar, tkFloat, tkString,
        tkWChar, tkLString, tkWString, tkVariant, tkEnumeration, tkSet:
  
          { conversion to DTD. Theese types will have #PCDATA model of content [translated] }
          addElement(PropName, PCDATA);
  
        { Code might be useful when using attributes  [translated] }
        {
        tkEnumeration:
        begin
          TypeData:= GetTypeData(GetTypeData(PropTypeInf)^.BaseType^);
          S := '';
          for J := TypeData^.MinValue to TypeData^.MaxValue do
          begin
            if S <> '' then S := S + '|';
            S := S + GetEnumName(PropTypeInf, J);
          end;
          addElement(PropName, S);
        end;
        }
        tkClass:
  
          { make recursive call for class-types  [translated] }
          begin
            PropObject := GetObjectProp(Component, PropInfo);
            if Assigned(PropObject) then
            begin
  
              { Specific(individual) handling of some specific classes [translated] }
              if PropObject is TPersistent then
                GenerateDTDInternal(PropObject, DTDList, Stream, PropName);
            end;
          end;
      end;
    end;
  
  
    { Collections require item("element") type(class) to be included into
      content model [translated] }
    if Component is TCollection then
    begin
      if TagContent <> '' then
        TagContent := TagContent + '|';
      TagContent := TagContent + (Component as TCollection).ItemClass.ClassName + '*';
    end;
  
  
    { Adding content model for the element(item)  [translated] }
    addElement(ComponentTagName, TagContent);
  finally
    FreeMem(PropList, NumProps * SizeOf(Pointer));
  end;
end;

function TICEXMLSerializer.IIF(AExpression: Boolean; const IfTrue, IfFalse:
        string): string;
begin
  if AExpression then
    Result := IfTrue
  else
    Result := IfFalse;
end;

function TICEXMLSerializer.IIF(AExpression: Boolean; IfTrue, IfFalse: Variant):
        Variant;
begin
  if AExpression then
    Result := IfTrue
  else
    Result := IfFalse;
end;

procedure TICEXMLSerializer.Serialize(Component: TObject; Stream: TStream);
var
  Result: string;
begin
  TAB := IIF(GenerateFormattedXML, #9, '');
  CR := IIF(GenerateFormattedXML, #13#10, '');
  
  Result := '';
  { Retrieving XML header [translated] }
  if Assigned(OnGetXMLHeader) then
    OnGetXMLHeader(Self, Result);
  if Result = '' then
    Result := DefaultXMLHeader;
  
  OutStream := Stream;
  
  WriteOutStream(PChar(Result));
  
  WriteOutStream(PChar(CR + '<' + Component.ClassName + '>'));
  SerializeInternal(Component);
  WriteOutStream(PChar(CR + '</' + Component.ClassName + '>'));
end;

procedure TICEXMLSerializer.SerializeInternal(Component: TObject; Level:
        Integer = 1);
var
  PropInfo: PPropInfo;
  TypeInf, PropTypeInf: PTypeInfo;
  TypeData: PTypeData;
  I, J: Integer;
  AName, PropName, sPropValue: string;
  PropList: PPropList;
  NumProps: Word;
  PropObject: TObject;
  
  { Adds opening tag with given name  [translated] }
  
  procedure addOpenTag(const Value: string);
  begin
    WriteOutStream(CR + DupStr(TAB, Level) + '<' + Value + '>');
    Inc(Level);
  end;
  
  { Adds closing tag with given name  [translated] }
  
  procedure addCloseTag(const Value: string; AddBreak: Boolean = False);
  begin
    Dec(Level);
    if AddBreak then
      WriteOutStream(CR + DupStr(TAB, Level));
    WriteOutStream('</' + Value + '>');
  end;
  
  { Adds value [in]to result string  [translated] }
  
  procedure addValue(const Value: string);
  begin
    WriteOutStream(Value);
  end;
  
begin
  //  Result := '';
  
  { Playing with RTTI }
  TypeInf := Component.ClassInfo;
  AName := TypeInf^.Name;
  TypeData := GetTypeData(TypeInf);
  NumProps := TypeData^.PropCount;
  
  GetMem(PropList, NumProps * SizeOf(Pointer));
  try
    { Getting list of properties  [translated] }
    GetPropInfos(TypeInf, PropList);
  
    for I := 0 to NumProps - 1 do
    begin
      PropName := PropList^[I]^.Name;
  
      PropTypeInf := PropList^[I]^.PropType^;
      PropInfo := PropList^[I];
  
      { Does the property wish to be saved?  [translated] }
      if not IsStoredProp(Component, PropInfo) then
        Continue;
  
      case PropTypeInf^.Kind of
        tkInteger, tkChar, tkEnumeration, tkFloat, tkString, tkSet,
        tkWChar, tkLString, tkWString, tkVariant:
          begin
            { Getting property's value  [translated] }
            sPropValue := GetPropValue(Component, PropName, True);
  
            { Checking if value is empty or is default  [translated] }
            if ExcludeEmptyValues and (sPropValue = '') then
              Continue;
            if ExcludeDefaultValues and (PropTypeInf^.Kind in ORDINAL_TYPES) and
              (sPropValue = IntToStr(PropInfo.Default)) then
              Continue;
  
            { special characters placeholders  [translated] }
            if FReplaceReservedSymbols then
            begin
              sPropValue := StringReplace(sPropValue, '<', '&lt;',
                [rfReplaceAll]);
              sPropValue := StringReplace(sPropValue, '>', '&gt;',
                [rfReplaceAll]);
            end;
  
            { converting to XML  [translated] }
            addOpenTag(PropName);
            { adds property's value to result  [translated] }
            addValue(sPropValue);
            addCloseTag(PropName);
          end;
        tkClass:
          { make recursive call for class-types  [translated] }
          begin
            PropObject := GetObjectProp(Component, PropInfo);
            if Assigned(PropObject) then
            begin
              { make recursive call for children class-types   [translated] }
  
              { Specific handlers for some certain classes  [translated] }
              if PropObject is TStrings then
              { text lists  [translated] }
              begin
                addOpenTag(PropName);
                WriteOutStream(TStrings(PropObject).CommaText);
                addCloseTag(PropName, True);
              end
              else
              if PropObject is TCollection then
              { collections  [translated] }
              begin
                if WrapCollections then
                  addOpenTag(PropName);
  
                SerializeInternal(PropObject, Level);
                for J := 0 to (PropObject as TCollection).Count - 1 do
                begin
                  { Container-tag with name of the class  [translated] }
                  addOpenTag(TCollection(PropObject).Items[J].ClassName);
                  SerializeInternal(TCollection(PropObject).Items[J],
                    Level);
                  addCloseTag(TCollection(PropObject).Items[J].ClassName, True);
                end;
  
                if WrapCollections then
                  addCloseTag(PropName, True);
              end
              else
              if PropObject is TPersistent then
              begin
                addOpenTag(PropName);
                SerializeInternal(PropObject, Level);
                addCloseTag(PropName, True);
              end;
  
              { Here one can add handling of other classes like TreeNodes, TListItems  [translated] }
            end;
            { Closing object's tag after proceeded its properties  [translated] }
          end;
      end;
    end;
  finally
    FreeMem(PropList, NumProps * SizeOf(Pointer));
  end;
end;

procedure TICEXMLSerializer.SetPropertyValue(Component: TObject; PropInfo:
        PPropInfo; Value, ValueEnd: PChar; ParentBlockEnd: PChar);
var
  PropTypeInf: PTypeInfo;
  PropObject: TObject;
  CollectionItem: TCollectionItem;
  SValue: string;
  TmpChar: Char;
begin
  PropTypeInf := PropInfo.PropType^;
  
  case PropTypeInf^.Kind of
    tkInteger, tkChar, tkEnumeration, tkFloat, tkString, tkSet,
    tkWChar, tkLString, tkWString, tkVariant:
      begin
  
        { simulates zero terminated string  [translated] }
        TmpChar := ValueEnd[0];
        ValueEnd[0] := #0;
        SValue := StrPas(Value);
        ValueEnd[0] := TmpChar;
  
  
        { Replacing specific characters (compatible only with that very component)  [translated] }
        if FReplaceReservedSymbols then
        begin
          SValue := StringReplace(SValue, '&lt;', '<', [rfReplaceAll]);
          SValue := StringReplace(SValue, '&gt;', '>', [rfReplaceAll]);
          // SValue := StringReplace(SValue, '&', '&', [rfReplaceAll]);
        end;
  
  
        { Changing delimiter to system-wide  [translated] }
        if PropTypeInf^.Kind = tkFloat then
          if DecimalSeparator = ',' then
            SValue := StringReplace(SValue, '.', DecimalSeparator, [rfReplaceAll])
          else
            SValue := StringReplace(SValue, ',', DecimalSeparator, [rfReplaceAll]);
  
        { tkSet parser needs "<" and ">" for correct transformation  [translated] }
        if PropTypeInf^.Kind = tkSet then
          SValue := '[' + SValue + ']';
        SetPropValue(Component, PropInfo^.Name, SValue);
      end;
    tkClass:
      begin
        PropObject := GetObjectProp(Component, PropInfo);
        if Assigned(PropObject) then
        begin
  
          { Specific(individual) handling of some specific classes  [translated] }
          if PropObject is TStrings then
  
          { text lists  [translated] }
          begin
            TmpChar := ValueEnd[0];
            ValueEnd[0] := #0;
            SValue := StrPas(Value);
            ValueEnd[0] := TmpChar;
            TStrings(PropObject).CommaText := SValue;
          end
          else
          if PropObject is TCollection then
  
          { collections  [translated] }
          begin
            while True do
  
            { we can't foretell number of element in TCollection  [translated] }
            begin
              CollectionItem := (PropObject as TCollection).Add;
              try
                DeSerializeInternal(CollectionItem,
                  CollectionItem.ClassName, ParentBlockEnd);
              except
  
                { Exception if next element is not found  [translated] }
                on E: Exception do
                begin
                  // Application.MessageBox(PChar(E.Message), '', MB_OK); - debug string
                  CollectionItem.Free;
                  // raise;  - debug string
                  Break;
                end;
              end;
            end;
          end
          else
  
            { Other classes are just processed recursevly  [translated] }
            DeSerializeInternal(PropObject, PropInfo^.Name,
              ParentBlockEnd);
        end;
      end;
  end;
end;

procedure TICEXMLSerializer.WriteOutStream(const Value: string);
begin
  if Value <> '' then
    OutStream.Write(PChar(Value)[0], Length(Value));
end;


{ writes string to output stream. Used for serialization. [translated] }


{
  Converts component to XML, according to published interface of its class
  Input:
    Component - Component to be converted
  Output:
    XML text into Stream
}

{
  Internal procedure Object->XML
  Is called from:
    Serialize()
  Input:
    Component - Component to be converted
    Level     - Level of nesting (for formatted output)
  Output:
    XML string into output Stream via .WriteOutStream() method
}

{
  Loads component's properties ("data") from stream, containing XML stream
  Input:
    Component - Component to be convertes.
    Stream    - Stream containing XML to load
  Preconditions:
    Components object was created prior to procedure's call
}


{
  Recursive procedure for loading of object from text buffer, containing XML
  Called from::
    Serialize()
  Input:
    Component        - Component to be converted,
    ComponentTagName - Name of XML tag for object (Arioch: may differ from
                       ClassName for CollectionItems, for XML header),
    ParentBlockEnd   - Pointer to the end of XML-description of the parent tag.
}

{
  Initialisation of the object's property
  Called from:
    DeSerializeInternal()
  Input:
    Component      - Component to be initialized
    PropInfo       - Information about type of property to set
    Value          - Value of the property
    ParentBlockEnd - Pointer to the end of XML description of parent tag. Used for recursion.
}

{
  This procedure generates DTD for given object according to its published interface
  Input:
    Component - Object
  Output:
    text of DTD into Stream
}



{
  Inner recursive procedure that generates DTD for given object
  Input:
    Component - Object
    DTDList   - list of already determined describedDTD elements
                to avoid duplicating
  Output:
    DTD text into Stream
}


end.

