using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace ElementMoving
{
    public class MouseEventArgsToMouseArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not MouseEventArgs args || args.OriginalSource is not UIElement element)
            {
                throw new ArgumentException("MouseEventArgsToPositionConverter Invalid argument");
            }
            // 최상위 Window 객체 찾기
            DependencyObject parent = element;
            while (parent != null && !(parent is Window))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            // parent가 Window 객체인 경우
            if (parent is Window window)
            {
                var point = args.GetPosition(window);
                var isLeftPressed = args.LeftButton == MouseButtonState.Pressed;
                var isRightPressed = args.RightButton == MouseButtonState.Pressed;
                return new MouseArgs(new Position { X = point.X, Y = point.Y }, isLeftPressed, isRightPressed);
            }
            else
            {
                throw new InvalidOperationException("Window 객체를 찾을 수 없습니다.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
