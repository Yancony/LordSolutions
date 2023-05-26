using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Entities
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; }

        public List<DetalleDeFactura> DetallesDeFactura { get; set; }
    }

}
