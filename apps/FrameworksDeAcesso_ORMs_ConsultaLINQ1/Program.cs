using System;
using System.Linq;


namespace FrameworksDeAcesso_ORMs_ConsultaLINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            //fonte de dados
            int[] salariosDaEmpresa = { 5000, 7000, 8500, 1300, 2000, 2500, 1000 };

            //consulta LINQ em alto nível
            var salariosDeUmDesenvolvedor =
                    from salario
                    in salariosDaEmpresa
                    where salario < 1500
                    orderby salario
                    select salario;

            var aux = "";
            foreach (var salario in salariosDeUmDesenvolvedor)
            {
                aux += (aux.Length > 0 ? ", " : "") + $"{salario}";
            }
            Console.WriteLine($"Quanto ganham os desenvolvedores desta empresa => {aux}");
            Console.ReadKey();
        }
    }
}
