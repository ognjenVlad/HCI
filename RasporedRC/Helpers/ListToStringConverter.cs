using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using RasporedRC.Model;
namespace RasporedRC
{
    public class ListToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<Software> s=(List<Software>)value;
            List<String> labels = new List<string>();
            if (s == null)
            {
                return "";
            }
            foreach(Software soft in s)
            {
                labels.Add(soft.label);
            }
            String text = String.Join(", ", (labels.ToArray()));
            text = text.Replace(",", "," + System.Environment.NewLine);
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
