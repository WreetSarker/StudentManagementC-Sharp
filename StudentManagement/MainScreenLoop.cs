using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace StudentManagement
{
    class MainScreenLoop
    {
        public static void RunMainLoop(StudentCollection sc)
        {
            while (true)
            {
                sc.showStudents();
                Console.WriteLine();
                Console.WriteLine("You can choose one from the following options: \n");
                Console.WriteLine("1.Add Student\n\n2.View Student\n\n3.Delete Student\n\n4.Add Semester\n");
                int chosenOption = Convert.ToInt32(Console.ReadLine());
                /*Console.WriteLine("\n\n");*/
                Console.WriteLine("You chose: {0}", chosenOption);
                Console.WriteLine();

                int[] options = { 1, 2, 3, 4 };

                if (options.Contains(chosenOption))
                {
                    if (chosenOption == 1)
                    {
                        string firstName, middleName, lastName, studentID, joiningBatch;
                        int department, degree;
                        Console.WriteLine("To add a student enter the following details: \n");
                        Console.Write("First Name: ");
                        firstName = Console.ReadLine();

                        Console.Write("Middle Name (Press Enter if no middle name): ");
                        middleName = Console.ReadLine();

                        Console.Write("Last Name: ");
                        lastName = Console.ReadLine();

                        Console.Write("Student ID: ");
                        studentID = Console.ReadLine();

                        Console.Write("Joining Batch: ");
                        joiningBatch = Console.ReadLine();

                        Console.Write("Department: ");
                        Console.Write("1. Computer Science 2. EEE 3. Mechanical 4. IPE 5. Chemical 6. Materials Science: ");
                        department = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Degree: ");
                        Console.Write("1. BSc 2. MSc 3. MBA 4. MPhil 5. PhD: ");
                        degree = Convert.ToInt32(Console.ReadLine());

                        Student student = new Student(firstName, middleName, lastName, studentID, joiningBatch, department, degree);
                        sc.addStudent(student);
                        SaveFile.saveToJson(student);
                        Console.WriteLine("Adding Student.....");
                        int milliseconds = 500;
                        Thread.Sleep(milliseconds);
                        Console.WriteLine("Student added successfully");
                        Console.WriteLine();
                    }
                    else if (chosenOption == 2)
                    {
                        string studentID;
                        Console.Write("Enter the student id to view: ");
                        studentID = Console.ReadLine();
                        Console.WriteLine();

                        var data = from student in sc.getStudents()
                                   where student.StudentID == studentID
                                   select student;

                        if (data.Any())
                        {
                            foreach (Student student in data)
                            {
                                int milliseconds = 500;
                                Thread.Sleep(milliseconds);
                                Console.WriteLine(student.ToString());
                                Console.Write("Semester: ");
                                student.showSemester();
                                Console.WriteLine();
                                Console.Write("Courses: \n");
                                student.showCourses();
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry! Student with {0} id does not exist in the database! Try again.\n", studentID);
                        }

                    }
                    else if (chosenOption == 3)
                    {
                        string studentID;
                        Console.Write("Enter the student id to delete: ");
                        studentID = Console.ReadLine();
                        if (sc.deleteStudent(studentID))
                        {
                            Console.WriteLine("Deleting student....");
                            Console.WriteLine("Student with {0} student id deleted successfully.", studentID);
                        }
                        else
                        {
                            Console.WriteLine("Sorry! Student with {0} id does not exist in the database! Try again.");
                        }

                    }else if (chosenOption == 4)
                    {
                        string semesterCode, year;
                        Console.WriteLine("Enter your semester code: Sum(Summer)/Fal(Fall)/Spr(Spring): ");
                        semesterCode = Console.ReadLine();
                        Console.WriteLine("Enter the year for the semester: ");
                        year = Console.ReadLine();

                        Semester sm = new Semester(semesterCode, year);
                        Console.WriteLine("Enter the student id of the student to add semester: ");
                        string studentID = Console.ReadLine();

                        bool isFound = false;

                        foreach(Student student in StudentCollection.students)
                        {
                            if(student.StudentID == studentID)
                            {
                                isFound = true;
                            }
                        }

                        if (isFound)
                        {
                            SemesterToStudent.addSemesterToStudent(studentID, sm);

                            Console.WriteLine("Do you want to add any course to {0}? (y/n)", studentID);
                            string boolInp = Console.ReadLine();
                            if (boolInp.ToLower() == "y")
                            {
                                string courseID, courseName, instructorName;
                                int numberOfCredits;
                                Console.WriteLine("Enter course ID: ");
                                courseID = Console.ReadLine();
                                Console.WriteLine("Enter course name: ");
                                courseName = Console.ReadLine();
                                Console.WriteLine("Enter course instructor name: ");
                                instructorName = Console.ReadLine();
                                Console.WriteLine("Total course credits: ");
                                numberOfCredits = Convert.ToInt32(Console.ReadLine());

                                Course course = new Course(courseID, courseName, instructorName, numberOfCredits);
                                Console.WriteLine("Adding course to {0}.....", studentID);
                                CourseToStudent.addCourseToStudent(studentID, course);
                                int milliseconds = 300;
                                Thread.Sleep(milliseconds);
                                Console.WriteLine("Course with following details added to {0}: ", studentID);
                                Console.WriteLine(course.ToString());
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry! Student with student id {0} does not exist in the database. Try again!", studentID);
                        }

                    }
                }
                else
                {
                    Console.WriteLine("You chose an invalid option.");
                    continue;
                }
                Console.WriteLine("Do you wish to continue? (y/n)");
                string inp;
                inp = Console.ReadLine();
                if (inp.ToLower() == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }

}