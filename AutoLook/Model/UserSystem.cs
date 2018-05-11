using System;
using System.Linq;
using Realms;

namespace AutoLook.Model
{
    public class UserSystem : RealmObject
    {
        [PrimaryKey]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public bool Remember { get; set; }

        public UserSystem()
        {
        }

        public static void SaveUserRealm(UserSystem usuario)
        {
            var realm = Realm.GetInstance();

            realm.Write(() =>
            {
                realm.Add(usuario);
            });
        }

        public static void UpdateUserRealm(UserSystem usuario)
        {
            var realm = Realm.GetInstance();

            UserSystem user = realm.All<UserSystem>().First(b => b.UserID == usuario.UserID);

            realm.Write(() =>
            {
                realm.Add(usuario);
            });
        }

        public static void DeleteUserRealm(int id)
        {
            var realm = Realm.GetInstance();
            if (CountUserSystem() > 0)
            {
                UserSystem user = realm.All<UserSystem>().First(b => b.UserID == id);

                if (user != null)
                {
                    // Delete an object with a transaction
                    using (var trans = realm.BeginWrite())
                    {
                        realm.Remove(user);
                        trans.Commit();
                    }
                }
            }
        }

        public UserSystem FindUser(int id)
        {
            var realm = Realm.GetInstance();

            var user = realm.All<UserSystem>().First(b => b.UserID == id);

            return user;
        }

        public static UserSystem GetUserRealm()
        {
            var realm = Realm.GetInstance();

            UserSystem user = realm.All<UserSystem>().LastOrDefault();

            return user;
        }

        public static int CountUserSystem()
        {
            var realm = Realm.GetInstance();

            var user = realm.All<UserSystem>();

            return user.Count();
        }

    }
}
