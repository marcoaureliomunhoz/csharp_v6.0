using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseObject1
{
    public class Ponto
    {
        private int _x = 0;
        private int _y = 0;
        
        public Ponto(int x, int y)
        {
            SetPosicao(x, y);
        }

        public void SetPosicao(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public override string ToString()
        {
            return "(" + _x.ToString() + ";" + _y.ToString() + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj is Ponto)
            {
                Ponto p = (Ponto)obj;
                return p.GetX() == _x && p.GetY() == _y;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Tipos Básicos ---");

            Console.WriteLine("{0}", "marco".GetHashCode());
            Console.WriteLine("{0}", "marco".Equals("marco"));
            Console.WriteLine("{0}", "marco".GetType());
            Console.WriteLine("{0}", 51.ToString());
            Console.WriteLine("{0}", 51.GetType());
            Console.WriteLine("{0}", 51.Equals("uma boa ideia"));
            Console.WriteLine("{0}", 51.Equals("51"));
            Console.WriteLine("{0}", 51.Equals(51));

            Console.WriteLine("--- Tipos Complexos ---");

            Ponto p1 = new Ponto(20, 50);
            Ponto p2 = new Ponto(30, 40);

            Console.WriteLine("{0}", p1.ToString());
            Console.WriteLine("{0}", p2.ToString());

            Console.WriteLine("{0}", p1.Equals(p2));

            p1.SetPosicao(p2.GetX(), p2.GetY());
            Console.WriteLine("{0}", p1.Equals(p2));

            Console.ReadKey();
        }
    }
}
