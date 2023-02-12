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

namespace Registy.Pages
{
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void Page_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.FocusedElement is TextBox felem)
                if (sender != felem)
                    Keyboard.Focus(MainGrid); // Предача фокуса основному гриду
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
