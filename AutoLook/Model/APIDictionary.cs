using System;
namespace AutoLook.Model
{
    public abstract class APIDictionary
    {
<<<<<<< HEAD
        public const string Base = "http://16b99ef5.ngrok.io/";
=======
        public const string Base = "http://08bb0874.ngrok.io/";
>>>>>>> 31c25e7956176ce32a9fff06d2c810d8c97ce474

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
