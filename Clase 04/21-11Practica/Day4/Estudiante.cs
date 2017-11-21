namespace Day4
{
    public class Estudiante : Persona
    {
        public string Legajo { get; set; }

        public string Ingreso { get; set; }

        public override string Presentacion()
        {
            return $"Hola soy un estudiante {this.Apellido} {this.Nombre} legajo : {this.Legajo}";
        }
    }
    
}