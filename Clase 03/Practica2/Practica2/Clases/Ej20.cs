using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Clases
{
    class Ej20
    {
        public static List<Pelicula> Peliculas;
        public static List<Cliente> Clientes;
        public static List<Alquiler> Alquileres;


        public void Menu()
        {
            string input;

            Console.WriteLine("Menu de administración de videoclub.");
            Console.WriteLine("Introduzca H para recibir ayuda.");
            do
            {
                Console.Write(">");
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "a":
                        AgregarPelicula();
                        break;
                    case "b":
                        AgregarCliente();
                        break;
                    case "c":
                        AlquilarPelicula();
                        break;
                    case "d":
                        HistorialCLiente();
                        break;
                    case "e":
                        ListaAlquileres();
                        break;
                    case "h":
                        Ayuda();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando desconocido, introduzca H para recibir ayuda.");
                        break;
                }

            } while (input != "q");
        }

        public void AgregarPelicula()
        {

        }

        public void AgregarCliente()
        {

        }

        public void AlquilarPelicula()
        {

        }

        public void HistorialCLiente()
        {

        }

        public void ListaAlquileres()
        {

        }

        public void Ayuda()
        {
            Console.WriteLine("A: Agregar una película al inventario.");
            Console.WriteLine("B:  Agregar un cliente.");
            Console.WriteLine("C:  Alquiler de una película.");
            Console.WriteLine("D: Historial de alquiler de cliente.");
            Console.WriteLine("E:  Lista de alquileres.");
            Console.WriteLine("H:  Lista de comandos.");
        }
    }

    class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Precio { get; set; }
        public int PlazoAlquiler { get; set; }
        public bool Alquilado { get; set; }
    }

    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public List<Pelicula> Alquilados { get; set; }

    }

    class Alquiler
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Pelicula Pelicula { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int Importe { get; set; }
    }

}
