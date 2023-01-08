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

namespace MyProduct
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // productViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource productForListViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productForListViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // productForListViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource productForListViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productForListViewSource1")));
            // Load data by setting the CollectionViewSource.Source property:
            // productForListViewSource1.Source = [generic data source]
        }

        private void productForListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
