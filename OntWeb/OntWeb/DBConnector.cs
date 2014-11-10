using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElasticSearchNestConnector;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace OntWeb
{
    public class DbConnector
    {
        private clsDBSelector dbSelector;

        public List<clsOntologyItem> Classes1 { get; private set; }
        public List<clsOntologyItem> Classes2 { get; private set; }
        public List<clsClassAtt> ClassAttributes { get; private set; }
        public List<clsClassAtt> ClassAttributesId { get; private set; }
        public List<clsClassRel> ClassRelations { get; private set; }
        public List<clsClassRel> ClassRelationsId { get; private set; }
        public List<clsOntologyItem> AttributeTypes { get; private set; }
        public List<clsOntologyItem> RelationTypes { get; private set; }
        public List<clsOntologyItem> Objects1 { get; private set; }
        public List<clsOntologyItem> Objects2 { get; private set; }
        public List<clsObjectRel> ObjectRelsId { get; private set; }
        public List<clsObjectRel> ObjectRels { get; private set; }
        public List<clsObjectAtt> ObjectAtts { get; private set; }
        public List<clsObjectAtt> ObjectAttsId { get; private set; }

        public clsOntologyItem GetClasses(List<clsOntologyItem> classesSearch = null,
                                          bool fillClassesRight = false,
                                          string sort = null,
                                          bool doCount = false)
        {
            var oItemResult = Globals.LogStates.LogState_Success.Clone();
            if (doCount)
            {
                oItemResult.Count = dbSelector.get_Data_ClassesCount(classesSearch);
            }
            else
            {
                Classes1 = dbSelector.get_Data_Classes(classesSearch, fillClassesRight, sort);
            }
            return oItemResult;
        }

        public clsOntologyItem GetClassAttributes(List<clsOntologyItem> classes = null,
                                                  List<clsOntologyItem> attributeTypes = null,
                                                  bool ids = true,
                                                  bool doCount = false)
        {
            var oItemResult = Globals.LogStates.LogState_Success.Clone();
            if (doCount)
            {
                oItemResult.Count = dbSelector.get_Data_ClassAttCount(classes,attributeTypes);
            }
            else
            {
                if (ids)
                {
                    ClassAttributesId = dbSelector.get_Data_ClassAtt(classes, attributeTypes);
                }
                else
                {
                    ClassAttributes = dbSelector.get_Data_ClassAtt(classes, attributeTypes,false);
                }
            }
            return oItemResult;
        }

        public clsOntologyItem GetClassRelations(List<clsClassRel> classRelationsSearch = null,
                                                 bool ids = true,
                                                 bool oref = false,
                                                 bool doCount = false)
        {
            var oItemResult = Globals.LogStates.LogState_Success.Clone();

            if (doCount)
            {
                oItemResult.Count = dbSelector.get_Data_ClassRelCount(classRelationsSearch);
            }
            else
            {
                if (ids)
                {
                    ClassRelationsId = dbSelector.get_Data_ClassRel(classRelationsSearch, ids, oref);
                }
                else
                {
                    ClassRelations = dbSelector.get_Data_ClassRel(classRelationsSearch, ids, oref);
                }
            }

            return oItemResult;
        }

        public clsOntologyItem GetAttributeTypes(List<clsOntologyItem> attributeTypesSearch = null,
                                                 bool doCount = false)
        {
            var oItemResult = Globals.LogStates.LogState_Success.Clone();

            if (doCount)
            {
                oItemResult.Count = dbSelector.get_Data_AttributeTypeCount(attributeTypesSearch);
            }
            else
            {
                AttributeTypes = dbSelector.get_Data_AttributeType(attributeTypesSearch);
            }

            return oItemResult;
        }

        public clsOntologyItem GetRelationTypes(List<clsOntologyItem> relationTypesSearch = null,
                                                 bool doCount = false)
        {
            var oItemResult = Globals.LogStates.LogState_Success.Clone();

            if (doCount)
            {
                oItemResult.Count = dbSelector.get_Data_RelationTypesCount(relationTypesSearch);
            }
            else
            {
                RelationTypes = dbSelector.get_Data_RelationTypes(relationTypesSearch);
            }

            return oItemResult;
        }

        public clsOntologyItem GetObjects(List<clsOntologyItem> objectsSearch = null,
                                          bool doCount = false,
                                          bool fillList2 = false,
                                          bool clearList1 = true,
                                          bool clearList2 = true,
                                          bool exact = false)
        {
            var oItemResult = Globals.LogStates.LogState_Success.Clone();

            if (doCount)
            {
                oItemResult.Count = dbSelector.get_Data_ObjectsCount(objectsSearch);
            }
            else
            {
                if (!fillList2)
                {
                    Objects1 = dbSelector.get_Data_Objects(objectsSearch, false, true, true,exact);   
                }
                else
                {
                    Objects2 = dbSelector.get_Data_Objects(objectsSearch, false, true, true, exact);   
                }
                 
            }

            return oItemResult;
        }

        public clsOntologyItem GetObjectRel(List<clsObjectRel> objectRelsSearch = null,
                                            bool ids = true,
                                            bool doCount = false,
                                            string Direction = null,
                                            bool clear = true,
                                            bool doJoinLeft = false,
                                            bool doJoinRight = false)
        {
            var oItemResult = Globals.LogStates.LogState_Success.Clone();

            if (doCount)
            {
                oItemResult.Count = dbSelector.get_Data_ObjectRelCount(objectRelsSearch);
            }
            else
            {
                if (ids)
                {
                    ObjectRelsId = dbSelector.get_Data_ObjectRel(objectRelsSearch, ids, doJoinLeft, doJoinRight);
                }
                else
                {
                    ObjectRels = dbSelector.get_Data_ObjectRel(objectRelsSearch, ids, doJoinLeft, doJoinRight);
                }

            }

            return oItemResult;
        }

        public clsOntologyItem GetObjectAtt(List<clsObjectAtt> ObjectAttsSearch = null,
                                            bool ids = true,
                                            bool doCount = false,
                                            bool doJoin = false)
        {
            var oItemResult = Globals.LogStates.LogState_Success.Clone();

            if (doCount)
            {
                oItemResult.Count = dbSelector.get_Data_ObjectAttCount(ObjectAttsSearch);
            }
            else
            {
                if (ids)
                {
                    ObjectAttsId = dbSelector.get_Data_ObjectAtt(ObjectAttsSearch, ids, doJoin);
                }
                else
                {
                    ObjectAtts = dbSelector.get_Data_ObjectAtt(ObjectAttsSearch, ids, doJoin);
                }

            }

            return oItemResult;
        }

        public DbConnector()
        {
            dbSelector = new clsDBSelector(Globals.ElServer,Globals.ElPort,Globals.ElIndex,Globals.RepIndex,Globals.ElSearchRange,"");
            Classes1 = new List<clsOntologyItem>();
            Classes2 = new List<clsOntologyItem>();
            ClassAttributes = new List<clsClassAtt>();
            ClassAttributesId = new List<clsClassAtt>();
            ClassRelations = new List<clsClassRel>();
            ClassRelationsId = new List<clsClassRel>();
        }
    }
}