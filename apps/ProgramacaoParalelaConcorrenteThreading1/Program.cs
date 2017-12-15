using System;
using System.Collections.Generic;
using System.Threading;

namespace ProgramacaoParalelaConcorrenteThreading1
{
    class Program
    {
        static List<string> _recurso = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("# inicio thread 0");

            var threadParalela1 = new Thread(ThreadParalela1_Run);
            var threadParalela2 = new Thread(ThreadParalela2_Run);

            threadParalela1.Start();
            threadParalela2.Start();

            for (var i = 0; i < 30; i++)
            {
                lock (_recurso)
                {
                    var aux = $"# passo thread 0 ... {i}";
                    Console.WriteLine(aux);
                    _recurso.Add(aux);
                }
                Thread.Sleep(1000);
            }

            Console.WriteLine("# fim thread 0");

            Console.WriteLine("Como ficou no recurso:");
            foreach (var x in _recurso)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }

        static void ThreadParalela1_Run()
        {
            var nome = Thread.CurrentThread.Name;

            Console.WriteLine("@ inicio thread 1");

            for (int i = 0; i < 30; i++)
            {
                lock (_recurso)
                {
                    var aux = $"@ passo thread 1 ... {i}";
                    Console.WriteLine(aux);

                    _recurso.Add(aux);

                    Thread.Sleep(1000);
                }
            }

            Console.WriteLine("@ fim thread 1");
        }

        static void ThreadParalela2_Run()
        {
            var nome = Thread.CurrentThread.Name;

            Console.WriteLine("& inicio thread 2");

            for (int i = 0; i < 30; i++)
            {
                lock (_recurso)
                {
                    var aux = $"& passo thread 2 ... {i}";
                    Console.WriteLine(aux);

                    _recurso.Add(aux);

                    Thread.Sleep(1000);
                }
            }

            Console.WriteLine("& fim thread 2");
        }
    }

}
