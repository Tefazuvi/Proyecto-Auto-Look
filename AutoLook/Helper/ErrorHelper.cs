using System;
using System.Collections.Generic;
using System.Text;
using AutoLook.Model;
using AutoLook.View;
using AutoLook.ViewModel;
using Xamarin.Forms;

namespace AutoLook.Helper
{
    public class ErrorHelper
    {
        /*
        public static async void ControlError(List<Error> errors, bool IsPopup = false)
        {
            if (errors != null && errors.Count > 0)
            {
                switch (errors[0].Code)
                {
                    case 7:
                    case 7000:
                        ResUserSign rqSingOut = await SignInModel.SignOut(UserModel.getUser().UserCode);
                        if (rqSingOut.IsSuccessful)
                        {
                            if (IsPopup)
                            {
                                await ((NavigationPage)App.Current.MainPage).Navigation.PopModalAsync();
                            }
                            App.Current.MainPage = new LoginView();
                        }
                        else
                        {
                            MessengerService.CreateAlert(rqSingOut.Errors[0].ToString());
                        }
                        break;
                    default:
                        MessengerService.CreateAlert(errors);
                        break;
                }
            }
        }

        public static async void ControlError(Error error)
        {
            switch (error.Code)
            {
                case 7:
                case 7000:
                    ResUserSign rqSingOut = await SignInModel.SignOut(UserModel.getUser().UserCode);
                    App.Current.MainPage = new LoginView();
                    break;
            }
        }

        public static void ControlError(Exception ex)
        {
            MessengerService.CreateAlert(App.Current.Resources["e_MovilGeneralError"].ToString());
            ErrorRegisterModel.RegisterError(ex);
            if (App.Current.MainPage.GetType() == typeof(MasterDetailPage))
            {
                ((NavigationPage)((MasterDetailPage)App.Current.MainPage).Detail).BarBackgroundColor = AppManagement.Main_MenuColor;
                ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
            }
            else
            {
                ((NavigationPage)App.Current.MainPage).Navigation.PopToRootAsync();
            }
        }

        public static void ControlErrorPop(Exception ex)
        {
            MessengerService.CreateAlert(App.Current.Resources["e_MovilGeneralError"].ToString());

            ErrorRegisterModel.RegisterError(ex);
            if (App.Current.MainPage.GetType() == typeof(MasterDetailPage))
            {
                ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
            }
            else
            {
                ((NavigationPage)App.Current.MainPage).Navigation.PopToRootAsync();
            }
        }    */
    }
}