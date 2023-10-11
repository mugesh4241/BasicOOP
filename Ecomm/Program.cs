using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileHandling.Create();
            Operation.DefaultData();
            Operation.MainMenu();
            //FileHandling.WriteToCSV();
        }
    }
}