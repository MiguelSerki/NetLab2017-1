using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGenericos.Ejercicios
{
    //Desarrollar un método genérico que tenga dos parámetros y el retorne si los valores son iguales.

    public class Ej25<T>
    {
        public bool Comparar(T a, T b)
        {
            return EqualityComparer<T>.Default.Equals(a, b);
        }
    }
}
