﻿using System;
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
        private async void Login()
        {
            IsBusy = true;
            usuario = await LoginModel.Authenticate(User, Password);

            await autoLookViewModel.setLoggedUser(usuario);

            if (usuario.Type == 2) //Admin = 2
            {
                autoLookViewModel.IsAdmin = true;
            }
            else
            {
                autoLookViewModel.IsAdmin = false;
            }

            IsBusy = false;

            await App.Current.MainPage.DisplayAlert("Success", "Bienvenido " + usuario.Name, "OK");

            autoLookViewModel.PageManager(1);
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
