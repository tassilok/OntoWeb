using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsOntologyItemsCreationRules
    {
        private clsClasses objClasses = new clsClasses();
        private clsTypes objTypes = new clsTypes();

        public clsOntologyItem Rule_TakeExistingItem { get; set; }
        public clsOntologyItem Rule_CreateNewItem { get; set; }
        
        public List<clsOntologyItem> OntologyItemsCreationRules { get; private set; }

        public clsOntologyItemsCreationRules()
        {
            Rule_CreateNewItem = new clsOntologyItem { GUID = "42063c4ff7e64a7c9e924d9cefd6ba26", Name = "Create New Item", GUID_Parent = objClasses.OItem_Class_OntologyItemCreationRule.GUID, Type = objTypes.ObjectType };
            Rule_TakeExistingItem = new clsOntologyItem { GUID = "2832803912ab410e8422095197d3d974", Name = "Take Existing Item", GUID_Parent = objClasses.OItem_Class_OntologyItemCreationRule.GUID, Type = objTypes.ObjectType };

            OntologyItemsCreationRules = new List<clsOntologyItem> 
            { 
                Rule_CreateNewItem,
                Rule_TakeExistingItem 
            };
        }
    }
}
