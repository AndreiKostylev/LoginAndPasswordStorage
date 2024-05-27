using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoginAndPasswordStorage
{
    class Login : MainWindow
    {
        
        public void Deregistration()
        {
            Registration? RegSerealiz = JsonSerializer.Deserialize<Registration>(File.ReadAllText("User.json"));
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
        }
    }
}
