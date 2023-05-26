using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Entities
{
    public class DetalleDeFactura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public Producto Producto { get; set; }

        public Factura Factura { get; set; }
    }

}
