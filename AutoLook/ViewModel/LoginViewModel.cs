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
        public ICommand OpenCreateUserCommand { get; set; }
        public ICommand OpenSendPasswordCommand { get; set; }

        public User usuario = new User();

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
                OnPropertyChanged("User");
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
                OnPropertyChanged("Password");
            }

        }

        private string _UserEmail { get; set; }

        public string UserEmail
        {
            get
            {
                return _UserEmail;
            }
            set
            {
                _UserEmail = value;
                OnPropertyChanged("UserEmail");
            }

        }

        private string _UserPhone { get; set; }

        public string UserPhone
        {
            get
            {
                return _UserPhone;
            }
            set
            {
                _UserPhone = value;
                OnPropertyChanged("UserPhone");
            }

        }

        private string _UserFullName { get; set; }

        public string UserFullName
        {
            get
            {
                return _UserFullName;
            }
            set
            {
                _UserFullName = value;
                OnPropertyChanged("UserFullName");
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
            usuario = await LoginModel.Authenticate(User, Password);

            UserEmail = usuario.Email;
            UserFullName = usuario.Name + " " + usuario.LastName;
            UserPhone = usuario.Phone;

            if (usuario.Type == 0) //Admin = 0
            {
                AutoLookViewModel.GetInstance().IsAdmin = true;
            }else{
                AutoLookViewModel.GetInstance().IsAdmin = false;
            }

        }

        private void OpenCreateUser()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new CreateUser());
        }

        private void OpenSendPassword()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new SendPassword());
        }

        private void InitCommands()
        {
            LoginCommand = new Command(Login);
            OpenCreateUserCommand = new Command(OpenCreateUser);
            OpenSendPasswordCommand = new Command(OpenSendPassword);
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
