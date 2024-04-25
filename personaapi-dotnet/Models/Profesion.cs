using System.ComponentModel.DataAnnotations;

namespace personaapi_dotnet.Models
{
    public class Profesion
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Estudio> Estudios { get; set; } = [];

    }
}
