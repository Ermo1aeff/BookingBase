﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BookingClient.Models;
using BookingClient.Resources;
using BookingClient.Styles.CustomWindowStyle;

namespace BookingClient
{
    public partial class AuthorizationWindow : Window
    {
        private bool IsCtrl = false;
        private bool IsF9 = false;
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
                MainWin.AccountId = Accounts.account_id.ToString();
                Close();
                MainWin.Show();
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

            if (e.Key == Key.F9)
            {
                IsF9 = true;
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

            if (e.Key == Key.F9)
            {
                IsF9 = false;
            }
        }
    }
}
