using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using AutoLook.Model;

namespace AutoLook.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {

        public ICommand CalculateCommand { get; set; }

        private Calculator Calc = new Calculator();

        private int _TermMonths { get; set; }

        public int TermMonths
        {
            get
            {
                return _TermMonths;
            }
            set
            {
                _TermMonths = value;
                OnPropertyChanged("TermMonths");
            }
        }

        private double _DownPayment { get; set; }

        public double DownPayment
        {
            get
            {
                return _DownPayment;
            }
            set
            {
                _DownPayment = value;
                OnPropertyChanged("DownPayment");
            }
        }

        private double _VehiclePrice { get; set; }

        public double VehiclePrice
        {
            get
            {
                return _VehiclePrice;
            }
            set
            {
                _VehiclePrice = value;
                OnPropertyChanged("VehiclePrice");
            }
        }

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

        private double _InterestRate { get; set; }

        public double InterestRate
        {
            get
            {
                return _InterestRate;
            }
            set
            {
                _InterestRate = value;
                OnPropertyChanged("InterestRate");
            }
        }

        public CalculatorViewModel()
        {
            InterestRate = Calc.InterestRate;
            CalculateCommand = new Command(getMonthlyPayment);
        }

        public void getMonthlyPayment(){
            Calc.VehiclePrice = VehiclePrice;
            Calc.DownPayment = DownPayment;
            Calc.TermMonths = TermMonths;
            Calc.InterestRate = InterestRate;
            MonthlyPayment = Calc.Calculate();
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
