using System;
using static System.Console;

namespace ExpressionBodiedMembers1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(GetDataFormatada());
            WriteLine(GetDataFormatadaExp());
            ReadKey();
        }

        //Sem Expression
        static string GetDataFormatada()
        {
            return "Hoje é " + DateTime.Now.ToLongDateString();
        }

        //Com Expression
        static string GetDataFormatadaExp() => "Hoje é " + DateTime.Now.ToLongDateString();
    }
}
