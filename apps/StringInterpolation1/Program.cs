using System;
using static System.Console;


namespace StringInterpolation1
{
    class Program
    {
        static void Main(string[] args)
        {
            //formatando string com concatenação e conversões
            var forma1 = "Hoje é " + DateTime.Now.ToLongDateString();
            WriteLine(forma1);

            //formatando string com o auxílio de um método especial
            var forma2 = String.Format("Hoje é {0}", DateTime.Now.ToLongDateString());
            WriteLine(forma2);

            //formatando string com interpolação
            var forma3 = $"Hoje é {DateTime.Now.ToLongDateString()}";
            WriteLine(forma3);

            ReadKey();
        }
    }
}
