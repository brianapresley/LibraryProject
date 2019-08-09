using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLibrary {
   public class StudentLib {

        public static string About = "About StudentLib";

        public List<Student> ListStudents() {
            var db = new AppEfDbContext(); //create an instance of the context
            return db.Students.ToList();

        }
        
        public Student GetStudent(int id) {
            var db = new AppEfDbContext();
            return db.Students.Find(id);
        }
        public bool InsertStudent(Student NewStudent)
        {
            var db = new AppEfDbContext();
            NewStudent.Id = 0;
            if (NewStudent.MajorId != null)
            {
                var major = db.Majors.Find(NewStudent.MajorId);
                if (major == null)
                {
                    return false;
                }
            }
            db.Students.Add(NewStudent);
            db.SaveChanges();
            return true;
        }
        public bool RemoveStudent(Student s) {
            var db = new AppEfDbContext();
            var rDB = GetStudent(s.Id);
            if(rDB == null) {
                throw new Exception("Student does not exist!");
            }
            rDB.Firstname = s.Firstname;
            rDB.Lastname = s.Lastname;
            rDB.Gpa = s.Gpa;
            rDB.Sat = s.Sat;
            rDB.IsFulltime = s.IsFulltime;
            rDB.MajorId = s.MajorId;
            var major = db.Majors.Find(s.MajorId);
            if (major == null) {
                return false;
            }
            db.Remove<Student>(rDB);
            db.SaveChanges();
            return true;
        
    }
        public bool UpdateStudent(Student s) {
            var db = new AppEfDbContext();
            var sDB = GetStudent(s.Id);
            if(sDB == null) {
                throw new Exception("Student cannot be found!");
            }
            sDB.Firstname = s.Firstname;
            sDB.Lastname = s.Lastname;
            sDB.Gpa = s.Gpa;
            sDB.Sat = s.Sat;
            sDB.IsFulltime = s.IsFulltime;
            sDB.MajorId = s.MajorId;
            var major = db.Majors.Find(s.MajorId);
            if(major == null) {
                return false;
            }
            db.Update<Student>(sDB);
            db.SaveChanges();
            return true;
        }
    }
}
