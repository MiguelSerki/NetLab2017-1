using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaYPila
{
    class Cola <T>
    {
        private List<T> Lista;

        public Cola()
        {
            Lista = new List<T>();
        }

        public void Agregar(T item)
        {
            Lista.Add(item);
        } 

        public T Tomar()
        {
            T tomada = Lista.ElementAt(0);
            Lista.RemoveAt(0);
            return tomada;
        }

        public int Cantidad()
        {
            return Lista.Count();
        }
    }
}
