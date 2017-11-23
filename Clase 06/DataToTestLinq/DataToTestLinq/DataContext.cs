using System;
using System.Collections.Generic;

namespace DataToTestLinq
{
    public static class DataContext
    {
        public static IEnumerable<Person> People = new List<Person>
        {
            new Person
            {
                Name = "Sara",
                Country = "EEUU",
                DateOfBorn = new DateTime(1990, 1,1),
                Gender = Gender.Feminine,
                LanguagesThatSpeaks = new List<Language> { Language.English, Language.French, },
                Weight = 55,
                Children = new List<Person>
                {
                    new Person
                    {
                        Name = "Jhon",
                        Country = "EEUU",
                        DateOfBorn = new DateTime(2015, 5,8),
                        Gender = Gender.Masculine,
                        LanguagesThatSpeaks = new List<Language> { Language.English,},
                        Weight = 14,
                    },
                    new Person
                    {
                        Name = "Sara jr",
                        Country = "EEUU",
                        DateOfBorn = new DateTime(2013, 7,8),
                        Gender = Gender.Feminine,
                        LanguagesThatSpeaks = new List<Language> { Language.English,},
                        Weight = 19,
                    }
                }
            },
            new Person
            {
                Name = "Roberto",
                Country = "Argetina",
                DateOfBorn = new DateTime(1987, 10, 10),
                Gender = Gender.Masculine,
                LanguagesThatSpeaks = new List<Language>{Language.Spanish},
                Weight = 85,
            },
            new Person
            {
                Name = "Jean-Claude",
                Country = "Francia",
                DateOfBorn = new DateTime(1960, 10, 18),
                Gender = Gender.Masculine,
                LanguagesThatSpeaks = new List<Language>{Language.French, },
                Weight = 75,
            },
            new Person
            {
                Name = "Osvaldo",
                Country = "España",
                DateOfBorn = new DateTime(1953, 3,18),
                Gender = Gender.Masculine,
                LanguagesThatSpeaks = new List<Language> { Language.Spanish },
                Weight = 90,
                Children = new List<Person>
                {
                    new Person
                    {
                        Name = "Jose",
                        Country = "España",
                        DateOfBorn = new DateTime(1980, 5,8),
                        Gender = Gender.Masculine,
                        LanguagesThatSpeaks = new List<Language> { Language.Spanish, },
                        Weight = 87,
                    },
                }
            },
            new Person
            {
                Name = "Arturo",
                Country = "Chile",
                DateOfBorn = new DateTime(1987, 5,22),
                Gender = Gender.Masculine,
                LanguagesThatSpeaks = new List<Language> { Language.Spanish },
                Weight = 70,
            },
            new Person
            {
                Name = "Eva",
                Country = "Argentina",
                DateOfBorn = new DateTime(1989, 1,1),
                Gender = Gender.Feminine,
                LanguagesThatSpeaks = new List<Language> { Language.Spanish, Language.French, },
                Weight = 65,
            }
        };
    }
}
