using System;
namespace AutoLook.Model
{
    public abstract class APIDictionary
    {

        public const string Base = "http://c45f02c2.ngrok.io/";


        #region BaseCore APIs
        public const string API_SaveUser = Base + "Login/SaveUser";
        public const string API_SaveFavorite = Base + "Login/SaveFavorite";
        public const string API_GetFavorite = Base + "Login/GetFavorite";
        public const string API_UpdateUser = Base + "Login/UpdateUser";
        public const string API_DeleteUser = Base + "Login/DeleteUser";
        public const string API_SaveCar = Base + "Car/SaveCar";
        public const string API_ReceiveSaveCar = Base + "Receive/SaveCar";
        public const string API_GetCar = Base + "Car/GetCars";
        public const string API_ReceiveGetCar = Base + "Receive/GetCars";
        public const string API_Authenticate = Base + "Login/Authenticate";
        #endregion
    }
}
