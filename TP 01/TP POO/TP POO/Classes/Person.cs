using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO.Classes
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int EntryYear { get; set; }
        public int Identification { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal Hours { get; set; }
        public abstract decimal BasicSalary { get; }

        public abstract decimal CalculateSalary();
    }
}
