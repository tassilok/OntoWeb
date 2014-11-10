using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.Data;
using WpfOnt.OServiceClassAtt;
using WpfOnt.OServiceOItems;

namespace WpfOnt
{
    public class DataWork_ObjectRefTree
    {

        private clsOntologyItem OItem_Object;

        public List<clsClassAtt> OList_ClassAtt { get; set; }
        public List<clsClassAtt> OList_ObjectAtt { get; set; }

        public string IdObject
        {
            get { return OItem_Object.GUID; }
            set
            {
                OItem_Object = dbWork.GetOItem(value, LocalConfig.Type_Object);
            }
        }

        private DbWork dbWork;

        public DataWork_ObjectRefTree()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                dbWork = new DbWork();
            }
            
        }


        public clsOntologyItem GetClassAttributes()
        {
            var searchClassAtt = new List<clsObjectAtt> 
            {
                new clsObjectAtt
                {
                    ID_Class = OItem_Object.GUID_Parent
                }
            };

            OList_ClassAtt = dbWork.GetClassAttributesByClassId(OItem_Object.GUID_Parent);

            return new clsOntologyItem
            {
                GUID = OList_ClassAtt != null ? LocalConfig.LogStates.LogState_Success.GUID : LocalConfig.LogStates.LogState_Error.GUID,
                Name = OList_ClassAtt != null ? LocalConfig.LogStates.LogState_Success.Name : LocalConfig.LogStates.LogState_Error.GUID,
                GUID_Parent = LocalConfig.LogStates.LogState_Success.GUID_Parent,
                Type = LocalConfig.LogStates.LogState_Success.Type
            };
        }

        public clsOntologyItem GetObjAttCount()
        {
            var searchCount = OList_ClassAtt.Select(classatt => new clsObjectAtt
            {
                ID_Class = classatt.ID_Class,
                ID_AttributeType = classatt.ID_AttributeType
            }).ToList();

            if (searchCount.Any())
            {
                
            }

            return new clsOntologyItem
            {
                GUID = OList_ClassAtt != null ? LocalConfig.LogStates.LogState_Success.GUID : LocalConfig.LogStates.LogState_Error.GUID,
                Name = OList_ClassAtt != null ? LocalConfig.LogStates.LogState_Success.Name : LocalConfig.LogStates.LogState_Error.GUID,
                GUID_Parent = LocalConfig.LogStates.LogState_Success.GUID_Parent,
                Type = LocalConfig.LogStates.LogState_Success.Type
            };
        }
    }
}
