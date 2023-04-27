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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using BookingClient.Models;
using BookingClient.Pages;
using BookingClient.PagesForWindow;

namespace BookingClient
{
    public partial class MainWindow : Window
    {
        public string AccountId { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RootFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (e.Content == (e.Content as DirectoryPage))
                (e.Content as DirectoryPage).Tag = this;

            if (e.Content == (e.Content as CreateOrderPage))
                (e.Content as CreateOrderPage).Tag = this;
        }

        public void SetTitleCaption(string PageName)
        {
            TitleCaption.Text = DirectoryButton.Content + PageName + " - " + Title;
        }

        // Деформирование окна под полноэкранный режим
        private void BookingClient_Loaded(object sender, RoutedEventArgs e)
        {
            TitleCaption.Text = Title;
            accounts AccountProfile = SourceCore.entities.accounts.SingleOrDefault(U => U.account_id.ToString() == AccountId);
            AccountCaptionButton.Content = AccountProfile != null ? AccountProfile.first_name + " " + AccountProfile.last_name : "Не удалось найти данные пользователя";

            ((Window)sender).StateChanged += WindowStateChanged;

            if (WindowState == WindowState.Maximized)
            {
                MainBorder.Padding = new Thickness(8);
                WinChrome.CaptionHeight = 34;
                PART_MaxButton_Path.Data = Geometry.Parse("M1,10 8,10 8,3, 1,3 1,10.5 M3,3 3,1 10,1, 10,8, 8,8");
            }
        }

        void WindowStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MainBorder.Padding = new Thickness(8);
                WinChrome.CaptionHeight = 34;
                ((Path)FindName("PART_MaxButton_Path")).Data = Geometry.Parse("M1,10 8,10 8,3, 1,3 1,10.5 M3,3 3,1 10,1, 10,8, 8,8");
            }
            else
            {
                MainBorder.Padding = new Thickness(0);
                WinChrome.CaptionHeight = 26;
                PART_MaxButton_Path.Data = Geometry.Parse("M1,1 L12,1 L12,12 L1,12 Z");
            }
        }

        private void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                Close();
            }
        }

        private void IconMouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            Point point = element.PointToScreen(new Point(element.ActualWidth / 2, element.ActualHeight));
            SystemCommands.ShowSystemMenu(this, point);
        }

        private void MinButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaxButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AccountCaptionButtonClick(object sender, RoutedEventArgs e)
        {
            Window AuthorizationWin = new AuthorizationWindow();
            Close();
            AuthorizationWin.Show();
        }

        private void NewTourButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new DirectoryPage());
            TitleCaption.Text = DirectoryButton.Content + " - " + Title;
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Uri Source = new Uri("Pages/NewOrderPages/CreateOrderPage.xaml", UriKind.Relative);
            if (RootFrame.NavigationService.CurrentSource != Source)
                RootFrame.Navigate(Source);
        }

        private void BookingClient_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized || Width >= 1250) 
            {
                Grid.SetColumn(TitleCaption, 0);
                Grid.SetColumnSpan(TitleCaption, 4);
            }
            else
            {
                Grid.SetColumn(TitleCaption, 2);
                Grid.SetColumnSpan(TitleCaption, 1);
            }

            //if (Width <= 1250)
            //{
            //    Grid.SetColumn(TitleCaption, 2);
            //    Grid.SetColumnSpan(TitleCaption, 1);
            //}
            //else
            //{
            //    Grid.SetColumn(TitleCaption, 0);
            //    Grid.SetColumnSpan(TitleCaption, 4);
            //}
        }
    }
}
