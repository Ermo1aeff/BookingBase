using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        private void CheckConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

                string ConnectionString =
                    @"Data Source=" + ServerNameComboBox.Text + ";" +
                    "Initial Catalog=" + BaseNameTextBox.Text + ";" +
                    "Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }

                ConnectionString =
                    @"metadata=res://*/Models.Booking_BaseModel.csdl|res://*/Models.Booking_BaseModel.ssdl|res://*/Models.Booking_BaseModel.msl;" +
                    "provider=System.Data.SqlClient;" +
                    "provider connection string=\"data source=" + ServerNameComboBox.Text + ";" +
                    "initial catalog=" + BaseNameTextBox.Text + ";" +
                    "integrated security=True;" +
                    "multipleactiveresultsets=True;" +
                    "application name=EntityFramework\";";

                connectionStringsSection.ConnectionStrings["Booking_BaseEntities"].ConnectionString = ConnectionString;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Подключение установлено!");
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к серверу!");
            }
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
            //DataTable ServerTable = SqlDataSourceEnumerator.Instance.GetDataSources();

            //foreach (DataRow row in ServerTable.Rows)
            //{
            //    ServerNameComboBox.Items.Add(row["ServerName"]);
            //}
        }
    }
}
