using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt
{
    public interface IModule
    {

        bool IsInitialized { get; set; }
        bool IsOntologyModuleConfiguraiton { get; set; }
        bool HasListEditor(clsOntologyItem OItem_Class);
        List<clsOntologyItem> GetMenuEntries(clsOntologyItem OItem_Item);
        clsOntologyItem Open_Viewer(clsOntologyItem OItem_Item, clsOntologyItem OItem_MenuItem);
        void Initialize();
    }
}
