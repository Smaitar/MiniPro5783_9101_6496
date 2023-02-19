using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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




        public CartWindow(BO.Cart c)
        {
            Cart = c;
            InitializeComponent();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            new ConfirnWindow(Cart).Show();
            //bl.Cart.AprrovedCart(Cart);
        }

        private void UpdateCart(object sender, RoutedEventArgs e)
        {
            OrderItem OrderItem = (OrderItem)((Button)sender).Tag;
            string action = ((Button)sender).Content.ToString()!;
            Cart temp;

            try
            {
                switch (action)
                {
                    case "❌":
                        temp = bl!.Cart.UpdateCart(Cart, OrderItem.ProductID, 0);
                        break;
                    case "➖":
                        temp = bl!.Cart.UpdateCart(Cart, OrderItem.ProductID, OrderItem.Amount - 1);
                        break;
                    case "➕":
                        temp = bl!.Cart.UpdateCart(Cart, OrderItem.ProductID, OrderItem.Amount + 1);
                        break;
                    default:
                        return;
                }
                Cart = null!;
                Cart = temp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}