using WpfOnt.OntoWeb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.Data;

namespace WpfOnt.ViewModel 
{
    public class ObjectRefTreeModel : ViewModelBase
    {
        private ObjectRefParentNode attributeNode;
        private ObjectRefParentNode leftRightNode;
        private ObjectRefParentNode rightLeftNode;
        private DataWork_ObjectRefTree dataWork_ObjectRefTree;

        private DbWork objDBLevel_Count;

        private ObservableCollection<ObjectRefParentNode> nodeList;
        public ObservableCollection<ObjectRefParentNode> NodeList 
        {
            get { return nodeList; }
            set
            {
                nodeList = value;
                OnPropertyChanged("NodeList");
            }
        }

        private clsLocalConfig localConfig;

        public clsLocalConfig LocalConfig
        {
            get { return localConfig; }
            set
            {
                localConfig = value;
                Initialize();
            }
        }
        public Globals GlobalConfig
        {
            get { return localConfig.Globals; }
            set
            {
                localConfig = new clsLocalConfig(value);
                Initialize();
            }
        }

        public string IdObject { get; set; }
        private bool showAttributes;
        public bool ShowAttributes 
        {
            get { return showAttributes; }
            set
            {
                showAttributes = value;
                OnPropertyChanged("ShowAttributes");
            }
            
        }

        private bool showRelForw;
        public bool ShowRelForw 
        {
            get { return showRelForw; }
            set
            {
                showRelForw = value;
                OnPropertyChanged("ShowRelForw");
            }
        }

        private bool showRelBackw;
        public bool ShowRelBackw 
        {
            get { return showRelBackw; }
            set
            {
                showRelBackw = value;
                OnPropertyChanged("ShowRelBackw");
            }
        }

        public ObjectRefTreeModel()
        {
            
        }

        private void Initialize()
        {
            objDBLevel_Count = new DbWork(LocalConfig.Globals);

            dataWork_ObjectRefTree = new DataWork_ObjectRefTree(localConfig.Globals);
            dataWork_ObjectRefTree.IdObject = IdObject;

            NodeList = new ObservableCollection<ObjectRefParentNode>();

            if (ShowAttributes)
            {
                attributeNode = new ObjectRefParentNode
                {
                    IdNode = localConfig.Globals.Type_AttributeType,
                    NameNode = localConfig.Globals.Type_AttributeType,
                    TypeOfNode = NodeType.ParentNode
                };
                NodeList.Add(attributeNode);
                LoadAttributes();
            }

            if (ShowRelForw)
            {
                leftRightNode = new ObjectRefParentNode
                        {
                            IdNode = localConfig.Globals.Directions.Direction_LeftRight.GUID,
                            NameNode = localConfig.Globals.Directions.Direction_LeftRight.Name,
                            TypeOfNode = NodeType.ParentNode
                        };
                NodeList.Add(leftRightNode);
            }

            if (ShowRelBackw)
            {

                rightLeftNode = new ObjectRefParentNode
                        {
                            IdNode = localConfig.Globals.Directions.Direction_RightLeft.GUID,
                            NameNode = localConfig.Globals.Directions.Direction_RightLeft.Name,
                            TypeOfNode = NodeType.ParentNode
                        };
                NodeList.Add(rightLeftNode);
            }
            
            
        }

        public void InitializeTree(string idObject)
        {
            IdObject = idObject;
            
        }

        private void LoadAttributes()
        {
            var oItem_Result = dataWork_ObjectRefTree.GetClassAttributes();
            var objOL_AttributeTree = dataWork_ObjectRefTree.OList_ClassAtt.OrderBy(clatt => clatt.Name_AttributeType).ToList();
            var attributeList = new List<ObjectRefChildNode>();
                    
            foreach (var objO_AttributeType in objOL_AttributeTree)
            {
                var oList_ObjAtt = new List<clsObjectAtt> { new clsObjectAtt { ID_Object = IdObject, ID_AttributeType = objO_AttributeType.ID_AttributeType }};
                oItem_Result = objDBLevel_Count.get_Data_ObjectAtt(oList_ObjAtt,doCount:true);
                if (oItem_Result.GUID == LocalConfig.Globals.LState_Error.GUID)
                {
                    break;
                }
                long intCount = oItem_Result.Count != null ? (long)oItem_Result.Count : 0;


                attributeList.Add(new ObjectRefChildNode(LocalConfig.Globals) { IdLeft = IdObject,
                                                                                IdRight = objO_AttributeType.ID_AttributeType,
                                                                                Min = objO_AttributeType.Min != null ? (long) objO_AttributeType.Min : 0,
                                                                                Max = objO_AttributeType.Max != null ? (long) objO_AttributeType.Max : 0,
                                                                                Count = intCount
                });
                

            
            }
        }
    }
}
