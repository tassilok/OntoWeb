using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.ViewModel;

namespace WpfOnt.Data
{
    public class ObjectRefChildNode : NotifyPropertyChange
    {
        Globals globals;
        public NodeType TypeOfNode { get; set; }
        public ObjectRefChildNode(Globals globals)
        {
            this.globals = globals;
        }

        public Visibility VisiblePresent
        {
            get
            {
                return Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Color BackColor
        {
            get
            {
                if (Max == -1)
                {
                    if (Count >= Min)
                    {
                        return Color.Green;
                    }
                    else
                    {
                        return Color.SandyBrown;
                    }

                }
                else
                {
                    if (Count >= min && Count <= max)
                    {
                        return Color.Green;
                    }
                    else
                    {
                        return Color.SandyBrown;
                    }
                }
            }
        }
        
        public string NameNode
        {
            get
            {
                if (TypeOfNode == NodeType.AttributeNode)
                {
                    return NameRight + " (" + Min + " / " + Count + " / " + Max + ")";
                }
                else
                {

                    if (IdDirection == globals.Directions.Direction_LeftRight.GUID)
                    {
                        return NameRel + " / " + NameRight + " (" + Min + " / " + Count + " / " + Max + ")";
                    }
                    else
                    {
                        return NameRel + " / " + NameLeft + " (" + Min + " / " + Count + " / " + Max + ")";
                    }
                }
            }
        }
        public string IdLeft { get; set; }
        public string NameLeft { get; set; }
        public string IdRel { get; set; }
        public string NameRel { get; set; }
        public string IdRight { get; set; }
        public string NameRight { get; set; }
        public string IdDirection { get; set; }
        private long min { get; set; }
        public long Min 
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
                OnPropertyChanged("Min");
                OnPropertyChanged("BackColor");
            }
        }
        private long count { get; set; }
        public long Count 
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
                OnPropertyChanged("BackColor");
                OnPropertyChanged("VisiblePresent");
            }
        }

        private long max { get; set; }
        public long Max
        {
            get { return max; }
            set
            {
                max = value;
                OnPropertyChanged("Max");
                OnPropertyChanged("BackColor");
            }
        }
        
    }
}
