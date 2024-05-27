using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndPasswordStorage
{
    public delegate void RegistrationDelegate(string login, string password);
    internal class Registration
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Registration(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public void Input()
        {
            RegestrationEvent.Invoke($"{Login}", $"{Password}");
        }
        public event RegistrationDelegate RegestrationEvent;
    }
}
