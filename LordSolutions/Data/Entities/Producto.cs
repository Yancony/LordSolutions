using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdProveedor { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public List<DetalleDeFactura> DetallesDeFactura { get; set; }
    }

}
