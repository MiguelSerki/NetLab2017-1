using ClassLibrary2;
using ConsoleApp1.foo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {

            /*
            var a = new
            {
                Name = "Kev",
                Age = 23
            };

            Console.WriteLine($"Hola soy {a.Name} y tengo {a.Age}");

            Console.WriteLine("Cual es tu nombre?");
            string name = Console.ReadLine().ToString();
            Console.WriteLine($"Hola {name}");
            Console.Read();*/
            var x = new Class5();
            Console.WriteLine(x.myVar);
            Console.Read();
        }
    }
}
