using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolacaoDeString1
{
    class Program
    {
        static void Main(string[] args)
        {
            int idade = 18;
            string nome = "Marco";
            double salario = 1234.56;

            //exemplo1
            string frase1 = nome + " possui " + idade.ToString() + " anos de idade e ganha só R$ " + salario.ToString() + " reais por mês.";

            //exemplo2
            string frase2 = String.Format("{0} possui {1} anos de idade e ganha só R$ {2} reais por mês.", nome, idade, salario);

            //exemplo3 = interpolação $"..{variavel}..";
            string frase3 = $"{nome} possui {idade} anos de idade e ganha só R$ {salario} reais por mês.";

            Console.WriteLine(frase1);
            Console.WriteLine(frase2);
            Console.WriteLine(frase3);
            Console.ReadKey();
        }
    }
}
