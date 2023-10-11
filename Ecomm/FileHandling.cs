using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm
{
    public static class FileHandling

    {
        public static void Create()

        {
            if (!Directory.Exists("EComm"))
            {
                Directory.CreateDirectory("EComm");
                System.Console.WriteLine("Folder created");
            }
            else
            {
                System.Console.WriteLine("folder already exits");
            }
            if (!File.Exists("EComm/CustomerDetails.csv"))
            {
                File.Create("EComm/CustomerDetails.csv").Close();
                System.Console.WriteLine("File created");

            }
            else
            {
                System.Console.WriteLine("file already exits");
            }
            if (!File.Exists("EComm/OrderDetails.csv"))
            {
                File.Create("EComm/OrderDetails.csv").Close();
                System.Console.WriteLine("created file");
            }
            else
            {
                System.Console.WriteLine("file already exits");
            }
            if (!File.Exists("EComm/ProductDetails.cvs"))
            {
                File.Create("EComm/ProductDetails.cvs").Close();
                System.Console.WriteLine("file created");
            }
            else
            {
                System.Console.WriteLine("alreaty exits");
            }
        }

        //     public static void WriteToCSV()
        //     {
        //         string [] CustomerDetails=new string [Operation.CustomerList.Count];
        //         for (int i=0;i<Operation.CustomerList.Count;i++)
        //         {
        //             CustomerDetails[i]=Operation .CustomerList[i].CustomerId+","+Operation.CustomerList[i].Name+","+Operation.CustomerList[i].Email+","+Operation.CustomerList[i].City+","+Operation.CustomerList[i].MobileNumber+","+Operation.CustomerList[i].WalletBalance;

        //         }
        //         File.WriteAllLines("EComm/CustomerDetails.csv",CustomerDetails);

        //         string [] OrderDetails=new string [Operation.OrderList.Count];
        //         for (int i=0;i<Operation.OrderList.Count;i++)
        //         {
        //             OrderDetails[i]=Operation.OrderList[i].OrderId+","+Operation.OrderList[i].CustomerId+","+Operation.OrderList[i].ProductId+","+Operation.OrderList[i].Quantity+","+Operation.OrderList[i].OrderStatus;


        //         }
        //         File.WriteAllLines("EComm/OrderDetails.csv",OrderDetails);

        //     }


        public static void ReadFromCSV()
        {
            string [] CustomerDetails=File.ReadAllLines("EComm/CustomerDetails.csv");
            foreach(string customer in CustomerDetails)
            {
                CustomerDetails customer1=new CustomerDetails(customer);
                Operation .CustomerList.Add(customer1);
            }
            
            string [] OrderDetails=File.ReadAllLines("EComm/OrderDetails.csv");
            foreach (string order in OrderDetails )
            {
                OrderDetails order1=new OrderDetails(order);
                Operation.OrderList.Add(order1);

            }

            string [] ProductDetails=File .ReadAllLines("EComm/ProductDetails.cvs");
            foreach (string product in ProductDetails)
            {
                ProductDetails product1=new ProductDetails(product);
                Operation.ProductList.Add(product1);


                
            }

        }


    }


}


