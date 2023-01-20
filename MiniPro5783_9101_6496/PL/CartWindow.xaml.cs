using BlApi;
using BO;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        IBL bl = Factory.Get();
        //BO.Cart Cart;
        public Cart Cart
        {
            get { return (Cart)GetValue(CartDep); }
            set { SetValue(CartDep, value); }
        }

        // Using a DependencyProperty as the backing store for Cart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CartDep =
            DependencyProperty.Register("Cart", typeof(Cart), typeof(CartWindow));




        public CartWindow( BO.Cart c)
        {
            Cart = c;
            InitializeComponent();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            new ConfirnWindow(Cart).Show();
            //bl.Cart.AprrovedCart(Cart);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

            OrderItem orderItem = (OrderItem)((Button)sender).Tag;
            bl.Cart.UpdateCart(Cart, orderItem.ProductID,0);
            //Cart.Items.Remove(orderItem);
            Cart temp = Cart;
            Cart = null;
            Cart = temp;
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            OrderItem orderItem = (OrderItem)((Button)sender).Tag;
            Cart = bl.Cart.UpdateCart(Cart, orderItem.ProductID, orderItem.Amount);
        }
    }
}