object dlgLookupPairs: TdlgLookupPairs
  Left = 281
  Top = 73
  BorderStyle = bsDialog
  Caption = 'Atribui'#231#227'o de Campos'
  ClientHeight = 371
  ClientWidth = 362
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object pnlTop: TPanel
    Left = 0
    Top = 0
    Width = 362
    Height = 193
    Align = alTop
    BevelInner = bvLowered
    TabOrder = 0
    object pnlCampos1: TPanel
      Left = 2
      Top = 2
      Width = 133
      Height = 189
      Align = alLeft
      BevelInner = bvLowered
      TabOrder = 0
      object lbxCampos1: TListBox
        Left = 2
        Top = 22
        Width = 129
        Height = 165
        Align = alBottom
        ItemHeight = 13
        ParentShowHint = False
        ShowHint = True
        TabOrder = 0
        OnDblClick = btnAddClick
      end
      object pnlTab1: TPanel
        Left = 2
        Top = 2
        Width = 129
        Height = 20
        Align = alClient
        Alignment = taLeftJustify
        BevelInner = bvLowered
        Caption = 'Tab1'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 1
      end
    end
    object pnlCampos2: TPanel
      Left = 227
      Top = 2
      Width = 133
      Height = 189
      Align = alRight
      BevelInner = bvLowered
      TabOrder = 1
      object lbxCampos2: TListBox
        Left = 2
        Top = 22
        Width = 129
        Height = 165
        Align = alBottom
        ItemHeight = 13
        ParentShowHint = False
        ShowHint = True
        TabOrder = 0
        OnDblClick = btnAddClick
      end
      object pnlTab2: TPanel
        Left = 2
        Top = 2
        Width = 129
        Height = 20
        Align = alClient
        Alignment = taLeftJustify
        BevelInner = bvLowered
        Caption = 'Tab2'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 1
      end
    end
    object pnlBtns: TPanel
      Left = 135
      Top = 2
      Width = 92
      Height = 189
      Align = alClient
      BevelInner = bvLowered
      TabOrder = 2
      DesignSize = (
        92
        189)
      object btnAdd: TfcShapeBtn
        Left = 9
        Top = 65
        Width = 75
        Height = 25
        Anchors = []
        Caption = 'Add'
        Color = clBtnFace
        DitherColor = clWhite
        Glyph.Data = {
          36030000424D3603000000000000360000002800000010000000100000000100
          18000000000000030000120B0000120B00000000000000000000FF00FFFF00FF
          FF00FFFF00FFFF00FF7F7F7F7F7F7F7D7D7D7C7C7C7B7B7B7B7B7BFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF929292929292909090A0A0A0A9
          A9A9A6A6A69494947E7E7E7C7C7C7C7C7CFF00FFFF00FFFF00FFFF00FFFF00FF
          999999999999B9B9B9DBDBDBEDEDEDEDEDEDEDEDEDEDEDEDD3D3D3A4A4A47D7D
          7D828282FF00FFFF00FFFF00FF9D9D9D9C9C9CCFCFCFEDEDEDEDEDEDD4D4D4C0
          C0C0C0C0C0D8D8D8EDEDEDEDEDEDBABABA7D7D7D7F7F7FFF00FFFF00FF9D9D9D
          CACACAEDEDEDE4E4E4AEAEAE8F8F8F8B8B8B888888898989AEAEAEE7E7E7EDED
          EDA9A9A97F7F7FFF00FFA2A2A2AAAAAAEBEBEBEAEAEAACACAC9595959A9A9AD0
          D0D0CACACA8F8F8F878787A9A9A9EDEDEDDCDCDC868686818181A2A2A2C3C3C3
          EDEDEDCBCBCB9C9C9C9999999D9D9DE8E8E8E1E1E19090908A8A8A888888CCCC
          CCEDEDEDA7A7A7818181A4A4A4D4D4D4EDEDEDB5B5B5A7A7A7CFCFCFD5D5D5EA
          EAEAE8E8E8D2D2D2C6C6C6909090ADADADEDEDEDBFBFBF818181AAAAAADCDCDC
          EDEDEDB4B4B4AFAFAFEBEBEBEDEDEDEDEDEDEDEDEDEDEDEDE5E5E5969696A9A9
          A9EDEDEDC3C3C38C8C8CB6B6B6DCDCDCEDEDEDBFBFBFA7A7A7B4B4B4BBBBBBE8
          E8E8E3E3E3B2B2B2A8A8A8929292BBBBBBEDEDEDBCBCBC8E8E8EAAAAAAD8D8D8
          EDEDEDDDDDDDA7A7A7A6A6A6ABABABE9E9E9E3E3E39E9E9E9999999B9B9BDFDF
          DFEBEBEBA4A4A48E8E8EFF00FFCDCDCDEDEDEDEDEDEDCCCCCCA6A6A6A6A6A6B9
          B9B9B6B6B6A0A0A09F9F9FCFCFCFEDEDEDD3D3D3939393FF00FFFF00FFC5C5C5
          E2E2E2EDEDEDEDEDEDD7D7D7B6B6B6ACACACACACACB8B8B8DADADAEDEDEDE6E6
          E6A7A7A7939393FF00FFFF00FFFF00FFCBCBCBE5E5E5EDEDEDEDEDEDECECECE4
          E4E4E5E5E5EDEDEDEDEDEDE1E1E1AEAEAE989898FF00FFFF00FFFF00FFFF00FF
          FF00FFCCCCCCD9D9D9E6E6E6EDEDEDEDEDEDEDEDEDE5E5E5C9C9C9A5A5A59898
          98FF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFCCCCCCCCCCCCCE
          CECEC7C7C7B9B9B9A9A9A9FF00FFFF00FFFF00FFFF00FFFF00FF}
        NumGlyphs = 0
        ParentClipping = True
        RoundRectBias = 25
        ShadeStyle = fbsHighlight
        TabOrder = 0
        TextOptions.Alignment = taLeftJustify
        TextOptions.VAlignment = vaVCenter
        OnClick = btnAddClick
      end
      object btnRemove: TfcShapeBtn
        Left = 9
        Top = 95
        Width = 75
        Height = 25
        Anchors = []
        Caption = 'Remove'
        Color = clBtnFace
        DitherColor = clWhite
        Glyph.Data = {
          36030000424D3603000000000000360000002800000010000000100000000100
          18000000000000030000120B0000120B00000000000000000000FF00FFFF00FF
          FF00FFFF00FFFF00FF8282828282828080807F7F7F7E7E7E7E7E7EFF00FFFF00
          FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FF959595959595939393A3A3A3AC
          ACACAAAAAA979797818181808080808080FF00FFFF00FFFF00FFFF00FFFF00FF
          9C9C9C9C9C9CBCBCBCDFDFDFF0F0F0F0F0F0F0F0F0F0F0F0D6D6D6A7A7A78080
          80858585FF00FFFF00FFFF00FFA0A0A0A0A0A0D2D2D2F0F0F0F0F0F0D7D7D7C3
          C3C3C3C3C3DBDBDBF0F0F0F0F0F0BDBDBD808080828282FF00FFFF00FFA0A0A0
          CDCDCDF0F0F0E7E7E7B1B1B19292929D9D9D9B9B9B8C8C8CB1B1B1EAEAEAF0F0
          F0ACACAC828282FF00FFA5A5A5ADADADEFEFEFEDEDEDAFAFAF9898989D9D9D9B
          9B9B9292929191918A8A8AACACACF0F0F0DFDFDF898989848484A5A5A5C6C6C6
          F0F0F0CECECE9F9F9F9C9C9CA1A1A19B9B9B9292929292928D8D8D8B8B8BCFCF
          CFF0F0F0AAAAAA848484A7A7A7D7D7D7F0F0F0B8B8B8AAAAAAEEEEEEEEEEEEEE
          EEEEEBEBEBEBEBEBEBEBEB939393B0B0B0F0F0F0C2C2C2848484ADADADDFDFDF
          F0F0F0B7B7B7B2B2B2DFDFDFF0F0F0F0F0F0F0F0F0F0F0F0E9E9E99A9A9AACAC
          ACF0F0F0C6C6C6909090BABABADFDFDFF0F0F0C2C2C2ABABABAEAEAEA8A8A8A5
          A5A5A1A1A1A1A1A1959595959595BEBEBEF0F0F0BFBFBF919191ADADADDBDBDB
          F0F0F0E0E0E0AAAAAAA9A9A9ABABABAAAAAAA1A1A1A0A0A09F9F9F9E9E9EE2E2
          E2EFEFEFA7A7A7919191FF00FFD0D0D0F0F0F0F0F0F0CFCFCFA9A9A9AAAAAAAA
          AAAAB0B0B0A3A3A3A2A2A2D2D2D2F0F0F0D6D6D6969696FF00FFFF00FFC9C9C9
          E5E5E5F0F0F0F0F0F0DADADABABABAAFAFAFAFAFAFBBBBBBDDDDDDF0F0F0EAEA
          EAAAAAAA969696FF00FFFF00FFFF00FFCFCFCFE9E9E9F0F0F0F0F0F0EFEFEFE7
          E7E7E8E8E8F0F0F0F0F0F0E4E4E4B1B1B19B9B9BFF00FFFF00FFFF00FFFF00FF
          FF00FFCFCFCFDCDCDCE9E9E9F0F0F0F0F0F0F0F0F0E8E8E8CCCCCCA8A8A89B9B
          9BFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFCFCFCFCFCFCFD1
          D1D1CACACABCBCBCACACACFF00FFFF00FFFF00FFFF00FFFF00FF}
        NumGlyphs = 0
        ParentClipping = True
        RoundRectBias = 25
        ShadeStyle = fbsHighlight
        TabOrder = 1
        TextOptions.Alignment = taLeftJustify
        TextOptions.VAlignment = vaVCenter
        OnClick = btnRemoveClick
      end
    end
  end
  object pnlBottom: TPanel
    Left = 0
    Top = 337
    Width = 362
    Height = 34
    Align = alBottom
    BevelInner = bvLowered
    TabOrder = 1
    DesignSize = (
      362
      34)
    object btnCancel: TBitBtn
      Left = 281
      Top = 4
      Width = 75
      Height = 25
      Anchors = [akRight, akBottom]
      TabOrder = 0
      Kind = bkCancel
    end
    object btnOk: TBitBtn
      Left = 201
      Top = 4
      Width = 75
      Height = 25
      Anchors = [akRight, akBottom]
      TabOrder = 1
      Kind = bkOK
    end
  end
  object lbxPares: TListBox
    Left = 0
    Top = 233
    Width = 362
    Height = 104
    Align = alClient
    ItemHeight = 13
    TabOrder = 2
    OnDblClick = btnRemoveClick
  end
  object pnlLookupField: TPanel
    Left = 0
    Top = 193
    Width = 362
    Height = 40
    Align = alTop
    BevelInner = bvLowered
    TabOrder = 3
    DesignSize = (
      362
      40)
    object Label1: TLabel
      Left = 160
      Top = 8
      Width = 64
      Height = 13
      Caption = 'Lookup Field:'
    end
    object Label2: TLabel
      Left = 4
      Top = 24
      Width = 92
      Height = 13
      Anchors = [akLeft, akBottom]
      Caption = 'Pares selecionados'
    end
    object cbbLookupField: TComboBox
      Left = 228
      Top = 4
      Width = 129
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 0
    end
  end
end
