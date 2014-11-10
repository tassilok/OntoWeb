using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.ViewModel;

namespace WpfOnt.Data
{
    public class OTreeNode : NotifyPropertyChange
    {
        private string name;
        private bool isExpanded;
        private bool isSelected;

        private System.Windows.Media.Brush background;

        public string Id { get; set; }
        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public List<OTreeNode> Nodes { get; set; }
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public bool IsRoot { get; set; }
        public System.Windows.Media.Brush Background 
        {
            get { return background; }
            set
            {
                background = value;
                OnPropertyChanged("Background");
            }
        }

        public OTreeNode()
        {
            Nodes = new List<OTreeNode>();
        }
    }
}
