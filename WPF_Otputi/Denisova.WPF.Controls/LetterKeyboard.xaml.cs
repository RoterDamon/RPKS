using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Denisova.WPF.Controls
{
    public partial class LetterKeyboard : UserControl
    {
        public LetterKeyboard()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty LetterButtonCommandProperty = DependencyProperty.Register(
            nameof(LetterButtonCommand), typeof(ICommand), typeof(LetterKeyboard));
        public ICommand LetterButtonCommand
        {
            get =>
                (ICommand)GetValue(LetterButtonCommandProperty);

            set =>
                SetValue(LetterButtonCommandProperty, value);
        }
        
        public static readonly DependencyProperty BackspaceButtonCommandProperty = DependencyProperty.Register(
            nameof(BackspaceButtonCommand), typeof(ICommand), typeof(LetterKeyboard));
        public ICommand BackspaceButtonCommand
        {
            get =>
                (ICommand)GetValue(BackspaceButtonCommandProperty);

            set =>
                SetValue(BackspaceButtonCommandProperty, value);
        }
        
        public static readonly DependencyProperty CapsButtonCommandProperty = DependencyProperty.Register(
            nameof(CapsButtonCommand), typeof(ICommand), typeof(LetterKeyboard));
        public ICommand CapsButtonCommand
        {
            get =>
                (ICommand)GetValue(CapsButtonCommandProperty);

            set =>
                SetValue(CapsButtonCommandProperty, value);
        }
        private void ChangeLanguageButton_OnClick(object sender, RoutedEventArgs e)
        {
            (_englishKeyboard.Visibility, _russianKeyboard.Visibility) = (_russianKeyboard.Visibility, _englishKeyboard.Visibility);
        }
    }
}