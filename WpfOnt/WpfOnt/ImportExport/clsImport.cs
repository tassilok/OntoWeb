using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.DataClasses;
using WpfOnt.Data;
using System.Xml;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.IO;

namespace WpfOnt.ImportExport
{
    public class clsImport
    {
        private Globals objGlobals;

        private clsDataTypes objDataTypes;

        private DbWork objDBLevel_TestExistance;

        private XmlTextReader objXMLReader;

        private string strPath_Templates;

        private new List<clsOntologyItem> objOList_OItems;
        private List<clsOntologyItem> objOList_Classes;
        private List<clsClassAtt> objOList_ClassAtts;
        private List<clsClassRel> objOList_ClassRel;
        private List<clsObjectAtt> objOList_ObjAtt;
        private List<clsObjectRel> objOList_ObjRel;

        private void ClearLists()
        {
            objOList_OItems.Clear();
            objOList_Classes.Clear();
            objOList_ClassAtts.Clear();
            objOList_ClassRel.Clear();
            objOList_ObjAtt.Clear();
            objOList_ObjRel.Clear();
        }

        public clsOntologyItem ImportTemplates(Assembly objAssembly)
        {
            var objOItem_Result = objGlobals.LState_Success.Clone();

            ClearLists();

            foreach ( var strManifestInfo in objAssembly.GetManifestResourceNames())
            {
                if (!strManifestInfo.ToLower().EndsWith("Template.xml") && strManifestInfo.ToLower().EndsWith(".xml"))
                {
                    var objXMLStream = objAssembly.GetManifestResourceStream(strManifestInfo);
                    objOItem_Result = AddItemsFromXMLStream(objXMLStream);
                    objXMLStream.Close();
                }
            }

            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
            {
                objOItem_Result = SaveItems();
            }

            return objOItem_Result;
        }

        public clsOntologyItem ImportXMLFiles(string strPath)
        {
            var objOItem_Result = objGlobals.LState_Success.Clone();

            ClearLists();

            try
            {
                var fileList = Directory.GetFiles(strPath).Where(f => Path.GetExtension(f).ToLower() == ".xml").ToList();

                foreach (var strFile in fileList)
                {
                    var objStream = new FileStream(strFile, FileMode.Open);

                    objOItem_Result = AddItemsFromXMLStream(objStream);
                    if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
                    {
                        objOItem_Result = SaveItems();
                    }
                    objStream.Close();
                }

                objOItem_Result.Count = fileList.Count;
            }
            catch (Exception ex)
                {
                    objOItem_Result = objGlobals.LState_Error.Clone();
                }

            return objOItem_Result;
        }

        private clsOntologyItem SaveItems()
        {
            var objOItem_Result = objGlobals.LState_Success.Clone();

            if (objOList_Classes.Any())
            {

                objOItem_Result = File(objOList_Classes);

            }

            if (objOList_OItems.Any())
            {
                objOItem_Result = objDBLevel_TestExistance.save_Objects(objOList_OItems);
            }

            if (objOList_ClassAtts.Any())
            {
                objOItem_Result = objDBLevel_TestExistance.save_ClassAttType(objOList_ClassAtts);
            }

            if (objOList_ClassRel.Any())
            {
                objOItem_Result = objDBLevel_TestExistance.save_ClassRel(objOList_ClassRel);
            }

            if (objOList_ObjAtt.Any())
            {
                var objOList_OAtt_Saved = objDBLevel_TestExistance.save_ObjAtt(objOList_ObjAtt);
                var lngCount = objOList_ObjAtt.Count - objOList_OAtt_Saved.Count;

                if (lngCount == 0)
                {
                    objOItem_Result = objGlobals.LState_Success.Clone();
                }
                else
                {
                    objOItem_Result = objGlobals.LState_Error.Clone();
                }

            }

            if (objOList_ObjRel.Any())
            {
                objOItem_Result = objDBLevel_TestExistance.save_ObjRel(objOList_ObjRel);
            }

            return objOItem_Result;
        }

        private clsOntologyItem AddItemsFromXMLStream(Stream objXMLStream)
        {
            string strType;
            var objOItem_Result = objGlobals.LState_Success.Clone();


            objXMLReader = new XmlTextReader(objXMLStream);
            objXMLReader.ReadToDescendant("Items");
            if (objXMLReader.LocalName == "Items")
            {
                strType = objXMLReader.GetAttribute("Type");
                if (!string.IsNullOrEmpty( strType))
                {
                    while (objXMLReader.ReadToFollowing("Item"))
                    {
                        if (strType == objGlobals.Type_AttributeType)
                        {
                            var ID = objXMLReader.GetAttribute("Id");
                            var ID_Parent = objXMLReader.GetAttribute("Id_Parent");
                            objXMLReader.Read();
                            var Name = objXMLReader.Value;
                            var objOItem_Item = new clsOntologyItem {GUID = ID, 
                                                                            Name = Name, 
                                                                            GUID_Parent = ID_Parent, 
                                                                            Type = objGlobals.Type_AttributeType};

                            objOItem_Result = objDBLevel_TestExistance.save_AttributeType(objOItem_Item);
                            if (objOItem_Result.GUID == objGlobals.LState_Error.GUID)
                            {
                                break;
                            }
                        } 
                        else if (strType == objGlobals.Type_Class)
                        {
                            var ID = objXMLReader.GetAttribute("Id");
                            var ID_Parent = objXMLReader.GetAttribute("Id_Parent");
                            objXMLReader.Read();
                            var Name = objXMLReader.Value;
                            var objOItem_Item = new clsOntologyItem {GUID = ID, 
                                                                     Name = Name,
                                                                     GUID_Parent = string.IsNullOrEmpty( ID_Parent) ? null : ID_Parent,
                                                                     Type = objGlobals.Type_Class};
                            objOList_Classes.Add(objOItem_Item);

                        } 
                        else if (strType == objGlobals.Type_Object)
                        {
                            var ID = objXMLReader.GetAttribute("Id");
                            var ID_Parent = objXMLReader.GetAttribute("Id_Parent");
                            objXMLReader.Read();
                            var Name = objXMLReader.Value;
                            var objOItem_Item = new clsOntologyItem {GUID = ID, 
                                                                     Name = Name,
                                                                     GUID_Parent = string.IsNullOrEmpty( ID_Parent) ? null : ID_Parent,
                                                                     Type = objGlobals.Type_Object};
                            objOList_Classes.Add(objOItem_Item);
                        }
                        else if (strType == objGlobals.Type_RelationType)
                        {
                            var ID = objXMLReader.GetAttribute("Id");
                            objXMLReader.Read();
                            var Name = objXMLReader.Value;
                            var objOItem_Item = new clsOntologyItem {GUID = ID, 
                                                                     Name = Name,
                                                                     Type = objGlobals.Type_RelationType};
                            
                            objOItem_Result = objDBLevel_TestExistance.save_RelationType(objOItem_Item);
                            if (objOItem_Result.GUID == objGlobals.LState_Error.GUID)
                            {
                                break;
                            }
                        }
                        else if (strType == objGlobals.Type_RelationType)
                        {
                            var ID_AttributeType = objXMLReader.GetAttribute("Id_AttributeType");
                            var ID_Class = objXMLReader.GetAttribute("Id_Class");
                            var ID_DataType = objXMLReader.GetAttribute("Id_DataType");
                            var Min = int.Parse(objXMLReader.GetAttribute("Min"));
                            var Max = int.Parse(objXMLReader.GetAttribute("Max"));

                            objXMLReader.Read();
                            var Name = objXMLReader.Value;

                            objOList_ClassAtts.Add(new clsClassAtt {ID_AttributeType = ID_AttributeType,
                                                                            ID_Class = ID_Class,
                                                                            ID_DataType = ID_DataType, 
                                                                            Min = Min,
                                                                            Max = Max});
                        }
                        else if (strType == objGlobals.Type_ClassRel)
                        {
                            var ID_Class_Left = objXMLReader.GetAttribute("Id_Class_Left");
                            var ID_Class_Right = objXMLReader.GetAttribute("Id_Class_Right");
                            var ID_RelationType = objXMLReader.GetAttribute("Id_RelationType");
                            var Min_Forw = long.Parse(objXMLReader.GetAttribute("Min_Forw"));
                            var Max_Forw = long.Parse(objXMLReader.GetAttribute("Max_Forw"));
                            var Max_Backw = long.Parse(objXMLReader.GetAttribute("Max_Backw"));
                            var Ontology = objXMLReader.GetAttribute("Ontology");

                            objXMLReader.Read();
                            var Name = objXMLReader.Value;

                            objOList_ClassRel.Add(new clsClassRel {ID_Class_Left = ID_Class_Left,
                                                                             ID_Class_Right = string.IsNullOrEmpty( ID_Class_Right) ? null : ID_Class_Right,
                                                                             ID_RelationType = ID_RelationType,
                                                                             Min_Forw = Min_Forw,
                                                                             Max_Forw = Max_Forw,
                                                                            Max_Backw = Max_Backw,
                                                                            Ontology = Ontology});
                        }
                        else if (strType == objGlobals.Type_ObjectAtt)
                        {
                            var Id_Attribute = objXMLReader.GetAttribute("Id_Attribute");
                            var Id_AttributeType = objXMLReader.GetAttribute("Id_AttributeType");
                            var Id_DataType = objXMLReader.GetAttribute("Id_DataType");
                            var Id_Object = objXMLReader.GetAttribute("Id_Object");
                            var Id_Class = objXMLReader.GetAttribute("Id_Class");
                            var OrderId = objXMLReader.GetAttribute("OrderId");
                            string Val_Named = null;
                            bool boolVal;
                            bool? Val_Bit = null;
                            DateTime dateVal;
                            DateTime? Val_Date = null;
                            double dblVal;
                            double? Val_Double = null;
                            long lngVal;
                            long? Val_Lng = null;
                            string Val_String = null;
                            long? orderId;

                            long lngTmp;
                            if (long.TryParse(OrderId, out lngTmp))
                            {
                                orderId = lngTmp;
                            }
                            else
                            {
                                orderId = null;
                            }
                            
                            if (objXMLReader.ReadToDescendant("Val_Named"))
                            {

                                Val_Named = System.Web.HttpUtility.HtmlDecode(objXMLReader.ReadElementContentAsString());
                                if (string.IsNullOrEmpty( Val_Named))
                                {
                                    Val_Named = null;
                                }

                            }
                            if (objXMLReader.ReadToFollowing("Val_Bit"))
                            {
                                var strValue = objXMLReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty( strValue ))
                                {
                                    if (Boolean.TryParse(strValue, out boolVal))
                                    {
                                        Val_Bit = boolVal;
                                    }
                                    else
                                    {

                                        Val_Bit = null;

                                    }
                                }
                                else
                                {
                                    Val_Bit = null;
                                }

                            }

                            if (objXMLReader.ReadToFollowing("Val_Date"))
                            {

                                var strValue = objXMLReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty( strValue ))
                                {
                                    if (DateTime.TryParse(strValue, out dateVal))
                                    {
                                        Val_Date = dateVal;
                                    }
                                    else
                                    {

                                        Val_Date = null;

                                    }
                                }
                                else
                                {
                                    Val_Date = null;
                                }

                            }

                            if (objXMLReader.ReadToFollowing("Val_Double") )
                            {

                                var strValue = objXMLReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty( strValue ))
                                {
                                    if (Double.TryParse(strValue, out dblVal))
                                    {
                                        Val_Double = dblVal;
                                    }
                                    else
                                    {

                                        Val_Double = null;

                                    }
                                }
                                else
                                {
                                    Val_Double = null;
                                }

                            }

                            if (objXMLReader.ReadToFollowing("Val_Lng"))
                            {

                                var strValue = objXMLReader.ReadElementContentAsString();
                                if (!string.IsNullOrEmpty( strValue))
                                {
                                    if (long.TryParse(strValue, out lngVal))
                                    {
                                        Val_Lng = lngVal;
                                    }
                                    else
                                    {

                                        Val_Lng = null;

                                    }
                                }
                                else
                                {
                                    Val_Lng = null;
                                }

                            }

                            if (objXMLReader.ReadToFollowing("Val_String"))
                            {

                                Val_String = System.Web.HttpUtility.HtmlDecode(objXMLReader.ReadElementContentAsString());
                                if (string.IsNullOrEmpty( Val_String))
                                {
                                    Val_String = null;
                                }
                            }

                            objOList_ObjAtt.Add(new clsObjectAtt {ID_Attribute = Id_Attribute, 
                                                                        ID_AttributeType = Id_AttributeType,
                                                                        ID_DataType = Id_DataType, 
                                                                        ID_Object = Id_Object, 
                                                                        ID_Class = Id_Class,
                                                                        OrderID = orderId, 
                                                                        Val_Named = Val_Named, 
                                                                        Val_Bit = Val_Bit, 
                                                                        Val_Date = Val_Date, 
                                                                        Val_Double = Val_Double, 
                                                                        Val_Lng = Val_Lng, 
                                                                           Val_String = Val_String});

                        }
                        else if (strType == objGlobals.Type_ObjectRel)
                        {
                            var Id_Object = objXMLReader.GetAttribute("Id_Object");
                            var Id_Parent_Object = objXMLReader.GetAttribute("Id_Parent_Object");
                            var Id_Other = objXMLReader.GetAttribute("Id_Other");
                            var Id_Parent_Other = objXMLReader.GetAttribute("Id_Parent_Other");
                            var Id_RelationType = objXMLReader.GetAttribute("Id_RelationType");
                            var OrderId = long.Parse(objXMLReader.GetAttribute("OrderId"));
                            var Ontology = objXMLReader.GetAttribute("Ontology");

                            objOList_ObjRel.Add(new clsObjectRel {ID_Object = Id_Object, 
                                                                        ID_Parent_Object = Id_Parent_Object, 
                                                                        ID_Other = Id_Other, 
                                                                        ID_Parent_Other = string.IsNullOrEmpty(Id_Parent_Other) ?  null :Id_Parent_Other, 
                                                                        ID_RelationType = Id_RelationType, 
                                                                        OrderID = OrderId, 
                                                                        Ontology = Ontology});
                        }
                    }


                }
            }
            objXMLReader.Close();

            return objOItem_Result;
        }

        private clsOntologyItem File(List<clsOntologyItem> objOList_Classes, clsOntologyItem objOItem_Class = null)
        {
            var objOList_ClassesForImport = objOList_Classes.Where(p => p.GUID_Parent == (objOItem_Class == null ? "" : objOItem_Class.GUID)).ToList();
            var objOItem_Result = (objOItem_Class != null ? objDBLevel_TestExistance.save_Class(objOItem_Class, string.IsNullOrEmpty(objOItem_Class.GUID_Parent) ? true : false) : objGlobals.LState_Success);
            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
            {
                foreach (var objOItem_Class_Sub in objOList_ClassesForImport)
                {
                    objOItem_Result = File(objOList_Classes, objOItem_Class_Sub);
                    if (objOItem_Result.GUID == objGlobals.LState_Error.GUID)
                    {
                        break;
                    }
                }
            }
            return objOItem_Result;
        }

        public clsImport(Globals globals)
        {
            objGlobals = globals;
            Initialize();
        }

        private void Initialize()
        {
            strPath_Templates = "Config" + Path.DirectorySeparatorChar + "Templates";
            objDBLevel_TestExistance = new DbWork(objGlobals);
        }
    }
}
