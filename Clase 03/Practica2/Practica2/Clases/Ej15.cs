using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Clases
{

    abstract class Operacion
    {
        public float Valor1 { get; set; }
        public float Valor2 { get; set; }

        public abstract float Operar();
    }

    class Suma : Operacion
    {
        public override float Operar()
        {
            return Valor1 + Valor2;
        }
    }

    class Resta : Operacion
    {
        public override float Operar()
        {
            return Valor1 - Valor2;
        }
    }

    class Division : Operacion
    {
        public override float Operar()
        {
            return Valor1 / Valor2;
        }
    }

    class Multiplicacion : Operacion
    {
        public override float Operar()
        {
            return Valor1 * Valor2;
        }
    }
}
