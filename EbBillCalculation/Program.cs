using System;
using System.Collections.Generic;

namespace EbBillCalculation;

class Program
{
    public static void Main(string[] args)
    {
        List<EbBill> ebBillList = new List<EbBill>();
        int flag = 1;

        while (flag == 1)
        {
            Console.WriteLine("1.Registration\n 2.Login \n 3.Exit");
            int choice1 = int.Parse(Console.ReadLine());
            if (choice1 == 1)
            {
                string userName, phone, emailId;
                Console.WriteLine("Enter your details:-");
                Console.WriteLine("Enter your UserName");
                userName = Console.ReadLine();
                Console.WriteLine("Enter your Phone");
                phone = Console.ReadLine();
                Console.WriteLine("Enter your Email id");
                emailId = Console.ReadLine();

                EbBill ebBill = new EbBill(userName, phone, emailId);
                Console.WriteLine("Your Meter Id is:");
                Console.WriteLine(ebBill.MeterId);

                ebBillList.Add(ebBill);
            }
            if (choice1 == 2)
            {
                int match = 0;
                EbBill loggedin = new EbBill();
                do
                {
                    string meterCheck;
                    Console.WriteLine("Enter your Meter Id:");
                    meterCheck = Console.ReadLine();


                    foreach (EbBill i in ebBillList)
                    {
                        if (i.MeterId == meterCheck)
                        {
                            match = 1;
                            loggedin = i;
                            break;
                        }
                    }
                    if (match != 1)
                    {
                        Console.WriteLine("Invalid id Try Again");
                    }

                } while (match == 0);
                int choice2;
                do
                {
                    Console.WriteLine("1.Calculate Amount \n 2.User Details \n 3.Exit");
                    choice2 = int.Parse(Console.ReadLine());
                    switch (choice2)
                    {
                        case 1:
                            {

                                Console.WriteLine("Enter Consumed units:");
                                loggedin.Units = int.Parse(Console.ReadLine());

                                Console.WriteLine("The Bill amount for MeterId {0} is: {1}", loggedin.MeterId, loggedin.CalculateAmount());
                                Console.WriteLine();
                                break;
                            }

                        case 2:
                            {
                                Console.WriteLine("Meter ID:{0}", loggedin.MeterId);
                                Console.WriteLine("UserName:{0}", loggedin.UserName);
                                Console.WriteLine("Phone Number:{0}", loggedin.PhoneNumber);
                                Console.WriteLine("Email Id:{0}", loggedin.EmailId);
                                Console.WriteLine();
                                break;

                            }
                    }
                } while (choice2 != 3);
            }
            if (choice1 == 3)
            {
                break;
            }
        }
    }
}