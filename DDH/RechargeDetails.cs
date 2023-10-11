using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDH
{
    public class RechargeDetails
    {
        private static int _id=1000;
        private static string _reid;
        public string RechargeId { get
        {
            return _reid;
        } }
        public string PackId { get; set; }
        public DateTime Valid { get; set; }

        public RechargeDetails(string reid,string packid,DateTime valid)
        {
            _id++;
            _reid=reid;
            PackId=packid;
            Valid=valid;
        }
    }
}