using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LibraryDetails
{
    public enum Gender{male,female,transenter}
    public enum Department{ECE,EEE,CSE}
    public class UserDetails
    {
        private static int s_id=3000;
        private static string _userid;
        public string UserId { get
        {
            return _userid;
        } }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        
        
        public long MobileNumber { get; set; }
        public double WalletBalance { get; set; }

        public UserDetails (string username,long mobilenum,string emailid,double walletBalance,Gender gender,Department depatment )
        {
            s_id++;
            _userid="SF"+3000;
            UserName=username;
            MobileNumber=mobilenum;
            EmailId=emailid;
            WalletBalance=walletBalance;
            Gender=gender;
            Department=depatment;
        }
        public static double WalletRecharge(double amount)
        {
            return amount;
        }
        public static double DedutBalance(double amount)
        {
            return amount;
        }
    }
}