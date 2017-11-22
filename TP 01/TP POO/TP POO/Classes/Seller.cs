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
            decimal plus = 0;
            var yearsWorking = DateTime.Today.Year - this.EntryYear;
            if (yearsWorking >= 5 && yearsWorking <= 10)
                plus = 2.5m * this.BasicSalary / 100;
            else if (yearsWorking > 10)
                plus = 5m * this.BasicSalary / 100;
            //Sueldo básico + Horas trabajadas (precio hora * cantidad horas) + Plus por antigüedad
            return (this.BasicSalary + (this.PricePerHour * this.HoursWorked) + plus);
        }
    }
}
