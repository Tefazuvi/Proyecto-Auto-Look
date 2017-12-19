using System;
using System.Collections.Generic;
using AutoLook.ViewModel;
using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class SideMenu : ContentPage
    {

        public SideMenu()
        {
            InitializeComponent();
            BindingContext = AutoLookViewModel.GetInstance();

        }
    }
}
