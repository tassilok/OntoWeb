using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using OntologyClasses.BaseClasses;

namespace OntWeb
{
    /// <summary>
    /// Summary description for OServiceClassRel
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceClassRel : System.Web.Services.WebService
    {

        private DbConnector dbConnector;

        public OServiceClassRel()
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
    }
}
