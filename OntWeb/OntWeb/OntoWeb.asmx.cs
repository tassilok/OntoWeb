using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using ElasticSearchNestConnector;

namespace OntWeb
{

    /// <summary>
    /// Summary description for OntoWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OntoWeb : System.Web.Services.WebService
    {

        private clsDBSelector dbSelector;
        private clsDBUpdater dbUpdater;
        private clsDBDeletor dbDeletor;

        private string session;

        clsTypes types = new clsTypes();

        public OntoWeb()
        {
            var OItem_Result = Globals.LoadConfig();
            if (OItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {

                dbSelector = new clsDBSelector(Globals.ElServer, Globals.ElPort, Globals.ElIndex, Globals.RepIndex, Globals.ElSearchRange, Globals.NewGuid);
                dbUpdater = new clsDBUpdater(dbSelector);
                dbDeletor = new clsDBDeletor(dbSelector);
            }
            else
            {
                SoapException se = new SoapException("Config-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        

        [WebMethod]
        public WebServiceResult ObjectAtts(List<clsObjectAtt> oList_ObjAttributes, bool onlyIds)
        {
            
            try
            {
                var oList = dbSelector.get_Data_ObjectAtt(oList_ObjAttributes, onlyIds);
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone(), ObjectAttributes = oList };
                return result;
            }catch (Exception ex)
            {

                var oResult = Globals.LogStates.LogState_Error.Clone();
                oResult.Additional1 = ex.Message;
                var result = new WebServiceResult { Result = oResult};
                return result;
            }
            

        }

        [WebMethod]
        public WebServiceResult ClassAttributes(List<clsOntologyItem> oList_Classes, List<clsOntologyItem> oList_AttributeTypes, bool onlyIds)
        {

            try
            {
                var oList = dbSelector.get_Data_ClassAtt(oList_Classes, oList_AttributeTypes, onlyIds);
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone(), ClassAttributes = oList };
                return result;
            }
            catch (Exception ex)
            {
                var oResult = Globals.LogStates.LogState_Error.Clone();
                oResult.Additional1 = ex.Message;
                var result = new WebServiceResult { Result = oResult };
                return result;
            }
            
            

        }

        [WebMethod]
        public WebServiceResult ClassRelations(List<clsClassRel> oList_ClassRel, bool onlyIds, bool queryOr = true)
        {
            try
            {
                var oList = dbSelector.get_Data_ClassRel(oList_ClassRel, onlyIds, queryOr);
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone() };
                return result;
            }
            catch (Exception ex)
            {
                var oResult = Globals.LogStates.LogState_Error.Clone();
                oResult.Additional1 = ex.Message;
                var result = new WebServiceResult { Result = oResult };
                return result;
            }
            
        }

        [WebMethod]
        public string Type_Object()
        {
            return types.ObjectType;
        }

        [WebMethod]
        public string Type_Class()
        {
            return types.ClassType;


        }

        [WebMethod]
        public string Type_AttributeType()
        {
            return types.AttributeType;
        }

        [WebMethod]
        public string Type_RelationType()
        {
            return types.RelationType;
        }

        [WebMethod]
        public clsLogStates OLogStates()
        {
            return new clsLogStates();
        }

        [WebMethod]
        public clsMappingRules OMappingRules()
        {
            return new clsMappingRules();
        }

        [WebMethod]
        public clsOntologyRelationRules ORelationRules()
        {
            return new clsOntologyRelationRules();
        }

        [WebMethod]
        public clsVariables OVariables()
        {
            return new clsVariables();
        }

        [WebMethod]
        public clsDirections ODirections()
        {
            return new clsDirections();
        }

        [WebMethod]
        public clsFields OFields()
        {
            return new clsFields();
        }

        [WebMethod]
        public List<Config> Config()
        {

            return Globals.Config;
        }

        [WebMethod]
        public string RegExGuid()
        {
            return Globals.RegEx_Guid;
        }

        [WebMethod]
        public WebServiceResult ObjectRels(List<clsObjectRel> oLIst_ObjRel, bool onlyIds)
        {
            try
            {
                var oList = dbSelector.get_Data_ObjectRel(oLIst_ObjRel,onlyIds);
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone(), ObjectRelations = oList };
                return result;
            }
            catch (Exception ex)
            {
                var oResult = Globals.LogStates.LogState_Error.Clone();
                oResult.Additional1 = ex.Message;
                var result = new WebServiceResult { Result = oResult };
                return result;
            }
        }

        [WebMethod]
        public WebServiceResult Objects(List<clsOntologyItem> oList_Objects)
        {
            try
            {
                var oList = dbSelector.get_Data_Objects(oList_Objects);
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone(), OntologyItems = oList };
                return result;
            }
            catch (Exception ex)
            {
                var oResult = Globals.LogStates.LogState_Error.Clone();
                oResult.Additional1 = ex.Message;
                var result = new WebServiceResult { Result = oResult };
                return result;
            }

            
        }

        [WebMethod]
        public WebServiceResult Classes(List<clsOntologyItem> oList_Classes)
        {
            try
            {
                var oList = dbSelector.get_Data_Classes(oList_Classes);
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone() };
                return result;
            }
            catch (Exception ex)
            {
                var oResult = Globals.LogStates.LogState_Error.Clone();
                oResult.Additional1 = ex.Message;
                var result = new WebServiceResult { Result = oResult };
                return result;
            }

        }

        [WebMethod]
        public WebServiceResult RelationTypes(List<clsOntologyItem> oLIst_RelTypes)
        {
            try
            {
                var oList = dbSelector.get_Data_RelationTypes(oLIst_RelTypes);
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone(), OntologyItems = oList };
                return result;
            }
            catch (Exception ex)
            {
                var oResult = Globals.LogStates.LogState_Error.Clone();
                oResult.Additional1 = ex.Message;
                var result = new WebServiceResult { Result = oResult };
                return result;
            }

        }

        [WebMethod]
        public WebServiceResult AttributeTypes(List<clsOntologyItem> oList_AttType)
        {
            try
            {
                var oList = dbSelector.get_Data_AttributeType(oList_AttType);
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone(), OntologyItems = oList };
                return result;
            }
            catch (Exception ex)
            {
                var oResult = Globals.LogStates.LogState_Error.Clone();
                oResult.Additional1 = ex.Message;
                var result = new WebServiceResult { Result = oResult };
                return result;
            }
            
        }

        [WebMethod]
        public clsOntologyItem GetOItem(string idItem, string type)
        {
            if (type == Globals.OTypes.ClassType)
            {
                var item = Classes(new List<clsOntologyItem> { new clsOntologyItem { GUID =  idItem } });
                return item.Result.GUID == Globals.LogStates.LogState_Success.GUID ? item.OntologyItems.FirstOrDefault() : item.Result;
            }
            else if (type == Globals.OTypes.ObjectType)
            {
                var item = Objects(new List<clsOntologyItem> { new clsOntologyItem { GUID = idItem } });
                return item.Result.GUID == Globals.LogStates.LogState_Success.GUID ? item.OntologyItems.FirstOrDefault() : item.Result;
            }
            else if (type == Globals.OTypes.AttributeType)
            {
                var item = AttributeTypes(new List<clsOntologyItem> { new clsOntologyItem { GUID = idItem } });
                return item.Result.GUID == Globals.LogStates.LogState_Success.GUID ? item.OntologyItems.FirstOrDefault() : item.Result;
            }
            else if (type == Globals.OTypes.RelationType)
            {
                var item = RelationTypes(new List<clsOntologyItem> { new clsOntologyItem { GUID = idItem } });
                return item.Result.GUID == Globals.LogStates.LogState_Success.GUID ? item.OntologyItems.FirstOrDefault() : item.Result;
            }
            else
            {
                return Globals.LogStates.LogState_Error.Clone();
            }
        }

        [WebMethod]
        public clsOntologyItem GetClassPath(string idClass)
        {
            return getClassPath(idClass, "");
        }
        
        private clsOntologyItem getClassPath(string idClass, string path)
        {
            var searchClass = new List<clsOntologyItem> { new clsOntologyItem { GUID = idClass } };

            

            try
            {
                var result = Classes(new List<clsOntologyItem> { new clsOntologyItem { GUID = idClass } });

                if (result.Result.GUID != Globals.LogStates.LogState_Success.GUID && result.OntologyItems.Any())
                {
                    
                    if (string.IsNullOrEmpty(path))
                    {
                        path = result.OntologyItems.First().Name;
                    }
                    else
                    {
                        path = result.OntologyItems.First().Name + "\\" + path;
                    }

                    if (!string.IsNullOrEmpty(result.OntologyItems.First().GUID_Parent))
                    {
                        return getClassPath(result.OntologyItems.First().GUID_Parent, path);
                    }
                    else
                    {
                        result.Result.Additional1 = path;
                        return result.Result;
                    }

                    
                }
                else
                {
                    return result.Result;
                }
            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }

            
        }

        [WebMethod]
        public clsOntologyItem DeleteIndex(string strIndex)
        {
            try
            {
                var indexResponse = dbSelector.ElConnector.DeleteIndex(d => dbSelector.GetDeleteIndexDescriptor().Index(strIndex));
                if (indexResponse.IsValid)
                {
                    return Globals.LogStates.LogState_Success.Clone();
                }
                else
                {
                    return Globals.LogStates.LogState_Error.Clone();
                }
            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
            

            
        }

        [WebMethod]
        public WebServiceResult IndexList(string server, int port)
        {
            try
            {
                var result = new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone(), IndexList = dbSelector.IndexList(server, port) };
                return result;

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return new WebServiceResult { Result = Globals.LogStates.LogState_Error.Clone() };
                
            }
            
        }

        [WebMethod]
        public clsOntologyItem SaveDataTypes(List<clsOntologyItem> oList_DataTypes)
        {
            try
            {
                return dbUpdater.save_DataTypes(oList_DataTypes);
                
            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem SaveAttributeTypes(List<clsOntologyItem> oList_AttributeTypes)
        {
            try
            {
                var result = Globals.LogStates.LogState_Success.Clone();
                foreach (var oItem_AttributeType in oList_AttributeTypes)
                {
                    result = dbUpdater.save_AttributeType(oItem_AttributeType);
                    if (result.GUID == Globals.LogStates.LogState_Error.GUID)
                    {
                        break;
                    }

                }

                return result;
            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem SaveClasses(List<clsOntologyItem> oList_Classes)
        {
            try
            {
                var result = Globals.LogStates.LogState_Success.Clone();
                foreach (var oItem_Class in oList_Classes)
	            {
                    result = dbUpdater.save_Class(oItem_Class);    
	            }

                return result;

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem SaveClassAtts(List<clsClassAtt> oList_ClassAtts)
        {
            try
            {

                return dbUpdater.save_ClassAtt(oList_ClassAtts);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem SaveClassRels(List<clsClassRel> oList_ClassRels)
        {
            try
            {

                return dbUpdater.save_ClassRel(oList_ClassRels);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public WebServiceResult SaveObjectAttributes(List<clsObjectAtt> oList_ObjAtts)
        {
            try
            {

                return new WebServiceResult { Result = Globals.LogStates.LogState_Success.Clone(), ObjectAttributes = dbUpdater.save_ObjectAtt(oList_ObjAtts) };

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return new WebServiceResult { Result = result };
            }
        }

        [WebMethod]
        public clsOntologyItem SaveObjects(List<clsOntologyItem> oList_Objects)
        {
            try
            {

                return dbUpdater.save_Objects(oList_Objects);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem SaveObjectRels(List<clsObjectRel> oList_ObjRels)
        {
            try
            {

                return dbUpdater.save_ObjectRel(oList_ObjRels);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem SaveRelationTypes(List<clsOntologyItem> oList_RelationTypes)
        {
            try
            {
                var result = Globals.LogStates.LogState_Success.Clone();
                foreach (var oItem_RelationType in oList_RelationTypes)
                {
                    result = dbUpdater.save_RelationType(oItem_RelationType);
                    if (result.GUID == Globals.LogStates.LogState_Error.GUID)
                    {
                        break;
                    }

                }

                return result;
            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem DeleteAttributeTypes(List<clsOntologyItem> oList_AttributeTypes)
        {
            try
            {
                return dbDeletor.del_AttributeType(oList_AttributeTypes);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
            
        }

        [WebMethod]
        public clsOntologyItem DeleteClasses(List<clsOntologyItem> oList_Classes)
        {
            try
            {
                return dbDeletor.del_Class(oList_Classes);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }

        }

        [WebMethod]
        public clsOntologyItem DeleteClassAttType(clsOntologyItem oItem_Class, clsOntologyItem oItem_AttributeType)
        {
            try
            {
                return dbDeletor.del_ClassAttType(oItem_Class, oItem_AttributeType);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem DeleteClassRel(List<clsClassRel> oList_ClassRel)
        {
            try
            {
                return dbDeletor.del_ClassRel(oList_ClassRel);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem DeleteDataTypes(List<clsOntologyItem> oList_DataTypes)
        {
            try
            {
                return dbDeletor.del_DataType(oList_DataTypes);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem DeleteObjectAttributes(List<clsObjectAtt> oList_ObjectAttributes)
        {
            try
            {
                return dbDeletor.del_ObjectAtt(oList_ObjectAttributes);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem DeleteObjectRelations(List<clsObjectRel> oList_ObjectRelations)
        {
            try
            {
                return dbDeletor.del_ObjectRel(oList_ObjectRelations);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem DeleteObjects(List<clsOntologyItem> oList_Objects)
        {
            try
            {
                return dbDeletor.del_Objects(oList_Objects);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }

        [WebMethod]
        public clsOntologyItem DeleteRelationTypes(List<clsOntologyItem> oList_RelationTypes)
        {
            try
            {
                return dbDeletor.del_RelationType(oList_RelationTypes);

            }
            catch (Exception ex)
            {
                var result = Globals.LogStates.LogState_Error.Clone();
                result.Additional1 = ex.Message;
                return result;
            }
        }
    }
}
