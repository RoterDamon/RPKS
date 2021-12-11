using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Denisova.WPF.Controls
{
    public partial class Spinner : UserControl
    {
        private DispatcherTimer _timerRotation;
        
        public Spinner()
        {
            InitializeComponent();


            _timerRotation = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 20), DispatcherPriority.Normal, (sender, eventArgs) =>
            {
                foreach (var t in CircleCollection)
                {
                    t.Angle = (t.Angle + (CircleRotation == Rotation.Counterclockwise ? -Speed : Speed)) % 360;
                }
            }, Dispatcher.CurrentDispatcher);
        }
        
        #region CircleColor
        public static readonly DependencyProperty CircleBrushProperty = DependencyProperty.Register(nameof(CircleBrush), typeof(Brush), typeof(Spinner), new PropertyMetadata(Brushes.Blue));
        public Brush CircleBrush
        {
            get => 
                 (Brush)GetValue(CircleBrushProperty); 
            set =>  
                SetValue(CircleBrushProperty, value); 
        }
        #endregion
        
        #region CirclesNumber
        public static readonly DependencyProperty CircleNumberProperty = DependencyProperty.Register(nameof(CircleNumber), typeof(int), typeof(Spinner), 
            new PropertyMetadata(0,
            (sender, eventArgs) =>
            {
                var oldCountValue = (int)eventArgs.OldValue;
                var newCountValue = (int)eventArgs.NewValue;

                if (newCountValue < 0)
                {
                    return;
                }

                var targetSpinner = sender as Spinner;

                var newItems = new SpinnerViewModel[newCountValue];
                for (var i = 0; i < newCountValue; i++)
                {
                    newItems[i] = new SpinnerViewModel
                    {
                        X = targetSpinner.Width - targetSpinner.CircleSize,
                        Y = (targetSpinner.Height - targetSpinner.CircleSize) / 2,
                        Angle = 360d / newCountValue * i
                    };
                }
                targetSpinner.CircleCollection = newItems;
            }));
        
        public int CircleNumber
        {
            get => 
                (int)GetValue(CircleNumberProperty); 
            set =>  
                SetValue(CircleNumberProperty, value); 
        }
        #endregion
        
        #region CircleOpacity
        public static readonly DependencyProperty CircleOpacityProperty = DependencyProperty.Register(nameof(CircleOpacity), typeof(double), typeof(Spinner), new FrameworkPropertyMetadata(1.0, 
            (d, o) => {},  
            (d, o) =>
            {
                var spinner = (Spinner)d;
                if (!(o is double @double))
                {
                    throw new ArgumentException("Invalid value type", nameof(o));
                }

                if(@double < 0.0)
                {
                    @double = 0.0;
                }
                if (@double > 1.0)
                {
                    @double = 1.0;
                }
                
                return @double;
            }));
        public double CircleOpacity
        {
            get => 
                (double)GetValue(CircleOpacityProperty); 
            set =>
                SetValue(CircleOpacityProperty, value); 
        }
        
        #endregion
        
        #region CircleSize
        public static readonly DependencyProperty CircleSizeProperty = DependencyProperty.Register(nameof(CircleSize), typeof(double), typeof(Spinner), new PropertyMetadata(20d,
            (d, o) => {}, 
            (d, o) => 
            {
                var spinner = (Spinner)d;
                if (!(o is double @double))
                {
                    throw new ArgumentException("Invalid value type", nameof(o));
                }
                if(@double < 1.0)
                {
                    @double = 1.0;
                }
                if (@double > 50.0)
                {
                    @double = 50.0;
                }
                return @double;
            }));
        public double CircleSize
        {
            get =>
               (double)GetValue(CircleSizeProperty); 
            set =>
                SetValue(CircleSizeProperty, value); 
        }
        
        #endregion

        #region CircleRotation

        public enum Rotation
        {
            Clockwise,
            Counterclockwise
        }
        
        public static readonly DependencyProperty CircleRotationProperty = DependencyProperty.Register(nameof(CircleRotation), typeof(Rotation), 
            typeof(Spinner), new PropertyMetadata(Rotation.Clockwise));
        public Rotation CircleRotation
        {
            get => 
                (Rotation)GetValue(CircleRotationProperty); 
            set =>  
                SetValue(CircleRotationProperty, value); 
        }

        #endregion

        #region CircleSpeed

        public static readonly DependencyProperty CircleSpeed = DependencyProperty.Register(nameof(Speed), typeof(int), typeof(Spinner), new PropertyMetadata(5));
               
                public int Speed
                {
                    get =>
                        (int)GetValue(CircleSpeed);
        
                    set =>
                        SetValue(CircleSpeed, value);
                }

        #endregion

        #region CircleCollection

         public static readonly DependencyProperty CircleCollectionProperty = DependencyProperty.Register(
                    nameof(CircleCollection), typeof(SpinnerViewModel[]), typeof(Spinner));
                public SpinnerViewModel[] CircleCollection
                {
                    get =>
                        (SpinnerViewModel[])GetValue(CircleCollectionProperty);
        
                    private set => SetValue(CircleCollectionProperty, value);
                }

        #endregion
        
        
    }
}