using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGenericos.Ejercicios
{
    /*
    Desarrollar una clase genérica que contenga un método genérico
    con un parámetro y que retorne el valor ingresado. 
    */

    public class Ej23<T>
    {
        public T RetornarIngresado(T ingresado)
        {
            return ingresado;
        }
    
    }
}
