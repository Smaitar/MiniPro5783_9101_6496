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
//
namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerWindows.xaml
    /// </summary>
    public partial class ManagerWindows : Window
    {
        public ManagerWindows()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainProduct().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainOrders().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
