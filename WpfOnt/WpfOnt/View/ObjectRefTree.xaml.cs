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
            var model = (ObjectRefTree)userControl.DataContext;
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
