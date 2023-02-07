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
using BookingClient.Pages;
using BookingClient.Styles.CustomWindowStyle;

namespace BookingClient
{
    public partial class MainWindow : Window
    {
        public string accountName { get; set; }

        private List<Page> ActivePages;

        private int CurrentPageIndex;

        public MainWindow()
        {
            InitializeComponent();
            ActivePages = new List<Page>();
            CurrentPageIndex = -1;
        }
        private void BookingClient_Loaded(object sender, RoutedEventArgs e)
        {
            BookingClient.Tag = accountName;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Page Page;
            ActivePages.RemoveAt(CurrentPageIndex);
            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex--;
                Page = ActivePages[CurrentPageIndex];
            }
            else
            {
                if (CurrentPageIndex < ActivePages.Count)
                {
                    Page = ActivePages[CurrentPageIndex];
                }
                else
                {
                    Page = null;
                }
            }
            // Отображение в фрейме новой выбранной страницы
            RootFrame.Navigate(Page);
        }

        private int GetActivePageIndexByType(Type PageType)
        {
            int Index = ActivePages.Count - 1;
            while ((Index >= 0) && (ActivePages[Index].GetType() != PageType))
            {
                Index--;
            }
            return Index;
        }

        private void ShowPage(Type PageType)
        {
            Page Page;
            if (PageType != null)
            {
                int Index = GetActivePageIndexByType(PageType);
                if (Index < 0)
                {
                    Page = (Page)Activator.CreateInstance(PageType);
                    ActivePages.Add(Page);
                    CurrentPageIndex = ActivePages.Count - 1;
                }
                else
                {
                    Page = ActivePages[Index];
                    CurrentPageIndex = Index;
                }
            }
            else
            {
                Page = null;
            }
            RootFrame.Navigate(Page);
        }
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPageIndex--;
            RootFrame.Navigate(ActivePages[CurrentPageIndex]);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPageIndex++;
            RootFrame.Navigate(ActivePages[CurrentPageIndex]);
        }

        private void SetControlsEnabled()
        {
            PreviousButton.IsEnabled = (CurrentPageIndex > 0);
            NextButton.IsEnabled = (CurrentPageIndex < ActivePages.Count - 1);
            CloseButton.IsEnabled = (ActivePages.Count > 0);
        }

        private void RootFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            while (RootFrame.CanGoBack)
            {
                RootFrame.RemoveBackEntry();
            }
            SetControlsEnabled();
        }

        private void BookingClient_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //MainGrid.Width =  (1600 - 800) / (100 - 200) * MainGrid.Width - 100; 
        }

        private void ToursButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(ToursPage));
        }

        private void PersonsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(PersonsPage));
        }

        private void DeparturesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(DeparturesPage));
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(OrdersPage));
        }

        private void OrderToursButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(CreateOrdersPage));
        }

        private void InteraryButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(ItineraryPage));
        }

        private void CitiesButton_Click_1(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(CitiesPage));
        }

        private void CountriesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(CountriesPage));
        }

        private void InclusionsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(InclusionsPage));
        }

        private void IncludedButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(IncludedPage));
        }

        private void OrderRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(OrderRoomsPage));
        }

        private void RoomsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(RoomPage));
        }

        private void ImagesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(ImagesPage));
        }

        private void BookingClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right && NextButton.IsEnabled)
            {
                NextButton_Click(null, null);
            }
            if (e.Key == Key.Left && PreviousButton.IsEnabled)
            {
                PreviousButton_Click(null, null);
            }
        }
    }
}
