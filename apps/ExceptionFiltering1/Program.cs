using System;
using static System.Console;


namespace ExceptionFiltering1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = 0;
                int x = 10 / n;
            }
            catch (Exception ex) when (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                //envia e-mail para o gerente
                WriteLine("e-mail para o gerente");
            }
            catch (Exception ex)
            {
                //envia e-mail para o suporte
                WriteLine("e-mail para o suporte");
            }
            ReadKey();
        }
    }
}
