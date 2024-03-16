inherited dlgDepConnection: TdlgDepConnection
  Caption = 'Nova Conex'#227'o de Depend'#234'ncia'
  ClientHeight = 98
  ClientWidth = 262
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 64
    Width = 262
    DesignSize = (
      262
      34)
    inherited btnCancel: TBitBtn
      Left = 183
    end
    inherited btnOk: TBitBtn
      Left = 107
    end
  end
  inherited pnlValues: TPanel
    Width = 262
    Height = 64
    inherited pnlFonte: TPanel
      Top = 22
      Width = 258
      DesignSize = (
        258
        20)
      inherited cbbFonte: TwwDBComboBox
        Left = 118
        Width = 138
      end
    end
    inherited pnlDestino: TPanel
      Top = 42
      Width = 258
      inherited cbbDestino: TwwDBComboBox
        Left = 118
        Width = 138
      end
    end
    object pnlStatus: TPanel
      Left = 2
      Top = 2
      Width = 258
      Height = 20
      Align = alBottom
      Alignment = taLeftJustify
      TabOrder = 2
      DesignSize = (
        258
        20)
      object Label2: TLabel
        Left = 4
        Top = 3
        Width = 79
        Height = 13
        Caption = '&Status do Objeto'
      end
      object cbbStatus: TwwDBComboBox
        Left = 118
        Top = 1
        Width = 138
        Height = 18
        Anchors = [akLeft, akRight, akBottom]
        ShowButton = True
        Style = csDropDownList
        MapList = False
        AllowClearKey = False
        AutoSize = False
        DropDownCount = 8
        ItemHeight = 0
        Items.Strings = (
          'Disabled'
          'Failure'
          'Ready'
          'Running'
          'Success')
        ItemIndex = 0
        Sorted = True
        TabOrder = 0
        UnboundDataType = wwDefault
      end
    end
  end
end
