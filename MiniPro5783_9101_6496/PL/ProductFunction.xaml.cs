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
using DalApi;


namespace PL
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class ProductFunctions : Window
    {
        IBL bl = new Bl();
        public ProductFunctions(int id)
        {

            InitializeComponent();
            Product product = new Product();
            try
            {
                product = bl.Product.GetById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (product != null)
            {
                IDtxt.Text = product.ID.ToString();
                IDtxt.IsEnabled = false;
                Nametxt.Text = product.Name;
                Pricetxt.Text = product.Price.ToString();
                InStocktxt.Text = product.InStock.ToString();
                Categorybox.ItemsSource = Enum.GetValues(typeof(Category));
                Categorybox.SelectedItem = product.Category;
                Upbtn.Visibility = Visibility.Visible;
                addbtn.Visibility = Visibility.Collapsed;
            }
        }
        public ProductFunctions()
        {
            InitializeComponent();

            Categorybox.ItemsSource = Enum.GetValues(typeof(Category));
            Upbtn.Visibility = Visibility.Collapsed;
            addbtn.Visibility = Visibility.Visible;

        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            BO.Product product = new BO.Product();
            product.ID = int.Parse(IDtxt.Text);
            product.Name = Nametxt.Text;
            product.Price = double.Parse(Pricetxt.Text);
            product.InStock = int.Parse(InStocktxt.Text);
            product.Category = (Category)Categorybox.SelectedItem;


            try
            {
                bl.Product.Add(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void Upbtn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product()
            {
                ID = int.Parse(IDtxt.Text),
                Name = Nametxt.Text,
                Price = double.Parse(Pricetxt.Text),
                InStock = int.Parse(InStocktxt.Text),
                Category = (Category)Categorybox.SelectedItem,
            };

            try
            {
                bl.Product.Update(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void idtx(object sender, KeyEventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text == null) return;

            if (e == null) return;

            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);



            if (Char.IsControl(c)) return;



            if (Char.IsDigit(c))

                if (!(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightAlt)))

                    return;

            e.Handled = true;



            return;
        }

        private void ins(object sender, KeyEventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text == null) return;

            if (e == null) return;

            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);



            if (Char.IsControl(c)) return;



            if (Char.IsDigit(c))

                if (!(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightAlt)))

                    return;

            e.Handled = true;



            return;
        }

        private void price(object sender, KeyEventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text == null) return;

            if (e == null) return;

            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);



            if (Char.IsControl(c)) return;



            if (Char.IsDigit(c))

                if (!(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightAlt)))

                    return;

            e.Handled = true;



            return;
        }
    }
}
