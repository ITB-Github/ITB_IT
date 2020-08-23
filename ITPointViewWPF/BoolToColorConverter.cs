using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ITPointViewWPF
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            SolidColorBrush color;
            // Setting default values
            var colorIfTrue = (Color)ColorConverter.ConvertFromString("#00a000");
            var colorIfFalse = (Color)ColorConverter.ConvertFromString("#FFCB301E");
            double opacity = 1;
            // Parsing converter parameter
            //if (parameter != null)
            //{
            //    // Parameter format: [ColorNameIfTrue;ColorNameIfFalse;OpacityNumber]
            //    var parameterstring = parameter.ToString();
            //    if (!string.IsNullOrEmpty(parameterstring))
            //    {
            //        var parameters = parameterstring.Split(';');
            //        var count = parameters.Length;
            //        if (count > 0 && !string.IsNullOrEmpty(parameters[0]))
            //        {
            //            colorIfTrue = ColorFromName(parameters[0]);
            //        }
            //        if (count > 1 && !string.IsNullOrEmpty(parameters[1]))
            //        {
            //            colorIfFalse = ColorFromName(parameters[1]);
            //        }
            //        if (count > 2 && !string.IsNullOrEmpty(parameters[2]))
            //        {
            //            double dblTemp;
            //            if (double.TryParse(parameters[2], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture.NumberFormat, out dblTemp))
            //                opacity = dblTemp;
            //        }
            //    }
            //}
            // Creating Color Brush
            if ((bool)value)
            {
                color = new SolidColorBrush(colorIfTrue);
                color.Opacity = opacity;
            }
            else
            {
                color = new SolidColorBrush(colorIfFalse);
                color.Opacity = opacity;
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public static Color ColorFromName(string colorName)
        {
            Color systemColor = (Color)ColorConverter.ConvertFromString(colorName);
            return Color.FromArgb(systemColor.A, systemColor.R, systemColor.G, systemColor.B);
        }
    }
}
