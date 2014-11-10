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
    /// Zusammenfassungsbeschreibung für OServiceClassAtt
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceClassAtt : System.Web.Services.WebService
    {

        private DbConnector dbConnector;

        public OServiceClassAtt()
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
        public List<clsClassAtt> ClassAttributes(bool onlyIds)
        {

            var oItem_Result = dbConnector.GetClassAttributes(ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassAttributesId : dbConnector.ClassAttributes;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsClassAtt> ClassAttributesByClassGuid(string guidClass, bool onlyIds)
        {

            var classesSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID = guidClass } };
            var oItem_Result = dbConnector.GetClassAttributes(classes: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassAttributesId : dbConnector.ClassAttributes;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsClassAtt> ClassAttributesByAttributeTypeGuid(string guidAttributeType, bool onlyIds)
        {

            var attributeTypeSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID = guidAttributeType } };
            var oItem_Result = dbConnector.GetClassAttributes(attributeTypes: attributeTypeSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassAttributesId : dbConnector.ClassAttributes;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsClassAtt> ClassAttributesByClassGuid_ttributeTypeGuid(string guidAttributeType, string guidClass, bool onlyIds)
        {

            var attributeTypeSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID = guidAttributeType } };
            var classesSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID = guidClass } };
            var oItem_Result = dbConnector.GetClassAttributes(classesSearch, attributeTypeSearch, onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassAttributesId : dbConnector.ClassAttributes;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }
    }
}
