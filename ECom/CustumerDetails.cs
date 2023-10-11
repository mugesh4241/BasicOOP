using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom
{
    public class CustumerDetails
    {
        public string CustumerName { get; set; }
        public string City { get; set; }
    
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WalletBalance { get; set; }
        public string CustomerId { get; set; }

        public CustumerDetails(string customerName,string city,long phoneNumber,string email,int walletbalance)
        {
            CustumerName=customerName;
            City=city;
            PhoneNumber=phoneNumber;
            Email=email;
            WalletBalance=walletbalance;
        }
    }
}