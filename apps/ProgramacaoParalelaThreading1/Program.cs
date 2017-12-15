using System;
using System.Diagnostics;
using System.Threading;

namespace ProgramacaoParalelaThreading1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"PID: {Process.GetCurrentProcess().Id}");

            Console.ReadKey();

            Console.WriteLine("[bloco sem thread]");

            var dh1_ini = DateTime.Now;

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine($"# tarefa 1 - passo {i}");
                Thread.Sleep(500);
            }

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine($"# tarefa 2 - passo {i}");
                Thread.Sleep(500);
            }

            var dh1_fim = DateTime.Now;
            var dh1_tot = dh1_fim.Subtract(dh1_ini);

            Console.WriteLine($"> Total de segundos: {dh1_tot.TotalSeconds}");

            Console.WriteLine("[bloco com thread]");

            var dh2_ini = DateTime.Now;

            Console.WriteLine("# inicio thread principal");

            var threadParalela = new Thread(ThreadParalela_Run);
            threadParalela.Start();

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine($"# passo thread principal ... {i}");
                Thread.Sleep(500);
            }

            Console.WriteLine("# fim thread principal");

            var dh2_fim = DateTime.Now;
            var dh2_tot = dh2_fim.Subtract(dh2_ini);

            Console.WriteLine($"> Total de segundos: {dh2_tot.TotalSeconds}");

            Console.ReadKey();
        }

        static void ThreadParalela_Run()
        {
            Console.WriteLine("@ inicio thread paralela");
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine($"@ passo thread paralela ... {i}");
                Thread.Sleep(500);
            }
            Console.WriteLine("@ fim thread paralela");
        }        
    }
}
