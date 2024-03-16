inherited dlgDBConnection: TdlgDBConnection
  Caption = 'Nova Conex'#227'o de Banco'
  ClientHeight = 118
  ClientWidth = 230
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 84
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
    Height = 84
    object pnlDBCConnectionString: TPanel
      Left = 2
      Top = 22
      Width = 226
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'Conex'#227'o'
      TabOrder = 1
      DesignSize = (
        226
        20)
      object cdgConnectionString: TwwDBComboDlg
        Left = 117
        Top = 1
        Width = 108
        Height = 18
        OnCustomDlg = cdgConnectionStringCustomDlg
        Anchors = [akTop, akRight]
        ShowButton = True
        Style = csDropDown
        AutoSize = False
        TabOrder = 0
        WordWrap = False
        UnboundDataType = wwDefault
      end
    end
    object pnlDBCLocation: TPanel
      Left = 2
      Top = 62
      Width = 226
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'ClientSide'
      TabOrder = 3
      DesignSize = (
        226
        20)
      object cbxDBCClientSide: TCheckBox
        Left = 117
        Top = 2
        Width = 20
        Height = 17
        Anchors = [akTop, akRight]
        TabOrder = 0
      end
    end
    object pnlDBCTimeOut: TPanel
      Left = 2
      Top = 42
      Width = 226
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'TimeOut'
      TabOrder = 2
      DesignSize = (
        226
        20)
      object speDBCTimeOut: TwwDBSpinEdit
        Left = 117
        Top = 1
        Width = 108
        Height = 18
        Anchors = [akTop, akRight]
        Increment = 10.000000000000000000
        AutoSize = False
        TabOrder = 0
        UnboundDataType = wwDefault
      end
    end
    object pnlDBCName: TPanel
      Left = 2
      Top = 2
      Width = 226
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      Caption = 'Nome'
      TabOrder = 0
      DesignSize = (
        226
        20)
      object edtName: TEdit
        Left = 117
        Top = 1
        Width = 108
        Height = 18
        Anchors = [akTop, akRight]
        AutoSize = False
        TabOrder = 0
      end
    end
  end
end
