using System.Collections.Generic;
using System.Linq;

namespace Console
{
    public class ColecaoConjunto
    {
        public Aluno a1, a2, a3, a4, a5, a6, a7, a8;
        public List<Aluno> Alunos;

        public ColecaoConjunto()
        {
            StartAlunos();

            HelpConsole.WriteLineBar("RelaçãoAlunos");
            WriteAlunos(Alunos);

            HelpConsole.WriteLineBar("Conjunto A");
            List<Aluno> _conjuntoA = new List<Aluno>() { a1, a2, a3 };
            WriteAlunos(_conjuntoA);

            HelpConsole.WriteLineBar("Conjunto B");
            List<Aluno> _conjuntoB = new List<Aluno>() { a3, a4, a5 };
            WriteAlunos(_conjuntoB);

            HelpConsole.WriteLineBar("conjuntoA.Except.conjuntoB");
            WriteAlunos(_conjuntoA.Except(_conjuntoB).ToList());

            HelpConsole.WriteLineBar("conjuntoA.Intersect.conjuntoB");
            WriteAlunos(_conjuntoA.Intersect(_conjuntoB).ToList());

            HelpConsole.WriteLineBar("conjuntoA.Union.conjuntoB");
            WriteAlunos(_conjuntoA.Union(_conjuntoB).ToList());

            HelpConsole.WriteLineBar("Conjunto C");
            List<Aluno> _conjuntoC = new List<Aluno>() { a1, a2, a3, a4, a5, a6, a7, a8 };
            WriteAlunos(_conjuntoC);

            HelpConsole.WriteLineBar("conjuntoC.Intersect.conjuntoA");
            WriteAlunos(_conjuntoC.Intersect(_conjuntoA).ToList());

            HelpConsole.WriteLineBar("conjuntoC.Intersect.conjuntoB");
            WriteAlunos(_conjuntoC.Intersect(_conjuntoB).ToList());

            HelpConsole.WriteLineBar("conjuntoC.Except.conjuntoA.Except.conjuntoB");
            WriteAlunos(_conjuntoC.Except(_conjuntoA).Except(_conjuntoB).ToList());

            System.Console.ReadKey();
        }

        public void StartAlunos()
        {
            a1 = new Aluno(1, "Aluno 1");
            a2 = new Aluno(2, "Aluno 2");
            a3 = new Aluno(3, "Aluno 3");
            a4 = new Aluno(4, "Aluno 4");
            a5 = new Aluno(5, "Aluno 5");
            a6 = new Aluno(6, "Aluno 6");
            a7 = new Aluno(7, "Aluno 7");
            a8 = new Aluno(8, "Aluno 8");

            Alunos = new List<Aluno>() { a1, a2, a3, a4, a5 };
        }

        public void WriteAlunos(List<Aluno> alunos)
        {
            if (alunos == null || !alunos.Any())
            {
                System.Console.WriteLine(" --- NENHUM ALUNO INFORMADO");
            }
            else
            {
                alunos.ForEach(x => System.Console.WriteLine(x.ToString()));
            }

            System.Console.WriteLine("");
        }
    }
}
