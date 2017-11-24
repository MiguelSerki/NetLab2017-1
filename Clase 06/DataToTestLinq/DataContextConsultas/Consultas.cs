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

            Console.WriteLine($"El promedio de edad es :{Math.Round(promedioEdad, 2)}");
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

        //Promedio de peso por género. 
        public void PromedioPesoGenero()
        {
            var h = DataContext.People.GroupBy(x => x.Gender)
                .Select(x => new
                {
                    Gender = x.Key,
                    //Min = x.Select(y => DateTime.Today.Year - y.DateOfBorn.Year).Min(),
                    avg = x.Select(y => y.Weight)
                    .Average()
                });

            foreach (var item in h)
            {
                Console.WriteLine($"{item.Gender}: {item.avg}");
            }
        }

        //Persona con mayor peso.
        public void MayorPeso()
        {
            var mayorPeso = DataContext.People
                .Select(p => new PersonModel
                {
                    Name = p.Name,
                    Weight = p.Weight
                })
                .Union(
                DataContext.People
                .SelectMany(p => p.Children)
                .Select(c => new PersonModel
                {
                    Name = c.Name,
                    Weight = c.Weight
                })
                )
                .OrderByDescending(x => x.Weight).FirstOrDefault();

            Console.WriteLine($"{mayorPeso.Name}: {mayorPeso.Weight}");
        }

        //Persona con menor peso.
        public void MenorPeso()
        {
            var menorPeso = DataContext.People
                .Select(p => new PersonModel
                {
                    Name = p.Name,
                    Weight = p.Weight
                })
                .Union(
                DataContext.People
                .SelectMany(p => p.Children)
                .Select(c => new PersonModel
                {
                    Name = c.Name,
                    Weight = c.Weight
                })
                )
                .OrderByDescending(x => x.Weight).LastOrDefault();

            Console.WriteLine($"{menorPeso.Name}: {menorPeso.Weight}");
        }

        //Última persona de la lista. 
        public void UltimaPersona()
        {
            var ultimo = DataContext.People
                .Select(p => new PersonModel
                {
                    Name = p.Name
                })
                .LastOrDefault();

            Console.WriteLine(ultimo.Name);
        }

        //Listar personas que hablan más de un idioma mostrando el nombre y los idiomas que habla. 
        public void Bilingues()
        {
            var bilingues = DataContext.People
                .Where(p => p.LanguagesThatSpeaks.Count() > 1)
                .Select(p => new PersonModelLanguage {
                    Name = p.Name,
                    LanguagesThatSpeaks = p.LanguagesThatSpeaks
                });

            foreach (var person in bilingues)
            {
                Console.WriteLine($"{person.Name}: {String.Join(", ", person.LanguagesThatSpeaks)}");
            }
        }

        //Promedio de edad de los hijos de cada persona.
        public void PromedioEdadHijos()
        {
            DataContext.People
                            .Where(p => p.Children.Any())
                           .Select(c => new
                           {
                               c.Name,
                               ChildrenAgeAverage = c.Children.Average(f => f.Age())
                           })
                           .ToList()
                           .ForEach(c => Console.WriteLine($"Padre: {c.Name}, Promedio edad hijos: {c.ChildrenAgeAverage}"));
        }

        //Consultar si existe alguna persona llamada “Osvaldo”.
        public void Existe(string name)
        {
            var x = DataContext.People
                .Where(p => p.Name.Equals(name))
                .Union(
                DataContext.People
                .Where(p => p.Children.Any())
                .Where(c => c.Name.Equals(name))
                );

            if (x.Any())
                foreach (var c in x)
                {
                    Console.WriteLine($"{c.Name}, {c.Age()} años, {c.Country}");
                }
            else
                Console.WriteLine("No existe!");
        }

        //Ordenar las personas por edad y listar las personas en 3ra y 4ta posición.
        public void TerceraYCuartaEdadAlta()
        {
            var t = DataContext.People
                .Select(p => new {
                    Name = p.Name,
                    Age = p.Age()
                })
                .Union(DataContext.People
                .Where(p => p.Children.Any())
                .SelectMany(p => p.Children)
                .Select(c => new {
                    Name = c.Name,
                    Age = c.Age()
                })
                )
                .OrderByDescending(p => p.Age)
                .ToList();

            Console.WriteLine($"{t.ElementAt(2).Name}: {t.ElementAt(2).Age}");
            Console.WriteLine($"{t.ElementAt(3).Name}: {t.ElementAt(3).Age}");
        }

    }

    class PersonModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }

    }

    class PersonModelLanguage
    {
        public PersonModelLanguage()
        {
            LanguagesThatSpeaks = new List<Language>();
        }

        public string Name { get; set; }
        public IEnumerable<Language> LanguagesThatSpeaks { get; set; }
    }

    public static class PersonExtensions
    {
        public static int Age(this Person person)
        {
            return DateTime.Today.Year - person.DateOfBorn.Year;
        }
    }
}
