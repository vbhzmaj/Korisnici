using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfUserAdmin.Model
{
    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string convertedValue = "";

            bool initialValue = (bool)value;

            if (initialValue == false)
            {
                return "0";
            }
            else if (initialValue == true)
            {
                return "1";
            }
            else return null;//{ return convertedValue; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string initialValue = ((string)value).Trim();
                     
                if (initialValue == "1") { return true; }
                else if (initialValue == "0") { return false; }
                else { return null; }
        }

    }

}
