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

        public Auto(string modelo, int precio)
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

            Centros[0].EfectuarVenta(Autos[0], 5);
            Centros[1].EfectuarVenta(Autos[3], 2);
            Centros[2].EfectuarVenta(Autos[1], 1);
            Centros[2].EfectuarVenta(Autos[2], 3);
            /*
            VentasTotales();
            VentasPorCentro();
            PorcentajeVentas();*/
            PorcentajeVentasAuto();
            Console.Read();
        }

        public void VentasTotales()
        {
            int ventaTotal = 0;
            foreach (var centro in Centros)
            {
                foreach (var venta in centro.Ventas)
                {
                    int dinero = venta.AutoVendido.Precio * venta.Cantidad;
                    ventaTotal += dinero;
                }
            }
            Console.WriteLine($"El total es: {ventaTotal}$");
        }

        public void VentasPorCentro()
        {
            foreach (var centro in Centros)
            {
                int ventaTotal = 0;
                foreach (var venta in centro.Ventas)
                {
                    int dinero = venta.AutoVendido.Precio * venta.Cantidad;
                    ventaTotal += dinero;
                }
                Console.WriteLine($"El total de ventas en el centro {centro.CentroId} es de: {ventaTotal}$");
            }
        }

        public void PorcentajeVentas()
        {
            int totalVentas = 0;

            foreach (var centro in Centros)
            {
                totalVentas += centro.Ventas.Count();
            }

            foreach (var centro in Centros)
            {
                int porcentaje = (centro.Ventas.Count() * 100) / totalVentas;
                Console.WriteLine($"El centro {centro.CentroId} representa un total de {porcentaje}% de las ventas");
            }

        }

        public void PorcentajeVentasAuto()
        {

            foreach (var centro in Centros)
            {
                int[] totalVentas = new int[] { 0, 0, 0, 0 };

                foreach (var venta in centro.Ventas)
                {
                    switch (venta.AutoVendido.Modelo)
                    {
                        case "Modelo 1":
                            totalVentas[0] += venta.Cantidad;
                            break;
                        case "Modelo 2":
                            totalVentas[1] += venta.Cantidad;
                            break;
                        case "Modelo 3":
                            totalVentas[2] += venta.Cantidad;
                            break;
                        case "Modelo 4":
                            totalVentas[3] += venta.Cantidad;
                            break;
                    }
                }

                int ventaTotalAutos = 0;
                for (int i = 0; i < 4; i++)
                {
                    ventaTotalAutos += totalVentas[i];
                }
                Console.WriteLine($"En el centro {centro.CentroId}");
                for (int i = 0; i < 4; i++)
                {
                    int porcentaje = (totalVentas[i] * 100) / ventaTotalAutos;
                    Console.WriteLine($"El {Autos[i].Modelo} representa un {porcentaje}% de las ventas");
                }
                Console.WriteLine();
            }
        }

    }

}
