using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineCourseEnrollment;

public static class Operations
{
    public static List<UserDetails> userDetails = new List<UserDetails>();
    public static List<CourseDetails> courseDetails = new List<CourseDetails>();
    public static List<EnrollmentDetails> enrollmentDetails = new List<EnrollmentDetails>();

    public static UserDetails loggedIn;
    public static void MainMenu()
    {
        try
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("***********Main Menu*********8");
                System.Console.WriteLine("Select \n1.Registration \n2.Login \n3.Exit");
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
            Console.WriteLine("Enter your Name: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Gender");
            GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);

            Console.WriteLine("Enter your Qualification ");
            string qualification = Console.ReadLine();

            Console.WriteLine("Enter the Mobile Number");
            long phone = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter your EmailID: ");
            string emailID = Console.ReadLine();

            Console.WriteLine("Enter the Maths Mark");
            int mathsMark = int.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(userName, age, gender, qualification, phone, emailID);
            userDetails.Add(user);

            Console.WriteLine($"Registered Successfully and your ID is {user.RegistrationID}");
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
            int match = 0;
            Console.WriteLine("Enter your ID to login");
            string userCheck = Console.ReadLine();

            foreach (UserDetails user in userDetails)
            {
                if (user.RegistrationID == userCheck)
                {
                    match = 1;
                    loggedIn = user;
                    SubMenu();
                    break;
                }
            }

            if (match != 1)
            {
                Console.WriteLine("Invalid id try again");
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
                System.Console.WriteLine("*********SubMenu********");
                System.Console.WriteLine("Select \n1.Enroll Course \n2.View Enrollment History \n3.Next Enrollment \n4.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            EnrollCourse();
                            break;
                        }
                    case 2:
                        {
                            EnrollmentHistory();
                            break;
                        }

                    case 3:
                        {
                            NextEnrollment();
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


    public static void EnrollCourse()
    {
        try
        {
            System.Console.WriteLine("Enroll course");
            foreach (CourseDetails course in courseDetails)
            {
                System.Console.WriteLine($"{course.CourseID} {course.CourseName} {course.TrainerName} {course.CourseDuration} {course.SeatsAvailable}");

            }
            System.Console.WriteLine("Pick one course and enter its ID");
            string courseChoice = Console.ReadLine();
            bool available = false;
            CourseDetails courseData;
            foreach (CourseDetails course in courseDetails)
            {
                if (course.CourseID == courseChoice && course.SeatsAvailable > 0)
                {
                    available = true;
                    courseData = course;
                }
            }

            if (available)
            {
                int courseCount = 0;
                foreach (EnrollmentDetails enroll in enrollmentDetails)
                {
                    if (enroll.RegistrationID == loggedIn.RegistrationID)
                    {
                        courseCount++;
                    }
                }

                if (courseCount < 2)
                {
                    EnrollmentDetails enrollment = new EnrollmentDetails(courseChoice, loggedIn.RegistrationID, DateTime.Now);

                }
                else
                {
                    //1st find 
                    CourseDetails temp = new CourseDetails();
                    string[] coursesEnrolled = new string[2];
                    DateTime lastEnrollDate = new DateTime();
                    int i = 0, least = 1000;
                    foreach (EnrollmentDetails enroll in enrollmentDetails)
                    {
                        if (loggedIn.RegistrationID == enroll.RegistrationID)
                        {
                            coursesEnrolled[i++] = enroll.CourseID;
                            if (enroll.EnrollmentDate > lastEnrollDate)
                            {
                                lastEnrollDate = enroll.EnrollmentDate;
                            }
                        }
                    }

                    foreach (CourseDetails course in courseDetails)
                    {
                        if (course.CourseID == coursesEnrolled[0] || course.CourseID == coursesEnrolled[1])
                        {
                            if (course.CourseDuration < least)
                            {
                                temp = course;
                                least = course.CourseDuration;
                            }
                        }
                    }


                    foreach (EnrollmentDetails enroll in enrollmentDetails)
                    {
                        if (enroll.CourseID == temp.CourseID && loggedIn.RegistrationID == enroll.RegistrationID)

                        {
                            DateTime nextEnroll = lastEnrollDate.AddDays(temp.CourseDuration);
                            Console.WriteLine($"you can enroll on {nextEnroll.ToString("dd/MM/yyyy")}");
                            break;
                        }
                    }



                }
            }
            else
            {
                System.Console.WriteLine("No seat available");
            }

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }

    public static void EnrollmentHistory()
    {
        try
        {

            System.Console.WriteLine("Enrollment History");
            foreach (EnrollmentDetails enroll in enrollmentDetails)
            {
                if (loggedIn.RegistrationID == enroll.RegistrationID)
                {
                    System.Console.WriteLine($"{enroll.EnrollmentID}  {enroll.RegistrationID}  {enroll.CourseID}  {enroll.EnrollmentDate.ToString("dd/MM/yyyy", null)}");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
        }
    }

    public static void NextEnrollment()
    {
        try
        {
            System.Console.WriteLine("Next Enrollment");
            DateTime[] date1 = new DateTime[2];


            int count = 0;



            foreach (EnrollmentDetails enroll in enrollmentDetails)
            {
                if (loggedIn.RegistrationID == enroll.RegistrationID)
                {

                    date1[count] = enroll.EnrollmentDate;

                    count++;
                }
            }

            DateTime nextEnrollmentDate = date1[0];
            foreach (DateTime date in date1)
            {
                if (date < nextEnrollmentDate)
                {
                    nextEnrollmentDate = date;
                }
            }

            System.Console.WriteLine($"you can next enroll on {nextEnrollmentDate.ToString("dd/MM/yyyy",null)}");


        }
        catch (Exception ex)
        {
            // System.Console.WriteLine(ex.StackTrace);
        }
    }
    public static void DefaultValues()
    {
        UserDetails user1 = new UserDetails("Ravichandran", 30, GenderDetails.Male, "ME", 993838833, "ravi@gmail.com");
        UserDetails user2 = new UserDetails("Priyadharshini", 30, GenderDetails.Female, "BE", 9944444455, "priya@gmail.com");
        userDetails.Add(user1);
        userDetails.Add(user2);


        CourseDetails course1 = new CourseDetails("C#", "Baskaran", 5, 0);
        CourseDetails course2 = new CourseDetails("HTML", "Ravi", 2, 5);
        CourseDetails course3 = new CourseDetails("CSS", "Priyadharshini", 2, 3);
        CourseDetails course4 = new CourseDetails("JS", "Baskaran", 3, 1);
        CourseDetails course5 = new CourseDetails("TS", "Ravi", 1, 2);
        courseDetails.Add(course1);
        courseDetails.Add(course2);
        courseDetails.Add(course3);
        courseDetails.Add(course4);
        courseDetails.Add(course5);

        EnrollmentDetails enroll1 = new EnrollmentDetails("CS2001", "SYNC1001", DateTime.ParseExact("28/01/2024", "dd/MM/yyyy", null));
        EnrollmentDetails enroll2 = new EnrollmentDetails("CS2003", "SYNC1001", DateTime.ParseExact("15/02/2024", "dd/MM/yyyy", null));
        EnrollmentDetails enroll3 = new EnrollmentDetails("CS2004", "SYNC1002", DateTime.ParseExact("18/02/2024", "dd/MM/yyyy", null));
        EnrollmentDetails enroll4 = new EnrollmentDetails("CS2002", "SYNC1002", DateTime.ParseExact("20/02/2024", "dd/MM/yyyy", null));
        enrollmentDetails.Add(enroll1);
        enrollmentDetails.Add(enroll2);
        enrollmentDetails.Add(enroll3);
        enrollmentDetails.Add(enroll4);





    }
}
