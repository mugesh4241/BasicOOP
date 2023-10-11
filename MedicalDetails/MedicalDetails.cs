using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDetails
{
    public class MedicalDetails
    {
        private static int _id=1000;
        private static string _userid;
        public string UserId { get{
            return _userid; 
        }
        
        }
        public long MobileNumber { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public double Balance { get; set; } 
        public MedicalDetails(){}
        public MedicalDetails(long mobileNumber,string userName,int age,string city,double balance)
        {
            ++_id;
            _userid="UDI"+_id;
            MobileNumber=mobileNumber;
            UserName=userName;
            Age=age;
            City=city;
            Balance=balance;

        }

    }
}