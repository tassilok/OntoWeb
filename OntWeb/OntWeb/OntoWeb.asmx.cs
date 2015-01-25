using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

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

        private DbConnector dbConnector;
        clsTypes types = new clsTypes();

        public OntoWeb()
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

        [WebMethod]
        public List<clsOntologyItem> ClassesByGuidParent(string GuidParent, bool allChildren = false)
        {
            if (allChildren)
            {
                return LocGetClassChildsByGuidParent(GuidParent);
            }
            else
            {
                var classesSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = GuidParent } };
                var oItemResult = dbConnector.GetClasses(classesSearch);
                if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
                {
                    return dbConnector.Classes1;
                }
                else
                {
                    SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                    throw se;
                }
            }

        }

        private List<clsOntologyItem> LocGetClassChildsByGuidParent(string GuidParent)
        {
            var classes = new List<clsOntologyItem>();
            var classesSearch = new List<clsOntologyItem>();
            var first = true;
            long classFoundCount;

            do
            {
                classFoundCount = classes.Count;
                if (first)
                {
                    classesSearch.Add(new clsOntologyItem { GUID_Parent = GuidParent });
                    first = false;
                }
                else
                {
                    classesSearch =
                        dbConnector.Classes1.GroupBy(p => p.GUID)
                                   .Select(p => new clsOntologyItem { GUID_Parent = p.Key })
                                   .ToList();
                }
                var oItemResult = dbConnector.GetClasses(classesSearch);
                if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
                {
                    classes.AddRange(dbConnector.Classes1);
                    classFoundCount = classes.Count - classFoundCount;
                }
                else
                {
                    SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                    throw se;
                }

            } while (classFoundCount > 0);


            return classes;
        }

        [WebMethod]
        public List<clsOntologyItem> ClassesChildsByGuidParentAndName(string GuidParent, string name, bool allChildren = false, bool caseSensitive = false)
        {
            var classes = new List<clsOntologyItem>();

            if (allChildren)
            {
                classes = LocGetClassChildsByGuidParent(GuidParent);

                return caseSensitive ? classes.Where(p => p.Name == name).ToList() :
                                       classes.Where(p => p.Name.ToLower() == name.ToLower()).ToList();
            }
            else
            {
                return caseSensitive ? LocGetClassChildsByGuidParent(GuidParent).Where(p => p.Name == name).ToList() :
                                       LocGetClassChildsByGuidParent(GuidParent).Where(p => p.Name.ToLower() == name.ToLower()).ToList();

            }



        }

        [WebMethod]
        public List<clsClassRel> ClassRelations(bool onlyIds)
        {
            var oItem_Result = dbConnector.GetClassRelations(ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByLeftGuid(string guidClass, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { ID_Class_Left = guidClass } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByRightGuid(string guidClass, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { ID_Class_Right = guidClass } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByRelationTypeGuid(string guidRelationType, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { ID_RelationType = guidRelationType } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByLeftGuid_RightGuid(string guidLeft, string guidRight, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { ID_Class_Left = guidLeft, ID_Class_Right = guidRight } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByLeftGuid_RelationTypeGuid_RightGuid(string guidLeft, string guidRelationType, string guidRight, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { ID_Class_Left = guidLeft, ID_RelationType = guidRelationType, ID_Class_Right = guidRight } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByLeftGuid_RelationTypeGuid(string guidLeft, string guidRelationType, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { ID_Class_Left = guidLeft, ID_RelationType = guidRelationType } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByRelationTypeGuid_RightGuid(string guidRelationType, string guidRight, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { ID_RelationType = guidRelationType, ID_Class_Right = guidRight } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByMinForw(long minForw, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { Min_Forw = minForw } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByMaxForw(long maxForw, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { Max_Forw = maxForw } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsClassRel> ClassRelationsByMaxBackw(long maxBackw, bool onlyIds)
        {
            var classesSearch = new List<clsClassRel> { new clsClassRel { Max_Backw = maxBackw } };
            var oItem_Result = dbConnector.GetClassRelations(classRelationsSearch: classesSearch, ids: onlyIds);
            if (oItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return onlyIds ? dbConnector.ClassRelationsId : dbConnector.ClassRelations;

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
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
            var oItem_Result = dbConnector.GetObjectAtt(objectAttsSearch, doCount: true);
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

        [WebMethod]
        public List<clsOntologyItem> Objects()
        {
            var oItemResult = dbConnector.GetObjects();
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Objects1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ObjectsByGuid(string guid)
        {
            var oListObjectsSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID = guid } };

            var oItemResult = dbConnector.GetObjects(oListObjectsSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Objects1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ObjectsByName(string name, bool exact)
        {
            var oListObjectsSearch = new List<clsOntologyItem> { new clsOntologyItem { Name = name } };

            var oItemResult = dbConnector.GetObjects(oListObjectsSearch, exact: exact);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Objects1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ObjectsByGuidParent(string guidParent)
        {
            var oListObjectsSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = guidParent } };

            var oItemResult = dbConnector.GetObjects(oListObjectsSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Objects1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ObjectsByGuidParentAndName(string guidParent, string name, bool exact)
        {
            var oListObjectsSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = guidParent,
                                                                                       Name = name} };

            var oItemResult = dbConnector.GetObjects(oListObjectsSearch, exact: exact);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Objects1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> Classes()
        {
            var oItemResult = dbConnector.GetClasses();
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Classes1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ClassesByGuid(string guid)
        {
            var classesSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID = guid } };
            var oItemResult = dbConnector.GetClasses(classesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Classes1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ClassesByName(string name, bool strict = false, bool caseSensitive = false)
        {
            var classesSearch = new List<clsOntologyItem> { new clsOntologyItem { Name = name } };
            var oItemResult = dbConnector.GetClasses(classesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                if (strict)
                {
                    return caseSensitive ? dbConnector.Classes1.Where(p => p.Name == name).ToList() : dbConnector.Classes1.Where(p => p.Name.ToLower() == name.ToLower()).ToList();

                }
                else
                {
                    return dbConnector.Classes1;
                }


            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> RelationTypes()
        {
            var oItemResult = dbConnector.GetRelationTypes();
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.RelationTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> RelationTypesByRelationTypeGuid(string guidRelationType)
        {
            var RelationTypesSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID = guidRelationType } };
            var oItemResult = dbConnector.GetRelationTypes(RelationTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.RelationTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> RelationTypesByRelationTypeName(string nameRelationType, bool strict, bool caseSensitive)
        {
            var RelationTypesSearch = new List<clsOntologyItem> { new clsOntologyItem { Name = nameRelationType } };
            var oItemResult = dbConnector.GetRelationTypes(RelationTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                if (strict)
                {
                    if (caseSensitive)
                    {
                        return dbConnector.RelationTypes.Where(p => p.Name == nameRelationType).ToList();
                    }
                    else
                    {
                        return dbConnector.RelationTypes.Where(p => p.Name.ToLower() == nameRelationType.ToLower()).ToList();
                    }
                }
                else
                {
                    return dbConnector.RelationTypes;
                }

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> AttributeTypes()
        {
            var oItemResult = dbConnector.GetAttributeTypes();
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.AttributeTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> AttributeTypesByAttributeTypeGuid(string guidAttributeType)
        {
            var attributeTypesSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID = guidAttributeType } };
            var oItemResult = dbConnector.GetAttributeTypes(attributeTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.AttributeTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> AttributeTypesByAttributeTypeName(string nameAttributeType, bool strict, bool caseSensitive)
        {
            var attributeTypesSearch = new List<clsOntologyItem> { new clsOntologyItem { Name = nameAttributeType } };
            var oItemResult = dbConnector.GetAttributeTypes(attributeTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                if (strict)
                {
                    if (caseSensitive)
                    {
                        return dbConnector.AttributeTypes.Where(p => p.Name == nameAttributeType).ToList();
                    }
                    else
                    {
                        return dbConnector.AttributeTypes.Where(p => p.Name.ToLower() == nameAttributeType.ToLower()).ToList();
                    }
                }
                else
                {
                    return dbConnector.AttributeTypes;
                }

            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> AttributeTypesByAttributeTypeIdDataType(string idDataType)
        {
            var attributeTypesSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = idDataType } };
            var oItemResult = dbConnector.GetAttributeTypes(attributeTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.AttributeTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public clsOntologyItem GetOItem(string idItem, string type)
        {
            if (type == Globals.OTypes.ClassType)
            {
                var items = ClassesByGuid(idItem);
                return items.FirstOrDefault();
            }
            else if (type == Globals.OTypes.ObjectType)
            {
                var items = ObjectsByGuid(idItem);
                return items.FirstOrDefault();
            }
            else if (type == Globals.OTypes.AttributeType)
            {
                var items = AttributeTypesByAttributeTypeGuid(idItem);
                return items.FirstOrDefault();
            }
            else if (type == Globals.OTypes.RelationType)
            {
                var items = RelationTypesByRelationTypeGuid(idItem);
                return items.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public string GetClassPath(string idClass)
        {
            return getClassPath(idClass, "");
        }
        
        private string getClassPath(string idClass, string path)
        {
            var searchClass = new List<clsOntologyItem> { new clsOntologyItem { GUID = idClass } };

            var result = dbConnector.GetClasses(searchClass);

            if (result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                if (dbConnector.Classes1.Any())
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        path = dbConnector.Classes1.First().Name;
                    }
                    else
                    {
                        path = dbConnector.Classes1.First().Name + "\\" + path;
                    }

                    if (!string.IsNullOrEmpty(dbConnector.Classes1.First().GUID_Parent))
                    {
                        return getClassPath(dbConnector.Classes1.First().GUID_Parent, path);
                    }
                    else
                    {
                        return path;
                    }

                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        [WebMethod]
        public clsOntologyItem DeleteIndex(string strIndex)
        {
            return dbConnector.DeleteIndex(strIndex);
        }

        [WebMethod]
        public List<string> IndexList(string server, int port)
        {
            return dbConnector.IndexList(server, port);
        }

        [WebMethod]
        public clsOntologyItem SaveDataTypes(List<clsOntologyItem> oList_DataTypes)
        {
            return dbConnector.save_DataTypes(oList_DataTypes);
        }

        [WebMethod]
        public clsOntologyItem DeleteAttributeTypes(List<clsOntologyItem> oList_AttributeTypes)
        {
            return dbConnector.del_AttributeType(oList_AttributeTypes);
        }
    }
}
