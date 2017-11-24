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
            //x.PromedioEdadPais();
            //x.PromedioPesoGenero();
            //x.MayorPeso();
            //x.MenorPeso();
            //x.UltimaPersona();
            //x.Bilingues();
            //x.PromedioEdadHijos();
            //x.Existe("Osvaldo");
            x.TerceraYCuartaEdadAlta();


            Console.Read();
        }
        

    }
}
