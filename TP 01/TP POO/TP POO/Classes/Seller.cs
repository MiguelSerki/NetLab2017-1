using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO.Classes
{
    public class Seller : Person
    {
        public override decimal BasicSalary => 2000;

        public override decimal CalculateSalary()
        {
            decimal percentage = 1;
            var yearsWorking = DateTime.Today.Year - this.EntryYear;
            if (yearsWorking >= 5 && yearsWorking <= 10)
                percentage = 2.5m;
            else if (yearsWorking > 10)
                percentage = 5;

            var hoursWorked = this.PricePerHour * this.Hours;
            var plus = percentage * hoursWorked / 100;

            //Sueldo básico + Horas trabajadas (precio hora * cantidad horas) + Plus por antigüedad
            return this.BasicSalary + hoursWorked + plus;
        }
    }
}
