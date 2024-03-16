object PersistencyModule: TPersistencyModule
  OldCreateOrder = False
  Left = 411
  Top = 402
  Height = 230
  Width = 320
  object Serializer: TJvgXMLSerializer
    ExcludeEmptyValues = False
    ExcludeDefaultValues = False
    ReplaceReservedSymbols = True
    IgnoreUnknownTags = False
    Left = 116
    Top = 8
  end
  object SaveDialog1: TSaveDialog
    InitialDir = 
      'C:\Documents and Settings\MARCELO\Meus documentos\ICE\Pesquisa\X' +
      'ML'
    Left = 24
    Top = 8
  end
  object OpenDialog1: TOpenDialog
    InitialDir = 
      'C:\Documents and Settings\MARCELO\Meus documentos\ICE\Pesquisa\X' +
      'ML'
    Left = 24
    Top = 68
  end
  object XMLDocument1: TXMLDocument
    Left = 116
    Top = 68
    DOMVendorDesc = 'MSXML'
  end
end
