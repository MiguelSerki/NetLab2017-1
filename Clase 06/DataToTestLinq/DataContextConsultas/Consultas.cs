using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataToTestLinq;

namespace DataContextConsultas
{
    public class Consultas
    {
        //Listar todas las personas mostrando nombre, país y edad. 
        public void MostrarTodos()
        {
            var test = DataContext.People
                .Select(person => new PersonModel
                {
                    Name = person.Name,
                    Country = person.Country,
                    Age = DateTime.Today.Year - person.DateOfBorn.Year
                })
                .Union(DataContext.People
                .Where(person => person.Children.Count() != 0)
                .SelectMany(person => person.Children)
                .Select(child => new PersonModel
                {
                    Name = child.Name,
                    Country = child.Country,
                    Age = DateTime.Today.Year - child.DateOfBorn.Year
                }));

            foreach (var p in test)
            {
                Console.WriteLine($"Nombre: {p.Name}, Pais: {p.Country}, Edad: {p.Age}");
            }

        }

        //Listar las mujeres.
        public void MostrarMujeres()
        {
            var mujeres = DataContext.People
                            .Where(person => person.Gender == Gender.Feminine)
                            .Select(person => new PersonModel
                            {
                                Name = person.Name,
                                Country = person.Country,
                                Age = DateTime.Today.Year - person.DateOfBorn.Year
                            })
                            .Union(DataContext.People
                                .Where(person => person.Children.Count() != 0)
                                .SelectMany(person => person.Children)
                                .Where(child => child.Gender == Gender.Feminine)
                                .Select(child => new PersonModel
                                {
                                    Name = child.Name,
                                    Country = child.Country,
                                    Age = DateTime.Today.Year - child.DateOfBorn.Year
                                }));


            foreach (var m in mujeres)
            {
                Console.WriteLine($"Nombre: {m.Name}, Pais: {m.Country}, Edad: {m.Age}");
            }
        }

        //Listar los hombres que pesen más de 70KG.
        public void MostrarHombres70()
        {
            var hombres70 = DataContext.People
                                .Where(person => person.Gender == Gender.Masculine && person.Weight > 70)
                                .Select(person => new PersonModel
                                {
                                    Name = person.Name,
                                    Country = person.Country,
                                    Age = DateTime.Today.Year - person.DateOfBorn.Year,
                                    Weight = person.Weight
                                })
                                .Union(DataContext.People
                                    .Where(person => person.Children.Count() != 0)
                                    .SelectMany(person => person.Children)
                                    .Where(child => child.Gender == Gender.Masculine && child.Weight > 70)
                                    .Select(child => new PersonModel
                                    {
                                        Name = child.Name,
                                        Country = child.Country,
                                        Age = DateTime.Today.Year - child.DateOfBorn.Year,
                                        Weight = child.Weight
                                    })
                                 );


            foreach (var h in hombres70)
            {
                Console.WriteLine($"Nombre: {h.Name}, Pais: {h.Country}, Edad: {h.Age}, Peso: {h.Weight}");
            }
        }

        //Promedio de edad de las personas de la lista, sin incluir a sus hijos.
        public void PromedioEdadAdultos()
        {
            var promedioEdad = DataContext.People
                .Select(person => DateTime.Today.Year - person.DateOfBorn.Year)
                .Average();
            
            Console.WriteLine($"El promedio de edad es :{Math.Round(promedioEdad,2)}");
        }

        public void MostrarHijos()
        {
            var hijos = DataContext.People
                                    .Where(person => person.Children.Count() != 0)
                                    .SelectMany(person => person.Children)
                                    .Select(child => new PersonModel
                                    {
                                        Name = child.Name,
                                        Country = child.Country,
                                        Age = DateTime.Today.Year - child.DateOfBorn.Year
                                    });


            foreach (var h in hijos)
            {
                Console.WriteLine($"Nombre: {h.Name}, Pais: {h.Country}, Edad: {h.Age}");
            }
        }

        //Promedio de edad por país.
        public void PromedioEdadPais()
        {
            var h = DataContext.People.GroupBy(x => x.Country)
                .Select(x => new
                {
                    Country = x.Key,
                    //Min = x.Select(y => DateTime.Today.Year - y.DateOfBorn.Year).Min(),
                    avg = x.Select(y => DateTime.Today.Year - y.DateOfBorn.Year)
                    .Average()
                });

            foreach (var item in h)
            {
                Console.WriteLine($"{item.Country}: {item.avg}");
            }
        }

    }

    class PersonModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
    }


}
