using System;
using System.Collections.Generic;
namespace ECom
{
    class Program {
        static List<CustumerDetails> CustumerList=new List<CustumerDetails>();

        public static void Main(string [] args )
        {
            do{
                System.Console.WriteLine("1.Customer Regitration\n2.Login\n3.Exit");
                int check=int.Parse(Console.ReadLine());
                do{
                    if(check!=1 && check !=2 && check !=3)
                    {
                        System.Console.WriteLine("Please Enter Vaild input ");
                        System.Console.WriteLine("1.Customer Regitration\n2.Login\n3.Exit");
                        check=int.Parse(Console.ReadLine());

                    }
                }while(check!=1 && check !=2 && check !=3);

                switch(check)
                {
                    case 1:
                    {
                        System.Console.WriteLine("Enter your name:");
                        string name=Console.ReadLine();
                        System.Console.WriteLine("enter your city:");
                        string city=Console.ReadLine();
                        System.Console.WriteLine("Enter your phone number");
                        long phoneNumber;
                        
                        bool con1=long.TryParse(Console.ReadLine(),out phoneNumber);
                        while(!con1)
                        {
                            System.Console.WriteLine("Please Enter vaild Input");
                            con1=long.TryParse(Console.ReadLine(),out phoneNumber);

                        }

                        System.Console.WriteLine("Enter your MailID:");
                        string email=Console.ReadLine();
                        System.Console.WriteLine("Enter your Wallent Balance:");
                        int walletbalance;
                        bool con2=int.TryParse(Console.ReadLine(),out walletbalance);
                        while(!con2)
                        {
                            System.Console.WriteLine("Please Enter vaild Input");
                            con1=int.TryParse(Console.ReadLine(),out walletbalance);

                        }
                        CustumerDetails custumer=new CustumerDetails(name,city,phoneNumber,email,walletbalance);
                        CustumerList.Add(custumer);
                        System.Console.WriteLine("Registration sucessful!\nYour custemer Id is:");


                        break;
                    }
                }

            }while(true);

        }
    }
}