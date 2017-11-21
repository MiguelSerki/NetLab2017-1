namespace Day4
{
    public abstract class Persona
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public abstract string Presentacion();
    }
}