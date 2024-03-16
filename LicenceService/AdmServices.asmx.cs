using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Databridge.Engine.Criptography;

namespace LicenceService
{
  /// <summary>
  /// Summary description for AdmServices
  /// </summary>
  [WebService(Namespace = "http://www.databridge.com/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class AdmServices : System.Web.Services.WebService
  {
    private ModelTableAdapters.ClientsTableAdapter clientsAdapter;
    private ModelTableAdapters.AvailableLicencesTableAdapter availableLicencesAdapter;
    private ModelTableAdapters.ClientAuditLogTableAdapter clientAuditLogAdapter;
    private ModelTableAdapters.ProductsTableAdapter productsAdapter;
    private Model model;
    private ModelTableAdapters.AdmUsersTableAdapter admUsersAdapter;

    [WebMethod]
    public string HelloWorld()
    {
      return "Hello World";
    }

    private void InitializeComponent()
    {
      this.admUsersAdapter = new LicenceService.ModelTableAdapters.AdmUsersTableAdapter();
      this.clientsAdapter = new LicenceService.ModelTableAdapters.ClientsTableAdapter();
      this.availableLicencesAdapter = new LicenceService.ModelTableAdapters.AvailableLicencesTableAdapter();
      this.clientAuditLogAdapter = new LicenceService.ModelTableAdapters.ClientAuditLogTableAdapter();
      this.productsAdapter = new LicenceService.ModelTableAdapters.ProductsTableAdapter();
      this.model = new LicenceService.Model();
      ((System.ComponentModel.ISupportInitialize)(this.model)).BeginInit();
      // 
      // admUsersAdapter
      // 
      this.admUsersAdapter.ClearBeforeFill = true;
      // 
      // clientsAdapter
      // 
      this.clientsAdapter.ClearBeforeFill = true;
      // 
      // availableLicencesAdapter
      // 
      this.availableLicencesAdapter.ClearBeforeFill = true;
      // 
      // clientAuditLogAdapter
      // 
      this.clientAuditLogAdapter.ClearBeforeFill = true;
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

    internal bool ValidateAdmUser(string usrName, string pwd, string token)
    {
      int? usrCount = admUsersAdapter.Count();
      if ((usrCount.HasValue) && (usrCount > 0))
      {

      }
      else
      {
        Cube cube = Cube.GetDefaultLongCube();
        bool validToken = Validator.ValidateToken(token, cube);
        bool validPwd = cube.UnRComp(pwd, cube.ResizeKey(token, 1)[0]) == "Sat0r";
        bool validName = usrName == "master";

        return validName && validPwd && validToken;
      }
      return false;
    }
  }
}
