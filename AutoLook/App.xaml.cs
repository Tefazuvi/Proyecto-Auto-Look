using Xamarin.Forms;
using AutoLook.View;

namespace AutoLook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AutoLook.View.MainPage();

            /*
            NavigationPage navigation = new NavigationPage(new MainTabbedPage());

            App.Current.MainPage = new MasterDetailPage
            {
                Master = new SideMenu(),
                Detail = navigation
            };

            //MainPage = new MainPage();*/
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
