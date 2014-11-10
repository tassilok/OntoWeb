using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfOnt.Data
{
    public class MainViewData : INotifyPropertyChanged
    {

        private string idClass;

        public string IdClass
        {
            get { return idClass; }
            set
            {
                idClass = value;
                OnPropertyChanged("IdClass");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
