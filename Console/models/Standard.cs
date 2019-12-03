using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }

        public Standard()
        {

        }

        public static IList<Standard> ObterLista()
        {
            IList<Standard> standardList =
                new List<Standard>()
                {
                        new Standard() { StandardID = 1, StandardName = "Standard 1" },
                        new Standard() { StandardID = 2, StandardName = "Standard 2" },
                        new Standard() { StandardID = 3, StandardName = "Standard 3" },
                };

            return standardList;
        }
    }
}
