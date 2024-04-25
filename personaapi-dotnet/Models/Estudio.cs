using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace personaapi_dotnet.Models
{
    public class Estudio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String ProfesionId { get; set; }
        public int PersonaCedula { get; set; }
        public DateTime Fecha { get; set; }
        public string Universidad { get; set; }
    }
}
