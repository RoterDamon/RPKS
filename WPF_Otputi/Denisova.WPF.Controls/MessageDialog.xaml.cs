using System.Windows.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Denisova.WPF.Controls
{
    public partial class MessageDialog : UserControl
    {
         public enum DistinctButtons
        {
            Ok,
            Cancel,
            Yes,
            No
        }
        
        public enum ButtonOptions
        {
            Ok,
            OkCancel,
            YesNo
        }
        
        public MessageDialog()
        {
            InitializeComponent();
        }

        #region FontProperty

        public Brush MessageDialogFontColor
        {
            get =>
                (Brush)GetValue(MessageDialogFontColorProperty);

            set =>
                SetValue(MessageDialogFontColorProperty, value);
        }
        public static readonly DependencyProperty MessageDialogFontColorProperty = DependencyProperty.Register(
            nameof(MessageDialogFontColor), typeof(Brush), typeof(MessageDialog));
        
        public FontWeight MessageDialogFontWeight
        {
            get =>
                (FontWeight)GetValue(MessageDialogFontWeightProperty);

            set =>
                SetValue(MessageDialogFontWeightProperty, value);
        }
        public static readonly DependencyProperty MessageDialogFontWeightProperty = DependencyProperty.Register(
            nameof(MessageDialogFontWeight), typeof(FontWeight), typeof(MessageDialog));
        
        public FontFamily MessageDialogFontFamily
        {
            get =>
                (FontFamily)GetValue(MessageDialogFontFamilyProperty);

            set =>
                SetValue(MessageDialogFontFamilyProperty, value);
        }
        public static readonly DependencyProperty MessageDialogFontFamilyProperty = DependencyProperty.Register(
            nameof(MessageDialogFontFamily), typeof(FontFamily), typeof(MessageDialog));
        
        public int MessageDialogFontSize
        {
            get =>
                (int)GetValue(MessageDialogFontSizeProperty);

            set =>
                SetValue(MessageDialogFontSizeProperty, value);
        }
        public static readonly DependencyProperty MessageDialogFontSizeProperty = DependencyProperty.Register(
            nameof(MessageDialogFontSize), typeof(int), typeof(MessageDialog));

        #endregion

        public string MessageDialogText
        {
            get =>
                (string)GetValue(MessageDialogTextProperty);

            set =>
                SetValue(MessageDialogTextProperty, value);
        }
        public static readonly DependencyProperty MessageDialogTextProperty = DependencyProperty.Register(
            nameof(MessageDialogText), typeof(string), typeof(MessageDialog));

        public ICommand LeftButtonCommand
        {
            get =>
                (ICommand)GetValue(LeftButtonCommandProperty);

            set =>
                SetValue(LeftButtonCommandProperty, value);
        }
        public static readonly DependencyProperty LeftButtonCommandProperty = DependencyProperty.Register(
            nameof(LeftButtonCommand), typeof(ICommand), typeof(MessageDialog));

        public ICommand RightButtonCommand
        {
            get =>
                (ICommand)GetValue(RightButtonCommandProperty);

            set =>
                SetValue(RightButtonCommandProperty, value);
        }
        public static readonly DependencyProperty RightButtonCommandProperty = DependencyProperty.Register(
            nameof(RightButtonCommand), typeof(ICommand), typeof(MessageDialog));
        
        public ObservableCollection<DistinctButtons> Buttons
        {
            get =>
                (ObservableCollection<DistinctButtons>)GetValue(ButtonsProperty);

            private set =>
                SetValue(ButtonsProperty, value);
        }
        
        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(
            nameof(Buttons), typeof(ObservableCollection<DistinctButtons>), typeof(MessageDialog),
            new PropertyMetadata(new ObservableCollection<DistinctButtons>(new [] { DistinctButtons.Ok })));
        
        public ButtonOptions ButtonsStyle
        {
            get =>
                (ButtonOptions)GetValue(ButtonsStyleProperty);

            set
            {
                SetValue(ButtonsStyleProperty, value);
            }
        }
        
        public static readonly DependencyProperty ButtonsStyleProperty = DependencyProperty.Register(
            nameof(ButtonsStyle), typeof(ButtonOptions), typeof(MessageDialog), new PropertyMetadata(ButtonOptions.Ok, (sender, eventArgs) =>
            {
                if (!(sender is MessageDialog targetMessageDialog))
                {
                    throw new ArgumentNullException(nameof(targetMessageDialog));
                }

                var value = (ButtonOptions)eventArgs.NewValue;

                var buttons = new ObservableCollection<DistinctButtons>();

                switch (value)
                {
                    case ButtonOptions.Ok:
                        buttons.Add(DistinctButtons.Ok);
                        break;
                    case ButtonOptions.OkCancel:
                        buttons.Add(DistinctButtons.Ok);
                        buttons.Add(DistinctButtons.Cancel);
                        break;
                    case ButtonOptions.YesNo:
                        buttons.Add(DistinctButtons.Yes);
                        buttons.Add(DistinctButtons.No);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
                
                targetMessageDialog.Buttons = buttons;
            }));
    }
}