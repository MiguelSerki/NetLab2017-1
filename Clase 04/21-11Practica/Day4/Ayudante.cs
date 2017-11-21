using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Crear el nuevo tipo Ayudante que va a tener los mismos datos que el estudiante pero
    se debe guardar el Dni y Experiencia como en el profesor
    Además se debe crear un método común a Ayudante - Profesor que calcule
    el sueldo en base a Exp en años * (1000 - para ayudantes - 2000 para profesores) 
    En el menú profesor - ayudantes al consultar un ítem mostrar el sueldo
*/

namespace Day4
{
    public class Ayudante : Profesional
    {
        public string Legajo { get; set; }

        public string Ingreso { get; set; }

        public override int BaseSueldo => 1000;

        public override string Presentacion()
        {
            return $"Hola soy el ayudante {this.Apellido} {this.Nombre}, cuento con {this.Experiencia} años de experiencia";
        }
    }
}
