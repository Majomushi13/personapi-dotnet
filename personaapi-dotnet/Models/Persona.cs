using System.ComponentModel.DataAnnotations;

namespace personaapi_dotnet.Models
{
    public enum Genero { M , F }
    public class Persona
    {
        [Key]
        public int Cc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Genero Genero { get; set; }
        public int Edad { get; set; }
        public ICollection<Estudio> Estudios { get; set; } = [];
        public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();

    }
}

