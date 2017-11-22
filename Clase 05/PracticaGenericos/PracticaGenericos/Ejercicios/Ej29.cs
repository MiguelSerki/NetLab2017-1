using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGenericos.Ejercicios
{
    /*
     * Desarrollar una interface en c# IContenedor que contenga las firmas Agregar,
     * Quitar y EstaRepetido. Escribir una implementación para esta interface. 
     */

    class Ej29
    {
        public interface IContenedor
        {
            void Agregar(int x);
            void Quitar(int x);
            bool EstaRepetido(int x);
        }

        public class Implementacion : IContenedor
        {
            List<int> Nros;

            public Implementacion()
            {
                Nros = new List<int>();
            }

            public void Agregar(int x)
            {
                Nros.Add(x);
            }

            public bool EstaRepetido(int x)
            {
                IEnumerable<int> lista = Nros.Where(c => c == x);

                return lista.Count() != 0;
            }

            public void Quitar(int x)
            {
                Nros.Remove(x);
            }
        }
    }
}
