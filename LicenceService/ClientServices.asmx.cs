using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace LicenceService
{
  /// <summary>
  /// Summary description for ClientServices
  /// </summary>
  [WebService(Namespace = "http://www.databridge.com/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class ClientServices : System.Web.Services.WebService
  {
    private ModelTableAdapters.RegisteredPluginsTableAdapter registeredPluginsAdapter;
    private ModelTableAdapters.RegisteredServersTableAdapter registeredServersAdapter;
    private ModelTableAdapters.AdmAuditLogTableAdapter admAuditLogAdapter;
    private ModelTableAdapters.AdmUsersTableAdapter admUsersAdapter;
    private ModelTableAdapters.AvailableLicencesTableAdapter availableLicencesAdapter;
    private ModelTableAdapters.ProductsTableAdapter productsAdapter;
    private Model model;
    private ModelTableAdapters.ClientsTableAdapter clientsAdapter;

    [WebMethod]
    public string TestDB()
    {
      InitializeComponent();
      DataTable tab = clientsAdapter.GetData();
      return tab.TableName;
    }

    private void InitializeComponent()
    {
      this.clientsAdapter = new LicenceService.ModelTableAdapters.ClientsTableAdapter();
      this.registeredPluginsAdapter = new LicenceService.ModelTableAdapters.RegisteredPluginsTableAdapter();
      this.registeredServersAdapter = new LicenceService.ModelTableAdapters.RegisteredServersTableAdapter();
      this.admAuditLogAdapter = new LicenceService.ModelTableAdapters.AdmAuditLogTableAdapter();
      this.admUsersAdapter = new LicenceService.ModelTableAdapters.AdmUsersTableAdapter();
      this.availableLicencesAdapter = new LicenceService.ModelTableAdapters.AvailableLicencesTableAdapter();
      this.productsAdapter = new LicenceService.ModelTableAdapters.ProductsTableAdapter();
      this.model = new LicenceService.Model();
      ((System.ComponentModel.ISupportInitialize)(this.model)).BeginInit();
      // 
      // clientsAdapter
      // 
      this.clientsAdapter.ClearBeforeFill = true;
      // 
      // registeredPluginsAdapter
      // 
      this.registeredPluginsAdapter.ClearBeforeFill = true;
      // 
      // registeredServersAdapter
      // 
      this.registeredServersAdapter.ClearBeforeFill = true;
      // 
      // admAuditLogAdapter
      // 
      this.admAuditLogAdapter.ClearBeforeFill = true;
      // 
      // admUsersAdapter
      // 
      this.admUsersAdapter.ClearBeforeFill = true;
      // 
      // availableLicencesAdapter
      // 
      this.availableLicencesAdapter.ClearBeforeFill = true;
      // 
      // productsAdapter
      // 
      this.productsAdapter.ClearBeforeFill = true;
      // 
      // model
      // 
      this.model.DataSetName = "Model";
      this.model.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      ((System.ComponentModel.ISupportInitialize)(this.model)).EndInit();

    }
  }
}
