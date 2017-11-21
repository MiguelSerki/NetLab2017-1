using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{

    class Program
    {

        static void Main(string[] args)
        {
            Password pass;
            string input;

            Console.Write("Ingrese un numero para el largo de su contraseña: ");
            if (int.TryParse(Console.ReadLine(), out int result))
                pass = new Password(result);
            else
                pass = new Password();

            do
            {
                Console.Write("Ingrese E para verificar si su clave es segura, C para generar una nueva o F para salir: ");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "e":
                        if (pass.EsFuerte())
                            Console.WriteLine("Su contraseña es segura.");
                        else
                            Console.WriteLine("Su contraseña no es segura!");
                        break;

                    case "c":
                        string inputSN;
                        bool validInput = false;
                        do
                        {
                            Console.Write("Desea generar una nueva contraseña? S / N: ");
                            inputSN = Console.ReadLine().ToLower();
                            if (inputSN.Equals("s") || inputSN.Equals("n"))
                                validInput = true;

                        } while (!validInput);

                        if (inputSN == "s")
                            Console.WriteLine($"Su nueva contraseña es: {pass.GenerarClave(true)}");
                        else
                            Console.WriteLine($"Su contraseña es: {pass.GenerarClave(false)}");
                        break;
                }

            } while (input != "f");

        }
    }

    class Password
    {

        public static string chars = "abcdefghijklmnñopqrstuvwxyz0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

        private string Clave { get; set; }
        public int Longitud { get; set; }

        public Password(int longitud = 8)
        {
            if (longitud > 0)
                Longitud = longitud;
            else
                Longitud = 8;
        }

        public bool EsFuerte()
        {
            bool tieneMayuscula = false;
            bool tieneNumero = false;

            if (Clave == null)
                return false;

            foreach (char caracter in Clave)
            {
                if (Char.IsUpper(caracter))
                    tieneMayuscula = true;
                else if (Char.IsNumber(caracter))
                    tieneNumero = true;
            }

            if (tieneNumero && tieneMayuscula)
                return true;
            else
                return false;

        }

        public string GenerarClave(bool generar)
        {
            if (generar)
            {
                Random random = new Random();
                string claveGenerada = "";

                for (int i = 0; i < Longitud; i++)
                    claveGenerada += chars[random.Next(chars.Length)];

                Clave = claveGenerada;
            }

            if (Clave == null)
                return "No tiene clave!";
            else
                return Clave;
        }

    }
}
