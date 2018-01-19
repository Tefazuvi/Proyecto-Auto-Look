using System;
using System.ComponentModel;
using System.Windows.Input;
using AutoLook.Model;
using AutoLook.View;
using Xamarin.Forms;
using System.Xml.Serialization;


namespace AutoLook.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Instances

        public ICommand LoginCommand { get; set; }
        public ICommand OpenCreateUserCommand { get; set; }
        public ICommand OpenSendPasswordCommand { get; set; }

        public User usuario;

        public AutoLookViewModel autoLookViewModel = AutoLookViewModel.GetInstance();

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

        private bool _IsBusy { get; set; }

        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }
            set
            {
                _IsBusy = value;
                OnPropertyChanged("IsBusy");
            }

        }

        private bool _Recordar { get; set; }

        public bool Recordar
        {
            get
            {
                return _Recordar;
            }
            set
            {
                _Recordar = value;
                OnPropertyChanged("Recordar");
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


        #endregion
        public LoginViewModel()
        {
            InitCommands();
        }

        #region Methods
        public async void Login()
        {
            IsBusy = true;
            if (User != null && Password != null)
            {
                usuario = await LoginModel.Authenticate(User, Password);

                if (usuario.UserID > 0)
                {
                    await autoLookViewModel.setLoggedUser(usuario);

                    if (usuario.Type == 2) //Admin = 2
                    {
                        autoLookViewModel.IsAdmin = true;
                    }
                    else
                    {
                        autoLookViewModel.IsAdmin = false;
                    }

                    if(Recordar == true)
                    {
                        UserSystem.DeleteUserRealm(usuario.UserID);
                        UserSystem UserSys = new UserSystem{ UserID = usuario.UserID, Email = usuario.Email, Pass = usuario.Password, Remember=  true};
                        UserSystem.SaveUserRealm(UserSys);
                    }

                    autoLookViewModel.IsLogged = true;

                    IsBusy = false;

                    await App.Current.MainPage.DisplayAlert("Bienvenido!", usuario.Name + " " + usuario.LastName, "OK");
                }
                else
                {
                    autoLookViewModel.IsLogged = false;
                    await App.Current.MainPage.DisplayAlert("OOOPS", "Error de Login ", "OK");
                    IsBusy = false;
                }
                autoLookViewModel.PageManager(1);
                User = "";
                Password = "";
                Recordar = false;
            }else{
                await App.Current.MainPage.DisplayAlert("OOOPS", "Debe completar todos los espacios. ", "OK");
                IsBusy = false;
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
