using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CallWebService
{
	public partial class Form1 : Form
	{
		//Variable to hold a reference to the proxy
		private WebServiceProxy.DynamicProxy _wsp = null;

		public Form1()
		{
			InitializeComponent();
			ConfigureGrids();
		}

		/// <summary>
		/// Instantiate the dynamic proxy object and get a list of services for the specified WSDL.
		/// </summary>
		/// <param name="sender">The source of the event</param>
		/// <param name="e">Event arguments</param>
		private void btnGetServices_Click(object sender, EventArgs e)
		{
			if (txtWsdlLoc.Text == String.Empty)
			{
				MessageBox.Show("You must provide a location for the WSDL for the web service");
				return;
			}

			//Clear out any results
			rtbResults.Text = String.Empty;

			_wsp = new WebServiceProxy.DynamicProxy(new Uri(txtWsdlLoc.Text));

			dgvMethods.DataSource = _wsp.GetWebMethods();
		}

		/// <summary>
		/// Retrieve the parameters for the selected method.
		/// </summary>
		/// <param name="sender">The source of the event</param>
		/// <param name="e">Event arguments</param>
		private void dgvMethods_SelectionChanged(object sender, EventArgs e)
		{
			String methodName = dgvMethods.CurrentRow.Cells["name"].Value.ToString();
			dgvParameters.DataSource = _wsp.GetParameters(methodName);
		}

		/// <summary>
		/// Get the parameter values and call the web service. Display the results that are returned.
		/// </summary>
		/// <param name="sender">The source of the event</param>
		/// <param name="e">Event arguments</param>
		private void btnInvoke_Click(object sender, EventArgs e)
		{
			Object[] parameters = GetParameters();
			rtbResults.Text = String.Empty;
			Object retVal = _wsp.Invoke(dgvMethods.CurrentRow.Cells["name"].Value.ToString(), parameters);
			if (retVal == null)
			{
				AddResult("Method succeeded but did not return any results");
				return;
			}
			if (retVal.GetType().IsArray)
			{
				Object[] retVals = (Object[])retVal;
				foreach (Object obj in retVals)
				{
					AddResult("\t" + obj.ToString());
				}
			}
			else AddResult("\t" + retVal.ToString());
		}

		/// <summary>
		/// Append the message to the end of the text in rtbResults.
		/// </summary>
		/// <param name="message">The string to append.</param>
		private void AddResult(string message)
		{
			rtbResults.Text += message;
		}

		/// <summary>
		/// Loop through the list of parameters in the DataGridView and create the 
		/// parameter object to send to the web service
		/// </summary>
		/// <returns>An array of objects representing the parameters of the web method.</returns>
		private object[] GetParameters()
		{
			ParameterInfo[] paramInfo = (ParameterInfo[])dgvParameters.DataSource;
			if (paramInfo.Length == 0) return null;
			Object[] parms = new Object[paramInfo.Length];
			for (int i = 0; i < dgvParameters.Rows.Count; i++)
			{
				parms[i] = ConvertParameterDataType(dgvParameters.Rows[i].Cells["ParamValue"].Value.ToString(), 
					paramInfo[i]);
			}
			return parms;
		}



		/// <summary>
		/// Configure the properties and columns for each grid.
		/// </summary>
		private void ConfigureGrids()
		{
			DataGridViewTextBoxColumn newColumn;
			//Configure the web methods grid
			dgvMethods.AutoGenerateColumns = false;
			newColumn = new DataGridViewTextBoxColumn();
			newColumn.Name = "returntype";
			newColumn.DataPropertyName = "returntype";
			newColumn.HeaderText = "Return Type";
			newColumn.ReadOnly = true;
			newColumn.MinimumWidth = 100;
			newColumn.Width = 300;
			dgvMethods.Columns.Insert(0, newColumn);
			newColumn = new DataGridViewTextBoxColumn();
			newColumn.Name = "name";
			newColumn.DataPropertyName = "name";
			newColumn.HeaderText = "Name";
			newColumn.ReadOnly = true;
			newColumn.MinimumWidth = 100;
			newColumn.Width = 399;
			dgvMethods.Columns.Insert(1, newColumn);

			//Configure the parameters grid
			dgvParameters.AutoGenerateColumns = false;
			newColumn = new DataGridViewTextBoxColumn();
			newColumn.Name = "name";
			newColumn.DataPropertyName = "name";
			newColumn.HeaderText = "Name";
			newColumn.ReadOnly = true;
			newColumn.MinimumWidth = 100;
			newColumn.Width = 150;
			dgvParameters.Columns.Insert(0, newColumn);
			newColumn = new DataGridViewTextBoxColumn();
			newColumn.Name = "parametertype";
			newColumn.DataPropertyName = "parametertype";
			newColumn.HeaderText = "Parameter Type";
			newColumn.ReadOnly = true;
			newColumn.MinimumWidth = 100;
			newColumn.Width = 150;
			dgvParameters.Columns.Insert(1, newColumn);
			newColumn = new DataGridViewTextBoxColumn();
			newColumn.Name = "ParamValue";
			newColumn.HeaderText = "Value";
			newColumn.ReadOnly = false;
			newColumn.MinimumWidth = 100;
			newColumn.Width = 398;
			dgvParameters.Columns.Insert(2, newColumn);
		}

		//''' <summary>
		//''' Convert the parameter data types into the correct type to call the web method
		//''' </summary>
		//''' <param name="paramValue">Value of the parameter</param>
		//''' <param name="pi">ParameterInfo object with information about the parameter</param>
		//''' <returns>The parameter cast to the correct type</returns>
		//''' <remarks>If the parameter type is an object or other complex type we can't 
		//''' cast to it so throw an error.</remarks>
		private Object ConvertParameterDataType(String paramValue, ParameterInfo pi)
		{
			if (paramValue == null) return null;
			if (pi.ParameterType.FullName == "System.String") return paramValue;
			if (pi.ParameterType.IsPrimitive)
			{
				return Convert.ChangeType(paramValue, pi.ParameterType);
			}
			if (pi.ParameterType.IsEnum)
			{
				Type enumType = _wsp.GetRemoteType(pi.ParameterType.Name);
				return System.Enum.Parse(enumType, paramValue, true);
			}
			throw new ArgumentException("Unable to convert parameter to a simple type.", pi.Name);
		}
	}
}