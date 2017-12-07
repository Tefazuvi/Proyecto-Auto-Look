using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using AutoLook.View;

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

        #endregion

        #region Methods

        private void NavigateWaze()
        {
            
        }

        /*private async Task InitClass()
        {
            
        }*/

        private void InitCommands()
        {
            NavigateWazeCommand = new Command(NavigateWaze);
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
