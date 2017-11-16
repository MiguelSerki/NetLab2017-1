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
//7)Contar los multiplos de 3 desde la unidad hasta un nro ingresado        X
//8)Ingresar 10 nros, sumar los + y mutiplicar los -                        X
//9)Ingresar dos nros e intercambiarlos                                     X
//10)Ingresar un nro y mostrar su cuadrado y cubo                           X
//11)Ingresar x cant de pesos y mostrar la cant de personas que pesan
//+ de 80 y - de 80                                                         X
//12)Ingresar 3 datos y decir que la clase de triangulo es.
//Para formar un triangulo hay que tener en cuenta que la suma
//de sus dos lados inferiores tiene que ser mayor que el lado
//superior                                                                  X
//13)Dados 3 nros donde el primero y el ultimo son limites de un
//intervalo, indicar si el tercero eprtenece a dicho intervalo              X
//14)Realizar la tabla de multiplicar de un nro ingresado entre
//0 y 10 de forma que se visualice de la siguiente forma: 4x1=4, 4x2=8
//15)Ingresar 2 nros, imrprima los nros naturales que hay entre ambos
//empezando por el mas pequeño, contar cuantos nros hay y cuantos de
//ellos son pares.

namespace Listas
{
    class Program
    {
        private static List<int> numbers = new List<int>();

        static void Main(string[] args)
        {
            GenerateNumbers();
            /*ShowOdds();
            ShowEvens();
            ShowMulti3();
            ShowMulti2And3();
            ShowPreviousSuma();
            ShowPrevious();
            ShowPreviousMulti3();*/

            //SumaYMulti(10);
            //AlternarNros();
            //CuadradoYCubo();
            //ShowPesos(5);
            //CheckTriangle();
            CheckIntermedio();
            Console.Read();
        }

        static void CheckIntermedio()
        {
            int n = 0;
            int[] nros = new int[3];

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Introduzca un numero: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                    n = int.Parse(input);

                nros[i] = n;
            }

            if (nros[1] < nros[2] && nros[1] > nros[0])
                Console.WriteLine("Existe");
            else
                Console.WriteLine("No Existe");
        }

        static void CheckTriangle()
        {
            int x = 0, y = 0, z = 0;
            int[] menores = new int[2];
            int mayor = 0;
            bool iguales = false;

            Console.Write("Introduzca primer lado: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                x = int.Parse(input);

            Console.Write("Introduzca segundo lado: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int result2))
                y = int.Parse(input);

            Console.Write("Introduzca segundo lado: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int result3))
                z = int.Parse(input);


            if (x == y && y == z)
            {
                iguales = true;
            }
            else if (x < y)
            {
                menores[0] = x;
                if (y < z)
                {
                    menores[1] = y;
                    mayor = z;
                }
                else
                {
                    menores[1] = z;
                    mayor = y;
                }
            }
            else
            {
                menores[0] = y;
                if (x < z)
                {
                    menores[1] = x;
                    mayor = z;
                }
                else
                {
                    menores[1] = z;
                    mayor = x;
                }
            }

            if (iguales || (menores[0] + menores[1]) > mayor)
            {
                if (x == y && y == z)
                {
                    Console.WriteLine("Triangulo equilátero");
                }
                else if (x == y || x == z || y == z)
                {
                    Console.WriteLine("Triangulo isósceles");
                }
                else
                {
                    Console.WriteLine("Triangulo escaleno");
                }
            }
            else
            {
                Console.WriteLine("OSO!");
            }

        }

        static void ShowPesos(int cantidad)
        {
            int n = 0;
            const int pesoLimite = 80;
            int pesosMenores = 0;
            int pesosMayores = 0;

            for (int i = 0; i < cantidad; i++)
            {

                Console.Write("Introduzca un peso: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                    n = int.Parse(input);

                if (n > pesoLimite)
                    pesosMayores++;
                else
                    pesosMenores++;
            }

            Console.WriteLine($"Hay un total de {pesosMayores} personas que pasan el limite y {pesosMenores} que no");

        }

        static void CuadradoYCubo()
        {
            int nro = 0;

            Console.Write("Introduzca un numero: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                nro = int.Parse(input);

            Console.WriteLine($"Cuadrado: {nro * nro}, Cubo: {nro * nro * nro}");
        }

        static void AlternarNros()
        {
            int x = 0, y = 0, xAux = 0;

            Console.Write("Introduzca primer numero: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                x = int.Parse(input);

            Console.Write("Introduzca segundo numero: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int result2))
                y = int.Parse(input);

            xAux = x;
            x = y;
            y = xAux;

            Console.Write($"Resultado de variables alternadas: x={x} y={y}");

        }

        static void SumaYMulti(int cantidad)
        {
            List<int> nros = new List<int>();
            List<int> nrosNeg = new List<int>();
            int n = 0;

            for (int i = 0; i < cantidad; i++)
            {

                Console.Write("Introduzca un numero: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                    n = int.Parse(input);

                if (n > 0)
                    nros.Add(n);
                else if (n < 0)
                    nrosNeg.Add(n);
            }

            int resultadoSuma = 0;
            int resultadoMult = 1;

            for (int i = 0; i < nros.Count; i++)
            {
                resultadoSuma += nros[i];
            }

            for (int i = 0; i < nrosNeg.Count; i++)
            {
                resultadoMult *= nrosNeg[i];
            }

            Console.WriteLine($"Resultado de nros positivos: {resultadoSuma}, nros negativos: {resultadoMult}");

        }

        static void GenerateNumbers()
        {
            for (int i = 0; i <= 100; i++)
            {
                numbers.Add(i);
            }
        }

        static void ShowOdds()
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

        static void ShowEvens()
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

        static void ShowMulti3()
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

        static void ShowMulti2And3()
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

        static void ShowPreviousSuma()
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

        static void ShowPrevious()
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

        static void ShowPreviousMulti3()
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