﻿using System;
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
    /// Interaction logic for MainOrders.xaml
    /// </summary>
    public partial class MainOrders : Window
    {
        BlApi.IBL? bl = Factory.Get();
        public MainOrders()
        {
            InitializeComponent();
            OrderListView.ItemsSource=bl.Order.GetOrderForListsManager();
        }

        private void OrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BO.OrderForList? orderForList= OrderListView.SelectedItem as BO.OrderForList;
            //if (orderForList!=null)
            //{
            //    OrderWindow orderWindow= new OrderWindow(orderForList.ID);
            //    orderWindow.ShowDialog();
            //    //OrderListView.ItemsSource=bl?.Order.GetOrderForListsManager().ToList();

            //}
            
        }

        private void OrderListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.OrderForList? orderForList = OrderListView.SelectedItem as BO.OrderForList;
            if (orderForList != null)
            {
                OrderWindow orderWindow = new OrderWindow(orderForList.ID);
                orderWindow.ShowDialog();
                OrderListView.ItemsSource=bl?.Order.GetOrderForListsManager().ToList();

            }


        }
    }
}
