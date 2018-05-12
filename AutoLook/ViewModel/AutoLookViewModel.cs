using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using AutoLook.View;
using AutoLook.ViewModel;
using AutoLook.Model;
using Plugin.Media;
using Realms;
using System.IO;
using System.Security.Cryptography;
using AutoLook.Helper;

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
        public ICommand ForgetCommand { get; set; }
        public ICommand ReceiveCarCommand { get; set; }

        private bool _IsBusy { get; set; }

        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }
            set
            {
                _IsBusy = value;
                OnPropertyChanged("IsBusy");
            }

        }

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

        private string _VerifyPassword { get; set; }

        public string VerifyPassword
        {
            get
            {
                return _VerifyPassword;
            }
            set
            {
                _VerifyPassword = value;
                OnPropertyChanged("VerifyPassword");
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

        private bool _IsLogged { get; set; }

        public bool IsLogged
        {
            get
            {
                return _IsLogged;
            }
            set
            {
                _IsLogged = value;
                setLogOption(_IsLogged);
                OnPropertyChanged("IsLogged");
            }
        }

        private bool _AcceptTerms { get; set; }

        public bool AcceptTerms
        {
            get
            {
                return _AcceptTerms;
            }
            set
            {
                _AcceptTerms = value;
                OnPropertyChanged("AcceptTerms");
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

		private CarModel _Vehiculo = new CarModel();

        public CarModel Vehiculo
        {
            get
            {
                return _Vehiculo;
            }
            set
            {
                _Vehiculo = value;
                OnPropertyChanged("Vehiculo");
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

        private ObservableCollection<CarModel> _lstFavorites = new ObservableCollection<CarModel>();

        public ObservableCollection<CarModel> lstFavorites
        {
            get
            {
                return _lstFavorites;
            }
            set
            {
                _lstFavorites = value;
                OnPropertyChanged("lstFavorites");
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
                    if (lstPages[0].Title.Equals("Cerrar Sesion"))
                    {
                        IsLogged = false;
                        goHome();
                        break;
                    }
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new LoginPage());
                    break;
                case 1:
                    ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new MainTabbedPage());
                    break;
                case 2:
                    if (!IsLogged)
                    {
                        PageManager(0);
                        break;
                    }
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

        private async void AddFavorite(int id)
        {
            string saved = "";
            saved = await User.SaveFavorite(LoggedUser.UserID, id);
            if (Int32.Parse(saved) > 0)
            {
                GetFavs();
                await App.Current.MainPage.DisplayAlert("Success", "Ha guardado el vehiculo como favorito.", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "No se ha guardado el vehiculo como favorito.", "OK");
            }
        }

        private bool PasswordVerification()
        {
            if (!Password.Equals(VerifyPassword))
            {
                App.Current.MainPage.DisplayAlert("Error", "Las contrasenas no coinciden.", "OK");
                VerifyPassword = "";
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task setLoggedUser(User usuario)
        {
            LoggedUser = usuario;
            UserId = LoggedUser.UserID;
            UserEmail = LoggedUser.Email;
            UserName = LoggedUser.Name;
            UserLastName = LoggedUser.LastName;
            UserFullName = UserName + " " + UserLastName;
            UserPhone = LoggedUser.Phone;
            GetFavs();
        }

        private async void SaveUser()
        {
            if (Email != null && Password != null && VerifyPassword != null && Name != null && LastName != null)
            {
                if (PasswordVerification() && AcceptTerms)
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
                        Email = "";
                        Password = "";
                        VerifyPassword = "";
                        Name = "";
                        LastName = "";
                        Phone = "";
                        AcceptTerms = false;
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Error", "Se ha generado un error.", "OK");
                    }
                }
                else
                {
                    if (AcceptTerms == false)
                    {
                        App.Current.MainPage.DisplayAlert("Error", "Por favor aceptar los términos y condiciones de uso y privacidad.", "OK");
                    }
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Debe completar los espacios con asterisco.", "OK");
            }
        }

        private async void AddCar()
        {
            CarModel car = new CarModel();
            
            car.Brand = Vehiculo.Brand;
            car.Model = Vehiculo.Model;
            car.Colour = Vehiculo.Colour;
            car.Transmision = Vehiculo.Transmision;
            car.Year = Vehiculo.Year;
            car.Miles = Vehiculo.Miles;
            car.Type = Vehiculo.Type;
            car.Price = Vehiculo.Price;
            car.DoorsQuantity = Vehiculo.DoorsQuantity;
            car.Capacity = Vehiculo.Capacity;
            car.Motor = Vehiculo.Motor;
            car.Gas = Vehiculo.Gas;

            car.ElectricWindows = Vehiculo.ElectricWindows;
            car.CentralLock = Vehiculo.CentralLock;
            car.HydraulicSteering = Vehiculo.HydraulicSteering;
            car.ElectricRearView = Vehiculo.ElectricRearView;
            car.Alarm = Vehiculo.Alarm;
            car.AirConditioner = Vehiculo.AirConditioner;
            car.LuxuryHoops = Vehiculo.LuxuryHoops;
            car.lstImagenes = lstImages;

            string saved = "";
            saved = await CarModel.SaveCar(car);

            if (Int32.Parse(saved) > 0)
            {
                lstImages = new ObservableCollection<ImageFile>();
                Vehiculo = new CarModel();

                lstOriginalVehiculos = await CarModel.GetCars();
                lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos);
                App.Current.MainPage.DisplayAlert("Success", "Se ha agregado el carro correctamente.", "OK");
                PageManager(1);
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Se ha generado un error.", "OK");
            }
        }

        private async void ReceiveCar()
        {
            ReceiveCarModel car = new ReceiveCarModel();

            car.Brand = ReceivedActual.Brand;
            car.Model = ReceivedActual.Model;
            car.Year = ReceivedActual.Year;
            car.Miles = ReceivedActual.Miles;
            car.Damage = ReceivedActual.Damage;
            car.lstImagenes = ReceivedActual.lstImagenes;

            string saved = "";
            saved = await ReceiveCarModel.SaveCar(car, UserId);
            lstImages = new ObservableCollection<ImageFile>();
            if (Int32.Parse(saved) > 0)
            {
                lstImages = new ObservableCollection<ImageFile>();
                ReceivedActual = new ReceiveCarModel();
                /*CarBrand = "";
                CarModelo = "";
                CarYear = 0;
                CarMiles = 0;
                CarDamage = "";
*/
                lstReceived = await ReceiveCarModel.GetCars();
                App.Current.MainPage.DisplayAlert("Success", "Su Consulta ha sido enviada", "OK");
                PageManager(1);
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Se ha generado un error.", "OK");
            }
        }


        private async void DeleteUser()
        {
            UserSystem.DeleteUserRealm(LoggedUser.UserID);
            string deleted = await User.DeleteUser(LoggedUser);
            if (Int32.Parse(deleted) > 0)
            {
                await App.Current.MainPage.DisplayAlert("Eliminado", "La informacion del usuario ha sido eliminada.", "OK");
                await setLogOption(false);
                PageManager(1);

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("OOOPS", "Ha ocurrido un error, intente de nuevo. ", "OK");
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
                await App.Current.MainPage.DisplayAlert("Informacion Actualizada", "Se han guardado los datos correctamente.", "OK");
                PageManager(2);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("OOOPS", "Ha ocurrido un error, intente de nuevo. ", "OK");
            }
        }

        private async Task setLogOption(bool Logged)
        {
            if (Logged == true)
            {
                lstPages[0] = new MasterPageItem { Id = 0, Title = "Cerrar Sesion", IconSource = "blueperson.png" };
            }
            else
            {
                IsAdmin = false;
                LoggedUser = new User();
                UserId = 0;
                UserEmail = "";
                UserName = "";
                UserLastName = "";
                UserFullName = "";
                UserPhone = "";
                lstPages[0] = new MasterPageItem { Id = 0, Title = "Iniciar sesion", IconSource = "blueperson.png" };
                goHome();
            }
        }

        private void goHome()
        {
            PageManager(1);
        }

        private void Forget()
        {
            UserSystem.DeleteUserRealm(LoggedUser.UserID);
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
                    if (lstImages.Count >= 4)
                    {
                        await App.Current.MainPage.DisplayAlert("Maximo de imagenes", "Tiene un total de 6 imagenes", "OK");
                    }
                    else
                    {
                        ImageFile image = new ImageFile { Path = file.Path };
                        image.Image = ImageResizer.ResizeImage(File.ReadAllBytes(image.Path), 250, 250);
                        lstImages.Add(image);
                    }
                }
                return;
            }
        }

        private async Task UpdatePages(bool Admin)
        {
            if (IsAdmin)
            {
                lstPages.Add(new MasterPageItem { Id = 4, Title = "Agregar vehículo", IconSource = "car.png" });
                lstReceived = await ReceiveCarModel.GetCars();
                lstPages.Add(new MasterPageItem { Id = 5, Title = "Ver Consultas", IconSource = "car.png" });
            }
            else
            {
                var itemToRemove = lstPages.SingleOrDefault(r => r.Id == 4);
                if (itemToRemove != null)
                    lstPages.Remove(itemToRemove);

                itemToRemove = lstPages.SingleOrDefault(r => r.Id == 5);
                if (itemToRemove != null)
                    lstPages.Remove(itemToRemove);
            }

        }

        private object GetImageSource(Byte[] Image)
        {
            return ImageSource.FromStream(() => new MemoryStream(Image));
        }

        private async void GetFavs()
        {
            List<int> favorites = await User.GetFavorite(LoggedUser.UserID);
            lstFavorites = new ObservableCollection<CarModel>(lstOriginalVehiculos.Where(r => favorites.Contains(r.Id)));
        }

        private async Task InitClass()
        {
            lstPages = await MasterPageItem.GetPages();
            IsBusy = true;
            lstOriginalVehiculos = await CarModel.GetCars();
            lstVehiculos = new ObservableCollection<CarModel>(lstOriginalVehiculos);
            if (UserSystem.CountUserSystem() > 0)
            {
                UserSystem usuario = UserSystem.GetUserRealm();
                LoginViewModel loginViewModel = new LoginViewModel();
                loginViewModel.User = usuario.Email;
                loginViewModel.Password = usuario.Pass;
                loginViewModel.Recordar = false;
                loginViewModel.Login();
            }
            IsBusy = false;
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
            ForgetCommand = new Command(Forget);
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
