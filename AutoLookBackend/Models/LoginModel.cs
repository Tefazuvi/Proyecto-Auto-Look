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

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Phone
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
                login.Email = reader["Email"].ToString();
                login.Password = reader["Password"].ToString();
                login.Type = Int32.Parse(reader["Type"].ToString());
                login.Name = reader["Name"].ToString();
                login.LastName = reader["LastName"].ToString();
                login.Phone = reader["Phone"].ToString();
            }

            var json = JsonConvert.SerializeObject(login);

            return json;
        }
    }
}
