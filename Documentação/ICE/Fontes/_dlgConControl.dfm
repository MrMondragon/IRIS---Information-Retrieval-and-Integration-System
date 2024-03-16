inherited dlgConControl: TdlgConControl
  Caption = 'Nova Conex'#227'o de Controle'
  ClientHeight = 78
  ClientWidth = 233
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 44
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
    Height = 44
    inherited pnlFonte: TPanel
      Top = 2
      Width = 229
      inherited cbbFonte: TwwDBComboBox
        Left = 86
        Width = 141
      end
    end
    inherited pnlDestino: TPanel
      Top = 22
      Width = 229
      inherited cbbDestino: TwwDBComboBox
        Left = 86
        Width = 141
      end
    end
  end
end
