using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;

namespace AutoLook.Model
{
    public class MasterPageItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string IconSource { get; set; }

        //public Type TargetType { get; set; }

        public static async Task<ObservableCollection<MasterPageItem>> GetPages()
        {
            ObservableCollection<MasterPageItem> lstPages = new ObservableCollection<MasterPageItem>();

            lstPages.Add(new MasterPageItem { Id = 0, Title = "Iniciar Sesion", IconSource = "blueperson.png" });
            lstPages.Add(new MasterPageItem { Id = 1, Title = "Vehiculos", IconSource = "blueperson.png" });
            lstPages.Add(new MasterPageItem { Id = 2, Title = "Información", IconSource = "blueperson.png" });
            lstPages.Add(new MasterPageItem { Id = 3, Title = "Auto-Look", IconSource = "info.png" });

            return lstPages;
        }
    }
}
