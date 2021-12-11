using System.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Input;

namespace Denisova.WPF.Controls
{
    public partial class DialogHost : UserControl
    {
        public DialogHost()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty DialogOpacityProperty = DependencyProperty.Register(
            nameof(DialogOpacity), typeof(double), typeof(DialogHost), new PropertyMetadata(0.4d, 
                (d, o) => {},
                (d, o) =>
                {
                    var dialog = (DialogHost) d;
                    if (!(o is double @double))
                    {
                        throw new ArgumentException("Invalid value type", nameof(o));
                    }

                    if (@double < 0.0)
                    {
                        @double = 0.0;
                    }

                    if (@double > 1.0)
                    {
                        @double = 1.0;
                    }
                    return @double;
                }));
        public double DialogOpacity
        {
            get =>
                (double)GetValue(DialogOpacityProperty);

            set =>
                SetValue(DialogOpacityProperty, value);
        }
        
        public static readonly DependencyProperty DialogCornerRadiusProperty = DependencyProperty.Register(
            nameof(DialogCornerRadius), typeof(CornerRadius), typeof(DialogHost), new PropertyMetadata(new CornerRadius(0)));
        public CornerRadius DialogCornerRadius
        {
            get =>
                (CornerRadius)GetValue(DialogCornerRadiusProperty);

            set =>
                SetValue(DialogCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CloseDialogCommandProperty = DependencyProperty.Register(
            nameof(CloseDialogCommand), typeof(ICommand), typeof(DialogHost));

        public ICommand CloseDialogCommand
        {
            get =>
                (ICommand) GetValue(CloseDialogCommandProperty);

            set =>
                SetValue(CloseDialogCommandProperty, value);
        }
    }
}