using System;
using System.Collections.Generic;
using AutoLook.Model;
using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class Financing : ContentPage
    {
        public Financing()
        {
            InitializeComponent();
            BindingContext = new Calculator();
        }
    }
}
