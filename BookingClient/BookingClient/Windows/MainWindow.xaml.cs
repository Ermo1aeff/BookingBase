using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookingClient.Models;
using BookingClient.Pages;
using BookingClient.Pages.NewOrderPages;
using BookingClient.Pages.NewTourPages;

namespace BookingClient
{
    public partial class MainWindow : Window
    {
        public int AccountID { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            AppFrame.frameMain = RootFrame;
        }

        private void RootFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (e.Content == (e.Content as DirectoryPage))
                (e.Content as DirectoryPage).Tag = this;

            if (e.Content == (e.Content as ListToursPage))
                (e.Content as ListToursPage).Tag = this;

            if (e.Content == (e.Content as ProfilePage))
                (e.Content as ProfilePage).Tag = this;
        }

        public void SetTitleCaption(string PageName)
        {
            TitleCaption.Text = DirectoryButton.Content + PageName + " - " + Title;
        }

        public void SetAccountCaption(int AccountId)
        {
            accounts AccountProfile = SourceCore.entities.accounts.SingleOrDefault(U => U.account_id == AccountId);

            AccountCaptionTextBlock.Text = AccountProfile != null
                ? AccountProfile.last_names == null
                    ? AccountProfile.first_names.first_name
                    : $"{AccountProfile.first_names.first_name} {AccountProfile.last_names.last_name}"
                : "Не удалось найти данные пользователя";

            if (AccountProfile.image != null)
            {
                AvatarImageBrush.ImageSource = ToImage(AccountProfile.image);
                AdminAvatarImageBrush.ImageSource = ToImage(AccountProfile.image);
            }

            if (AccountProfile.role_id == 1 || AccountProfile.role_id == 2)
            {
                AdminRectangle.Visibility = Visibility.Visible;
            }
            else
            {
                ClientElipse.Visibility = Visibility.Visible;
            }
        }

        // Деформирование окна под полноэкранный режим
        private void BookingClient_Loaded(object sender, RoutedEventArgs e)
        {
            ((Window)sender).StateChanged += WindowStateChanged;

            if (WindowState == WindowState.Maximized)
            {
                MainBorder.Padding = new Thickness(8);
                WinChrome.CaptionHeight = 40;
                PART_MaxButton_Path.Data = Geometry.Parse("M1,12 10,12 10,3, 1,3 1,12.6 M3,3 3,1 12,1, 12,10, 10,10");
            }

            TitleCaption.Text = Title;

            SetAccountCaption(AccountID);

            accounts AccountProfile = SourceCore.entities.accounts.SingleOrDefault(U => U.account_id == AccountID);

            switch (AccountProfile.role_id)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    CreateOrderButton.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    DirectoryButton.Visibility = Visibility.Collapsed;
                    RootFrame.Navigate(new ListToursPage(AccountID));
                    //NewTourButton.Visibility = Visibility.Collapsed;
                    //TourListButton.Visibility = Visibility.Collapsed;
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
                WinChrome.CaptionHeight = 40;
                ((Path)FindName("PART_MaxButton_Path")).Data = Geometry.Parse("M1,12 10,12 10,3, 1,3 1,12.6 M3,3 3,1 12,1, 12,10, 10,10");
            }
            else
            {
                MainBorder.Padding = new Thickness(0);
                WinChrome.CaptionHeight = 36;
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
            ProfilePage profilePage = new ProfilePage();
            profilePage.AccountID = AccountID;

            RootFrame.Navigate(profilePage);

            //Window AuthorizationWin = new AuthorizationWindow();
            //Close();
            //AuthorizationWin.Show();
        }

        //private void NewTourButton_Click(object sender, RoutedEventArgs e)
        //{
        //    RootFrame.Navigate(new NewTourPage());
        //}

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

            RootFrame.Navigate(new ListToursPage(AccountID));

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

        //private void TourListButton_Click(object sender, RoutedEventArgs e)
        //{
        //    RootFrame.Navigate(new TOTourListPage());
        //}

        public BitmapImage ToImage(byte[] array)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
