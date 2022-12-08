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
using BookingClient.Pages;

namespace BookingClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Page> ActivePages;

        private int CurrentPageIndex;

        public MainWindow()
        {
            InitializeComponent();
            ActivePages = new List<Page>();
            CurrentPageIndex = -1;
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

        private void ToursButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(ToursPage));
        }

        private void DeparturesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(DeparturesPage));
        }



    }
}
