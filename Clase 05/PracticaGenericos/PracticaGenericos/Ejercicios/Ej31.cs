using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGenericos.Ejercicios
{
    /*
     *  Diseñar dos clases Auto y Avión ambas pueden Acelerar,
     *  Frenar y Girar, y además el Avión puede Despegar y Aterrizar.
     *  Resolver aplicando interfaces.  
     */

    class Ej31
    {
    }

    public interface IVehiculo
    {
        int Velocidad { get; set; }
        int Rotacion { get; set; }

        void Acelerar();
        void Frenar();
        void Girar();
    }

    public interface IVehiculoAereo : IVehiculo
    {
        bool EnVuelo { get; set; }
        void Despegar();
        void Aterrizar();
        
    }

    public class Auto : IVehiculo
    {
        public int Velocidad { get; set; }
        public int Rotacion { get; set; }

        public void Acelerar()
        {
            Velocidad++;
        }

        public void Frenar()
        {
            Velocidad--;
        }

        public void Girar()
        {
            Rotacion++;
        }
    }

    public class Avion : IVehiculoAereo
    {
        public int Velocidad { get; set; }
        public int Rotacion { get; set; }
        public bool EnVuelo { get; set; }

        public void Acelerar()
        {
            Velocidad++;
        }

        public void Frenar()
        {
            Velocidad--;
        }

        public void Girar()
        {
            Rotacion++;
        }
        
        public void Despegar()
        {
            EnVuelo = true;
        }

        public void Aterrizar()
        {
            EnVuelo = false;
        }
    }
}
