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
using System.Windows.Shapes;

namespace BookingClient
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen("SlpashScreen1.png");
            splashScreen.Show(true);
        }

        private void AuthorizationCommit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AuthorizationRollBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
