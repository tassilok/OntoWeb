using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OntologyClasses.BaseClasses;
using System.Web.Services.Protocols;

namespace OntWeb
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für OServiceObjectAtt
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceObjectAtt : System.Web.Services.WebService
    {

        private DbConnector dbConnector;

        public OServiceObjectAtt()
        {
            var OItem_Result = Globals.LoadConfig();
            if (OItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                dbConnector = new DbConnector();
            }
            else
            {
                SoapException se = new SoapException("Config-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsObjectAtt> ObjectAtts(bool onlyIds)
        {
            var oItem_Result = dbConnector.GetObjectAtt(ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectAttsId : dbConnector.ObjectAtts;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
        }

        [WebMethod]
        public List<clsObjectAtt> ObjectAttsByIdObject(bool onlyIds, string idObject)
        {
            var objectAttsSearch = new List<clsObjectAtt> { new clsObjectAtt { ID_Object = idObject } };
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectAttsId : dbConnector.ObjectAtts;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
        }

        [WebMethod]
        public List<clsObjectAtt> ObjectAttsByIdClass(bool onlyIds, string idClass)
        {
            var objectAttsSearch = new List<clsObjectAtt> { new clsObjectAtt { ID_Class = idClass } };
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectAttsId : dbConnector.ObjectAtts;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
        }

        [WebMethod]
        public List<clsObjectAtt> ObjectAttsByIdAttributeType(bool onlyIds, string idAttributeType)
        {
            var objectAttsSearch = new List<clsObjectAtt> { new clsObjectAtt { ID_AttributeType = idAttributeType } };
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectAttsId : dbConnector.ObjectAtts;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
        }

        [WebMethod]
        public List<clsObjectAtt> ObjectAttsByIdObjectAndIdAttributeType(bool onlyIds, string idObject, string idAttributeType)
        {
            var objectAttsSearch = new List<clsObjectAtt> { new clsObjectAtt { ID_Object = idObject, ID_AttributeType = idAttributeType } };
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectAttsId : dbConnector.ObjectAtts;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
        }

        [WebMethod]
        public List<clsObjectAtt> ObjectAttsByIdClassAndIdAttributeType(bool onlyIds, string idClass, string idAttributeType)
        {
            var objectAttsSearch = new List<clsObjectAtt> { new clsObjectAtt { ID_Class = idClass, ID_AttributeType = idAttributeType } };
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectAttsId : dbConnector.ObjectAtts;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
            
        }

        [WebMethod]
        public long CountObjectAttsByIdClassAndIdAttributeType(string idClass, string idAttributeType)
        {
            var objectAttsSearch = new List<clsObjectAtt> { new clsObjectAtt { ID_Class = idClass, ID_AttributeType = idAttributeType } };
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch,doCount:true);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return oItem_Result.Count ?? 0;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
        }

        [WebMethod]
        public List<clsObjectAtt> ObjectAttsByIdObjectAndIdDataType(bool onlyIds, string idObject, string idDataType)
        {
            var objectAttsSearch = new List<clsObjectAtt> { new clsObjectAtt { ID_Object = idObject, ID_DataType = idDataType } };
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectAttsId : dbConnector.ObjectAtts;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
        }

        [WebMethod]
        public List<clsObjectAtt> ObjectAttsByIdClassAndIdDataType(bool onlyIds, string idClass, string idDataType)
        {
            var objectAttsSearch = new List<clsObjectAtt> { new clsObjectAtt { ID_Class = idClass, ID_DataType = idDataType } };
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectAttsId : dbConnector.ObjectAtts;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;

            }
        }
    }
    
}
