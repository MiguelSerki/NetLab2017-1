using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Clases
{

    class Auto
    {
        public int Precio { get; set; }
        public string Modelo { get; set; }

        public Auto(string modelo,int precio)
        {
            Modelo = modelo;
            Precio = precio;
        }

    }

    class Venta
    {
        public int Cantidad { get; set; }
        public Auto AutoVendido { get; set; }

        public Venta(Auto auto, int cant)
        {
            AutoVendido = auto;
            Cantidad = cant;
        }

        public int PrecioTotal()
        {
            return AutoVendido.Precio * Cantidad;
        }
    }

    class Centro
    {
        public List<Venta> Ventas { get; set; }
        public int CentroId { get; set; }

        public Centro(int id)
        {
            CentroId = id;
            Ventas = new List<Venta>();
        }

        public void EfectuarVenta(Auto auto, int cant)
        {
            Ventas.Add(new Venta(auto, cant));
        }

    }

    class Empresa
    {
        public List<Centro> Centros { get; set; }

        public static List<Auto> Autos { get; set; }

        public void InstanciarEj()
        {
            Autos = new List<Auto>
            {
                new Auto("Modelo 1",200000),
                new Auto("Modelo 2",300000),
                new Auto("Modelo 3",400000),
                new Auto("Modelo 4",500000)
            };

            Centros = new List<Centro>
            {
                new Centro(1),
                new Centro(2),
                new Centro(3)
            };

            Centros[0].EfectuarVenta();

        }
    }

}
