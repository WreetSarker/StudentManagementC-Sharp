using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace StudentManagement
{

    class Semester
    {
        public string SemesterName { get; set; }
        public Semester(string semesterCode, string year)
        {
            SemesterName = semesterCode + "-" + year;
        }

    }

}