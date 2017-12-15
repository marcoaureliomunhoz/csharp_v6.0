using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramacaoParalelaThreading2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# inicio thread principal");

            var threadParalela = Task.Run(() => {
                Console.WriteLine("@ inicio thread paralela");
                for (var i = 0; i < 100; i++)
                {
                    Console.WriteLine($"@ passo thread paralela ... {i}");
                    Thread.Sleep(500);
                }
                Console.WriteLine("@ fim thread paralela");
            });

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine($"# passo thread principal ... {i}");
                Thread.Sleep(500);
            }

            Console.WriteLine("# fim thread principal");

            Console.ReadKey();
        }
    }
}
