using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Window AuthorizationWin = new AuthorizationWindow();
            Close();
            AuthorizationWin.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AutorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string message = "";

            string password = PasswordBox.Password != "" ? PasswordBox.Password : PasswordTextBox.Text;

            if (password.Length < 8)
            {
                message = "Пароль должен быть не менее 8 символов.";
            }

            Regex regex = new Regex(".*[A-Z].*");
            if (!regex.IsMatch(password))
            {
                message = "Пароль должен содержать заглавные буквы латинского алфавита.";
            }

            regex = new Regex(".*[a-z].*");
            if (!regex.IsMatch(password))
            {
                message = "Пароль должен содержать прописные буквы латинского алфавита.";
            }

            regex = new Regex(@".*\s.*");
            if (regex.IsMatch(password))
            {
                message = "Пароль НЕ должен содержать пробелы!";
            }

            regex = new Regex(@"(.*\W.*)");
            if (!regex.IsMatch(password))
            {
                message = "Пароль должен содержать специальные символы по типу: ? . \\ # ^ ( ) @.";
            }

            regex = new Regex(@"(.*[0-9].*)");
            if (!regex.IsMatch(password))
            {
                message = "Пароль должен содержать цифры.";
            }

            string login = LoginTextBox.Text;

            if (login.Length < 8)
            {
                message = "Логин должен быть не менее 8 символов.";
            }

            if (message == "")
            {
                //executors Executors = new executors();
                //Executors.executor_name = ExecuterTextBox.Text;
                //Executors.login = LoginTextBox.Text;
                //Executors.password = password;
                //Добавление пользователя в базу данных
                //DataBase.executors.Add(Executors);
                //Сохранение изменений
                //DataBase.SaveChanges();
                Window AutorizationWin = new MainWindow();
                Close();
                AutorizationWin.Show();
            }
            else
            {
                ErrorTextBox.Text = message;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox.Tag = PasswordBox.Password == "" ? "Пароль" : "";
        }

        private void PasswordCheckBox_Click(object sender, RoutedEventArgs e)
        {
            string Password = PasswordBox.Password;
            Visibility Visibility = PasswordBox.Visibility;
            //Переброска информации из TextBox'а в PasswordBox
            PasswordBox.Password = PasswordTextBox.Text;
            PasswordBox.Visibility = PasswordTextBox.Visibility;
            // Возврат информации из временных буферов в TextBox
            PasswordTextBox.Text = Password;
            PasswordTextBox.Visibility = Visibility;
        }



        private void CapchaCheckBox_Click(object sender, RoutedEventArgs e)
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            //разделитель
            char[] a = { ',' };
            //расщепление массива по разделителю
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = " ";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            CapchaTextBox.Text = pwd;
        }

        private void CapchaCheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            CapchaCheckBox_Click(sender, e);
        }

        private void CapchaTextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            AutorizationButton.IsEnabled = CapchaTextBox.Text == CapchaTextBoxInput.Text;
        }
    }
}
