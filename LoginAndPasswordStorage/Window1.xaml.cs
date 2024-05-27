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

namespace LoginAndPasswordStorage
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            // Проверка существования пользователя и соответствия пароля
            if (CheckCredentials(login, password))
            {
                MessageBox.Show("Login successful.");
            }
            else
            {
                MessageTextBlock.Text = "Invalid login or password.";
            }
        }

        private bool CheckCredentials(string login, string password)
        {
            string userJson = File.ReadAllText("User.json");

            if (string.IsNullOrEmpty(userJson))
            {
                MessageTextBlock.Text = "No users registered.";
                return false;
            }

            Registration user = JsonSerializer.Deserialize<Registration>(userJson);
            return (user.Login == login && user.Password == password);
        }
    
    }
}
