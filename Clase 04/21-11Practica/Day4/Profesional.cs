using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public abstract class Profesional : Persona
    {
        public string Dni { get; set; }

        public string Experiencia { get; set; }

        public abstract int BaseSueldo { get; }

        public decimal CalcularSueldo()
        {
            return this.BaseSueldo * int.Parse(Experiencia);
        }
    }
}
