using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfOnt.Data;
using WpfOnt.OServiceConfiguration;
using WpfOnt.OServiceOItems;
using WpfOnt.ViewModel;
using WpfOnt.ViewModelUtils;

namespace WpfOnt.Pages.PagesViewModels
{
    public class ObjectsEditModel : ViewModelBase
    {
        private bool _canExecute;
        private ICommand _clickNavFirst;
        private ICommand _clickNavPrevious;
        private ICommand _clickNavNext;
        private ICommand _clickNavLast;
        private ICommand _clickSortTopDown;
        private ICommand _clickSortBottomUp;

        private string menuItem_File;
        private string menuItem_Edit;
        private string menuItem_ToOntologyClipboard;
        private string menuItem_Delete;
        private string menuItem_OpenModuleByCommandLine;
        private string menuItem_OpenLastModule;
        private string menuItem_OpenGraphView;

        private string label_Header;
        private string label_GUID;
        private string label_Name;
        private string label_Objects;
        private string label_Service;
        private string label_Filter;

        private string guidObject;
        private string nameObject;

        private string nameFilter;

        private string posCount;

        private bool isEnabled_NavBack;
        private double opac_NavBack;
        private bool isEnabled_NavNext;
        private double opac_NavNext;

        private bool isEnabled_S_TopDown;
        private double opac_TopDown;
        private bool isEnabled_S_BottomUp;
        private double opac_BottomUp;

        private bool isEnabled_Name;

        private string serviceConnection;

        private DataWork_ObjectsEdit dataWork_ObjectsEdit;
        
        private int itemIx;
        
        private List<WpfOnt.OServiceOItems.clsOntologyItem> rawObjects;
        private List<WpfOnt.OServiceOItems.clsOntologyItem> workObjects;

        public bool IsEnabled_Name
        {
            get { return isEnabled_Name; }
            set
            {
                isEnabled_Name = value;
                OnPropertyChanged("IsEnabled_Name");
            }
        }

        public string NameFilter
        {
            get { return nameFilter; }
            set
            {
                nameFilter = value;
                OnPropertyChanged("NameFilter");
            }
        }

        public bool IsEnabled_S_TopDown
        {
            get { return isEnabled_S_TopDown; }
            set
            {
                isEnabled_S_TopDown = value;
                Opac_TopDown = isEnabled_S_TopDown ? 1 : 0.5;
                OnPropertyChanged("IsEnabled_S_TopDown");
            }
        }

        public double Opac_TopDown
        {
            get { return opac_TopDown; }
            set
            {
                opac_TopDown = value;
                OnPropertyChanged("Opac_TopDown");
            }
        }

        public bool IsEnabled_S_BottomUp
        {
            get { return isEnabled_S_BottomUp; }
            set
            {
                isEnabled_S_BottomUp = value;
                Opac_BottomUp = isEnabled_S_BottomUp ? 1 : 0.5;
                OnPropertyChanged("IsEnabled_S_BottomUp");
            }
        }

        public double Opac_BottomUp
        {
            get { return opac_BottomUp; }
            set
            {
                opac_BottomUp = value;
                OnPropertyChanged("Opac_BottomUp");
            }
        }

        public bool IsEnabled_NavBack
        {
            get { return isEnabled_NavBack; }
            set
            {
                isEnabled_NavBack = value;
                Opac_NavBack = isEnabled_NavBack ? 1 : 0.5;
                OnPropertyChanged("IsEnabled_NavBack");
            }
        }

        public double Opac_NavBack
        {
            get { return opac_NavBack; }
            set
            {
                opac_NavBack = value;
                OnPropertyChanged("Opac_NavBack");
            }
        }

        
        public bool IsEnabled_NavNext
        {
            get { return isEnabled_NavNext; }
            set
            {
                isEnabled_NavNext = value;
                Opac_NavBack = isEnabled_NavNext ? 1 : 0.5;
                OnPropertyChanged("IsEnabled_NavNext");
            }
        }

        public double Opac_NavNext
        {
            get { return opac_NavNext; }
            set
            {
                opac_NavNext = value;
                OnPropertyChanged("Opac_NavNext");
            }
        }

        public string PosCount
        {
            get { return posCount; }
            set
            {
                posCount = value;
                OnPropertyChanged("PosCount");
            }
        }

        public string GuidObject
        {
            get { return guidObject; }
            set
            {
                guidObject = value;
                OnPropertyChanged("GuidObject");
            }
        }

        public string NameObject
        {
            get { return nameObject; }
            set
            {
                nameObject = value;
                OnPropertyChanged("NameObject");
            }
        }

        public void InitializeView()
        {
            ConfigureFilter();
            SetHeader();
            SetObjectData();
            ConfigureNavigation();
            
        }

        private void ConfigureFilter()
        {
            if (Objects.Any())
            {
                WpfOnt.OServiceOItems.clsOntologyItem selItem = null;
                if (workObjects.Any() && itemIx >= 0 && itemIx < workObjects.Count)
                {
                    selItem = workObjects[itemIx];
                }
                else
                {
                    itemIx = 0;
                }
                

                if (string.IsNullOrEmpty(nameFilter))
                {
                    workObjects = Objects;
                }
                else
                {
                    workObjects = Objects.Where(obj => obj.Name.ToLower().Contains(nameFilter.ToLower())).ToList();

                }

                if (selItem != null)
                {
                    itemIx = workObjects.IndexOf(selItem);

                    if (itemIx < 0)
                    {
                        itemIx = 0;
                    }
                }
                else
                {
                    itemIx = 0;
                }
            }
            
        }

        public List<WpfOnt.OServiceOItems.clsOntologyItem> Objects 
        {
            get { return rawObjects; }
            set
            {
                rawObjects = value;
                workObjects = rawObjects;
                OnPropertyChanged("Objects");
            }
        }

        private void SetHeader()
        {
            Label_Header = "-";
            if (workObjects != null && workObjects.Any())
            {
                if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
                {

                    Label_Header = dataWork_ObjectsEdit.ObjectPath(workObjects[itemIx]);
                }
            }
        }

        private void ConfigureNavigation()
        {
            PosCount = (workObjects.Any() ? itemIx + 1 : 0).ToString() + "/" + workObjects.Count.ToString();

            IsEnabled_S_BottomUp = false;
            IsEnabled_S_TopDown = false;

            IsEnabled_NavBack = false;
            IsEnabled_NavNext = false;

            if (workObjects.Count > 1)
            {
                IsEnabled_S_TopDown = true;
                IsEnabled_S_BottomUp = true;
            }

            if (itemIx > 0)
            {
                IsEnabled_NavBack = true;
            }

            if (itemIx < workObjects.Count - 1)
            {
                IsEnabled_NavNext = true;
            }
        }

        private void SetObjectData()
        {
            GuidObject = "";
            NameObject = "";
            IsEnabled_Name = false;
            if (workObjects != null && workObjects.Any())
            {
                GuidObject = workObjects[itemIx].GUID;
                NameObject = workObjects[itemIx].Name;
                IsEnabled_Name = true;
            }
        }

        public int ItemIx 
        {
            get { return itemIx; }
            set
            {
                itemIx = value;
                OnPropertyChanged("ItemIx");
            }
        }


        public ObjectsEditModel()
        {
            _canExecute = true;
            dataWork_ObjectsEdit = new DataWork_ObjectsEdit();

            MenuItem_File = "x_File";
            MenuItem_Edit = "x_Edit";
            MenuItem_ToOntologyClipboard = "x_To Ontology Clipboard";
            MenuItem_Delete = "x_Delete";
            MenuItem_OpenModuleByCommandLine = "x_Open Module By Command Line";
            MenuItem_OpenLastModule = "x_Open Last Module";
            MenuItem_OpenGraphView = "x_Open Graph View";

            Label_Header = "-";
            Label_GUID = "x_Guid:";
            Label_Name = "x_Name:";
            Label_Objects = "x_Objects";
            Label_Service = "-";
            Label_Filter = "x_Filter:";

            IsEnabled_NavBack = false;
            IsEnabled_NavNext = false;
            IsEnabled_S_BottomUp = false;
            IsEnabled_S_TopDown = false;

            serviceConnection = "OServices@localhost";
        }

        public string ServiceConnection
        {
            get { return serviceConnection; }
            set
            {
                serviceConnection = value;
                OnPropertyChanged("ServiceConnection");
            }
        }

        public string MenuItem_File
        {
            get { return menuItem_File; }
            set
            {
                menuItem_File = value;
                OnPropertyChanged("MenuItem_File");
            }
        }

        public string MenuItem_Edit
        {
            get { return menuItem_Edit; }
            set
            {
                menuItem_Edit = value;
                OnPropertyChanged("MenuItem_Edit");
            }
        }

        public string MenuItem_ToOntologyClipboard
        {
            get { return menuItem_ToOntologyClipboard; }
            set
            {
                menuItem_ToOntologyClipboard = value;
                OnPropertyChanged("MenuItem_ToOntologyClipboard");
            }
        }

        public string MenuItem_Delete
        {
            get { return menuItem_Delete; }
            set
            {
                menuItem_Delete = value;
                OnPropertyChanged("MenuItem_Delete");
            }
        }

        public string MenuItem_OpenModuleByCommandLine
        {
            get { return menuItem_OpenModuleByCommandLine; }
            set
            {
                menuItem_OpenModuleByCommandLine = value;
                OnPropertyChanged("MenuItem_OpenModuleByCommandLine");
            }
        }

        public string MenuItem_OpenLastModule
        {
            get { return menuItem_OpenLastModule; }
            set
            {
                menuItem_OpenLastModule = value;
                OnPropertyChanged("MenuItem_OpenLastModule");
            }
        }

        public string MenuItem_OpenGraphView
        {
            get { return menuItem_OpenGraphView; }
            set
            {
                menuItem_OpenGraphView = value;
                OnPropertyChanged("MenuItem_OpenGraphView");
            }
        }

        public string Label_Header
        {
            get { return label_Header; }
            set
            {
                label_Header = value;
                OnPropertyChanged("Label_Header");
            }
        }

        public string Label_GUID
        {
            get { return label_GUID; }
            set
            {
                label_GUID = value;
                OnPropertyChanged("Label_GUID");
            }
        }

        public string Label_Name
        {
            get { return label_Name; }
            set
            {
                label_Name = value;
                OnPropertyChanged("Label_Name");
            }
        }

        public string Label_Objects
        {
            get { return label_Objects; }
            set
            {
                label_Objects = value;
                OnPropertyChanged("Label_Objects");
            }
        }

        public string Label_Filter
        {
            get { return label_Filter; }
            set
            {
                label_Filter = value;
                OnPropertyChanged("Label_Filter");
            }
        }

        public string Label_Service
        {
            get { return label_Service; }
            set
            {
                label_Service = value;
                OnPropertyChanged("Label_Service");
            }
        }

        public ICommand ClickNavFirst
        {
            get
            {
                return _clickNavFirst ?? (_clickNavFirst = new CommandHandler(() => clickNavFirst(), _canExecute));
            }
        }

        public ICommand ClickNavPrevious
        {
            get
            {
                return _clickNavPrevious ?? (_clickNavPrevious = new CommandHandler(() => clickNavPrevious(), _canExecute));
            }
        }

        public ICommand ClickNavNext
        {
            get
            {
                return _clickNavNext ?? (_clickNavNext = new CommandHandler(() => clickNavNext(), _canExecute));
            }
        }

        public ICommand ClickNavLast
        {
            get
            {
                return _clickNavLast ?? (_clickNavLast = new CommandHandler(() => clickNavLast(), _canExecute));
            }
        }

        public ICommand ClickSortTopDown
        {
            get
            {
                return _clickSortTopDown ?? (_clickSortTopDown = new CommandHandler(() => clickSortTopDown(), _canExecute));
            }
        }

        public ICommand ClickSortBottomUp
        {
            get
            {
                return _clickSortBottomUp ?? (_clickSortBottomUp = new CommandHandler(() => clickSortBottomUp(), _canExecute));
            }
        }

        public void clickSortTopDown()
        {
            var selObject = workObjects[itemIx];
            workObjects.Sort((object1, object2) => object1.Name.CompareTo(object2.Name));
            itemIx = workObjects.IndexOf(selObject);
            InitializeView();
        }

        public void clickSortBottomUp()
        {
            var selObject = workObjects[itemIx];
            workObjects.Sort((object1, object2) => object2.Name.CompareTo(object1.Name));
            itemIx = workObjects.IndexOf(selObject);
            InitializeView();
        }

        public void clickNavFirst()
        {
            if (itemIx > 0)
            {
                itemIx = 0;
                InitializeView();
            }
        }

        public void clickNavPrevious()
        {
            if (itemIx > 0)
            {
                itemIx--;
                InitializeView();
            }
        }

        public void clickNavNext()
        {
            if (itemIx < workObjects.Count - 1)
            {
                itemIx++;
                InitializeView();
            }
        }

        public void clickNavLast()
        {
            if (itemIx < workObjects.Count - 1)
            {
                itemIx = workObjects.Count - 1;
                InitializeView();
            }
        }

        public void SaveName()
        {
            
        }
    }
}
