inherited dlgForLoop: TdlgForLoop
  Caption = 'Novo Loop For'
  ClientHeight = 118
  PixelsPerInch = 96
  TextHeight = 13
  inherited pnlBtns: TPanel
    Top = 84
  end
  inherited pnlValues: TPanel
    Height = 84
    object pnlMax: TPanel
      Left = 2
      Top = 62
      Width = 218
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 2
      object Label4: TLabel
        Left = 4
        Top = 3
        Width = 36
        Height = 13
        Caption = '&M'#225'ximo'
        FocusControl = cedMax
      end
      object cedMax: TfcCalcEdit
        Left = 90
        Top = 1
        Width = 126
        Height = 18
        CalcOptions.BackgroundStyle = cbdStretch
        CalcOptions.Options = []
        AutoSize = False
        ButtonStyle = cbsDownArrow
        MaxLength = 20
        ReadOnly = False
        TabOrder = 0
        Text = '0'
      end
    end
    object pnlMin: TPanel
      Left = 2
      Top = 42
      Width = 218
      Height = 20
      Align = alTop
      Alignment = taLeftJustify
      TabOrder = 3
      object Label3: TLabel
        Left = 4
        Top = 3
        Width = 35
        Height = 13
        Caption = 'M'#237'n&imo'
        FocusControl = cedMin
      end
      object cedMin: TfcCalcEdit
        Left = 90
        Top = 1
        Width = 126
        Height = 18
        CalcOptions.BackgroundStyle = cbdStretch
        CalcOptions.Options = []
        AutoSize = False
        ButtonStyle = cbsDownArrow
        MaxLength = 20
        ReadOnly = False
        TabOrder = 0
        Text = '0'
      end
    end
  end
end
