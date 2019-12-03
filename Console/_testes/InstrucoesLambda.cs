using System.Collections.Generic;
using System.Linq;

namespace Console
{
    public class InstrucoesLambda
    {
        ListNewStudent Students;

        public InstrucoesLambda()
        {
            Students = ListNewStudent.GetListStudent();

            HelpConsole.WriteLineBar("Lista completa de students");
            Students.ForEach(x => System.Console.WriteLine(x.ToString()));

            //Imprimir_Posicao_0_Score_maior_90();
            //Imprimir_Group_1();
            //Imprimir_Group_2();
            //Imprimir_Group_3();
            Imprimir_Group_4();
        }



        //private void Imprimir_Posicao_0_Score_maior_90()
        //{
        //    IEnumerable<Student> studentQuery =
        //        from student in Students
        //        where student.Scores[0] > 90
        //        select student;

        //    HelpConsole.WriteLineBar("Score posição 0 maior que 90");
        //    studentQuery.ToList().ForEach(x => System.Console.WriteLine(x.ToString()));
        //}

        private void Imprimir_Group_1()
        {
            System.Console.WriteLine("");

            HelpConsole.WriteLineBar("Imprimir_Group_1");

            var studentQuery2 =
                from student in Students
                group student by student.Last[0];


            foreach (var studentGroup in studentQuery2)
            {
                System.Console.WriteLine(studentGroup.Key);

                foreach (NewStudentt student in studentGroup)
                {
                    System.Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }
        }

        private void Imprimir_Group_2()
        {
            System.Console.WriteLine("");

            HelpConsole.WriteLineBar("Imprimir_Group_2");

            var studentQuery =
                from student in Students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            foreach (var groupOfStudents in studentQuery)
            {
                System.Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    System.Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }
        }

        private void Imprimir_Group_3()
        {
            System.Console.WriteLine("");

            HelpConsole.WriteLineBar("Imprimir_Group_3");

            var studentQuery =
                from student in Students

                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]

                where totalScore / 4 < student.Scores[0]
                select student.Last + " "
                        + student.First + " "
                        + totalScore.ToString()
                        + " / 4 < " + student.Scores[0].ToString() + " "
                        + (totalScore / 4 < student.Scores[0]).ToString();

            foreach (string s in studentQuery)
            {
                System.Console.WriteLine(s);
            }
        }

        private void Imprimir_Group_4()
        {
            System.Console.WriteLine("");

            HelpConsole.WriteLineBar("Imprimir_Group_4");

            var studentQuery =
                from student in Students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                select totalScore;

            double averageScore = studentQuery.Average();

            System.Console.WriteLine("Class average score = {0}", averageScore);
        }





    }
}
