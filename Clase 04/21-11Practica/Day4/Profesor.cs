using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Profesor : Profesional
    {
        public string Materia { get; set; }

        public override int BaseSueldo => 2000;

        public override string Presentacion()
        {
            return $"Hola soy el profesor {this.Apellido} {this.Nombre} de la materia {this.Materia}";
        }
    }
}
