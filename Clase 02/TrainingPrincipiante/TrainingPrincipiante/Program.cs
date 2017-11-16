using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPrincipiante
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ej01();
            //Ej02();
            //Ej03();
            //Ej04();
            //Ej05();
            //Ej06();
            //Ej11();
            //Ej13();
            Ej14();
            Console.Read();
        }

        static void Ej01()
        {
            int x = 2, y = 4, z = 10;
            int suma = x + y + z;
            Console.WriteLine(suma);
        }

        static void Ej02()
        {
            string nombre, ciudad;
            Console.Write("Introduzca su nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Introduzca nombre de la ciudad: ");
            ciudad = Console.ReadLine();
            Console.WriteLine($"Hola {nombre}, bienvenido a {ciudad}!");
        }

        static void Ej03()
        {
            string nombre;
            int edad;
            Console.Write("Introduzca su nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Introduzca su edad: ");
            edad = int.Parse(Console.ReadLine());
            Console.WriteLine($"Te llamas {nombre} y tienes {edad} años");
        }

        static void Ej04()
        {
            int x, y;
            Console.Write("Introduzca el primer nro: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Introduzca el segundo nro: ");
            y = int.Parse(Console.ReadLine());

            if (x > y)
                Console.WriteLine("El primer nro es mayor");
            else if (x < y)
                Console.WriteLine("El segundo nro es mayor");
            else
                Console.WriteLine("Ambos son iguales");
        }

        static void Ej05()
        {
            string dia;
            Console.Write("Ingrese día de la semana: ");
            dia = Console.ReadLine().ToLower();
            switch (dia)
            {
                case "lunes":
                    Console.WriteLine("Día de semana");
                    break;
                case "martes":
                    Console.WriteLine("Día de semana");
                    break;
                case "miercoles":
                    Console.WriteLine("Día de semana");
                    break;
                case "jueves":
                    Console.WriteLine("Día de semana");
                    break;
                case "viernes":
                    Console.WriteLine("Día de semana");
                    break;
                case "sabado":
                    Console.WriteLine("Fin de semana");
                    break;
                case "domingo":
                    Console.WriteLine("Fin de semana");
                    break;
                default:
                    Console.WriteLine($"Error el día {dia} no existe!");
                    break;
            }
        }

        static void Ej06()
        {
            int monto;
            string formaDePago;
            Console.Write("Introduzca monto a pagar: ");
            monto = int.Parse(Console.ReadLine());
            Console.Write("Introduzca E para pagar con efectivo o T para pagar con tarjeta: ");
            formaDePago = Console.ReadLine().ToLower();
            if (formaDePago == "t")
                Console.WriteLine($"Usted ha pagado {monto}$ con tarjeta");
            else
                Console.WriteLine($"Usted ha pagado {monto}$ con efectivo");
        }

        static void Ej11()
        {
            List<Item> pedido = new List<Item>();
            bool pedir = true;

            while (pedir)
            {
                Item n = new Item();
                Console.Write("Introduzca nombre del producto: ");
                n.nombre = Console.ReadLine();
                Console.Write("Introduzca la cantidad: ");
                n.cantidad = int.Parse(Console.ReadLine());
                pedido.Add(n);
                Console.WriteLine("Quiere pedir algo más? S/N: ");
                string seguir = Console.ReadLine().ToLower();
                if (seguir != "s")
                    pedir = false;
            }

            Console.WriteLine();
            Console.WriteLine("Su pedido es:");
            foreach (Item i in pedido)
            {
                Console.WriteLine($"{i.cantidad} de {i.nombre}");
            }

        }

        static void Ej13()
        {
            List<Cliente> clientes = new List<Cliente>();
            int DineroTotal = 0;

            Cliente x = new Cliente
            {
                ClienteId = 1,
                DineroDepositado = 2500
            };
            clientes.Add(x);

            x = new Cliente
            {
                ClienteId = 1,
                DineroDepositado = 200
            };
            clientes.Add(x);

            x = new Cliente
            {
                ClienteId = 1,
                DineroDepositado = 250
            };
            clientes.Add(x);

            foreach (Cliente cliente in clientes)
            {
                DineroTotal += cliente.DineroDepositado;
            }

            Console.WriteLine($"El dinero total en el banco es ${DineroTotal}");
        }

        static void Ej14()
        {
            Persona p1 = new Persona { Nombre = "Javier", Edad = 25 };
            p1.ObtenerDatos();
        }

    }

    class Item
    {
        public string nombre { get; set; }
        public int cantidad { get; set; }
    }

    class Cliente
    {

        public int ClienteId { get; set; }
        public int DineroDepositado { get; set; }


        public void Depositar(int monto)
        {
            DineroDepositado += monto;
            Console.WriteLine($"Usted ha depositado {monto}$");
        }

        public void Extraer(int monto)
        {
            DineroDepositado -= monto;
            Console.WriteLine($"Usted ha extraido {monto}$");
        }
    }

    class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public void ObtenerDatos()
        {
            if (Edad >= 18)
                Console.WriteLine($"El nombre de la persona es {Nombre}, y es mayor de edad");
            else
                Console.WriteLine($"El nombre de la persona es {Nombre}, y es menor de edad");
        }
    }

}
