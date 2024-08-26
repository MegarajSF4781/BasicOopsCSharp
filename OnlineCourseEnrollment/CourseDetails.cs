using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseEnrollment;

public class CourseDetails
{
    // •	CourseID (Auto Incremented – CS2001)
    // •	CourseName
    // •	TrainerName
    // •	CourseDuration
    // •	SeatsAvailabe


    /// <summary>
    /// Static Field s_courseID used to auto increment courseID of the instance of <see cref="CourseDetails"/>
    /// </summary>
    private static int s_courseID = 2000;
    /// <summary>
    /// CourseID property used to hold a course's ID of instance of <see cref="CourseDetails"/> 
    /// </summary>
    public string CourseID { get; }
    /// <summary>
    /// CourseName property used to hold a course Name of instance of <see cref="CourseDetails"/> 
    /// </summary>
    public string CourseName { get; set; }
    /// <summary>
    /// Trainer Name property used to hold a TrainerName of instance of <see cref="CourseDetails"/> 
    /// </summary>
    public string TrainerName { get; set; }
    /// <summary>
    /// Course duration property used to hold a CourseDuration of instance of <see cref="CourseDetails"/> 
    /// </summary>
    public int CourseDuration { get; set; }

    /// <summary>
    /// Seats Available property used to hold a SeatsAvailable of instance of <see cref="CourseDetails"/> 
    /// </summary>
    public int SeatsAvailable { get; set; }

    /// <summary>
    /// Constructor Course Details used to initialize parametrized properties
    /// </summary>
    /// <param name="courseName">parameter used to assign its value</param>
    /// <param name="trainerName">parameter used to assign its value</param>
    /// <param name="courseDuration">parameter used to assign its value</param>
    /// <param name="seatsAvailabe">parameter used to assign its value</param>
    public CourseDetails(string courseName, string trainerName, int courseDuration, int seatsAvailabe)
    {
        s_courseID++;
        CourseID = "CS" + s_courseID;
        CourseName = courseName;
        TrainerName = trainerName;
        CourseDuration = courseDuration;
        SeatsAvailable = seatsAvailabe;
    }

    public CourseDetails()
    {

    }

}
