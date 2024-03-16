using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
      propertyGrid1.SelectedObject = gaugeContainer1;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Dundas.Gauges.Wizard.DundasGaugeWizardForm form = new Dundas.Gauges.Wizard.DundasGaugeWizardForm();
      form.SetGaugeControl(gaugeContainer1, true);
      form.Show();      
    }

    private void button2_Click(object sender, EventArgs e)
    {
      
    }
  }
}