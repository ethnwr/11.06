using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Задание 1
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string data = $"Фамилия: {LastNameBox.Text}\n" +
                         $"Имя: {FirstNameBox.Text}\n" +
                         $"Отчество: {MiddleNameBox.Text}\n" +
                         $"Пол: {GenderCombo.Text}\n" +
                         $"Дата рождения: {BirthDatePicker.SelectedDate:dd.MM.yyyy}\n" +
                         $"Семейный статус: {MaritalStatusBox.Text}\n" +
                         $"Дополнительная информация: {InfoBox.Text}";

            File.WriteAllText("user_data.txt", data);
            MessageBox.Show("Данные сохранены в файл user_data.txt");
        }

        // Задание 2
        private void CalculateDays_Click(object sender, RoutedEventArgs e)
        {
            if (Date1Picker.SelectedDate == null || Date2Picker.SelectedDate == null)
            {
                MessageBox.Show("Выберите обе даты");
                return;
            }

            TimeSpan span = Date1Picker.SelectedDate.Value - Date2Picker.SelectedDate.Value;
            DaysResult.Text = $"Разница: {Math.Abs(span.Days)} дней";
        }

        // Задание 3
        private void ShowDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int day = int.Parse(DayBox.Text);
                int month = int.Parse(MonthBox.Text);
                int year = int.Parse(YearBox.Text);

                DateTime date = new DateTime(year, month, day);
                BirthdayCalendar.SelectedDate = date;
                BirthdayCalendar.DisplayDate = date;
            }
            catch
            {
                MessageBox.Show("Введите корректную дату");
            }
        }
    }
}
