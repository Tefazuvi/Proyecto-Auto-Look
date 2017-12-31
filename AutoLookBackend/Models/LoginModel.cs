using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace AutoLookBackend.Models
{
    public class LoginModel
    {
        #region Variables
        Conexion conexionM = new Conexion();
        #endregion

        public LoginModel()
        {
        }

        public string User
        {
            get;
            set;
        }

        public string UserPassword
        {
            get;
            set;
        }

        public int UserType
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string UserLastName
        {
            get;
            set;
        }

        public string UserPhone
        {
            get;
            set;
        }

        public string Login(string user, string pass)
        {
            string query = "Select * from User where Email='" + user + "' and Password='" + pass + "'";

            MySqlDataReader reader = conexionM.getExecuteQuery(query);

            LoginModel login = new LoginModel();

            while (reader.Read())
            {
                login.User = reader["Email"].ToString();
                login.UserPassword = reader["Password"].ToString();
                login.UserType = Int32.Parse(reader["Type"].ToString());
                login.UserName = reader["Name"].ToString();
                login.UserLastName = reader["LastName"].ToString();
                login.UserPhone = reader["Phone"].ToString();
            }

            var json = JsonConvert.SerializeObject(login);

            return json;
        }
    }
}
