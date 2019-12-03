using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class RelacaoAlunos : List<Aluno>
    {

    }

    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Aluno() { }
        public Aluno(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }


        public override string ToString()
        {
            return string.Format("ID: {0} / NOME: {1}", Id > 0 ? Id.ToString() : "---", Nome);
        }
    }
}
