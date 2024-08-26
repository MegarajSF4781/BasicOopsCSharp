using System;

namespace StudentAdmission;


/// <summary>
/// Class StudentDetails used to create an instance for student 
/// Refer Documentation on <see href="www.syncfusion.com"/>
/// </summary>
public class StudentDetails
{


    /// <summary>
    /// Static Field s_studentID used to auto increment StudentID of the instance of <see cref="StudentDetails"/>
    /// </summary>
   
    private static int s_studentID = 3000;
    /// <summary>
    /// StudentID property used to hold a student's ID of instance of <see cref="StudentDetails"/>
    /// </summary>
    /// <value></value>
    public string StudentID { get; }
    public string StudentName { get; set; }
    public string FatherName { get; set; }
    public DateTime DOB { get; set; }
    public GenderDetails Gender { get; set; }
    public int PhysicsMarks { get; set; }
    public int MathsMarks { get; set; }
    public int ChemistryMarks { get; set; }

    public StudentDetails(string name, string fatherName, DateTime dob,GenderDetails gender, int physicsMark, int chemistryMark, int mathsMark)
    {
        s_studentID++;
        StudentID = "SF" + s_studentID;
        StudentName = name;
        FatherName = fatherName;
        DOB = dob;
        Gender = gender;
        PhysicsMarks = physicsMark;
        ChemistryMarks = chemistryMark;
        MathsMarks =  mathsMark;

        

    }

    public StudentDetails()
    {

    }


    public int TotalMarks()
    {
        return PhysicsMarks + ChemistryMarks + MathsMarks;
    }

    public void ShowDetails()
    {
        Console.WriteLine("Student ID: "+StudentID);
        Console.WriteLine("Student Name: "+StudentName);
        Console.WriteLine("Father's Name: "+FatherName);
        Console.WriteLine("Date Of Birth: "+DOB.ToString("dd/MM/yyyy"));
        Console.WriteLine("Gender: "+Gender);
        Console.WriteLine("Physics Mark: "+PhysicsMarks);
        Console.WriteLine("Chemistry Mark: "+ChemistryMarks);
        Console.WriteLine("Maths Mark: "+MathsMarks);
    }

    /// <summary>
    /// method Average used to calculate average mark score of instance of <see cref="StudentDetails"/>
    /// </summary>
    /// <returns>Returns average in double dataType </returns>
    public double Average()
    {
        return (double)TotalMarks() / 3;
    }

    /// <summary>
    /// Method IsEligible used to check whether the instance of <see cref="StudentDetails"/>
    /// is eligible for admission based on cutoff
    /// </summary>
    /// <returns>Returns true is eligible, else false</returns>
    public bool IsEligible()
    {
        if (Average() >= 75)
        {
            return true;
        }
        return false;
    }
}
