using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankDetails
{
    public class BankDetails
    {
        public string CustomerId { get; set; }
        private static int _id=1000;
        public string  CustomerName { get; set; }
        public double Balance { get; set; }
        public double PhoneNum { get; set; }
        public string MailId { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender1 { get; set; }
        public BankDetails(){}
        public BankDetails(string name,double balance,long mobile,Gender gender1,DateTime dob ,string emailid)
        {
            _id++;
            CustomerId="HDFC"+_id;
            Balance=balance;
            PhoneNum=mobile;
            MailId=emailid;
            DOB=dob;
            Gender1=gender1;
            CustomerName=name;
        }
        public double Withdraw(double balance,double amount)
        {
            
            

            return balance-amount ;
        }
        public double Deposite(double balance,double amount)
        {
            
            return balance+amount;
        }

    }
}