using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoComParams
{
    public static class Calculadora1
    {
        public static int Somar(params int[] numeros)
        {
            int soma = 0;
            foreach (int numero in numeros)
            {
                soma += numero;
            }
            return soma;
        }
    }

    public static class Calculadora2
    {
        public static int Somar(int filtro, params int[] numeros)
        {
            int soma = 0;
            foreach (int numero in numeros)
            {
                if (numero > filtro)
                {
                    soma += numero;
                }
            }
            return soma;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- método só com params ---");
            Console.WriteLine("{0}", Calculadora1.Somar(1, 4));
            Console.WriteLine("{0}", Calculadora1.Somar(2, 6, 8));
            Console.WriteLine("{0}", Calculadora1.Somar(3, 8, 9, 2, 3));

            Console.WriteLine("--- método com params e vários parâmetros ---");
            Console.WriteLine("{0}", Calculadora2.Somar(3, 2, 6, 8));

            Console.ReadKey();
        }
    }
}
