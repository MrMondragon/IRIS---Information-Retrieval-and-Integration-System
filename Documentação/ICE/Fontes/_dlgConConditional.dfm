inherited dlgConConditional: TdlgConConditional
  Left = 262
  Top = 248
  Caption = 'Nova Conex'#227'o Condicional'
  ClientHeight = 118
  ClientWidth = 238
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 84
    Width = 238
    inherited btnCancel: TBitBtn
      Left = 159
    end
    inherited btnOk: TBitBtn
      Left = 83
    end
  end
  inherited pnlValues: TPanel
    Width = 238
    Height = 84
    inherited pnlFonte: TPanel
      Top = 42
      Width = 234
      DesignSize = (
        234
        20)
      inherited cbbFonte: TwwDBComboBox
        Width = 143
      end
    end
    inherited pnlDestino: TPanel
      Top = 62
      Width = 234
      inherited cbbDestino: TwwDBComboBox
        Width = 143
      end
    end
    object pnlElse: TPanel
      Left = 2
      Top = 22
      Width = 234
      Height = 20
      Align = alBottom
      Alignment = taLeftJustify
      TabOrder = 2
      object Label1: TLabel
        Left = 4
        Top = 3
        Width = 20
        Height = 13
        Caption = '&Else'
      end
      object cbxElseValue: TCheckBox
        Left = 91
        Top = 3
        Width = 21
        Height = 15
        TabOrder = 0
      end
    end
    object pnlValTest: TPanel
      Left = 2
      Top = 2
      Width = 234
      Height = 20
      Align = alBottom
      Alignment = taLeftJustify
      TabOrder = 3
      DesignSize = (
        234
        20)
      object Label4: TLabel
        Left = 4
        Top = 3
        Width = 72
        Height = 13
        Caption = '&Valor de Teste:'
      end
      object edtValue: TEdit
        Left = 90
        Top = 1
        Width = 143
        Height = 18
        Anchors = [akLeft, akRight, akBottom]
        AutoSize = False
        TabOrder = 0
      end
    end
  end
end
