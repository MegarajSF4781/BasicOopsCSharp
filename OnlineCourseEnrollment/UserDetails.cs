using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseEnrollment;

public class UserDetails
{
    // a.RegistrationID(Auto Incremented – SYNC1001)
    // b.UserName
    // c.Age
    // d.Gender – (Enum – Male, Female, Transgender )
    // e.Qualification
    // f.MobileNumber
    // g.MailID


    /// <summary>
    /// Static Field s_registrationID used to auto increment RegistrationID of the instance of <see cref="UserDetails"/>
    /// </summary>
    private static int s_registrationID = 1000;

    /// <summary>
    ///  RegistrationID property used to hold a user's ID of instance of <see cref="UserDetails"/> 
    /// </summary>
    public string RegistrationID { get; }

    /// <summary>
    /// UserName Property ised to hold Name of a instance of <see cref="UserDetails"/>
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Age property used to hold Age of instance of <see cref="UserDetails"/>
    /// </summary>
    /// <value>0 to 100</value>
    public int Age { get; set; }
    /// <summary>
    /// Gender property used to hold Age of instance of <see cref="UserDetails"/>
    /// 
    /// </summary>
    /// <value>MAle,Female,Transgender</value>
    public GenderDetails Gender { get; set; }
    /// <summary>
    /// Qualification property used to hold a user's Qualification of instance of <see cref="UserDetails"/> 
    /// </summary>
    public string Qualification { get; set; }

    /// <summary>
    /// MobileNumber property used to hold a user's MobileNumber of instance of <see cref="UserDetails"/> 
    /// </summary>
    public long MobileNumber { get; set; }

    /// <summary>
    /// EmailID property used to hold a user's ID of instance of <see cref="UserDetails"/> 
    /// </summary>
    public string EmailID { get; set; }

    /// <summary>
    /// Constructor UserDetails used to initialize parametrized properties
    /// </summary>
    /// <param name="userName">userName parameter used to assign its value</param>
    /// <param name="age">age parameter used to assign its value</param>
    /// <param name="gender">gender parameter used to assign its value</param>
    /// <param name="qualification">qualification parameter used to assign its value</param>
    /// <param name="mobileNumber">mobileNumber parameter used to assign its value</param>
    /// <param name="emailID">emailID parameter used to assign its value</param>
    public UserDetails(string userName, int age, GenderDetails gender, string qualification, long mobileNumber, string emailID)
    {
        s_registrationID++;
        RegistrationID = "SYNC" + s_registrationID;
        UserName = userName;
        Age = age;
        Gender = gender;
        Qualification = qualification;
        MobileNumber = mobileNumber;
        EmailID = emailID;

    }




}
