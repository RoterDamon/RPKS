using System;
using System.Globalization;
using System.Windows;
using Denisova.WPF.MVVM.Core.Converter;

namespace Denisova.Wpf.MVVM
{
    public class BoolChecks : MultiConverterBase<BoolChecks>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 3)
                throw new ArgumentOutOfRangeException(nameof(values), "values count should be equal to 3");

            if (values[0] == DependencyProperty.UnsetValue ||
                values[1] == DependencyProperty.UnsetValue ||
                values[2] == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }

            if (!(values[0] is bool @bool))
            {
                throw new ArgumentOutOfRangeException(nameof(values), "values[0] should be of type System.Boolean");
            }

            return @bool ? values[1] : values[2];
        }
    }
}