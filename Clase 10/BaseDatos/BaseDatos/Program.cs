using BaseDatos.Datos;
using BaseDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BaseDatos
{
    public class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var optionSelected = ArrowMenu("Manejo de Datos", new string[] { "Crear ciudad", "Crear empleado", "Empleados de ciudad", "Mostrar supervisores", "Salir" });
                Console.Clear();
                switch (optionSelected)
                {
                    case 0:
                        CrearCiudad();
                        break;
                    case 1:
                        CrearEmpleado();
                        break;
                    case 2:
                        MostrarEmpleados();
                        break;
                    case 3:
                        MostrarSupervisores();
                        break;
                    default:
                        return;
                }
            } while (true);
        }

        public static int ArrowMenu(string menu, string[] menuItems)
        {
            var curItem = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();

                Console.WriteLine("   ================================");
                Console.WriteLine("\t" + menu);
                Console.WriteLine("   ================================\n");

                Console.WriteLine("Move with up and down arrows, press enter to select:\n");

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (curItem == i)
                    {
                        Console.Write("=> ");
                        Console.WriteLine(menuItems[i]);
                    }
                    else
                        Console.WriteLine($"   {menuItems[i]}");
                }

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow" && curItem < menuItems.Length - 1)
                    curItem++;
                else if (key.Key.ToString() == "UpArrow" && curItem > 0)
                    curItem--;

            } while (key.KeyChar != 13); //13 = Enter

            return curItem;
        }


        public static void CrearCiudad()
        {

            Console.Write("Ingrese nombre de la ciudad: ");
            var name = Console.ReadLine();

            var city = new City()
            {
                Name = name
            };

            using (var context = new Context())
            {
                context.Cities.Add(city);
                context.SaveChanges();
            }

            Console.WriteLine("Ciudad creada con exito!");
            Console.Read();
        }

        public static void CrearEmpleado()
        {
            var employee = new Employee();

            Console.Write("Ingrese nombre: ");
            employee.Name = Console.ReadLine();

            Console.Write("Ingrese apellido: ");
            employee.Surname = Console.ReadLine();

            Console.Write("Ingrese edad: ");
            int.TryParse(Console.ReadLine(), out int result);
            employee.Age = result;

            Console.Write("Ingrese posición: ");
            employee.Position = Console.ReadLine();


            using (var context = new Context())
            {
                City city;

                do
                {
                    Console.Write("Ingrese una ciudad validad: ");
                    var cityToSearch = Console.ReadLine();

                    city = context.Cities.FirstOrDefault(c => c.Name == cityToSearch);

                } while (city == null);

                employee.City = city;
                context.Employees.Add(employee);
                context.SaveChanges();
            }

            Console.WriteLine("Empleado creado con exito");
            Console.Read();
        }

        public static void MostrarEmpleados() {

            Console.WriteLine("Ingrese nombre de la ciudad: ");
            var cityToSearch = Console.ReadLine();
            City city;

            using (var context = new Context())
            {
               city  = context.Cities
                    .Include(c => c.Employees)
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Name == cityToSearch);
            }

            if (city != null)
            {
                Console.WriteLine("\nLos empleados son:");

                foreach (var e in city.Employees)
                {
                    Console.WriteLine($"{e.Name} {e.Surname}");
                }
            }
            else
                Console.WriteLine("No existe la ciudad!");

            Console.Read();
        }

        public static void MostrarSupervisores()
        {
            var supervisorId = 0;

            using (var context = new Context())
            {
                var data = context.Employees.FirstOrDefault(c => c.Id == supervisorId).Employees;

                if (data.Any())
                {
                    foreach (var e in data)
                    {
                        Console.WriteLine($"{e.Name} {e.Surname}: ${e.SueldoMensual * DateTime.Today.Month}");
                    }
                }
            }
        }

    }

}
