using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BookingClient
{
    public partial class ConnectionWindow : Window
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        private Thread t;

        private void CheckConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckConnectionButton.Content.ToString() == "Прервать подключение")
            {
                timer.Stop();
                t.Interrupt();
            }
            else
            {
                string ServerName = ServerNameComboBox.Text;
                string BaseName = BaseNameTextBox.Text;
                t = new Thread(new ThreadStart(() => ThreadProc(ServerName, BaseName)));

                CheckConnectionButton.Content = "Прервать подключение";
                AuthorizationButton.IsEnabled = false;
                CloseButton.IsEnabled = false;

                MessageTextBlock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                timerStart();
                t.Start();
            }
        }

        private DispatcherTimer timer = null;
        private string ellipsis = "";

        private void timerStart()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            ellipsis = ellipsis != "..." ? ellipsis + "." : "";
            MessageTextBlock.Text = $"Проверка подключения{ellipsis}";
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            Window AuthorizationWin = new AuthorizationWindow();
            Close();
            AuthorizationWin.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PasswordCheckBox_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //datatable servertable = sqldatasourceenumerator.instance.getdatasources();

            //foreach (datarow row in servertable.rows)
            //{
            //    servernamecombobox.items.add(row["servername"]);
            //}
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void ThreadProc(string ServerName, string BaseName)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

                string ConnectionString =
                    @"Data Source=" + ServerName + ";" +
                    "Initial Catalog=" + BaseName + ";" +
                    "Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }

                ConnectionString =
                    @"metadata=res://*/Models.Booking_BaseModel.csdl|res://*/Models.Booking_BaseModel.ssdl|res://*/Models.Booking_BaseModel.msl;" +
                    "provider=System.Data.SqlClient;" +
                    "provider connection string=\"data source=" + ServerName + ";" +
                    "initial catalog=" + BaseName + ";" +
                    "integrated security=True;" +
                    "multipleactiveresultsets=True;" +
                    "application name=EntityFramework\";";

                connectionStringsSection.ConnectionStrings["Booking_BaseEntities"].ConnectionString = ConnectionString;

                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");

                timer.Stop();

                Dispatcher.Invoke(() => MessageTextBlock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green"));
                Dispatcher.Invoke(() => MessageTextBlock.Text = "Подключение установлено!");
            }
            catch (Exception e) when (!(e is ThreadInterruptedException))
            {
                timer.Stop();

                Dispatcher.Invoke(() => MessageTextBlock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red"));
                Dispatcher.Invoke(() => MessageTextBlock.Text = $"Не удалось подключиться к серверу! {e.InnerException}");
            }
            catch (Exception e) when (e is ThreadInterruptedException)
            {
                timer.Stop();

                Dispatcher.Invoke(() => MessageTextBlock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red"));
                Dispatcher.Invoke(() => MessageTextBlock.Text = "Подключение прервано!");
            }
            finally
            {
                Dispatcher.Invoke(() => CheckConnectionButton.Content = "Создать соединение");
                Dispatcher.Invoke(() => AuthorizationButton.IsEnabled = true);
                Dispatcher.Invoke(() => CloseButton.IsEnabled = true);

                Thread.Sleep(0);
            }
        }
    }
}
