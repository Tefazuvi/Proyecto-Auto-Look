using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using AutoLook.View;
using Plugin.Media;
using AutoLook.Model;

namespace AutoLook.ViewModel
{
    public class AutoLookViewModel : INotifyPropertyChanged
    {

        #region Singleton

        private static AutoLookViewModel instance = null;

        private AutoLookViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static AutoLookViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new AutoLookViewModel();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
        #endregion


        #region Instances

        public ICommand NavigateWazeCommand { get; set; }
        public ICommand AddImageCommand { get; set; }
        public ICommand PageManagerCommand { get; set; }

        private ObservableCollection<ImageFile> _lstImages = new ObservableCollection<ImageFile>();

        public ObservableCollection<ImageFile> lstImages

        {
            get
            {
                return _lstImages;

            }
            set
            {
                _lstImages = value;
                OnPropertyChanged("lstImages");

            }

        }

        private int _FiltroOrdenar { get; set; }

        public int FiltroOrdenar
        {
            get
            {
                return _FiltroOrdenar;
            }
            set
            {
                _FiltroOrdenar = value;
                OnPropertyChanged("FiltroOrdenar");
            }
        }

        private ObservableCollection<CarModel> _lstVehiculos = new ObservableCollection<CarModel>();

        public ObservableCollection<CarModel> lstVehiculos
        {
            get
            {
                return _lstVehiculos;
            }
            set
            {
                _lstVehiculos = value;
                OnPropertyChanged("lstVehiculos");
            }
        }


        #endregion

        #region Methods

        private void PageManager(int Id)
        {
            switch (Id)
            {
                case 0:
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new LoginPage());
                    break;
                case 1:
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new MainTabbedPage());
                    break;
                case 2:
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new UserInfo());
                    break;
                case 3:
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new About());
                    break;
                case 4:
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new AddCar());
                    break;
                default:
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new HomePage());
                    break;
            }

            ((MasterDetailPage)App.Current.MainPage).IsPresented = false;

        }

        private void NavigateWaze()
        {

        }

        private async void AddImage()
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file != null)
                {
                    ImageFile image = new ImageFile { Path = file.Path };
                    lstImages.Add(image);
                }

                return;
            }
        }

        private async Task InitClass()
        {
            lstVehiculos = await CarModel.ObtenerVehiculos();
        }

        private void InitCommands()
        {
            NavigateWazeCommand = new Command(NavigateWaze);
            AddImageCommand = new Command(AddImage);
            PageManagerCommand = new Command<int>(PageManager);
        }

        #endregion

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
