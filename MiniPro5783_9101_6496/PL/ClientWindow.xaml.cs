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
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        BlApi.IBL? bl = Factory.Get();
        static BO.Cart cart;
        public ClientWindow()
        {
            InitializeComponent();
            cart = new BO.Cart();
            cart.Items = new List<OrderItem?>();
            list.ItemsSource = bl.Product.GetListToClient(cart);
            AttributeSelector.ItemsSource = Enum.GetValues(typeof(Category));
        }
        //public ClientWindow(BO.Cart cartu)
        //{
        //    cart = new BO.Cart();
        //    cart = cartu;
        //}

        private void selection(object sender, SelectionChangedEventArgs e)
        {
            Category category = (Category)AttributeSelector.SelectedItem;

            list.ItemsSource = bl.Product.GetList(x => x!.Category == category);
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (ProductItem)((ListView)sender).SelectedItem;
            new ClientFunction(selected).ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CartWindow(cart).ShowDialog();

        }
    }
}
