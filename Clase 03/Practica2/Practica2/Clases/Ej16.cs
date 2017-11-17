using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Clases
{
    abstract class Animal
    {
        public string Nombre { get; set; }

        public abstract void Saludar();
    }

    class Perro : Animal
    {
        public override void Saludar()
        {
            Console.WriteLine($"{Nombre}: guau guau");
        }

    }

    class Gato : Animal
    {
        public override void Saludar()
        {
            Console.WriteLine($"{Nombre}: miau");
        }
    }

    class Pajaro : Animal
    {
        public override void Saludar()
        {
            Console.WriteLine($"{Nombre}: pio pio");
        }
    }
}
