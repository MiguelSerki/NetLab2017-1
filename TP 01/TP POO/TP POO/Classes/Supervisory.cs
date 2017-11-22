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
            //Sueldo básico + Horas trabajadas (precio hora * cantidad horas) + Plus por antigüedad + Comisión
        }
    }
}
