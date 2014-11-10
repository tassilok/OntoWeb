using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.Data;
using WpfOnt.OServiceOItems;

namespace WpfOnt.Pages
{
    public class DataWork_ObjectsEdit
    {
        private DbWork dbWork;

        public DataWork_ObjectsEdit()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                dbWork = new DbWork();
            }
            
        }

        public string ObjectPath(clsOntologyItem OItem_Object)
        {
            var classPath = dbWork.GetClassPath(OItem_Object.GUID_Parent);
            return classPath + "\\" + OItem_Object.Name;
        }
    }
}
