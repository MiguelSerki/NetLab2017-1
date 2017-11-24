using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO.Classes
{
    public interface IPerson
    {
        string Name { get; set; }
        string Surname { get; set; }
        int EntryYear { get; set; }
        string Identification { get; set; }
        decimal PricePerHour { get; set; }
        int Hours { get; set; }
        decimal BasicSalary { get; }

        decimal CalculateSalary();
    }
}
