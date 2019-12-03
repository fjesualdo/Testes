using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class FormatString
    {
        public FormatString()
        {
            WriteLine_Com_Caracteres_Contados();
        }

        private void WriteLine_Com_Caracteres_Contados()
        {
            // Crie uma matriz contendo a área de alguns estados.
            Tuple<string, double>[] areas =
                {
                    Tuple.Create("Sitka, Alaska", 2870.3),
                    Tuple.Create("New York City", 302.6),
                    Tuple.Create("Los Angeles", 468.7),
                    Tuple.Create("Detroit", 138.8),
                    Tuple.Create("Chicago", 227.1),
                    Tuple.Create("San Diego", 325.2)
                };


            HelpConsole.WriteLineBar("Mascara da linha");
            System.Console.WriteLine("{0,-18} {1,14:N1} {2,30}\n", "123456789012345678", "12345678901234", "123456789012345678901234567890");
            System.Console.WriteLine("{0,-18} {1,14:N1} {2,30}\n", "City", "Area (mi.)", "Equivalent to a square with:");

            HelpConsole.WriteLineBar();
            foreach (var area in areas)
            {
                System.Console.WriteLine(
                    "{0,-18} {1,14:N2x'} {2,14:N2} miles per side",
                    area.Item1,
                    area.Item2,
                    Math.Round(Math.Sqrt(area.Item2), 2)
                );
            }
        }
    }
}
