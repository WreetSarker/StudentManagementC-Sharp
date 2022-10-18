using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace StudentManagement
{
    // Student Collection class contains list of all the students and methods to add and delete student
    class StudentCollection
    {
        public static List<Student> students = new List<Student>();
        public void addStudent(Student student)
        {
            students.Add(student);

            
        }

        public List<Student> getStudents()
        {
            return students;
        }

        public bool deleteStudent(string studentID)
        {
            foreach(Student student in students)
            {
                if(student.StudentID == studentID)
                {
                    students.Remove(student); 
                    return true;
                }
            } 
            return false;
        }

        public void showStudents()
        {
            Console.WriteLine("Current number of enrolled students: {0}", students.Count);
            
            if(students.Count > 0)
            {
                for(int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine("{0}. "+students[i].FullName, i+1);
                }
            }
        }

    }
}