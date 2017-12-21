using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AutoLook.Model
{
    public class Calculator : INotifyPropertyChanged
    {
        public double VehiclePrice { get; set; }
        public double DownPayment { get; set; }
        public double Loan { get; set; }
        public double InterestRate { get; set; }
        public int TermMonths { get; set; }

        public ICommand CalculateCommand { get; set; }

        private double _MonthlyPayment { get; set; }

        public double MonthlyPayment
        {
            get
            {
                return _MonthlyPayment;
            }
            set
            {
                _MonthlyPayment = value;
                OnPropertyChanged("MonthlyPayment");
            }
        }

        public Calculator()
        {
            InterestRate = 21;
            CalculateCommand = new Command(Calculate);
        }

        private void Calculate()
        {
            Loan = VehiclePrice - DownPayment;
            double factor = (InterestRate/100 / 12) / (1 - Math.Pow((1 + (InterestRate/100 / 12)), (-TermMonths)));
            MonthlyPayment = Loan * factor;
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
