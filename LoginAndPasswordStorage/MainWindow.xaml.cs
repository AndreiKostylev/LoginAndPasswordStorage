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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoginAndPasswordStorageLib; // Подключение библиотеки
namespace LoginAndPasswordStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

                string intUser = File.ReadAllText("UserData.json");
                if (File.Exists("UserData.json") == true && intUser != "")
                {
                    Exregistration();
                }
                else
                {
                    MessageBox.Show("Учетная запись не создана");
                }

        }
        public void Exregistration()
        {

            Registration? RegSerealiz = JsonSerializer.Deserialize<Registration>(File.ReadAllText("UserData.json"));
            RegSerealiz.RegestrationEvent += Open;
            RegSerealiz.Input();
        }

        public void Open(string login, string password)
        {
            string Login = LoginTextBox.Text;
            string Password = PasswordBox.Password;
            if (login == Login && password == Password)
            {
                Services service = new Services();
                this.Close();
                service.Show();
            }
            else
            {
                MessageBox.Show("Неверно введен логин или пароль.");
            }
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            RegWindowOpen();

        }
        public void RegWindowOpen()
        {
            RegWin regWin = new RegWin();
            this.Close();
            regWin.Show();
        }
    }
}
