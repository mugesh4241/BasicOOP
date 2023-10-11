using System;
using System.Collections.Generic;
namespace BankDetails
{
    public enum Gender{select,Male,Female,Transentor}
    class Program {
    static List<BankDetails> BankList=new List<BankDetails>();
        public static void Main(string [] args)
        {
            do{
            System.Console.WriteLine("1.Registration\n2.Login\n3.Exit");
            int check=int.Parse(Console.ReadLine());
            
            
            switch(check)
            {
                
                case 1:
                {
                    

                    System.Console.WriteLine("Enter the custemer Name:");
                    string name=Console.ReadLine();
                    System.Console.WriteLine("Enter the custemer Mobile Number:");
                    long mobile=long.Parse(Console.ReadLine());
                    System.Console.WriteLine("enter the initial deposid amount");
                    double balance=double.Parse(Console.ReadLine());
                    System.Console.WriteLine("Enter the Gender male female transentor");
                    Gender gender1;
                    bool che=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender1);
                    while(!che)
                    {
                        System.Console.WriteLine("invaild input Please enter again");
                        che=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender1);
                    }
                    System.Console.WriteLine("Enter the Date of birth");
                    DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/mm/yyyy",null);
                    System.Console.WriteLine("Enter the Email-id:");
                    string emailid=Console.ReadLine();
                    
                    BankDetails bank=new BankDetails(name,balance,mobile,gender1,dob,emailid);
                    BankList.Add(bank);
                    

                    break;
                }
                
                case 2:
                {
                    System.Console.WriteLine("Enter the custemer id:");
                    string custemerid=Console.ReadLine();
                    int index=0;
                    foreach(BankDetails i in BankList)
                    {
                        if(custemerid.Equals(i.CustomerId))
                        {
                            break;
                        }
                        else{
                            index++;
                        }
                    }

                    foreach(BankDetails i in BankList )

                    {
                        
                        if(custemerid.Equals(i.CustomerId))
                        {
                            System.Console.WriteLine("1.withdraw\n2.deposite\n3.balanecheck\n4.check");
                            int che1=int.Parse(Console.ReadLine());
                            BankDetails bank =new BankDetails();
                            switch(che1)
                            {
                                case 1:
                                {
                                    System.Console.WriteLine("enter the withdraw amount:");
                                    double amount=double.Parse(Console.ReadLine());
                                    double result=bank.Withdraw(BankList[index].Balance, amount);
                                    System.Console.WriteLine("remaining balance is:"+result);
                                    BankList[index].Balance=result;
                                    break;
                                }
                                case 2:
                                {
                                    System.Console.WriteLine("Enter the Deposite amount");
                                    double amount=double.Parse(Console.ReadLine());
                                    double result=bank.Deposite(BankList[index].Balance,amount);
                                    System.Console.WriteLine("remaining balance is :"+result);
                                    BankList[index].Balance=result;
                                    break;

                                }
                                case 3:
                                {
                                    System.Console.WriteLine("Your balace is "+BankList[index].Balance);

                                    break;
                                }
                            }
                        }
                    }
                    
                    break;
                }
                case 3:
                {
                    System.Console.WriteLine("------------thank you------------");
                    break;
                }

            }
            
        }while(true);
    }
}
}
