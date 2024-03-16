using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;
using Iris.Runtime.Core.Networking;
using Iris.DynamicsServices.WebReference;
using System.Net;

namespace Iris.DynamicsServices
{
  public static class UpdaterHelper
  {
    private static CrmService service;
    private static CrmService GetService(NetworkCredential credentials, string wsdlUrl, string org)
    {
      if (service == null)
      {
        service = new CrmService();
        CrmAuthenticationToken token = new CrmAuthenticationToken();
        token.AuthenticationType = 0;
        token.OrganizationName = org;
        service.Url = wsdlUrl;
        service.CrmAuthenticationTokenValue = token;

        service.Credentials = credentials;
        service.PreAuthenticate = true;
      }

     
      return service;
    }

    internal static string InsertRow(NetworkCredential credentials, string wsdlUrl, string org, DataRow row,
   Dictionary<string, CRMPropMapper> propMapper, string entityName)
    {
      DynamicEntity entity = RowToEntity(row, propMapper, entityName, OperationType.Insert);
      CrmService srv = GetService(credentials, wsdlUrl, org);
      Guid id = srv.Create(entity);
      return Convert.ToString(id);
    }

    internal static void UpdateRow(NetworkCredential credentials, string wsdlUrl, string org, DataRow row,
  Dictionary<string, CRMPropMapper> propMapper, string entityName)
    {
      DynamicEntity entity = RowToEntity(row, propMapper, entityName, OperationType.Update);
      TargetUpdateDynamic target = new TargetUpdateDynamic();
      target.Entity = entity;
      UpdateRequest request = new UpdateRequest();
      request.Target = target;

      CrmService srv = GetService(credentials, wsdlUrl, org);

      srv.Execute(request);
    }

    internal static void InactivateRow(NetworkCredential credentials, string wsdlUrl, string org, DataRow row,
   Dictionary<string, CRMPropMapper> propMapper, string entityName)
    {
      string idName = propMapper.Where(x => x.Value.Id).Select(x => x.Key).FirstOrDefault().ToLower();
      Guid guid = (Guid)row[idName, DataRowVersion.Original];
      CrmService srv = GetService(credentials, wsdlUrl, org);
      SetStateDynamicEntityRequest stateReq = new SetStateDynamicEntityRequest();
      stateReq.Entity = new Moniker();

      stateReq.Entity.Id = guid;
      stateReq.Entity.Name = entityName;

      //Set to Inactive
      stateReq.State = "inactive";
      stateReq.Status = -1;

      srv.Execute(stateReq);
    }

    private static DynamicEntity RowToEntity(DataRow row,
      Dictionary<string, CRMPropMapper> propMapper, string entityName, OperationType operationType)
    {
      DynamicEntity entidade = new DynamicEntity();
      entidade.Name = entityName;
      List<Property> props = new List<Property>();

      foreach (DataColumn column in row.Table.Columns)
      {
        object value = row[column];
        //Não cria propriedades para nulos e valores inalterados
        if (propMapper.ContainsKey(column.ColumnName) && (!Convert.IsDBNull(row[column])))
        {
          Property prop = CreateProperty(propMapper[column.ColumnName].DataType, value,
            column.ColumnName, propMapper[column.ColumnName].LookupEntity);
          if (prop != null)
          {
            props.Add(prop);
          }
        }
      }


      if (operationType == OperationType.Insert) //inserindo novo registro
      {
        KeyProperty property = new KeyProperty();
        property.Name = propMapper.Where(x => x.Value.Id).Select(x => x.Key).FirstOrDefault().ToLower();
        property.Value = new Key();
        property.Value.Value = Guid.NewGuid();
        props.Add(property);
      }

      entidade.Properties = props.ToArray();

      return entidade;
    }

    private static Property CreateProperty(PropertyType propertyType, object value,
      string propertyName, string entityName)
    {
      propertyName = propertyName.ToLower();

      EntityName lkpEntity = EntityName.none;
      if (!string.IsNullOrEmpty(entityName))
        lkpEntity = (EntityName)Enum.Parse(typeof(EntityName), entityName);

      if ((!Convert.IsDBNull(value)) && (value != null) && (!string.IsNullOrEmpty(Convert.ToString(value).Trim())))
      {
        switch (propertyType)
        {
          case PropertyType.Text:
            {
              StringProperty property = new StringProperty();
              property.Name = propertyName;
              property.Value = Convert.ToString(value);
              return property;
            }
          case PropertyType.Integer:
            {
              CrmNumberProperty property = new CrmNumberProperty();
              property.Name = propertyName;
              property.Value = new CrmNumber();
              property.Value.Value = Convert.ToInt32(value);
              return property;
            }
          case PropertyType.DateTime:
            {
              CrmDateTimeProperty property = new CrmDateTimeProperty();
              property.Name = propertyName;
              property.Value = new CrmDateTime();
              DateTime dt = Convert.ToDateTime(value);
              if (dt < new DateTime(1900, 1, 1))
                dt = new DateTime(1900, 1, 1);
              property.Value.Value = Convert.ToString(string.Format("{0}/{1}/{2}", dt.Month, dt.Day, dt.Year));
              return property;
            }
          case PropertyType.Decimal:
            {
              CrmDecimalProperty property = new CrmDecimalProperty();
              property.Name = propertyName;
              property.Value = new CrmDecimal();
              property.Value.Value = Convert.ToDecimal(value);
              return property;
            }
          case PropertyType.Money:
            {
              CrmMoneyProperty property = new CrmMoneyProperty();
              property.Name = propertyName;
              property.Value = new CrmMoney();
              property.Value.Value = Convert.ToDecimal(value);
              return property;
            }
          case PropertyType.PickList:
            {
              PicklistProperty property = new PicklistProperty();
              property.Name = propertyName;
              property.Value = new Picklist();
              property.Value.Value = Convert.ToInt32(value);
              return property;
            }
          case PropertyType.Float:
            {
              CrmFloatProperty property = new CrmFloatProperty();
              property.Name = propertyName;
              property.Value = new CrmFloat();
              property.Value.Value = Convert.ToSingle(value);
              return property;
            }
          case PropertyType.Bit:
            {
              CrmBooleanProperty property = new CrmBooleanProperty();
              property.Name = propertyName;
              property.Value = new CrmBoolean();
              property.Value.Value = Convert.ToBoolean(value);
              return property;
            }
          case PropertyType.Lookup:
            {
              LookupProperty property = new LookupProperty();
              property.Name = propertyName;
              property.Value = new Lookup();
              property.Value.Value = (Guid)value;
              return property;
            }
          case PropertyType.Customer:
            {
              CustomerProperty property = new CustomerProperty();
              property.Name = propertyName;
              property.Value = new Customer();
              property.Value.type = entityName;
              property.Value.Value = (Guid)value;
              return property;
            }
          case PropertyType.Id:
            {
              KeyProperty property = new KeyProperty();
              property.Name = propertyName;
              property.Value = new Key();
              property.Value.Value = (Guid)value;
              return property;
            }
        }
      }
      return null;
    }



    internal static void ResetService()
    {
      service = null;
    }
  }
}
