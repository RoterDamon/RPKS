using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Denisova.WPF.Styles
{
    public class ScrollViewerAttached: ScrollViewer
    {
        public static readonly DependencyProperty ScrollsColorProperty = DependencyProperty.RegisterAttached(
            nameof(ScrollsColorProperty), typeof(Color), typeof(ScrollViewerAttached), new PropertyMetadata(Color.AliceBlue));
        
        public static Color GetScrollsColor(DependencyObject obj)  
        {  
            return (Color)obj.GetValue(ScrollsColorProperty);  
        }  
  
        public static void SetScrollsColor(DependencyObject obj, Color value)  
        {  
            obj.SetValue(ScrollsColorProperty, value);  
        } 
    }
}