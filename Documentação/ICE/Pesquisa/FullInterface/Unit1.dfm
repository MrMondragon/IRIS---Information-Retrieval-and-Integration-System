object Form1: TForm1
  Left = 207
  Top = 198
  Width = 751
  Height = 540
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object StatusBar1: TStatusBar
    Left = 0
    Top = 487
    Width = 743
    Height = 19
    Panels = <>
  end
  object ToolBar1: TToolBar
    Left = 0
    Top = 0
    Width = 743
    Height = 29
    Caption = 'ToolBar1'
    TabOrder = 1
  end
  object Panel1: TPanel
    Left = 0
    Top = 29
    Width = 743
    Height = 458
    Align = alClient
    BevelOuter = bvNone
    Caption = 'Panel1'
    TabOrder = 2
    object Splitter1: TSplitter
      Left = 0
      Top = 325
      Width = 743
      Height = 3
      Cursor = crVSplit
      Align = alBottom
      Beveled = True
    end
    object MainCanvas: TdxFlowChart
      Left = 0
      Top = 0
      Width = 743
      Height = 325
      Options = [fcoCanDelete, fcoCanDrag, fcoCanSelect, fcoMultiSelect, fcoHideSelection, fcoDelOnClick]
      Align = alClient
    end
    object SyntaxMemo1: TSynMemo
      Left = 0
      Top = 328
      Width = 743
      Height = 130
      Align = alBottom
      ClipCopyFormats = [smTEXT, smRTF]
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -13
      Font.Name = 'Courier New'
      Font.Style = []
      GutterColor = clYellow
      GutterFont.Charset = DEFAULT_CHARSET
      GutterFont.Color = clWindowText
      GutterFont.Height = -11
      GutterFont.Name = 'MS Sans Serif'
      GutterFont.Style = []
      HyperCursor = crDefault
      IndentStep = 1
      Lines.Strings = (
        '')
      Margin = 8
      Modified = False
      MonoPrint = True
      Options = [smoSyntaxHighlight, smoPrintWrap, smoPrintLineNos, smoPrintFilename, smoPrintDate, smoPrintPageNos, smoAutoIndent, smoTabToColumn, smoWordSelect, smoShowRMargin, smoShowGutter, smoShowWrapColumn, smoTitleAsFilename, smoProcessDroppedFiles, smoBlockOverwriteCursor, smoShowWrapGlyph, smoColumnTrack, smoUseTAB, smoSmartFill, smoOLEDragSource]
      ReadOnly = False
      RightMargin = 80
      SaveFormat = sfTEXT
      ScrollBars = ssBoth
      SelLineStyle = lsCRLF
      SelStart = 0
      SelLength = 0
      SelTextColor = clWhite
      SelTextBack = clBlue
      TabDefault = 4
      TabOrder = 1
      Version = '3.00.39'
      VisiblePropEdPages = [ppOPTIONS, ppHIGHLIGHTING, ppKEYS, ppAUTOCORRECT, ppTEMPLATES]
      WrapAtColumn = 0
      ActiveParser = 1
      Parser1 = GlobalParserDtm.PascalScript
      Parser2 = GlobalParserDtm.SQLScript
    end
  end
  object ToolBarImages: TImageList
    Left = 680
  end
  object ToolActions: TActionList
    Left = 708
  end
end
