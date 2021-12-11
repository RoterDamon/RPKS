using System;
using System.Windows.Input;
using Denisova.WPF.MVVM.Core.Command;
using Denisova.WPF.MVVM.Core.ViewModel;

namespace Example
{
    public class NumericKeyboardViewModel: ViewModelBase
    {
        private string _targetValue;
        private ICommand _backspaceCommand;
        private ICommand _digitCommand;

        public NumericKeyboardViewModel()
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

        public ICommand DigitCommand =>
            _digitCommand ??= new RelayCommand(digit => Digit((digit as string)[0]));

        private void Backspace()
        {
            Target = Target.Remove(Target.Length - 1, 1);
        }
        
        private bool IsEnableBackspace()
        { 
            return Target != string.Empty;
        }

        private void Digit(char digit)
        {
            if (!(Char.IsDigit(digit)))
            {
                throw new ArgumentException("Invalid value type");
            }
            Target += digit;
        }
    }
}