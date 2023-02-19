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
using BO;
using BlApi;

namespace PL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainProduct : Window
    {
        //IBL bl;
        BlApi.IBL? bl = Factory.Get();
        static Cart cart;
        public MainProduct()
        {
            InitializeComponent();

            list.ItemsSource = bl.Product.GetList();
            AttributeSelector.ItemsSource = Enum.GetValues(typeof(Category));
        }

        public MainProduct(BO.Cart cartu)
        {
              cart = new BO.Cart();
              cart = cartu;
        }

        //search yhr item selected
        private void selection(object sender, SelectionChangedEventArgs e)
        {
            Category category = (Category)AttributeSelector.SelectedItem;

            list.ItemsSource = bl.Product.GetList(x => x!.Category == category);
        }

        //if the user chose to update it comes here and send to the update window
        private void update(object sender, MouseButtonEventArgs e)
        {
            ProductForList product = (ProductForList)list.SelectedItem;
            new ProductFunctions(product.ID, bl).Show();
        }

        //if the user made a Click to add
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new ProductFunctions(bl).Show();

        }
    }
}
