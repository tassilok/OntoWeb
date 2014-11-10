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
    /// Zusammenfassungsbeschreibung für OServiceObjectRel
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceObjectRel : System.Web.Services.WebService
    {
        private DbConnector dbConnector;

        public OServiceObjectRel()
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
        public List<clsObjectRel> ObjectRels(bool onlyIds)
        {
            var oItem_Result = dbConnector.GetObjectRel(ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdObject(string IdObject, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Object = IdObject } };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdOther(string IdOther, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Other = IdOther } };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdObjectAndIdRelationType(string IdObject, string IdRelationType, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Object = IdObject,
                                                                               ID_RelationType = IdRelationType} };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdObjectAndIdRelationTypeAndIdOther(string IdObject, string IdRelationType, string IdOther, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Object = IdObject,
                                                                               ID_RelationType = IdRelationType,
                                                                               ID_Other = IdOther} };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdRelationTypeAndIdOther(string IdRelationType, string IdOther, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_RelationType = IdRelationType,
                                                                               ID_Other = IdOther} };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdParentObject(string IdParentObject, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = IdParentObject } };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdParentOther(string IdParentOther, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Other = IdParentOther } };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdParentObjectAndIdRelationType(string IdParentObject, string IdRelationType, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = IdParentObject,
                                                                               ID_RelationType = IdRelationType} };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdParentObjectAndIdRelationTypeAndIdParentOther(string IdParentObject, string IdRelationType, string IdParentOther, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = IdParentObject,
                                                                               ID_RelationType = IdRelationType,
                                                                               ID_Parent_Other = IdParentOther} };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdRelationTypeAndIdParentOther(string IdRelationType, string IdParentOther, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_RelationType = IdRelationType,
                                                                               ID_Parent_Other = IdParentOther} };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdObjectAndIdRelationTypeAndIdParentOther(string IdObject, string IdRelationType, string IdParentOther, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Object = IdObject,
                                                                               ID_RelationType = IdRelationType,
                                                                               ID_Other = IdParentOther} };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

        [WebMethod]
        public List<clsObjectRel> ObjectRelsByIdParentObjectAndIdRelationTypeAndIdOther(string IdParentObject, string IdRelationType, string IdOther, bool onlyIds)
        {
            var objectRelsSearch = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = IdParentObject,
                                                                               ID_RelationType = IdRelationType,
                                                                               ID_Other = IdOther} };

            var oItem_Result = dbConnector.GetObjectRel(objectRelsSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ObjectRelsId : dbConnector.ObjectRels;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }

        }

    }
}
