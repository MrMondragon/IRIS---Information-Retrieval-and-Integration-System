object dlgControlStructure: TdlgControlStructure
  Left = 338
  Top = 209
  BorderStyle = bsDialog
  Caption = 'Estrutura de Controle'
  ClientHeight = 71
  ClientWidth = 253
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  KeyPreview = True
  OldCreateOrder = False
  Position = poScreenCenter
  OnKeyUp = FormKeyUp
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object dtiInspector: TwwDataInspector
    Left = 0
    Top = 0
    Width = 253
    Height = 37
    DisableThemes = False
    Align = alClient
    TabOrder = 0
    Items = <
      item
        Caption = 'Nome'
        WordWrap = False
      end>
    CaptionWidth = 73
    Options = [ovColumnResize, ovRowResize, ovEnterToTab, ovHighlightActiveRow, ovCenterCaptionVert]
    CaptionFont.Charset = DEFAULT_CHARSET
    CaptionFont.Color = clWindowText
    CaptionFont.Height = -11
    CaptionFont.Name = 'MS Sans Serif'
    CaptionFont.Style = []
  end
  object pnlBtns: TPanel
    Left = 0
    Top = 37
    Width = 253
    Height = 34
    Align = alBottom
    BevelInner = bvLowered
    TabOrder = 1
    DesignSize = (
      253
      34)
    object btnCancel: TBitBtn
      Left = 174
      Top = 4
      Width = 75
      Height = 25
      Anchors = [akTop, akRight]
      TabOrder = 0
      Kind = bkCancel
    end
    object btnOk: TBitBtn
      Left = 98
      Top = 4
      Width = 75
      Height = 25
      Anchors = [akTop, akRight]
      TabOrder = 1
      Kind = bkOK
    end
  end
end
