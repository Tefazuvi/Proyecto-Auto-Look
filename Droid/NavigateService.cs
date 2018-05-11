using System.Net;
using Xamarin.Forms;
using System;
using AutoLook.Model;
using Android.Content;

[assembly: Dependency(typeof(AutoLook.Droid.NavigateService))]

namespace AutoLook.Droid
{
    public class NavigateService : INavigateService
    {
        public void NavigateAutoLook()
        {
            try
            {
                // Launch Waze to look for Hawaii:
                String url = "https://waze.com/ul?q=Hawaii";
                Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(url));
                Android.App.Application.Context.StartActivity(intent);
            }
            catch (ActivityNotFoundException ex)
            {
                // If Waze is not installed, open it in Google Play:
                Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=com.waze"));
                Android.App.Application.Context.StartActivity(intent);
            }
        }
    }
}
