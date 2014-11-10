using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.Data;

namespace WpfOnt.ViewModel 
{
    public class ObjectRefTreeModel : ViewModelBase
    {
        private DataWork_ObjectRefTree dataWork_ObjectRefTree = new DataWork_ObjectRefTree();
        public List<ObjectRefParentNode> NodeList { get; set; }

        public string IdObject { get; set; }

        public ObjectRefTreeModel()
        {
            NodeList = new List<ObjectRefParentNode>
            {
                new ObjectRefParentNode 
                {
                    IdNode = LocalConfig.Type_AttributeType,
                    NameNode = LocalConfig.Type_AttributeType
                },
                new ObjectRefParentNode
                {
                    IdNode = LocalConfig.Directions.Direction_LeftRight.GUID,
                    NameNode = LocalConfig.Directions.Direction_LeftRight.Name
                },
                new ObjectRefParentNode
                {
                    IdNode = LocalConfig.Directions.Direction_RightLeft.GUID,
                    NameNode = LocalConfig.Directions.Direction_RightLeft.Name
                }
                   
            };
        }

        public void InitializeTree(string idObject)
        {
            IdObject = idObject;
            dataWork_ObjectRefTree.IdObject = IdObject;
            var oItem_Result = dataWork_ObjectRefTree.GetClassAttributes();
        }

        private void LoadAttributes()
        {

        }
    }
}
