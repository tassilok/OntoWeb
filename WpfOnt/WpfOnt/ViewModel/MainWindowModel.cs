using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.Data;

namespace WpfOnt.ViewModel
{
    public class MainWindowModel : ViewModelBase
    {

        private string idClass;
        private Globals globalConfig;
        private clsLocalConfig localConfig;

        public MainWindowModel()
        {
            
        }

        public clsLocalConfig LocalConfig
        {
            get { return localConfig; }
            set
            {
                localConfig = value;
                OnPropertyChanged("LocalConfig");
            }
        }

        public Globals GlobalConfig
        {
            get { return globalConfig; }
            set
            {
                globalConfig = value;
                localConfig = new clsLocalConfig(globalConfig);
                OnPropertyChanged("GlobalConfig");
            }
        }

        public string IdClass
        {
            get { return idClass; }
            set
            {
                idClass = value;
                OnPropertyChanged("IdClass");
            }
        }
    }
}
