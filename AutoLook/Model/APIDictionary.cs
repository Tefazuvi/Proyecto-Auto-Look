using System;
namespace AutoLook.Model
{
    public abstract class APIDictionary
    {
        public const string Base = "http://08bb0874.ngrok.io/";

        #region BaseCore APIs
        public const string API_SaveUser = Base + "Login/SaveUser";
        public const string API_UpdateUser = Base + "Login/UpdateUser";
        public const string API_DeleteUser = Base + "Login/DeleteUser";
        public const string API_SaveCar = Base + "Car/SaveCar";
        public const string API_GetCar = Base + "Car/GetCars";
        public const string API_Authenticate = Base + "Login/Authenticate";
        #endregion
    }
}
