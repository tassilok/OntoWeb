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
    /// Zusammenfassungsbeschreibung für OServiceOItems
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceOItems : System.Web.Services.WebService
    {

        private DbConnector dbConnector;

        public OServiceOItems()
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
            var oListObjectsSearch = new List<clsOntologyItem> { new clsOntologyItem { Name = name} };

            var oItemResult = dbConnector.GetObjects(oListObjectsSearch,exact: exact);
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

            var oItemResult = dbConnector.GetObjects(oListObjectsSearch,exact: exact);
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


    }
}
