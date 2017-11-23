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
            decimal percentage = 0;
            var yearsWorking = DateTime.Today.Year - this.EntryYear;
            if (yearsWorking >= 5 && yearsWorking <= 10)
                percentage = 2.5m;
            else if (yearsWorking > 10)
                percentage = 5m;

            var workedHours = this.PricePerHour * this.Hours;
            var plus = percentage * workedHours / 100;
            var comission = this.Commission * workedHours / 100;

            //Sueldo básico + Horas trabajadas (precio hora * cantidad horas) + Plus por antigüedad + Comisión
            return this.BasicSalary + workedHours + plus + comission;
        }
    }
}
