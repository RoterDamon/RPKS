using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using Denisova.WPF.MVVM.Core.Converter;

namespace Denisova.Wpf.MVVM
{
    public class StrikinglyConverter : MultiConverterBase<StrikinglyConverter>
    {
        public enum BitwiseOperations
        {
            BitwiseOr,
            BitwiseAnd,
            Xor,
            BitwiseNot
        }
        public override object Convert([NotNull] object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) 
                throw new ArgumentNullException(nameof(values));
            
            if (values.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(values));

            if (!(Enum.IsDefined(typeof(BitwiseOperations), parameter)))
            {
                throw new ArgumentException("parameter should be of type Order Relation Operations",
                    nameof(parameter));
            }
            
            if (values.Length == 1 && parameter == (object)BitwiseOperations.BitwiseNot)
            {
                if (values[0] == DependencyProperty.UnsetValue)
                    return DependencyProperty.UnsetValue;
                else
                    return ~(dynamic)values[0];
            }
            
            if (values[0] == DependencyProperty.UnsetValue ||
                values[1] == DependencyProperty.UnsetValue)
            {
                return DependencyProperty.UnsetValue;
            }

            var leftOperand = (dynamic)values[0];
            var rightOperand = (dynamic)values[1];

            return parameter switch
            {
                BitwiseOperations.BitwiseOr => leftOperand | rightOperand,
                BitwiseOperations.BitwiseAnd => leftOperand & rightOperand,
                BitwiseOperations.Xor => leftOperand ^ rightOperand,
                _ => throw new ArgumentException("Invalid operation", nameof(parameter))
            };
        }
    }
}