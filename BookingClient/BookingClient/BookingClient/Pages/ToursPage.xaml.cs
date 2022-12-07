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

namespace BookingClient.Pages
{
    /// <summary>
    /// Interaction logic for ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        //описание вспомогательных переменных
        private int DlgMode = -1;
        private string Make_buf;
        private string Model_buf;
        private string RegPlates_buf;
        private string YearIssue_buf;
        private string Price_buf;

        public ToursPage()
        {
            InitializeComponent();
            DataContext = this;
            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
        }

        public void CarNumDlgLoad(bool b)
        {
            if (b == true)
            {
                RecordChangeBlock.Width = new GridLength(230);
                //Включаем кнопки
                RecordsDataGrid.IsHitTestVisible = false;
                AddRecordButton.IsEnabled = false;
                CopyRecordButton.IsEnabled = false;
                EditRecordButton.IsEnabled = false;
                DeleteRecordButton.IsEnabled = false;
            }
            else
            {
                RecordChangeBlock.Width = new GridLength(0);
                //Выключаем кнопки
                RecordsDataGrid.IsHitTestVisible = true;
                AddRecordButton.IsEnabled = true;
                CopyRecordButton.IsEnabled = true;
                EditRecordButton.IsEnabled = true;
                DeleteRecordButton.IsEnabled = true;
                DlgMode = -1;
            }
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            CarNumDlgLoad(true);
            DlgMode = 0;
            RecordsDataGrid.SelectedItem = null;
            RecordChangeTitle.Content = "Добавить запись";
            CarNumComboBoxMake.Text = "";
            CarNumComboBoxModel.Text = "";
            CarNumTextRegPlates.Text = "";
            CarNumTextYearIssue.Text = "";
        }

        private void CotyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                CarNumDlgLoad(true);
                DlgMode = 0;
                RecordChangeTitle.Content = "Копировать - добавить книгу на основе выбранной";
                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                Make_buf = CarNumComboBoxMake.Text;
                Model_buf = CarNumComboBoxModel.Text;
                RegPlates_buf = CarNumTextRegPlates.Text;
                YearIssue_buf = CarNumTextYearIssue.Text;
                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;
                CarNumComboBoxMake.Text = Make_buf;
                CarNumComboBoxModel.Text = Model_buf;
                CarNumTextRegPlates.Text = RegPlates_buf;
                CarNumTextYearIssue.Text = YearIssue_buf;
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }

        private void EditRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                CarNumDlgLoad(true);
                RecordChangeTitle.Content = "Изменить экзепляр";
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }

        private void DeleteRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                //MakeSource.entities.registration_plates.Remove((DataBase.registration_plates)CarNum.SelectedItem);
                //MakeSource.entities.SaveChanges();
            }
        }

        private void CommitChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RollbackChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            CarNumDlgLoad(false);
        }

    }
}
