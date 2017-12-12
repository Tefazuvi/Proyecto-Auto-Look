using System;
using System.ComponentModel;
using System.Windows.Input;
using AutoLook.Model;
using AutoLook.View;
using Xamarin.Forms;

namespace AutoLook.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Instances

        public ICommand LoginCommand { get; set; }

        private string _User { get; set; }

        public string User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
            }

        }

        private string _Password { get; set; }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }

        }

        #endregion
        public LoginViewModel()
        {
            InitCommands();
        }

        #region Methods
        private async void Login()
        {
            User user = await LoginModel.Authenticate(User, Password);

        }

        private void InitCommands()
        {
            LoginCommand = new Command(Login);
        }

        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
