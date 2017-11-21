using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Clases
{
    class Ej20
    {
        public static List<Pelicula> Peliculas = new List<Pelicula>();
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Alquiler> Alquileres = new List<Alquiler>();


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
            Pelicula pelicula = new Pelicula();

            pelicula.Id = Peliculas.Count() + 1;
            Console.Write("Titulo: ");
            pelicula.Titulo = Console.ReadLine();
            Console.Write("Precio: ");
            if (int.TryParse(Console.ReadLine(), out int precio))
                pelicula.Precio = precio;
            Console.Write("Plazo alquiler: ");
            if (int.TryParse(Console.ReadLine(), out int plazo))
                pelicula.PlazoAlquiler = plazo;

            Peliculas.Add(pelicula);
        }

        public void AgregarCliente()
        {
            Cliente cliente = new Cliente();

            cliente.Id = Clientes.Count() + 1;
            Console.Write("Nombre: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            cliente.Direccion = Console.ReadLine();
            if (int.TryParse(Console.ReadLine(), out int telefono))
                cliente.Telefono = telefono;

            Clientes.Add(cliente);
        }

        public void AlquilarPelicula()
        {
            Alquiler alquiler = new Alquiler();
            alquiler.Id = Alquileres.Count() + 1;
            Console.Write("Id de cliente: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                foreach (var cliente in Clientes)
                {
                    if (cliente.Id == id)
                    {
                        alquiler.Cliente = cliente;
                        break;
                    }
                }
            Console.Write("Id de pelicula: ");
            if (int.TryParse(Console.ReadLine(), out int peliculaId))
                foreach (var pelicula in Peliculas)
                {
                    if (pelicula.Id == peliculaId)
                    {
                        alquiler.Pelicula = pelicula;
                        break;
                    }
                }
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                alquiler.FechaAlquiler = fecha;
                alquiler.FechaDevolucion = fecha.AddDays(alquiler.Pelicula.PlazoAlquiler);
            }
            alquiler.Importe = alquiler.Pelicula.Precio;

            alquiler.Cliente.Alquilados.Add(alquiler);
            Alquileres.Add(alquiler);
        }

        public void HistorialCLiente()
        {

            Console.Write("Ingrese el id del cliente: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                foreach (var c in Clientes)
                {
                    if (c.Id == id)
                    {
                        foreach (var a in c.Alquilados)
                        {
                            Console.WriteLine($"Alquiler Id: {a.Id}, Pelicula: {a.Pelicula.Titulo}, Entrega: {a.FechaDevolucion}, Importe: {a.Importe}");
                        }
                        break;
                    }
                }
        }

        public void ListaAlquileres()
        {
            foreach (var alquiler in Alquileres)
            {
                Console.WriteLine($"Id: {alquiler}, Cliente: {alquiler.Cliente.Nombre}, Pelicula: {alquiler.Pelicula.Titulo}, Entrega: {alquiler.FechaDevolucion}, Importe: {alquiler.Importe}");
            }
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

    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Precio { get; set; }
        public int PlazoAlquiler { get; set; }
        public bool Alquilado { get; set; }
    }

    public class Cliente
    {
        public Cliente()
        {
            Alquilados = new List<Alquiler>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public List<Alquiler> Alquilados { get; set; }

    }

    public class Alquiler
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Pelicula Pelicula { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int Importe { get; set; }
    }

}
