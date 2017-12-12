using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposBasicos1
{
    class Program
    {
        static void Main(string[] args)
        {
            short valorInt16 = 16;
            int valorInt32 = 32;
            long valorInt64 = 64;
            byte menorByte = 0;
            sbyte menorSByte = -128;
            float valorFloat = 3.4f;

            Console.WriteLine("{0}", valorInt16.GetType());
            Console.WriteLine("{0}", valorInt32.GetType());
            Console.WriteLine("{0}", valorInt64.GetType());
            Console.WriteLine("{0}", menorByte.GetType());
            Console.WriteLine("{0}", menorSByte.GetType());
            Console.WriteLine("{0}", valorFloat.GetType());

            Console.ReadKey();
        }
    }
}
