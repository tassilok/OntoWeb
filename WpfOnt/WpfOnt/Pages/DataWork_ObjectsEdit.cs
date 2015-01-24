using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.Data;

namespace WpfOnt.Pages
{
    public class DataWork_ObjectsEdit
    {
        private Globals globals;
        private DbWork dbWork;

        public DataWork_ObjectsEdit(Globals globals)
        {
            this.globals = globals;
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                dbWork = new DbWork(globals);
            }
            
        }

        public string ObjectPath(clsOntologyItem OItem_Object)
        {
            var oItem_Class = dbWork.GetOItem(OItem_Object.GUID_Parent, globals.Type_Class);

            var classPath = dbWork.GetClassPath(oItem_Class);
            return classPath + "\\" + OItem_Object.Name;
        }
    }
}
