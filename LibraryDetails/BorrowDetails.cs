using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDetails
{
    public enum Status{Default,borrowed,returned}
    public class BorrowDetails
    {
        private static int s_id=300;
        private static string _borrowid;
        public string BorrowId { get
        {
            return _borrowid;
        }}
        public string BookId { get; set; }
        public string UserId { get; set; }
        public Status Status { get; set; }
        
        public int BorrowBookCount { get; set; }
        public double PaidFineAmount{ get; set; }
        public DateTime BorrowDate { get; set; }
        public BorrowDetails(string bookid,string userid,int borrowBookCount,double paidFineAmount,DateTime borrowDate,Status status)
        {
            s_id++;
            _borrowid="LB"+s_id;
            BookId=bookid;
            UserId=userid;
            BorrowDate=borrowDate;
            BorrowBookCount=borrowBookCount;
            PaidFineAmount=paidFineAmount;
            Status =status;
        }
    }
}