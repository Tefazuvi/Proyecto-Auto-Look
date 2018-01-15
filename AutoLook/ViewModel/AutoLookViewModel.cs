using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using AutoLook.View;
using AutoLook.Model;
using Plugin.Media;
using Realms;
using System.IO;
using System.Security.Cryptography;

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

        public ICommand AddImageCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand PageManagerCommand { get; set; }
        public ICommand VerVehiculoCommand { get; set; }
        public ICommand VerReceivedCommand { get; set; }
        public ICommand AddFavoriteCommand { get; set; }
        public ICommand SaveUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        public ICommand ChangeInfoCommand { get; set; }
        public ICommand FiltersCommand { get; set; }
        public ICommand AddCarCommand { get; set; }
        public ICommand ReceiveCarCommand { get; set; }

        private string _Name { get; set; }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }

        }

        private string _LastName { get; set; }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                OnPropertyChanged("LastName");
            }

        }

        private string _Email { get; set; }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }

        }

        private string _Password { get; set; }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }

        }

        private string _Phone { get; set; }

        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
                OnPropertyChanged("Phone");
            }

        }

        private int UserId { get; set; }

        private string _UserEmail { get; set; }

        public string UserEmail
        {
            get
            {
                return _UserEmail;
            }
            set
            {
                _UserEmail = value;
                OnPropertyChanged("UserEmail");
            }

        }

        private string _UserPhone { get; set; }

        public string UserPhone
        {
            get
            {
                return _UserPhone;
            }
            set
            {
                _UserPhone = value;
                OnPropertyChanged("UserPhone");
            }

        }

        public User LoggedUser = new User();

        private string _UserFullName { get; set; }

        public string UserFullName
        {
            get
            {
                return _UserFullName;
            }
            set
            {
                _UserFullName = value;
                OnPropertyChanged("UserFullName");
            }

        }

        private string _UserName { get; set; }

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
                OnPropertyChanged("UserName");
            }

        }

        private string _UserLastName { get; set; }

        public string UserLastName
        {
            get
            {
                return _UserLastName;
            }
            set
            {
                _UserLastName = value;
                OnPropertyChanged("UserLastName");
            }

        }

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

        private ReceiveCarModel _ReceivedActual { get; set; }

        public ReceiveCarModel ReceivedActual
        {
            get
            {
                return _ReceivedActual;
            }
            set
            {
                _ReceivedActual = value;
                OnPropertyChanged("ReceivedActual");
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

        private ObservableCollection<ReceiveCarModel> _lstReceived = new ObservableCollection<ReceiveCarModel>();

        public ObservableCollection<ReceiveCarModel> lstReceived
        {
            get
            {
                return _lstReceived;
            }
            set
            {
                _lstReceived = value;
                OnPropertyChanged("lstReceived");
            }
        }

        private int CarId { get; set; }

        private string _CarBrand { get; set; }

        public string CarBrand
        {
            get
            {
                return _CarBrand;
            }
            set
            {
                _CarBrand = value;
                OnPropertyChanged("CarBrand");
            }
        }

        private string _CarModelo { get; set; }

        public string CarModelo
        {
            get
            {
                return _CarModelo;
            }
            set
            {
                _CarModelo = value;
                OnPropertyChanged("CarModelo");
            }
        }

        private string _CarDamage { get; set; }

        public string CarDamage
        {
            get
            {
                return _CarDamage;
            }
            set
            {
                _CarDamage = value;
                OnPropertyChanged("CarDamage");
            }
        }

        private string _CarColour { get; set; }

        public string CarColour
        {
            get
            {
                return _CarColour;
            }
            set
            {
                _CarColour = value;
                OnPropertyChanged("CarColour");
            }
        }

        private int _CarYear { get; set; }

        public int CarYear
        {
            get
            {
                return _CarYear;
            }
            set
            {
                _CarYear = value;
                OnPropertyChanged("CarYear");
            }
        }

        private int _CarMiles { get; set; }

        public int CarMiles
        {
            get
            {
                return _CarMiles;
            }
            set
            {
                _CarMiles = value;
                OnPropertyChanged("CarMiles");
            }
        }

        private string _CarType { get; set; }

        public string CarType
        {
            get
            {
                return _CarType;
            }
            set
            {
                _CarType = value;
                OnPropertyChanged("CarType");
            }
        }

        private double _CarPrice { get; set; }

        public double CarPrice
        {
            get
            {
                return _CarPrice;
            }
            set
            {
                _CarPrice = value;
                OnPropertyChanged("CarPrice");
            }
        }

        private double _PriceSlider { get; set; }

        public double PriceSlider
        {
            get
            {
                return _PriceSlider;
            }
            set
            {
                _PriceSlider = value;
                OnPropertyChanged("PriceSlider");
            }
        }

        private int _CarDoorsQuantity { get; set; }

        public int CarDoorsQuantity
        {
            get
            {
                return _CarDoorsQuantity;
            }
            set
            {
                _CarDoorsQuantity = value;
                OnPropertyChanged("CarDoorsQuantity");
            }
        }

        private int _CarCapacity{ get; set; }

        public int CarCapacity
        {
            get
            {
                return _CarCapacity;
            }
            set
            {
                _CarCapacity = value;
                OnPropertyChanged("CarCapacity");
            }
        }

        private string _CarMotor { get; set; }

        public string CarMotor
        {
            get
            {
                return _CarMotor;
            }
            set
            {
                _CarMotor = value;
                OnPropertyChanged("CarMotor");
            }
        }

        private string _CarGas { get; set; }

        public string CarGas
        {
            get
            {
                return _CarGas;
            }
            set
            {
                _CarGas = value;
                OnPropertyChanged("CarGas");
            }
        }

        private bool _CarElectricWindows { get; set; }

        public bool CarElectricWindows
        {
            get
            {
                return _CarElectricWindows;
            }
            set
            {
                _CarElectricWindows = value;
                OnPropertyChanged("CarElectricWindows");
            }
        }

        private bool _CarCentralLock { get; set; }

        public bool CarCentralLock
        {
            get
            {
                return _CarCentralLock;
            }
            set
            {
                _CarCentralLock = value;
                OnPropertyChanged("CarCentralLock");
            }
        }

        private bool _CarHydraulicSteering { get; set; }

        public bool CarHydraulicSteering
        {
            get
            {
                return _CarHydraulicSteering;
            }
            set
            {
                _CarHydraulicSteering = value;
                OnPropertyChanged("CarHydraulicSteering");
            }
        }

        private bool _CarElectricRearView { get; set; }

        public bool CarElectricRearView
        {
            get
            {
                return _CarElectricRearView;
            }
            set
            {
                _CarElectricRearView = value;
                OnPropertyChanged("CarElectricRearView");
            }
        }

        private bool _CarAlarm { get; set; }

        public bool CarAlarm
        {
            get
            {
                return _CarAlarm;
            }
            set
            {
                _CarAlarm = value;
                OnPropertyChanged("CarAlarm");
            }
        }

        private bool _CarAirConditioner { get; set; }

        public bool CarAirConditioner
        {
            get
            {
                return _CarAirConditioner;
            }
            set
            {
                _CarAirConditioner = value;
                OnPropertyChanged("CarAirConditioner");
            }
        }

        private bool _CarLuxuryHoops { get; set; }

        public bool CarLuxuryHoops
        {
            get
            {
                return _CarLuxuryHoops;
            }
            set
            {
                _CarLuxuryHoops = value;
                OnPropertyChanged("CarLuxuryHoops");
            }
        }

        /*
        public CarModel(){
            var realm = Realm.GetInstance();
            return;
        }*/


        #endregion

        #region Methods

        public void PageManager(int Id)
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
                    lstImages = new ObservableCollection<ImageFile>();
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new AddCar());
                    break;
                case 5:
                    lstImages = new ObservableCollection<ImageFile>();
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new ReceiveCarList());
                    break;
                default:
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new MainTabbedPage());
                    break;
            }

            ((MasterDetailPage)App.Current.MainPage).IsPresented = false;

        }

        private void VerVehiculo(int id)
        {
            VehiculoActual = lstOriginalVehiculos.Where(x => x.Id == id).FirstOrDefault();

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new CarDetails());

        }

        private void VerReceived(int id)
        {
            ReceivedActual = lstReceived.Where(x => x.Id == id).FirstOrDefault();

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ReceiveCarDetail());

        }

        private void Filters()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new Filters());
        }

        private void AddFavorite(int id)
        {
            
            //App.Current.MainPage.DisplayAlert("Success", "Ha guardado el vehiculo como favorito.", "OK");
        }

        public void setLoggedUser(User usuario)
        {
            LoggedUser = usuario;
            UserId = LoggedUser.ID;
            UserEmail = LoggedUser.Email;
            UserName = LoggedUser.Name;
            UserLastName = LoggedUser.LastName;
            UserFullName = UserName + " " + UserLastName;
            UserPhone = LoggedUser.Phone;
        }

        private async void SaveUser()
        {
            User usuario = new User();
            usuario.Email = Email;
            usuario.Password = Password;
            usuario.Name = Name;
            usuario.LastName = LastName;
            usuario.Phone = Phone;
            usuario.Type = 1;
            string saved = "";
            saved = await User.SaveUser(usuario);
            if (Int32.Parse(saved) > 0)
            {

                App.Current.MainPage.DisplayAlert("Success", "Se ha agregado el usuario correctamente.", "OK");
                PageManager(1);
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Se ha generado un error.", "OK");
            }
        }

        private async void AddCar()
        {
            CarModel car = new CarModel();

            car.Brand = CarBrand;
            car.Model = CarModelo;
            car.Colour = CarColour;
            car.Year = CarYear;
            car.Miles = CarMiles;
            car.Type = CarType;
            car.Price = CarPrice;
            car.DoorsQuantity = CarDoorsQuantity;
            car.Capacity = CarCapacity;
            car.Motor = CarMotor;
            car.Gas = CarGas;

            car.ElectricWindows = CarElectricWindows;
            car.CentralLock = CarCentralLock;
            car.HydraulicSteering = CarHydraulicSteering;
            car.ElectricRearView = CarElectricRearView;
            car.Alarm = CarAlarm;
            car.AirConditioner = CarAirConditioner;
            car.LuxuryHoops = CarLuxuryHoops;
            car.lstImagenes = lstImages;

            string saved = "";
            saved = await CarModel.SaveCar(car);

            if (Int32.Parse(saved) > 0)
            {
                lstImages = new ObservableCollection<ImageFile>();
                CarBrand = "";
                CarModelo = "";
                CarColour = "";
                CarYear = 0;
                CarMiles = 0;
                CarType = "";
                CarPrice = 0;
                CarDoorsQuantity = 0;
                CarCapacity = 0;
                CarMotor = "";
                CarGas = "";
                CarElectricWindows = false;
                CarCentralLock = false;
                CarHydraulicSteering = false;
                CarElectricRearView = false;
                CarAlarm = false;
                CarAirConditioner = false;
                CarLuxuryHoops = false;

                App.Current.MainPage.DisplayAlert("Success", "Se ha agregado el carro correctamente.", "OK");
                PageManager(1);
            }else{
                App.Current.MainPage.DisplayAlert("Error", "Se ha generado un error.", "OK");
            }
        }

        private async void ReceiveCar()
        {
            ReceiveCarModel car = new ReceiveCarModel();

            car.Brand = CarBrand;
            car.Model = CarModelo;
            car.Year = CarYear;
            car.Miles = CarMiles;
            car.Damage = CarDamage;
            car.lstImagenes = lstImages;

            string saved = "";
            saved = await ReceiveCarModel.SaveCar(car);
            lstImages = new ObservableCollection<ImageFile>();
            if (Int32.Parse(saved) > 0)
            {
                lstImages = new ObservableCollection<ImageFile>();
                CarBrand = "";
                CarModelo = "";
                CarYear = 0;
                CarMiles = 0;
                CarDamage = "";

                App.Current.MainPage.DisplayAlert("Success", "Su Consulta ha sido enviada", "OK");
                PageManager(1);
            }else{
                App.Current.MainPage.DisplayAlert("Error", "Se ha generado un error.", "OK");
            }
        }

        private async void DeleteUser()
        {
            string deleted = await User.DeleteUser(LoggedUser);
            if (Int32.Parse(deleted) > 0)
            {
                PageManager(1);
            }
        }

        private async void UpdateUser()
        {
            LoggedUser.Name = UserName;
            LoggedUser.LastName = UserLastName;
            LoggedUser.Email = UserEmail;
            LoggedUser.Phone = UserPhone;
            UserFullName = UserName + " " + UserLastName;

            string updated = await User.UpdateUser(LoggedUser);
            if (Int32.Parse(updated) > 0)
            {
                PageManager(2);
            }
        }

        private void goHome()
        {
            PageManager(1);
        }

        private void OpenChangeInfo()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new ChangeInfo());
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

        private async void AddImage()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file != null)
                {
                    ImageFile image = new ImageFile { Path = file.Path};
                    image.Image = File.ReadAllBytes(image.Path);
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
                lstPages.Add(new MasterPageItem { Id = 5, Title = "Ver Consultas", IconSource = "car.png" });
            }

        }

        private object GetImageSource(Byte[] Image)
        {
            return ImageSource.FromStream(() => new MemoryStream(Image));
        }

        private async Task InitClass()
        {
            //lstVehiculos = await CarModel.ObtenerVehiculos();
            lstOriginalVehiculos = await CarModel.GetCars();
            //lstReceived = await ReceiveCarModel.GetCars();
            lstReceived = await ReceiveCarModel.ObtenerVehiculos();
            lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos);
            lstPages = await MasterPageItem.GetPages();
            //lstOriginalVehiculos = lstVehiculos.ToList();
        }

        private void InitCommands()
        {
            SaveUserCommand = new Command(SaveUser);
            UpdateUserCommand = new Command(UpdateUser);
            AddImageCommand = new Command(AddImage);
            CancelCommand = new Command(goHome);
            PageManagerCommand = new Command<int>(PageManager);
            VerVehiculoCommand = new Command<int>(VerVehiculo);
            VerReceivedCommand = new Command<int>(VerReceived);
            AddFavoriteCommand = new Command<int>(AddFavorite);
            DeleteUserCommand = new Command(DeleteUser);
            ChangeInfoCommand = new Command(OpenChangeInfo);
            AddCarCommand = new Command(AddCar);
            ReceiveCarCommand = new Command(ReceiveCar);
            FiltersCommand = new Command(Filters);
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
