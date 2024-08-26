using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnlineLibraryManagement;

public static class Operations
{
    public static List<UserDetails> userDetails = new List<UserDetails>();
    public static List<BookDetails> bookDetails = new List<BookDetails>();
    public static List<BorrowDetails> borrowDetails = new List<BorrowDetails>();
    public static UserDetails loggedIn;


    public static void MainMenu()
    {
        // 1.	UserRegistration
        // 2.	UserLogin
        // 3.	Exit

        try
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("********MainMenu********");
                System.Console.WriteLine("1.Register\n2.Login\n3.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Register();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            break;
                        }
                }

            } while (flag);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }



    }

    public static void Register()
    {
        try
        {
            System.Console.WriteLine("Register");
            System.Console.WriteLine("Enter your Name");
            string name = Console.ReadLine();

            System.Console.WriteLine("Enter you gender");
            GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);

            System.Console.WriteLine("Enter your Department Name");
            DepartmentDetails department = Enum.Parse<DepartmentDetails>(Console.ReadLine(), true);

            System.Console.WriteLine("Enter your Phome Number");
            long phone = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your Email ID");
            string emailID = Console.ReadLine();

            System.Console.WriteLine("Enter your wallet Balance");
            double walletBalance = double.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(name, gender, department, phone, emailID, walletBalance);
            userDetails.Add(user);

            System.Console.WriteLine($"Your User ID is {user.UserID}");

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }


    public static void Login()
    {
        try
        {
            System.Console.WriteLine("Login");
            System.Console.WriteLine("Enter the user id to login");
            string userCheck = Console.ReadLine();
            int match = 0;
            foreach (UserDetails user in userDetails)
            {
                if (userCheck == user.UserID)
                {
                    match = 1;
                    loggedIn = user;
                    SubMenu();
                    break;
                }
            }

            if (match != 1)
            {
                System.Console.WriteLine("Incorrect User ID try again");
            }

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }


    public static void SubMenu()
    {
        try
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("***********SUBMENU***********");
                System.Console.WriteLine("1.Borrowbook \n2.ShowBorrowedhistory \n3.ReturnBooks \n4.WalletRecharge \n5.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            BorrowBook();
                            break;
                        }
                    case 2:
                        {
                            ShowBorrowedBooks();
                            break;
                        }
                    case 3:
                        {
                            ReturnBooks();
                            break;
                        }
                    case 4:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 5:
                        {
                            flag = false;
                            break;
                        }
                }
            } while (flag);

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }


    public static void BorrowBook()
    {
        try
        {
            System.Console.WriteLine("Borrow Book");
            string bookChoice;
            int count;
            foreach (BookDetails book in bookDetails)
            {
                System.Console.WriteLine($"{book.BookID}  {book.BookName}  {book.AuthorName}  {book.BookCount}");
            }
            bookChoice = Console.ReadLine();
            int found = 0;
            foreach (BookDetails book in bookDetails)
            {
                if (bookChoice == book.BookID)
                {
                    found = 1;
                    System.Console.WriteLine("Enter The count of the book");
                    count = int.Parse(Console.ReadLine());
                    if (book.BookCount < count)
                    {
                        System.Console.WriteLine("Books are not available for the selected count");
                        DateTime available = DateTime.MaxValue;
                        foreach (BorrowDetails borrow in borrowDetails)
                        {
                            if (borrow.BookID == bookChoice && borrow.Status == StatusDetails.Borrowed)
                            {
                                if (available > borrow.BorrowedDate)
                                {
                                    available = borrow.BorrowedDate;
                                }
                            }
                        }
                        Console.WriteLine($"The book will be available on {available.AddDays(15).ToString("dd/MM/yyyy", null)}");

                    }

                    else if (book.BookCount >= count)
                    {
                        int totalBorrowedCount = 0;
                        foreach (BorrowDetails borrow in borrowDetails)
                        {
                            totalBorrowedCount += borrow.BorrowBookCount;
                        }

                        if (totalBorrowedCount >= 3)
                        {
                            System.Console.WriteLine("You have borrowed 3 books already");
                        }
                        else if ((totalBorrowedCount + count) >= 3)
                        {
                            System.Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {totalBorrowedCount} and requested count is {count}, which exceeds 3 ");
                        }
                        else
                        {
                            BorrowDetails borrow1 = new BorrowDetails(bookChoice, loggedIn.UserID, DateTime.Now, count, StatusDetails.Borrowed, 0);
                            System.Console.WriteLine($"Book borrowed successfully {borrow1.BorrowID}");
                            book.BookCount -= count;

                        }

                    }
                    else
                    {

                    }
                    break;
                }
            }

            if (found == 0)
            {
                System.Console.WriteLine("Invalid Book ID, Please enter valid ID");
            }
            // else
            // {
            //     System.Console.WriteLine("Enter The count of the book");
            //     count = int.Parse(Console.ReadLine());
            // }





        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }

    public static void ShowBorrowedBooks()
    {
        try
        {
            System.Console.WriteLine("Show Borrowed Books");
            foreach (BorrowDetails borrow in borrowDetails)
            {
                if (loggedIn.UserID == borrow.UserID)
                {
                    System.Console.WriteLine($"{borrow.UserID} {borrow.BookID} {borrow.BorrowedDate} {borrow.BorrowBookCount} {borrow.Status} {borrow.PaidFineAmount}");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }


    public static void ReturnBooks()
    {

        try
        {
            System.Console.WriteLine("Return Books");
            int daysCount = 0;
            BorrowDetails borrowed;
            foreach (BorrowDetails borrow in borrowDetails)
            {
                if (loggedIn.UserID == borrow.UserID && borrow.Status == StatusDetails.Borrowed)
                {
                    System.Console.WriteLine($"{borrow.BookID} {borrow.BorrowedDate} {borrow.BorrowBookCount}  Your Return date is {borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy", null)}");

                    DateTime returnDate1 = borrow.BorrowedDate.AddDays(15);
                    DateTime nowDate = DateTime.Now;
                    TimeSpan t = nowDate - returnDate1;
                    daysCount += t.Days;
                    borrowed = borrow;
                    if (daysCount > 15)
                    {
                        int fine = daysCount;
                        System.Console.WriteLine("Select The borrowed id");
                        string borrowID = Console.ReadLine();
                        if (loggedIn.WalletBalance >= daysCount)
                        {
                            loggedIn.DeductBalance(fine);
                            borrow.PaidFineAmount += fine;
                            borrow.BorrowBookCount = 0;
                            borrow.Status = StatusDetails.Returned;
                            System.Console.WriteLine("Book returned successfully");


                        }
                        else
                        {
                            System.Console.WriteLine("Insufficientbalance. Please rechange and proceed");

                        }

                    }
                    else
                    {
                        borrow.Status = StatusDetails.Returned;
                        System.Console.WriteLine("Book returned successfully");
                        borrow.BorrowBookCount = 0;
                    }

                    break;
                }
            }


        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }

    public static void WalletRecharge()
    {
        try
        {
            System.Console.WriteLine("Wallet Recharge");
            System.Console.WriteLine("Do you want to recharge wallet? yes or no");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "yes")
            {
                System.Console.WriteLine("Enter the amount to recharge");
                double amount = double.Parse(Console.ReadLine());
                loggedIn.WalletRecharge(amount);
                System.Console.WriteLine("Amount Recharged successfully");
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }
    public static void DefaultValues()
    {
        UserDetails user1 = new UserDetails("Ravichandran", GenderDetails.Male, DepartmentDetails.EEE, 9938388333, "ravi@gmail.com", 100);
        UserDetails user2 = new UserDetails("Priyadharshini", GenderDetails.Female, DepartmentDetails.CSE, 994444455, "priya@gmail.com", 100);
        userDetails.Add(user1);
        userDetails.Add(user2);


        BookDetails book1 = new BookDetails("C#", "Author1", 3);
        BookDetails book2 = new BookDetails("HTML", "Author2", 3);
        BookDetails book3 = new BookDetails("CSS", "Author1", 3);
        BookDetails book4 = new BookDetails("JS", "Author1", 3);
        BookDetails book5 = new BookDetails("TS", "Author2", 2);
        bookDetails.Add(book1);
        bookDetails.Add(book2);
        bookDetails.Add(book3);
        bookDetails.Add(book4);
        bookDetails.Add(book5);


        BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", DateTime.ParseExact("10/09/2023", "dd/MM/yyyy", null), 2, StatusDetails.Borrowed, 0);
        BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", DateTime.ParseExact("12/09/2023", "dd/MM/yyyy", null), 1, StatusDetails.Borrowed, 0);
        BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", DateTime.ParseExact("14/09/2023", "dd/MM/yyyy", null), 1, StatusDetails.Returned, 3);
        BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", DateTime.ParseExact("11/09/2023", "dd/MM/yyyy", null), 2, StatusDetails.Borrowed, 0);
        BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", DateTime.ParseExact("09/09/2023", "dd/MM/yyyy", null), 1, StatusDetails.Returned, 3);
        borrowDetails.Add(borrow1);
        borrowDetails.Add(borrow2);
        borrowDetails.Add(borrow3);
        borrowDetails.Add(borrow4);
        borrowDetails.Add(borrow5);




    }
}
