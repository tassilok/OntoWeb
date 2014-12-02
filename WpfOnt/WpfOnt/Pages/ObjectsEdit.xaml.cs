using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfOnt.Data;
using WpfOnt.Pages.PagesViewModels;

namespace WpfOnt.Pages
{
    /// <summary>
    /// Interaktionslogik für ObjectsEdit.xaml
    /// </summary>
    public partial class ObjectsEdit : Window
    {
        ObjectsEditModel model;

        

        private DispatcherTimer timerFilter = new DispatcherTimer();
        private DispatcherTimer timerName = new DispatcherTimer();

        public ObjectsEdit(List<clsOntologyItem> objects, int itemIx, Globals globals)
        {
           

            InitializeComponent();

            model = (ObjectsEditModel) DataContext;
            model.GlobalConfig = globals;

            timerFilter.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timerFilter.Tick += timerFilter_Tick;

            timerName.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timerName.Tick += timerName_Tick;

            model = (ObjectsEditModel)DataContext;
            model.Objects = objects;
            model.ItemIx = itemIx;
            model.InitializeView();
        }

        void timerName_Tick(object sender, EventArgs e)
        {
            timerName.Stop();
            model.SaveName();
        }

        void timerFilter_Tick(object sender, EventArgs e)
        {
            timerFilter.Stop();
           model.InitializeView();          
        }

        private void Window_Initialized_1(object sender, EventArgs e)
        {
            
            
        }

        private void TextBox_TextChanged_Filter(object sender, TextChangedEventArgs e)
        {
            timerFilter.Stop();
            timerFilter.Start();
        }

        private void TextBox_TextChanged_Name(object sender, TextChangedEventArgs e)
        {
            timerName.Stop();
            timerName.Start();
        }
    }
}
