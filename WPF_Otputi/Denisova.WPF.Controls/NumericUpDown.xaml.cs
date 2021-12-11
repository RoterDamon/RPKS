using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Denisova.WPF.MVVM.Core.Command;

namespace Denisova.WPF.Controls
{
    public partial class NumericUpDown : UserControl
    {
        private ICommand _minusButtonCommand;
        private ICommand _plusButtonCommand;
        
        public NumericUpDown()
        {
            InitializeComponent();
        }
        public ICommand MinusButtonCommand =>
            _minusButtonCommand ??= new RelayCommand(_ =>
            {
                TargetValue -= TargetValueStep;
            });

        public ICommand PlusButtonCommand =>
            _plusButtonCommand ??= new RelayCommand(_ =>
            {
                TargetValue += TargetValueStep;
            });
        
        #region Dependency properties
        public int TargetValueMinBound
        {
            get =>
                (int)GetValue(TargetValueMinBoundProperty);

            set =>
                SetValue(TargetValueMinBoundProperty, value);
        }
        public static readonly DependencyProperty TargetValueMinBoundProperty = DependencyProperty.Register(
            nameof(TargetValueMinBound), typeof(int), typeof(NumericUpDown), new PropertyMetadata(1));

        public int TargetValueMaxBound
        {
            get =>
                (int)GetValue(TargetValueMaxBoundProperty);

            set =>
                SetValue(TargetValueMaxBoundProperty, value);
        }
        public static readonly DependencyProperty TargetValueMaxBoundProperty = DependencyProperty.Register(
            nameof(TargetValueMaxBound), typeof(int), typeof(NumericUpDown), new PropertyMetadata(100));

        public int TargetValueStep
        {
            get =>
                (int)GetValue(TargetValueStepProperty);

            set =>
                SetValue(TargetValueStepProperty, value);
        }
        public static readonly DependencyProperty TargetValueStepProperty = DependencyProperty.Register(
            nameof(TargetValueStep), typeof(int), typeof(NumericUpDown), new PropertyMetadata(1));

        public int TargetValue
        {
            get =>
                (int)GetValue(TargetValueProperty);

            set =>
                SetValue(TargetValueProperty, value);
        }
        public static readonly DependencyProperty TargetValueProperty = DependencyProperty.Register(
            nameof(TargetValue), typeof(int), typeof(NumericUpDown), 
            new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (d, e) =>
                {
                }, (d, e) =>
                {
                    var targetControl = d as NumericUpDown;
                    if (!(e is int @int))
                    {
                        throw new ArgumentException("Invalid value type", nameof(e));
                    }
                
                    if (@int < targetControl.TargetValueMinBound)
                    {
                        @int = targetControl.TargetValueMinBound;
                    }
                    else if (@int > targetControl.TargetValueMaxBound)
                    {
                        @int = targetControl.TargetValueMaxBound;
                    }
                
                    return @int;
                }, true, System.Windows.Data.UpdateSourceTrigger.PropertyChanged), targetValue =>
            {
                if (targetValue is not int @int)
                {
                    return false;
                }

                return true;
            }
            );

        #endregion
    }
}