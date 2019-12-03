using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public static class HelpConsole
    {
        private const int LINE_SIZE = 60;

        private static string GetLine(char caracter = '-')
        {
            return new string(caracter, LINE_SIZE);
        }

        public static void WriteLineBar(char value = '-')
        {
            System.Console.WriteLine(GetLine(value));
        }

        public static void WriteLineBar(string titulo, char caracter = '-')
        {
            string linha = string.Format($"--- {titulo} ");

            if (LINE_SIZE > linha.Length)
            {
                linha += new string(caracter, LINE_SIZE - linha.Length);
            }

            System.Console.WriteLine(linha);
        }
    }














}
