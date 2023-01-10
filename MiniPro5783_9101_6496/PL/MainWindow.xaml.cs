using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for MainWindow1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void manager(object sender, RoutedEventArgs e)
        {
            new ManagerWindow().ShowDialog();
        }

        private void client(object sender, RoutedEventArgs e)
        {
            new ClientWindow().ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
   
            //new OrderTrackingWindow(id).ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            idText.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
            buttonCehck.Visibility = Visibility.Visible;  
        }

        //private void buttonCehck(object sender, RoutedEventArgs e)
        //{
        //    new OrderTrack().Show();
        //}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCehck_Click(object sender, RoutedEventArgs e)
        {
            //int id = int.Parse(idText.Text);
            new OrderTrack().Show();
        }
    }
}
