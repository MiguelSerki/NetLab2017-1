﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO.Classes;

namespace TP_POO
{
    class Program
    {
        public static List<Seller> sellers = new List<Seller>();
        public static List<Supervisory> supervisors = new List<Supervisory>();

        static void Main(string[] args)
        {
            var input = "";
            while (input != "q")
            {
                Console.WriteLine("Ingrese 'A' para agregar un empleado, 'C' para calcular sueldo, 'M' para mejores renumerados, 'Q' para salir");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "a":
                        AddEmployee();
                        break;
                    case "c":
                        CalculateSalary();
                        break;
                    case "m":
                        BetterPaid();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando invalido...");
                        break;
                }

            }

        }

        static void AddEmployee()
        {
            var input = "";
            while (input != "q")
            {
                Console.WriteLine("Ingrese 'V' para agregar a un vendedor, 'S' para agregar a un supervisor, 'Q' para volver atrás");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "v":
                        sellers.Add(DataInput(new Seller()));
                        break;
                    case "s":
                        var type = "";
                        do
                        {
                            Console.WriteLine("Ingrese tipo de supervisor: 'A', 'B' o 'C'");
                            type = Console.ReadLine().ToLower();
                            switch (type)
                            {
                                case "a":
                                    supervisors.Add(DataInput(new SupervisoryA()));
                                    break;
                                case "b":
                                    supervisors.Add(DataInput(new SupervisoryB()));
                                    break;
                                case "c":
                                    supervisors.Add(DataInput(new SupervisoryC()));
                                    break;
                                default:
                                    Console.WriteLine("Error, comando invalido...");
                                    break;
                            }

                        } while (type != "a" && type != "b" && type != "c");
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando invalido...");
                        break;
                }
            }

        }

        static void CalculateSalary()
        {
            var input = "";
            do
            {
                Console.WriteLine("Ingrese 'A' para calcular el sueldo de un empleado, 'B' para todos los empleados, 'Q' para volver atrás");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "a":
                        Console.WriteLine("Ingrese DNI del empleado");
                        string doc = Console.ReadLine();
                        IPerson employee;

                        try
                        {
                            employee = sellers.Where(c => c.Identification.Equals(doc)).First();
                        }
                        catch (Exception)
                        {
                            employee = supervisors.Where(c => c.Identification.Equals(doc)).FirstOrDefault();
                        }
                        

                        try
                        {
                            Console.WriteLine($"{employee.Name} {employee.Surname}: {employee.CalculateSalary()}$");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No existe el empleado");
                        }

                        break;
                    case "b":
                        Console.WriteLine("Supervisores:");
                        foreach (var emp in supervisors)
                            Console.WriteLine($"{emp.Name} {emp.Surname}: {emp.CalculateSalary()}$");
                        Console.WriteLine("Vendedores:");
                        foreach (var emp in sellers)
                            Console.WriteLine($"{emp.Name} {emp.Surname}: {emp.CalculateSalary()}$");
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Error, comando invalido...");
                        break;
                }
            } while (input != "q");
        }

        static void BetterPaid()
        {
            IPerson employee = null;

            try
            {
                Console.WriteLine("El vendedor mejor renumerado es:");
                employee = sellers.OrderByDescending(x => x.CalculateSalary()).First();
                Console.WriteLine($"{employee.Name} {employee.Surname}: {employee.CalculateSalary()}$");
            }
            catch (Exception)
            {
                Console.WriteLine("No existe ningún vendedor");
            }

            try
            {
                employee = null;
                Console.WriteLine("El supervisor mejor renumerado es:");
                employee = supervisors.OrderByDescending(x => x.CalculateSalary()).First();
                Console.WriteLine($"{employee.Name} {employee.Surname}: {employee.CalculateSalary()}$");


            }
            catch (Exception)
            {
                Console.WriteLine("No existe ningún supervisor");
            }
        }

        static T DataInput<T>(T employee)
            where T : IPerson
        {
            Console.Write("Ingrese nombre: ");
            employee.Name = Console.ReadLine();
            Console.Write("Ingrese apellido: ");
            employee.Surname = Console.ReadLine();
            Console.Write("Ingrese DNI: ");
            employee.Identification = Console.ReadLine();
            Console.Write("Ingrese año de ingreso: ");
            if (int.TryParse(Console.ReadLine(), out int year))
                employee.EntryYear = year;
            Console.Write("Ingrese precio por hora: ");
            if (int.TryParse(Console.ReadLine(), out int price))
                employee.PricePerHour = price;
            Console.Write("Ingrese cantidad de horas realizadas: ");
            if (int.TryParse(Console.ReadLine(), out int hours))
                employee.Hours = hours;

            return employee;
        }
    }
}
