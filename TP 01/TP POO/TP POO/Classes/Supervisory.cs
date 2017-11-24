using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO.Classes
{
    public abstract class Supervisory : IPerson
    {
        public decimal BasicSalary => 4000;
        public abstract decimal Commission { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int EntryYear { get; set; }
        public string Identification { get; set; }
        public decimal PricePerHour { get; set; }
        public int Hours { get; set; }

        public decimal CalculateSalary()
        {
            decimal percentage = 0;
            decimal plus;
            var yearsWorking = 0;
            if (this.EntryYear > 0)
                yearsWorking = DateTime.Today.Year - this.EntryYear;

            if (yearsWorking >= 5 && yearsWorking <= 10)
                percentage = 2.5m;
            else if (yearsWorking > 10)
                percentage = 5m;

            var workedHours = this.PricePerHour * this.Hours;

            if (percentage > 0)
                plus = percentage * workedHours / 100;
            else
                plus = 0;
            
            var comission = this.Commission * workedHours / 100;

            //Sueldo básico + Horas trabajadas (precio hora * cantidad horas) + Plus por antigüedad + Comisión
            return this.BasicSalary + workedHours + plus + comission;
        }
    }
}
