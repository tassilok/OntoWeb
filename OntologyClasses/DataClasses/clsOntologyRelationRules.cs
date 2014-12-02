using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsOntologyRelationRules
    {
        public clsOntologyItem Rule_ChildToken { get; set; }
        public clsOntologyItem Rule_InnerJoin { get; set; }
        public clsOntologyItem Rule_LeftOuterJoin { get; set; }
        public clsOntologyItem Rule_OnlyItem { get; set; }
        public clsOntologyItem Rule_RelationBreak { get; set; }
        public clsOntologyItem Rule_RightOuterJoin { get; set; }
        public clsOntologyItem Rule_NoOtherRelationsOfThisType { get; set; }

        private clsClasses objClasses = new clsClasses();
        private clsTypes objTypes = new clsTypes();

        public List<clsOntologyItem> OntologyRelationRules { get; private set; } 

        public clsOntologyRelationRules()
        {
            Rule_ChildToken = new clsOntologyItem { GUID = "5f39c4ce080d4f36b432f83d2892c841", Name = "Child-Token", GUID_Parent = objClasses.OItem_Class_OntologyRelationRule.GUID, Type = objTypes.ObjectType};
            Rule_InnerJoin = new clsOntologyItem { GUID = "00b22e07be8e433097558c30c46d76e4", Name = "Inner Join", GUID_Parent = objClasses.OItem_Class_OntologyRelationRule.GUID, Type = objTypes.ObjectType };
            Rule_OnlyItem = new clsOntologyItem { GUID = "16fdf6615bdb4c55bfecd3e55df416fe", Name = "Inner Join", GUID_Parent = objClasses.OItem_Class_OntologyRelationRule.GUID, Type = objTypes.ObjectType };
            Rule_RelationBreak = new clsOntologyItem { GUID = "cbe4408df1734971bfed25a3b7891f88", Name = "Relation-Break", GUID_Parent = objClasses.OItem_Class_OntologyRelationRule.GUID, Type = objTypes.ObjectType };
            Rule_RightOuterJoin = new clsOntologyItem { GUID = "519a9d9c2db941c7b1f5b52ce8d74e31", Name = "Right Outer Join", GUID_Parent = objClasses.OItem_Class_OntologyRelationRule.GUID, Type = objTypes.ObjectType };
            Rule_NoOtherRelationsOfThisType = new clsOntologyItem { GUID = "ad4893d4b59648cba4ba09312f3a1508", Name = "No Other Relations Of This Type", GUID_Parent = objClasses.OItem_Class_OntologyRelationRule.GUID, Type = objTypes.ObjectType };

            OntologyRelationRules = new List<clsOntologyItem>
                {
                    Rule_ChildToken,
                    Rule_InnerJoin,
                    Rule_OnlyItem,
                    Rule_RelationBreak,
                    Rule_RightOuterJoin,
                    Rule_NoOtherRelationsOfThisType
                };
        }
    }
}
