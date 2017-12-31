using System;
using System.Collections.Generic;
using AutoLook.ViewModel;
using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class Financing : ContentPage
    {
        public Financing()
        {
            InitializeComponent();
            BindingContext = new CalculatorViewModel();
        }
    }
}
