using System;
using System.Collections.Generic;
using AutoLook.ViewModel;
using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class Favorites : ContentPage
    {
        public Favorites()
        {
            InitializeComponent();
            BindingContext = AutoLookViewModel.GetInstance();
        }
    }
}
