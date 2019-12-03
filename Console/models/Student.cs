using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID && x.StudentName.ToLower() == y.StudentName.ToLower())
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.StudentID.GetHashCode();
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int StandardID { get; set; }


        public Student()
        {

        }

        public static IList<Student> ObterLista()
        {
            IList<Student> studentList =
                new List<Student>()
                {
                        new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 },
                        new Student() { StudentID = 2, StudentName = "Steve", Age = 21, StandardID = 1 },
                        new Student() { StudentID = 3, StudentName = "Bill", Age = 18, StandardID = 2 },
                        new Student() { StudentID = 4, StudentName = "Ram", Age = 20, StandardID = 2 },
                        new Student() { StudentID = 5, StudentName = "Ron", Age = 21 }
                };

            return studentList;
        }
    }
}
