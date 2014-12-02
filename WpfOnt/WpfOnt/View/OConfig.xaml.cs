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
using System.Windows.Shapes;
using WpfOnt.ViewModel;

namespace WpfOnt.View
{
    /// <summary>
    /// Interaktionslogik für OConfig.xaml
    /// </summary>
    public partial class OConfig : Window
    {
        public OConfig(string errorMessage)
        {
            InitializeComponent();

            var model = (OConfigModel) this.DataContext;
            model.WindowTitle = errorMessage;
        }
    }
}
