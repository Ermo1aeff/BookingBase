﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BookingClient.Models;

namespace BookingClient
{
    public partial class AuthorizationWindow : Window
    {
        private bool IsCtrl = false;
        private bool IsF = false;

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow RegistrationWin = new RegistrationWindow();
            Close();
            RegistrationWin.Show();
        }

        private void AutorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordPasswordBox.Password != "" ? PasswordPasswordBox.Password : PasswordTextBox.Text;
            accounts Accounts = SourceCore.entities.accounts.SingleOrDefault(U => U.account_login == LoginTextBox.Text && U.account_password == password);
            if (Accounts != null)
            {
                MainWindow MainWin = new MainWindow();
                MainWin.AccountID = Accounts.account_id;
                Close();
                SplashScreen splashScreen = new SplashScreen("Images/SlpashScreen1.png");
                splashScreen.Show(false);
                MainWin.Show();
                TimeSpan duration = new TimeSpan(0, 0, 0, 1);
                splashScreen.Close(duration);
            }
        }

        private void PasswordCheckBox_Click(object sender, RoutedEventArgs e)
        {
            string Password = PasswordPasswordBox.Password;
            Visibility Visibility = PasswordPasswordBox.Visibility;
            //Переброска информации из TextBox'а в PasswordBox
            PasswordPasswordBox.Password = PasswordTextBox.Text;
            PasswordPasswordBox.Visibility = PasswordTextBox.Visibility;
            // Возврат информации из временных буферов в TextBox
            PasswordTextBox.Text = Password;
            PasswordTextBox.Visibility = Visibility;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPasswordBox.Tag = PasswordPasswordBox.Password == "" ? "Пароль" : "";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.LeftCtrl)
            {
                IsCtrl = true;
            }

            if (e.Key == Key.F)
            {
                IsF = true;
            }

            if (IsCtrl && IsF)
            {
                ConnectionWindow ConnWin = new ConnectionWindow();
                Close();
                ConnWin.Show();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
            {
                IsCtrl = false;
            }

            if (e.Key == Key.F)
            {
                IsF = false;
            }
        }
    }
}
