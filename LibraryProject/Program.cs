using System;
using StudentLibrary;
//using BrianasUtilitiesLibrary;

namespace LibraryProject {
    class Program {
        static void Main(string[] args) {

            //var about = StudentLib.About;        //To reference Studentlib since its in a different namespace or add a using statement
            //BrianasUtilitiesLibrary.Console.Print(about);


            //get list of all students
            var lib = new StudentLib();

            //To Insert Elmer Fudd
            var ef = new Student
            {
                Id = 0,
                Firstname = "Elmer",
                Lastname = "Fudd",
                Sat = 600,
                Gpa = 1.5,
                IsFulltime = true,
                MajorId = 1
            };
            var ok = lib.InsertStudent(ef);
            Console.WriteLine(ef);
            Console.WriteLine((ok ? "Insert Successful!" : "Insert Failed!"));


            //To Delete Jane Doe
            var janedoe = lib.GetStudent(1);
            lib.RemoveStudent(janedoe);

            //To UPDATE John to Jon 
            //var jonsmith = lib.GetStudent(2);
            //jonsmith.Firstname = "Jon";
            //var success = lib.UpdateStudent(jonsmith);

            var students = lib.ListStudents();
            foreach(var student in students) {
                Console.WriteLine($"{student.Firstname} {student.Lastname} {student.Major?.Description}");

            }
            // get a student by primary key
            var s4 = lib.GetStudent(4);
            if(s4 == null) {
                Console.WriteLine("Student not found");
            }else {
                Console.WriteLine($"S4: {s4.Firstname} {s4.Lastname} {s4.Major?.Description}");
            }
            //this should fail
            var s444 = lib.GetStudent(444);
            if (s444 == null) {
                Console.WriteLine("Student not found!");
            }
            else { 
                    Console.WriteLine($"S444: {s444.Firstname} {s444.Lastname} {s444.Major.Description}");
                }

            }
        }
    }

