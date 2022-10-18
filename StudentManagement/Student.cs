using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace StudentManagement
{
     //Base student class
    class Student
    {

        public string FullName { get; 
            private set; }

        public string StudentID { get; set; }

        public int Department { get; set; }

        public int Degree { get; set; }

        public static List<Semester> Semesters = new List<Semester> { };
        public static List<Course> Courses = new List<Course> { };

        public List<Semester> getSemesters()
        {
            return Semesters;
        }

        enum Departments { ComputerScience = 1, EEE, Mechanical, IPE, Chemical, MaterialsScience }

        enum Degrees { BSc = 1, MSc, MBA, MPhil, PhD }

        public Student(string firstName, string middleName, string lastName, string studentID, string joiningBatch, int department, int degree)
        {
            if(middleName == "")
            {
                FullName = firstName + " " + lastName;
            }
            else
            {
                FullName = firstName + " " + middleName + " " + lastName;
            }

            StudentID = studentID;
            Department = department;
            Degree = degree;
        }

        public void addSemester(Semester sm)
        {
            Semesters.Add(sm);
        }



        public void showSemester()
        {
            for(int i = 0; i < Semesters.Count; i++)
            {
                Console.WriteLine((i+1) + ". "+ Semesters[i].SemesterName);
            }
        }

        public void addCourse(Course c)
        {
            Courses.Add(c);
        }
        public void showCourses()
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                Console.WriteLine((i + 1) + ". Course name: " + Courses[i].CourseName);
                Console.WriteLine("Course info: " + Courses[i].CourseInfo);
            }
        }

        public override string ToString()
        {
            return "Student Name: " + FullName + "\nStudent ID: "+ StudentID + "\nDepartment: " +(Departments)Department
                + "\nDegree: " + (Degrees)Degree;
        }
    }

}