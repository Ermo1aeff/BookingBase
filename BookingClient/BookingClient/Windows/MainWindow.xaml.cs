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
using BookingClient.Pages.NewOrderPages;
using BookingClient.Pages.NewTourPages;
using System.Threading;

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

            if (e.Content == (e.Content as ListToursPage))
                (e.Content as ListToursPage).Tag = this;
        }

        public void SetTitleCaption(string PageName)
        {
            TitleCaption.Text = DirectoryButton.Content + PageName + " - " + Title;
        }

        // Деформирование окна под полноэкранный режим
        private void BookingClient_Loaded(object sender, RoutedEventArgs e)
        {
            ((Window)sender).StateChanged += WindowStateChanged;

            if (WindowState == WindowState.Maximized)
            {
                MainBorder.Padding = new Thickness(8);
                WinChrome.CaptionHeight = 34;
                PART_MaxButton_Path.Data = Geometry.Parse("M1,12 10,12 10,3, 1,3 1,12.6 M3,3 3,1 12,1, 12,10, 10,10");
            }

            TitleCaption.Text = Title;

            accounts AccountProfile = SourceCore.entities.accounts.SingleOrDefault(U => U.account_id.ToString() == AccountId);


            if (AccountProfile != null)
            {
                if (AccountProfile.last_names == null)
                {
                    AccountCaptionButton.Content = AccountProfile.first_names.first_name;
                }
                else
                {
                    AccountCaptionButton.Content = $"{AccountProfile.first_names.first_name} {AccountProfile.last_names.last_name}";
                }
            } 
            else
            {
                AccountCaptionButton.Content = "Не удалось найти данные пользователя";
            }

            switch (AccountProfile.role_id)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    DirectoryButton.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    RootFrame.Navigate(new ListToursPage());
                    CreateOrderButton.Visibility = Visibility.Collapsed;
                    NewTourButton.Visibility = Visibility.Collapsed;
                    TourListButton.Visibility = Visibility.Collapsed;
                    DirectoryButton.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        void WindowStateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MainBorder.Padding = new Thickness(8);
                WinChrome.CaptionHeight = 34;
                ((Path)FindName("PART_MaxButton_Path")).Data = Geometry.Parse("M1,12 10,12 10,3, 1,3 1,12.6 M3,3 3,1 12,1, 12,10, 10,10");
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
            RootFrame.Navigate(new ProfilePage());

            //Window AuthorizationWin = new AuthorizationWindow();
            //Close();
            //AuthorizationWin.Show();
        }

        private void NewTourButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new NewTourPage());
        }

        private void DirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new DirectoryPage());
            TitleCaption.Text = DirectoryButton.Content + " - " + Title;
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Uri Source = new Uri("Pages/NewOrderPages/ListToursPage.xaml", UriKind.Relative);
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

        private void TourListButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new TOTourListPage());

        }
    }
}
