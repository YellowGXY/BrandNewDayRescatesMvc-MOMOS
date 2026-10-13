using System.ComponentModel.DataAnnotations;

namespace BrandNewDayRescatesMvc.Models
{
    public class Rescate
    {
        [Key]
        public int RescateId { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Villano { get; set; }

        public string Resultado { get; set; }

        // Clave foránea hacia Heroe
        public int HeroeId { get; set; }

        // Propiedad de navegación
        public virtual Heroe Heroe { get; set; }
    }
}