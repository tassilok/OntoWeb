using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsMappingRules
    {
        public clsOntologyItem MappingRule_RemoveSrc { get; private set; }
        public clsOntologyItem MappingRule_NewItem { get; private set; }
        public clsOntologyItem MappingRule_SrcItemIsDstItem { get; private set; }

        public List<clsOntologyItem> MappingRules { get; private set; }

        private clsClasses objClasses = new clsClasses();
        private clsTypes objTypes = new clsTypes();

        public clsMappingRules()
        {
            MappingRule_RemoveSrc = new clsOntologyItem
            {
                GUID = "e43d3449d193431182dcf4450a4a6b5a",
                Name = "Remove Src",
                GUID_Parent = objClasses.OItem_Class_MappingRule.GUID,
                Type = objTypes.ObjectType
            };

            MappingRule_NewItem = new clsOntologyItem
            {
                GUID = "613e389ada874e7c8ba968481101a72b",
                Name = "New Item",
                GUID_Parent = objClasses.OItem_Class_MappingRule.GUID,
                Type = objTypes.ObjectType
            };

            MappingRule_SrcItemIsDstItem = new clsOntologyItem
            {
                GUID = "8596506d502342f58b23677819ccb3b0",
                Name = "Srcitem is Dstitem",
                GUID_Parent = objClasses.OItem_Class_MappingRule.GUID,
                Type = objTypes.ObjectType
            };

            MappingRules = new List<clsOntologyItem>
                {
                    MappingRule_NewItem,
                    MappingRule_RemoveSrc,
                    MappingRule_SrcItemIsDstItem
                };
        }
    }
}
