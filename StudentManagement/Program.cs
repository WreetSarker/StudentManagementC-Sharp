using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StudentManagement
{
    
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Student Management System");
            Console.WriteLine("==========================");

            Console.WriteLine();
            StudentCollection sc = new StudentCollection();

            MainScreenLoop.RunMainLoop(sc);
            
            
            
        }
    }
}