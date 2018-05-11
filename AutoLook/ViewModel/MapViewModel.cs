using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using AutoLook.Model;
using Xamarin.Forms;

namespace AutoLook.ViewModel
{
    public class MapViewModel : INotifyPropertyChanged
    {

        public MapViewModel()
        {
            InitCommands();

            Location locationA = new Location { Name = "AutoLook", Description = "Venta de vehiculos usados", Phone = "2221-8972", Address = "Calle Blancos, 150 m. Oeste de Amazon, contiguo a la línea del tren.", Latitude = 9.946234, Longitude = -84.072448 };

            lstLocations = new ObservableCollection<Location>();

            lstLocations.Add(locationA);
        }

        public ICommand NavigateWazeCommand { get; set; }

        private ObservableCollection<Location> _lstLocations { get; set; }

        public ObservableCollection<Location> lstLocations
        {
            get
            {
                return _lstLocations;
            }
            set
            {
                _lstLocations = value;
                OnPropertyChanged("lstLocations");
            }
        }

        private void NavigateWaze()
        {
            DependencyService.Get<INavigateService>().NavigateAutoLook();
        }

        private void InitCommands()
        {
            NavigateWazeCommand = new Command(NavigateWaze);
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
