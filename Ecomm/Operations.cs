using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Ecomm
{
    class Operation

    {
        public static List<OrderDetails> OrderList = new List<OrderDetails>();
        public static List<ProductDetails> ProductList = new List<ProductDetails>();
        public static List<CustomerDetails> CustomerList = new List<CustomerDetails>();
        public static CustomerDetails currentLoginUser;
        public static void MainMenu()
        {
            //menu
            DefaultData();
            bool choise = true;
            do
            {
                System.Console.WriteLine("1.Registration\n2.Login\n3.Exit");
                int check;
                bool con = int.TryParse(Console.ReadLine(), out check);
                System.Console.WriteLine(check);

                switch (check)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            choise = false;
                            System.Console.WriteLine("You have selected ");
                            break;
                        }
                    default:
                        {
                            choise = true;
                            System.Console.WriteLine("Invalid Input");
                            break;
                        }
                }
            } while (choise);




        }
        public static void DefaultData()
        {
            //order
            OrderDetails order1 = new OrderDetails("CID1001", "PID1001", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002", "PID1002", 40000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderList.Add(order1);
            OrderList.Add(order2);

            //product
            ProductDetails product1 = new ProductDetails("PID1001", "Mobile(samsang)", 10, 10000, 3);
            ProductDetails product2 = new ProductDetails("PID1002", "Tablet(Lenavo)", 5, 15000, 2);
            ProductDetails product3 = new ProductDetails("PID1003", "Camara(sony)", 3, 20000, 4);
            ProductDetails product4 = new ProductDetails("PID1004", "iPhone", 5, 50000, 6);
            ProductDetails product5 = new ProductDetails("PID1005", "Laptop(Lenavo13)", 3, 40000, 3);
            ProductDetails product6 = new ProductDetails("PID1006", "HeadPhone(boat)", 5, 1000, 2);
            ProductDetails product7 = new ProductDetails("PID1007", "Headset(boat)", 4, 500, 2);
            ProductList.Add(product1);
            ProductList.Add(product2);
            ProductList.Add(product3);
            ProductList.Add(product4);
            ProductList.Add(product5);
            ProductList.Add(product6);
            ProductList.Add(product7);

            //Customer

            CustomerDetails customer1 = new CustomerDetails("Ravi", "chennai", 9885858439, 50000, "ravi@gmai.com");
            CustomerDetails customer2 = new CustomerDetails("Basker", "chennai", 9884858439, 60000, "basker@gmai.com");
            CustomerList.Add(customer1);
            CustomerList.Add(customer2);

        }
        //Registration method
        public static void Registration()
        {
            System.Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            System.Console.WriteLine("Enter Your city Name");
            string city = Console.ReadLine();
            System.Console.WriteLine("Enter Your Phone number :");
            long mobilenumber = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter your Email Id:");
            string email = Console.ReadLine();
            System.Console.WriteLine("Enter your wallet balance:");
            double wallerBalance = double.Parse(Console.ReadLine());
            CustomerDetails customer = new CustomerDetails(name, city, mobilenumber, wallerBalance, email);

            CustomerList.Add(customer);
            System.Console.WriteLine(customer.CustomerId);


        }
        //Login method 
        public static void Login()
        {
            bool choise1 = false;
            System.Console.WriteLine("Enter your Customer Id");
            string customerId = Console.ReadLine().ToUpper();
            foreach (CustomerDetails i in CustomerList)
            {
                if (customerId == i.CustomerId)
                {
                    System.Console.WriteLine("Login sucessfull");
                    choise1 = true;
                    currentLoginUser = i;
                    SubMenu();
                }
            }
            if (!choise1)
            {
                System.Console.WriteLine("Invalid input");
            }
        }
        public static void SubMenu()
        {
            bool choise2 = true;
            do
            {

                System.Console.WriteLine("a.purchase\nb.Order History\nc.Cancel Order\nd.wallet Balance\n.e.wallet reacharse\nf.Exit");
                char check1 = char.Parse(Console.ReadLine());
                switch (check1)
                {
                    case 'a':
                        {
                            Purchase();
                            break;
                        }
                    case 'b':
                        {
                            OrderHistory();
                            break;
                        }
                    case 'c':
                        {
                            CancelOrder();
                            break;
                        }
                    case 'd':
                        {
                            walletBalance();
                            break;
                        }
                    case 'e':
                        {
                            WallettRecharge();
                            break;
                        }
                    case 'f':
                        {
                            choise2 = false;
                            break;
                        }
                }
            } while (choise2);

        }
        public static void Purchase()
        {
            System.Console.WriteLine("Product details");
            foreach (ProductDetails j in ProductList)
            {
                System.Console.WriteLine($"{j.ProductId} {j.ProductName} {j.Stock} {j.Price} {j.ShipDuration}");
            }
            // product Id
            System.Console.WriteLine("enter Product Id");
            string productId = Console.ReadLine().ToUpper();
            bool choise3 = false;
            foreach (ProductDetails product in ProductList)
            {
                if (productId.Equals(product.ProductId))
                {
                    choise3 = true;
                    System.Console.WriteLine("enter the num of product to be purchased");
                    int count = int.Parse(Console.ReadLine());
                    if (count > product.Stock)
                    {
                        System.Console.WriteLine(product.Stock);
                    }
                    else
                    {
                        double deliveryCharge = 50;
                        double totalAmount = (count * product.Price) + deliveryCharge;
                        if (totalAmount <= currentLoginUser.WalletBalance)
                        {
                            currentLoginUser.DeductBalance(totalAmount);
                            product.Stock -= count;
                            //create order details object and adding to its list
                            OrderDetails order = new OrderDetails(currentLoginUser.CustomerId, product.ProductId, totalAmount, DateTime.Now, count, OrderStatus.Ordered);
                            OrderList.Add(order);
                            System.Console.WriteLine("Order placed successfully your order Id is:" + order.OrderId);
                        }
                        else
                        {
                            System.Console.WriteLine("Insufficient wallet Balance please detect your wallet Balance");
                        }
                    }

                }
            }
            if (!choise3)
            {
                System.Console.WriteLine("Invalid input");
            }

        }
        //cancel order
        public static void CancelOrder()
        {
            //show the order list based on id and status
            foreach (OrderDetails i in OrderList)
            {
                if (currentLoginUser.CustomerId == i.CustomerId && i.OrderStatus == OrderStatus.Ordered)
                {
                    System.Console.WriteLine($"{i.OrderId} {i.ProductId} {i.TodalPrice} {i.PurchaseDate} {i.Quantity} {i.OrderStatus}");
                }
            }
            System.Console.WriteLine("Enter the order Id");
            string id = Console.ReadLine().ToUpper();
            //need to check the order id and it's status as ordered from orderlist
            bool choise4 = false;
            foreach (OrderDetails order in OrderList)
            {
                if (id == order.OrderId && order.OrderStatus == OrderStatus.Ordered && currentLoginUser.CustomerId == order.CustomerId)
                {
                    choise4 = true;
                    //if id is available restore and else invalid id.
                    // change the order status as canceled and display the cancel message
                    order.OrderStatus = OrderStatus.Cancelled;
                    currentLoginUser.WalletRecharse(order.TodalPrice);
                    foreach (ProductDetails product in ProductList)
                    {
                        if (product.ProductId == order.ProductId)
                        {
                            product.Stock += order.Quantity;
                        }
                    }
                    System.Console.WriteLine($"order {order.OrderId} is cancelled");

                }
            }
            if (!choise4)
            {
                System.Console.WriteLine("Invaild Input");
            }


        }

        // order history
        public static void OrderHistory()
        {
            foreach (OrderDetails i in OrderList)
            {
                if (currentLoginUser.CustomerId == i.CustomerId)
                {
                    System.Console.WriteLine($"{i.OrderId} {i.ProductId} {i.TodalPrice} {i.PurchaseDate} {i.Quantity} {i.OrderStatus}");
                }
            }
        }
        public static void walletBalance()
        {
            System.Console.WriteLine($"your Wallet Balance is: {currentLoginUser.WalletBalance}");


        }
        public static void WallettRecharge()
        {
            System.Console.WriteLine("do you want to proceed-Yes or No");
            string check2 = Console.ReadLine().ToLower();
            if (check2 == "yes")
            {
                System.Console.WriteLine("enter the amount to be recharge:");
                double amount = double.Parse(Console.ReadLine());
                currentLoginUser.WalletRecharse(amount);
            }


        }
    }
}



/*        foreach(OrderDetails i in OrderList)
            {
                System.Console.WriteLine($"{i.CustomerId} {i.ProductId} {i.TodalPrice} {i.PurchaseDate} {i.Quantity}{i.OrderStatus}");
            }

            foreach (ProductDetails j in ProductList)
            {
                System.Console.WriteLine($"{j.ProductId} {j.ProductName} {j.Stock} {j.Price} {j.ShipDuration}");
            }

            foreach(CustomerDetails k in CustomerList)
            {
                System.Console.WriteLine($"{k.Name} {k.City} {k.MobileNumber} {k.WalletBalance} {k.Email}");
            }*/
