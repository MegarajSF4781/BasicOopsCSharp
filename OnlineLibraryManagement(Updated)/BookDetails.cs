using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    /// <summary>
    /// BookDetails class used to create an instance of <see cref="BookDetails"/>
    /// For More details check <see href="www.syncfusion.com"/>
    /// </summary>
    public class BookDetails
    {
        /// <summary>
        /// s_bookID Static property used to create ID with BorrowID of instance <see cref="BookDetails"/>
        /// </summary>
        private static int s_bookID = 1000;
        /// <summary>
        /// BookID property used to create unique ID for instance of <see cref="BookDetails"/>
        /// </summary>
        /// <value>For Example (BID1001)</value>
        public string BookID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }


        public BookDetails(string bookName, string authorName, int bookCount)
        {
            s_bookID++;
            BookID = "BID" + s_bookID;
            BookName = bookName;
            AuthorName = authorName;
            BookCount = bookCount;
        }


    }
}