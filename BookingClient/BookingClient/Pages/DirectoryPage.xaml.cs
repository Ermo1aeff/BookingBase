using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BookingClient.Pages
{
    public partial class DirectoryPage : Page
    {
        private List<Page> ActivePages;
        private List<string> ActivePagesName;
        private int CurrentPageIndex;

        public DirectoryPage()
        {
            InitializeComponent();
            DataContext = this;
            ActivePages = new List<Page>();
            ActivePagesName = new List<string>();
            CurrentPageIndex = -1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Page Page;
            ActivePages.RemoveAt(CurrentPageIndex);
            string PageName;
            ActivePagesName.RemoveAt(CurrentPageIndex);

            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex--;
                Page = ActivePages[CurrentPageIndex];
                PageName = ActivePagesName[CurrentPageIndex];
            }
            else
            {
                if (CurrentPageIndex < ActivePages.Count)
                {
                    Page = ActivePages[CurrentPageIndex];
                    PageName = ActivePagesName[CurrentPageIndex];
                }
                else
                {
                    Page = null;
                    PageName = null;
                }
            }
            // Отображение в фрейме новой выбранной страницы
            RootFrame.Navigate(Page);
            (Tag as MainWindow).SetTitleCaption(PageName);
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

        private void ShowPage(Type PageType, string PageName)
        {
            Page Page;
            if (PageType != null)
            {
                int Index = GetActivePageIndexByType(PageType);
                if (Index < 0)
                {
                    Page = (Page)Activator.CreateInstance(PageType);
                    ActivePages.Add(Page);
                    ActivePagesName.Add("/" + PageName);
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
            (Tag as MainWindow).SetTitleCaption(ActivePagesName[CurrentPageIndex]);
        }
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPageIndex--;
            RootFrame.Navigate(ActivePages[CurrentPageIndex]);
            (Tag as MainWindow).SetTitleCaption(ActivePagesName[CurrentPageIndex]);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPageIndex++;
            RootFrame.Navigate(ActivePages[CurrentPageIndex]);
            (Tag as MainWindow).SetTitleCaption(ActivePagesName[CurrentPageIndex]);
        }

        private void SetControlsEnabled()
        {
            PreviousButton.IsEnabled = CurrentPageIndex > 0;
            NextButton.IsEnabled = CurrentPageIndex < ActivePages.Count - 1;
            CloseButton.IsEnabled = ActivePages.Count > 0;
        }

        private void RootFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            while (RootFrame.CanGoBack)
            {
                RootFrame.RemoveBackEntry();
            }
            SetControlsEnabled();
        }

        private void ToursButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(ToursPage), ((Button)sender).Content.ToString());
        }

        private void PersonsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(PersonsPage), ((Button)sender).Content.ToString());
        }

        private void DeparturesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(DeparturesPage), ((Button)sender).Content.ToString());
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(OrdersPage), ((Button)sender).Content.ToString());
        }

        private void InteraryButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(ItineraryPage), ((Button)sender).Content.ToString());
        }

        private void CitiesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(CitiesPage), ((Button)sender).Content.ToString());
        }

        private void CountriesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(CountriesPage), ((Button)sender).Content.ToString());
        }

        private void InclusionsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(InclusionsPage), ((Button)sender).Content.ToString());
        }

        private void IncludedButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(IncludedPage), ((Button)sender).Content.ToString());
        }

        private void OrderRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(OrderRoomsPage), ((Button)sender).Content.ToString());
        }

        private void RoomsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(RoomPage), ((Button)sender).Content.ToString());
        }

        private void ImagesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(ImagesPage), ((Button)sender).Content.ToString());
        }
    }
}
