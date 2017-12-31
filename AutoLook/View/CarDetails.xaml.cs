using System;
using System.Collections.Generic;
using AutoLook.ViewModel;
using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class CarDetails : ContentPage
    {
        public CarDetails()
        {
            InitializeComponent();
            BindingContext = AutoLookViewModel.GetInstance();
        }
    }
}
