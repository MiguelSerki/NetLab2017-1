using System;
using System.Linq;

namespace Day4
{
    public class Program
    {

        static void Main(string[] args)
        {
            string opcion;

            do
            {
                Linea();
                Console.WriteLine("Ingrese la opcion deseada 'p' Profesores - 'e' Estudiantes - 'a' Ayudantes, 's' Salir");
                opcion = Console.ReadLine().ToLower();

                switch (opcion)
                {
                    case "p":
                        EjecutarMenuProfesores();
                        break;

                    case "e":
                        EjecutarMenuEstudiantes();
                        break;
                    case "a":
                        EjecutarMenuAyudantes();
                        break;
                }
            } while (opcion != "s");

            Linea();
            Console.WriteLine("Fin del programa, ingrese una tecla para continuar");
            Console.ReadLine();
        }

        private static void EjecutarMenuAyudantes()
        {
            Linea();
            Console.WriteLine("Listado 'l' Consultar 'c' Agregar 'a' Modificar 'm' Eliminar 'e'");
            var opcion = Console.ReadLine().ToLower();

            switch (opcion)
            {
                case "l":
                    var ayudantes = BaseDeDatos.Ayudantes;
                    Linea();
                    Console.WriteLine("Ayudantes : ");
                    foreach (var p in ayudantes)
                    {
                        MostrarAyudante(p);
                    }

                    break;

                case "c":
                    Linea();
                    Console.WriteLine("Ingrese el legajo a buscar");
                    var legajoParaBuscar = Console.ReadLine();

                    Ayudante ayudante = null;

                    foreach (var p in BaseDeDatos.Ayudantes)
                    {
                        if (p.Legajo == legajoParaBuscar)
                        {
                            ayudante = p;
                            break;
                        }
                    }

                    if (ayudante != null)
                    {
                        MostrarAyudante(ayudante);
                    }
                    else
                    {
                        Console.WriteLine("No existe el ayudante ingresado");
                    }

                    break;

                case "a":
                    Linea();
                    Console.WriteLine("Ingrese nombre");
                    var nuevoAyudanteNombre = Console.ReadLine();
                    if (nuevoAyudanteNombre.Length > 50)
                    {
                        Console.WriteLine("ERROR! Nombre no puede tener más de 50 caracteres.");
                        break;
                    }

                    Console.WriteLine("Ingrese apellido");
                    var nuevoAyudanteApellido = Console.ReadLine();
                    if (nuevoAyudanteApellido.Length > 50)
                    {
                        Console.WriteLine("ERROR! Apellido no puede tener más de 50 caracteres.");
                        break;
                    }

                    Console.WriteLine("Ingrese legajo");
                    var nuevoAyudanteLegajo = Console.ReadLine();

                    Console.WriteLine("Ingrese año de ingreso");
                    var nuevoAyudanteIngreso = Console.ReadLine();

                    Console.WriteLine("Ingrese DNI");
                    var nuevoAyudanteDni = Console.ReadLine();

                    Console.WriteLine("Ingrese Experiencia");
                    var nuevoAyudanteExperiencia = Console.ReadLine();

                    var nuevoAyudante = new Ayudante
                    {
                        Apellido = nuevoAyudanteApellido,
                        Legajo = nuevoAyudanteLegajo,
                        Nombre = nuevoAyudanteNombre,
                        Ingreso = nuevoAyudanteIngreso,
                        Dni = nuevoAyudanteDni,
                        Experiencia = nuevoAyudanteExperiencia
                    };

                    BaseDeDatos.Ayudantes.Add(nuevoAyudante);
                    Linea();
                    Console.WriteLine("Ayudante agregado correctamente");
                    break;

                case "m":
                    Linea();
                    Console.WriteLine("Ingrese el legajo a buscar");
                    var legajoParaEditar = Console.ReadLine();

                    Ayudante ayudanteParaEditar = null;

                    foreach (var p in BaseDeDatos.Ayudantes)
                    {
                        if (p.Legajo == legajoParaEditar)
                        {
                            ayudanteParaEditar = p;
                            break;
                        }
                    }

                    if (ayudanteParaEditar != null)
                    {
                        Linea();
                        Console.WriteLine("Ingrese nuevo nombre");
                        var editarAyudanteNombre = Console.ReadLine();
                        if (editarAyudanteNombre.Length > 50)
                        {
                            Console.WriteLine("ERROR! Nombre no puede tener más de 50 caracteres.");
                            break;
                        }

                        Console.WriteLine("Ingrese nuevo apellido");
                        var editarAyudanteApellido = Console.ReadLine();
                        if (editarAyudanteApellido.Length > 50)
                        {
                            Console.WriteLine("ERROR! Apellido no puede tener más de 50 caracteres.");
                            break;
                        }

                        Console.WriteLine("Ingrese nuevo legajo");
                        var editarAyudanteLegajo = Console.ReadLine();

                        Console.WriteLine("Ingrese nuevo año de ingreso");
                        var editarAyudanteIngreso = Console.ReadLine();

                        Console.WriteLine("Ingrese nuevo DNI");
                        var editarAyudanteDni = Console.ReadLine();

                        Console.WriteLine("Ingrese nuevos años de experiencia");
                        var editarAyudanteExperiencia = Console.ReadLine();

                        ayudanteParaEditar.Nombre = editarAyudanteNombre;
                        ayudanteParaEditar.Apellido = editarAyudanteApellido;
                        ayudanteParaEditar.Legajo = editarAyudanteLegajo;
                        ayudanteParaEditar.Ingreso = editarAyudanteIngreso;
                        ayudanteParaEditar.Dni = editarAyudanteDni;
                        ayudanteParaEditar.Experiencia = editarAyudanteExperiencia;

                        Linea();
                        Console.WriteLine("Ayudante editado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No existe el ayudante ingresado");
                    }
                    break;

                case "e":
                    Linea();
                    Console.WriteLine("Ingrese el legajo a buscar");
                    var legajoParaRemover = Console.ReadLine();

                    Ayudante ayudanteParaRemover = null;

                    foreach (var p in BaseDeDatos.Ayudantes)
                    {
                        if (p.Legajo == legajoParaRemover)
                        {
                            ayudanteParaRemover = p;
                            break;
                        }
                    }

                    if (ayudanteParaRemover != null)
                    {
                        BaseDeDatos.Ayudantes.Remove(ayudanteParaRemover);

                        Linea();
                        Console.WriteLine("Ayudante eliminado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No existe el ayudante ingresado");
                    }

                    break;
            }

            opcion = Console.ReadLine();
        }

        private static void EjecutarMenuEstudiantes()
        {
            Linea();
            Console.WriteLine("Listado 'l' Consultar 'c' Agregar 'a' Modificar 'm' Eliminar 'e'");
            var opcion = Console.ReadLine().ToLower();

            switch (opcion)
            {
                case "l":
                    var estudiantes = BaseDeDatos.Estudiantes;
                    Linea();
                    Console.WriteLine("Estudiantes : ");
                    foreach (var p in estudiantes)
                    {
                        MostrarEstudiante(p);
                    }

                    break;

                case "c":
                    Linea();
                    Console.WriteLine("Ingrese el legajo a buscar");
                    var legajoParaBuscar = Console.ReadLine();

                    Estudiante estudiante = null;

                    foreach (var p in BaseDeDatos.Estudiantes)
                    {
                        if (p.Legajo == legajoParaBuscar)
                        {
                            estudiante = p;
                            break;
                        }
                    }

                    if (estudiante != null)
                    {
                        MostrarEstudiante(estudiante);
                    }
                    else
                    {
                        Console.WriteLine("No existe el estudiante ingresado");
                    }

                    break;

                case "a":
                    Linea();
                    Console.WriteLine("Ingrese nombre");
                    var nuevoEstudianteNombre = Console.ReadLine();
                    if (nuevoEstudianteNombre.Length > 50)
                    {
                        Console.WriteLine("ERROR! Nombre no puede tener más de 50 caracteres.");
                        break;
                    }

                    Console.WriteLine("Ingrese apellido");
                    var nuevoEstudianteApellido = Console.ReadLine();
                    if (nuevoEstudianteApellido.Length > 50)
                    {
                        Console.WriteLine("ERROR! Apellido no puede tener más de 50 caracteres.");
                        break;
                    }

                    Console.WriteLine("Ingrese legajo");
                    var nuevoEstudianteLegajo = Console.ReadLine();

                    Console.WriteLine("Ingrese año de ingreso");
                    var nuevoEstudianteIngreso = Console.ReadLine();


                    var nuevoEstudiante = new Estudiante
                    {
                        Apellido = nuevoEstudianteApellido,
                        Legajo = nuevoEstudianteLegajo,
                        Nombre = nuevoEstudianteNombre,
                        Ingreso = nuevoEstudianteIngreso
                    };

                    BaseDeDatos.Estudiantes.Add(nuevoEstudiante);
                    Linea();
                    Console.WriteLine("Estudiante agregado correctamente");
                    break;

                case "m":
                    Linea();
                    Console.WriteLine("Ingrese el legajo a buscar");
                    var legajoParaEditar = Console.ReadLine();

                    Estudiante EstudianteParaEditar = null;

                    foreach (var p in BaseDeDatos.Estudiantes)
                    {
                        if (p.Legajo == legajoParaEditar)
                        {
                            EstudianteParaEditar = p;
                            break;
                        }
                    }

                    if (EstudianteParaEditar != null)
                    {
                        Linea();
                        Console.WriteLine("Ingrese nuevo nombre");
                        var editarEstudianteNombre = Console.ReadLine();
                        if (editarEstudianteNombre.Length > 50)
                        {
                            Console.WriteLine("ERROR! Nombre no puede tener más de 50 caracteres.");
                            break;
                        }

                        Console.WriteLine("Ingrese nuevo apellido");
                        var editarEstudianteApellido = Console.ReadLine();
                        if (editarEstudianteApellido.Length > 50)
                        {
                            Console.WriteLine("ERROR! Apellido no puede tener más de 50 caracteres.");
                            break;
                        }

                        Console.WriteLine("Ingrese nuevo legajo");
                        var editarEstudianteLegajo = Console.ReadLine();

                        Console.WriteLine("Ingrese nuevo año de ingreso");
                        var editarEstudianteIngreso = Console.ReadLine();

                        EstudianteParaEditar.Nombre = editarEstudianteNombre;
                        EstudianteParaEditar.Apellido = editarEstudianteApellido;
                        EstudianteParaEditar.Legajo = editarEstudianteLegajo;
                        EstudianteParaEditar.Ingreso = editarEstudianteIngreso;

                        Linea();
                        Console.WriteLine("Estudiante editado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No existe el estudiante ingresado");
                    }
                    break;

                case "e":
                    Linea();
                    Console.WriteLine("Ingrese el legajo a buscar");
                    var legajoParaRemover = Console.ReadLine();

                    Estudiante estudianteParaRemover = null;

                    foreach (var p in BaseDeDatos.Estudiantes)
                    {
                        if (p.Legajo == legajoParaRemover)
                        {
                            estudianteParaRemover = p;
                            break;
                        }
                    }

                    if (estudianteParaRemover != null)
                    {
                        BaseDeDatos.Estudiantes.Remove(estudianteParaRemover);

                        Linea();
                        Console.WriteLine("Estudiante eliminado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No existe el estudiante ingresado");
                    }

                    break;
            }

            opcion = Console.ReadLine();
        }

        private static void EjecutarMenuProfesores()
        {
            Linea();
            Console.WriteLine("Listado 'l' Consultar 'c' Agregar 'a' Modificar 'm' Eliminar 'e'");
            var opcion = Console.ReadLine().ToLower();

            switch (opcion)
            {
                case "l":
                    var profesores = BaseDeDatos.Profesores;
                    Linea();
                    Console.WriteLine("Profesores : ");
                    foreach (var p in profesores)
                    {
                        MostrarProfesor(p);
                    }

                    break;

                case "c":
                    Linea();
                    Console.WriteLine("Ingrese el dni a buscar");
                    var dniParaBuscar = Console.ReadLine();

                    Profesor profesor = null;

                    foreach (var p in BaseDeDatos.Profesores)
                    {
                        if (p.Dni == dniParaBuscar)
                        {
                            profesor = p;
                            break;
                        }
                    }

                    if (profesor != null)
                    {
                        MostrarProfesor(profesor);
                    }
                    else
                    {
                        Console.WriteLine("No existe el profesor ingresado");
                    }

                    break;

                case "a":
                    Linea();
                    Console.WriteLine("Ingrese nombre");
                    var nuevoProfesorNombre = Console.ReadLine();
                    if (nuevoProfesorNombre.Length > 50)
                    {
                        Console.WriteLine("ERROR! Nombre no puede tener más de 50 caracteres.");
                        break;
                    }

                    Console.WriteLine("Ingrese apellido");
                    var nuevoProfesorApellido = Console.ReadLine();
                    if (nuevoProfesorApellido.Length > 50)
                    {
                        Console.WriteLine("ERROR! Apellido no puede tener más de 50 caracteres.");
                        break;
                    }

                    Console.WriteLine("Ingrese dni");
                    var nuevoProfesorDni = Console.ReadLine();

                    Console.WriteLine("Ingrese materia");
                    var nuevoProfesorMateria = Console.ReadLine();

                    Console.WriteLine("Ingrese años de experiencia");
                    var nuevoProfesorExperiencia = Console.ReadLine();

                    var nuevoProfesor = new Profesor
                    {
                        Apellido = nuevoProfesorApellido,
                        Dni = nuevoProfesorDni,
                        Nombre = nuevoProfesorNombre,
                        Materia = nuevoProfesorMateria,
                        Experiencia = nuevoProfesorExperiencia
                    };

                    BaseDeDatos.Profesores.Add(nuevoProfesor);
                    Linea();
                    Console.WriteLine("Profesor agregado correctamente");
                    break;

                case "m":
                    Linea();
                    Console.WriteLine("Ingrese el dni a buscar");
                    var dniParaEditar = Console.ReadLine();

                    var profesorParaEditar = BaseDeDatos.Profesores.FirstOrDefault(x=> x.Dni == dniParaEditar);

                    if (profesorParaEditar != null)
                    {
                        Linea();
                        Console.WriteLine("Ingrese nuevo nombre");
                        var editarProfesorNombre = Console.ReadLine();
                        if (editarProfesorNombre.Length > 50)
                        {
                            Console.WriteLine("ERROR! Nombre no puede tener más de 50 caracteres.");
                            break;
                        }

                        Console.WriteLine("Ingrese nuevo apellido");
                        var editarProfesorApellido = Console.ReadLine();
                        if (editarProfesorApellido.Length > 50)
                        {
                            Console.WriteLine("ERROR! Apellido no puede tener más de 50 caracteres.");
                            break;
                        }


                        Console.WriteLine("Ingrese nuevo dni");
                        var editarProfesorDni = Console.ReadLine();

                        Console.WriteLine("Ingrese nueva materia");
                        var editarProfesorMateria = Console.ReadLine();

                        Console.WriteLine("Ingrese nuevos años de experiencia");
                        var editarProfesorExperiencia = Console.ReadLine();

                        profesorParaEditar.Nombre = editarProfesorNombre;
                        profesorParaEditar.Apellido = editarProfesorApellido;
                        profesorParaEditar.Dni = editarProfesorDni;
                        profesorParaEditar.Materia = editarProfesorMateria;
                        profesorParaEditar.Experiencia = editarProfesorExperiencia;

                        Linea();
                        Console.WriteLine("Profesor editado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No existe el profesor ingresado");
                    }
                    break;

                case "e":
                    Linea();
                    Console.WriteLine("Ingrese el dni a buscar");
                    var dniParaRemover = Console.ReadLine();

                    Profesor profesorParaRemover = null;

                    foreach (var p in BaseDeDatos.Profesores)
                    {
                        if (p.Dni == dniParaRemover)
                        {
                            profesorParaRemover = p;
                            break;
                        }
                    }

                    if (profesorParaRemover != null)
                    {
                        BaseDeDatos.Profesores.Remove(profesorParaRemover);

                        Linea();
                        Console.WriteLine("Profesor eliminado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No existe el profesor ingresado");
                    }

                    break;
            }

            opcion = Console.ReadLine();
        }

        private static void MostrarProfesor(Profesor p)
        {
            Console.WriteLine($"Nombre: {p.Nombre}, Apellido: {p.Apellido}, DNI: {p.Dni}, Materia: {p.Materia}, Años de experiencia: {p.Experiencia}, Sueldo: {p.CalcularSueldo()}");
        }

        private static void MostrarAyudante(Ayudante p)
        {
            Console.WriteLine($"Nombre: {p.Nombre}, Apellido: {p.Apellido}, DNI: {p.Dni}, Legajo: {p.Legajo}, Años de experiencia: {p.Experiencia}, Sueldo: {p.CalcularSueldo()}");
        }

        private static void MostrarEstudiante(Estudiante p)
        {
            Console.WriteLine($"Nombre: {p.Nombre}, Apellido: {p.Apellido}, Legajo: {p.Legajo}, Año de ingreso: {p.Ingreso}");
        }

        private static void Linea()
        {
            Console.WriteLine("======================");
        }
    }
}