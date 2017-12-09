using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AutoLook.View
{
    public partial class SideMenu : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public SideMenu()
        {
            InitializeComponent();
        }
    }
}
