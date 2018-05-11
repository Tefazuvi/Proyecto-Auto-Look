using System;
using System.Net;
using Xamarin.Forms;
using AutoLook.Model;
using UIKit;
using Foundation;

[assembly: Dependency(typeof(AutoLook.iOS.NavigateService))]
namespace AutoLook.iOS
{
    public class NavigateService : INavigateService
    {
        public void NavigateAutoLook()
        {
            if (UIApplication.SharedApplication.CanOpenUrl(new NSUrl("waze://")))
            {
                // Waze is installed. Launch Waze and start navigation
                UIApplication.SharedApplication.OpenUrl(new NSUrl("https://waze.com/ul?q=Hawaii"));
            }
            else
            {
                // Waze is not installed. Launch AppStore to install Waze app
                UIApplication.SharedApplication.OpenUrl(new NSUrl("https://itunes.apple.com/us/app/waze-navigation-live-traffic/id323229106?mt=8"));
            }
        }
    }
}
