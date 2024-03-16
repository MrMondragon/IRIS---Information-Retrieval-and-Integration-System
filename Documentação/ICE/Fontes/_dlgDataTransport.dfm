inherited dlgDataTransport: TdlgDataTransport
  Caption = 'Novo Transporte de Dados'
  ClientHeight = 118
  ClientWidth = 232
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 84
    Width = 232
    inherited btnCancel: TBitBtn
      Left = 153
    end
    inherited btnOk: TBitBtn
      Left = 77
    end
  end
  inherited pnlValues: TPanel
    Width = 232
    Height = 84
    inherited pnlPropPasOpName: TPanel
      Width = 228
      inherited edtName: TEdit
        Width = 173
      end
    end
    object pnlDts1: TPanel
      Left = 2
      Top = 42
      Width = 228
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 1
      DesignSize = (
        228
        20)
      object Label2: TLabel
        Left = 4
        Top = 4
        Width = 36
        Height = 13
        Caption = '&Destino'
      end
      object cbbDestino: TwwDBComboBox
        Left = 52
        Top = 1
        Width = 173
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
    object pnlDts2: TPanel
      Left = 2
      Top = 22
      Width = 228
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 2
      DesignSize = (
        228
        20)
      object Label3: TLabel
        Left = 4
        Top = 4
        Width = 27
        Height = 13
        Caption = '&Fonte'
      end
      object cbbFonte: TwwDBComboBox
        Left = 52
        Top = 1
        Width = 173
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
    object pnlPairList: TPanel
      Left = 2
      Top = 62
      Width = 228
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 3
      DesignSize = (
        228
        20)
      object Label4: TLabel
        Left = 4
        Top = 4
        Width = 38
        Height = 13
        Caption = '&Campos'
      end
      object cdgCampos: TwwDBComboDlg
        Left = 52
        Top = 1
        Width = 173
        Height = 18
        OnCustomDlg = cdgCamposCustomDlg
        Anchors = [akLeft, akTop, akRight]
        ShowButton = True
        Style = csDropDown
        AutoSize = False
        ReadOnly = True
        TabOrder = 0
        WordWrap = False
        UnboundDataType = wwDefault
      end
    end
  end
end
