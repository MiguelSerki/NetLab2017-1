using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContextConsultas
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Consultas();
            //x.MostrarTodos();
            //x.MostrarMujeres();
            //x.MostrarHombres70();
            //x.PromedioEdadAdultos();
            //x.MostrarHijos();
            x.PromedioEdadPais();

            Console.Read();
        }
        

    }
}
