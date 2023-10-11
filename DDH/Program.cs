using System;
using System.Collections.Generic;

namespace DDH
{
    class Program 
    {
        static List<UserDetails> UserList= new List<UserDetails>();
        static List<PackDetails> PackList=new List<PackDetails>();
        static List<RechargeDetails> RechargeList=new List<RechargeDetails>();
        static UserDetails CurrenetDetails;
        public static void Main(string [] args)
        {
            Default();
            do{
                System.Console.WriteLine("\n1.Register\n2.Login\n3.Exit");
                int check=int.Parse(Console.ReadLine());
                do{
                
                if(check!=1 && check!=2 && check!=3)
                {
                    System.Console.WriteLine("please enter vaild");
                    System.Console.WriteLine("\n1.Register\n2.Login\n3.Exit");
                    check=int.Parse(Console.ReadLine());
                }
                }while(check!=1 && check!=2 && check!=3);
                switch(check)
                {
                    case 1:
                    {
                        Resgistration();
                        
                        break;
                    }
                    case 2:
                    {
                        Login();
                        break;
                    }
                }

            }while(true);

        }
        public static void Login()
        {
            System.Console.WriteLine("Enter the user Id:");
            string uesrid=Console.ReadLine();
            foreach(UserDetails i in UserList)
            {
                if(uesrid.Equals(i.UserId))
                {
                    CurrenetDetails=i;
                    System.Console.WriteLine("1.current pack\n2.pack Recharse\n3.wallet recharse\n4.view pack recharse history\n5.show wallet balance \n6.exit");
                    int check1=int.Parse(Console.ReadLine());
                    switch(check1)
                    {
                        case 1:
                        {
                            foreach(RechargeDetails j in RechargeList)
                            {
                                System.Console.WriteLine($" {j.RechargeId} {j.PackId} {j.Valid}");
                            }
                            break;
                        }
                        case 2:
                        {
                            foreach(PackDetails k in PackList)
                            {
                                System.Console.WriteLine($"{k.PackName}  {k.Price}  {k.PackId}  {k.Validity}");
                                
                    
                            }
                            System.Console.WriteLine("Enter the pack Id");
                            string packid=Console.ReadLine();
                            foreach (PackDetails packk in PackList)
                            {
                                if(packid==packk.PackId)
                                {
                                    if(packk.Price>CurrenetDetails.Balance)
                                    {
                                        System.Console.WriteLine("Inssufficient Balance");
                                    }
                                    else
                                    {
                                        CurrenetDetails.Balance-=packk.Price;
                                        RechargeDetails pack=new RechargeDetails(packk.PackName,packk.PackId,DateTime.Now);
                                        
                                        RechargeList.Add(pack);
                                        System.Console.WriteLine($"{packk.PackName} {packk.PackId} {DateTime.Now} ");
                                        System.Console.WriteLine("your Recharge sucessfull");
                                        System.Console.WriteLine("remaing balance"+CurrenetDetails.Balance);
                                        break;
                                    }
                                }
                            }
                            break;
                            
                        }
                        case 3:
                        {
                            WalletRecharge();
                            break;

                        }
                        case 4:
                        {
                            History();
                            break;
                        }
                        case 5:
                        {
                            System.Console.WriteLine("your balance  is :"+CurrenetDetails.Balance);
                            break;
                        }
                        case 6:
                        {
                            break;
                        }
                    }
                }
            }
            
        }
        public static void Resgistration()
        {
            System.Console.WriteLine("Enter your Name");
            string name=Console.ReadLine();
            System.Console.WriteLine("enter ypur mobile number:");
            long mobile=long.Parse(Console.ReadLine());
            System.Console.WriteLine("enter the your email id");
            string email=Console.ReadLine();
            System.Console.WriteLine("enterr your wallet balance");
            int balance;
            bool che=int.TryParse(Console.ReadLine(),out balance);
            UserDetails user=new UserDetails(name,mobile,email,balance);
            UserList.Add(user);
            System.Console.WriteLine(user.UserId);
            
            
        }
        public static void Default()
        {
            PackDetails user1=new PackDetails("RC150","pack1",150,28,50);
            PackDetails user2=new PackDetails("RC300","pack2",300,28,75);
            PackDetails user3=new PackDetails("RC500","pack3",500,28,200);
            PackDetails user4=new PackDetails("RC1500","pack4",1500,28,200);
            
            PackList.Add(user1);
            PackList.Add(user2);
            PackList.Add(user3);
            PackList.Add(user4);

            
            RechargeDetails user01=new RechargeDetails("RP001","RC150",new DateTime(27/12/2012));
            RechargeDetails user02=new RechargeDetails("RP002","RC150",new DateTime(22/12/2012));
            
            RechargeList.Add(user01);
            RechargeList.Add(user02);

            UserDetails user03=new UserDetails("Jhon",398736287,"jhao@hak",500);
            UserDetails user04=new UserDetails("Merlin",54436287,"mer@hak",150);
            UserList.Add(user03);
            UserList.Add(user04);
        }
        public static void WalletRecharge()
        {
            System.Console.WriteLine("Enter the amount to be recharge:");
            int amount;
            bool check2=int.TryParse(Console.ReadLine(),out amount);
            while(!check2)
            {
                System.Console.WriteLine("Please enter vaild input");
                System.Console.WriteLine("Enter the amount to be recharge:");
                check2=int.TryParse(Console.ReadLine(),out amount);
            }
            CurrenetDetails.Balance+=amount;

        }
        public static void History()
        {
            foreach(UserDetails i in UserList)
            {
                if (CurrenetDetails.UserId==i.UserId)
                {
                    System.Console.WriteLine($"{i.Name}   {i.UserId}  {i.Email}  {i.Balance}  {i.Mobile}");
                }
            }
        }
    
    }
}