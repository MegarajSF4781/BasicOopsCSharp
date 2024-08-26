using System;
using System.Collections.Generic;
using Assembly;
namespace Application;

class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employeeList = new List<Employee>();
        int flag = 1;

        while (flag == 1)
        {
            Console.WriteLine("1.Registration \n2.Login \n3.Exit");
            int choice1 = int.Parse(Console.ReadLine());
            if (choice1 == 1)
            {
                string employeeName,role,teamName;
                WorkLocation location ;

                Console.WriteLine("Enter your details:-");
                Console.WriteLine("Enter your Name");
                employeeName = Console.ReadLine();
                Console.WriteLine("Enter your Role");
                role = Console.ReadLine();
                Console.WriteLine("Enter your WorkLocation:");
                location = Enum.Parse<WorkLocation>(Console.ReadLine(), true);
                Console.WriteLine("Enter your Team Name");
                teamName = Console.ReadLine();
                Console.WriteLine("Enter your DOJ");
                DateTime doj = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.WriteLine("Enter your Gender:");
                GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
                Console.WriteLine("Enter your Phone");
               
                Employee employee = new Employee(employeeName,role,location,teamName,doj,gender);
                Console.WriteLine("Your Employee Id is:");
                Console.WriteLine(employee.EmployeeId);

                employeeList.Add(employee);
            }
            if (choice1 == 2)
            {
                int match = 0;
                Employee loggedin = new Employee();
                do
                {
                    string employeeCheck;
                    Console.WriteLine("Enter your EMployee Id:");
                    employeeCheck = Console.ReadLine();


                    foreach (Employee i in employeeList)
                    {
                        if (i.EmployeeId == employeeCheck)
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
                    Console.WriteLine("1.CAlculate Salary  \n2.Display details \n3.Exit");
                    choice2 = int.Parse(Console.ReadLine());
                    switch (choice2)
                    {
                        case 1:
                            {

                                Console.WriteLine("Enter the Number of working days this month");
                                int noOfWorkingDays = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the Number of Leave taken this month");
                                int noOfLeaveTaken = int.Parse(Console.ReadLine());
                                loggedin.SalaryCalculation(noOfWorkingDays,noOfLeaveTaken);
                                Console.WriteLine("The Salary amount is {0}",loggedin.Salary);
                                Console.WriteLine();
                                break;
                            }

                        case 2:
                            {
                                Console.WriteLine("Employee ID : "+loggedin.EmployeeId);
                                Console.WriteLine("Employee Name : "+loggedin.EmployeeName);
                                Console.WriteLine("Employee Role : "+loggedin.Role);
                                Console.WriteLine("Employee Team Name : "+loggedin.TeamName);
                                Console.WriteLine("Employee DOJ :"+loggedin.DOJ.ToString("dd/MM/yyyy"));
                                Console.WriteLine("Employee Gender : "+loggedin.Gender);
                                break;
                            }

                


                    }
                
                } while (choice2 != 3) ;
        }
        if (choice1 == 3)
        {
            break;
        }
    }
}
}