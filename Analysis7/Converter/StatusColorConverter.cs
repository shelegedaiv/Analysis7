using System;
using System.Globalization;
using System.Windows.Data;

namespace Analysis7.Converter
{
    public class StatusColorConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var probability = (double)values[0];
            var status = (bool)values[1];
            if (!status) return "";
            if (probability < 0.2) return "Дуже низький";
            else if (probability < 0.4) return "Низький";
            else if (probability < 0.6) return "Середній";
            else if (probability < 0.8) return "Високий";
            else return "Дуже високий";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}