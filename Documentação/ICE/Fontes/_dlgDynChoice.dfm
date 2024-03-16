inherited dlgDynChoice: TdlgDynChoice
  Left = 314
  Top = 218
  Caption = 'Novo Ponto de Escolha'
  ClientHeight = 78
  ClientWidth = 222
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 44
    Width = 222
    DesignSize = (
      222
      34)
    inherited btnCancel: TBitBtn
      Left = 143
    end
    inherited btnOk: TBitBtn
      Left = 67
    end
  end
  inherited pnlValues: TPanel
    Width = 222
    Height = 44
    inherited pnlPropPasOpName: TPanel
      Width = 218
      DesignSize = (
        218
        20)
      inherited edtName: TEdit
        Left = 90
        Width = 126
        OnExit = nil
        OnKeyUp = nil
      end
    end
    object pnlVars: TPanel
      Left = 2
      Top = 22
      Width = 218
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 1
      DesignSize = (
        218
        20)
      object Label2: TLabel
        Left = 4
        Top = 4
        Width = 83
        Height = 13
        Caption = '&Vari'#225'vel de Teste'
      end
      object cbbVars: TwwDBComboBox
        Left = 90
        Top = 1
        Width = 126
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
  end
end
