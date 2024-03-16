inherited dlgSQLOperation: TdlgSQLOperation
  Left = 257
  Top = 250
  Caption = 'Novo Comando SQL'
  ClientHeight = 98
  ClientWidth = 230
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 64
    Width = 230
    inherited btnCancel: TBitBtn
      Left = 151
    end
    inherited btnOk: TBitBtn
      Left = 75
    end
  end
  inherited pnlValues: TPanel
    Width = 230
    Height = 64
    inherited pnlPropPasOpName: TPanel
      Width = 226
      DesignSize = (
        226
        20)
      inherited Label1: TLabel
        Top = 3
      end
      inherited edtName: TEdit
        Left = 108
        Width = 117
      end
    end
    object pnlDBConnection: TPanel
      Left = 2
      Top = 22
      Width = 226
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 1
      DesignSize = (
        226
        20)
      object Label2: TLabel
        Left = 4
        Top = 3
        Width = 94
        Height = 13
        Caption = '&Conex'#227'o de Banco:'
      end
      object cbbConnection: TwwDBComboBox
        Left = 108
        Top = 1
        Width = 117
        Height = 18
        Anchors = [akLeft, akTop, akRight]
        ShowButton = True
        Style = csDropDownList
        MapList = False
        AllowClearKey = False
        AutoSize = False
        DropDownCount = 8
        ItemHeight = 0
        Sorted = True
        TabOrder = 0
        UnboundDataType = wwDefault
      end
    end
    object pnlPrepareCommand: TPanel
      Left = 2
      Top = 42
      Width = 226
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 2
      object cbxPrepareCommand: TCheckBox
        Left = 2
        Top = 2
        Width = 119
        Height = 17
        Alignment = taLeftJustify
        Caption = '&Prepare Command:'
        TabOrder = 0
      end
    end
  end
end
