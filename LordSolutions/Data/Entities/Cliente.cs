using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = null;

        public string Telefono { get; set; } = null;
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

        public List<Factura> Facturas { get; set; }
    }

}
