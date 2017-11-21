using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaYPila
{
    class Pila<T>
    {
        private List<T> Lista;

        public Pila()
        {
            Lista = new List<T>();
        }

        public void Agregar(T item)
        {
            Lista.Add(item);
        }

        public T Tomar()
        {
            T tomada = Lista.LastOrDefault();
            Lista.RemoveAt(Lista.Count() - 1);
            return tomada;
        }

        public int Cantidad()
        {
            return Lista.Count();
        }
    }
}
