using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace CollectionviewSourceSample
{
    public class BooleanVisiblityConverter :IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool convParameter = this.GetConverterParameter(parameter);
            bool selected = (bool)value;

            return convParameter==selected ? Visibility.Visible : Visibility.Collapsed;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Not Implemented");
        }

        #endregion

        private bool GetConverterParameter(object parameter)
        {
            try
            {
                bool convParameter = true;
                if (parameter != null)
                    convParameter = System.Convert.ToBoolean(parameter);
                return convParameter;
            }
            catch { return false; }
        }
    }
}
