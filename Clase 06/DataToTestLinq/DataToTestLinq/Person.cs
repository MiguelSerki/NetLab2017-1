using System;
using System.Collections.Generic;

namespace DataToTestLinq
{
    public class Person
    {
        public Person()
        {
            LanguagesThatSpeaks = new List<Language>();
            Children = new List<Person>();
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBorn { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<Language> LanguagesThatSpeaks { get; set; }
        public decimal Weight { get; set; }
        public List<Person> Children { get; set; }
    }
}
