using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaYPila
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Cola<int> cola = new Cola<int>();
            cola.Agregar(5);
            cola.Agregar(7);
            cola.Agregar(10);
            Console.WriteLine(cola.Cantidad());
            Console.WriteLine(cola.Tomar());
            Console.WriteLine(cola.Tomar());
            Console.WriteLine(cola.Cantidad());
            Console.Read();
            */
            Pila<int> pila = new Pila<int>();
            pila.Agregar(5);
            pila.Agregar(7);
            pila.Agregar(10);
            Console.WriteLine(pila.Cantidad());
            Console.WriteLine(pila.Tomar());
            Console.WriteLine(pila.Tomar());
            Console.WriteLine(pila.Cantidad());
            Console.Read();
        }
    }
}
