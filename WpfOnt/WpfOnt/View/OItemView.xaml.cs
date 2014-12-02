using OntologyClasses.BaseClasses;
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
using System.Windows.Threading;
using WpfOnt.Pages;
using WpfOnt.ViewModel;

namespace WpfOnt.View
{
    /// <summary>
    /// Interaktionslogik für OItemView.xaml
    /// </summary>
    public partial class OItemView : UserControl
    {
        private DispatcherTimer timerFilter = new DispatcherTimer();

        //public static readonly DependencyProperty IdParentProperty = DependencyProperty.Register("IdParent", typeof(String), typeof(OItemList), new PropertyMetadata("Test"));
        public static readonly DependencyProperty IdParentProperty =
            DependencyProperty.Register(
              "IdParent", typeof(string), typeof(OItemView),
                new FrameworkPropertyMetadata()
                {
                    PropertyChangedCallback = OnIdParentChanged,
                    BindsTwoWayByDefault = true
                });

        //public static readonly DependencyProperty ItemListProperty =
        //   DependencyProperty.Register("ItemList", typeof(List<clsOntologyItem>), typeof(OItemView));

        public static readonly DependencyProperty GlobalConfigProperty =
            DependencyProperty.Register(
              "GlobalConfig", typeof(Globals), typeof(OItemView),
                new FrameworkPropertyMetadata()
                {
                    PropertyChangedCallback = OnGlobalConfigChanged,
                    BindsTwoWayByDefault = true
                });

        private static void OnGlobalConfigChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (OItemView)d;
            var model = (OItemListModel)userControl.DataContext;
            model.GlobalConfig = (Globals) e.NewValue;
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

        private static void OnIdParentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (OItemView)d;
            var model = (OItemListModel)userControl.DataContext;
            model.RefreshObjects(e.NewValue.ToString());

        }

        //public List<clsOntologyItem> ItemList
        //{
        //    get
        //    {
        //        return (List<clsOntologyItem>)GetValue(ItemListProperty);
        //    }
        //    set
        //    {
        //        SetValue(ItemListProperty, value);
        //    }
        //}

        public string IdParent
        {
            get { return (string)GetValue(IdParentProperty); }
            set
            {
                SetValue(IdParentProperty, value);
            }
        }

        public OItemView()
        {
            InitializeComponent();
            timerFilter.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timerFilter.Tick += timerFilter_Tick;
        }

        void timerFilter_Tick(object sender, EventArgs e)
        {
            timerFilter.Stop();
            var viewModel = (OItemListModel)DataContext;

            viewModel.NameFilter = textBox_Filter.Text;
            viewModel.RefreshObjects();
        }

        private void dataGridViewItems_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Name")
            {
                e.Column.Visibility = System.Windows.Visibility.Visible;

            }
            else
            {
                e.Column.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            timerFilter.Stop();
            
            timerFilter.Start();
            
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var row = (DataGridRow)e.Source;
            var oItem = (clsOntologyItem)row.Item;

            var model = (OItemListModel)DataContext;
            model.OpenObjectEdit(oItem);
        }

    }
}
