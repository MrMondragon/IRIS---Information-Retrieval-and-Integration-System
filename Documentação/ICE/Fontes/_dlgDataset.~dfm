inherited dlgDataset: TdlgDataset
  Left = 349
  Top = 248
  Caption = 'dlgDataset'
  ClientHeight = 158
  ClientWidth = 173
  OldCreateOrder = True
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 125
    Width = 173
    Height = 33
    inherited btnCancel: TBitBtn
      Left = 94
    end
    inherited btnOk: TBitBtn
      Left = 18
    end
  end
  inherited pnlValues: TPanel
    Width = 173
    Height = 125
    object pnlDtsName: TPanel
      Left = 2
      Top = 2
      Width = 169
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'Nome'
      TabOrder = 0
      DesignSize = (
        169
        20)
      object edtDtsName: TEdit
        Left = 66
        Top = 1
        Width = 100
        Height = 18
        Anchors = [akTop, akRight]
        AutoSize = False
        TabOrder = 0
      end
    end
    object pnlMasterSource: TPanel
      Left = 2
      Top = 82
      Width = 169
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'Master Dts'
      TabOrder = 4
      DesignSize = (
        169
        20)
      object cbbMasterDts: TwwDBComboBox
        Left = 66
        Top = 1
        Width = 100
        Height = 18
        Anchors = [akTop, akRight]
        ShowButton = True
        Style = csDropDownList
        MapList = False
        AllowClearKey = True
        AutoSize = False
        DropDownCount = 8
        ItemHeight = 0
        Sorted = True
        TabOrder = 0
        UnboundDataType = wwDefault
      end
    end
    object pnlMasterFields: TPanel
      Left = 2
      Top = 102
      Width = 169
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'Master Fields'
      TabOrder = 5
      DesignSize = (
        169
        20)
      object cdgMasterFields: TwwDBComboDlg
        Left = 66
        Top = 1
        Width = 100
        Height = 18
        OnCustomDlg = cdgMasterFieldsCustomDlg
        Anchors = [akTop, akRight]
        ShowButton = True
        Style = csDropDown
        AutoSize = False
        ReadOnly = True
        TabOrder = 0
        WordWrap = False
        UnboundDataType = wwDefault
      end
    end
    object pnlCacheSize: TPanel
      Left = 2
      Top = 62
      Width = 169
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'Cache Size'
      TabOrder = 3
      DesignSize = (
        169
        20)
      object speCacheSize: TwwDBSpinEdit
        Left = 66
        Top = 1
        Width = 100
        Height = 18
        Anchors = [akTop, akRight]
        Increment = 1.000000000000000000
        MaxValue = 1000000.000000000000000000
        MinValue = 1.000000000000000000
        Value = 1.000000000000000000
        AutoSize = False
        TabOrder = 0
        UnboundDataType = wwDefault
      end
    end
    object pnlSQL: TPanel
      Left = 2
      Top = 42
      Width = 169
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'SQL'
      TabOrder = 2
      DesignSize = (
        169
        20)
      object cdgSQL: TwwDBComboDlg
        Left = 66
        Top = 1
        Width = 100
        Height = 18
        OnCustomDlg = cdgSQLCustomDlg
        Anchors = [akTop, akRight]
        ShowButton = True
        Style = csDropDown
        AutoSize = False
        TabOrder = 0
        WordWrap = False
        UnboundDataType = wwDefault
      end
    end
    object pnlDBConnection: TPanel
      Left = 2
      Top = 22
      Width = 169
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'Conex'#227'o'
      TabOrder = 1
      DesignSize = (
        169
        20)
      object cbbDBConnection: TwwDBComboBox
        Left = 66
        Top = 1
        Width = 100
        Height = 18
        Anchors = [akTop, akRight]
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
        OnCloseUp = cbbDBConnectionCloseUp
      end
    end
  end
end
