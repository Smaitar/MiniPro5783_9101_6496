﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PL;

public class ButtonVisible : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      => ((bool)value)==true ? Visibility.Visible : Visibility.Hidden;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
