﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Collections;

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

    public partial class WindowStyle
    {
        void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
                sender.ForWindowFromTemplate(w => SystemCommands.CloseWindow(w));
        }

        void IconMouseUp(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
            var point = element.PointToScreen(new Point(element.ActualWidth / 2, element.ActualHeight));
            sender.ForWindowFromTemplate(w => SystemCommands.ShowSystemMenu(w, point));
        }

        void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((Window)sender).StateChanged += WindowStateChanged;

            var w = (Window)sender;
            var handle = w.GetWindowHandle();
            var containerBorder = (Border)w.Template.FindName("PART_Container", w);

            if (w.WindowState == WindowState.Maximized)
            {
                //var screen = System.Windows.Forms.Screen.FromHandle(handle);
                //if (screen.Primary)
                //{
                //    containerBorder.Padding = new Thickness(7);
                //}
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
                containerBorder.Padding = new Thickness(7);
            }
            else
            {
                containerBorder.Padding = new Thickness(0);
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
    }
}
