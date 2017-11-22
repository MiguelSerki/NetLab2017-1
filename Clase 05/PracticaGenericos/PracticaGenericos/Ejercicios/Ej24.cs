using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGenericos.Ejercicios
{
    //Desarrollar una clase genérica que contenga un método genérico con un parámetro y lo escriba en consola

    public class Ej24<T>
    {
        public void MostrarParametro(T input)
        {
            Console.WriteLine(input);
        }
    }
}
