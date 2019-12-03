using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class ListNewStudent : List<NewStudentt>
    {
        public ListNewStudent()
        {

        }

       
        // Create a data source by using a collection initializer.
        public static ListNewStudent GetListStudent()
        {
            ListNewStudent students = new ListNewStudent()
            {
                new NewStudentt {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new NewStudentt {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new NewStudentt {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new NewStudentt {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new NewStudentt {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new NewStudentt {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new NewStudentt {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new NewStudentt {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new NewStudentt {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new NewStudentt {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new NewStudentt {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new NewStudentt {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };

            return students;
        }
    }

    public class NewStudentt
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }

        public List<int> Scores;

        public override string ToString()
        {

            //return string.Format("ID: {0,2} / NOME: {1, -15} / PREÇO: {2,10}", this.Id.ToString(), this.Nome, this.Preco.ToString("F2", CultureInfo.InvariantCulture));

            return string.Format("ID: {0,3} / FIRST: {1,-20} / LAST: {2,-20} / SCORE: {3,-20}", ID > 0 ? ID.ToString() : "---", First, Last, String.Join(",", Scores));
        }
    }
}
