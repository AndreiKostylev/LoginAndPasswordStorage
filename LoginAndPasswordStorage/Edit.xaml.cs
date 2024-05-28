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
using System.Windows.Shapes;
using static LoginAndPasswordStorageLib.LoginAndPasswordStorageLib;

namespace LoginAndPasswordStorage
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private AdNew _currentAd;
        private Services _servicesWindow;

        public Edit(Services servicesWindow, AdNew ad)
        {
            InitializeComponent();
            _servicesWindow = servicesWindow;
            _currentAd = ad;

            // Заполнение полями данными выбранной записи
            ServiceNameTextBox.Text = ad.Service;
            LoginTextBox.Text = ad.Login;
            PasswordTextBox.Password = ad.Password;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение изменений
            _currentAd.Service = ServiceNameTextBox.Text;
            _currentAd.Login = LoginTextBox.Text;
            _currentAd.Password = PasswordTextBox.Password;

            // Сохранение в JSON
            _servicesWindow.SaveData();
            _servicesWindow.RefreshData();
            var servicesWindow = new Services();
            servicesWindow.Show();
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var servicesWindow = new Services();
            servicesWindow.Show();
            Close();
        }
    }
}
