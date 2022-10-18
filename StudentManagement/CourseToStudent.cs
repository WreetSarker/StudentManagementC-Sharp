using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace StudentManagement
{

    class CourseToStudent
    {
        public static void addCourseToStudent(string studentID, Course c)
        {
            foreach (Student st in StudentCollection.students)
            {
                if (st.StudentID == studentID)
                {
                    st.addCourse(c);
                }
            }
        }
    }

}