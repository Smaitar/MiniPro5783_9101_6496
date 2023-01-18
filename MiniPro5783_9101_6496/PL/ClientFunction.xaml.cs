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
using BO;
using DalApi;

namespace PL
{
    /// <summary>
    /// Interaction logic for ClientFunction.xaml
    /// </summary>
    public partial class ClientFunction : Window
    {
        public static readonly BlApi.IBL? bl = BlApi.Factory.Get();
        public  BO.Cart cart;
        static  DependencyProperty ProductItemDep = DependencyProperty.Register(nameof(productItem), typeof(ProductItem), typeof(ClientFunction));
        BO.ProductItem productItem { get => (BO.ProductItem)GetValue(ProductItemDep); set => SetValue(ProductItemDep, value); }
        // BO.ProductItem productItem { get; set; }


        //public BO.ProductItem productItem
        //{
        //    get { return (BO.ProductItem)GetValue(productItemProperty); }
        //    set { SetValue(productItemProperty, value); }
        //}

        //Using a DependencyProperty as the backing store for productItem.This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty productItemProperty =
        //    DependencyProperty.Register("productItem", typeof(BO.ProductItem), typeof(Window), new PropertyMetadata(null));



        //public BO.Cart MyCart
        //{
        //    get { return (BO.Cart)GetValue(MyCartProperty); }
        //    set { SetValue(MyCartProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyCart.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MyCartProperty =
        //    DependencyProperty.Register("MyCart", typeof(BO.Cart), typeof(Window), new PropertyMetadata(null));



        public ClientFunction(BO.ProductItem ProductItem, Cart c)
        {
            InitializeComponent();
            productItem = ProductItem;
            cart = c;
        }

        //public ClientFunction(int id)
        //{
        //    InitializeComponent();
        //    BO.ProductItem dep = new BO.ProductItem();

        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = (ProductItem)((ListView)sender).SelectedItem;
            //new Cart(selected).ShowDialog();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if(!cart.Items.Exists(x=> x!.ID==productItem.ID))
                cart = bl.Cart.AddProduct(cart, productItem.ID);
            if (int.Parse(amountOfProducts.Text) > 1)
                cart = bl.Cart.UpdateCart(cart, productItem.ID, int.Parse(amountOfProducts.Text));
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cart_Click(object sender, RoutedEventArgs e)
        {
            new CartWindow(cart).Show();
            this.Close();       
        }
    }
}
