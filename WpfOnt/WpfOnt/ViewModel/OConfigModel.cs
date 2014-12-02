using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt.ViewModel
{
    public class OConfigModel : ViewModelBase
    {
        private string textApply = "x_Apply";
        private string textCancel = "x_Cancel";
        private string windowTitle;

        public string TextApply
        {
            get { return textApply; }
            set
            {
                textApply = value;
                OnPropertyChanged("TextApply");
            }
        }

        public string TextCancel
        {
            get { return textCancel; }
            set
            {
                textCancel = value;
                OnPropertyChanged("TextCancel");
            }
        }

        public string WindowTitle
        {
            get { return windowTitle; }
            set
            {
                windowTitle = value;
                OnPropertyChanged("WindowTitle");
            }
        }
    }
}
