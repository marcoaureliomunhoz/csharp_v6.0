using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressoesLambda1
{
    class Program
    {
        static void Main(string[] args)
        {
            new SoDelegate().Executar();
            new DelegateComExpressaoLambda().Executar();
            new FuncComExpressaoLambda().Executar();
            new FuncComplexaComExpressaoLambda().Executar();
            Console.ReadKey();
        }
    }

    delegate int DelegCalc(int v);

    class SoDelegate
    {
        public void Executar()
        {
            DelegCalc calc = new DelegCalc(Quadrado);
            Console.WriteLine("{0}", calc(2));
        }

        private int Quadrado(int x)
        {
            return x * x;
        }
    }

    class DelegateComExpressaoLambda
    {
        public void Executar()
        {
            DelegCalc calc = new DelegCalc(x => x * x);
            Console.WriteLine("{0}", calc(3));
        }
    }

    class FuncComExpressaoLambda
    {
        public void Executar()
        {
            Func<int,int> quadrado = x => x * x;
            Console.WriteLine("{0}", quadrado(4));
        }
    }

    class FuncComplexaComExpressaoLambda
    {
        public void Executar()
        {
            Func<int, double, string> concatenar = (a,b) => a.ToString() + b.ToString();
            Console.WriteLine("{0}", concatenar(5,6.7));
        }
    }
}
