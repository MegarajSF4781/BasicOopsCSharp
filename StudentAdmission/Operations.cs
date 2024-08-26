using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission;

public static class Operations
{
    public static List<StudentDetails> studentDetails = new List<StudentDetails>();
    public static List<DepartmentDetails> departmentDetails = new List<DepartmentDetails>();
    public static List<AdmissionDetails> admissionDetails = new List<AdmissionDetails>();
    public static StudentDetails loggedIn;

    public static void MainMenu()
    {
        try
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("***********Main Menu*********8");
                System.Console.WriteLine("Select \n1.Registration \n2.Login \n3.Show Department wise seats availability \n4.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }

                    case 2:
                        {
                            Login();
                            break;
                        }

                    case 3:
                        {
                            System.Console.WriteLine("Show seats availability");
                            break;
                        }
                    case 4:
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

    public static void Registration()
    {
        try
        {
            // b.StudentName
            // c.FatherName
            // d.DOB
            // e.Gender – Enum(Male, Female, Transgender)
            // f.Physics
            // g.Chemistry
            // h.Maths

            Console.WriteLine("Enter the student Name: ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter Father's Name: ");
            string fatherName = Console.ReadLine();

            Console.WriteLine("Enter the DOB");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.WriteLine("Enter the Gender");
            GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);

            Console.WriteLine("Enter the Physics Mark");
            int physicsMark = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Chemistry Mark");
            int chemistryMark = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Maths Mark");
            int mathsMark = int.Parse(Console.ReadLine());

            StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);
            studentDetails.Add(student);

            Console.WriteLine("Student Registered Successfully and Student ID is " + student.StudentID);
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
            int match = 0;


            string studentCheck;
            Console.WriteLine("Enter your Student Id:");
            studentCheck = Console.ReadLine();


            foreach (StudentDetails i in studentDetails)
            {
                if (i.StudentID == studentCheck)
                {
                    match = 1;
                    loggedIn = i;
                    Submenu();
                    break;
                }
            }
            if (match != 1)
            {
                Console.WriteLine("Invalid id Try Again");
            }

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }



    public static void Submenu()
    {
        try
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("**********SUBMENU***********");
                Console.WriteLine("1. Check Eligibility \n2. Show Details \n3. Take Admission \n4. Cancel Admission \n5.SHow Admission Details \n6.Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            ShowDetails();
                            break;
                        }

                    case 3:
                        {
                            TakeAdmission();
                            break;
                        }


                    case 4:
                        {
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            ShowAdmissionDetails();
                            break;
                        }
                    case 6:
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

    public static void CheckEligibility()
    {
        try
        {
            System.Console.WriteLine("Eligibility");
            if (loggedIn.IsEligible())
            {
                Console.WriteLine("Student is Eligible");
            }
            else
            {
                Console.WriteLine("Student is no eligible");
            }


        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }

    public static void ShowDetails()
    {
        try
        {
            System.Console.WriteLine("Show Details");
            System.Console.WriteLine($"{loggedIn.StudentID}  {loggedIn.FatherName} {loggedIn.DOB.ToString("dd/MM/yyyy")} {loggedIn.Gender}  Physics MArks: {loggedIn.PhysicsMarks} ChemMark{loggedIn.ChemistryMarks}  Mathsmark {loggedIn.MathsMarks} ");

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }


    public static void TakeAdmission()
    {
        try
        {
            System.Console.WriteLine("Take Admission");
            foreach (DepartmentDetails i in departmentDetails)
            {
                Console.WriteLine($"{i.DepartmentID}    {i.DepartmentName}    {i.NumberOfSeats}");
            }

            Console.WriteLine();
            Console.WriteLine("Choose the department to continue");
            string departmentChoice = Console.ReadLine();
            DepartmentDetails temp = new DepartmentDetails();
            int right = 0;
            foreach (DepartmentDetails i in departmentDetails)
            {
                if (departmentChoice == i.DepartmentID)
                {
                    right = 1;
                    temp = i;
                }
            }

            if (right == 1 && loggedIn.IsEligible())
            {

                int newCandidate = 1;
                foreach (AdmissionDetails i in admissionDetails)
                {
                    if (i.StudentID == loggedIn.StudentID && i.Status==AdmissionStatus.Admitted)
                    {
                        Console.WriteLine("You have already applied before");
                        newCandidate = 0;
                        break;
                    }
                }

                if (newCandidate == 1)
                {
                    if (temp.NumberOfSeats > 0)
                    {
                        DateTime admissionDate = DateTime.Now;
                        AdmissionStatus status = AdmissionStatus.Admitted;
                        AdmissionDetails admission = new AdmissionDetails(loggedIn.StudentID, departmentChoice, admissionDate, status);
                        admissionDetails.Add(admission);
                        Console.WriteLine("Admission took successfully. Your admission ID-{0}", admission.AdmissionID);
                        temp.NumberOfSeats -= 1;
                    }
                    else
                    {
                        Console.WriteLine("No Seats Available");
                    }
                }



            }

           
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }

    public static void CancelAdmission()
    {
        try
        {
            System.Console.WriteLine("Cancel Admission");
            DepartmentDetails dept = new DepartmentDetails();
            int checkCancelled=0;
            foreach (AdmissionDetails i in admissionDetails)
            {
                if (loggedIn.StudentID == i.StudentID && i.Status!=AdmissionStatus.Cancelled)
                {
                    Console.WriteLine("Student {0}'s Application has been Cancelled", loggedIn.StudentID);
                    i.Status = AdmissionStatus.Cancelled;
                    checkCancelled = 1;
                    foreach (DepartmentDetails j in departmentDetails)
                    {
                        if (i.DepartmentID == j.DepartmentID)
                        {
                            j.NumberOfSeats += 1;
                        }
                    }
                    break;
                }
                
            }
            if(checkCancelled!=1)
            {
                Console.WriteLine("Try again");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }

    public static void ShowAdmissionDetails()
    {
        try
        {
            System.Console.WriteLine("SHow Admission Details");
            foreach(AdmissionDetails admission in admissionDetails)
            {
                if(loggedIn.StudentID == admission.StudentID)
                {
                    System.Console.WriteLine($"{admission.AdmissionID} {admission.StudentID} {admission.DepartmentID} {admission.AdmissionDate}  {admission.Status}");
                }
            }
            
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }

    public static void DefaultValues()
    {
        StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), GenderDetails.Male, 95, 95, 95);
        StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), GenderDetails.Male, 95, 95, 95);
        studentDetails.Add(student1);
        studentDetails.Add(student2);


        DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
        DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
        DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
        DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
        departmentDetails.Add(department1);
        departmentDetails.Add(department2);
        departmentDetails.Add(department3);
        departmentDetails.Add(department4);



        AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", DateTime.ParseExact("11/05/2022", "dd/MM/yyyy", null), AdmissionStatus.Admitted);
        AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", DateTime.ParseExact("12/05/2022", "dd/MM/yyyy", null), AdmissionStatus.Admitted);
        admissionDetails.Add(admission1);
        admissionDetails.Add(admission2);

    }





}


