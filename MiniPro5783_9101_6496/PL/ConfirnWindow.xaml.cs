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
using BlApi;
using BO;
using DalApi;

namespace PL
{
    /// <summary>
    /// Interaction logic for ConfirnWindow.xaml
    /// </summary>
    public partial class ConfirnWindow : Window
    {
        BlApi.IBL? bl = BlApi.Factory.Get();
        static BO.Cart cart;
        public ConfirnWindow(BO.Cart cart1)
        {
            InitializeComponent();

            cart1 = cart;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(bl.Cart.AprrovedCart(cart))
                MessageBox.Show("The order confirmed");

        }
    }
}
