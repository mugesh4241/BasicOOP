using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace MedicalDetails
{
    class Program 
    {
        static List<MedicalDetails> MedicalList=new List<MedicalDetails>();
        static List<MedicineDetails> MedicineList=new List<MedicineDetails>();
        static MedicalDetails currentCus;
       public static void Main(string [] args)
        {
            MedicalDetails custemer1=new MedicalDetails(849998859,"ravi",33,"theni",400);
            MedicalDetails custemer2=new MedicalDetails(4803093932,"basker",33,"chennai",500);
            MedicalList.Add(custemer1);
            MedicalList.Add(custemer2);
            do{
            Console.WriteLine("1.Registration\n2.Login\n3.exit");
            int check=int.Parse(Console.ReadLine());
            switch(check)
            {
                case 1:
                {
                    
                    System.Console.WriteLine("enter the user name:");
                    string userName=Console.ReadLine();
                    System.Console.WriteLine("Enter the mobile number");
                    long mobileNumber=long.Parse(Console.ReadLine());
                    System.Console.WriteLine("enter the age:");
                    int age=int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Enter the city:");
                    string city=Console.ReadLine();
                    System.Console.WriteLine("enter the balance:");
                    double balance =double.Parse(Console.ReadLine());
                    MedicalDetails Medical=new MedicalDetails(mobileNumber,userName,age,city,balance);
                    MedicalList.Add(Medical);
                    System.Console.WriteLine(Medical.UserId);
                    break;
                }
                case 2:
                {
                    
                    MedicineDetails Medicine1=new MedicineDetails("MD100","paracitamal",40,5,new DateTime(30/06/2023));
                    MedicineDetails Medicine2=new MedicineDetails("MD101","calpol",10,5,new DateTime(30/05/2023));
                    MedicineDetails Medicine3=new MedicineDetails("MD102","Gelucil",3,40,new DateTime(30/04/2023));
                    MedicineDetails Medicine4=new MedicineDetails("MD103","Metrogel",5,50,new DateTime(30/12/2023));
                    MedicineDetails Medicine5=new MedicineDetails("MD104","Povindin lodin",10,50,new DateTime(30/10/2023));

                    MedicineList.Add(Medicine1);
                    MedicineList.Add(Medicine2);
                    MedicineList.Add(Medicine3);
                    MedicineList.Add(Medicine4);
                    MedicineList.Add(Medicine5);                    
                    int index=0;
                    System.Console.WriteLine("Please Enter the user Id:");
                    string userId=(Console.ReadLine());
                    

                    foreach(MedicalDetails i in MedicalList)
                    {
                        
                        
                        if (userId.Equals(i.UserId))
                        {
                            break;
                        }
                        else{
                            index++;
                        }

                    }
                    foreach(MedicalDetails i in MedicalList)
                    {
                        if (userId.Equals(i.UserId))
                        {
                            System.Console.WriteLine("1.Show medicine List\n2.purchase medicine\n3.cancel purchase \n4.purchase history\n5.recharse\n6.wallat Balance\n6.exit");
                            int check1=int.Parse(Console.ReadLine());
                            currentCus =i;

                            switch(check1)
                            {
                                case 1:
                                {
                                    foreach(MedicineDetails j in MedicineList)
                                    {
                                        System.Console.WriteLine($"{j.MedicineName} {j.Price} {j.DOE} {j.MedicineId} {j.AvailableCount}");

                                    }
                                    break;
                                }
                                case 2:
                                {
                                    foreach(MedicineDetails k in MedicineList)
                                    {
                                        System.Console.WriteLine($"{k.MedicineName} {k.Price} {k.DOE} {k.MedicineId} {k.AvailableCount}");
                                        
                                        
                                    }
                                    PurchaseDetails();
                                    break;
                                }
                                case 3:
                                {
                                    Cancel();
                                    break;

                                }
                                case 4:
                                {

                                    break;
                                }
                            }

                        }
                    }



                    break;
                }
            }
            
        }while(true);
        
    }
    public static void PurchaseDetails()
    {
        System.Console.WriteLine("enter Mechine Id");
        string mechineid=Console.ReadLine();
        System.Console.WriteLine("number medichine you want");
        int count=int.Parse(Console.ReadLine());
        foreach(MedicineDetails medicine in MedicineList)
        {
            if(mechineid==medicine.MedicineId)
            {
                if(medicine.AvailableCount<count)
                {
                    System.Console.WriteLine("not available");
                }
                else{
                    if(currentCus.Balance>medicine.Price)
                    {
                        currentCus.Balance-=medicine.Price;
                        System.Console.WriteLine("oeder success\n"+currentCus.Balance+"this your balance");
                    }

                }
            }
        }
    }
    public  static void Cancel()
    {
        System.Console.WriteLine("enter the medicine id to cancel");
        string mechineid=Console.ReadLine();
        System.Console.WriteLine("how many medisine to br return:");
        int return1=int.Parse(Console.ReadLine());
        foreach(MedicineDetails medicine in MedicineList)
        {
            if(mechineid==medicine.MedicineId)
            {
                System.Console.WriteLine("your order order cancelld");
                currentCus.Balance+=medicine.Price;
                medicine.AvailableCount+=return1;
            }
        }

    }
}
}
