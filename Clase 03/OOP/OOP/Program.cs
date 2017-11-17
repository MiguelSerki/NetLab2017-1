using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Crea una clase llamada Cuenta que tendra los sig atributos:
    titular y cantidad (puede tener decimales).                                 X        

    El titular sera obligatorio y la cantidad es opcional.
    Crea dos constructores que cumpla lo anterior.                              X

    Crea sus propiedades.                                                       X

    Tendra dos metodos especiales:

    Ingresar(decimal cantidad): se ingresa una cantidad a la cuenta,
    si la cantidad introducida es negativa, no se hara nada.

    Retirar(decimal cantidad): se retira una cantidad de la cuenta,
    si restando la cantidad actual a la que nos pasan es negativa,
    la cantidad pasa a ser 0.
*/

namespace Cuenta
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Cuenta("Jorge", 250.0f);
            c.Retirar(2500.0f);
            Console.Read();
           
        }
    }

    class Cuenta
    {
        public float Cantidad { get; set; }
        public string Titular { get; set; }

        public Cuenta(string titular, float cantidad)
            :this(titular)
        {
            Cantidad = cantidad;
        }

        public Cuenta(string titular)
        {
            Titular = titular;
        }

        public void Ingresar(float monto)
        {
            if (monto > 0)
            {
                Cantidad += monto;
                Console.WriteLine($"Usted ha ingresado un monto de {monto}$, su saldo actual es: {Cantidad}");
            }
        }

        public void Retirar(float monto)
        {
            float retirado = 0;
            float resultado = Cantidad - monto;
            if (resultado > 0) { 
                Cantidad = resultado;
                retirado = monto;
            }
            else
            {
                retirado = Cantidad;
                Cantidad = 0;
            }
            Console.WriteLine($"Usted ha retirado un monto de {retirado}$, su saldo actual es: {Cantidad}");
        }

    }

}
