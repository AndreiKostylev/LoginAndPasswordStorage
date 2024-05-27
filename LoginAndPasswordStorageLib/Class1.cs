namespace LoginAndPasswordStorageLib
{
    public class LoginAndPasswordStorageLib
    {
        public delegate void RegistrationDelegate(string login, string password);

        public class Registration
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
                RegistrationEvent?.Invoke(Login, Password);
            }

            public event RegistrationDelegate RegistrationEvent;
        }

        public class AdNew
        {

            public string Service { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }

            public AdNew(string service, string login, string password)
            {
               
                Service = service;
                Login = login;
                Password = password;
            }
        }
    }
}