using Denisova.WPF.MVVM.Core.ViewModel;
using System.Windows.Input;
using Denisova.WPF.MVVM.Core.Command;
using Denisova.WPF.MVVM.Core.ViewModel;
using System.Windows;

namespace Example
{
    public class MainViewModel: ViewModelBase//NumericUpDown MessageDialog DialogHost
    {
        private int _targetValue = 50;
        private int _targetValueStep = 1;
        private bool _isDialogOpened = false;

        private ICommand _closeDialogCommand;
        private ICommand _openDialogCommand;

        private ICommand _okMessageDialog;
        private ICommand _cancelMessageDialog;
        public ICommand CloseDialogCommand =>
            _closeDialogCommand ??= new RelayCommand(_ => CloseDialog());
        public ICommand OpenDialogCommand =>
            _openDialogCommand ??= new RelayCommand(_ => OpenDialog());

        
        
        public int TargetValue
        {
            get =>
                _targetValue;

            set
            {
                _targetValue = value;
                RaisePropertyChanged(nameof(TargetValue));
            }
        }

        public int TargetValueStep
        {
            get =>
                _targetValueStep;

            set
            {
                _targetValueStep = value;
                RaisePropertyChanged(nameof(TargetValueStep));
            }
        }

        public bool IsDialogOpened
        {
            get =>
                _isDialogOpened;

            private set
            {
                _isDialogOpened = value;
                RaisePropertyChanged(nameof(IsDialogOpened));
            }
        }

        private void CloseDialog()
        {
            IsDialogOpened = false;
        }

        private void OpenDialog()
        {
            IsDialogOpened = true;
        }
        
        public ICommand CancelButtonCommand =>
                    _cancelMessageDialog ??= new RelayCommand(_ => CancelButtonPressed());
        private void CancelButtonPressed()
        {
            MessageBox.Show("Ну и пожалуйста!");
        }
        
        public ICommand OkButtonCommand =>
            _okMessageDialog ??= new RelayCommand(_ => OkButtonPressed());
        private void OkButtonPressed()
        {
            MessageBox.Show("Готовь!");
        }
    }
}