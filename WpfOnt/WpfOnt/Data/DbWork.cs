using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.OntoWeb;

namespace WpfOnt.Data
{
    public class DbWork
    {

        public List<clsOntologyItem> OList_Objects { get; private set; }
        public List<clsOntologyItem> OList_Objects2 { get; private set; }
        public List<clsObjectRel> OList_ObjectRel_ID { get; private set; }
        public List<clsObjectRel> OList_ObjectRel { get; private set; }
        //public List<clsObjectTree> OList_ObjectTree { get; private set; }
        public List<clsOntologyItem> OList_Classes { get; private set; }
        public List<clsOntologyItem> OList_Classes2 { get; private set; }
        public List<clsOntologyItem> OList_RelationTypes { get; private set; }
        public List<clsOntologyItem> OList_AttributeTypes { get; private set; }
        public List<clsClassRel> OList_ClassRel_ID { get; private set; }
        public List<clsClassRel> OList_ClassRel { get; private set; }
        public List<clsClassAtt> OList_ClassAtt_ID { get; private set; }
        public List<clsClassAtt> OList_ClassAtt { get; private set; }
        public List<clsObjectAtt> OList_ObjAtt_ID { get; private set; }
        public List<clsObjectAtt> OList_ObjAtt { get; private set; }
        public List<clsOntologyItem> OList_DataTypes { get; private set; }
        //public List<clsAttribute> OList_Attributes { get; private set; }

        //private clsDataTypes objDataTypes = new clsDataTypes();
        //private clsTypes objTypes = new clsTypes();
        private clsLogStates objLogStates = new clsLogStates();
        private clsFields objFields = new clsFields();
        private clsDirections objDirections = new clsDirections();

        private OntoWeb.OntoWebSoapClient ontoWebSoapClient;

        private string strServer;
        private string strIndex;
        private string strIndexRep;
        private int intPort;
        private int intSearchRange;
        private string strSession;

        public int PackageLength { get; set; }
        //private SortEnum sortE;

        //private clsDBSelector objElSelector; 
        //private clsDBDeletor objElDeletor;
        //private clsDBUpdater objElUpdater;


        public List<clsObjectAtt> OAList_Saved { get; set; }


        //public SortEnum Sort
        //{
        //    get { return sortE; }
        //    set 
        //    { 
        //        sortE = value;
        //        objElSelector.Sort = sortE;
        //    }
        //}

         public List<string> IndexList(string strServer, int intPort)
         {
             return new List<string>(ontoWebSoapClient.IndexList(strServer, intPort));
         }
        

        public clsOntologyItem save_DataTypes(List<clsOntologyItem> OList_DataTypes)
        {
            var objOItem_Result = ontoWebSoapClient.SaveDataTypes(OList_DataTypes.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem save_AttributeType(clsOntologyItem oItem_AttributeType)
        {
            var objOItem_Result = ontoWebSoapClient.SaveAttributeTypes((new List<clsOntologyItem>{ oItem_AttributeType }).ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem del_AttributeType(List<clsOntologyItem> OList_AttributeType)
        {
            var objOItem_Result = ontoWebSoapClient.DeleteAttributeTypes(OList_AttributeType.ToArray());
            return objOItem_Result;
        }

        public clsOntologyItem del_RelationTypes(List<clsOntologyItem> OList_RelationType)
        {
            var objOItem_Result = ontoWebSoapClient.DeleteRelationTypes(OList_RelationType.ToArray());

            return objOItem_Result;
        }


        public clsOntologyItem del_DataTypes(List<clsOntologyItem> OList_DataTypes)
        {
            var objOItem_Result = ontoWebSoapClient.DeleteDataTypes(OList_DataTypes.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem del_ClassAttType(clsOntologyItem oItem_Class, clsOntologyItem oItem_AttType)
        {
            var objOItem_Result = ontoWebSoapClient.DeleteClassAttType(oItem_Class, oItem_AttType);
            return objOItem_Result;
        }
        
        public clsOntologyItem del_Objects(List<clsOntologyItem> List_Objects)
        {
            var objOItem_Result = ontoWebSoapClient.DeleteObjects(List_Objects.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem del_ClassRel(List<clsClassRel> oList_ClRel)
        {
            var objOItem_Result = ontoWebSoapClient.DeleteClassRel(oList_ClRel.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem del_ObjectAtt(List<clsObjectAtt> oList_ObjectAtts ) 
        {

            var objOItem_Result = ontoWebSoapClient.DeleteObjectAttributes(oList_ObjectAtts.ToArray());
        
            return objOItem_Result;
        }
        
        public clsOntologyItem del_ObjectRel(List<clsObjectRel> oList_ObjecRels)
        {
            var objOItem_Result = ontoWebSoapClient.DeleteObjectRelations(oList_ObjecRels.ToArray());

            return objOItem_Result;
        }
       
        public clsOntologyItem save_RelationType(clsOntologyItem oItem_RelationType)
        {
            var objOItem_Result = ontoWebSoapClient.SaveRelationTypes((new List<clsOntologyItem>{ oItem_RelationType}).ToArray());
        
            return objOItem_Result;
        }

        public clsOntologyItem del_Class(List<clsOntologyItem> oList_Class)
        {
            var objOItem_Result = ontoWebSoapClient.DeleteClasses(oList_Class.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem save_ClassRel(List<clsClassRel> oList_ClassRel) 
        {
            var objOItem_Result = ontoWebSoapClient.SaveClassRels(oList_ClassRel.ToArray());

            return objOItem_Result;
        }
        
        public clsOntologyItem save_ClassAttType(List<clsClassAtt> oList_ClassAtt) 
        {
            var objOItem_Result = ontoWebSoapClient.SaveClassAtts(oList_ClassAtt.ToArray());
        
            return objOItem_Result;
        }
        
        public clsOntologyItem save_Class(clsOntologyItem objOItem_Class, bool boolRoot = false) 
        {
            var objOItem_Result = ontoWebSoapClient.SaveClasses((new List<clsOntologyItem>{ objOItem_Class }).ToArray());
        
            return objOItem_Result;
        }

        public clsOntologyItem save_ObjRel(List<clsObjectRel> oList_ObjectRel )
        {
            var objOItem_Result = ontoWebSoapClient.SaveObjectRels(oList_ObjectRel.ToArray());
        
            return objOItem_Result;
        }

        public clsOntologyItem save_ObjAtt(List<clsObjectAtt> oList_ObjAtt ) 
        {
            
            var result = ontoWebSoapClient.SaveObjectAttributes(oList_ObjAtt.ToArray());
            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                OAList_Saved = new List<clsObjectAtt>( result.ObjectAttributes );
                return result.Result;
            }
            else
            {
                return result.Result;
            }
        }

        public clsOntologyItem save_Objects(List<clsOntologyItem> oList_Objects )
        {
            var result = ontoWebSoapClient.SaveObjects(oList_Objects.ToArray());

            return result;
        }

        private void initialize_Client()
        {
        }
        
        public clsOntologyItem get_Data_RelationTypes(List<clsOntologyItem> OList_RelType = null,
                                               bool doCount = false) 
        {
            this.OList_RelationTypes.Clear();
            var objOItem_Result = objLogStates.LogState_Success;

            if (doCount)
            {
                objOItem_Result.Count = ontoWebSoapClient.rel(OList_RelType);
            }
            else
            {
                this.OList_RelationTypes = objElSelector.get_Data_RelationTypes(OList_RelType);

            
            }
            
            return objOItem_Result;
        }

        public clsOntologyItem get_Data_AttributeType(List<clsOntologyItem> OList_AttType = null,
                                               bool doCount = false) 
        {
            this.OList_AttributeTypes.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();

            if (doCount)
            {
                objOItem_Result.Count = objElSelector.get_Data_AttributeTypeCount(OList_AttType);
            }
            else
            {
                this.OList_AttributeTypes = objElSelector.get_Data_AttributeType(OList_AttType);
            }
            
            return objOItem_Result;
        }

        public clsOntologyItem get_Data_ClassAtt(List<clsOntologyItem> oList_Class = null,
                                          List<clsOntologyItem> oList_AttributeTyp = null,
                                          bool boolIDs = true,
                                          bool doCount = false) 
        {
            this.OList_ClassAtt_ID.Clear();
            this.OList_ClassAtt.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();

            if (doCount)
            {
                objOItem_Result.Count = objElSelector.get_Data_ClassAttCount(oList_Class,oList_AttributeTyp);
            }
            else
            {
                if (boolIDs)
                {
                    this.OList_ClassAtt_ID = objElSelector.get_Data_ClassAtt(oList_Class, oList_AttributeTyp, boolIDs);
                }
                else
                {
                    this.OList_ClassAtt = objElSelector.get_Data_ClassAtt(oList_Class, oList_AttributeTyp, boolIDs);

                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem get_Data_ClassRel(List<clsClassRel> OList_ClassRel,
                                          bool boolIDs = false,
                                          bool boolOR = false, 
                                          bool doCount = false)
        {
            this.OList_ClassRel_ID.Clear();
            this.OList_ClassRel.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();
            if (doCount)
            {
                objOItem_Result.Count = objElSelector.get_Data_ClassRelCount(OList_ClassRel);
            }
            else
            {
                if (boolIDs)
                {
                    this.OList_ClassRel_ID = objElSelector.get_Data_ClassRel(OList_ClassRel, boolIDs, boolOR);
                }
                else
                {
                    this.OList_ClassRel = objElSelector.get_Data_ClassRel(OList_ClassRel, boolIDs, boolOR);
                }
                
            }

            return objOItem_Result;
        }

        public clsOntologyItem get_Data_ObjectAtt(List<clsObjectAtt> oList_ObjectAtt,
                                           bool boolIDs = true,
                                           bool doCount = false,
                                           bool doJoin = false)
        {
            this.OList_ObjAtt_ID.Clear();
            this.OList_ObjAtt.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();

            if (doCount)
            {
                objOItem_Result.Count = objElSelector.get_Data_ObjectAttCount(oList_ObjectAtt);
            }
            else
            {
                if (boolIDs)
                {
                    this.OList_ObjAtt_ID = objElSelector.get_Data_ObjectAtt(oList_ObjectAtt, boolIDs, doJoin);
                }
                else
                {
                    this.OList_ObjAtt = objElSelector.get_Data_ObjectAtt(oList_ObjectAtt, boolIDs, doJoin);
                }
            }

            return objOItem_Result;
        }

        public long get_Data_Att_OrderID(clsOntologyItem OItem_Object = null,
                                             clsOntologyItem OItem_AttributeType = null,
                                             bool doASC = true)
        {
        
            string strSortField;
        
            strSortField = "OrderID:";

            var lngOrderID = objElSelector.get_Data_Att_OrderByVal(strSortField,OItem_Object,OItem_AttributeType,doASC);

            return lngOrderID;

        }

        public long get_Data_Att_OrderByVal(string strOrderField,
                                         clsOntologyItem OItem_Object = null,
                                             clsOntologyItem OItem_AttributeType = null,
                                             bool doASC = true)
        {
            var lngOrderID = objElSelector.get_Data_Att_OrderByVal(strOrderField,OItem_Object,OItem_AttributeType,doASC);

            return lngOrderID;
        }

        public long get_Data_Rel_OrderID(clsOntologyItem OItem_Left = null,
                                             clsOntologyItem OItem_Right = null,
                                             clsOntologyItem OItem_RelationType = null,
                                             bool doASC = true)
        {
            long lngOrderID = 0;

            lngOrderID = objElSelector.get_Data_Rel_OrderByVal(OItem_Left,
                                                               OItem_Right,
                                                               OItem_RelationType,
                                                               "OrderID",
                                                               doASC);

        
            return lngOrderID;
        }

        public clsOntologyItem get_Data_ObjectRel(List<clsObjectRel> oList_ObjectRel,
                                           bool boolIDs = true,
                                           bool doCount = false,
                                           string Direction = null,
                                           bool doJoin_Left = false,
                                           bool doJoin_right = false,
                                           bool boolTable_Objects_Left = false,
                                           bool boolTable_Objects_Right = false) 
        {
            this.OList_ObjectRel_ID.Clear();
            this.OList_ObjectRel.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();


            if (doCount)
            {
                objOItem_Result.Count = objElSelector.get_Data_ObjectRelCount(oList_ObjectRel);
            }
            else
            {
                if (boolIDs)
                {
                    this.OList_ObjectRel_ID = objElSelector.get_Data_ObjectRel(oList_ObjectRel, boolIDs, doJoin_Left, doJoin_right);
                }
                else
                {
                    this.OList_ObjectRel = objElSelector.get_Data_ObjectRel(oList_ObjectRel, boolIDs, doJoin_Left, doJoin_right);
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem get_Data_DataTyps(List<clsOntologyItem> oList_DataTypes = null,
                                          bool doCount = false)
        {
            this.OList_DataTypes.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();

            if (doCount)
            {
                objOItem_Result.Count = objElSelector.get_Data_DataTypesCount(oList_DataTypes);
            }
            else
            {
                this.OList_DataTypes = objElSelector.get_Data_DataTypes(oList_DataTypes);

            }

        
            return objOItem_Result;
        }

        public clsOntologyItem get_Data_Objects_Tree(clsOntologyItem objOItem_Class_Par,
                                              clsOntologyItem objOitem_Class_Child,
                                              clsOntologyItem objOItem_RelationType,
                                              bool boolTable = false,
                                              bool doCount = false)
        {
            this.OList_ObjectTree.Clear();
            this.OList_Objects.Clear();
            this.OList_Objects2.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();

            if (doCount)
            {
                objOItem_Result.Count = objElSelector.get_Data_Objects_Tree_Count(objOItem_Class_Par,
                                                                                  objOitem_Class_Child,
                                                                                  objOItem_RelationType);
            }
            else
            {
                this.OList_ObjectTree = objElSelector.get_Data_Objects_Tree(objOItem_Class_Par,
                                                                                 objOitem_Class_Child,
                                                                                 objOItem_RelationType);
                this.OList_Objects = objElSelector.OntologyList_Objects1;
                this.OList_Objects2 = objElSelector.OntologyList_Objects2;

            }

            return objOItem_Result;

        }

        public clsOntologyItem get_Data_Objects(List<clsOntologyItem> oList_Objects = null,
                                         bool doCount = false,
                                         bool List2 = false,
                                         bool boolExact = false) 
        {
            this.OList_Objects.Clear();
            this.OList_Objects2.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();

        
            if (!List2)
            {
                this.OList_Objects = objElSelector.get_Data_Objects(oList_Objects, false, true, true, boolExact);
            }
            else
            {
                this.OList_Objects2 = objElSelector.get_Data_Objects(oList_Objects, false, true, true, boolExact);
            }

            return objOItem_Result;
        }



        public clsOntologyItem create_Report_ES(clsOntologyItem objOItem_Report)
        {
            var objOItem_Result = objLogStates.LogState_Success.Clone();

            return objOItem_Result;
        }

        public bool test_Index_Es()
        {

            var objIndexDescriptor = objElSelector.GetIndexExistsDescriptor();
            objIndexDescriptor.Index(strIndex);

            return objElSelector.ElConnector.IndexExists(f => objIndexDescriptor).Exists;
        
        }

        public bool create_Index_Es() 
        {
            var indexSettings = objElSelector.GetIndexSettings();
            var objOPResult = objElSelector.ElConnector.CreateIndex(index => index.Index(strIndex).InitializeUsing(indexSettings));
            return objOPResult.IsValid;
            
        }

        public clsOntologyItem get_Data_Classes(List<clsOntologyItem> OList_Classes = null,
                                     bool boolTable = false, 
                                     bool boolClasses_Right = false,
                                     string strSort = null,
                                     bool doCount = false)
        {
            this.OList_Classes.Clear();
            this.OList_Classes2.Clear();
            var objOItem_Result = objLogStates.LogState_Success.Clone();

            if (doCount)
            {
                objOItem_Result.Count = objElSelector.get_Data_ClassesCount(OList_Classes);
            }
            else 
            {
                if (!boolClasses_Right)
                {
                    this.OList_Classes = objElSelector.get_Data_Classes(OList_Classes, boolClasses_Right, strSort);
                
                }
                else 
                {
                    this.OList_Classes2 = objElSelector.get_Data_Classes(OList_Classes, boolClasses_Right, strSort);
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetOItem(string GUID_Item, string Type_Item ) 
        {
            var objOItem_OItem = new clsOntologyItem {GUID = GUID_Item,
                                                       Type = Type_Item};


            var objOLIst_OItem = new List<clsOntologyItem> {objOItem_OItem};

            var objOItem_Result = new clsOntologyItem {GUID = objLogStates.LogState_Error.GUID};

            if (Type_Item.ToLower() == objTypes.AttributeType.ToLower())
            {
                objOItem_Result = get_Data_AttributeType(objOLIst_OItem);
                if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                {
                    if (OList_AttributeTypes.Any())
                    {
                        objOItem_OItem.Name = OList_AttributeTypes.First().Name;
                        objOItem_OItem.GUID_Parent = OList_AttributeTypes.First().GUID_Parent;
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Success.GUID;
                    }
                    else
                    {
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID;
                    }
                    objOItem_OItem.Type = objTypes.AttributeType;
                }
            }
            else if (Type_Item.ToLower() == objTypes.ClassType.ToLower())
            {
                objOItem_Result = get_Data_Classes(objOLIst_OItem);
                if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                {
                    if (OList_Classes.Any())
                    {
                        objOItem_OItem.Name = OList_Classes.First().Name;
                        objOItem_OItem.GUID_Parent = OList_Classes.First().GUID_Parent;
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Success.GUID;
                    }
                    else
                    {
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID;
                    }
                    objOItem_OItem.Type = objTypes.ClassType;
                }
            }
            else if (Type_Item.ToLower() == objTypes.ClassType.ToLower())
            {
                objOItem_Result = get_Data_Objects(objOLIst_OItem);
                if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                {
                    if (OList_Objects.Any())
                    {
                        objOItem_OItem.Name = OList_Objects.First().Name;
                        objOItem_OItem.GUID_Parent = OList_Objects.First().GUID_Parent;
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Success.GUID;
                    }
                    else
                    {
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID;
                    }
                    objOItem_OItem.Type = objTypes.ObjectType;
                }
            }
            else if (Type_Item.ToLower() == objTypes.RelationType.ToLower())
            {
                objOItem_Result = get_Data_RelationTypes(objOLIst_OItem);
                if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                {
                    if (OList_RelationTypes.Any())
                    {
                        objOItem_OItem.Name = OList_RelationTypes.First().Name;
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Success.GUID;
                    }
                    else
                    {
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID;
                    }
                    objOItem_OItem.Type = objTypes.RelationType;
                }
            }
        
            if (objOItem_Result.GUID == objLogStates.LogState_Error.GUID)
            {
                objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID;
            }

            return objOItem_OItem;
        }    

    public string GetClassPath(clsOntologyItem OItem_Class)
    {
        string strPath = "";
        do
        {
            if (!string.IsNullOrEmpty(OItem_Class.GUID_Parent))
            {
                if ( OItem_Class.GUID_Parent != "")
                {
                    strPath = OItem_Class.Name + (!string.IsNullOrEmpty(strPath) ? "\\" : "") + strPath;
                    var objOLRel_ClassParent = new List<clsOntologyItem> {new clsOntologyItem {GUID = OItem_Class.GUID_Parent}};
                    var OList_Classes = objElSelector.get_Data_Classes(objOLRel_ClassParent);
                    OItem_Class = OList_Classes.FirstOrDefault();
                }
            }
        } while (OItem_Class.GUID_Parent != null);
        

        if (OItem_Class != null)
        {
            strPath = "\\" + OItem_Class.Name + (!string.IsNullOrEmpty(strPath) ? "\\" : "") + strPath;
        }

        return strPath;
    }


    public DbWork(Globals globals)
    {
        set_DBConnection();
        strServer = globals.Server;
        strIndex = globals.Index;
        strIndexRep = globals.Index_Rep;
        intPort = globals.Port;
        intSearchRange = globals.SearchRange;
        strSession = globals.Session;

        Initialize();
        initialize_Client();

        Sort = SortEnum.NONE;
    }
    
        public DbWork(string strServer, int intPort, string strIndex, string strIndexRep, int intSearchRange, string strSession)
        {
            set_DBConnection();

            this.strIndex = strIndex;
            this.strIndexRep = strIndexRep;
            this.strServer = strServer;
            this.intPort = intPort;
            this.intSearchRange = intSearchRange;
            this.strSession = strSession;

            Initialize();
            initialize_Client();

            Sort = SortEnum.NONE;
        }

        private void Initialize()
        {
            PackageLength = intSearchRange;
            OList_Objects = new List<clsOntologyItem>();
            OList_Objects2 = new List<clsOntologyItem>();
            OList_ObjectRel_ID = new List<clsObjectRel>();
            OList_ObjectRel = new List<clsObjectRel>();
            OList_ObjectTree = new List<clsObjectTree>();
            OList_Classes = new List<clsOntologyItem>();
            OList_Classes2 = new List<clsOntologyItem>();
            OList_RelationTypes = new List<clsOntologyItem>();
            OList_AttributeTypes = new List<clsOntologyItem>();
            OList_ClassRel_ID = new List<clsClassRel>();
            OList_ClassRel = new List<clsClassRel>();
            OList_ClassAtt_ID = new List<clsClassAtt>();
            OList_ClassAtt = new List<clsClassAtt>();
            OList_ObjAtt_ID = new List<clsObjectAtt>();
            OList_ObjAtt = new List<clsObjectAtt>();
            OList_DataTypes = new List<clsOntologyItem>();
            OList_Attributes = new List<clsAttribute>();

            ontoWebSoapClient = new OntoWebSoapClient();
        }

        public DbWork()
        {
            Initialize();
            //objElSelector = new clsDBSelector();
        }
    
    
        private void set_DBConnection()
        {

        }


        public clsOntologyItem DeleteIndex(string strIndex) 
        {
            var oItem_Result = ontoWebSoapClient.DeleteIndex(strIndex);

            return oItem_Result;
        }



    }
}

