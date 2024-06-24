using Microsoft.Xaml.Behaviors;

using System.Windows;

namespace ElementMoving
{
    public class SizeObserverBehavior : Behavior<FrameworkElement>
    {
        public static readonly DependencyProperty ActualWidthProperty =
            DependencyProperty.Register("ActualWidth", typeof(double), typeof(SizeObserverBehavior), new PropertyMetadata(0.0));

        public double ActualWidth
        {
            get { return (double)GetValue(ActualWidthProperty); }
            set { SetValue(ActualWidthProperty, value); }
        }

        public static readonly DependencyProperty ActualHeightProperty =
            DependencyProperty.Register("ActualHeight", typeof(double), typeof(SizeObserverBehavior), new PropertyMetadata(0.0));

        public double ActualHeight
        {
            get { return (double)GetValue(ActualHeightProperty); }
            set { SetValue(ActualHeightProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SizeChanged += OnSizeChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.ActualWidth = e.NewSize.Width;
            this.ActualHeight = e.NewSize.Height;
        }
    }
}
