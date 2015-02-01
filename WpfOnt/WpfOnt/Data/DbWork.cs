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
        public List<clsObjectTree> OList_ObjectTree { get; private set; }
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

        //private clsDataTypes objDataTypes = new clsDataTypes();
        private clsTypes objTypes;
        private clsLogStates objLogStates;
        private clsDirections objDirections;


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
             var result = WebServiceConnector.OntologyWebSoapClient.IndexList(strServer, intPort);
             if (result.Result.GUID == objLogStates.LogState_Success.GUID)
             {
                 return new List<string>( result.IndexList);
             }
             else
             {
                 return null;
             }
             
         }
        

        public clsOntologyItem save_DataTypes(List<clsOntologyItem> OList_DataTypes)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.SaveDataTypes(OList_DataTypes.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem save_AttributeType(clsOntologyItem oItem_AttributeType)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.SaveAttributeTypes((new List<clsOntologyItem>{ oItem_AttributeType }).ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem del_AttributeType(List<clsOntologyItem> OList_AttributeType)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteAttributeTypes(OList_AttributeType.ToArray());
            return objOItem_Result;
        }

        public clsOntologyItem del_RelationTypes(List<clsOntologyItem> OList_RelationType)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteRelationTypes(OList_RelationType.ToArray());

            return objOItem_Result;
        }


        public clsOntologyItem del_DataTypes(List<clsOntologyItem> OList_DataTypes)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteDataTypes(OList_DataTypes.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem del_ClassAttType(clsOntologyItem oItem_Class, clsOntologyItem oItem_AttType)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteClassAttType(oItem_Class, oItem_AttType);
            return objOItem_Result;
        }
        
        public clsOntologyItem del_Objects(List<clsOntologyItem> List_Objects)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteObjects(List_Objects.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem del_ClassRel(List<clsClassRel> oList_ClRel)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteClassRel(oList_ClRel.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem del_ObjectAtt(List<clsObjectAtt> oList_ObjectAtts ) 
        {

            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteObjectAttributes(oList_ObjectAtts.ToArray());
        
            return objOItem_Result;
        }
        
        public clsOntologyItem del_ObjectRel(List<clsObjectRel> oList_ObjecRels)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteObjectRelations(oList_ObjecRels.ToArray());

            return objOItem_Result;
        }
       
        public clsOntologyItem save_RelationType(clsOntologyItem oItem_RelationType)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.SaveRelationTypes((new List<clsOntologyItem>{ oItem_RelationType}).ToArray());
        
            return objOItem_Result;
        }

        public clsOntologyItem del_Class(List<clsOntologyItem> oList_Class)
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteClasses(oList_Class.ToArray());

            return objOItem_Result;
        }

        public clsOntologyItem save_ClassRel(List<clsClassRel> oList_ClassRel) 
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.SaveClassRels(oList_ClassRel.ToArray());

            return objOItem_Result;
        }
        
        public clsOntologyItem save_ClassAttType(List<clsClassAtt> oList_ClassAtt) 
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.SaveClassAtts(oList_ClassAtt.ToArray());
        
            return objOItem_Result;
        }
        
        public clsOntologyItem save_Class(clsOntologyItem objOItem_Class, bool boolRoot = false) 
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.SaveClasses((new List<clsOntologyItem>{ objOItem_Class }).ToArray());
        
            return objOItem_Result;
        }

        public clsOntologyItem save_ObjRel(List<clsObjectRel> oList_ObjectRel )
        {
            var objOItem_Result = WebServiceConnector.OntologyWebSoapClient.SaveObjectRels(oList_ObjectRel.ToArray());
        
            return objOItem_Result;
        }

        public clsOntologyItem save_ObjAtt(List<clsObjectAtt> oList_ObjAtt ) 
        {
            
            var result = WebServiceConnector.OntologyWebSoapClient.SaveObjectAttributes(oList_ObjAtt.ToArray());
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
            var result = WebServiceConnector.OntologyWebSoapClient.SaveObjects(oList_Objects.ToArray());

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

            var result = WebServiceConnector.OntologyWebSoapClient.RelationTypes(OList_RelType.ToArray(),doCount);
            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (doCount)
                {
                    objOItem_Result.Count = result.Count;
                }
                else
                {
                    OList_RelationTypes = new List<clsOntologyItem>(result.OntologyItems);
                    objOItem_Result = result.Result;
                }
                
            }
            else
            {
                objOItem_Result = result.Result;

            
            }
            
            return objOItem_Result;
        }

        public clsOntologyItem get_Data_AttributeType(List<clsOntologyItem> OList_AttType = null,
                                               bool doCount = false) 
        {
            this.OList_AttributeTypes.Clear();
            var objOItem_Result = objLogStates.LogState_Success;

            var result = WebServiceConnector.OntologyWebSoapClient.AttributeTypes(OList_AttType.ToArray(), doCount);
            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (doCount)
                {
                    objOItem_Result.Count = result.Count;
                }
                else
                {
                    this.OList_AttributeTypes = new List<clsOntologyItem>( result.OntologyItems );
                }
            }
            else
            {
                objOItem_Result = result.Result;
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
            var objOItem_Result = objLogStates.LogState_Success;

            var result = WebServiceConnector.OntologyWebSoapClient.ClassAttributes(oList_Class.ToArray(), oList_AttributeTyp.ToArray(), boolIDs, doCount);
            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (doCount)
                {
                    objOItem_Result.Count = result.Count;
                }
                else
                {
                    if (boolIDs)
                    {
                        this.OList_ClassAtt_ID = new List<clsClassAtt>(result.ClassAttributes);
                    }
                    else
                    {
                        this.OList_ClassAtt = new List<clsClassAtt>(result.ClassAttributes);

                    }
                }
            }
            else
            {
                return result.Result;
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
            var objOItem_Result = objLogStates.LogState_Success;
            var result = WebServiceConnector.OntologyWebSoapClient.ClassRelations(OList_ClassRel.ToArray(), boolIDs, boolOR, doCount);
            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (doCount)
                {
                    objOItem_Result.Count = result.Count;
                }
                else
                {
                    if (boolIDs)
                    {
                        this.OList_ClassRel_ID = new List<clsClassRel>( result.ClassRelations );
                    }
                    else
                    {
                        this.OList_ClassRel = new List<clsClassRel>(result.ClassRelations);
                    }

                }
            }
            else
            {
                objOItem_Result = result.Result;
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
            var objOItem_Result = objLogStates.LogState_Success;

            var result = WebServiceConnector.OntologyWebSoapClient.ObjectAtts(oList_ObjectAtt.ToArray(), boolIDs, doCount);

            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (doCount)
                {
                    objOItem_Result.Count = result.Count;
                }
                else
                {
                    if (boolIDs)
                    {
                        this.OList_ObjAtt_ID = new List<clsObjectAtt>(result.ObjectAttributes);
                    }
                    else
                    {
                        this.OList_ObjAtt = new List<clsObjectAtt>(result.ObjectAttributes);
                    }
                }
            }
            else
            {
                objOItem_Result = result.Result;
            }
            

            return objOItem_Result;
        }

        public long get_Data_Att_OrderID(clsOntologyItem OItem_Object = null,
                                             clsOntologyItem OItem_AttributeType = null,
                                             bool doASC = true)
        {
        
            string strSortField;

            strSortField = "OrderID:";

            var result = WebServiceConnector.OntologyWebSoapClient.ObjectAttributesOrderId(OItem_Object, OItem_AttributeType, strSortField, doASC);

            return result.OrderId;

        }

        public long get_Data_Att_OrderByVal(string strOrderField,
                                         clsOntologyItem OItem_Object = null,
                                             clsOntologyItem OItem_AttributeType = null,
                                             bool doASC = true)
        {
            var result = WebServiceConnector.OntologyWebSoapClient.ObjectAttributesOrderByVal(strOrderField, OItem_Object, OItem_AttributeType, doASC);
            var lngOrderID = result.OrderId;

            return lngOrderID;
        }

        public long get_Data_Rel_OrderID(clsOntologyItem OItem_Left = null,
                                             clsOntologyItem OItem_Right = null,
                                             clsOntologyItem OItem_RelationType = null,
                                             bool doASC = true)
        {

            var result = WebServiceConnector.OntologyWebSoapClient.ObjectRelationsOrderId(OItem_Left, OItem_Right, OItem_RelationType, doASC);
        
            return result.OrderId;
        }

        public clsOntologyItem get_Data_ObjectRel(List<clsObjectRel> oList_ObjectRel,
                                           bool boolIDs = true,
                                           bool doCount = false,
                                           string Direction = null,
                                           bool doJoin_Left = false,
                                           bool doJoin_right = false) 
        {
            this.OList_ObjectRel_ID.Clear();
            this.OList_ObjectRel.Clear();
            var objOItem_Result = objLogStates.LogState_Success;

            var result = WebServiceConnector.OntologyWebSoapClient.ObjectRels(oList_ObjectRel.ToArray(), boolIDs, doCount);

            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (doCount)
                {
                    objOItem_Result.Count = result.Count;
                }
                else
                {
                    if (boolIDs)
                    {
                        this.OList_ObjectRel_ID = new List<clsObjectRel>(result.ObjectRelations);
                    }
                    else
                    {
                        this.OList_ObjectRel = new List<clsObjectRel>(result.ObjectRelations);
                    }
                }
                
            }
            else
            {
                objOItem_Result = result.Result;
            }
            

            return objOItem_Result;
        }

        public clsOntologyItem get_Data_DataTyps(List<clsOntologyItem> oList_DataTypes = null,
                                          bool doCount = false)
        {
            this.OList_DataTypes.Clear();
            var objOItem_Result = objLogStates.LogState_Success;

            var result = WebServiceConnector.OntologyWebSoapClient.DataTypes(oList_DataTypes.ToArray(), doCount);

            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (doCount)
                {
                    objOItem_Result.Count = result.Count;
                }
                else
                {
                    this.OList_DataTypes = new List<clsOntologyItem>( result.OntologyItems);

                }
            }
            else
            {
                objOItem_Result = result.Result;
            }
            

        
            return objOItem_Result;
        }

        public clsOntologyItem get_Data_Objects_Tree(clsOntologyItem objOItem_Class_Par,
                                              clsOntologyItem objOitem_Class_Child,
                                              clsOntologyItem objOItem_RelationType,
                                              bool doCount = false)
        {
            this.OList_ObjectTree.Clear();
            this.OList_Objects.Clear();
            this.OList_Objects2.Clear();
            var objOItem_Result = objLogStates.LogState_Success;

            var result = WebServiceConnector.OntologyWebSoapClient.ObjectTree(objOItem_Class_Par, objOitem_Class_Child, objOItem_RelationType, doCount);

            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (doCount)
                {
                    objOItem_Result.Count = result.Count;
                }
                else
                {
                    this.OList_ObjectTree = new List<clsObjectTree>( result.ObjectTrees );
                    this.OList_Objects =  new List<clsOntologyItem>( result.OntologyItems1 );
                    this.OList_Objects2 = new List<clsOntologyItem>( result.OntologyItems2 );

                }
            }
            else
            {
                objOItem_Result = result.Result;
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
            var objOItem_Result = objLogStates.LogState_Success;

            var result = WebServiceConnector.OntologyWebSoapClient.Objects(oList_Objects.ToArray(), doCount);
        
            if (result.Result.GUID == objLogStates.LogState_Success.GUID)
            {
                if (!List2)
                {
                    if (boolExact)
                    {
                        var objects = (from objectItem in result.OntologyItems
                                       join objItm in oList_Objects on objectItem.Name equals objItm.Name
                                       select objectItem).ToList();
                        this.OList_Objects = objects;
                    }
                    else
                    {
                        this.OList_Objects = new List<clsOntologyItem>(result.OntologyItems);
                    }
                    
                }
                else
                {
                    if (boolExact)
                    {
                        var objects = (from objectItem in result.OntologyItems
                                       join objItm in oList_Objects on objectItem.Name equals objItm.Name
                                       select objectItem).ToList();
                        this.OList_Objects2 = objects;
                    }
                    else
                    {
                        this.OList_Objects2 = new List<clsOntologyItem>(result.OntologyItems);
                    }
                    
                }
            }
            else
            {
                objOItem_Result = result.Result;
            }

            

            return objOItem_Result;
        }



        public clsOntologyItem create_Report_ES(clsOntologyItem objOItem_Report)
        {
            var objOItem_Result = objLogStates.LogState_Success;

            return objOItem_Result;
        }

        public bool test_Index_Es()
        {

            return WebServiceConnector.OntologyWebSoapClient.IndexExists(strIndex);
        
        }

        public bool create_Index_Es() 
        {
            var result = WebServiceConnector.OntologyWebSoapClient.CreateIndex(strIndex);
            return result;
            
        }

        public clsOntologyItem get_Data_Classes(List<clsOntologyItem> OList_Classes = null,
                                     bool doClassesRight = false,
                                     bool doASC = true,
                                     bool doCount = false)
        {
            this.OList_Classes.Clear();
            this.OList_Classes2.Clear();
            var objOItem_Result = objLogStates.LogState_Success;

            

            var result = WebServiceConnector.OntologyWebSoapClient.Classes(OList_Classes.ToArray(), doCount);

            if (doCount)
            {
                objOItem_Result.Count = result.Count;
            }
            else 
            {
                if (!doClassesRight)
                {
                    if (doASC)
                    {
                        this.OList_Classes = new List<clsOntologyItem>(result.OntologyItems.OrderBy(cls => cls.Name));
                        
                    }
                    else
                    {
                        this.OList_Classes = new List<clsOntologyItem>(result.OntologyItems.OrderByDescending(cls => cls.Name));
                    }
                    
                
                }
                else 
                {
                    if (doASC)
                    {
                        this.OList_Classes2 = new List<clsOntologyItem>(result.OntologyItems.OrderBy(cls => cls.Name));

                    }
                    else
                    {
                        this.OList_Classes2 = new List<clsOntologyItem>(result.OntologyItems.OrderByDescending(cls => cls.Name));
                    }
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetOItem(string GUID_Item, string Type_Item ) 
        {
            return WebServiceConnector.OntologyWebSoapClient.GetOItem(GUID_Item, Type_Item);
        }    

    public string GetClassPath(clsOntologyItem OItem_Class)
    {
        var result = WebServiceConnector.OntologyWebSoapClient.GetClassPath(OItem_Class.GUID);
        
        if (result.GUID == objLogStates.LogState_Success.GUID)
        {
            return result.Additional1;
        }
        else
        {
            return null;
        }
        
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

            objTypes = WebServiceConnector.OntologyWebSoapClient.OTypes();
            objLogStates = WebServiceConnector.OntologyWebSoapClient.OLogStates();
            objDirections = WebServiceConnector.OntologyWebSoapClient.ODirections();
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
            var oItem_Result = WebServiceConnector.OntologyWebSoapClient.DeleteIndex(strIndex);

            return oItem_Result;
        }



    }
}

