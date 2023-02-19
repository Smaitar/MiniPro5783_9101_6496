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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PL
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        BlApi.IBL? bl = Factory.Get();
        static BO.Cart cart;

        public ObservableCollection<ProductItem> ProductsList
        {
            get { return (ObservableCollection<ProductItem>)GetValue(ProductsListProperty)!; }
            set { SetValue(ProductsListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductsList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductsListProperty =
            DependencyProperty.Register("ProductsList", typeof(ObservableCollection<ProductItem>), typeof(ClientWindow));


        // Using a DependencyProperty as the backing store for Cart.  This enables animation, styling, binding, etc...

        public ICollectionView CollectionViewProductList { set; get; }

        private string ProductGroupName;

        private PropertyGroupDescription ProductGroupDescription;


        public ClientWindow()
        {
            InitializeComponent();
            cart = new Cart { Items = new List<OrderItem?>() };
            ProductsList = new ObservableCollection<ProductItem>(bl.Product.GetListToClient(cart));
            ProductGroupName = "Category";
            CollectionViewProductList = CollectionViewSource.GetDefaultView(ProductsList);
            ProductGroupDescription = new PropertyGroupDescription(ProductGroupName);
            CollectionViewProductList.GroupDescriptions.Add(ProductGroupDescription);
        }

        public ClientWindow(BO.Cart cartu)
        {
            cart = cartu;
        }

        private void selection(object sender, SelectionChangedEventArgs e)
        {
            Category category = (Category)AttributeSelector.SelectedItem;

            ProductsList = (ObservableCollection<ProductItem>)bl!.Product.GetList(x => x!.Category == category);
            //ProductsList = bl.Product.GetList(x => x!.Category == category);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CartWindow(cart).ShowDialog();

        }

        private void UpdateCart(object sender, RoutedEventArgs e)
        {
            ProductItem productItem = (ProductItem)((Button)sender).Tag;
            string action = ((Button)sender).Content.ToString()!;
            e.Handled= true;
            try
            {

                switch (action)
                {
                    case "X":
                        cart = bl!.Cart.UpdateCart(cart, productItem.ID, 0);
                        break;
                    case "➖":
                        cart = bl!.Cart.UpdateCart(cart, productItem.ID, productItem.Amount - 1);
                        break;
                    case "➕":
                        cart = bl!.Cart.UpdateCart(cart, productItem.ID, productItem.Amount + 1);
                        break;
                    default:
                        return;
                }
                ProductsList = new ObservableCollection<ProductItem>(bl.Product.GetListToClient(cart));
                CollectionViewProductList = CollectionViewSource.GetDefaultView(ProductsList);
                CollectionViewProductList.GroupDescriptions.Add(ProductGroupDescription);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void list_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;   
            var selected = (ProductItem)((ListView)sender).SelectedItem;
            new ClientFunction(selected, cart).ShowDialog();

        }
    }
}
