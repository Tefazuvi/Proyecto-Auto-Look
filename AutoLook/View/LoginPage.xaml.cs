using System;
using System.Collections.Generic;

using Xamarin.Forms;
using AutoLook.Model;
using AutoLook.ViewModel;

namespace AutoLook.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}
