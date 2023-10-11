using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDetails
{
    public class BookDetails
    {
        private static int s_id=100;
        private static string _bookid;
        public string BookId { get{
            return _bookid;
        } }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }
        public BookDetails(string bookid,string bookName,string authorName,int bookCount)
        {
            s_id++;
            _bookid ="BID"+s_id;
            BookCount=bookCount;
            BookName=bookName;
            AuthorName =authorName;
        }

    }
}