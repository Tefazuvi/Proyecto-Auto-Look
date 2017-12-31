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
using Realms;

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
        public ICommand VerVehiculoCommand { get; set; }

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

        private ObservableCollection<MasterPageItem> _lstPages = new ObservableCollection<MasterPageItem>();

        public ObservableCollection<MasterPageItem> lstPages

        {
            get
            {
                return _lstPages;

            }
            set
            {
                _lstPages = value;
                OnPropertyChanged("lstPages");

            }

        }

        private bool _IsAdmin { get; set; }

        public bool IsAdmin
        {
            get
            {
                return _IsAdmin;
            }
            set
            {
                _IsAdmin = value;
                UpdatePages(_IsAdmin);
                OnPropertyChanged("IsAdmin");
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
                OrdenarVehiculos(_FiltroOrdenar);
                OnPropertyChanged("FiltroOrdenar");
            }
        }

        private CarModel _VehiculoActual { get; set; }

        public CarModel VehiculoActual
        {
            get
            {
                return _VehiculoActual;
            }
            set
            {
                _VehiculoActual = value;
                OnPropertyChanged("VehiculoActual");
            }
        }

        private int _ImagenActual { get; set; }

        public int ImagenActual
        {
            get
            {
                return _ImagenActual;
            }
            set
            {
                _ImagenActual = value;
                Posicion = _ImagenActual + 1;
                OnPropertyChanged("ImagenActual");
            }
        }

        private int _Posicion = 1;

        public int Posicion
        {
            get
            {
                return _Posicion;
            }
            set
            {
                _Posicion = value;
                OnPropertyChanged("Posicion");
            }
        }

        private List<CarModel> lstOriginalVehiculos = new List<CarModel>();

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
        /*
        public CarModel(){
            var realm = Realm.GetInstance();
            return;
        }*/


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

        private void VerVehiculo(int id)
        {
            VehiculoActual = lstOriginalVehiculos.Where(x => x.Id == id).FirstOrDefault();

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new CarDetails());

        }

        private async void OrdenarVehiculos(int Orden)
        {
            //Filtros
            //lstVehiculos.Clear();
            //lstOriginalVehiculos.Where(x => x.Nombre.ToLower().Contains(textoBuscar.ToLower())).ToList().ForEach(x => lstPersonas.Add(x));

            switch (Orden)
            {
                case 1:
                    lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos.OrderBy(car => car.Price));
                    break;
                case 2:
                    lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos.OrderByDescending(car => car.Price));
                    break;
                case 3:
                    lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos.OrderBy(car => car.Miles));
                    break;
                case 4:
                    lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos.OrderByDescending(car => car.Miles));
                    break;
                case 5:
                    lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos.OrderBy(car => car.Year));
                    break;
                case 6:
                    lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos.OrderByDescending(car => car.Year));
                    break;
                default:
                    lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos);
                    break;
            }
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

        private void UpdatePages(bool Admin)
        {
            if (IsAdmin)
            {
                lstPages.Add(new MasterPageItem { Id = 4, Title = "Agregar vehículo", IconSource = "car.png" });
            }

        }

        private async Task InitClass()
        {
            lstVehiculos = await CarModel.ObtenerVehiculos();
            lstPages = await MasterPageItem.GetPages();
            lstOriginalVehiculos = lstVehiculos.ToList();
        }

        private void InitCommands()
        {
            NavigateWazeCommand = new Command(NavigateWaze);
            AddImageCommand = new Command(AddImage);
            PageManagerCommand = new Command<int>(PageManager);
            VerVehiculoCommand = new Command<int>(VerVehiculo);
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
