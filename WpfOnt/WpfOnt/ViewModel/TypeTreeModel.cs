using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfOnt.Data;
using WpfOnt.View;
using WpfOnt.ViewModelUtils;

namespace WpfOnt.ViewModel
{
    public class TypeTreeModel : ViewModelBase
    {

        private Globals globals;
        private clsLocalConfig localConfig;
        private DbWork dbWork;

        public RelayCommand<TreeViewHelper.DependencyPropertyEventArgs> MySelItemChgCmd { get; set; }

        

        private string markLbl = "x_Mark:";
        private string itemCountLbl = "x_Count:";
        private string itemCount = "0";
        private string lblGuid = "x_GUID:";
        private string guidClass = "";
        private List<clsOntologyItem> classList;
        private List<OTreeNode> nodeList;
        private List<OTreeNode> nodes;

        public object CurrSelItem { get; set; }

        public Globals GlobalConfig
        {
            get
            {
                return globals;
            }
            set
            {
                globals = value;
                localConfig = new clsLocalConfig(globals);
                if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
                {
                    dbWork = new DbWork(localConfig.Globals);
                }
                OnPropertyChanged("GlobalConfig");
                Refresh();
            }
        }

        public clsLocalConfig LocalConfig
        {
            get
            {
                return localConfig;
            }
            set
            {
                this.localConfig = value;
                if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
                {
                    dbWork = new DbWork(localConfig.Globals);
                }
                OnPropertyChanged("LocalConfig");
                Refresh();
            }
        }

        public string LblGuid
        {
            get { return lblGuid; }
            set
            {
                lblGuid = value;
                OnPropertyChanged("LblGuid");
            }
        }

        public string GuidClass
        {
            get { return guidClass; }
            set
            {
                guidClass = value;
                OnPropertyChanged("GuidClass");
            }
        }

        /// <summary>
        ///     Contains the current selected page.
        /// </summary>
        public string MarkLbl
        {
            get { return markLbl; }
            set
            {
                markLbl = value;
                OnPropertyChanged("MarkLbl");
            }
        }

        /// <summary>
        ///     Contains the current selected page.
        /// </summary>
        public string ItemCountLbl
        {
            get { return itemCountLbl; }
            set
            {
                itemCountLbl = value;
                OnPropertyChanged("ItemCountLbl");
            }
        }

        /// <summary>
        ///     Contains the current selected page.
        /// </summary>
        public string ItemCount
        {
            get { return itemCount; }
            set
            {
                itemCount = value;
                OnPropertyChanged("ItemCount");
            }
        }

        /// <summary>
        ///     Contains the current selected page.
        /// </summary>
        public List<OTreeNode> Nodes
        {
            get { return nodes; }
            set
            {
                nodes = value;
                OnPropertyChanged("Nodes");
            }
        }

        
        public TypeTreeModel()
        {
            MySelItemChgCmd = new RelayCommand<TreeViewHelper.DependencyPropertyEventArgs>(TreeViewItemSelectedChangedCallBack);
            CurrSelItem = new object();
            

        }

        private static void TreeViewItemSelectedChangedCallBack(TreeViewHelper.DependencyPropertyEventArgs e)
        {
            if (e != null && e.DependencyPropertyChangedEventArgs.NewValue != null)
            {
                
            }
                
        }

        private void Refresh()
        {
            nodeList = new List<OTreeNode>();

            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
               var oItem_Result = dbWork.get_Data_Classes();
               classList = dbWork.OList_Classes;
            }
            
            GetONodeList();
            Nodes = nodeList;
        }

        private void GetONodeList(OTreeNode oTreeNodeParent = null)
        {
            if (oTreeNodeParent == null)
            {
                var oClassList =
                    classList.Where(cl => string.IsNullOrEmpty(cl.GUID_Parent))
                             .OrderBy(cl => cl.Name)
                             .ToList();

                foreach (var oClass in oClassList)
                {
                    var oTreeNode = new OTreeNode
                        {
                            Id = oClass.GUID,
                            Name = oClass.Name,
                            IsRoot = true
                        };
                    nodeList.Add(oTreeNode);
                    GetONodeList(oTreeNode);
                }

                ItemCount = classList.Count.ToString();
            }
            else
            {
                var oClassList =
                    classList.Where(cl => cl.GUID_Parent == oTreeNodeParent.Id)
                             .OrderBy(cl => cl.Name)
                             .ToList();

                foreach (var oClass in oClassList)
                {
                    var oTreeNode = new OTreeNode
                    {
                        Id = oClass.GUID,
                        Name = oClass.Name,
                        IsRoot = false
                    };
                    oTreeNodeParent.Nodes.Add(oTreeNode);
                    GetONodeList(oTreeNode);
                }

                ItemCount = classList.Count.ToString();
            }
        }

       
    }
}
