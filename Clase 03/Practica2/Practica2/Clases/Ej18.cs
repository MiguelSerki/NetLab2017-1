using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Clases
{
    class Contador
    {
        public int Valor { get; set; }

        public Contador(int valor=0)
        {
            Valor = valor;
        }

        public void Incrementar() {
            Valor++;
        }
        public void Disminuir() {
            Valor--;
        }
    }
}
