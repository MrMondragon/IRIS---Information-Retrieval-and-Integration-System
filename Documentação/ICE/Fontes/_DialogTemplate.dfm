object dlgTemplate: TdlgTemplate
  Left = 370
  Top = 221
  BorderStyle = bsDialog
  Caption = 'Template'
  ClientHeight = 80
  ClientWidth = 176
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  KeyPreview = True
  OldCreateOrder = False
  Position = poScreenCenter
  OnKeyPress = FormKeyPress
  PixelsPerInch = 96
  TextHeight = 13
  object pnlBtns: TPanel
    Left = 0
    Top = 46
    Width = 176
    Height = 34
    Align = alBottom
    BevelInner = bvLowered
    TabOrder = 0
    DesignSize = (
      176
      34)
    object btnCancel: TBitBtn
      Left = 97
      Top = 4
      Width = 75
      Height = 25
      Anchors = [akTop, akRight]
      TabOrder = 1
      Kind = bkCancel
    end
    object btnOk: TBitBtn
      Left = 21
      Top = 4
      Width = 75
      Height = 25
      Anchors = [akTop, akRight]
      TabOrder = 0
      Kind = bkOK
    end
  end
  object pnlValues: TPanel
    Left = 0
    Top = 0
    Width = 176
    Height = 46
    Align = alClient
    BevelInner = bvLowered
    TabOrder = 1
  end
end
