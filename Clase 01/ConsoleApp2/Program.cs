using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//int.Parse(x)
//Convert.ToInt32(x)
//int.TryParse(a,out in int3)

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int x, y;
            Console.Write("Primer numero: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int result) == true)
                x = int.Parse(input);
            else
                x = 0;
            Console.Write("Segundo numero: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int result2) == true)
                y = int.Parse(input);
            else
                y = 0;

            Resultado errorDetectado = ejecutarCalculadora(x,y);
            if (!errorDetectado.error)
            {
                Console.Write("Tercer numero: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int result3) == true)
                    y = int.Parse(input);
                else
                    y = 0;
                errorDetectado = ejecutarCalculadora(errorDetectado.valor, y);
                Console.Read();
            }
           
        }

        static Resultado ejecutarCalculadora(int x, int y)
        {
            Resultado resultado = new Resultado();
            Console.Write("S suma, R resta, D divicion, M Multiplicacion: ");
            string f = Console.ReadLine().ToLower();
            switch (f)
            {
                case "r":
                    resultado.valor = Resta(x, y);
                    Console.WriteLine("Resultado: " + resultado.valor);
                    break;
                case "m":
                    resultado.valor = Multiplicacion(x, y);
                    Console.WriteLine("Resultado: " + resultado.valor);
                    break;
                case "d":
                    resultado.valor = Division(x, y);
                    if (resultado.valor != -1)
                        Console.WriteLine("Resultado: " + resultado.valor);
                    else
                        resultado.error = true;
                    break;
                case "s":
                    resultado.valor = Suma(x, y);
                    Console.WriteLine("Resultado: " + resultado.valor);
                    break;
                default:
                    resultado.error = true;
                    return resultado;
            }
            
            return resultado;
        }

        static int Suma(int x, int y)
        {
            return (x + y);
        }

        static int Resta(int x, int y)
        {
            return (x - y);
        }

        static int Division(int x, int y)
        {
            if (y == 0)
            {
                Console.WriteLine("COMO VAS A DIVIDIR POR CERO CHABON???");
                return -1;
            }
            return (x / y);
        }

        static int Multiplicacion(int x, int y)
        {
            return (x * y);
        }
    }

    class Resultado
    {
        public int valor;
        public bool error;
    }
}
