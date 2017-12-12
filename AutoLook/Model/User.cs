using System;
namespace AutoLook.Model
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }

        public User()
        {
        }
    }
}
