using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalDetails
{
    public class MedicineDetails
    {
       
        public string MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int AvailableCount { get; set; }
        public int Price { get; set; }
        public DateTime DOE { get; set; }
        public MedicineDetails(string medicineId,string medicineName,int availableCount,int price,DateTime doe)
        {
            MedicineId=medicineId;
            MedicineName=medicineName;
            AvailableCount=availableCount;
            Price=price;
            DOE=doe;
        }
    }
}