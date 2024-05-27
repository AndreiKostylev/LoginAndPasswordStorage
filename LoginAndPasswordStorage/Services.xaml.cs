using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LoginAndPasswordStorageLib;
using static LoginAndPasswordStorageLib.LoginAndPasswordStorageLib;

namespace LoginAndPasswordStorage
{
    public partial class Services : Window
    {
        static internal List<AdNew> adnew = new List<AdNew>();

        public Services()
        {
            InitializeComponent();
            if (File.Exists("UserPass.json"))
            {
                // Использование класса AdNew из библиотеки
                List<AdNew>? deserializationUsers = JsonSerializer.Deserialize<List<AdNew>>(File.ReadAllText("UserPass.json"));
                if (deserializationUsers != null)
                {
                    adnew = deserializationUsers;
                }
            }
            dataOutput.ItemsSource = adnew;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Add add = new Add();
            add.Show();
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataOutput.SelectedItem is AdNew selectedAd)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Удаление из списка сервисов
                    Services.adnew.Remove(selectedAd);
                    SaveData(); // Сохранение изменений в файл JSON
                    RefreshData(); // Обновление отображения данных
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.", "Нет выбранной записи", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        internal void RefreshData()
        {
            // Обновление отображения данных
            dataOutput.ItemsSource = null;
            dataOutput.ItemsSource = Services.adnew;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (dataOutput.SelectedItem is AdNew selectedAd)
            {
                Edit editRecord = new Edit(this, selectedAd);
                editRecord.Show();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredList = Services.adnew.Where(ad => ad.Service.ToLower().Contains(searchText) || ad.Login.ToLower().Contains(searchText)).ToList();
            if (filteredList.Count > 0)
            {
                dataOutput.ItemsSource = filteredList;
            }
            else
            {
                MessageBox.Show("Не найдено записей по заданным критериям.", "Поиск", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        internal void SaveData()
        {
            string json = JsonSerializer.Serialize(adnew);
            File.WriteAllText("UserPass.json", json);
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем поле поиска перед возвращением в меню сервисов
            SearchTextBox.Text = string.Empty;

            // Если есть результаты поиска, возвращаемся к отображению всех записей
            if (dataOutput.ItemsSource != Services.adnew)
            {
                dataOutput.ItemsSource = Services.adnew;
            }
            else
            {
                // Возвращаемся в меню сервисов
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }

            
        }

    }
}
