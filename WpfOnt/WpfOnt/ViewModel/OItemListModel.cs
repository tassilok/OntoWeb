using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfOnt.Data;
using WpfOnt.OServiceOItems;
using WpfOnt.Pages;
using WpfOnt.View;
using WpfOnt.ViewModelUtils;

namespace WpfOnt.ViewModel
{
    public class OItemListModel : ViewModelBase
    {

        
        
        private List<WpfOnt.OServiceOItems.clsOntologyItem> itemList;
        private WpfOnt.OServiceOItems.clsOntologyItem parentClass;
        private DbWork dbWork;
        private string idParent;

        private double opacityButtonAdd = 0.5;
        private double opacityButtonDel = 0.5;
        private double opacityButtonRelate = 0.5;
        private double opacityButtonSort = 0.5;
        private double opacityButtonOrderTD = 0.5;
        private double opacityButtonOrderBU = 0.5;
        private double opacityButtonReport = 0.5;
        private double opacityButtonNameEdit = 0.5;

        private bool enableButtonAdd = false;
        private bool enableButtonDel = false;
        private bool enableButtonRelate = false;
        private bool enableButtonSort = false;
        private bool enableButtonOrderTD = false;
        private bool enableButtonOrderBU = false;
        private bool enableButtonReport = false;
        private bool enableButtonNameEdit = false;

        private int itemCount = 0;

        private string lblItemCount = "x_Items";
        private string lblFilter = "x_Filter:";
        private string lblAdvanced = "x_Advanced...";

        public string NameFilter { get; set; }

        public string LblAdvanced
        {
            get { return lblAdvanced; }
            set
            {
                lblAdvanced = value;
                OnPropertyChanged("LblAdvanced");
            }
        }

        public string LblFilter
        {
            get { return lblFilter; }
            set
            {
                lblFilter = value;
                OnPropertyChanged("LblFilter");
            }
        }

        public int ItemCount
        {
            get { return itemCount; }
            set
            {
                itemCount = value;
                OnPropertyChanged("ItemCount");
            }
        }

        public string LblItemCount
        {
            get { return lblItemCount; }
            set
            {
                lblItemCount = value;
                OnPropertyChanged("LblItemCount");
            }
        }

        public double OpacityButtonAdd
        {
            get { return opacityButtonAdd; }
            set
            {
                opacityButtonAdd = value;
                OnPropertyChanged("OpacityButtonAdd");
            }
        }

        public double OpacityButtonDel
        {
            get { return opacityButtonDel; }
            set
            {
                opacityButtonDel = value;
                OnPropertyChanged("OpacityButtonDel");
            }
        }

        public double OpacityButtonRelate
        {
            get { return opacityButtonRelate; }
            set
            {
                opacityButtonRelate = value;
                OnPropertyChanged("OpacityButtonRelate");
            }
        }

        public double OpacityButtonSort
        {
            get { return opacityButtonSort; }
            set
            {
                opacityButtonSort = value;
                OnPropertyChanged("OpacityButtonSort");
            }
        }

        public double OpacityButtonOrderTD
        {
            get { return opacityButtonOrderTD; }
            set
            {
                opacityButtonOrderTD = value;
                OnPropertyChanged("OpacityButtonOrderTD");
            }
        }

        public double OpacityButtonOrderBU
        {
            get { return opacityButtonOrderBU; }
            set
            {
                opacityButtonOrderBU = value;
                OnPropertyChanged("OpacityButtonOrderBU");
            }
        }

        public double OpacityButtonReport
        {
            get { return opacityButtonReport; }
            set
            {
                opacityButtonReport = value;
                OnPropertyChanged("OpacityButtonReport");
            }
        }

        public double OpacityButtonNameEdit
        {
            get { return opacityButtonNameEdit; }
            set
            {
                opacityButtonNameEdit = value;
                OnPropertyChanged("OpacityButtonNameEdit");
            }
        }

        public bool EnableButton_Add
        {
            get { return enableButtonAdd; }
            set 
            { 
                enableButtonAdd = value;
                OpacityButtonAdd = enableButtonAdd ? 1 : 0.5;
                OnPropertyChanged("EnableButton_Add");
            }
        }

        public bool EnableButton_Del
        {
            get { return enableButtonDel; }
            set
            {
                enableButtonDel = value;
                OpacityButtonDel = enableButtonDel ? 1 : 0.5;
                OnPropertyChanged("EnableButton_Del");
            }
        }

        public bool EnableButton_Relate
        {
            get { return enableButtonRelate; }
            set
            {
                enableButtonRelate = value;
                OpacityButtonRelate = enableButtonRelate ? 1 : 0.5;
                OnPropertyChanged("EnableButton_Relate");
            }
        }

        public bool EnableButton_Sort
        {
            get { return enableButtonSort; }
            set
            {
                enableButtonSort = value;
                OpacityButtonSort = enableButtonSort ? 1 : 0.5;
                OnPropertyChanged("EnableButton_Sort");
            }
        }

        public bool EnableButton_OrderTD
        {
            get { return enableButtonOrderTD; }
            set
            {
                enableButtonOrderTD = value;
                OpacityButtonOrderTD = enableButtonOrderTD ? 1 : 0.5;
                OnPropertyChanged("EnableButton_OrderTD");
            }
        }

        public bool EnableButton_OrderBU
        {
            get { return enableButtonOrderBU; }
            set
            {
                enableButtonOrderBU = value;
                OpacityButtonOrderBU = enableButtonOrderBU ? 1 : 0.5;
                OnPropertyChanged("EnableButton_OrderBU");
            }
        }

        public bool EnableButton_Report
        {
            get { return enableButtonReport; }
            set
            {
                enableButtonReport = value;
                OpacityButtonReport = enableButtonReport ? 1 : 0.5;
                OnPropertyChanged("EnableButton_Report");
            }
        }

        public bool EnableButton_NameEdit
        {
            get { return enableButtonNameEdit; }
            set
            {
                enableButtonNameEdit = value;
                OpacityButtonNameEdit = enableButtonNameEdit ? 1 : 0.5;
                OnPropertyChanged("EnableButton_NameEdit");
            }
        }

        public string IdParent 
        {
            get { return idParent; }
            set
            {
                idParent = value;
                RefreshObjects(idParent);
            }
        }

        public OItemListModel()
        {
            
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                dbWork = new DbWork();
            }
        }

        /// <summary>
        ///     Contains the current selected page.
        /// </summary>
        public List<WpfOnt.OServiceOItems.clsOntologyItem> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged("ItemList");
            }
        }

        //public WpfOnt.OServiceClasses.clsOntologyItem ParentClass
        //{
        //    get { return parentClass; }
        //    set
        //    {
        //        parentClass = value;
        //        RefreshObjects();
        //        OnPropertyChanged("ItemList");
        //    }
        //}

        public void RefreshObjects(string idParent = null)
        {

            this.idParent = idParent ?? this.idParent;

            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                if (string.IsNullOrEmpty(NameFilter))
                {
                    ItemList = dbWork.GetObjectListByClassId(this.idParent); 
                }
                else
                {
                    ItemList = dbWork.GetObjectListByNameObjectAndClassId(this.idParent, NameFilter);
                }
               
            }

            ItemCount = ItemList.Count;
            
        }

        public void OpenObjectEdit(clsOntologyItem OItem_Object)
        {
            var ix = itemList.IndexOf(OItem_Object);
            var objectsEdit = new ObjectsEdit(itemList, ix);
            objectsEdit.Show();
        }

        
    }
}
