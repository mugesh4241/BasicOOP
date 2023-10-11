
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using EB_Bill;
namespace EBBill
{
    class Program 
    {
        static List<UserDetails> UserList=new List<UserDetails>();
        static UserDetails CurrentLoginUser;    
        public static void Main (string [] args)
        {
            
            bool choise=false;
            do{

                //menu
                System.Console.WriteLine("1.Registrarion\n2.Login\n3.Exit");
                int check;
                bool che=int.TryParse(Console.ReadLine(),out check);
                while(!che)
                {
                    System.Console.WriteLine("Please enter vaild inforamtion");
                    System.Console.WriteLine("1.Registrarion\n2.Login\n3.Exit");
                    che=int.TryParse(Console.ReadLine(),out check);
                }
                switch(check)
                {
                    case 1:
                    {
                        System.Console.WriteLine("you have enter into registrartion page");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Login();
                        System.Console.WriteLine("your enter into Login");
                        break;
                    }
                    case 3:
                    {
                        System.Console.WriteLine("Thank you");
                        choise=true;
                        break;
                    }
                    
                }

            }while(!choise);

        }
        public static void Registration()
        {
            System.Console.WriteLine("enter your user name");
            string name=Console.ReadLine();
            System.Console.WriteLine("enter your mobile number");
            long mobile;
            bool che1=long.TryParse(Console.ReadLine(),out mobile);
            while(!che1)
            {
                System.Console.WriteLine("Please enter vaild inforamtion");
                che1=long.TryParse(Console.ReadLine(),out mobile);
            }
            System.Console.WriteLine("please enter email id");
            string email=Console.ReadLine();
            UserDetails user =new UserDetails(name,mobile,email);
            UserList.Add(user);
            System.Console.WriteLine(user.UserId);

            


        }
        public static void Login()
        {
            bool che1=true;
            do{
            bool che2=false;
            do{
            
            System.Console.WriteLine("enter your user id");
            string userid=Console.ReadLine().ToUpper();
            foreach (UserDetails user in UserList)
            {
                if(userid==user.UserId)
                {
                    che2=true;
                    System.Console.WriteLine("1.Calculate amount\n2.Display your details\n3.Exit");
                    CurrentLoginUser=user;
                    int check2;
                    bool choise1=int.TryParse(Console.ReadLine(),out check2);
                    while(!choise1)
                    {
                        System.Console.WriteLine("enter valid input");
                        System.Console.WriteLine("1.Calculate amount\n2.Display your details\n3.Exit");
                        choise1=int.TryParse(Console.ReadLine(),out check2);


                    }
                    
                    
                    switch (check2)
                    {
                        case 1:
                        {
                            System.Console.WriteLine("Enter the number of unit used:");
                            double unit=double.Parse(Console.ReadLine());
                            CurrentLoginUser.Unit=unit;
                            CurrentLoginUser.Amount=5*unit;
                            
                            System.Console.WriteLine("your current bill amount is : "+CurrentLoginUser.Amount);
                            
                            break;
                        }
                        case 2:
                        {
                            System.Console.WriteLine("Your details is:");
                            System.Console.WriteLine($" {CurrentLoginUser.UserName}  {CurrentLoginUser.UserId}  {CurrentLoginUser.MailId}  {CurrentLoginUser.PhoneNumber}  {CurrentLoginUser.Unit}  {CurrentLoginUser.Amount}");
                            break;
                        }
                        case 3:
                        {
                            che1=false;
                            break;
                        }
                    }
                    }


                }
            }while(!che2);
            if(!che2)
            {
                System.Console.WriteLine("invalid Input");
            }
            }while(che1);

        }

        }
    }
