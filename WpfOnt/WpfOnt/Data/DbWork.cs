﻿using System;
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
        private clsFields objFields;
        private clsDirections objDirections;

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
             var result = ontoWebSoapClient.IndexList(strServer, intPort);
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

            var result = ontoWebSoapClient.RelationTypes(OList_RelType.ToArray(),doCount);
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

            var result = ontoWebSoapClient.AttributeTypes(OList_AttType.ToArray(), doCount);
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
            var objOItem_Result = objLogStates.LogState_Success.Clone();

            var result = ontoWebSoapClient.ClassAttributes(oList_Class.ToArray(), oList_AttributeTyp.ToArray(), boolIDs, doCount);
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
            var result = ontoWebSoapClient.ClassRelations(OList_ClassRel.ToArray(), boolIDs, boolOR, doCount);
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

            var result = ontoWebSoapClient.ObjectAtts(oList_ObjectAtt.ToArray(), boolIDs, doCount);

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

            var result = ontoWebSoapClient.ObjectAttributesOrderId(OItem_Object, OItem_AttributeType, strSortField, doASC);

            return result.OrderId;

        }

        public long get_Data_Att_OrderByVal(string strOrderField,
                                         clsOntologyItem OItem_Object = null,
                                             clsOntologyItem OItem_AttributeType = null,
                                             bool doASC = true)
        {
            var result = ontoWebSoapClient.ObjectAttributesOrderByVal(strOrderField, OItem_Object, OItem_AttributeType, doASC);
            var lngOrderID = result.OrderId;

            return lngOrderID;
        }

        public long get_Data_Rel_OrderID(clsOntologyItem OItem_Left = null,
                                             clsOntologyItem OItem_Right = null,
                                             clsOntologyItem OItem_RelationType = null,
                                             bool doASC = true)
        {

            var result = ontoWebSoapClient.ObjectRelationsOrderId(OItem_Left, OItem_Right, OItem_RelationType, doASC);
        
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

            var result = ontoWebSoapClient.ObjectRels(oList_ObjectRel.ToArray(), boolIDs, doCount);

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

            var result = ontoWebSoapClient.DataTypes(oList_DataTypes.ToArray(), doCount);

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

            var result = ontoWebSoapClient.ObjectTree(objOItem_Class_Par, objOitem_Class_Child, objOItem_RelationType, doCount);

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

            var result = ontoWebSoapClient.Objects(oList_Objects.ToArray(), doCount);
        
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
                                     bool doClassesRight = false,
                                     bool doASC = true,
                                     bool doCount = false)
        {
            this.OList_Classes.Clear();
            this.OList_Classes2.Clear();
            var objOItem_Result = objLogStates.LogState_Success;

            

            var result = ontoWebSoapClient.Classes(OList_Classes.ToArray(), doCount);

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

            ontoWebSoapClient = new OntoWebSoapClient();
            objTypes = ontoWebSoapClient.OTypes();
            objLogStates = ontoWebSoapClient.OLogStates();
            objDirections = ontoWebSoapClient.ODirections();
            objFields = ontoWebSoapClient.OFields();
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

