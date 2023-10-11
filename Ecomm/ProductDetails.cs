using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm
{
    public class ProductDetails
    {
        private static int s_id=1000;
        private string _productId;
        
        public string ProductId { get{
            return _productId;
        } }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int ShipDuration { get; set; }

        public double Price { get; set; }

        public ProductDetails(string productId,string productName,int stock,int shipDuration,double price)
        {
            s_id++;
            _productId="PID"+s_id;
            ProductName=productName;
            Stock=stock;
            ShipDuration=shipDuration;
            Price=price;
        }
        public ProductDetails (string product)
        {
            
        }
    }
}