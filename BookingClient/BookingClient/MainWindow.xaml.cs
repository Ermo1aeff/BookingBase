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

namespace BookingClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonMinimize(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.Width;
            SizeToContent = SizeToContent.Height;
            //Width = SystemParameters.MaximizedPrimaryScreenWidth;
            //this.Height = SystemParameters.MaximizedPrimaryScreenHeight;
            //this.Left = 0;
            //this.Top = 0;
            //this.WindowState = WindowState.Normal;

            //Application.Current.MainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            //Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //private void ShowPage1(object sender, RoutedEventArgs e)
        //{
        //    RootFrame.Navigate(new Pages.Page1());
        //}

        //private void ShowPage2(object sender, RoutedEventArgs e)
        //{
        //    RootFrame.Navigate(new Pages.Page2());
        //}

    }
}
