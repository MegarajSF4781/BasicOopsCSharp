using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseEnrollment;

public class EnrollmentDetails
{
    // •	EnrollmentID (Auto Incremented – EMT3001)
    // •	CourseID 
    // •	RegistrationID
    // •	EnrollmentDate

    /// <summary>
    /// Static Field s_enrollmentID used to auto increment Enrollment ID of the instance of <see cref="EnrollmentDetails"/>
    /// </summary>
    private static int s_enrollmentID = 3000;
    /// <summary>
    /// Enrollment ID property used to hold a Enrollment's ID of instance of <see cref="EnrollmentDetails"/> 
    /// </summary>
    public string EnrollmentID { get; }
    /// <summary>
    /// Course ID property used to hold a Course's ID of instance of <see cref="EnrollmentDetails"/> 
    /// </summary>
    public string CourseID { get; set; }
    /// <summary>
    /// Registration ID property used to hold a Registration's ID of instance of <see cref="EnrollmentDetails"/> 
    /// </summary>
    public string RegistrationID { get; set; }
    /// <summary>
    /// EnrollmentDate property used to hold EnrollmentDate of instance of <see cref="EnrollmentDetails"/>
    /// </summary>
    /// <value>Format DD/MM/yyyy</value>
    public DateTime EnrollmentDate { get; set; }

    /// <summary>
    /// Constructor EnrollmentDetails used to initialize parametrized properties
    /// </summary>
    /// <param name="courseID">courseID parameter used to assign its value</param>
    /// <param name="registrationID">registrationID parameter used to assign its value</param>
    /// <param name="enrollmentDate"> enrollmentDate parameter used to assign its value</param> 
    /// <param name="courseID">courseID parameter used to assign its value</param>
    /// <param name="registrationID">registrationID parameter used to assign its value</param>
    /// <param name="enrollmentDate">enrollmentDate parameter used to assign its value</param>
    public EnrollmentDetails(string courseID, string registrationID, DateTime enrollmentDate)
    {
        s_enrollmentID++;
        EnrollmentID = "EMT" + s_enrollmentID;
        CourseID = courseID;
        RegistrationID = registrationID;
        EnrollmentDate = enrollmentDate;
    }

}
