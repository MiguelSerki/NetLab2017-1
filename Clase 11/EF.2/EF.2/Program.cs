using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF._2.Datos;
using EF._2.Entidades;
using System.Data.Entity;

namespace EF._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateCity();
            //CreateEmployee();
            //ShowCityEmployees();
            //ShowSuperVisorEmployees();


            using (var context = new Context())
            {
                var category = context.Categories.FirstOrDefault();

                var employee1 = context.Employees.FirstOrDefault(c => c.Name == "David");
                var employee2 = context.Employees.FirstOrDefault(c=> c.Name == "Cesar");

                category.Employees.Add(employee2);
                category.Employees.Add(employee1);

                // or

                employee1.Categories.Add(category);
                employee2.Categories.Add(category);
            }


            Console.ReadLine();

        }

        private static void ShowSuperVisorEmployees()
        {
            using (var context = new Context())
            {
                var supervisorId = int.Parse(Console.ReadLine());

                var supervisor = context.Employees
                        .Include(e => e.Employees)
                        .AsNoTracking()
                        .FirstOrDefault(s => s.Id == supervisorId);

                foreach (var employee in supervisor.Employees)
                {
                    var month = DateTime.Now.Month;

                    var current = employee.Salary * month;

                    Console.WriteLine($@"Empleado : {employee.Name} {employee.Surname} 
                                         Sueldo Anual : {employee.Salary * 12}
                                         Monto cobrado : {current}
                                        ");
                }

            }
        }

        private static void ShowCityEmployees()
        {
            using (var context = new Context())
            {
                var cityId = int.Parse(Console.ReadLine());
                var city = context.Cities
                    .Include(e => e.Employees)
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == cityId);

                Console.WriteLine(city.Name);
                Console.WriteLine("===========================");

                foreach (var employee in city.Employees)
                {
                    Console.WriteLine($"{employee.Name} {employee.Surname}");
                }

            }
        }

        private static void CreateEmployee()
        {
            // 2 -- crear empleado
            var newEmployee = new Employee
            {
                Name = Console.ReadLine(),
                Age = int.Parse(Console.ReadLine()),
                Surname = Console.ReadLine(),
                Position = Console.ReadLine(),

            };

            var cityToSearch = Console.ReadLine();

            using (var context = new Context())
            {
                var city = context.Cities.FirstOrDefault(c => c.Name == cityToSearch);

                newEmployee.City = city;
                //newEmployee.CityId = city.Id;
                //city.Employees.Add(newEmployee);

                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }
        }

        private static void CreateCity()
        {
            // 1 -- crear una ciudad
            var newCity = new City
            {
                Name = Console.ReadLine()
            };

            using (var context = new Context())
            {
                context.Cities.Add(newCity);
                context.SaveChanges();
            }
        }
    }
}
