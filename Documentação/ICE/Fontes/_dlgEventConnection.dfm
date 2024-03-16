inherited dlgEventConnection: TdlgEventConnection
  Left = 259
  Top = 244
  Caption = 'Nova Conex'#227'o de Eventos'
  ClientHeight = 98
  ClientWidth = 233
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 64
    Width = 233
    inherited btnCancel: TBitBtn
      Left = 154
    end
    inherited btnOk: TBitBtn
      Left = 78
    end
  end
  inherited pnlValues: TPanel
    Width = 233
    Height = 64
    inherited pnlFonte: TPanel
      Top = 22
      Width = 229
      DesignSize = (
        229
        20)
      inherited cbbFonte: TwwDBComboBox
        Left = 102
      end
    end
    inherited pnlDestino: TPanel
      Top = 42
      Width = 229
      inherited cbbDestino: TwwDBComboBox
        Left = 102
      end
    end
    object pnlEvent: TPanel
      Left = 2
      Top = 2
      Width = 229
      Height = 20
      Align = alBottom
      Alignment = taLeftJustify
      TabOrder = 2
      DesignSize = (
        229
        20)
      object Label2: TLabel
        Left = 4
        Top = 3
        Width = 76
        Height = 13
        Caption = '&Tipo de Evento:'
      end
      object cbbTipo: TwwDBComboBox
        Left = 102
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
        Items.Strings = (
          'T'#233'rmino'
          'Sucesso'
          'Falha')
        ItemIndex = 0
        Sorted = False
        TabOrder = 0
        UnboundDataType = wwDefault
      end
    end
  end
end
