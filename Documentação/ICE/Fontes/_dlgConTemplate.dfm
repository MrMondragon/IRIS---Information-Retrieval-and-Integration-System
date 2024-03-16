inherited dlgConTemplate: TdlgConTemplate
  Left = 332
  Top = 222
  Caption = 'dlgConTemplate'
  ClientHeight = 127
  ClientWidth = 221
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 93
    Width = 221
    DesignSize = (
      221
      34)
    inherited btnCancel: TBitBtn
      Left = 142
    end
    inherited btnOk: TBitBtn
      Left = 66
    end
  end
  inherited pnlValues: TPanel
    Width = 221
    Height = 93
    object pnlFonte: TPanel
      Left = 2
      Top = 51
      Width = 217
      Height = 20
      Align = alBottom
      Alignment = taLeftJustify
      TabOrder = 0
      DesignSize = (
        217
        20)
      object lbFonte: TLabel
        Left = 4
        Top = 3
        Width = 27
        Height = 13
        Caption = '&Fonte'
      end
      object cbbFonte: TwwDBComboBox
        Left = 90
        Top = 1
        Width = 126
        Height = 18
        Anchors = [akLeft, akRight, akBottom]
        ShowButton = True
        Style = csDropDownList
        MapList = False
        AllowClearKey = False
        AutoSize = False
        DropDownCount = 8
        ItemHeight = 0
        Sorted = False
        TabOrder = 0
        UnboundDataType = wwDefault
      end
    end
    object pnlDestino: TPanel
      Left = 2
      Top = 71
      Width = 217
      Height = 20
      Align = alBottom
      Alignment = taLeftJustify
      TabOrder = 1
      DesignSize = (
        217
        20)
      object lbDest: TLabel
        Left = 4
        Top = 3
        Width = 36
        Height = 13
        Caption = '&Destino'
      end
      object cbbDestino: TwwDBComboBox
        Left = 90
        Top = 1
        Width = 126
        Height = 18
        Anchors = [akLeft, akRight, akBottom]
        ShowButton = True
        Style = csDropDownList
        MapList = False
        AllowClearKey = False
        AutoSize = False
        DropDownCount = 8
        ItemHeight = 0
        Sorted = False
        TabOrder = 0
        UnboundDataType = wwDefault
      end
    end
  end
end
