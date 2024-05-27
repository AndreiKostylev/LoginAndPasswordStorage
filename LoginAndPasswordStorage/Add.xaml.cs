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
using static LoginAndPasswordStorageLib.LoginAndPasswordStorageLib;


namespace LoginAndPasswordStorage
{
    public partial class Add : Window
    {
        private AdNew _currentAd; // Уточнение пространства имен

        public Add(AdNew ad = null) // Уточнение пространства имен
        {
            InitializeComponent();
            LoadData(); // Загрузка данных при каждом запуске окна
            if (ad != null)
            {
                _currentAd = ad;
                ServiceNameTextBox.Text = ad.Service;
                LoginTextBox.Text = ad.Login;
                PasswordTextBox.Password = ad.Password;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentAd != null)
            {
                _currentAd.Service = ServiceNameTextBox.Text;
                _currentAd.Login = LoginTextBox.Text;
                _currentAd.Password = PasswordTextBox.Password;
            }
            else
            {
                // Использование класса AdNew из пространства имен LoginAndPasswordStorage
                Services.adnew.Add(new AdNew(ServiceNameTextBox.Text, LoginTextBox.Text, PasswordTextBox.Password)); // Уточнение пространства имен
            }

            SaveData(); // Сохранение данных при нажатии на кнопку "Сохранить"
            
            var servicesWindow = new Services();
            servicesWindow.Show();
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Метод для загрузки данных из JSON файла
        private void LoadData()
        {
            if (File.Exists("UserPass.json"))
            {
                string json = File.ReadAllText("UserPass.json");
                Services.adnew = JsonSerializer.Deserialize<List<AdNew>>(json) ?? new List<AdNew>();
            }
        }

        // Метод для сохранения данных в JSON файл
        private void SaveData()
        {
            string json = JsonSerializer.Serialize(Services.adnew);
            File.WriteAllText("UserPass.json", json);
        }
    }
}
