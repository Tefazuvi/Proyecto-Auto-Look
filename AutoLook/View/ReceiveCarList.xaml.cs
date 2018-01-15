using System;
using System.Collections.Generic;
using AutoLook.ViewModel;
using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class ReceiveCarList : ContentPage
    {
        public ReceiveCarList()
        {
            InitializeComponent();
            BindingContext = AutoLookViewModel.GetInstance();
        }
    }
}
