﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RasporedRC
{
    class EnableButtonConverter : IValueConverter
    
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine(value.ToString());
            return (int)value == 0 ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
            
        
    }
}
