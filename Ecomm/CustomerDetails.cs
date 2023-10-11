using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm
{
    public class CustomerDetails
    {
        private static int s_customerId=1000;
        

        public string CustomerId { get;}
        public string  Name { get; set; }
        public string  City { get; set; }
        public long  MobileNumber { get; set; }
        public double WalletBalance { get; set; }

        public string  Email { get; set; }

        public CustomerDetails(string name,string city ,long mobileNumber, double walletBalance , string email)
        {
            s_customerId++;
            CustomerId="CID"+s_customerId;
            Name=name;
            City =city;
            MobileNumber=mobileNumber;
            WalletBalance=walletBalance;
           
            Email=email;
        }
        public CustomerDetails(string customer)
        {
            string [] customerDetails=customer.Split(",");
            s_customerId=int.Parse(customerDetails[0].Remove(0,3));
            CustomerId=customerDetails[0];
            Name=customerDetails[1];
            City=customerDetails[2];
            MobileNumber=long.Parse(customerDetails[3]);
            WalletBalance=double.Parse(customerDetails[4]);

        }
        public void  WalletRecharse(double amount)
        {
            WalletBalance+=amount;           
        }
        public void DeductBalance(double amount)
        {
            WalletBalance -=amount;

        }
    }
}