using System;
using System.Globalization;
using System.Windows.Input;
using Denisova.WPF.MVVM.Core.Command;
using Denisova.WPF.MVVM.Core.ViewModel;
namespace Example
{
    public class LetterKeyboardViewModel: ViewModelBase
    {
        private string _targetValue;
        private ICommand _backspaceCommand;
        private ICommand _letterCommand;
        private ICommand _capsCommand;
        private bool _capsLock = false;

        public LetterKeyboardViewModel()
        {
            Target = string.Empty;
        }

        public string Target
        {
            get =>
                _targetValue;
            private set
            {
                _targetValue = value;
                RaisePropertyChanged(nameof(Target));
            }
        }

        
        public ICommand BackspaceCommand =>
            _backspaceCommand ??= new RelayCommand(_ => Backspace(), _ => IsEnableBackspace());

        public ICommand LetterCommand =>
            _letterCommand ??= new RelayCommand(letter => Letter(((string) letter)));

        public ICommand CapsCommand =>
            _capsCommand ??= new RelayCommand(_ => CapsLock());
        
        private void Backspace()
        {
            Target = Target.Remove(Target.Length - 1, 1);
        }
        
        private bool IsEnableBackspace()
        { 
            return Target != string.Empty;
        }

        private void Letter(string letter)
        {

            Target += _capsLock
                ? CultureInfo.CurrentCulture.TextInfo.ToUpper(letter)
                : CultureInfo.CurrentCulture.TextInfo.ToLower(letter);
        }

        private void CapsLock()
        {
            _capsLock = ! _capsLock;
        }
        
    }
}