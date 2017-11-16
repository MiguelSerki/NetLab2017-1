using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1)Mostrar los nros impares entre el 0 y el 100                            X
//2)Mostrar los nros pares entre el 0 y el 100                              X
//3)Mostrar los multiplos de 3 del 0 al 100                                 X
//4)Mostrar los multiplos de 3 y de 2 entre el 0 y 100                      X
//5)Ingresar un nro y mostrar la suma de los nros que lo anteceden          X
//6)Mostrar los nros del 1 hasta el nro ingresado                           X
//7)Contar los multiplos de 3 desde la unidad hasta un nro ingresado

namespace Listas
{
    class Program
    {
        private static List<int> numbers = new List<int>();

        static void Main(string[] args)
        {
            generateNumbers();
            showOdds();
            showEvens();
            showMulti3();
            showMulti2And3();
            showPreviousSuma();
            showPrevious();
            showPreviousMulti3();
            Console.Read();
        }

        static void generateNumbers()
        {
            for (int i = 0; i <= 100; i++)
            {
                numbers.Add(i);
            }
        }

        static void showOdds()
        {
            Console.WriteLine("Numeros impares del 0 al 100:");
            foreach (int n in numbers)
            {
                if (n % 2 != 0)
                    Console.Write(n + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void showEvens()
        {
            Console.WriteLine("Numeros pares del 0 al 100:");
            foreach (int n in numbers)
            {
                if (n % 2 == 0)
                    Console.Write(n + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void showMulti3()
        {
            Console.WriteLine("Numeros multiplos de 3 del 0 al 100:");
            foreach (int n in numbers)
            {
                if (n % 3 == 0)
                    Console.Write(n + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void showMulti2And3()
        {
            Console.WriteLine("Numeros multiplos de 2 y 3 del 0 al 100:");
            foreach (int n in numbers)
            {
                if (n % 3 == 0 || n % 2 == 0)
                    Console.Write(n + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void showPreviousSuma()
        {
            Console.Write("Ingrese un numero para sumar sus antecesores: ");
            int n = 0;
            int sumaTotal = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                n = int.Parse(input);

            for (int i = 0; i <= n; i++)
            {
                sumaTotal += i;
            }

            Console.WriteLine("El resultado de la suma es: " + sumaTotal);

            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void showPrevious()
        {
            Console.Write("Ingrese un numero para ver sus antecesores: ");
            int n = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                n = int.Parse(input);

            for (int i = 1; i < n; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void showPreviousMulti3()
        {
            Console.Write("Ingrese un numero para ver sus antecesores multiplos de 3: ");
            int n = 0;
            int cant = 0;
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                n = int.Parse(input);

            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0)
                {
                    cant++;
                }
            }

            Console.WriteLine("Hay " + cant + " nros previos al ingresado.");
            Console.WriteLine();
        }


    }
}