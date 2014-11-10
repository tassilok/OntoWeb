using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfOnt.Data;
using WpfOnt.ViewModel;

namespace WpfOnt.View
{
    public delegate void SelectedNodeDelegate(OTreeNode oTreeNode);

    /// <summary>
    /// Interaction logic for TypeTree.xaml
    /// </summary>
    public partial class TypeTree : UserControl
    {
        

        public event SelectedNodeDelegate SelectedNode;

        private DispatcherTimer timerSearch = new DispatcherTimer();
        private static string searchClass;

        private Brush nodeBackground;

        private void searchNode(string search, OTreeNode parentNode)
        {
            if (parentNode == null)
            {
                foreach (OTreeNode treeNodeSub in treeView_Classes.Items)
                {
                    treeNodeSub.Background = nodeBackground;
                    if (search!= "" && treeNodeSub.Name.ToLower().Contains(search.ToLower()))
                    {
                        treeNodeSub.Background = Brushes.Yellow;
                        
                    }
                    searchNode(search, treeNodeSub);
                }
            }
            else
            {
                foreach (OTreeNode treeNodeSub in parentNode.Nodes)
                {
                    treeNodeSub.Background = nodeBackground;
                    if (search != "" && treeNodeSub.Name.ToLower().Contains(search.ToLower()))
                    {
                        treeNodeSub.Background = Brushes.Yellow;
                        
                    }
                    searchNode(search, treeNodeSub);
                }
            }
        }

        public TypeTree()
        {
            InitializeComponent();
            timerSearch.Stop();
            timerSearch.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timerSearch.Tick += timerSearch_Tick;
            
        }

        void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();
            searchNode(searchClass, null);            
        }


        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            timerSearch.Stop();
            var node = (OTreeNode)e.NewValue;

            var model = (TypeTreeModel)DataContext;
            model.GuidClass = node.Id;

            SelectedNode(node);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            timerSearch.Stop();
            var textBox = (TextBox) e.Source;
            searchClass = textBox.Text;
            var nodeItem = (OTreeNode)treeView_Classes.Items[0];

            nodeBackground = nodeItem.Background;

            timerSearch.Start();
        }
    }
}
