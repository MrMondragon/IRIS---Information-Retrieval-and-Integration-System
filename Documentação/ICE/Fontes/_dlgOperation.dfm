inherited dlgOperation: TdlgOperation
  Caption = 'Nova Opera'#231#227'o'
  ClientHeight = 58
  ClientWidth = 175
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 24
    Width = 175
    DesignSize = (
      175
      34)
    inherited btnCancel: TBitBtn
      Left = 96
    end
    inherited btnOk: TBitBtn
      Left = 20
    end
  end
  inherited pnlValues: TPanel
    Width = 175
    Height = 24
    object pnlPropPasOpName: TPanel
      Left = 2
      Top = 2
      Width = 171
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 0
      DesignSize = (
        171
        20)
      object Label1: TLabel
        Left = 4
        Top = 4
        Width = 28
        Height = 13
        Caption = '&Nome'
        FocusControl = edtName
      end
      object edtName: TEdit
        Left = 52
        Top = 1
        Width = 116
        Height = 18
        Anchors = [akLeft, akTop, akRight]
        AutoSize = False
        TabOrder = 0
      end
    end
  end
end
