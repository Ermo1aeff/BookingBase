using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Collections;
using System.Linq;
using BookingClient.Models;
using System.Windows.Shell;

namespace BookingClient.Styles.CustomWindowStyle
{
    internal static class LocalExtensions
    {
        public static void ForWindowFromTemplate(this object templateFrameworkElement, Action<Window> action)
        {
            Window window = ((FrameworkElement)templateFrameworkElement).TemplatedParent as Window;
            if (window != null) action(window);
        }

        public static IntPtr GetWindowHandle(this Window window)
        {
            WindowInteropHelper helper = new WindowInteropHelper(window);
            return helper.Handle;
        }
    }

    public partial class CutosmWindowStyle
    {
        

        public string accountName { get; set; }
        Window windowStyleSender { get; set; }

        void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                sender.ForWindowFromTemplate(w => SystemCommands.CloseWindow(w));
            }
        }

        void IconMouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            Point point = element.PointToScreen(new Point(element.ActualWidth / 2, element.ActualHeight));
            sender.ForWindowFromTemplate(w => SystemCommands.ShowSystemMenu(w, point));
        }

        void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((Window)sender).StateChanged += WindowStateChanged;

            Window w = (Window)sender;
            windowStyleSender = (Window)sender;
            IntPtr handle = w.GetWindowHandle();
            Border containerBorder = (Border)w.Template.FindName("PART_Container", w);

            Button CuptionButton = (Button)w.Template.FindName("AccountCaptionButton", w);
            string id = w.Tag.ToString();
            accounts Accounts = SourceCore.entities.accounts.SingleOrDefault(U => U.account_id.ToString() == id);
            CuptionButton.Content = Accounts != null ? Accounts.first_name + " " + Accounts.last_name : "Не удалось найти данные пользователя";

            if (w.WindowState == WindowState.Maximized)
            {
                containerBorder.Padding = new Thickness(7);
            }
        }

        void WindowStateChanged(object sender, EventArgs e)
        {
            var w = (Window)sender;
            var handle = w.GetWindowHandle();
            var containerBorder = (Border)w.Template.FindName("PART_Container", w);

            if (w.WindowState == WindowState.Maximized)
            {
                containerBorder.Padding = new Thickness(7, 7, 7, 7);

                WindowChrome.SetWindowChrome(w, new WindowChrome()
                {
                    CaptionHeight = 33,
                    ResizeBorderThickness = new Thickness(7, 7, 7, 7),
                    UseAeroCaptionButtons = false,
                    GlassFrameThickness = new Thickness(0, 0, 0, 1),
                    CornerRadius = new CornerRadius(0),
                });
            }
            else
            {
                containerBorder.Padding = new Thickness(0);

                WindowChrome.SetWindowChrome(w, new WindowChrome()
                {
                    CaptionHeight = 26,
                    ResizeBorderThickness = new Thickness(7, 7, 7, 7),
                    UseAeroCaptionButtons = false,
                    GlassFrameThickness = new Thickness(0, 0, 0, 1),
                    CornerRadius = new CornerRadius(0),
                });
            }
        }

        void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w => SystemCommands.CloseWindow(w));
        }

        void MinButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w => SystemCommands.MinimizeWindow(w));
        }

        void MaxButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w =>
            {
                if (w.WindowState == WindowState.Maximized) SystemCommands.RestoreWindow(w);
                else SystemCommands.MaximizeWindow(w);
            });
        }

        void AccountCaptionButtonClick(object sender, RoutedEventArgs e)
        {
            Button w = (Button)sender;
            //IntPtr handle = w.GetWindowHandle();
            Button Border = (Button)windowStyleSender.Template.FindName("TextButton", windowStyleSender);
            Window AuthorizationWin = new AuthorizationWindow();
            windowStyleSender.Close();
            AuthorizationWin.Show();
            //Border.Content = "Текст";
            //w.Content = windowStyleSender.Tag;
            //windowStyleSender.Tag = "Что?";
            //w.Content = accountName;
        }
    }
}
