using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Password
    {
        private string Clave { get; set; }
        public int Longitud { get; set; }

        public Password(int longitud = 8)
        {
            if (longitud > 0)
                Longitud = longitud;
            else
                Longitud = 8;
        }

        public bool EsFuerte() {
            return true;
        }

        public string GenerarClave(bool generar)
        {
            
            return "";
        }

    }
}
