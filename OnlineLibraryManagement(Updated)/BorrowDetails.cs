using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    /// <summary>
    /// BorrowDetails class used to create an instance of <see cref="BookDetails"/>
    /// For More details check <see href="www.syncfusion.com"/>
    /// </summary>
    public class BorrowDetails
    {
        /// <summary>
        /// s_borrowID Static property used to create ID with BorrowID of instance <see cref="BorrowDetails"/>
        /// </summary>
        private static int s_borrowID = 1000;
        public string BorrowID { get; set; }

        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BorrowBookCount { get; set; }
        public StatusDetails Status { get; set; }
        public double PaidFineAmount { get; set; }


        public BorrowDetails(string bookID, string userID, DateTime borrowedDate, int borrowBookCount, StatusDetails status, double paidFineAmount)
        {
            s_borrowID++;
            BorrowID = "LB" + s_borrowID;
            BookID = bookID;
            UserID = userID;
            BorrowedDate = borrowedDate;
            BorrowBookCount = borrowBookCount;
            Status = status;
            PaidFineAmount = paidFineAmount;

        }
    }
}