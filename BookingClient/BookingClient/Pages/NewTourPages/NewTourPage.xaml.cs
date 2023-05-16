using BookingClient.Models;
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

namespace BookingClient.Pages.NewTourPages
{
    /// <summary>
    /// Логика взаимодействия для NewTourPage.xaml
    /// </summary>
    public partial class NewTourPage : Page
    {
        public NewTourPage()
        {
            ListBox listbox = new ListBox();
            InitializeComponent();
        }
    }
}
