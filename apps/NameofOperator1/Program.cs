using System;
using static System.Console;

namespace NameofOperator1
{
    class Calculadora
    {
        public int Somar(int a, int b) => a + b;
    }

    class Program
    {
        static Calculadora recurso1;

        static void Main(string[] args)
        {
            Metodo1();
            Metodo2();
            ReadKey();
        }

        static void Metodo1()
        {
            try
            {
                recurso1.Somar(2, 2);
            }
            catch (Exception ex)
            {
                //WriteLine($"Erro ao acessar recurso1: {ex.Message}");
                WriteLine($"Erro ao acessar {nameof(recurso1)}: {ex.Message}");
            }
        }

        static void Metodo2()
        {
            try
            {
                recurso1.Somar(3, 3);
            }
            catch (Exception ex)
            {
                //WriteLine($"Erro ao acessar recurso1: {ex.Message}");
                WriteLine($"Erro ao acessar {nameof(recurso1)}: {ex.Message}");
            }
        }
    }
}
