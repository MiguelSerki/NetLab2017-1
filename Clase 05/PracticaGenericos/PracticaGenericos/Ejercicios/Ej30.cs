using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGenericos.Ejercicios
{

    //Resolver el ejercicio 16 aplicando interfaces.

    class Ej30
    {

    }

    public interface IAnimal
    {
        string Nombre { get; set; }
        void Saludar();
    }

    public class Gato : IAnimal
    {
        public string Nombre { get; set; }

        public Gato(string nombre)
        {
            this.Nombre = nombre;
        }

        public void Saludar()
        {
            Console.WriteLine($"{this.Nombre} dice miau");
        }
    }

    public class Perro : IAnimal
    {
        public string Nombre { get; set; }

        public Perro(string nombre)
        {
            Nombre = nombre;
        }

        public void Saludar()
        {
            Console.WriteLine($"{this.Nombre} dice guau guau");
        }
    }

    public class Pajaro : IAnimal
    {
        public string Nombre { get; set; }

        public Pajaro(string nombre)
        {
            Nombre = nombre;
        }

        public void Saludar()
        {
            Console.WriteLine($"{this.Nombre} dice pio pio");
        }
    }
}
