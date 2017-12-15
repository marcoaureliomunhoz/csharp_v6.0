using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramacaoParalelaThreading3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# main - ini #");

            //executa o processo principal e aguarda
            ProcessoPrincipal().Wait();

            Console.WriteLine("# main - fim #");
            
            Console.ReadKey();
        }

        static async Task ProcessoPrincipal()
        {
            //processamento inicial
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Processo1");
                Thread.Sleep(500);
            }

            //cria uma task especial que executa em paralelo
            var processo2 = ProcessoAsync();

            //aqui não precisamos do retorno de processo2
            //então podemos executar
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Processo3");
                Thread.Sleep(500);
            }

            //aqui precisamos do resultado do processo2
            //não podemos continuar, temos que esperar
            var resultado = await processo2;

            //agora sim, depois de obter o resultado do processo2
            //podemos executar o processo4
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Processo4 => {resultado}");
                Thread.Sleep(500);
            }
        }

        //processamento "pesado"
        static async Task<string> ProcessoAsync()
        {
            for (int i=0; i<5; i++)
            {
                Console.WriteLine("ProcessoAsync - bloco1");
            }

            Console.WriteLine("ProcessoAsync - bloco2");

            //quando chegar aqui, ou seja, ao encontrar um await dentro de um método async Task
            //é que o processamento assíncrono ocorre
            await Task.Delay(10000);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ProcessoAsync - bloco3");
            }

            return "resultado_do_processamento_assincrono";
        }
    }
}
