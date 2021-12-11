using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Denisova.WPF.MVVM.Core.Converter;

namespace Denisova.WPF.Controls
{
    public sealed class IndexInCollectionConverter : MultiConverterBase<IndexInCollectionConverter>
    {
        
        #region MultiConverterBase overrides

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new ArgumentException("values count != 2", nameof(values));
            }

            if (!(values[0] is IEnumerable enumerable))
            {
                throw new ArgumentException("values[0] should implement IEnumerable");
            }

            var index = 0;
            foreach (var value in enumerable)
            {
                if (value.Equals(values[1]))
                {
                    return index;
                }

                ++index;
            }

            return -1;
        }

        #endregion
        
    }
}