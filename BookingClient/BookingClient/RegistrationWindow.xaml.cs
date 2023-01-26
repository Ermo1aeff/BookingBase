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
using BookingClient.Models;

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
            Regex regex;
            string message = "";

            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password != "" ? PasswordBox.Password : PasswordTextBox.Text;
            string confirmPssword = ConfirmPasswordBox.Password != "" ? ConfirmPasswordBox.Password : ConfirmPasswordTextBox.Text;

            if (lastName == "" && message == "")
                message = "Введите фамилию";

            regex = new Regex(@".*\s.*");

            if (regex.IsMatch(lastName) && message == "")
                message = "Фамилия НЕ должна содержать пробелов!";

            if (firstName == "")
                message = "Введите имя";

            if (regex.IsMatch(firstName) && message == "")
                message = "Имя НЕ должно содержать пробелов!";

            if (login.Length < 6)
                message = "Логин должен быть не менее 6 символов";

            regex = new Regex(@".*\s.*");
            if (regex.IsMatch(login) && message == "")
                message = "Логин НЕ должен содержать пробелов!";

            if (password.Length < 8 && message == "")
                message = "Пароль должен быть не менее 8 символов";

            if (regex.IsMatch(password) && message == "")
                message = "Пароль НЕ должен содержать пробелов!";

            regex = new Regex(".*[A-Z].*");
            if (!regex.IsMatch(password) && message == "")
                message = "Пароль должен содержать хотябы одну заглавную и прописную буквы латинского алфавита";

            regex = new Regex(".*[a-z].*");
            if (!regex.IsMatch(password) && message == "")
                message = "Пароль должен содержать хотябы одну заглавную и прописную буквы латинского алфавита";

            regex = new Regex(@"(.*[0-9].*)");
            if (!regex.IsMatch(password) && message == "")
                message = "Пароль должен содержать цифры";

            regex = new Regex(@"(.*\W.*)");
            if (!regex.IsMatch(password) && message == "")
                message = "Пароль должен содержать хотябы один специальный символ по типу: ? . # * ^ - \\ # ^ ( ) @";

            if (confirmPssword == "" && message == "")
                message = "Подтвердите пароль";

            if (password != confirmPssword && message == "")
                message = "Пароль подтверждён неправильно!";

            if (SourceCore.entities.accounts.SingleOrDefault(U => U.account_login == LoginTextBox.Text) != null && message == "")
                message = "Логин уже используется";

            if (message == "")
            {
                accounts Accounts = new accounts();
                Accounts.last_name = lastName;
                Accounts.first_name = firstName;
                Accounts.account_login = login;
                //Accounts.account_password = ConfirmPasswordBox.Visibility == Visibility.Collapsed ? ConfirmPasswordTextBox.Text : ConfirmPasswordBox.Password;
                Accounts.account_password = password;
                SourceCore.entities.accounts.Add(Accounts);
                SourceCore.entities.SaveChanges();
                MessageTextBox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGreen");
                message = "Вы успешно зарегистрировались!";
            }
            MessageTextBox.Text = message;
        }


        //PasswordBox
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

        //RepeatPasswordBox
        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ConfirmPasswordBox.Tag = ConfirmPasswordBox.Password == "" ? "Подтвердите пароль" : "";
        }

        private void ConfirmPasswordCheckBox_Click(object sender, RoutedEventArgs e)
        {
            string Password = ConfirmPasswordBox.Password;
            Visibility Visibility = ConfirmPasswordBox.Visibility;
            //Переброска информации из TextBox'а в PasswordBox
            ConfirmPasswordBox.Password = ConfirmPasswordTextBox.Text;
            ConfirmPasswordBox.Visibility = ConfirmPasswordTextBox.Visibility;
            // Возврат информации из временных буферов в TextBox
            ConfirmPasswordTextBox.Text = Password;
            ConfirmPasswordTextBox.Visibility = Visibility;
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
