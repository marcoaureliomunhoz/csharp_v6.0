using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetorMatriz1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mesesAno = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Console.WriteLine("[mesesAno]");
            Console.WriteLine("Length = {0}", mesesAno.Length);
            Console.WriteLine("Rank = {0}", mesesAno.Rank);
            Array.Reverse(mesesAno);
            string aux1 = "";            
            foreach (int mes in mesesAno)
            {
                aux1 += (aux1.Length>0?",":"") + mes.ToString();
            }
            Console.WriteLine("Reverse = {0}", aux1);
            Console.WriteLine("");

            string[] diasSemana = new string[7];
            diasSemana[0] = "dom";
            diasSemana[1] = "seg";
            diasSemana[2] = "ter";
            diasSemana[3] = "qua";
            diasSemana[4] = "qui";
            diasSemana[5] = "sex";
            diasSemana[6] = "sab";
            Console.WriteLine("[diasSemana]");
            Console.WriteLine("Length = {0}", diasSemana.Length);
            Console.WriteLine("Rank = {0}", diasSemana.Rank);
            Array.Sort(diasSemana);
            string aux2 = "";
            foreach (string dia in diasSemana)
            {
                aux2 += (aux2.Length > 0 ? "," : "") + dia;
            }
            Console.WriteLine("Sort = {0}", aux2);
            Console.WriteLine("");

            int[,] quadrado1 = { { 10, 11 }, { 50, 51 } };
            Console.WriteLine("[quadrado1]");
            Console.WriteLine("Length = {0}", quadrado1.Length);
            Console.WriteLine("Rank = {0}", quadrado1.Rank);
            Console.WriteLine("");

            int[,] quadrado2 = new int[2, 2];
            quadrado2[0, 0] = 10;
            quadrado2[0, 1] = 11;
            quadrado2[1, 0] = 50;
            quadrado2[1, 1] = 51;
            Console.WriteLine("[quadrado2]");
            Console.WriteLine("Length = {0}", quadrado2.Length);
            Console.WriteLine("Rank = {0}", quadrado2.Rank);
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
