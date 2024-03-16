namespace CallWebService
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.rtbResults = new System.Windows.Forms.RichTextBox();
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.btnInvoke = new System.Windows.Forms.Button();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.dgvParameters = new System.Windows.Forms.DataGridView();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.dgvMethods = new System.Windows.Forms.DataGridView();
			this.txtWsdlLoc = new System.Windows.Forms.TextBox();
			this.btnGetServices = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox4.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
			this.GroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMethods)).BeginInit();
			this.SuspendLayout();
			// 
			// rtbResults
			// 
			this.rtbResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rtbResults.Location = new System.Drawing.Point(3, 13);
			this.rtbResults.Name = "rtbResults";
			this.rtbResults.Size = new System.Drawing.Size(678, 195);
			this.rtbResults.TabIndex = 1;
			this.rtbResults.Text = "";
			// 
			// GroupBox4
			// 
			this.GroupBox4.Controls.Add(this.rtbResults);
			this.GroupBox4.Controls.Add(this.btnInvoke);
			this.GroupBox4.Location = new System.Drawing.Point(15, 342);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(765, 214);
			this.GroupBox4.TabIndex = 12;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "Output";
			// 
			// btnInvoke
			// 
			this.btnInvoke.Location = new System.Drawing.Point(687, 13);
			this.btnInvoke.Name = "btnInvoke";
			this.btnInvoke.Size = new System.Drawing.Size(75, 23);
			this.btnInvoke.TabIndex = 0;
			this.btnInvoke.Text = "Invoke";
			this.btnInvoke.UseVisualStyleBackColor = true;
			this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
			// 
			// GroupBox3
			// 
			this.GroupBox3.Controls.Add(this.dgvParameters);
			this.GroupBox3.Location = new System.Drawing.Point(15, 187);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(765, 150);
			this.GroupBox3.TabIndex = 11;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Parameters";
			// 
			// dgvParameters
			// 
			this.dgvParameters.AllowUserToAddRows = false;
			this.dgvParameters.AllowUserToDeleteRows = false;
			this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvParameters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvParameters.Location = new System.Drawing.Point(3, 16);
			this.dgvParameters.Name = "dgvParameters";
			this.dgvParameters.Size = new System.Drawing.Size(759, 131);
			this.dgvParameters.TabIndex = 0;
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.Add(this.dgvMethods);
			this.GroupBox2.Location = new System.Drawing.Point(15, 37);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(765, 150);
			this.GroupBox2.TabIndex = 10;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Methods";
			// 
			// dgvMethods
			// 
			this.dgvMethods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMethods.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMethods.Location = new System.Drawing.Point(3, 16);
			this.dgvMethods.Name = "dgvMethods";
			this.dgvMethods.Size = new System.Drawing.Size(759, 131);
			this.dgvMethods.TabIndex = 0;
			this.dgvMethods.SelectionChanged += new System.EventHandler(this.dgvMethods_SelectionChanged);
			// 
			// txtWsdlLoc
			// 
			this.txtWsdlLoc.Location = new System.Drawing.Point(104, 11);
			this.txtWsdlLoc.Name = "txtWsdlLoc";
			this.txtWsdlLoc.Size = new System.Drawing.Size(569, 20);
			this.txtWsdlLoc.TabIndex = 8;
			// 
			// btnGetServices
			// 
			this.btnGetServices.Location = new System.Drawing.Point(696, 10);
			this.btnGetServices.Name = "btnGetServices";
			this.btnGetServices.Size = new System.Drawing.Size(84, 23);
			this.btnGetServices.TabIndex = 9;
			this.btnGetServices.Text = "Get Service";
			this.btnGetServices.UseVisualStyleBackColor = true;
			this.btnGetServices.Click += new System.EventHandler(this.btnGetServices_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(12, 15);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(86, 13);
			this.Label1.TabIndex = 7;
			this.Label1.Text = "WSDL Location:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 567);
			this.Controls.Add(this.GroupBox4);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.txtWsdlLoc);
			this.Controls.Add(this.btnGetServices);
			this.Controls.Add(this.Label1);
			this.Name = "Form1";
			this.Text = "Call Web Service";
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
			this.GroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMethods)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.RichTextBox rtbResults;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.Button btnInvoke;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.DataGridView dgvParameters;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.DataGridView dgvMethods;
		internal System.Windows.Forms.TextBox txtWsdlLoc;
		internal System.Windows.Forms.Button btnGetServices;
		internal System.Windows.Forms.Label Label1;
	}
}

