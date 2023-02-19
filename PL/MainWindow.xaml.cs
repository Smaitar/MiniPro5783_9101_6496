using BO;
using PL;
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

        private bool _simulatorClick
        {
            get { return (bool)GetValue(_simulatorClickProperty); }
            set { SetValue(_simulatorClickProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _simulatorClickProperty =
            DependencyProperty.Register("_simulatorClick", typeof(bool), typeof(MainWindow), new PropertyMetadata(true));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void manager(object sender, RoutedEventArgs e)
        {
            new ManagerWindows().ShowDialog();
        }

        private void client(object sender, RoutedEventArgs e)
        {
            new ClientWindow().ShowDialog();
        }

        private void simulator(object sender, RoutedEventArgs e)
        {
            _simulatorClick = false;
            new SimulatorWindow(() => _simulatorClick = !_simulatorClick).Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            //new OrderTrackingWindow(id).ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // int id = int.Parse(idText.Text);
            idText.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
            buttonCehck.Visibility = Visibility.Visible;
        }

        private void buttonCehck_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(idText.Text);
            try
            {
                new OrderTrack(id).Show();
            }
            catch
            { }

        }
    }
}
