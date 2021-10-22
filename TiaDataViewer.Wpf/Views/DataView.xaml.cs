using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TiaDataViewer.Wpf.Views
{
    public partial class DataView : UserControl
    {
        public DataView()
        {
            InitializeComponent();
        }

        // Button to scroll list of types to the left
        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            Decorator border = VisualTreeHelper.GetChild(xTypeList, 0) as Decorator;
            ScrollViewer scrollViewer = border.Child as ScrollViewer;

            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - 1);
        }

        // Button to scroll list of types to the right
        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            Decorator border = VisualTreeHelper.GetChild(xTypeList, 0) as Decorator;
            ScrollViewer scrollViewer = border.Child as ScrollViewer;

            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + 1);
        }

        // Scroll list of types by mouse wheel
        private void TypeList_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            Decorator border = VisualTreeHelper.GetChild(xTypeList, 0) as Decorator;
            ScrollViewer scrollViewer = border.Child as ScrollViewer;

            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + e.Delta / 100);
        }
    }
}
