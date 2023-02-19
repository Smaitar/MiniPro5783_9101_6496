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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        BlApi.IBL? bl = Factory.Get();



        public List<BO.OrderItem?> orderItem
        {
            get { return (List<BO.OrderItem?>)GetValue(orderItemProperty); }
            set { SetValue(orderItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for orderItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty orderItemProperty =
            DependencyProperty.Register("orderItem", typeof(List<BO.OrderItem?>), typeof(Window), new PropertyMetadata(null));


        public BO.Order? order
        {
            get { return (BO.Order?)GetValue(orderProperty); }
            set { SetValue(orderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for order.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty orderProperty =
            DependencyProperty.Register("order", typeof(BO.Order), typeof(Window), new PropertyMetadata(null));


        public OrderWindow(int id)
        {
            InitializeComponent();

            orderItem = new List<BO.OrderItem?>();
           try
           {
                order = bl.Order.OrderDetails(id);
           }
                
       
            catch (BO.NotExist ex)
            {
                //MessageBox.Show(ex.Message);
               //A throw an error message box
                string messageBoxText = ex.Message.ToString();
                string caption = "error";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, icon, MessageBoxResult.OK);
           }
         orderItem=order.Items.ToList();
            
        }

        private void update2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order temp = bl.Order.UpdateSuppliedOrder(order.ID);
                order = null;
                order = temp;
            }
            catch(BO.NotExist ex)
            {
                string messageBoxText = ex.Message.ToString();
                string caption = "error";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, icon, MessageBoxResult.OK);
            }
            this.Close();
        }

        private void update1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order temp = bl!.Order.UpdateSentOrder(order!.ID);
                order = null;
                order = temp;
            }
            catch (BO.NotExist ex)
            {
                string messageBoxText = ex.Message.ToString();
                string caption = "error";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, icon, MessageBoxResult.OK);
            }
            this.Close();
        }

       
    }
}
