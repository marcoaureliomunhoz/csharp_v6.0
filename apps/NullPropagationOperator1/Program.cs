using System;
using static System.Console;

namespace NullPropagationOperator1
{
    class Editora
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return $"[ Codigo: {Codigo}, Nome: {Nome} ]";
        }
    }

    class Livro
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Editora Editora { get; set; }

        public override string ToString()
        {
            //aqui pode dar erro se Editora não for uma instância
            //é aí que entra o operador de propagação de null
            return $"[ Codigo: {Codigo}, Nome: {Nome}, Editora: {Editora?.ToString() ?? "<null>"} ]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Editora novatec = new Editora();
            novatec.Codigo = 1;
            novatec.Nome = "novatec";

            Livro useCabeca = new Livro();
            useCabeca.Codigo = 1;
            useCabeca.Nome = "Use a Cabeça";
            useCabeca.Editora = novatec;

            Livro phpModerno = new Livro();
            phpModerno.Codigo = 2;
            phpModerno.Nome = "PHP Moderno";

            WriteLine(useCabeca.ToString());
            WriteLine(phpModerno.ToString());

            ReadKey();
        }
    }
}
