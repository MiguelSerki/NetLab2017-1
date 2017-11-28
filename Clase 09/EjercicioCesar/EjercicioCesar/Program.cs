using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace ConsoleApp
{
    class Program
    {

        static CustomerService service = new CustomerService();

        static void Main(string[] args)
        {
            Console.WriteLine("Clientes C.R.U.D:");
            var input = "";
            do
            {
                Console.WriteLine("C: Create, R: Read, U: Update, D: Delete, Q: Quit");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "c":
                        CreateMenu();
                        break;
                    case "r":
                        ReadMenu();
                        break;
                    case "u":
                        UpdateMenu();
                        break;
                    case "d":
                        DeleteMenu();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando invalida...");
                        break;
                }
            } while (input != "q");
        }

        static void CreateMenu() { }

        static void ReadMenu()
        {
            Console.WriteLine("A: Mostrar todos, S: Mostrar uno, Q: volver atras:");
            var input = "";
            do
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        var customers = service.ReadCustomers();
                        foreach (var c in customers)
                        {
                            Console.WriteLine($"ID: {c.CustomerID}");
                            Console.WriteLine($"Nombre:{c.ContactName}");
                            Console.WriteLine($"Compania: {c.CompanyName} ({c.ContactTitle})");
                            Console.WriteLine($"{c.Address}, {c.City}({c.PostalCode}), {c.Country}");
                            Console.WriteLine($"Telefono: {c.Phone}, Fax: {c.Fax}");
                            Console.WriteLine();
                        }
                        return;
                    case "s":

                        return;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando invalido...");
                        break;
                }
            } while (input != "q");

        }


        static void UpdateMenu() { }

        static void DeleteMenu() { }

    }
}
