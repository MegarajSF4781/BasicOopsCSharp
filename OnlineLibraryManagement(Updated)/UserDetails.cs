using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    /// <summary>
    /// BookDetails class used to create an instance of <see cref="UserDetails"/>
    /// For More details check <see href="www.syncfusion.com"/>
    /// </summary>

    public class UserDetails
    {
        //         a.	UserID (Auto Increment – SF3000)
        // b.	UserName
        // c.	Gender
        // d.	Department – (Enum – ECE, EEE, CSE)
        // e.	MobileNumber
        // f.	MailID

        /// <summary>
        /// s_userID Static property used to create ID with BorrowID of instance <see cref="BorrowDetails"/>
        /// </summary>
        private static int s_userID = 3000;
        public string UserID { get; set; }
        public string UserName { get; set; }
        public GenderDetails Gender { get; set; }
        public DepartmentDetails Department { get; set; }
        public long Phone { get; set; }
        public string EmailID { get; set; }
        private double _walletBalance = 0;
        public double WalletBalance { get { return _walletBalance; } }

        public UserDetails(string userName, GenderDetails gender, DepartmentDetails department, long phone, string emailID, double walletBalance)
        {
            s_userID++;
            UserID = "SF" + s_userID;
            UserName = userName;
            Gender = gender;
            Department = department;
            Phone = phone;
            EmailID = emailID;
            _walletBalance = walletBalance;

        }

        public void WalletRecharge(double amount)
        {
            _walletBalance += amount;
        }

        public void DeductBalance(double amount)
        {
            _walletBalance -= amount;
        }



    }
}