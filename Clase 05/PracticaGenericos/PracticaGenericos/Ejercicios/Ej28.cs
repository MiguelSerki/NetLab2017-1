using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGenericos.Ejercicios
{
    //Desarrollar un método genérico que reciba un parámetro del tipo IConvertible e IComparable. 

    public class Ej28
    {
        public void MetodoRecibe<T>(IConvertible a, IComparable b) { }
    }
}
