using System;
using System.Collections.Generic;
using AutoLook.ViewModel;

using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class AddCar : ContentPage
    {
        public AddCar()
        {
            InitializeComponent();
            BindingContext = AutoLookViewModel.GetInstance();
        }
    }
}
