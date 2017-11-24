using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContextConsultas;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new Consultas();

            //Ejercicio 01
            Console.WriteLine("Todas las personas:\n");
            foreach (var p in service.MostrarTodos())
            {
                Console.WriteLine($"Nombre: {p.Name}, Pais: {p.Country}, Edad: {p.Age}");
            }
            Line();

            //Ejercicio 02
            Console.WriteLine("Todas las mujeres:\n");
            foreach (var m in service.MostrarMujeres())
            {
                Console.WriteLine($"Nombre: {m.Name}, Pais: {m.Country}, Edad: {m.Age}");
            }
            Line();

            //Ejercicio 03
            Console.WriteLine("Todos los hombres que pesan más de 70KG:\n");
            foreach (var h in service.MostrarHombres70())
            {
                Console.WriteLine($"Nombre: {h.Name}, Pais: {h.Country}, Edad: {h.Age}, Peso: {h.Weight}");
            }
            Line();

            //Ejercicio 04
            Console.WriteLine("Promedio edad adultos:\n");
            Console.WriteLine($"El promedio de edad es :{Math.Round(service.PromedioEdadAdultos(), 2)}");
            Line();

            //Ejercicio 05
            Console.WriteLine("Todos los hijos:\n");
            foreach (var h in service.MostrarHijos())
            {
                Console.WriteLine($"Nombre: {h.Name}, Pais: {h.Country}, Edad: {h.Age}");
            }
            Line();

            //Ejercicio 06
            Console.WriteLine("Promedio de edad por país:\n");
            foreach (var item in service.PromedioEdadPais())
            {
                Console.WriteLine($"{item.Country}: {item.Avg}");
            }
            Line();

            //Ejercicio 07
            Console.WriteLine("Promedio de peso por género:\n");
            foreach (var item in service.PromedioPesoGenero())
            {
                Console.WriteLine($"{item.Gender}: {item.Avg}");
            }
            Line();

            //Ejercicio 08
            Console.WriteLine("Persona con mayor peso:\n");
            var mayorPeso = service.MayorPeso();
            Console.WriteLine($"{mayorPeso.Name}: {mayorPeso.Weight}");
            Line();

            //Ejercicio 09
            Console.WriteLine("Persona con menor peso:\n");
            var menorPeso = service.MenorPeso();
            Console.WriteLine($"{menorPeso.Name}: {menorPeso.Weight}");
            Line();

            //Ejercicio 10
            Console.WriteLine("Ultima persona de la lista:\n");
            Console.WriteLine(service.UltimaPersona());
            Line();

            //Ejercicio 11
            Console.WriteLine("Todas las personas Multilingüe:\n");
            foreach (var person in service.Multilingue())
            {
                Console.WriteLine($"{person.Name}: {person.LanguagesThatSpeaks}");
            }
            Line();

            //Ejercicio 12
            Console.WriteLine("Promedio edad hijos por padre:\n");
            foreach (var c in service.PromedioEdadHijos())
            {
                Console.WriteLine($"Padre: {c.Name}, Promedio edad hijos: {c.ChildrenAgeAverage}");
            }
            Line();

            //Ejercicio 13
            Console.WriteLine("Existe Osvaldo en la lista?:\n");
            if (service.Existe("Osvaldo"))
                Console.WriteLine("Existe!");
            else
                Console.WriteLine("No existe!");
            Line();

            //Ejercicio 14
            Console.WriteLine("3ra y 4ta persona de la lista ordenada por edad:\n");
            foreach (var p in service.TerceraYCuartaEdadAlta())
            {
                Console.WriteLine($"Nombre: {p.Name}, Edad: {p.Age}");
            }
            Line();

            Console.ReadLine();
        }

        static void Line()
        {
            Console.WriteLine("\n-------------------------------------------------\n");
        }
    }
}
