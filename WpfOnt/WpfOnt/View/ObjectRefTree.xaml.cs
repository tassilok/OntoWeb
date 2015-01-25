using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WpfOnt.ViewModel;

namespace WpfOnt.View
{
    /// <summary>
    /// Interaktionslogik für ObjectRefTree.xaml
    /// </summary>
    public partial class ObjectRefTree : UserControl
    {
        public static readonly DependencyProperty LocalConfigProperty =
           DependencyProperty.Register(
             "LocalConfig", typeof(clsLocalConfig), typeof(ObjectRefTree),
               new FrameworkPropertyMetadata()
               {
                   PropertyChangedCallback = OnLocalConfigChanged,
                   BindsTwoWayByDefault = true
               });

        private static void OnLocalConfigChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (ObjectRefTree)d;
            var model = (ObjectRefTreeModel)userControl.DataContext;
            model.LocalConfig = (clsLocalConfig)e.NewValue;
        }


        public clsLocalConfig LocalConfig
        {
            get
            {
                return (clsLocalConfig)GetValue(LocalConfigProperty);
            }
            set
            {
                SetValue(LocalConfigProperty, value);
            }
        }

        public static readonly DependencyProperty GlobalConfigProperty =
           DependencyProperty.Register(
             "GlobalConfig", typeof(Globals), typeof(ObjectRefTree),
               new FrameworkPropertyMetadata()
               {
                   PropertyChangedCallback = OnGlobalConfigChanged,
                   BindsTwoWayByDefault = true
               });

        private static void OnGlobalConfigChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (ObjectRefTree)d;
            var model = (ObjectRefTreeModel)userControl.DataContext;
            model.GlobalConfig = (Globals)e.NewValue;
        }

        public Globals GlobalConfig
        {
            get
            {
                return (Globals)GetValue(GlobalConfigProperty);
            }
            set
            {
                SetValue(GlobalConfigProperty, value);
            }
        }

        public static readonly DependencyProperty ShowAttributesProperty =
           DependencyProperty.Register(
             "ShowAttributes", typeof(bool), typeof(ObjectRefTree),
               new FrameworkPropertyMetadata()
               {
                   PropertyChangedCallback = OnShowAttributesChanged,
                   BindsTwoWayByDefault = true
               });

        private static void OnShowAttributesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (ObjectRefTree)d;
            var model = (ObjectRefTreeModel)userControl.DataContext;
            
            model.ShowAttributes = (bool)e.NewValue;
        }

        public bool ShowAttributes
        {
            get
            {
                return (bool)GetValue(ShowAttributesProperty);
            }
            set
            {
                SetValue(ShowAttributesProperty, value);
            }
        }

        public static readonly DependencyProperty ShowRelForwProperty =
           DependencyProperty.Register(
             "ShowRelForw", typeof(bool), typeof(ObjectRefTree),
               new FrameworkPropertyMetadata()
               {
                   PropertyChangedCallback = OnShowRelForwChanged,
                   BindsTwoWayByDefault = true
               });

        private static void OnShowRelForwChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (ObjectRefTree)d;
            var model = (ObjectRefTreeModel)userControl.DataContext;
            model.ShowRelForw = (bool)e.NewValue;
        }

        public bool ShowRelForw
        {
            get
            {
                return (bool)GetValue(ShowRelForwProperty);
            }
            set
            {
                SetValue(ShowRelForwProperty, value);
            }
        }

        public static readonly DependencyProperty ShowRelBackwProperty =
           DependencyProperty.Register(
             "ShowRelBackw", typeof(bool), typeof(ObjectRefTree),
               new FrameworkPropertyMetadata()
               {
                   PropertyChangedCallback = OnShowRelBackwChanged,
                   BindsTwoWayByDefault = true
               });

        private static void OnShowRelBackwChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (ObjectRefTree)d;
            var model = (ObjectRefTreeModel)userControl.DataContext;
            model.ShowRelBackw = (bool)e.NewValue;
        }

        public bool ShowRelBackw
        {
            get
            {
                return (bool)GetValue(ShowRelBackwProperty);
            }
            set
            {
                SetValue(ShowRelBackwProperty, value);
            }
        }
        

        public static readonly DependencyProperty IdObjectProperty =
            DependencyProperty.Register(
              "IdObject", typeof(string), typeof(ObjectRefTree),
                new FrameworkPropertyMetadata()
                {
                    PropertyChangedCallback = OnIdObjectChanged,
                    BindsTwoWayByDefault = true
                });

        public string IdObject
        {
            get { return (string)GetValue(IdObjectProperty); }
            set
            {
                SetValue(IdObjectProperty, value);
            }
        }

        private static void OnIdObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (ObjectRefTree)d;
            var model = (ObjectRefTreeModel)userControl.DataContext;
            if (!string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                model.InitializeTree(e.NewValue.ToString());
 
            }
            //model.RefreshObjects(e.NewValue.ToString());
        }

        public ObjectRefTree()
        {
            InitializeComponent();
        }
    }
}
