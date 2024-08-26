using System;
namespace StudentAdmission;

public class AdmissionDetails
{
    private static int s_admissionID = 1000;
    public string AdmissionID {get;}
    public string StudentID {get; set;}
    public string DepartmentID {get; set;}
    public DateTime AdmissionDate {get; set;}
    public AdmissionStatus Status {get; set;}



    public AdmissionDetails(string studentID , string departmentID , DateTime admissionDate,AdmissionStatus status)
    {
        s_admissionID++;
        AdmissionID = "AID" + s_admissionID;
        StudentID = studentID;
        DepartmentID = departmentID;
        AdmissionDate = admissionDate;
        Status = status;
    }


    
}
