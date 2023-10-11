using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDH
{
    public class UserDetails
    {
        private static int _id=1001;
        private static string _userId;
        public string UserId { get{
            return _userId;
        } }
        
        public int Balance { get; set; }
        public long Mobile { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserDetails(string name,long mobile,string email,int balance)
        {
            _id++;
            _userId="DTH"+_id;
            Name=name;
            Mobile=mobile;
            Balance=balance;
            Email=email;
        }
    }
}