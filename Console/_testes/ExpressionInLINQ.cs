using System.Collections.Generic;
using System.Linq;

namespace Console
{
    public class ExpressionInLINQ
    {
        public ExpressionInLINQ()
        {

        }

        public void MultipleSelect()
        {
            HelpConsole.WriteLineBar("Example: Multiple Select and where Operator");
            {
                var studentNames =
                    Student.ObterLista().Where(s => s.Age > 18)
                                        .Select(s => s)
                                        .Where(st => st.StandardID > 0)
                                        .Select(s => s.StudentName);

                studentNames.ToList().ForEach(x => System.Console.WriteLine(x));
            }
        }

        public void LINQQueryReturnsCollectionOfAnonymousObjects()
        {
            HelpConsole.WriteLineBar("Example: LINQ Query returns Collection of Anonymous Objects");
            {
                var teenStudentsName = from s in Student.ObterLista()
                                       where s.Age > 12 && s.Age < 20
                                       select new { StudentName = s.StudentName };

                teenStudentsName.ToList().ForEach(x => System.Console.WriteLine(x.StudentName));
            }
        }

        public void LINQGroupByQuery01()
        {
            HelpConsole.WriteLineBar("Example: LINQ GroupBy Query - C#");
            {
                var studentsGroupByStandard = from s in Student.ObterLista()
                                              group s by s.StandardID into sg
                                              orderby sg.Key
                                              select new { sg.Key, sg };


                foreach (var group in studentsGroupByStandard)
                {
                    System.Console.WriteLine("StandardID {0}:", group.Key);
                    group.sg.ToList().ForEach(st => System.Console.WriteLine("   - " + st.StudentName));
                }
            }
        }

        public void LINQGroupByQuery02()
        {
            HelpConsole.WriteLineBar("Example: LINQ GroupBy Query - C#");
            {
                var studentsGroupByStandard = from s in Student.ObterLista()
                                              where s.StandardID > 0
                                              group s by s.StandardID into sg
                                              orderby sg.Key
                                              select new { sg.Key, sg };

                foreach (var group in studentsGroupByStandard)
                {
                    System.Console.WriteLine("StandardID {0}:", group.Key);
                    group.sg.ToList().ForEach(st => System.Console.WriteLine("   - " + st.StudentName));
                }

            }
        }

        public void LINQLeftOuterJoin01()
        {
            HelpConsole.WriteLineBar("Example: LINQ Left Outer Join - C#");
            {
                var studentsGroup =
                    from stad in Standard.ObterLista()
                    join s in Student.ObterLista()
                    on stad.StandardID equals s.StandardID
                    into sg
                    select new
                    {
                        StandardName = stad.StandardName,
                        Students = sg
                    };

                foreach (var group in studentsGroup)
                {
                    System.Console.WriteLine(group.StandardName);

                    group.Students.ToList().ForEach(st => System.Console.WriteLine("    - " + st.StudentName));
                }
            }
        }

        public void LINQLeftOuterJoin02()
        {
            HelpConsole.WriteLineBar("Example: LINQ Left Outer Join - C#");
            {
                var studentsWithStandard =
                    from stad in Standard.ObterLista()
                    join s in Student.ObterLista()
                    on stad.StandardID equals s.StandardID
                    into sg
                    from std_grp in sg
                    orderby stad.StandardName, std_grp.StudentName
                    select new
                    {
                        StudentName = std_grp.StudentName,
                        StandardName = stad.StandardName
                    };


                foreach (var group in studentsWithStandard)
                {
                    System.Console.WriteLine("------- {0} is in {1}", group.StudentName, group.StandardName);
                }
            }
        }

        public void Sorting()
        {
            HelpConsole.WriteLineBar("Example: Sorting");
            {
                var sortedStudents =
                    from s in Student.ObterLista()
                    orderby s.StandardID, s.Age
                    select new
                    {
                        StudentName = s.StudentName,
                        Age = s.Age,
                        StandardID = s.StandardID
                    };

                sortedStudents.ToList().ForEach(s => System.Console.WriteLine("Student Name: {0}, Age: {1}, StandardID: {2}", s.StudentName, s.Age, s.StandardID));
            }
        }

        public void LINQInnerJoin()
        {
            HelpConsole.WriteLineBar("Example: LINQ Inner join - C#");
            {
                var studentWithStandard =
                    from s in Student.ObterLista()
                    join stad in Standard.ObterLista()
                    on s.StandardID equals stad.StandardID
                    select new
                    {
                        StudentName = s.StudentName,
                        StandardName = stad.StandardName
                    };

                studentWithStandard.ToList().ForEach(s => System.Console.WriteLine("{0} is in {1}", s.StudentName, s.StandardName));
            }
        }

        public void NestedQuery()
        {
            HelpConsole.WriteLineBar("Nested Query");
            {
                var nestedQueries = from s in Student.ObterLista()
                                    where s.Age > 18 && s.StandardID ==
                                        (from std in Standard.ObterLista()
                                         where std.StandardName == "Standard 1"
                                         select std.StandardID).FirstOrDefault()
                                    select s;

                nestedQueries.ToList().ForEach(s => System.Console.WriteLine(s.StudentName));
            }
        }

        public void WhereExtension()
        {
            HelpConsole.WriteLineBar("Example: Linq - Where extension method in C#");
            {
                var filteredResult =
                    Student.ObterLista()
                           .Where((s, i) =>
                           {
                               if (i % 2 == 0) // if it is even element
                                       return true;
                               return false;
                           });

                foreach (var std in filteredResult)
                    System.Console.WriteLine(std.StudentName);
            }
        }

        public void JoinOperator()
        {
            HelpConsole.WriteLineBar("Example: Join operator in query syntax C#");
            {
                var innerJoin =
                    Student.ObterLista().Join(// outer sequence =
                        Standard.ObterLista(),  // inner sequence 
                        student => student.StandardID,    // outerKeySelector
                        standard => standard.StandardID,  // innerKeySelector
                        (student, standard) => new  // result selector
                            {
                            StudentName = student.StudentName,
                            StandardName = standard.StandardName
                        });

                innerJoin.ToList().ForEach(x => System.Console.WriteLine($"Student: {x.StudentName} - Stand: {x.StandardName}"));

            }
        }

        public void GroupJoinInMethod()
        {
            HelpConsole.WriteLineBar("Example: GroupJoin in Method syntax C#");
            {
                var groupJoin = Standard.ObterLista().GroupJoin(Student.ObterLista(),  //inner sequence
                                std => std.StandardID, //outerKeySelector 
                                s => s.StandardID,     //innerKeySelector
                                (std, studentsGroup) => new // resultSelector 
                                    {
                                    Students = studentsGroup,
                                    StandarFulldName = std.StandardName
                                });

                foreach (var item in groupJoin)
                {
                    System.Console.WriteLine(item.StandarFulldName);

                    foreach (var stud in item.Students)
                        System.Console.WriteLine(stud.StudentName);
                }
            }
        }

        public void GroupJoinQuery()
        {
            HelpConsole.WriteLineBar("Example: GroupJoin Query Syntax C#");
            {
                var groupJoin = from std in Standard.ObterLista()
                                join s in Student.ObterLista()
                                on std.StandardID equals s.StandardID
                                into studentGroup
                                select new
                                {
                                    Students = studentGroup,
                                    StandardName = std.StandardName
                                };

                foreach (var item in groupJoin)
                {
                    System.Console.WriteLine(item.StandardName);

                    foreach (var stud in item.Students)
                        System.Console.WriteLine(stud.StudentName);
                }
            }
        }

        public void SelectInQuery()
        {
            HelpConsole.WriteLineBar("Example: Select in Query Syntax C#");
            {
                var selectResult = from s in Student.ObterLista()
                                   select new { Name = "Mr. " + s.StudentName, Age = s.Age };

                foreach (var item in selectResult)
                    System.Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);
            }
        }

        public void All_Any_Operator()
        {
            HelpConsole.WriteLineBar("Example: All/Any operator C#");
            {
                var studentList = Student.ObterLista();

                // checks whether all the students are teenagers    
                bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);
                bool isAnyStudentTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);

                System.Console.WriteLine("Todos são adolescente: " + (areAllStudentsTeenAger ? "SIM" : "NÃO"));
                System.Console.WriteLine("Tem adolescente: " + (isAnyStudentTeenAger ? "SIM" : "NÃO"));
            }
        }

        public void Contains_Aggregate_Average_SequenceEqual_operator()
        {
            HelpConsole.WriteLineBar("Example: Contains/Aggregate/Average/SequenceEqual  operator C#");
            {
                var studentList = Student.ObterLista();

                // Contains ============================================================================= 
                Student std = new Student() { StudentID = 3, StudentName = "Bill" };
                bool result = studentList.Contains(std); //returns false
                System.Console.WriteLine("Contem 3-Bill: " + (result ? "SIM" : "NÃO"));

                result = studentList.Contains(std, new StudentComparer()); //returns true
                System.Console.WriteLine("Contem 3-Bill: " + (result ? "SIM" : "NÃO"));

                // Aggregate =============================================================================
                string commaSeparatedStudentNames =
                    studentList.Aggregate<Student, string>(
                        "Student Names: ", (str, s) => str += $"{s.StudentID}-{s.StudentName}" + " / ");

                System.Console.WriteLine("studentList.Aggregate: " + commaSeparatedStudentNames);

                // Average ===============================================================================
                var avgAge = studentList.Average(s => s.Age);
                System.Console.WriteLine($"Average Age of Student: {studentList.Sum(x => x.Age)}/{studentList.Count} = {avgAge}");

                // SequenceEqual =============================================================================
                var studentListAux = Student.ObterLista();
                bool isEqual = studentList.SequenceEqual(studentListAux);// returns false
                System.Console.WriteLine($"Listas são iguais: {(isEqual ? "SIM" : "NÃO")}");
                isEqual = studentList.SequenceEqual(studentListAux, new StudentComparer());// returns false
                System.Console.WriteLine($"Listas são iguais: {(isEqual ? "SIM" : "NÃO")}");

            }
        }

        public void DefaultIfEmpty()
        {
            HelpConsole.WriteLineBar("Example: DefaultIfEmpty C#:");
            {
                IList<Student> emptyStudentList = new List<Student>();

                var newStudentList1 = emptyStudentList.DefaultIfEmpty();
                var newStudentList2 = emptyStudentList.DefaultIfEmpty(new Student() { StudentID = 1, StudentName = "11" });

                System.Console.WriteLine("Count: {0} ", newStudentList1.Count());
                System.Console.WriteLine("Student ID: {0} ", newStudentList1.ElementAt(0));

                System.Console.WriteLine("Count: {0} ", newStudentList2.Count());
                System.Console.WriteLine("Student ID: {0} ", newStudentList2.ElementAt(0).StudentID);
            }

        }

        public void OperatorDistinct()
        {
            HelpConsole.WriteLineBar("Set Operator: Distinct");
            {
                IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
                };

                var distinctStudents = studentList.Distinct(new StudentComparer());

                foreach (var std in distinctStudents)
                {
                    System.Console.WriteLine(std.StudentName);
                }
            }
        }

        public void ExceptWithObject()
        {
            HelpConsole.WriteLineBar("Example: Except() with object type C#");
            {
                IList<Student> studentList1 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

                IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

                var resultedCol = studentList1.Except(studentList2, new StudentComparer());

                foreach (Student std in resultedCol)
                {
                    System.Console.WriteLine(std.StudentName);
                }
            }
        }

        public void IntersectInMethod()
        {
            HelpConsole.WriteLineBar("Example: Intersect in method syntax C#");
            {
                IList<Student> studentList1 = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
                };

                IList<Student> studentList2 = new List<Student>() {
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
                };

                var resultedCol = studentList1.Intersect(studentList2, new StudentComparer());

                foreach (Student std in resultedCol)
                {
                    System.Console.WriteLine(std.StudentName);
                }
            }
        }

        public void UnionOperator()
        {
            HelpConsole.WriteLineBar("Example: Union operator C#");
            {
                IList<Student> studentList1 = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
                };

                IList<Student> studentList2 = new List<Student>() {
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
                };

                var resultedCol = studentList1.Union(studentList2, new StudentComparer());

                foreach (Student std in resultedCol)
                {
                    System.Console.WriteLine(std.StudentName);
                }
            }
        }
    }
}
}
