using LordSolutions.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Request
{
    public class DetalleDeFacturaResponse
    {
        public int Id { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Factura Factura { get; set; }
    }
}
