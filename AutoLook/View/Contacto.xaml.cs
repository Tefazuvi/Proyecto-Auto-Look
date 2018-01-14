using System;
using AutoLook.ViewModel;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class Contacto : ContentPage
    {
        public Contacto()
        {
            InitializeComponent();
            BindingContext = new MapViewModel();
        }
    }
}
