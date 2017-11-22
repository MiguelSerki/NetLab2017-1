using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO.Classes
{
    public abstract class Supervisory : Person
    {
        public override decimal BasicSalary => 4000;
        public abstract decimal Commission { get; }

        public override decimal CalculateSalary()
        {
            decimal plus = 0;
            var yearsWorking = DateTime.Today.Year - this.EntryYear;
            if (yearsWorking >= 5 && yearsWorking <= 10)
                plus = this.HoursWorked * 2.5m;
            else if (yearsWorking > 10)
                plus = this.HoursWorked * 5m;

            //TO DO
            //Sueldo básico + Horas trabajadas (precio hora * cantidad horas) + Plus por antigüedad + Comisión
            return (this.BasicSalary + (this.PricePerHour * this.HoursWorked) + plus);
        }
    }
}
