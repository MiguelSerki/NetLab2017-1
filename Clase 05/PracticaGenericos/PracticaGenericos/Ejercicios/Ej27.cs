using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGenericos.Ejercicios
{
    /*
     * Desarrollar un método genérico que reciba dos colecciones del tipo IEnumerable<T>
     * donde T debe ser una clase e internamente haga la intersección de ambas colecciones
     * y retorne el primer ítem o el valor por defecto.
    */
    public class Ej27
    {
        public T DevolverInterseccion<T>(IEnumerable<T> a, IEnumerable<T> b)
            where T : class
        {
            return a.Intersect(b).FirstOrDefault();
        }
    }
}
