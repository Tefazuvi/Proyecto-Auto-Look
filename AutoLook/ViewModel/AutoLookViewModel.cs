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
        public AutoLookViewModel()
        {
            //InitClass();
            InitCommands();
        }
        #region Instances

        public ICommand NavigateWazeCommand { get; set; }
        public ICommand AddImageCommand { get; set; }

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

        //private Image image = new Image();

        #endregion

        #region Methods

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

        /*private async Task InitClass()
        {
            
        }*/

        private void InitCommands()
        {
            NavigateWazeCommand = new Command(NavigateWaze);
            AddImageCommand = new Command(AddImage);
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
