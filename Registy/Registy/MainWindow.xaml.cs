using Registy.Pages;
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
using System.Windows.Shell;

namespace Registy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool FullScreenMode = false;
        private WindowState WinState;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new RegistrationPage());
            Window_StateChanged(null, null);
        }

        // Деформация окна под полноэкранный режим
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (!FullScreenMode)
            {
                if (WindowState == WindowState.Maximized)
                {
                    MainBorder.Padding = new Thickness(8);
                    WinChrome.CaptionHeight = 40;
                }
                else
                {
                    MainBorder.Padding = new Thickness(0);
                    WinChrome.CaptionHeight = 32;
                }
            }
        }

        // Полноэкранный режим на F11
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                FullScreenMode = !FullScreenMode;

                if (FullScreenMode)
                {
                    WinState = WindowState;
                    MainBorder.Padding = new Thickness(0);
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Minimized;
                    WindowState = WindowState.Maximized;
                    WindowChrome.SetWindowChrome(this, null);
                }
                else
                {
                    WindowChrome NewWindowChrome = new WindowChrome
                    {
                        CaptionHeight = 32,
                        UseAeroCaptionButtons = false,
                        GlassFrameThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(0)
                    };

                    WindowState = WindowState.Normal;
                    WindowState = WinState;
                    WindowChrome.SetWindowChrome(this, NewWindowChrome);
                    WindowStyle = WindowStyle.SingleBorderWindow;
                }
            }
        }

        private void RootFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }
    }
}
