using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace StudentManagement
{

    class Course
    {
        public string CourseName { get; set; }
        public string CourseInfo { get; set; }
        public Course(string courseID, string courseName, string instructorName, int numberOfCredits)
        {
            CourseName = courseName + " " + courseID;
            CourseInfo = "Credits: " + numberOfCredits + ", Offered by: " + instructorName;
        }

        public override string ToString()
        {
            return "Full Course name: " + CourseName + "\nCourse info: "+ CourseInfo;

        }
    }

}