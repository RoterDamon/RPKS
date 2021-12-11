using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Denisova.WPF.Controls
{
    public partial class NumericKeyboard : UserControl
    {
        public NumericKeyboard()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty DigitalButtonCommandProperty = DependencyProperty.Register(
            nameof(DigitalButtonCommand), typeof(ICommand), typeof(NumericKeyboard));
        public ICommand DigitalButtonCommand
        {
            get =>
                (ICommand)GetValue(DigitalButtonCommandProperty);

            set =>
                SetValue(DigitalButtonCommandProperty, value);
        }
        
        public static readonly DependencyProperty BackspaceButtonCommandProperty = DependencyProperty.Register(
            nameof(BackspaceButtonCommand), typeof(ICommand), typeof(NumericKeyboard));
        public ICommand BackspaceButtonCommand
        {
            get =>
                (ICommand)GetValue(BackspaceButtonCommandProperty);

            set =>
                SetValue(BackspaceButtonCommandProperty, value);
        }
    }
}