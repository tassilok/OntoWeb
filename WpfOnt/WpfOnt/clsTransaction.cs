using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.Data;

namespace WpfOnt
{
    public class clsTransaction
    {
        private List<clsTransactionItem> objOList_Item = new List<clsTransactionItem>();
        private clsTransactionItem objOItem_TransItem = new clsTransactionItem();
        private DbWork objDBLevel; 
        private clsLogStates objLogStates = new clsLogStates();
        private clsClassTypes objClassTypes = new clsClassTypes();
        private clsTypes objTypes = new clsTypes();
        private clsDataTypes objDataTypes = new clsDataTypes();

        public clsTransactionItem OItem_Last() 
        {
            return objOList_Item.Last();
        }

        public clsOntologyItem del_ObjectAndRelations(clsOntologyItem OItem_Object)
        {
            var objOList_AttributesDel = new List<clsObjectAtt> {new clsObjectAtt {ID_Object = OItem_Object.GUID}};
            var objOList_ObjectsForw = new List<clsObjectRel> {new clsObjectRel {ID_Object = OItem_Object.GUID}};
            var objOList_ObjectsBackw = new List<clsObjectRel> {new clsObjectRel {ID_Other = OItem_Object.GUID}};


            var objOItem_Result = objDBLevel.del_ObjectAtt(objOList_AttributesDel);
            if (objOItem_Result.GUID != objLogStates.LogState_Error.GUID)
            {
                objOItem_Result = objDBLevel.del_ObjectRel(objOList_ObjectsForw);
                if (objOItem_Result.GUID != objLogStates.LogState_Error.GUID)
                {
                    objOItem_Result = objDBLevel.del_ObjectRel(objOList_ObjectsBackw);
                    if (objOItem_Result.GUID != objLogStates.LogState_Error.GUID)
                    {
                        objOItem_Result = objDBLevel.del_Objects(new List<clsOntologyItem> {OItem_Object});
                    }
                }
            }
            
            return objOItem_Result;
        }
        
        public clsOntologyItem do_Transaction(object OItem_Item, bool boolRemoveAll = false, bool boolRemoveItem = false)
        {
            clsOntologyItem objOItem_Result = objLogStates.LogState_Error.Clone();
            List<clsOntologyItem> objOL_Items = new List<clsOntologyItem>();
            List<clsObjectAtt> objOL_AItems = new List<clsObjectAtt>();
            List<clsObjectRel> objOL_RItems = new List<clsObjectRel>();
            List<clsClassAtt> objOL_CLaItems = new List<clsClassAtt>();
            List<clsClassRel> objOL_ClrItems = new List<clsClassRel>();

            objOItem_TransItem = new clsTransactionItem();

            objOItem_TransItem.Removed = boolRemoveItem;

            if (OItem_Item.GetType().Name == objClassTypes.ClassType_ObjectAtt)
            {
                objOItem_TransItem.OItem_ObjectAtt = (clsObjectAtt)OItem_Item;
                objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolRemoveAll=boolRemoveAll);
                if (boolRemoveItem == false)
                {
                    if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                    {

                        objOL_AItems.Add((clsObjectAtt)OItem_Item);
                        objOItem_Result = objDBLevel.save_ObjAtt(objOL_AItems);
                        if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                        {
                            objOItem_TransItem.OItem_ObjectAtt.ID_Attribute = objDBLevel.OAList_Saved.First().ID_Attribute;
                        }
                    }

                }

                objOItem_TransItem.TransactionResult = objOItem_Result;
            }
            else if (OItem_Item.GetType().Name == objClassTypes.ClassType_ObjectRel)       
            {


                objOItem_TransItem.OItem_ObjectRel = (clsObjectRel) OItem_Item;
                if (objOItem_TransItem.OItem_ObjectRel.Ontology == objTypes.ObjectType)
                {
                    objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolRemoveAll=boolRemoveAll);
                }
                else
                {
                    objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolNeutral:true, boolRemoveAll:boolRemoveAll);
                }

                if (boolRemoveItem == false)
                {
                    if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                    {
                        objOL_RItems.Add((clsObjectRel)OItem_Item);
                        objOItem_Result = objDBLevel.save_ObjRel(objOL_RItems);
                    }
                }


                objOItem_TransItem.TransactionResult = objOItem_Result;
            }
            else if (OItem_Item.GetType().Name == objClassTypes.ClassType_ClassAtt)       
            {

                objOItem_TransItem.OItem_ClassAtt = (clsClassAtt) OItem_Item;
                objOItem_Result = clear_Relations(objClassTypes.ClassType_ObjectAtt, boolRemoveAll=boolRemoveAll);
                if (boolRemoveItem == false)
                {
                    if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                    {
                        objOL_CLaItems.Add((clsClassAtt)OItem_Item);
                        objOItem_Result = objDBLevel.save_ClassAttType(objOL_CLaItems);
                    }
                }


                objOItem_TransItem.TransactionResult = objOItem_Result;
            }
            else if (OItem_Item.GetType().Name == objClassTypes.ClassType_ClassRel)       
            {
                objOItem_TransItem.OItem_ClassRel = (clsClassRel)OItem_Item;
                objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolRemoveAll=boolRemoveAll);

                if (boolRemoveItem == false)
                {
                    if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                    {
                        objOL_ClrItems.Add((clsClassRel) OItem_Item);
                        objOItem_Result = objDBLevel.save_ClassRel(objOL_ClrItems);
                    }

                }

                objOItem_TransItem.TransactionResult = objOItem_Result;
            }
            else if (OItem_Item.GetType().Name == objClassTypes.ClassType_OntologyItem)       
            {
                objOItem_TransItem.OItem_OntologyItem = (clsOntologyItem)OItem_Item;
                if (boolRemoveItem == false)
                {
                    objOL_Items.Add((clsOntologyItem) OItem_Item);
                    if (objOItem_TransItem.OItem_OntologyItem.Type == objTypes.AttributeType)
                    {
                        objOItem_Result = objDBLevel.save_AttributeType((clsOntologyItem)OItem_Item);
                        objOItem_TransItem.TransactionResult = objOItem_Result;
                    }
                    else if (objOItem_TransItem.OItem_OntologyItem.Type == objTypes.ClassType)
                    {
                        objOItem_Result = objDBLevel.save_Class((clsOntologyItem)OItem_Item);
                        objOItem_TransItem.TransactionResult = objOItem_Result;
                    }
                    else if (objOItem_TransItem.OItem_OntologyItem.Type == objTypes.ObjectType)
                    {
                        objOItem_Result = objDBLevel.save_Objects(objOL_Items);
                        objOItem_TransItem.TransactionResult = objOItem_Result;
                    }
                    else if (objOItem_TransItem.OItem_OntologyItem.Type == objTypes.RelationType)
                    {
                        objOItem_Result = objDBLevel.save_RelationType((clsOntologyItem)OItem_Item);
                        objOItem_TransItem.TransactionResult = objOItem_Result;
                    }
                    else
                    {
                        objOItem_TransItem.TransactionResult = objLogStates.LogState_Error.Clone();
                    }
                }
                else
                {
                    objOL_Items.Add((clsOntologyItem)OItem_Item);
                    if (objOItem_TransItem.OItem_OntologyItem.Type == objTypes.AttributeType)
                    {
                        objOItem_Result = objDBLevel.del_AttributeType(objOL_Items);
                        objOItem_TransItem.TransactionResult = objOItem_Result;
                    }
                    else if (objOItem_TransItem.OItem_OntologyItem.Type == objTypes.ClassType)
                    {
                        objOItem_Result = objDBLevel.del_Class(objOL_Items);
                        objOItem_TransItem.TransactionResult = objOItem_Result;
                    }
                    else if (objOItem_TransItem.OItem_OntologyItem.Type == objTypes.ObjectType)
                    {
                        objOItem_Result = objDBLevel.del_Objects(objOL_Items);
                        objOItem_TransItem.TransactionResult = objOItem_Result;
                    }
                    else if (objOItem_TransItem.OItem_OntologyItem.Type == objTypes.RelationType)
                    {
                        objOItem_Result = objDBLevel.del_RelationTypes(objOL_Items);
                        objOItem_TransItem.TransactionResult = objOItem_Result;
                    }
                    else
                    {
                        objOItem_TransItem.TransactionResult = objLogStates.LogState_Error;
                    }
                    
                }



            }

            objOList_Item.Add(objOItem_TransItem);

            return objOItem_Result;
        }

        public clsOntologyItem fill_TransactionList(Object OItem_Item, bool boolRemoveAll = false)
        {
            var objOItem_Result = objLogStates.LogState_Error.Clone();
            var objOL_Items = new List<clsOntologyItem>();
            var objOL_AItems = new  List<clsObjectAtt>();
            var objOL_RItems = new List<clsObjectRel>();
            var objOL_CLaItems = new List<clsClassAtt>();
            var objOL_ClrItems = new List<clsClassRel>();

            objOItem_TransItem = new clsTransactionItem();

            if (OItem_Item.GetType().Name == objClassTypes.ClassType_ObjectAtt)
            {
                objOItem_TransItem.OItem_ObjectAtt = (clsObjectAtt) OItem_Item;

                if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                {
                    objOL_AItems.Add((clsObjectAtt)OItem_Item);

                }

                objOItem_TransItem.TransactionResult = objOItem_Result;
            }
            else if (OItem_Item.GetType().Name == objClassTypes.ClassType_ObjectRel)
            {
                objOItem_TransItem.OItem_ObjectRel = (clsObjectRel) OItem_Item;

                if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                {
                    objOL_RItems.Add((clsObjectRel)OItem_Item);
                }

                objOItem_TransItem.TransactionResult = objOItem_Result;
            }
            else if (OItem_Item.GetType().Name == objClassTypes.ClassType_ClassAtt)
            {
                objOItem_TransItem.OItem_ClassAtt = (clsClassAtt) OItem_Item;

                if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                {
                    objOL_CLaItems.Add((clsClassAtt) OItem_Item);

                }

                objOItem_TransItem.TransactionResult = objOItem_Result;
            }
            else if (OItem_Item.GetType().Name == objClassTypes.ClassType_ClassRel)
            {
                objOItem_TransItem.OItem_ClassRel = (clsClassRel)OItem_Item;

                if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
                {
                    objOL_ClrItems.Add((clsClassRel)OItem_Item);

                }

                objOItem_TransItem.TransactionResult = objOItem_Result;
            }
            else if (OItem_Item.GetType().Name == objClassTypes.ClassType_OntologyItem)
            {
                   objOItem_TransItem.OItem_OntologyItem = (clsOntologyItem)OItem_Item;
                    objOL_Items.Add((clsOntologyItem)OItem_Item);
            }

            objOList_Item.Add(objOItem_TransItem);

            return objOItem_Result;
        }
        
        public clsOntologyItem rollback()
        {
            var objOItem_Result = objLogStates.LogState_Error.Clone();

            clsTransactionItem objTransactionItem;

            if (objOList_Item.Any())
            {
                for (var i = objOList_Item.Count - 1; i >= 0;i--)
                {
                    objTransactionItem = objOList_Item[i];
                    objOItem_Result = rollback_One(objTransactionItem);
                    if (objOItem_Result.GUID == objLogStates.LogState_Error.GUID)
                    {
                        break;
                    }
                }
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Error.Clone();
            }

            return objOItem_Result;
        }
        
        private clsOntologyItem rollback_One(clsTransactionItem objTransactionItem)
        {
            clsOntologyItem objOItem_Result;
            var objOItem_Class = new clsOntologyItem();
            var objOItem_AttributeType = new clsOntologyItem();
            var objOLClassAtt = new List<clsClassAtt>();
            var objOLClassRel = new List<clsClassRel>();
            var objOLObjAtt = new List<clsObjectAtt>();
            var objOLObjRel = new List<clsObjectRel>();
            var objOLOntologyItem = new List<clsOntologyItem>();
            var objOLObjAttSaved = new List<clsObjectAtt>();

            if (objTransactionItem.savedType == objClassTypes.ClassType_ClassAtt)
            {
                objOItem_Class.GUID = objTransactionItem.OItem_ClassAtt.ID_Class;
                objOItem_AttributeType.GUID = objTransactionItem.OItem_ClassAtt.ID_AttributeType;

                if (objTransactionItem.Removed == false)
                {
                    objOItem_Result = objDBLevel.del_ClassAttType(objOItem_Class,
                                                              objOItem_AttributeType);
                }
                else
                {
                    objOLClassAtt.Add(objTransactionItem.OItem_ClassAtt);
                    objOItem_Result = objDBLevel.save_ClassAttType(objOLClassAtt);

                }
            }
            else if (objTransactionItem.savedType == objClassTypes.ClassType_ClassRel)
            {
                if (objTransactionItem.Removed == false)
                {
                    objOLClassRel.Add(new clsClassRel(objTransactionItem.OItem_ClassRel.ID_Class_Left,
                                                  objTransactionItem.OItem_ClassRel.ID_Class_Right,
                                                  objTransactionItem.OItem_ClassRel.ID_RelationType,
                                                  null, null, null, null));

                    if (objDBLevel.del_ClassRel(objOLClassRel).Count>0)
                    {
                        objOItem_Result = objLogStates.LogState_Success.Clone();
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Error.Clone();
                    }
                }
                else
                {
                    objOLClassRel.Add(objTransactionItem.OItem_ClassRel);

                    objOItem_Result = objDBLevel.save_ClassRel(objOLClassRel);
                }
            }
            else if (objTransactionItem.savedType == objClassTypes.ClassType_ObjectAtt)
            {
                if (objTransactionItem.Removed == false)
                {
                    if (objTransactionItem.OItem_ObjectAtt.ID_Attribute != null)
                    {
                        objOLObjAtt.Add(new clsObjectAtt(objTransactionItem.OItem_ObjectAtt.ID_Attribute, null, null, null, null));


                        objOItem_Result = objDBLevel.del_ObjectAtt(objOLObjAtt);
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Success.Clone();
                    }
                }
                else
                {
                    objOLObjAtt.Add(objTransactionItem.OItem_ObjectAtt);

                    objOItem_Result = objDBLevel.save_ObjAtt(objOLObjAtt);

                }
            }
            else if (objTransactionItem.savedType == objClassTypes.ClassType_ObjectRel)
            {
                if (objTransactionItem.Removed == false)
                {
                    objOLObjRel.Add(new clsObjectRel
                    {
                        ID_Object = objTransactionItem.OItem_ObjectRel.ID_Object,
                        ID_Other = objTransactionItem.OItem_ObjectRel.ID_Other,
                        ID_RelationType = objTransactionItem.OItem_ObjectRel.ID_RelationType
                    });

                    objOItem_Result = objDBLevel.del_ObjectRel(objOLObjRel);
                }
                else
                {
                    objOLObjRel.Add(objTransactionItem.OItem_ObjectRel);

                    objOItem_Result = objDBLevel.save_ObjRel(objOLObjRel);
                }
            }
            else if (objTransactionItem.savedType == objClassTypes.ClassType_OntologyItem)
            {
                objOLOntologyItem.Add(objTransactionItem.OItem_OntologyItem);
                if (objTransactionItem.Removed == false)
                {
                    objOItem_Result = objDBLevel.del_Objects(objOLOntologyItem);
                }
                else
                {
                    objOItem_Result = objDBLevel.save_Objects(objOLOntologyItem);
                }
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Error.Clone();
            }

            return objOItem_Result;
        }
        
        private clsOntologyItem clear_Relations(string strType, bool boolNeutral = false, bool boolRemoveAll = false)
        {
            var objOItem_Result = objLogStates.LogState_Error.Clone();
            clsOntologyItem objOItem_Result_Search;
            clsOntologyItem objOItem_Result_Del;

            var objOL_ObjAtt = new List<clsObjectAtt>();
            var objOL_ObjAtt_Search = new List<clsObjectAtt>();
            var objOL_ObjAtt_Del = new List<clsObjectAtt>();
            var objOL_ObjRel = new List<clsObjectRel>();
            var objOL_ObjRel_Search = new List<clsObjectRel>();
            var objOL_ObjRel_Del = new List<clsObjectRel>();
            var objOL_ClassRel_Del = new List<clsClassRel>();

            if (strType == objClassTypes.ClassType_ObjectAtt)
            {
                if (boolRemoveAll)
                {
                    objOL_ObjAtt_Del.Add(new clsObjectAtt(null,
                                                  objOItem_TransItem.OItem_ObjectAtt.ID_Object,
                                                  null,
                                                  objOItem_TransItem.OItem_ObjectAtt.ID_AttributeType,
                                                  null));
                    objOItem_Result = objDBLevel.del_ObjectAtt(objOL_ObjAtt_Del);
                }   
                else
                {
                    if (objOItem_TransItem.OItem_ObjectAtt.ID_Attribute != null &&
                        !string.IsNullOrEmpty(objOItem_TransItem.OItem_ObjectAtt.ID_Attribute))
                    {
                        objOL_ObjAtt_Del.Add(new clsObjectAtt(objOItem_TransItem.OItem_ObjectAtt.ID_Attribute,
                                                          null,
                                                          null, 
                                                          null, 
                                                          null));

                        objOItem_Result = objDBLevel.del_ObjectAtt(objOL_ObjAtt_Del);
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Success.Clone();
                    }

                }
            }
            else if (strType == objClassTypes.ClassType_ObjectRel)
            {
                if (boolRemoveAll)
                {

                    if (!boolNeutral)
                    {
                        objOL_ObjRel_Del.Add(new clsObjectRel
                        {
                            ID_Object = objOItem_TransItem.OItem_ObjectRel.ID_Object,
                            ID_Parent_Other = objOItem_TransItem.OItem_ObjectRel.ID_Parent_Other,
                            ID_RelationType = objOItem_TransItem.OItem_ObjectRel.ID_RelationType
                        });
                    }
                    else
                    {
                        objOL_ObjRel_Del.Add(new clsObjectRel
                        {
                            ID_Object = objOItem_TransItem.OItem_ObjectRel.ID_Object,
                            ID_RelationType = objOItem_TransItem.OItem_ObjectRel.ID_RelationType
                        });
                    }

                    objOItem_Result = objDBLevel.del_ObjectRel(objOL_ObjRel_Del);
                }   
                else
                {
                    objOL_ObjRel_Del.Add(objOItem_TransItem.OItem_ObjectRel);
                    objOItem_Result = objDBLevel.del_ObjectRel(objOL_ObjRel_Del);
                }
            }
            else if (strType == objClassTypes.ClassType_ClassRel)
            {
                if (objOItem_TransItem.OItem_ClassRel.ID_Class_Left != null &&
                    objOItem_TransItem.OItem_ClassRel.ID_RelationType != null)
                {
                    objOL_ClassRel_Del.Add(new clsClassRel {ID_Class_Left = objOItem_TransItem.OItem_ClassRel.ID_Class_Left,
                                                             ID_Class_Right = objOItem_TransItem.OItem_ClassRel.ID_Class_Right,
                                                             ID_RelationType = objOItem_TransItem.OItem_ClassRel.ID_RelationType});


                    objOItem_Result = objDBLevel.del_ClassRel(objOL_ClassRel_Del);
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error.Clone();
                }
            }

            if (objOItem_Result.GUID == objLogStates.LogState_Nothing.GUID)
            {
                objOItem_Result = objLogStates.LogState_Success.Clone();
            }

            return objOItem_Result;
        }
        
        public void ClearItems()
        {
            objOList_Item.Clear();
        }

        public clsTransaction(Globals globals)
        {
            objDBLevel = new DbWork(globals.Server, globals.Port, globals.Index, globals.Index_Rep, globals.SearchRange, globals.Session);
            objOList_Item = new List<clsTransactionItem>();
        }

        public clsTransaction(string strServer, int intPort, string strIndex, string strIndexRep, int intSearchRange, string strSession)
        {
            objDBLevel = new DbWork(strServer, intPort, strIndex, strIndexRep, intSearchRange, strSession);
            objOList_Item = new List<clsTransactionItem>();
        }
    
    }
}
