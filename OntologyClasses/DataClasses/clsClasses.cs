using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsClasses
    {
        public clsOntologyItem OItem_Class_Root { get; private set; }
        public clsOntologyItem OItem_Class_Logstate { get; private set; }
        public clsOntologyItem OItem_Class_Directions { get; private set; }
        public clsOntologyItem OItem_Class_System { get; private set; }
        public clsOntologyItem OItem_Class_Ontologies { get; private set; }
        public clsOntologyItem OItem_Class_OntologyItems { get; private set; }
        public clsOntologyItem OItem_Class_OntologyRelationRule { get; private set; }
        public clsOntologyItem OItem_Class_OntologyItemCreationRule { get; private set; }
        public clsOntologyItem OItem_Class_OntologyJoin { get; private set; }
        public clsOntologyItem OItem_Class_Server { get; private set; }
        public clsOntologyItem OItem_Class_Variable { get; private set; }
        public clsOntologyItem OItem_Class_OntologyMapping { get; private set; }
        public clsOntologyItem OItem_Class_OntologyMappingItem { get; private set; }
        public clsOntologyItem OItem_Class_MappingRule { get; private set; }
        public clsOntologyItem OItem_Class_Module { get; private set; }
        public clsOntologyItem OItem_Class_ModuleFunction { get; private set; }

        public List<clsOntologyItem> OList_Classes { get; private set; } 

        private clsTypes objTypes = new clsTypes();

        public clsClasses()
        {
            OList_Classes = new List<clsOntologyItem>();

            OItem_Class_Root = new clsOntologyItem {GUID = "49fdcd27e1054770941d7485dcad08c1", Name = "Root"};
            OList_Classes.Add(OItem_Class_Root);
            OItem_Class_System = new clsOntologyItem{ GUID = "665dd88b792e4256a27a68ee1e10ece6", Name = "System", GUID_Parent = OItem_Class_Root.GUID, Type = objTypes.ClassType};
            OList_Classes.Add(OItem_Class_System);
            OItem_Class_Logstate = new clsOntologyItem { GUID = "1d9568afb6da49908f4d907dfdd30749", Name = "Logstate", GUID_Parent = OItem_Class_System.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_Logstate);
            OItem_Class_Directions = new clsOntologyItem { GUID = "3d1dc6cfb96449869808f39b7c5c3907", Name = "Direction", GUID_Parent = OItem_Class_System.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_Directions);
            OItem_Class_Ontologies = new clsOntologyItem { GUID = "eb411e2ff93d4a5ebbbac0b5d7ec0197", Name = "Ontologies", GUID_Parent = OItem_Class_System.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_Ontologies);
            OItem_Class_OntologyItems = new clsOntologyItem { GUID = "d3f72a683f6146a48ff381db05997dc8", Name = "Ontology-Items", GUID_Parent = OItem_Class_Ontologies.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_OntologyItems);
            OItem_Class_OntologyRelationRule = new clsOntologyItem { GUID = "925f489dec8d4130a418fcb022a4c731", Name = "Ontology-Relation-Rule", GUID_Parent = OItem_Class_Ontologies.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_OntologyRelationRule);
            OItem_Class_OntologyJoin = new clsOntologyItem { GUID = "aab30dd04faf4386896016218132b110", Name = "Ontology-Join", GUID_Parent = OItem_Class_Ontologies.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_OntologyJoin);
            OItem_Class_OntologyMapping = new clsOntologyItem { GUID = "7392dc3336e6422e96d90764a852cec3", Name = "Ontology-Mapping", GUID_Parent = OItem_Class_Ontologies.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_OntologyMapping);
            OItem_Class_OntologyMappingItem = new clsOntologyItem { GUID = "4d84e06af18046deb89d562cef0ca858", Name = "Ontology-Mapping-Item", GUID_Parent = OItem_Class_OntologyMapping.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_OntologyMappingItem);
            OItem_Class_MappingRule = new clsOntologyItem { GUID = "8a2ab30ee0764b6b8d18150066a95eda", Name = "Mapping-Rule", GUID_Parent = OItem_Class_OntologyMapping.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_MappingRule);
            OItem_Class_Server = new clsOntologyItem { GUID = "d7a03a35875142b48e0519fc7a77ee91", Name = "Server", GUID_Parent = OItem_Class_System.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_Server);
            OItem_Class_OntologyItemCreationRule = new clsOntologyItem { GUID = "e4e7e7621df04b81a6ff8f8d67cf988a", Name = "OntologyItem-Creation-Rules", GUID_Parent = OItem_Class_OntologyItems.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_OntologyItemCreationRule);
            OItem_Class_Module = new clsOntologyItem { GUID = "aa616051e5214facabdbcbba6f8c6e73", Name = "Module", GUID_Parent = OItem_Class_System.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_Module);
            OItem_Class_ModuleFunction = new clsOntologyItem { GUID = "86b05e853ce24a56be3c80375a686a82", Name = "Module-Function", GUID_Parent = OItem_Class_Module.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_ModuleFunction);

            OItem_Class_Variable = new clsOntologyItem { GUID = "4158aad2656a4fb997bf524c6f5fecaa", Name = "Variable", GUID_Parent = OItem_Class_System.GUID, Type = objTypes.ClassType };
            OList_Classes.Add(OItem_Class_Variable);
        }
    }
}
