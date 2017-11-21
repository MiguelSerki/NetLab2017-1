using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Clases
{
    class Ej21
    {
    }

    public class Person
    {
        public Person()
        {
            LanguagesThatSpeaks = new List<Language>();
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBorn { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<Language> LanguagesThatSpeaks { get; set; }
    }
    public enum Gender { Masculine, Feminine }
    public enum Language { English, Spanish, French }
    var people = new List<Person>
{
    new Person
    {
        Name = "Sara",
        Country = "EEUU",
        DateOfBorn = new DateTime(1990, 1,1),
        Gender = Gender.Feminine,
        LanguagesThatSpeaks = new List<Language> { Language.English, Language.French, }
    },
    new Person
    {
        Name = "Roberto",
        Country = "Argetina",
        DateOfBorn = new DateTime(1987, 10, 10),
        Gender = Gender.Masculine,
        LanguagesThatSpeaks = new List<Language>{Language.Spanish}
    },
    new Person
    {
        Name = "Jean-Claude",
        Country = "Francia",
        DateOfBorn = new DateTime(1960, 10, 18),
        Gender = Gender.Masculine,
        LanguagesThatSpeaks = new List<Language>{Language.French, }
    },
    new Person
    {
        Name = "Osvaldo",
        Country = "España",
        DateOfBorn = new DateTime(2003, 3,18),
        Gender = Gender.Masculine,
        LanguagesThatSpeaks = new List<Language>Language.Spanish,}
    },
    new Person
    {
        Name = "Arturo",
        Country = "Chile",
        DateOfBorn = new DateTime(1987, 5,22),
        Gender = Gender.Masculine,
        LanguagesThatSpeaks = new List<Language>{Language.Spanish
}
    },
};

}
