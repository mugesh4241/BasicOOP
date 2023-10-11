using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDH
{
    public class PackDetails
    {
        public string PackId { get; set; }
        public string PackName { get; set; }
        public int Price { get; set; }
        public int Validity { get; set; }

        public int NoOfChannel { get; set; }

        public PackDetails(string packid,string packname,int price,int validity,int nochenal)
        {
            PackId=packid;
            PackName=packname;
            Price=price;
            Validity=validity;
            NoOfChannel=nochenal;
        }
    }
}