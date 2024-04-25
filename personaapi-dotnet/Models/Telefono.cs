using System.ComponentModel.DataAnnotations;

namespace personaapi_dotnet.Models
{
    public class Telefono
    {
        [Key]
        public string Numero { get; set; }
        public string Operador { get; set;}
        public int PersonaCedula { get; set; }

    }
}
