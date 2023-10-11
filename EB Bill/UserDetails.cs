using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EB_Bill
{
    public class UserDetails
    {
        private static int s_id=1000;
        private string _usedId;
        public string UserId { get
        {
            return _usedId;
        }}
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string MailId { get; set; }
        public double Unit { get; set; }
        public double Amount { get; set; }

        public UserDetails(string name,long number,string mail)
        {
            s_id++;
            _usedId="EB"+s_id;
            UserName=name;
            PhoneNumber=number;
            MailId=mail;
            Unit=0;
            Amount=0;

        }
    }
}