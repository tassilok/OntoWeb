using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.Interfaces
{
    public interface IModule
    {
        
        bool IsOntologyModuleConfiguration { get; }
        bool HasListEditor(clsOntologyItem OItem_Class);
        List<clsOntologyItem> GetMenuEntries(clsOntologyItem OItem_Item);
        clsOntologyItem Open_Viewer(clsOntologyItem OItem_Item, clsOntologyItem OItem_MenuItem);

    }
}
