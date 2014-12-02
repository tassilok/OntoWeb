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
        private DataWork_ObjectRefTree dataWork_ObjectRefTree;
        public List<ObjectRefParentNode> NodeList { get; set; }

        private Globals globals;
        public Globals GlobalConfig
        {
            get { return globals; }
            set
            {
                globals = value;
                dataWork_ObjectRefTree = new DataWork_ObjectRefTree(globals);
                NodeList = new List<ObjectRefParentNode>
                {
                    new ObjectRefParentNode 
                    {
                        IdNode = this.globals.Type_AttributeType,
                        NameNode = this.globals.Type_AttributeType
                    },
                    new ObjectRefParentNode
                    {
                        IdNode = this.globals.Directions.Direction_LeftRight.GUID,
                        NameNode = this.globals.Directions.Direction_LeftRight.Name
                    },
                    new ObjectRefParentNode
                    {
                        IdNode = this.globals.Directions.Direction_RightLeft.GUID,
                        NameNode = this.globals.Directions.Direction_RightLeft.Name
                    }
                   
                };
                Initialize();
            }
        }

        public string IdObject { get; set; }

        public ObjectRefTreeModel()
        {
            
        }

        private void Initialize()
        {
            dataWork_ObjectRefTree.IdObject = IdObject;
            var oItem_Result = dataWork_ObjectRefTree.GetClassAttributes();
        }

        public void InitializeTree(string idObject)
        {
            IdObject = idObject;
            
        }

        private void LoadAttributes()
        {

        }
    }
}
