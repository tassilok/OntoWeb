using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.Data;

namespace WpfOnt
{
    public class DataWork_ObjectRefTree
    {

        private Globals globals;
        private clsOntologyItem OItem_Object;

        public List<clsClassAtt> OList_ClassAtt { get; set; }
        public List<clsClassAtt> OList_ObjectAtt { get; set; }

        public string IdObject
        {
            get { return OItem_Object.GUID; }
            set
            {
                OItem_Object = dbWork.GetOItem(value, globals.Type_Object);
            }
        }

        private DbWork dbWork;

        public DataWork_ObjectRefTree(Globals globals)
        {
            this.globals = globals;
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                dbWork = new DbWork(globals);
            }
            
        }


        public clsOntologyItem GetClassAttributes()
        {
            var searchClassAtt = new List<clsOntologyItem> 
            {
                new clsOntologyItem
                {
                    GUID_Parent = OItem_Object.GUID_Parent
                }
            };

            var oItem_Result = dbWork.get_Data_ClassAtt(searchClassAtt,null,false);
            OList_ClassAtt = dbWork.OList_ClassAtt;

            return new clsOntologyItem
            {
                GUID = OList_ClassAtt != null ? globals.LState_Success.GUID : globals.LState_Error.GUID,
                Name = OList_ClassAtt != null ? globals.LState_Success.Name : globals.LState_Error.GUID,
                GUID_Parent = globals.LState_Success.GUID_Parent,
                Type = globals.LState_Success.Type
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
                GUID = OList_ClassAtt != null ? globals.LState_Success.GUID : globals.LState_Error.GUID,
                Name = OList_ClassAtt != null ? globals.LState_Success.Name : globals.LState_Error.GUID,
                GUID_Parent = globals.LState_Success.GUID_Parent,
                Type = globals.LState_Success.Type
            };
        }
    }
}
