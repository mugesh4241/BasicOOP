using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
namespace LibraryDetails
{
    class Program 
    {
        static List<UserDetails> UserList =new List<UserDetails>();
        static List<BookDetails > BookList=new List<BookDetails>();
        static List<BorrowDetails > BorrowList=new List<BorrowDetails>();
        static UserDetails CurrentLoginUser;
        public static void Main (string [] args)
        {
            DefaultDetails();
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
        public static void DefaultDetails()
        {
            //Default user details
            UserDetails user1=new UserDetails("ravichandran",9847872983,"ravi@.com",100,Gender.male,Department.ECE);
            UserDetails user2=new UserDetails("priyadharshini",9847872983,"priya@.com",150,Gender.female,Department.CSE);
            UserList.Add(user1);
            UserList.Add(user1);

            //Book details

            BookDetails book1=new BookDetails("BI101","c#","Author1",3);
            BookDetails book2=new BookDetails("BI102","HTML","Author2",5);
            BookDetails book3=new BookDetails("BI103","css","Author3",3);
            BookDetails book4=new BookDetails("BI104","js","Author4",3);
            BookDetails book5=new BookDetails("BI105","js","Author5",2);
            BookList.Add(book5);
            BookList.Add(book1);
            BookList.Add(book2);
            BookList.Add(book3);
            BookList.Add(book4);

            //Borrow Details
            BorrowDetails borrow1=new BorrowDetails("BID101","SF3001",2,0,new DateTime(13/09/2023),Status.borrowed);
            BorrowDetails borrow2=new BorrowDetails("BID103","SF3001",1,0,new DateTime(12/09/2023),Status.borrowed);
            BorrowDetails borrow3=new BorrowDetails("BID104","SF3001",2,0,new DateTime(14/09/2023),Status.returned);
            BorrowDetails borrow4=new BorrowDetails("BID102","SF3002",1,0,new DateTime(09/09/2023),Status.borrowed);
            BorrowDetails borrow5=new BorrowDetails("BID105","SF3002",1,0,new DateTime(13/09/2023),Status.returned);
            BorrowList.Add(borrow5);
            BorrowList.Add(borrow4);
            BorrowList.Add(borrow3);
            BorrowList.Add(borrow2);
            BorrowList.Add(borrow1);




        }
        //register
        public static void Registration()
        {
            System.Console.WriteLine("enter your user name");
            string name=Console.ReadLine();
            System.Console.WriteLine("enter your genter");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine());
            System.Console.WriteLine("enter your depart ment");
            Department department=Enum.Parse<Department>(Console.ReadLine());;
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
            double walletBalance;
            bool che2=double.TryParse(Console.ReadLine(),out walletBalance);
            while(!che2)
            {
                System.Console.WriteLine("Please enter vaild inforamtion");
                che2=double.TryParse(Console.ReadLine(),out walletBalance);
            }
            UserDetails user=new UserDetails(name,mobile ,email ,walletBalance ,gender,department);
            UserList.Add(user);
            System.Console.WriteLine(user.UserId+" :this is your user id");


        }
        //login
        public static void Login()
        {
            bool che4=true;
            do{
            bool che3=false;
            do{
            
            System.Console.WriteLine("enter your user id");
            string userid=Console.ReadLine().ToUpper();
            foreach (UserDetails user in UserList)
            {
                if(userid==user.UserId)
                {
                    che3=true;
                    System.Console.WriteLine("1.Borrow book\n2.BorrowHistory\n3.return books\n4.wallet recharge\n5.Exit");
                    CurrentLoginUser=user;
                    int check2;
                    bool choise1=int.TryParse(Console.ReadLine(),out check2);
                    while(!choise1)
                    {
                        System.Console.WriteLine("enter valid input");
                        System.Console.WriteLine("1.Borrow book\n2.BorrowHistory\n3.return books\n4.wallet recharge\n5.Exit");
                        choise1=int.TryParse(Console.ReadLine(),out check2);


                    }
                    
                    
                    switch (check2)
                    {
                        case 1:
                        {
                            System.Console.WriteLine("borrow book");
                            BorrowBook();
                            break;
                        }
                        case 2:
                        {
                            ShowBorrowHistry();
                            break;
                        }
                        case 3:
                        {
                            Return();
                            break;
                        }
                        case 4:
                        {
                            WalletRecharge();
                            break;
                        }
                        case 5:
                        {
                            che4=false;
                            break;
                        }
                    }
                    }


                }
            }while(!che3);
            if(!che3)
            {
                System.Console.WriteLine("invalid Input");
            }
            }while(che4);

        }
        public static void BorrowBook()
        {
            foreach(BookDetails book in BookList)
            {
                System.Console.WriteLine($"{book.BookName}  {book.AuthorName}  {book.BookId}  {book.BookCount}");
            }
            System.Console.WriteLine("enter your book id");
            bool che5=true;
            do{
            string bookid=Console.ReadLine().ToUpper();
            foreach(BookDetails book in BookList)
            {
                if(bookid==book.BookId)
                {
                    che5=false;
                    if(book.BookCount<=0)
                    {
                        System.Console.WriteLine("book is not available");

                    }
                    else{
                        System.Console.WriteLine("enter the count to be want");
                        int count=int.Parse(Console.ReadLine());
                        if(book.BookCount>=count)
                        {
                            che5=false;
                            System.Console.WriteLine("Borrowed");
                            BorrowDetails borrow=new BorrowDetails(book.BookId,CurrentLoginUser.UserId,count,0,DateTime.Now,Status.borrowed);
                            BorrowList.Add(borrow);
                            
                        }
                        else 
                        {
                            System.Console.WriteLine("book is not available");
                        }
                    }
                }
            }
            }while(!che5);
        }
        public static void ShowBorrowHistry()
        {

            foreach(BorrowDetails borrow in BorrowList)
            {
                System.Console.WriteLine($"{borrow.UserId}  {borrow.BookId}  {borrow.BorrowId}  {borrow.BorrowDate} {borrow.Status}");
            }
        }
        public static void WalletRecharge()
        {
            System.Console.WriteLine("enter the amount to be rechaege");
            double amount=double.Parse(Console.ReadLine());
            CurrentLoginUser.WalletBalance+=amount;
        }
        public static void Return()
        {
            foreach(BorrowDetails borrow in BorrowList)
            {
                
            }

        }



    }
}
