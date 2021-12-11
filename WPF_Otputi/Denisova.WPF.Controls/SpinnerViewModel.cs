using Denisova.WPF.MVVM.Core.ViewModel;

namespace Denisova.WPF.Controls
{
    public class SpinnerViewModel: ViewModelBase
    {
        private double _x;
        private double _y;
        private double _angle;

        public double Angle
        {
            get =>
                _angle;

            set
            {
                _angle = value;
                RaisePropertyChanged(nameof(Angle));
            }
        }
        public double X
        {
            get =>
                _x;

            set
            {
                _x = value ;
                RaisePropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get =>
                _y;

            set
            {
                _y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }
        
    }
}