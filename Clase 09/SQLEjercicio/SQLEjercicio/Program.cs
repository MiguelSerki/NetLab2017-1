using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SQLEjercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio01();
            Ejercicio02();


            //var shipper = context.Shippers.Include(c => c.Orders);
            //.FirstOrDefault(c => c.ShipperID == 1);

            //shipper = shipper.Where(c => c.ShipperID == 1);

            /*
            var context = new Context();
            var category = new Category();
            context.Entry(category).State = EntityState.Added;
            */

            //using(var transaction = context.Database.BeginTransaction())
        }

        static void Ejercicio01()
        {
            var context = new Context();

            foreach (var employee in context.Employees.Include(e => e.Territories.Select(t => t.Region)).AsNoTracking())
            {
                Console.WriteLine($"{employee.TitleOfCourtesy} {employee.LastName} " +
                    $"{employee.FirstName}, {employee.City}");

                foreach (var territory in employee.Territories)
                {
                    Console.WriteLine($"{territory.TerritoryDescription.Trim()} - {territory.Region.RegionDescription}");
                }
                Console.WriteLine();
            }


            Console.Read();
        }

        static void Ejercicio02()
        {
            Console.WriteLine("ABM DE CATEGORIAS");
            var input = "";
            do
            {
                Console.WriteLine("Ingrese M para modificar categoria, D para borrar categoria, C para crear una nueva, Q para salir.");
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "m":
                        EditarCategoria();
                        break;
                    case "d":
                        BorrarCategoria();
                        break;
                    case "c":
                        CrearCategoria();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando invalido...");
                        break;
                }
            } while (input != "q");
        }

        static void EditarCategoria()
        {
            Console.Write("Ingrese ID de la categoria: ");
            int.TryParse(Console.ReadLine(), out int resultId);
            if (resultId > 0)
            {
                using (var context = new Context())
                {
                    try
                    {
                        var category = context.Categories
                            .First(c => c.CategoryID == resultId);

                        Console.WriteLine($"Nombre de la categoria: {category.CategoryName}");

                        Console.Write("Ingrese nuevo nombre para la categoria: ");
                        var input = Console.ReadLine();
                        if (input != "")
                            category.CategoryName = input;
                        Console.Write("Ingrese nueva descripcion para la categoria: ");
                        input = "";
                        input = Console.ReadLine();
                        if (input != "")
                            category.Description = input;

                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error, no existe la categoria...");
                    }
                }
            }
            else
                Console.WriteLine("ID erronea...");
        }

        static void BorrarCategoria()
        {
            Console.Write("Ingrese ID de la categoria: ");
            int.TryParse(Console.ReadLine(), out int resultId);
            if (resultId > 0)
            {
                using (var context = new Context())
                {
                    try
                    {
                        var category = context.Categories
                            .Include(p => p.Products)
                            .First(c => c.CategoryID == resultId);

                        if (category.Products.Any())
                        {
                            Console.WriteLine("Error, no se puede eliminar una categoria con productos asociados...");
                        }
                        else
                        {
                            context.Categories.Remove(category);
                            context.SaveChanges();
                            Console.WriteLine("Categoria eliminada correctamente");
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error, no existe la categoria...");
                    }
                }
            }
            else
                Console.WriteLine("Error, ID erronea...");

        }

        static void CrearCategoria()
        {

            using (var context = new Context())
            {
                var category = new Category();

                Console.Write("Ingrese nuevo nombre para la categoria: ");
                var input = Console.ReadLine();
                if (input != "")
                    category.CategoryName = input;
                Console.Write("Ingrese nueva descripcion para la categoria: ");
                input = "";
                input = Console.ReadLine();
                if (input != "")
                    category.Description = input;

                context.Categories.Add(category);
                context.SaveChanges();

                Console.WriteLine("Categoria creada con exito.");
            }
        }
    }


}
