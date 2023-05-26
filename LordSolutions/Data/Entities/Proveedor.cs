using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Entities
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string CorreoElectronico { get; set; }

        public List<Producto> Productos { get; set; }
    }

}
