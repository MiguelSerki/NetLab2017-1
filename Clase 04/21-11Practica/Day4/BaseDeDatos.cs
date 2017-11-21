using System.Collections.Generic;

namespace Day4
{
    public static class BaseDeDatos
    {
        public static List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>
        {
            new Estudiante
            {
                Apellido = "Revoledo",
                Legajo = "40608",
                Nombre = "David"
            },
            new Estudiante
            {
                Apellido = "Araujo",
                Legajo = "23331",
                Nombre = "Cesar"
            }
        };

        public static List<Profesor> Profesores { get; set; } = new List<Profesor>
        {
            new Profesor
            {
                Apellido = "Revoledo",
                Materia = ".Net",
                Nombre = "David",
                Dni = "35444444"
            }
        };

        public static List<Ayudante> Ayudantes { get; set; } = new List<Ayudante>
        {
            new Ayudante
            {
                Apellido = "Morelli",
                Nombre = "Kevin",
                Dni = "35444444",
                Experiencia = "1",
                Ingreso = "2016",
                Legajo = "255"
            }
        };
    }
}