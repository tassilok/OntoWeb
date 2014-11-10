using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows8Ont.OServiceClasses;

// Die Elementvorlage "Benutzersteuerelement" ist unter http://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.

namespace Windows8Ont
{
    public sealed partial class TypeTree : UserControl
    {
        public List<clsOntologyItem> ClassList { get; private set; }
        public string ItemCount { get; private set; }

        private OServiceClassesSoapClient oServiceClassesSoapClient = new OServiceClassesSoapClient();

        public TypeTree()
        {
            this.InitializeComponent();
            GetClasses();
            

        }

        private async void GetClasses()
        {
            clsOntologyItem[] results = await oServiceClassesSoapClient.ClassesAsync();
            TreeViewClasses.ItemsSource = results.ToList();

            TextBlockItemCount.Text = TreeViewClasses.Items.Count.ToString();
            //ClassList = results.ToList();
            //ItemCount = ClassList.Count.ToString();
        }
        
    }
}
