using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.ESTypes;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace ElasticSearchNestConnector
{
    [Flags]
    public enum CopyItem
    {
        AttributeTypes = 1,
        RelationTypes = 2,
        Classes = 4,
        Objects = 8,
        ClassAttributes = 16,
        ClassRelations = 32,
        ObjectAttributes = 64,
        ObjectRelations = 128,
        DataTypes = 256
    }
    public class clsCopyIndex
    {
        private clsDBSelector objDBSelector_Src;
        private clsDBSelector objDBSelector_Dst;
        private clsDBUpdater objDBUpdater;
        private clsLogStates objLogStates = new clsLogStates();
        private clsClasses objClasses = new clsClasses();

        public List<clsOntologyItem> OList_AttributeTypes { get; set; }
        public List<clsOntologyItem> OList_RelationTypes { get; set; }
        public List<clsOntologyItem> OList_Classes { get; set; }
        public List<clsOntologyItem> OList_Objects { get; set; }
        public List<clsClassAtt> OList_ClassAttributes { get; set; }
        public List<clsClassRel> OList_ClassRelations { get; set; }
        public List<clsObjectAtt> OList_ObjectAttributes { get; set; }
        public List<clsObjectRel> OList_ObjectRelations { get; set; }
        public List<clsOntologyItem> OList_DataTypes { get; set; }

        public void ClearLists()
        {
            OList_AttributeTypes.Clear();
            OList_ClassAttributes.Clear();
            OList_Classes.Clear();
            OList_ClassRelations.Clear();
            OList_ObjectAttributes.Clear();
            OList_ObjectRelations.Clear();
            OList_Objects.Clear();
            OList_RelationTypes.Clear();
            OList_DataTypes.Clear();
        }

        public clsCopyIndex(clsDBSelector dbSelector_src)
        {
            objDBSelector_Src = dbSelector_src;
            Initialize();
        }

        private void Initialize()
        {
            OList_AttributeTypes = new List<clsOntologyItem>();
            OList_ClassAttributes = new List<clsClassAtt>();
            OList_Classes = new List<clsOntologyItem>();
            OList_ClassRelations = new List<clsClassRel>();
            OList_ObjectAttributes = new List<clsObjectAtt>();
            OList_ObjectRelations = new List<clsObjectRel>();
            OList_Objects = new List<clsOntologyItem>();
            OList_RelationTypes = new List<clsOntologyItem>();
            OList_DataTypes = new List<clsOntologyItem>();
        }

        public clsOntologyItem CopyIndex(string index_dst, CopyItem copyItem)
        {
            var result = objLogStates.LogState_Success.Clone();

            objDBSelector_Dst = new clsDBSelector(objDBSelector_Src.Server, objDBSelector_Src.Port, index_dst, objDBSelector_Src.IndexRep, objDBSelector_Src.SearchRange, objDBSelector_Src.Session);

            objDBUpdater = new clsDBUpdater(objDBSelector_Dst);

            if (copyItem.HasFlag(CopyItem.DataTypes))
            {
                if (!OList_DataTypes.Any())
                {
                    OList_DataTypes = objDBSelector_Src.get_Data_DataTypes();
                }

                
                result = objDBUpdater.save_DataTypes(OList_DataTypes);

            }

            if (copyItem.HasFlag(CopyItem.AttributeTypes))
            {
                if (!OList_AttributeTypes.Any())
                {
                   OList_AttributeTypes = objDBSelector_Src.get_Data_AttributeType();
                }


                foreach (var oItem_AttributeType in OList_AttributeTypes)
                {
                    result = objDBUpdater.save_AttributeType(oItem_AttributeType);

                    if (result.GUID == objLogStates.LogState_Error.GUID)
                    {
                        break;
                    }
                }
            }

            if (copyItem.HasFlag(CopyItem.RelationTypes))
            {
                if (!OList_RelationTypes.Any())
                {
                    OList_RelationTypes = objDBSelector_Src.get_Data_RelationTypes();
                }
                
                foreach (var oItem_RelationType in OList_RelationTypes)
                {
                    result = objDBUpdater.save_RelationType(oItem_RelationType);
                    if (result.GUID == objLogStates.LogState_Error.GUID)
                    {
                        break;
                    }
                }
            }

            if (copyItem.HasFlag(CopyItem.Classes))
            {
                if (!OList_Classes.Any())
                {
                    OList_Classes = objDBSelector_Src.get_Data_Classes();
                }

                foreach (var oItem_Class in OList_Classes)
                {
                    
                    result = objDBUpdater.save_Class(oItem_Class, oItem_Class.GUID == objClasses.OItem_Class_Root.GUID);
                    
                    if (result.GUID == objLogStates.LogState_Error.GUID)
                    {
                        break;
                    }
                }
            }

            if (copyItem.HasFlag(CopyItem.Objects))
            {
                if (!OList_Objects.Any())
                {
                    OList_Objects = objDBSelector_Src.get_Data_Objects();
                }

                //result = objDBUpdater.save_Objects(OList_Objects);

                var start = 0;

                while (start < OList_Objects.Count)
                {

                    var length = objDBSelector_Src.SearchRange;
                    if (start + length >= OList_Objects.Count)
                    {
                        length = OList_Objects.Count - start;
                    }

                    result = objDBUpdater.save_Objects(OList_Objects.GetRange(start , length));
                    if (result.GUID == objLogStates.LogState_Error.GUID)
                    {
                        break;
                    }
                    start = start + length;
                }

                if (start + objDBSelector_Src.SearchRange < OList_Objects.Count - 1)
                {
                    result = objDBUpdater.save_Objects(OList_Objects.GetRange(start + objDBSelector_Src.SearchRange, OList_Objects.Count - (start + objDBSelector_Src.SearchRange+1)));
                }
            }

            var searchRange = 500;

            if (copyItem.HasFlag(CopyItem.ClassAttributes))
            {
                if (!OList_ClassAttributes.Any())
                {
                    OList_ClassAttributes = objDBSelector_Src.get_Data_ClassAtt();
                }

                var start = 0;

                while (start < OList_ClassAttributes.Count)
                {

                    var length = searchRange;
                    if (start + length >= OList_ClassAttributes.Count)
                    {
                        length = OList_ClassAttributes.Count - start;
                    }

                    result = objDBUpdater.save_ClassAtt(OList_ClassAttributes.GetRange(start, length));
                    if (result.GUID == objLogStates.LogState_Error.GUID)
                    {
                        break;
                    }
                    start = start + length;
                }

                if (start + searchRange < OList_ClassAttributes.Count - 1)
                {
                    result = objDBUpdater.save_ClassAtt(OList_ClassAttributes.GetRange(start + searchRange, OList_ClassAttributes.Count - (start + searchRange + 1)));
                }
            }

            searchRange = 500;

            if (copyItem.HasFlag(CopyItem.ClassRelations))
            {
                if (!OList_ClassRelations.Any())
                {
                    OList_ClassRelations = objDBSelector_Src.get_Data_ClassRel(null);
                }

                var start = 0;

                while (start < OList_ClassRelations.Count)
                {

                    var length = searchRange;
                    if (start + length >= OList_ClassRelations.Count)
                    {
                        length = OList_ClassRelations.Count - start;
                    }

                    result = objDBUpdater.save_ClassRel(OList_ClassRelations.GetRange(start, length));
                    if (result.GUID == objLogStates.LogState_Error.GUID)
                    {
                        break;
                    }
                    start = start + length;
                }

                if (start + searchRange < OList_ClassRelations.Count - 1)
                {
                    result = objDBUpdater.save_ClassRel(OList_ClassRelations.GetRange(start + searchRange, OList_ClassRelations.Count - (start + searchRange + 1)));
                }
            }

            searchRange = 500;

            if (copyItem.HasFlag(CopyItem.ObjectAttributes))
            {
                if (!OList_ObjectAttributes.Any())
                {
                    OList_ObjectAttributes = objDBSelector_Src.get_Data_ObjectAtt(null);
                }

                var start = 0;

                while (start < OList_ObjectAttributes.Count)
                {

                    var length = searchRange;
                    if (start + length >= OList_ObjectAttributes.Count)
                    {
                        length = OList_ObjectAttributes.Count - start;
                    }

                    var items = objDBUpdater.save_ObjectAtt(OList_ObjectAttributes.GetRange(start, length));

                    if (items.Count < length)
                    {
                        //break;
                    }
                    start = start + length;
                }

                if (start + searchRange < OList_ObjectAttributes.Count - 1)
                {
                    var items = objDBUpdater.save_ObjectAtt(OList_ObjectAttributes.GetRange(start + searchRange, OList_ObjectAttributes.Count - (start + searchRange + 1)));
                }
            }

            searchRange = 1000;

            if (copyItem.HasFlag(CopyItem.ObjectRelations))
            {
                if (!OList_ObjectRelations.Any())
                {
                    OList_ObjectRelations = objDBSelector_Src.get_Data_ObjectRel(null);
                }

                var start = 0;

                while (start < OList_ObjectRelations.Count)
                {

                    var length = searchRange;
                    if (start + length >= OList_ObjectRelations.Count)
                    {
                        length = OList_ObjectRelations.Count - start;
                    }

                    var items = objDBUpdater.save_ObjectRel(OList_ObjectRelations.GetRange(start, length));

                    if (items.Count < length)
                    {
                        //break;
                    }
                    start = start + length;
                }

                if (start + searchRange < OList_ObjectRelations.Count - 1)
                {
                    var items = objDBUpdater.save_ObjectRel(OList_ObjectRelations.GetRange(start + searchRange, OList_ObjectRelations.Count - (start + searchRange + 1)));
                }
            }

            return result;
        }

        
    }
}
