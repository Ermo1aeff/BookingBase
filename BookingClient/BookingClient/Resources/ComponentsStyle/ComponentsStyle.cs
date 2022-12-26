using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookingClient.Resources
{
    public partial class ComponentsStyle
    {
        private double prevWidth, prevHeight;
        private Point prevPoint;

        private void resizeGripGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                e.Handled = true;
                Grid grid = (Grid)sender;
                grid.CaptureMouse();
                //var B = (Border)sender;
                grid.Width = 100;
                //prevWidth = grid.ActualWidth;
                //prevHeight = grid.ActualHeight;

                prevPoint = e.GetPosition(null);
            }
            catch (Exception)
            {
            }
        }
        private void resizeGripGrid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    //var T = (TextBox)sender;
                    Point point = e.GetPosition(null);
                    var xDiff = point.X - prevPoint.X;
                    var yDiff = point.Y - prevPoint.Y;

                    //T.Width = prevWidth + xDiff;
                    //T.Height = prevHeight + yDiff;


                    //prevWidth = T.Width;
                    //prevHeight = T.Height;
                    prevPoint = e.GetPosition(null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void resizeGripGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //var T = (TextBox)sender;
                e.Handled = true;
                Grid grid = (Grid)sender;
                grid.ReleaseMouseCapture();

                //prevWidth = T.ActualWidth;
                //prevHeight = T.ActualHeight;
            }
            catch (Exception)
            {
            }
        }

    }
}
