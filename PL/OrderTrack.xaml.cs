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
    /// Interaction logic for OrderTruckingWindow.xaml
    /// </summary>
    public partial class OrderTrack : Window
    {
        IBL bl = Factory.Get();
        //public OrderTracking OrderTracking
        //{
        //    get { return (OrderTracking)GetValue(OrderTruckingDep); }
        //    set { SetValue(OrderTruckingDep, value); }
        //}

        //// Using a DependencyProperty as the backing store for OrderTrucking.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty OrderTruckingDep =
        //    DependencyProperty.Register(nameof(OrderTracking), typeof(OrderTrack));

        public OrderTracking orderTracking
        {
            get { return (OrderTracking)GetValue(OrderTrackingProperty); }
            set { SetValue(OrderTrackingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrderTracking.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderTrackingProperty =
            DependencyProperty.Register("orderTracking", typeof(OrderTracking), typeof(OrderTrack));


        public OrderTrack()
        {
            InitializeComponent();
            try
            {
                orderTracking = new OrderTracking { StatusList = new List<Tuple<DateTime?, OrderStatus?>>() };
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public OrderTrack(int id)
        {
            InitializeComponent();
            try
            {
                orderTracking = new OrderTracking { StatusList = new List<Tuple<DateTime?, OrderStatus?>>() };
                orderTracking = bl.Order.OrderTracking(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

        }

        private void Search(object sender, RoutedEventArgs e)
        {
            try
            {
                //OrderTracking = bl.IOrder.OrderTracking(OrderTracking.ID);
                orderTracking = bl.Order.OrderTracking(orderTracking.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not found");
            }
        }
    }
}