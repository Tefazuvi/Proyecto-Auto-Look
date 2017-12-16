using System;
using System.Collections.Generic;
using AutoLook.ViewModel;
using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class ReceiveCarDetail : ContentPage
    {
        public ReceiveCarDetail()
        {
            InitializeComponent();
            BindingContext = AutoLookViewModel.GetInstance();
        }
    }
}
