using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.Data;
using WpfOnt.OServiceOItems;

namespace WpfOnt.ViewModel
{
    public class MainWindowModel : ViewModelBase
    {

        private string idClass;

        public MainWindowModel()
        {
            
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
