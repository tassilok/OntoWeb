using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using Nest;
using Elasticsearch.Net.Connection;
using PUrify;

namespace ElasticSearchNestConnector
{
    [Flags]
    public enum SortEnum
    {
        ASC_Name = 1,
        DESC_Name = 2,
        NONE = 4,
        ASC_OrderID = 8,
        DESC_OrderID = 16
    }

    public class clsDBSelector
    {
        public string Server { get; private set; }
        public int Port { get; private set; }
        public string Index { get; private set; }
        public string IndexRep { get; private set; }
        public int SearchRange { get; private set; }
        public string Session { get; private set; }
        public List<string> SpecialCharacters_Write { get; set; }
        public List<string> SpecialCharacters_Read { get; set; }

        private SortEnum sort = SortEnum.NONE;

        public IElasticClient ElConnector { get; private set; }

        private ISearchResponse<clsObjectRel> resultObjectRel;
        private ISearchResponse<clsObjectAtt> resultObjectAddOrder;
        private ISearchResponse<clsOntologyItem> resultAttributeType;
        private ISearchResponse<clsOntologyItem> resultAttributeTypeCount;
        private ISearchResponse<clsClassAtt> resultClassAtt;
        private ISearchResponse<clsClassAtt> resultClassAttCount;
        private ISearchResponse<clsOntologyItem> resultClasses;
        private ISearchResponse<clsOntologyItem> resultClassesCount;
        private ISearchResponse<clsClassRel> resultClassRel;
        private ISearchResponse<clsClassRel> resultClassRelCount;
        private ISearchResponse<clsOntologyItem> resultDataTypes;
        private ISearchResponse<clsOntologyItem> resultDataTypesCount;
        private ISearchResponse<clsObjectAtt> resultObjectAtt;
        private ISearchResponse<clsObjectAtt> resultObjectAttCount;
        private ISearchResponse<clsObjectRel> resultObjectRelCount;
        private ISearchResponse<clsOntologyItem> resultObjects;
        private ISearchResponse<clsObjectRel> resultObjectRelTree;
        private ISearchResponse<clsObjectRel> resultObjectRelTreeCount;
        private ISearchResponse<clsOntologyItem> resultObjectCount;
        private ISearchResponse<clsObjectRel> resultObjectRelOrder;
        private ISearchResponse<clsOntologyItem> resultRelationTypes;
        private ISearchResponse<clsOntologyItem> resultRelationTypesCount;

        private List<clsOntologyItem> oList_ObjectsSearch;
        private List<clsOntologyItem> oList_AttributeTypesSearch;
        private List<clsOntologyItem> oList_ClassesSearch;
        private List<clsOntologyItem> oList_DataTypesSearch;
        private List<clsOntologyItem> oList_OtherObjectsSearch;
        private List<clsObjectRel> OList_OhterSearch;

        private clsFields objFields = new clsFields();
        private clsTypes objTypes = new clsTypes();

        public List<clsOntologyItem> OntologyList_Objects1 { get; set; }
        public List<clsOntologyItem> OntologyList_Objects2 { get; set; }
        public List<clsObjectRel> OntologyList_ObjectRel_ID { get; set; }
        public List<clsObjectRel> OntologyList_ObjectRel { get; set; }
        public List<clsObjectTree> OntologyList_ObjectTree { get; set; }
        public List<clsOntologyItem> OntologyList_Classes1 { get; set; }
        public List<clsOntologyItem> OntologyList_Classes2 { get; set; }
        public List<clsOntologyItem> OntologyList_RelationTypes1 { get; set; }
        public List<clsOntologyItem> OntologyList_RelationTypes2 { get; set; }
        public List<clsOntologyItem> OntologyList_AttributTypes1 { get; set; }
        public List<clsOntologyItem> OntologyList_AttributTypes2 { get; set; }
        public List<clsClassRel> OntologyList_ClassRel_ID { get; set; }
        public List<clsClassRel> OntologyList_ClassRel { get; set; }
        public List<clsClassAtt> OntologyList_ClassAtt_ID { get; set; }
        public List<clsClassAtt> OntologyList_ClassAtt { get; set; }
        public List<clsObjectAtt> OntologyList_ObjAtt_ID { get; set; }
        public List<clsObjectAtt> OntologyList_ObjAtt { get; set; }
        public List<clsOntologyItem> OntologyList_DataTypes { get; set; }
        public List<clsAttribute> OntologyList_Attributes { get; set; }

        public IndexExistsDescriptor GetIndexExistsDescriptor()
        {
            return new IndexExistsDescriptor();
        }

        public IndexSettings GetIndexSettings()
        {
            return new IndexSettings();
        }

        public DeleteIndexDescriptor GetDeleteIndexDescriptor()
        {
            return new DeleteIndexDescriptor();
        }

        public SortEnum Sort
        {
            get
            {
                return sort;
            }
            set
            {
                sort = value;
            }


        }

        public string create_Query_ClassRel(List<clsClassRel> OList_ClassRel, bool boolClear = true)
        {
            var strQuery = "";

            if (OList_ClassRel != null)
            {
                
                if (OList_ClassRel.Any())
                {

                    var oL_ID_Left = (from obj in OList_ClassRel
                                      where obj.ID_Class_Left != null
                                      group obj by obj.ID_Class_Left
                                          into g
                                          select g.Key).ToList();


                    if (oL_ID_Left.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_ID_Left.Count;i++ )
                        {
                            if (i>0) strQuery += " OR ";

                            strQuery += objFields.ID_Class_Left + ":" + oL_ID_Left[i];
                        }
                        strQuery += ")";
                    }
                    

                    var oL_ID_Right = (from obj in OList_ClassRel
                                       where obj.ID_Class_Right != null
                                       group obj by obj.ID_Class_Right
                                           into g
                                           select g.Key).ToList();

                    if (oL_ID_Right.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_ID_Right.Count; i++ )
                        {
                            if (i>0) strQuery += " OR ";

                            strQuery += objFields.ID_Class_Right + ":" + oL_ID_Right[i];
                        }
                        strQuery += ")";
                    }

                    


                    var oL_ID_RelationType = (from obj in OList_ClassRel
                                              where obj.ID_RelationType != null
                                              group obj by obj.ID_RelationType
                                                  into g
                                                  select g.Key).ToList();


                    if (oL_ID_RelationType.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_ID_RelationType.Count;i++ )
                        {
                            if (i>0) strQuery += " OR ";

                            strQuery += objFields.ID_RelationType + ":" + oL_ID_RelationType[i];
                        }
                        strQuery += ")";
                    }
                    

                }
            }

            if (strQuery == "")
            {
                strQuery = "*";
            }

            return strQuery;
        }

        public string create_Query_ObjectAtt(List<clsObjectAtt> OList_ObjectAtt, bool doJoin = false)
        {

            var strQuery = "";
            if (OList_ObjectAtt != null)
            {

                var oL_ID_Attribute = (from obj in OList_ObjectAtt
                                       where obj.ID_Attribute != null
                                       group obj by obj.ID_Attribute
                                           into g
                                           select g.Key).ToList();


                if (oL_ID_Attribute.Any())
                {
                    strQuery += "(";

                    for (var i = 0; i < oL_ID_Attribute.Count;i++ )
                    {
                        if (i > 0)
                            strQuery += " OR ";

                        strQuery += objFields.ID_Attribute + ":" + oL_ID_Attribute[i];
                    }

                    strQuery += ")";
                }

                

                var oL_ID_AttributeType = (from obj in OList_ObjectAtt
                                           where obj.ID_AttributeType != null
                                           group obj by obj.ID_AttributeType
                                               into g
                                               select g.Key).ToList();


                if (oL_ID_AttributeType.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";    
                    strQuery += "(";
                    for (int i = 0; i < oL_ID_AttributeType.Count; i++)
                    {
                        if (i > 0) strQuery += " OR ";
                        strQuery += objFields.ID_AttributeType + ":" + oL_ID_AttributeType[i];
                    }
                    
                    strQuery += ")";
                }
                

                

                var oL_ID_Object = (from obj in OList_ObjectAtt
                                    where obj.ID_Object != null
                                    group obj by obj.ID_Object
                                        into g
                                        select g.Key).ToList();

                if (oL_ID_Object.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";    
                    strQuery += "(";
                    for (int i = 0; i < oL_ID_Object.Count;i++)
                    {
                        if (i>0)
                            strQuery += " OR ";

                        strQuery += objFields.ID_Object + ":" + oL_ID_Object[i];
                    }
                    strQuery += ")";
                }

                

                

                var oL_ID_Class = (from obj in OList_ObjectAtt
                                   where obj.ID_Class != null
                                   group obj by obj.ID_Class
                                       into g
                                       select g.Key).ToList();


                if (oL_ID_Class.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";    
                    strQuery += "(";
                    for (var i = 0; i < oL_ID_Class.Count;i++ )
                    {
                        if (i > 0 )
                            strQuery += " OR ";

                        strQuery += objFields.ID_Class + ":" + oL_ID_Class[i];
                    }
                    strQuery += ")";
                }
                

                

                var oL_ID_DataType = (from obj in OList_ObjectAtt
                                      where obj.ID_DataType != null
                                      group obj by obj.ID_DataType
                                          into g
                                          select g.Key).ToList();


                if (oL_ID_DataType.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";    
                    strQuery += "(";
                    for (var i = 0; i < oL_ID_DataType.Count; i++ )
                    {
                        if (i>0) strQuery += " OR ";

                        strQuery += objFields.ID_DataType + ":" + oL_ID_DataType[i];
                    }
                    strQuery += ")";
                }


                
                var oL_Bit = (from obj in OList_ObjectAtt
                              where obj.Val_Bit != null
                              group obj by obj.Val_Bit
                                  into g
                                  select g.Key).ToList();

                if (oL_Bit.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";    
                    strQuery += "(";
                    for (var i = 0; i < oL_Bit.Count; i++ )
                    {
                        if (i>0) strQuery += " OR ";

                        strQuery += objFields.Val_Bool + ":" + oL_Bit[0].ToString();
                    }
                    strQuery += ")";
                }



                
                var oL_Date = (from obj in OList_ObjectAtt
                               where obj.Val_Date != null
                               group obj by obj.Val_Date
                                   into g
                                   select g.Key).ToList();

                if (oL_Date.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";    
                    strQuery += "(";
                    for (var i = 0; i < oL_Date.Count; i++)
                    {
                        if (i > 0) strQuery += " OR ";

                        strQuery += objFields.Val_Datetime + ":" + oL_Date[i].ToString();
                    }
                    strQuery += ")";
                }



                

                var oL_Dbl = (from obj in OList_ObjectAtt
                              where obj.Val_Double != null
                              group obj by obj.Val_Double
                                  into g
                                  select g.Key).ToList();

                if (oL_Dbl.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";
                    strQuery += "(";
                    for (var i = 0; i < oL_Dbl.Count; i++)
                    {
                        if (i > 0) strQuery += " OR ";

                        strQuery += objFields.Val_Real + ":" + oL_Dbl[i].ToString();
                    }
                    strQuery += ")";
                }

                

                var oL_Lng = (from obj in OList_ObjectAtt
                              where obj.Val_Lng != null
                              group obj by obj.Val_Lng
                                  into g
                                  select g.Key).ToList();

                if (oL_Lng.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";
                    strQuery += "(";
                    for (var i = 0; i < oL_Lng.Count; i++)
                    {
                        if (i > 0) strQuery += " OR ";

                        strQuery += objFields.Val_Int + ":" + oL_Lng[i].ToString();
                    }
                    strQuery += ")";
                }

                

                var oL_Str = (from obj in OList_ObjectAtt
                              where obj.Val_String != null
                              group obj by obj.Val_String
                                  into g
                                  select g.Key).ToList();


                if (oL_Str.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";
                    strQuery += "(";
                    for (var i = 0; i < oL_Str.Count; i++)
                    {
                        if (i > 0) strQuery += " OR ";

                        strQuery += objFields.Val_String + ":" + oL_Str[i];
                    }
                    strQuery += ")";
                }

                


            }

            if (doJoin)
            {
                

                var objLClasses = (from obj in OntologyList_Objects1
                                   where obj.GUID_Parent != null
                                   group obj by obj.GUID_Parent
                                       into g
                                       select g.Key).ToList();

                if (objLClasses.Any())
                {
                    if (strQuery != "") strQuery += "  AND  ";
                    strQuery += "(";
                    for (var i = 0; i < objLClasses.Count; i++)
                    {
                        if (i > 0) strQuery += " OR ";

                        strQuery += objFields.ID_Class + ":" + objLClasses[i];
                    }
                    strQuery += ")";
                }
                

            }

            if (strQuery == "")
            {
                strQuery = "*";

            }

            return strQuery;
        }

        public string create_Query_ObjectRel(List<clsObjectRel> OList_ObjectRel)
        {
            var strQuery = "";
            if (OList_ObjectRel != null)
            {
                if (OList_ObjectRel.Any())
                {

                    var oL_IDObject = (from obj in OList_ObjectRel
                                       where obj.ID_Object != null && obj.ID_Object != ""
                                       group obj by obj.ID_Object
                                           into g
                                           select g.Key).ToList();

                    if (oL_IDObject.Any())
                    {
                        strQuery += "(";
                        for (var i = 0; i < oL_IDObject.Count; i++ )
                        {
                            if (i > 0) strQuery += " OR ";

                            strQuery += objFields.ID_Object + ":" + oL_IDObject[i];
                        }
                        strQuery += ")";
                    }

                    

                    var oL_IDParentObject = (from obj in OList_ObjectRel
                                             where obj.ID_Parent_Object != null && obj.ID_Parent_Object != ""
                                             group obj by obj.ID_Parent_Object
                                                 into g
                                                 select g.Key).ToList();

                    if (oL_IDParentObject.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i<oL_IDParentObject.Count;i++)
                        {
                            if (i > 0) strQuery += " OR ";

                            strQuery += objFields.ID_Parent_Object + ":" + oL_IDParentObject[i];
                        }
                        strQuery += ")";
                    }

                    

                    

                    var oL_IDOther = (from obj in OList_ObjectRel
                                      where obj.ID_Other != null && obj.ID_Other != ""
                                      group obj by obj.ID_Other
                                          into g
                                          select g.Key).ToList();

                    if (oL_IDOther.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_IDOther.Count;i++ )
                        {
                            if (i > 0) strQuery += " OR ";

                            strQuery += objFields.ID_Other + ":" + oL_IDOther[i];
                        }
                        strQuery += ")";
                    }

                    

                   var oL_IDParentOther = (from obj in OList_ObjectRel
                                            where obj.ID_Parent_Other != null && obj.ID_Parent_Other != ""
                                            group obj by obj.ID_Parent_Other
                                                into g
                                                select g.Key).ToList();


                    if (oL_IDParentOther.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_IDParentOther.Count;i++ )
                        {
                            if (i > 0) strQuery += " OR ";

                            strQuery += objFields.ID_Parent_Other + ":" + oL_IDParentOther[i];
                        }
                        strQuery += ")";
                    }
                    

                    

                    var oL_IDRelationType = (from obj in OList_ObjectRel
                                             where obj.ID_RelationType != null && obj.ID_RelationType != ""
                                             group obj by obj.ID_RelationType
                                                 into g
                                                 select g.Key).ToList();


                    if (oL_IDRelationType.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_IDRelationType.Count;i++ )
                        {
                            if (i>0) strQuery += " OR ";

                            strQuery += objFields.ID_RelationType + ":" + oL_IDRelationType[i];
                        }
                        strQuery += ")";

                    }

                    

                    

                    var oL_Ontology = (from obj in OList_ObjectRel
                                       where obj.Ontology != null && obj.Ontology != ""
                                       group obj by obj.Ontology
                                           into g
                                           select g.Key).ToList();


                    if (oL_Ontology.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_Ontology.Count;i++ )
                        {
                            if (i>0) strQuery += " OR ";

                            strQuery += objFields.Ontology + ":" + oL_Ontology[i];
                        }
                        strQuery += ")";
                    }

                    var oL_OrderID = (from obj in OList_ObjectRel
                                       where obj.OrderID > 0
                                       group obj by obj.OrderID
                                           into g
                                           select g.Key).ToList();

                    if (oL_OrderID.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_OrderID.Count; i++)
                        {
                            if (i > 0) strQuery += " OR ";

                            strQuery += objFields.OrderID + ":" + oL_OrderID[i];
                        }
                        strQuery += ")";
                    }

                }
            }

            if (strQuery == "")
            {
                strQuery = "*";
            }

            return strQuery;

        }

        public string create_Query_ClassAtt(List<clsOntologyItem> OList_Classes = null,
                                                       List<clsOntologyItem> OList_AttributeTypes = null)
        {
            var strQuery = "";

            if (OList_Classes != null)
            {
                if (OList_Classes.Any())
                {
                    

                    var oL_ID = (from obj in OList_Classes
                                 where obj.GUID != null
                                 group obj by obj.GUID
                                     into g
                                     select g.Key).ToList();


                    if (oL_ID.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_ID.Count;i++ )
                        {
                            if (i>0) strQuery += " OR ";

                            strQuery += objFields.ID_Class + ":" + oL_ID[i];
                        }
                        strQuery += ")";
                    }
                    

                }
            }

            if (OList_AttributeTypes != null)
            {
                if (OList_AttributeTypes.Any())
                {

                    var oL_ID = (from obj in OList_AttributeTypes
                                 where obj.GUID != null
                                 group obj by obj.GUID
                                     into g
                                     select g.Key).ToList();


                    if (oL_ID.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_ID.Count; i++ )
                        {
                            if (i > 0)
                                strQuery += " OR ";

                            strQuery += objFields.ID_AttributeType + ":" + oL_ID[i];
                        }
                        strQuery += ")";
                    }
                    

                }
            }

            if (strQuery == "")
            {
                strQuery = "*";
            }

            return strQuery;
        }

        public string create_Query_Att_OrderID(clsOntologyItem OItem_Object = null,
                                                      clsOntologyItem OItem_AttributeType = null)
        {

            var strQuery = "";

            if (OItem_Object != null)
            {
                if (OItem_Object.GUID != null)
                {
                    strQuery = objFields.ID_Object + ":" + OItem_Object.GUID;
                }


                

                if (OItem_Object.GUID_Parent != null)
                {
                    if (strQuery != "")
                    {
                        strQuery += " AND ";
                    }
                    strQuery += objFields.ID_Class + ":" + OItem_Object.GUID_Parent;
                }

            }


            
            if (OItem_AttributeType != null)
            {
                if (strQuery != "")
                {
                    strQuery += " AND ";
                }

                if (OItem_AttributeType.GUID != null)
                {
                    strQuery += objFields.ID_AttributeType + ":" + OItem_AttributeType.GUID;
                }


            }

            return strQuery;
        }

        public string create_Query_Rel_OrderID(clsOntologyItem OItem_Left = null,
                                                      clsOntologyItem OItem_Right = null,
                                                      clsOntologyItem OItem_RelationType = null)
        {
            var strQuery = "";

            if (OItem_Left != null)
            {

                if (OItem_Left.GUID != null)
                {
                    strQuery = objFields.ID_Object + ":" + OItem_Left.GUID;
                }

                if (OItem_Left.GUID_Parent != null)
                {
                    if (strQuery != "")
                    {
                        strQuery += " AND ";
                    }
                    strQuery += objFields.ID_Parent_Object + ":" + OItem_Left.GUID_Parent;
                }

            }

            if (OItem_Right != null)
            {

                if (OItem_Right.GUID != null)
                {
                    if (strQuery != "")
                    {
                        strQuery += " AND ";
                    }
                    strQuery += objFields.ID_Other + ":" + OItem_Right.GUID;
                }

                if (OItem_Right.GUID_Parent != null)
                {
                    if (strQuery != "")
                    {
                        strQuery += " AND ";
                    }
                    strQuery += objFields.ID_Parent_Other + ":" + OItem_Right.GUID_Parent;
                }


                if (OItem_Right.Type != null)
                {
                    if (strQuery != "")
                    {
                        strQuery += " AND ";
                    }
                    strQuery += objFields.Ontology + ":" + OItem_Right.Type;
                }
            }

            if (OItem_RelationType != null)
            {

                if (OItem_RelationType.GUID != null)
                {
                    if (strQuery != "")
                    {
                        strQuery += " AND ";
                    }
                    strQuery += objFields.ID_RelationType + ":" + OItem_RelationType.GUID;
                }



            }

            return strQuery;
        }

        public string create_Query_Simple(List<clsOntologyItem> OList_Items, string strOntology, bool boolExact = false)
        {
            var strQuery = "";
            var strField_IDParent = "";

            if (strOntology == objTypes.AttributeType)
            {
                strField_IDParent = objFields.ID_DataType;
            }
            else if (strOntology == objTypes.ObjectType)
            {
                strField_IDParent = objFields.ID_Class;
            }
            else
            {
                strField_IDParent = objFields.ID_Parent;
            }

            if (OList_Items != null)
            {
                if (OList_Items.Any())
                {
                    var boolID = false;
                    var oL_ID = (from obj in OList_Items
                                 where obj.GUID != null && obj.GUID != ""
                                 group obj by obj.GUID
                                     into g
                                     select g.Key).ToList();

                    if (oL_ID.Any())
                    {
                        if (strQuery != "") strQuery += "  AND  ";
                        strQuery += "(";
                        for (var i = 0; i < oL_ID.Count;i++ )
                        {
                            if (i>0) strQuery += " OR ";

                            strQuery += objFields.ID_Item + ":" + oL_ID[i];
                        }
                        strQuery += ")";
                    }

                    

                    if (strQuery != "")
                    {
                        boolID = true;
                    }

                    if (!boolID)
                    {
                        strQuery = "";
                        var oL_Name = (from obj in OList_Items
                                       where obj.Name != null && obj.Name != ""
                                       group obj by obj.Name
                                           into g
                                           select g.Key).ToList();


                        if (oL_Name.Any())
                        {
                            if (strQuery != "") strQuery += "  AND  ";
                            strQuery += "(";
                            for (var i = 0; i < oL_Name.Count; i++ )
                            {
                                if (i > 0) strQuery += " OR ";
                                var nameQuery = oL_Name[i];
                                foreach (var specialCharacter in SpecialCharacters_Read)
                                {
                                    nameQuery = nameQuery.Replace(specialCharacter, "\\" + specialCharacter);
                                }

                                if (!boolExact)
                                {
                                    if (nameQuery == oL_Name[i])
                                    {
                                        strQuery += objFields.Name_Item + ":*" + nameQuery + "*";
                                    }
                                    else
                                    {
                                        strQuery += objFields.Name_Item + ":\"" +  nameQuery + "\"";
                                    }


                                }
                                else
                                {
                                    strQuery += objFields + ":" + nameQuery;
                                }

                            }
                            strQuery += ")";
                        }
                        


                        if (strOntology == objTypes.AttributeType ||
                            strOntology == objTypes.ClassType ||
                            strOntology == objTypes.ObjectType)
                        {
                            var oL_IDParent = (from obj in OList_Items
                                               where obj.GUID_Parent != null & obj.GUID_Parent != ""
                                               group obj by obj.GUID_Parent
                                                   into g
                                                   select g.Key).ToList();


                            if (oL_IDParent.Any())
                            {
                                if (strQuery != "") strQuery += "  AND  ";
                                strQuery += "(";
                                for (var i = 0; i < oL_IDParent.Count;i++ )
                                {
                                    if (i > 0) strQuery += " OR ";

                                    strQuery += strField_IDParent + ":" + oL_IDParent[i];
                                }
                                strQuery += ")";
                            }
                            


                        }
                    }
                }
            }

            if (strQuery == "")
            {
                strQuery = "*";
            }

            return strQuery;
        }

        private void initialize_Client()
        {
            var uri = new Uri("http://" + Server + ":" + Port.ToString()).Purify();

            var settings = new ConnectionSettings(uri).SetDefaultIndex(Index).ExposeRawResponse();
            ElConnector = new ElasticClient(settings);

            if (IndexRep != null)
            {
                try
                {
                    ElConnector.CreateIndex(IndexRep);

                }
                catch (Exception ex)
                {

                    throw new Exception("Report index!");
                }    
            }
            
        }

        public long get_Data_Att_OrderByVal(string strOrderField,
                                            clsOntologyItem OItem_Object = null,
                                            clsOntologyItem OItem_AttributeType = null,
                                            bool doASC = true)
        {

            resultObjectAddOrder = null;
            var strQuery = create_Query_Att_OrderID(OItem_Object, OItem_AttributeType);

            long lngOrderID = 0;

            if (doASC)
            {
                resultObjectAddOrder = ElConnector.Search<clsObjectAtt>(s => s.Index(Index).Type(objTypes.ObjectAtt).QueryString(strQuery).From(0).Size(1).Sort(p => p.OnField(strOrderField).Ascending()));
                if (resultObjectAddOrder.Documents.Any())
                {
                    lngOrderID = (long)(typeof(clsObjectAtt).GetProperty(strOrderField).GetValue(resultObjectAddOrder.Documents.First(), null));
                }
            }
            else
            {
                resultObjectAddOrder = ElConnector.Search<clsObjectAtt>(s => s.Index(Index).Type(objTypes.ObjectAtt).QueryString(strQuery).From(0).Size(1).Sort(p => p.OnField(strOrderField).Descending()));
                if (resultObjectAddOrder.Documents.Any())
                {
                    lngOrderID = (long)(typeof(clsObjectAtt).GetProperty(strOrderField).GetValue(resultObjectAddOrder.Documents.First(), null));
                }
            }
            
            return lngOrderID;
        }

        public long get_Data_AttributeTypeCount(List<clsOntologyItem> OList_AttType = null)
        {
            resultAttributeTypeCount = null;
            OntologyList_AttributTypes1.Clear();

            var strQuery = create_Query_Simple(OList_AttType, objTypes.AttributeType);

            resultAttributeTypeCount = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.AttributeType).QueryString(strQuery).From(0).Size(1));

            var lngCount = resultAttributeTypeCount.Total;

            return lngCount;
        }

        public List<clsOntologyItem> get_Data_AttributeType(List<clsOntologyItem> OList_AttType = null, bool List2 = false)
        {
            resultAttributeType = null;
            if (OntologyList_AttributTypes1 == null)
            {
                OntologyList_AttributTypes1 = new List<clsOntologyItem>();
            }

            if (OntologyList_AttributTypes2 == null)
            {
                OntologyList_AttributTypes2 = new List<clsOntologyItem>();
            }

            if (!List2)
            {
                OntologyList_AttributTypes1.Clear();
            }
            else
            {
                OntologyList_AttributTypes2.Clear();
            }


            var strQuery = create_Query_Simple(OList_AttType, objTypes.AttributeType);

            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                
                resultAttributeType = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.AttributeType).QueryString(strQuery).From(intPos).Size(SearchRange));
                    //ElConnector.Search(Index, objTypes.AttributeType, objBoolQuery.ToString(), intPos,
                                                       //SearchRange);


                if (!List2)
                {
                    OntologyList_AttributTypes1.AddRange(resultAttributeType.Documents.Select(d => new clsOntologyItem 
                        {
                            GUID = d.GUID,
                            Name = d.Name,
                            GUID_Parent = d.GUID_Parent,
                            Type = objTypes.AttributeType
                        }));                
                }
                else
                {
                    OntologyList_AttributTypes2.AddRange(resultAttributeType.Documents);
                }


                if (resultAttributeType.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultAttributeType.Documents.Count();
                    intPos += SearchRange;
                }



            }

            if (!List2)
            {
                return OntologyList_AttributTypes1;
            }
            else
            {
                return OntologyList_AttributTypes2;
            }

        }

        public long get_Data_ClassAttCount(List<clsOntologyItem> OList_Class = null,
                                           List<clsOntologyItem> OList_AttributeType = null)
        {
            resultClassAttCount = null;
            var strQuery = create_Query_ClassAtt(OList_Class, OList_AttributeType);


            resultClassAttCount = ElConnector.Search<clsClassAtt>(s => s.Index(Index).Type(objTypes.ClassAtt).QueryString(strQuery).From(0).Size(1));
                //ElConnector.Search(Index, objTypes.ClassAtt, objBoolQuery.ToString(), 0, 1);

            var lngCount = resultClassAttCount.Total;

            return lngCount;
        }

        public List<clsClassAtt> get_Data_ClassAtt(List<clsOntologyItem> OList_Class = null,
                                           List<clsOntologyItem> OList_AttributeType = null,
                                           bool boolIDs = true)
        {
            resultClassAtt = null;
            if (OntologyList_ClassAtt_ID == null)
            {
                OntologyList_ClassAtt_ID = new List<clsClassAtt>();
            }

            if (OntologyList_ClassAtt == null)
            {
                OntologyList_ClassAtt = new List<clsClassAtt>();
            }

            OntologyList_ClassAtt_ID.Clear();
            OntologyList_ClassAtt.Clear();

            var strQuery = create_Query_ClassAtt(OList_Class, OList_AttributeType);

            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {

                resultClassAtt = ElConnector.Search<clsClassAtt>(s => s.Index(Index).Type(objTypes.ClassAtt).QueryString(strQuery).From(intPos).Size(SearchRange));
                    //ElConnector.Search(Index, objTypes.ClassAtt, objBoolQuery.ToString(), intPos, SearchRange);
                
                
                OntologyList_ClassAtt_ID.AddRange(resultClassAtt.Documents);

                if (resultClassAtt.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultClassAtt.Documents.Count();
                    intPos += SearchRange;
                }
            }

            if (!boolIDs)
            {
                var oList_AttributeTypes = (from objAttributeType in OntologyList_ClassAtt_ID
                                            group objAttributeType by objAttributeType.ID_AttributeType
                                                into g
                                                select new clsOntologyItem { GUID = g.Key }).ToList();
                get_Data_AttributeType(oList_AttributeTypes);

                var oList_Classes = (from objClass in OntologyList_ClassAtt_ID
                                     group objClass by objClass.ID_Class
                                         into g
                                         select new clsOntologyItem { GUID = g.Key }).ToList();

                get_Data_Classes(oList_Classes);

                var oList_DataTypes = (from objDataType in OntologyList_AttributTypes1
                                       group objDataType by objDataType.GUID_Parent
                                           into g
                                           select new clsOntologyItem { GUID = g.Key }).ToList();

                get_Data_DataTypes(oList_DataTypes);

                OntologyList_ClassAtt.AddRange((from objClassAtt in OntologyList_ClassAtt_ID
                                                join objClass in OntologyList_Classes1 on objClassAtt.ID_Class equals objClass.GUID
                                                join objAttType in OntologyList_AttributTypes1 on objClassAtt.ID_AttributeType equals objAttType.GUID
                                                join objDataType in OntologyList_DataTypes on objAttType.GUID_Parent equals objDataType.GUID
                                                select new clsClassAtt
                                                {
                                                    ID_AttributeType = objAttType.GUID,
                                                    ID_Class = objClass.GUID,
                                                    ID_DataType = objClassAtt.ID_DataType,
                                                    Name_AttributeType = objAttType.Name,
                                                    Name_Class = objClass.Name,
                                                    Name_DataType = objDataType.Name,
                                                    Min = objClassAtt.Min,
                                                    Max = objClassAtt.Max
                                                }));
            }



            if (boolIDs)
            {
                return OntologyList_ClassAtt_ID;
            }
            else
            {
                return OntologyList_ClassAtt;
            }

        }

        public long get_Data_ClassRelCount(List<clsClassRel> OList_ClassRel)
        {
            resultClassRelCount = null;
            var strQuery = create_Query_ClassRel(OList_ClassRel);

            resultClassRelCount = ElConnector.Search<clsClassRel>(s => s.Index(Index).Type(objTypes.ClassRel).QueryString(strQuery).From(0).Size(1));

            var lngCount = resultClassRelCount.Total;

            return lngCount;
        }

        public List<clsClassRel> get_Data_ClassRel(List<clsClassRel> OList_ClassRel,
                                                   bool boolIDs = true,
                                                   bool boolOR = false)
        {
            resultClassRel = null;
            if (OntologyList_ClassRel_ID == null)
            {
                OntologyList_ClassRel_ID = new List<clsClassRel>();
            }

            if (OntologyList_ClassRel == null)
            {
                OntologyList_ClassRel = new List<clsClassRel>();
            }

            if (OntologyList_Classes1 == null)
            {
                OntologyList_Classes1 = new List<clsOntologyItem>();
            }

            if (OntologyList_Classes2 == null)
            {
                OntologyList_Classes2 = new List<clsOntologyItem>();
            }

            if (OntologyList_RelationTypes1 == null)
            {
                OntologyList_RelationTypes1 = new List<clsOntologyItem>();
            }

            OntologyList_ClassRel_ID.Clear();
            OntologyList_ClassRel.Clear();
            OntologyList_Classes1.Clear();
            OntologyList_Classes2.Clear();
            OntologyList_RelationTypes1.Clear();

            switch (sort)
            {
            }

            var strQuery = create_Query_ClassRel(OList_ClassRel);


            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                resultClassRel = ElConnector.Search<clsClassRel>(s => s.Index(Index).Type(objTypes.ClassRel).QueryString(strQuery).From(intPos).Size(SearchRange));

                OntologyList_ClassRel_ID.AddRange(resultClassRel.Documents);

                if (resultClassRel.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultClassRel.Documents.Count();
                    intPos += SearchRange;
                }
            }

            if (!boolIDs)
            {
                var oList_ClassesLeft = (from objClass in OntologyList_ClassRel_ID
                                         group objClass by objClass.ID_Class_Left
                                             into g
                                             select new clsOntologyItem { GUID = g.Key }).ToList();

                get_Data_Classes(oList_ClassesLeft);

                var oList_ClassesRight = (from objClass in OntologyList_ClassRel_ID
                                          group objClass by objClass.ID_Class_Right
                                              into g
                                              select new clsOntologyItem { GUID = g.Key }).ToList();

                if (oList_ClassesRight.Any())
                {
                    get_Data_Classes(oList_ClassesRight, true);
                }

                var oList_RelationTypes = (from objClass in OntologyList_ClassRel_ID
                                           group objClass by objClass.ID_RelationType
                                               into g
                                               select new clsOntologyItem { GUID = g.Key }).ToList();

                get_Data_RelationTypes(oList_RelationTypes);

                if (boolOR)
                {
                    OntologyList_ClassRel.AddRange((from objClassRel in OntologyList_ClassRel_ID
                                                    join objClassLeft in OntologyList_Classes1 on objClassRel.ID_Class_Left equals objClassLeft.GUID
                                                    join objClassRight in OntologyList_Classes2 on objClassRel.ID_Class_Right equals objClassRight.GUID into objClassesRight
                                                    from objClassRight in objClassesRight.DefaultIfEmpty()
                                                    where objClassRight == null
                                                    join objRelationType in OntologyList_RelationTypes1 on objClassRel.ID_RelationType equals objRelationType.GUID
                                                    select new clsClassRel
                                                    {
                                                        ID_Class_Left = objClassLeft.GUID,
                                                        Name_Class_Left = objClassLeft.Name,
                                                        ID_RelationType = objRelationType.GUID,
                                                        Name_RelationType = objRelationType.Name,
                                                        Min_Forw = objClassRel.Min_Forw,
                                                        Max_Forw = objClassRel.Max_Forw,
                                                        Max_Backw = objClassRel.Max_Backw,
                                                        Ontology = objClassRel.Ontology
                                                    }).ToList());
                }
                else
                {
                    OntologyList_ClassRel.AddRange((from objClassRel in OntologyList_ClassRel_ID
                                                    join objClassLeft in OntologyList_Classes1 on objClassRel.ID_Class_Left equals objClassLeft.GUID
                                                    join objClassRight in OntologyList_Classes2 on objClassRel.ID_Class_Right equals objClassRight.GUID
                                                    join objRelationType in OntologyList_RelationTypes1 on objClassRel.ID_RelationType equals objRelationType.GUID
                                                    select new clsClassRel
                                                    {
                                                        ID_Class_Left = objClassLeft.GUID,
                                                        Name_Class_Left = objClassLeft.Name,
                                                        ID_Class_Right = objClassRight.GUID,
                                                        Name_Class_Right = objClassRight.Name,
                                                        ID_RelationType = objRelationType.GUID,
                                                        Name_RelationType = objRelationType.Name,
                                                        Min_Forw = objClassRel.Min_Forw,
                                                        Max_Forw = objClassRel.Max_Forw,
                                                        Max_Backw = objClassRel.Max_Backw,
                                                        Ontology = objClassRel.Ontology
                                                    }).ToList());
                }


            }



            if (boolIDs)
            {
                return OntologyList_ClassRel_ID;
            }
            else
            {
                return OntologyList_ClassRel;
            }

        }

        public long get_Data_ClassesCount(List<clsOntologyItem> OList_Classes = null)
        {

            resultClassesCount = null;
            var strQuery = create_Query_Simple(OList_Classes, objTypes.ClassType);

            resultClassesCount = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.ClassType).QueryString(strQuery).From(0).Size(1));

            var lngCount = resultClassesCount.Total;

            return lngCount;
        }

        public List<clsOntologyItem> get_Data_Classes(List<clsOntologyItem> OList_Classes = null,
                                                  bool boolClasses_Right = false,
                                                  string strSort = null)
        {
            resultClasses = null;
            var strQuery = create_Query_Simple(OList_Classes, objTypes.ClassType);

            if (OntologyList_Classes1 == null)
            {
                OntologyList_Classes1 = new List<clsOntologyItem>();
            }

            if (OntologyList_Classes2 == null)
            {
                OntologyList_Classes2 = new List<clsOntologyItem>();
            }

            if (!boolClasses_Right)
            {
                OntologyList_Classes1.Clear();
            }
            else
            {
                OntologyList_Classes2.Clear();
            }


            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                resultClasses = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.ClassType).QueryString(strQuery).From(intPos).Size(SearchRange));

                if (!boolClasses_Right)
                {

                    OntologyList_Classes1.AddRange(resultClasses.Documents.Select(d => new clsOntologyItem 
                        {
                            GUID = d.GUID,
                            Name = d.Name,
                            GUID_Parent = d.GUID_Parent,
                            Type = objTypes.ClassType
                        }));


                }
                else
                {
                    OntologyList_Classes2.AddRange(resultClasses.Documents.Select(d => new clsOntologyItem
                    {
                        GUID = d.GUID,
                        Name = d.Name,
                        GUID_Parent = d.GUID_Parent,
                        Type = objTypes.ClassType
                    }));
                }


                if (resultClasses.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultClasses.Documents.Count();
                    intPos += SearchRange;
                }
            }

            if (!boolClasses_Right)
            {
                return OntologyList_Classes1;
            }
            else
            {
                return OntologyList_Classes2;
            }

        }

        public long get_Data_DataTypesCount(List<clsOntologyItem> OList_DataTypes = null)
        {
            resultDataTypesCount = null;
            OntologyList_AttributTypes1.Clear();

            var strQuery = create_Query_Simple(OList_DataTypes, objTypes.DataType);

            resultDataTypesCount = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.DataType).QueryString(strQuery).From(0).Size(1));

            var lngCount = resultDataTypesCount.Total;

            return lngCount;
        }

        public List<clsOntologyItem> get_Data_DataTypes(List<clsOntologyItem> OList_DataType = null)
        {
            resultDataTypes = null;
            if (OntologyList_DataTypes == null)
            {
                OntologyList_DataTypes = new List<clsOntologyItem>();
            }
            OntologyList_DataTypes.Clear();

            var strQuery = create_Query_Simple(OList_DataType, objTypes.DataType);

            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                
                resultDataTypes = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.DataType).QueryString(strQuery).From(intPos).Size(SearchRange));


                OntologyList_DataTypes.AddRange(resultDataTypes.Documents);

                if (resultDataTypes.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultDataTypes.Documents.Count();
                    intPos += SearchRange;
                }



            }

            return OntologyList_DataTypes;
        }

        public long get_Data_ObjectAttCount(List<clsObjectAtt> OList_ObjectAtt)
        {
            resultObjectAttCount = null;

            if (OntologyList_AttributTypes1 == null)
            {
                OntologyList_AttributTypes1 = new List<clsOntologyItem>();
            }
            OntologyList_AttributTypes1.Clear();

            var strQuery = create_Query_ObjectAtt(OList_ObjectAtt);

            resultObjectAttCount = ElConnector.Search<clsObjectAtt>(s => s.Index(Index).Type(objTypes.ObjectAtt).QueryString(strQuery).From(0).Size(1));

            var lngCount = resultObjectAttCount.Total;

            return lngCount;
        }

        public List<clsObjectAtt> get_Data_ObjectAtt(List<clsObjectAtt> OList_ObjectAtt,
                                                     bool boolIDs = true,
                                                     bool doJoin = false)
        {
            resultObjectAtt = null;
            var strQuery = create_Query_ObjectAtt(OList_ObjectAtt, doJoin);

            if (OntologyList_ObjAtt == null) OntologyList_ObjAtt = new List<clsObjectAtt>();
            if (OntologyList_ObjAtt_ID == null) OntologyList_ObjAtt_ID = new List<clsObjectAtt>();
            if (OntologyList_AttributTypes1 == null) OntologyList_AttributTypes1 = new List<clsOntologyItem>();
            if (OntologyList_Attributes == null) OntologyList_Attributes = new List<clsAttribute>();
            if (OntologyList_Classes1 == null) OntologyList_Classes1 = new List<clsOntologyItem>();
            if (OntologyList_Objects1 == null) OntologyList_Objects1 = new List<clsOntologyItem>();
            if (OntologyList_DataTypes == null) OntologyList_DataTypes = new List<clsOntologyItem>();

            OntologyList_ObjAtt.Clear();
            OntologyList_ObjAtt_ID.Clear();
            OntologyList_AttributTypes1.Clear();
            OntologyList_Attributes.Clear();
            OntologyList_Classes1.Clear();
            if (doJoin == false)
                OntologyList_Objects1.Clear();

            OntologyList_DataTypes.Clear();


            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                resultObjectAtt = ElConnector.Search<clsObjectAtt>(s => s.Index(Index).Type(objTypes.ObjectAtt).QueryString(strQuery).From(intPos).Size(SearchRange));

                OntologyList_ObjAtt_ID.AddRange(resultObjectAtt.Documents);

                if (resultObjectAtt.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultObjectAtt.Documents.Count();
                    intPos += SearchRange;
                }



            }


            if (!boolIDs)
            {
                if (!doJoin)
                {

                    if (OntologyList_ObjAtt_ID.Count < 1000)
                    {
                        oList_ObjectsSearch = (from objObj in OntologyList_ObjAtt_ID
                                        group objObj by objObj.ID_Object
                                            into g
                                            select
                                                new clsOntologyItem { GUID = g.Key, Type = objTypes.ObjectType }).ToList();
                    }
                    else
                    {
                        oList_ObjectsSearch = (from objObj in OntologyList_ObjAtt_ID
                                        group objObj by objObj.ID_Class
                                            into g
                                            select
                                                new clsOntologyItem { GUID_Parent = g.Key, Type = objTypes.ObjectType }).ToList();
                    }


                    if (oList_ObjectsSearch.Any())
                    {
                        get_Data_Objects(oList_ObjectsSearch);
                    }
                }

                oList_AttributeTypesSearch = (from objAttType in OntologyList_ObjAtt_ID
                                            group objAttType by objAttType.ID_AttributeType
                                                into g
                                                select new clsOntologyItem { GUID = g.Key }).ToList();

                if (oList_AttributeTypesSearch.Any())
                {
                    get_Data_AttributeType(oList_AttributeTypesSearch);
                }

                oList_ClassesSearch = (from objClass in OntologyList_ObjAtt_ID
                                     group objClass by objClass.ID_Class
                                         into g
                                         select new clsOntologyItem { GUID = g.Key }).ToList();

                if (oList_ClassesSearch.Any())
                {
                    get_Data_Classes(oList_ClassesSearch);
                }

                oList_DataTypesSearch = (from objDataType in OntologyList_ObjAtt_ID
                                       group objDataType by objDataType.ID_DataType
                                           into g
                                           select new clsOntologyItem { GUID = g.Key }).ToList();

                if (oList_DataTypesSearch.Any())
                {
                    get_Data_DataTypes(oList_DataTypesSearch);
                }

                OntologyList_ObjAtt = (from objObjAtt in OntologyList_ObjAtt_ID
                                       join objObject in OntologyList_Objects1 on objObjAtt.ID_Object equals
                                           objObject.GUID
                                       join objClass in OntologyList_Classes1 on objObject.GUID_Parent equals
                                           objClass.GUID
                                       join objAttType in OntologyList_AttributTypes1 on objObjAtt.ID_AttributeType
                                           equals objAttType.GUID
                                       join objDataType in OntologyList_DataTypes on objAttType.GUID_Parent equals
                                           objDataType.GUID
                                       select new clsObjectAtt
                                       {
                                           ID_Attribute = objObjAtt.ID_Attribute,
                                           ID_AttributeType = objAttType.GUID,
                                           ID_Class = objClass.GUID,
                                           ID_Object = objObject.GUID,
                                           ID_DataType = objDataType.GUID,
                                           OrderID = objObjAtt.OrderID,
                                           Name_AttributeType = objAttType.Name,
                                           Name_Class = objClass.Name,
                                           Name_Object = objObject.Name,
                                           Name_DataType = objDataType.Name,
                                           Val_Bit = objObjAtt.Val_Bit,
                                           Val_Date = objObjAtt.Val_Date,
                                           Val_Double = objObjAtt.Val_Double,
                                           Val_Lng = objObjAtt.Val_Lng,
                                           Val_Named = objObjAtt.Val_Named,
                                           Val_String = objObjAtt.Val_String
                                       }).ToList();
            }

            if (boolIDs)
            {
                return OntologyList_ObjAtt_ID;
            }
            else
            {
                return OntologyList_ObjAtt;
            }

        }

        public long get_Data_ObjectsCount(List<clsOntologyItem> OList_Objects = null)
        {
            resultObjectCount = null;
            var strQuery = create_Query_Simple(OList_Objects, objTypes.ObjectType);

            resultObjectCount = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.ObjectType).QueryString(strQuery).From(0).Size(1));

            var lngCount = resultObjectCount.Total;

            return lngCount;
        }

        public List<clsOntologyItem> get_Data_Objects(List<clsOntologyItem> OList_Objects = null,
                                                      bool List2 = false,
                                                      bool ClearObj1 = true,
                                                      bool ClearObj2 = true,
                                                      bool boolExact = false)
        {
            resultObjects = null;
            if (OntologyList_Objects1 == null)
            {
                OntologyList_Objects1 = new List<clsOntologyItem>();
            }
            else
            {
                if (ClearObj1) OntologyList_Objects1.Clear();
            }
            if (OntologyList_Objects2 == null)
            {
                OntologyList_Objects2 = new List<clsOntologyItem>();
            }
            else
            {
                if (ClearObj2) OntologyList_Objects2.Clear();
            }

            var strQuery = create_Query_Simple(OList_Objects, objTypes.ObjectType, boolExact);

            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                resultObjects = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.ObjectType).QueryString(strQuery).From(intPos).Size(SearchRange));

                if (!List2)
                {
                    OntologyList_Objects1.AddRange(resultObjects.Documents.Select(d => new clsOntologyItem
                    {
                        GUID = d.GUID,
                        Name = d.Name,
                        GUID_Parent = d.GUID_Parent,
                        Type = objTypes.ObjectType
                    }));
                }
                else
                {
                    OntologyList_Objects2.AddRange(resultObjects.Documents.Select(d => new clsOntologyItem
                    {
                        GUID = d.GUID,
                        Name = d.Name,
                        GUID_Parent = d.GUID_Parent,
                        Type = objTypes.ObjectType
                    }));
                }


                if (resultObjects.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultObjects.Documents.Count();
                    intPos += SearchRange;
                }


            }

            if (!List2)
            {
                return OntologyList_Objects1;
            }
            else
            {
                return OntologyList_Objects2;
            }

        }

        public long get_Data_ObjectRelCount(List<clsObjectRel> OList_ObjectRel = null)
        {

            resultObjectRelCount = null;
            var strQuery = create_Query_ObjectRel(OList_ObjectRel);

            resultObjectRelCount = ElConnector.Search<clsObjectRel>(s => s.Index(Index).Type(objTypes.ObjectRel).QueryString(strQuery).From(0).Size(1));

            var lngCount = resultObjectRelCount.Total;

            return lngCount;
        }

        public List<clsObjectRel> get_Data_ObjectRel(List<clsObjectRel> OList_ObjectRel = null,
                                                     bool boolIDs = true,
                                                     bool doJoin_Left = false,
                                                     bool doJoin_Right = false)
        {
            resultObjectRel = null;
            var strQuery = create_Query_ObjectRel(OList_ObjectRel);

            OntologyList_ObjectRel = new List<clsObjectRel>();
            OntologyList_ObjectRel_ID = new List<clsObjectRel>();
            OntologyList_Classes1 = new List<clsOntologyItem>();
            OntologyList_RelationTypes1 = new List<clsOntologyItem>();
            OntologyList_DataTypes = new List<clsOntologyItem>();

            if (OntologyList_Objects1 == null)
            {
                OntologyList_Objects1 = new List<clsOntologyItem>();
            }
            else
            {
                if (!doJoin_Left) OntologyList_Objects1.Clear();
            }

            if (OntologyList_Objects2 == null)
            {
                OntologyList_Objects2 = new List<clsOntologyItem>();
            }
            else
            {
                if (!doJoin_Right) OntologyList_Objects2.Clear();
            }


            string strSort = null;
            if (sort == SortEnum.ASC_OrderID)
            {
                strSort = "OrderID:asc";
            }
            else if (sort == SortEnum.DESC_OrderID)
            {
                strSort = "OrderID:desc";
            }

            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                if (sort != SortEnum.ASC_OrderID && sort != SortEnum.DESC_OrderID)
                {
                    resultObjectRel = ElConnector.Search<clsObjectRel>(s => s.Index(Index).Type(objTypes.ObjectRel).QueryString(strQuery).From(intPos).Size(SearchRange));

                    OntologyList_ObjectRel_ID.AddRange(resultObjectRel.Documents);

                    if (resultObjectRel.Documents.Count() < SearchRange)
                    {
                        intCount = 0;
                    }
                    else
                    {
                        intCount = resultObjectRel.Documents.Count();
                        intPos += SearchRange;
                    }
                }
                else
                {
                    if (sort == SortEnum.ASC_OrderID)
                    {
                        resultObjectRel = ElConnector.Search<clsObjectRel>(s => s.Index(Index).Type(objTypes.ObjectRel).QueryString(strQuery).From(intPos).Size(SearchRange).SortAscending(objFields.OrderID));
                        OntologyList_ObjectRel_ID.AddRange(resultObjectRel.Documents);

                        if (resultObjectRel.Documents.Count() < SearchRange)
                        {
                            intCount = 0;
                        }
                        else
                        {
                            intCount = resultObjectRel.Documents.Count();
                            intPos += SearchRange;
                        }
                    }
                    else
                    {
                        resultObjectRel = ElConnector.Search<clsObjectRel>(s => s.Index(Index).Type(objTypes.ObjectRel).QueryString(strQuery).From(intPos).Size(SearchRange).SortDescending(objFields.OrderID));
                        OntologyList_ObjectRel_ID.AddRange(resultObjectRel.Documents);
                        if (resultObjectRel.Documents.Count() < SearchRange)
                        {
                            intCount = 0;
                        }
                        else
                        {
                            intCount = resultObjectRel.Documents.Count();
                            intPos += SearchRange;
                        }
                    }
                    
                }



                

                




            }


            if (!boolIDs)
            {
                if (!doJoin_Left)
                {
                    if (OntologyList_ObjectRel_ID.Count < 1000)
                    {
                        oList_ObjectsSearch = (from objObj in OntologyList_ObjectRel_ID
                                        group objObj by objObj.ID_Object
                                            into g
                                            select
                                                new clsOntologyItem { GUID = g.Key, Type = objTypes.ObjectType }).ToList();
                    }
                    else
                    {
                        oList_ObjectsSearch = (from objObj in OntologyList_ObjectRel_ID
                                        group objObj by objObj.ID_Parent_Object
                                            into g
                                            select
                                                new clsOntologyItem { GUID_Parent = g.Key, Type = objTypes.ObjectType }).ToList();
                    }


                    if (oList_ObjectsSearch.Any())
                    {
                        get_Data_Objects(oList_ObjectsSearch);
                    }
                }


                get_Data_Classes();

                get_Data_RelationTypes();

                get_Data_AttributeType();

                if (OntologyList_ObjectRel_ID.Count < 1000)
                {
                    oList_OtherObjectsSearch = (from objClass in OntologyList_ObjectRel_ID
                                          where objClass.Ontology == objTypes.ObjectType
                                          group objClass by objClass.ID_Other
                                              into g
                                              select new clsOntologyItem { GUID = g.Key }).ToList();

                }
                else
                {
                    oList_OtherObjectsSearch = (from objClass in OntologyList_ObjectRel_ID
                                          where objClass.Ontology == objTypes.ObjectType
                                          group objClass by objClass.ID_Parent_Other
                                              into g
                                              select new clsOntologyItem { GUID_Parent = g.Key }).ToList();
                }

                OntologyList_Objects2 = oList_OtherObjectsSearch.Any() ? get_Data_Objects(oList_OtherObjectsSearch, List2: true, ClearObj1: false) : new List<clsOntologyItem>();

                OntologyList_DataTypes = get_Data_DataTypes();

                OList_OhterSearch = (from objOther in OntologyList_ObjectRel_ID
                                   where objOther.Ontology == objTypes.AttributeType ||
                                         objOther.Ontology == objTypes.RelationType ||
                                         objOther.Ontology == objTypes.ClassType
                                   select objOther).ToList();

                if (OntologyList_Objects2.Any())
                {
                    OntologyList_ObjectRel.AddRange((from objObjRel in OntologyList_ObjectRel_ID
                                                     join objLeft in OntologyList_Objects1 on objObjRel.ID_Object equals
                                                         objLeft.GUID
                                                     join objLeftClass in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Object equals objLeftClass.GUID
                                                     join objRight in OntologyList_Objects2 on objObjRel.ID_Other equals
                                                         objRight.GUID
                                                     join objRightParent in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Other equals objRightParent.GUID
                                                     join objRelationType in OntologyList_RelationTypes1 on
                                                         objObjRel.ID_RelationType equals objRelationType.GUID
                                                     select new clsObjectRel
                                                     {
                                                         ID_Object = objLeft.GUID,
                                                         Name_Object = objLeft.Name,
                                                         ID_Parent_Object = objLeftClass.GUID,
                                                         Name_Parent_Object = objLeftClass.Name,
                                                         ID_Other = objRight.GUID,
                                                         Name_Other = objRight.Name,
                                                         ID_Parent_Other = objRightParent.GUID,
                                                         Name_Parent_Other = objRightParent.Name,
                                                         OrderID = objObjRel.OrderID,
                                                         Ontology = objObjRel.Ontology,
                                                         ID_RelationType = objRelationType.GUID,
                                                         Name_RelationType = objRelationType.Name
                                                     }).ToList());

                }

                if (OList_OhterSearch.Where(p => p.Ontology == objTypes.AttributeType).Any())
                {
                    OntologyList_ObjectRel.AddRange((from objObjRel in OntologyList_ObjectRel_ID
                                                     join objLeft in OntologyList_Objects1 on objObjRel.ID_Object equals
                                                         objLeft.GUID
                                                     join objLeftClass in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Object equals objLeftClass.GUID
                                                     join objRight in OntologyList_AttributTypes1 on objObjRel.ID_Other equals
                                                         objRight.GUID
                                                     join objRightParent in OntologyList_DataTypes on
                                                         objRight.GUID_Parent equals objRightParent.GUID
                                                     join objRelationType in OntologyList_RelationTypes1 on
                                                         objObjRel.ID_RelationType equals objRelationType.GUID
                                                     select new clsObjectRel
                                                     {
                                                         ID_Object = objLeft.GUID,
                                                         Name_Object = objLeft.Name,
                                                         ID_Parent_Object = objLeftClass.GUID,
                                                         Name_Parent_Object = objLeftClass.Name,
                                                         ID_Other = objRight.GUID,
                                                         Name_Other = objRight.Name,
                                                         ID_Parent_Other = objRightParent.GUID,
                                                         Name_Parent_Other = objRightParent.Name,
                                                         OrderID = objObjRel.OrderID,
                                                         Ontology = objObjRel.Ontology,
                                                         ID_RelationType = objRelationType.GUID,
                                                         Name_RelationType = objRelationType.Name
                                                     }).ToList());

                }

                if (OList_OhterSearch.Where(p => p.Ontology == objTypes.RelationType).Any())
                {
                    OntologyList_ObjectRel.AddRange((from objObjRel in OntologyList_ObjectRel_ID
                                                     join objLeft in OntologyList_Objects1 on objObjRel.ID_Object equals
                                                         objLeft.GUID
                                                     join objLeftClass in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Object equals objLeftClass.GUID
                                                     join objRight in OntologyList_RelationTypes1 on objObjRel.ID_Other equals
                                                         objRight.GUID
                                                     join objRelationType in OntologyList_RelationTypes1 on
                                                         objObjRel.ID_RelationType equals objRelationType.GUID
                                                     select new clsObjectRel
                                                     {
                                                         ID_Object = objLeft.GUID,
                                                         Name_Object = objLeft.Name,
                                                         ID_Parent_Object = objLeftClass.GUID,
                                                         Name_Parent_Object = objLeftClass.Name,
                                                         ID_Other = objRight.GUID,
                                                         Name_Other = objRight.Name,
                                                         OrderID = objObjRel.OrderID,
                                                         Ontology = objObjRel.Ontology,
                                                         ID_RelationType = objRelationType.GUID,
                                                         Name_RelationType = objRelationType.Name
                                                     }).ToList());

                }

                if (OList_OhterSearch.Where(p => p.Ontology == objTypes.ClassType).Any())
                {
                    OntologyList_ObjectRel.AddRange((from objObjRel in OntologyList_ObjectRel_ID
                                                     join objLeft in OntologyList_Objects1 on objObjRel.ID_Object equals
                                                         objLeft.GUID
                                                     join objLeftClass in OntologyList_Classes1 on
                                                         objObjRel.ID_Parent_Object equals objLeftClass.GUID
                                                     join objRight in OntologyList_Classes1 on objObjRel.ID_Other equals
                                                         objRight.GUID
                                                     join objRelationType in OntologyList_RelationTypes1 on
                                                         objObjRel.ID_RelationType equals objRelationType.GUID
                                                     select new clsObjectRel
                                                     {
                                                         ID_Object = objLeft.GUID,
                                                         Name_Object = objLeft.Name,
                                                         ID_Parent_Object = objLeftClass.GUID,
                                                         Name_Parent_Object = objLeftClass.Name,
                                                         ID_Other = objRight.GUID,
                                                         Name_Other = objRight.Name,
                                                         ID_Parent_Other = objRight.GUID_Parent,
                                                         OrderID = objObjRel.OrderID,
                                                         Ontology = objObjRel.Ontology,
                                                         ID_RelationType = objRelationType.GUID,
                                                         Name_RelationType = objRelationType.Name
                                                     }).ToList());

                }

            }
            if (boolIDs)
            {
                return OntologyList_ObjectRel_ID;
            }
            else
            {
                return OntologyList_ObjectRel;
            }

        }

        public long get_Data_RelationTypesCount(List<clsOntologyItem> OList_RelType = null)
        {
            resultRelationTypesCount = null;
            OntologyList_AttributTypes1.Clear();

            var strQuery = create_Query_Simple(OList_RelType, objTypes.RelationType);


            resultRelationTypesCount = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.RelationType).Query(q => q.QueryString(qs => qs.Query(strQuery))).From(0).Size(1));

            var lngCount = resultRelationTypesCount.Total;

            return lngCount;
        }

        public List<string> IndexList(string server, int port)
        {
            var uri = new Uri("http://" + server + ":" + port.ToString());

            var settings = new ConnectionSettings(uri);
            var objElConnector = new ElasticClient(settings);
            var dictIndex = objElConnector.IndicesStats().Indices;
            
            return dictIndex.Keys.ToList();
        }

        public List<clsOntologyItem> get_Data_RelationTypes(List<clsOntologyItem> OList_RelType = null, bool List2 = false)
        {
            resultRelationTypes = null;
            if (OntologyList_RelationTypes1 == null)
            {
                OntologyList_RelationTypes1 = new List<clsOntologyItem>();
            }

            if (OntologyList_RelationTypes2 == null)
            {
                OntologyList_RelationTypes2 = new List<clsOntologyItem>();
            }

            if (!List2)
            {
                OntologyList_RelationTypes1.Clear();
            }
            else
            {
                OntologyList_RelationTypes2.Clear();
            }


            var strQuery = create_Query_Simple(OList_RelType, objTypes.RelationType);

            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                resultRelationTypes = ElConnector.Search<clsOntologyItem>(s => s.Index(Index).Type(objTypes.RelationType).QueryString(strQuery).From(intPos).Size(SearchRange));
                

                if (!List2)
                {
                    OntologyList_RelationTypes1.AddRange(resultRelationTypes.Documents.Select(d => new clsOntologyItem
                    {
                        GUID = d.GUID,
                        Name = d.Name,
                        GUID_Parent = d.GUID_Parent,
                        Type = objTypes.RelationType
                    }));
                }
                else
                {
                    OntologyList_RelationTypes2.AddRange(resultRelationTypes.Documents.Select(d => new clsOntologyItem
                    {
                        GUID = d.GUID,
                        Name = d.Name,
                        GUID_Parent = d.GUID_Parent,
                        Type = objTypes.RelationType
                    }));
                }


                if (resultRelationTypes.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultRelationTypes.Documents.Count();
                    intPos += SearchRange;
                }


            }

            if (!List2)
            {
                return OntologyList_RelationTypes1;
            }
            else
            {
                return OntologyList_RelationTypes2;
            }

        }

        public long get_Data_Rel_OrderByVal(clsOntologyItem OItem_Left,
                                        clsOntologyItem OItem_Right,
                                        clsOntologyItem OItem_RelationType,
                                        string strSort,
                                        bool doASC = true)
        {
            resultObjectRelOrder = null;
            long lngOrderID = 0;
            string strField = strSort;

         
            var strQuery = create_Query_Rel_OrderID(OItem_Left, OItem_Right, OItem_RelationType);

            if (doASC)
            {
                resultObjectRelOrder = ElConnector.Search<clsObjectRel>(s => s.Index(Index).Type(objTypes.ObjectRel).QueryString(strQuery).From(0).Size(1).SortAscending(strSort));
                if (resultObjectRelOrder.Documents.Any())
                {
                    lngOrderID = (long)resultObjectRelOrder.Documents.First().OrderID;
                }
            }
            else
            {
                resultObjectRelOrder = ElConnector.Search<clsObjectRel>(s => s.Index(Index).Type(objTypes.ObjectRel).QueryString(strQuery).From(0).Size(1).SortDescending(strSort));
                if (resultObjectRelOrder.Documents.Any())
                {
                    lngOrderID = (long)resultObjectRelOrder.Documents.First().OrderID;
                }
            }

            


            return lngOrderID;
        }

        public long get_Data_Objects_Tree_Count(clsOntologyItem OItem_Class_Par,
                                                clsOntologyItem OItem_Class_Child,
                                                clsOntologyItem OItem_RelationType)
        {
            resultObjectRelTreeCount = null;
            var strQuery = objFields.ID_Parent_Object + ":" + OItem_Class_Par.GUID;
            strQuery += " AND " + objFields.ID_Parent_Other + OItem_Class_Child.GUID;
            strQuery += " AND " + objFields.ID_RelationType + OItem_RelationType.GUID;

            resultObjectRelTreeCount = ElConnector.Search<clsObjectRel>(s => s.Index(Index).Type(objTypes.ObjectRel).QueryString(strQuery).From(0).Size(1));

            var lngCount = resultObjectRelTreeCount.Total;

            return lngCount;
        }

        public List<clsObjectTree> get_Data_Objects_Tree(clsOntologyItem OItem_Class_Par,
                                                clsOntologyItem OItem_Class_Child,
                                                clsOntologyItem OItem_RelationType)
        {
            resultObjectRelTree = null;
            if (OntologyList_ObjectTree == null)
            {
                OntologyList_ObjectTree = new List<clsObjectTree>();
            }

            OntologyList_ObjectTree.Clear();

            var strQuery = objFields.ID_Parent_Object + ":" + OItem_Class_Par.GUID;
            strQuery += " AND " + objFields.ID_Parent_Other + ":" + OItem_Class_Child.GUID;
            strQuery += " AND " + objFields.ID_RelationType + ":" + OItem_RelationType.GUID;

            var objOList_Objects = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = OItem_Class_Par.GUID,
                                                                                     Type = objTypes.ObjectType } };

            var objOList_Other = new List<clsOntologyItem> { new clsOntologyItem {GUID_Parent = OItem_Class_Child.GUID,
                                                                                     Type = objTypes.ObjectType } };

            var objOList_RelationType = new List<clsOntologyItem> { OItem_RelationType };


            get_Data_Objects(objOList_Objects);
            get_Data_Objects(objOList_Other, true, false, true);
            get_Data_RelationTypes(objOList_RelationType);

            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                resultObjectRelTree = ElConnector.Search<clsObjectRel>(s => s.Index(Index).Type(objTypes.ObjectRel).QueryString(strQuery).From(intPos).Size(SearchRange));

                OntologyList_ObjectTree.AddRange((from objHit in resultObjectRelTree.Documents
                                                  join objLeft in OntologyList_Objects1 on objHit.ID_Object equals objLeft.GUID
                                                  join objRight in OntologyList_Objects2 on objHit.ID_Other equals objRight.GUID
                                                  join objRel in OntologyList_RelationTypes1 on objHit.ID_RelationType equals objRel.GUID
                                                  select new clsObjectTree
                                                  {
                                                      ID_Object = objRight.GUID,
                                                      Name_Object = objRight.Name,
                                                      ID_Parent = objRight.GUID_Parent,
                                                      ID_Object_Parent = objLeft.GUID,
                                                      Name_Object_Parent = objLeft.Name,
                                                      OrderID = objHit.OrderID  ?? 0
                                                  }).ToList().OrderBy(p => p.ID_Object_Parent).ThenBy(p => p.OrderID).ThenBy(p => p.Name_Object).ToList());

                if (resultObjectRelTree.Documents.Count() < SearchRange)
                {
                    intCount = 0;
                }
                else
                {
                    intCount = resultObjectRelTree.Documents.Count();
                    intPos += SearchRange;
                }
            }

            return OntologyList_ObjectTree;
        }


        public clsDBSelector(string server,
                          int port,
                          string index,
                          string indexRep,
                          int searchRange,
                          string session)
        {
            this.Server = server;
            this.Port = port;
            this.Index = index;
            this.IndexRep = indexRep;
            this.SearchRange = searchRange;
            this.Session = session;

            SpecialCharacters_Read = new List<string> { "\\", "+", "-", "&&", "||", "!", "(", ")", "{", "}", "[", "]", "^", "\"", "~", "*", "?", ":", "@", "/" };
            //SpecialCharacters_Write = new List<string> { ":", "\"" };
            //SpecialCharacters_Read = new List<string> { " ", ":", "/", "\"" };
            initialize_Client();
            sort = SortEnum.NONE;




        }

        public clsDBSelector()
        {
            


        }
    }
}
