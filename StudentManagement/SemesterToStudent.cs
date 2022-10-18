using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace StudentManagement
{

    class SemesterToStudent
    {
        public static void addSemesterToStudent(string studentID, Semester sm)
        {
            foreach (Student st in StudentCollection.students)
            {
                if (st.StudentID == studentID)
                {
                    st.addSemester(sm);
                }
            }
        }
    }

}