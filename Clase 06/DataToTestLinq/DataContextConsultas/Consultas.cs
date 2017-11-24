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
        public List<PersonModel> MostrarTodos()
        {
            var todos = DataContext.People
                .Select(person => new PersonModel
                {
                    Name = person.Name,
                    Country = person.Country,
                    Age = person.Age()
                })
                .Union(DataContext.People
                .Where(person => person.Children.Count() != 0)
                .SelectMany(person => person.Children)
                .Select(child => new PersonModel
                {
                    Name = child.Name,
                    Country = child.Country,
                    Age = child.Age()
                }))
                .ToList();

            return todos;

        }

        //Listar las mujeres.
        public List<PersonModel> MostrarMujeres()
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
                                }))
                                .ToList();



            return mujeres;
        }

        //Listar los hombres que pesen más de 70KG.
        public List<PersonModel> MostrarHombres70()
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
                                 )
                                 .ToList();

            return hombres70;
        }

        //Promedio de edad de las personas de la lista, sin incluir a sus hijos.
        public double PromedioEdadAdultos()
        {
            var promedioEdad = DataContext.People
                .Select(person => DateTime.Today.Year - person.DateOfBorn.Year)
                .Average();
            
            return promedioEdad;
        }

        public List<PersonModel> MostrarHijos()
        {
            var hijos = DataContext.People
                                    .Where(person => person.Children.Count() != 0)
                                    .SelectMany(person => person.Children)
                                    .Select(child => new PersonModel
                                    {
                                        Name = child.Name,
                                        Country = child.Country,
                                        Age = DateTime.Today.Year - child.DateOfBorn.Year
                                    })
                                    .ToList();

            return hijos;
        }

        //Promedio de edad por país.
        public List<CountryAvg> PromedioEdadPais()
        {
            var promedios = DataContext.People.GroupBy(x => x.Country)
                .Select(x => new CountryAvg
                {
                    Country = x.Key,
                    //Min = x.Select(y => DateTime.Today.Year - y.DateOfBorn.Year).Min(),
                    Avg = x.Select(y => DateTime.Today.Year - y.DateOfBorn.Year)
                    .Average()
                })
                .ToList();

            return promedios;
        }

        //Promedio de peso por género. 
        public List<GenderAvg> PromedioPesoGenero()
        {
            var promedios = DataContext.People.GroupBy(x => x.Gender)
                .Select(x => new GenderAvg
                {
                    Gender = x.Key.ToString(),
                    //Min = x.Select(y => DateTime.Today.Year - y.DateOfBorn.Year).Min(),
                    Avg = x.Select(y => y.Weight).Average()
                })
                .ToList();
            //falta agarrar a los pibes!!!!!!!!!
            return promedios;
        }

        //Persona con mayor peso.
        public PersonModel MayorPeso()
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

            return mayorPeso;
        }

        //Persona con menor peso.
        public PersonModel MenorPeso()
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
            
            return menorPeso;
        }

        //Última persona de la lista. 
        public string UltimaPersona()
        {
            var ultimo = DataContext.People
                .Select(p => p.Name)
                .LastOrDefault();
            
            return ultimo;
        }

        //Listar personas que hablan más de un idioma mostrando el nombre y los idiomas que habla. 
        public List<PersonModelLanguage> Multilingue()
        {
            var multilingue = DataContext.People
                .Where(p => p.LanguagesThatSpeaks.Count() > 1)
                .Select(p => new PersonModelLanguage
                {
                    Name = p.Name,
                    LanguagesThatSpeaks = String.Join(", ", p.LanguagesThatSpeaks)
                })
                .ToList();

            return multilingue;
        }

        //Promedio de edad de los hijos de cada persona.
        public List<ChildrenAgeAvg> PromedioEdadHijos()
        {
            var promedios = DataContext.People
                            .Where(p => p.Children.Any())
                           .Select(c => new ChildrenAgeAvg
                           {
                               Name = c.Name,
                               ChildrenAgeAverage = c.Children.Average(f => f.Age())
                           })
                           .ToList();
           
            return promedios;

        }

        //Consultar si existe alguna persona llamada “Osvaldo”.
        public bool Existe(string name)
        {
            var exist = DataContext.People
                .Where(p => p.Name.Equals(name))
                .Union(
                DataContext.People
                .Where(p => p.Children.Any())
                .Where(c => c.Name.Equals(name))
                )
                .Any();

            return exist;
        }

        //Ordenar las personas por edad y listar las personas en 3ra y 4ta posición.
        public List<PersonModel> TerceraYCuartaEdadAlta()
        {
            var t = DataContext.People
                .Select(p => new PersonModel
                {
                    Name = p.Name,
                    Age = p.Age()
                })
                .Union(DataContext.People
                .Where(p => p.Children.Any())
                .SelectMany(p => p.Children)
                .Select(c => new PersonModel
                {
                    Name = c.Name,
                    Age = c.Age()
                })
                )
                .OrderByDescending(p => p.Age)
                .Skip(2)
                .Take(2)
                .ToList();

            return t;
        }

    }

    public class PersonModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }

    }

    public class PersonModelLanguage
    {
        public string Name { get; set; }
        public string LanguagesThatSpeaks { get; set; }
    }

    public class CountryAvg
    {
        public string Country { get; set; }
        public double Avg { get; set; }
    }

    public class GenderAvg
    {
        public string Gender { get; set; }
        public decimal Avg { get; set; }
    }

    public class ChildrenAgeAvg
    {
        public string Name { get; set; }
        public double ChildrenAgeAverage { get; set; }
    }

    public static class PersonExtensions
    {
        public static int Age(this Person person)
        {
            return DateTime.Today.Year - person.DateOfBorn.Year;
        }
    }
}
