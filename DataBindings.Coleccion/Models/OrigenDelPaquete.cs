namespace DataBindings.Coleccion.Models
{
   public class OrigenDelPaquete
    {
        public string Nombre { get; set; } = string.Empty;
        public string Origen { get; set; } = string.Empty;
        public bool EstaHabilitado { get; set;} = false;

        public override string ToString()
        {
            return $"{Nombre} - ({Origen}";
        }

    }
}
