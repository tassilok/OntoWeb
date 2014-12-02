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

        public MainWindowModel()
        {
            
        }

        public Globals GlobalConfig
        {
            get { return globalConfig; }
            set
            {
                globalConfig = value;
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
