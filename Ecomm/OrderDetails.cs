using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm
{
    public enum OrderStatus{Default, Ordered, Cancelled};
    public class OrderDetails
    {
        private static int s_id=1000;

        private string _orderId;
        public string OrderId { get{
            return _orderId;
        }  }
        public string CustomerId { get; set; }
        public string ProductId {get;set;}
        public double TodalPrice{ get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string customerId,string productId,double totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus)
        {
            s_id++;
            _orderId="OID"+s_id;
            CustomerId=customerId;
            ProductId=productId;
            TodalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderStatus;

        }
        public OrderDetails(string order)
        {

        }
        
    }
}