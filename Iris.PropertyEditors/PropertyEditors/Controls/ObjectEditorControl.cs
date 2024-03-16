using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Databridge.Interfaces.BaseEditors.Controls;

namespace Iris.PropertyEditors.Controls
{
  public partial class ObjectEditorControl : BaseControl
  {
    public ObjectEditorControl()
    {
      InitializeComponent();
      dtpDateTime.Value = DateTime.Today;
      nudNumber.Maximum = int.MaxValue;      
      SetupEditor();
    }

    private void SetupEditor()
    {
      ClearEditors();
      switch (cbbType.Text)
      {
        case "Texto": SetupTexto();
          break;
        case "Data/Hora": SetupDataHora();
          break;
        case "Data": SetupData();
          break;
        case "Hora": SetupHora();
          break;
        case "Número Inteiro": SetupInt();
          break;
        case "Número Fracionário": SetupDecimal();
          break;
        case "Sim/Não": SetupBool();
          break;
        default:
          cbbType.Text = "Texto";
          SetupEditor();
          break;
      }
    }

    private void ClearEditors()
    {
      dtpDateTime.Visible = false;
      nudNumber.Visible = false;
      tbText.Visible = false;
      cbxBoolean.Visible = false;
      cbxBoolean.Visible = false;
    }

    private void SetupBool()
    {
      cbxBoolean.Visible = true;
    }

    private void SetupControl(Control control)
    {
      control.Size = cbbType.Size;
      control.Location = cbbType.Location;
      control.Visible = true;
      control.TabIndex = 0;
      control.Focus();
    }

    private void SetupDecimal()
    {
      nudNumber.DecimalPlaces = 4;
      SetupControl(nudNumber);
      nudNumber.Visible = true;
    }

    private void SetupInt()
    {
      nudNumber.DecimalPlaces = 0;
      SetupControl(nudNumber);
    }

    private void SetupHora()
    {
      dtpDateTime.Format = DateTimePickerFormat.Custom;
      dtpDateTime.CustomFormat = "hh:mm:ss";
      SetupControl(dtpDateTime);
    }

    private void SetupData()
    {
      dtpDateTime.Format = DateTimePickerFormat.Short;
      SetupControl(dtpDateTime);
    }

    private void SetupDataHora()
    {
      dtpDateTime.Format = DateTimePickerFormat.Custom;
      dtpDateTime.CustomFormat = "dd/MM/yyyy - hh:mm:ss";
      SetupControl(dtpDateTime);
    }

    private void SetupTexto()
    {
      SetupControl(tbText);
    }

    public object Value
    {
      get
      {
        switch (cbbType.Text)
        {
          case "Texto":
            return tbText.Text;
          case "Data/Hora":
          case "Data": 
          case "Hora": 
            return dtpDateTime.Value;
          case "Número Inteiro": SetupInt();
            return (int)nudNumber.Value;
          case "Número Fracionário": SetupDecimal();
            return nudNumber.Value;
          case "Sim/Não": SetupBool();
            return cbxBoolean.Checked;
          default:
            return null;
        }
      }
      set
      {

        string type = "";

        if(value != null)
          type = value.GetType().ToString();

        switch (type)
        {
          case "System.Int16":
            cbbType.Text = "Número Inteiro";
            nudNumber.Value = (Int16)value;
            break;
          case "System.Int32":
            cbbType.Text = "Número Inteiro";
            nudNumber.Value = (Int32)value;
            break;
          case "System.Int64":
            cbbType.Text = "Número Inteiro";
            nudNumber.Value = (Int64)value;
            break;
          case "System.UInt16":
            cbbType.Text = "Número Inteiro";
            nudNumber.Value = (UInt16)value;
            break;
          case "System.UInt32":
            cbbType.Text = "Número Inteiro";
            nudNumber.Value = (UInt32)value;
            break;
          case "System.UInt64":
            cbbType.Text = "Número Inteiro";
            nudNumber.Value = (UInt64)value;
            break;
          case "System.Byte":
            cbbType.Text = "Número Inteiro";
            nudNumber.Value = (Byte)value;
            break;
          case "System.SByte":
            cbbType.Text = "Número Inteiro";
            nudNumber.Value = (SByte)value;
            break;
          case "System.Decimal":
          case "System.Double":
          case "System.Float":
          case "System.Single":
            cbbType.Text = "Número Fracionário";
            nudNumber.Value = (Decimal)value;
            break;
          case "System.DateTime":
            cbbType.Text = "Data/Hora"; 
            dtpDateTime.Value = (DateTime)value;
            break;
          case "System.Boolean":
            cbbType.Text = "Sim/Não";
            cbxBoolean.Checked = (Boolean)value;
            break;
          default:
            cbbType.Text = "Texto";
            tbText.Text = Convert.ToString(value);
            break;
        }
        SetupEditor();
      }
    }

    private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetupEditor();
    }

    private void ValueControlsValidated(object sender, EventArgs e)
    {
      OnPropertyChanged();
    }



    internal void SetFocus()
    {
      foreach (Control control in grpValor.Controls)
      {
        if (control.Visible)
        {
          control.Focus();
          break;
        }
      }
    }
  }
}

