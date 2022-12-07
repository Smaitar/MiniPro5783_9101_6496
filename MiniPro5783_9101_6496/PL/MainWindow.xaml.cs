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
using BlApi;
using BlImplementation;
using BO;


namespace PL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = new Bl();
            list.ItemsSource = bl.Product.GetList();
            AttributeSelector.ItemsSource = Enum.GetValues(typeof(Category));
        }

        private void selection(object sender, SelectionChangedEventArgs e)
        {
            Category category = (Category)AttributeSelector.SelectedItem;

            list.ItemsSource = bl.Product.GetList(x => x!.Category == category);
        }

        private void update(object sender, MouseButtonEventArgs e)
        {
         ProductForList product = (ProductForList)list.SelectedItem;
            new Window2(product.ID).Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new Window2().Show();

        }
    }
}
