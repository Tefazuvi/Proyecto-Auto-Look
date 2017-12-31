using System;

namespace AutoLook.Model
{
    public class Calculator
    {
        public double VehiclePrice { get; set; }
        public double DownPayment { get; set; }
        public double Loan { get; set; }
        public double InterestRate { get; set; }
        public int TermMonths { get; set; }

        public Calculator()
        {
            InterestRate = 21;
        }

        public double Calculate()
        {
            Loan = VehiclePrice - DownPayment;
            double factor = (InterestRate / 100 / 12) / (1 - Math.Pow((1 + (InterestRate / 100 / 12)), (-TermMonths)));
            return Loan * factor;
        }

    }
}
