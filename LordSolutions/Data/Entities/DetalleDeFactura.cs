using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LordSolutions.Data.Request;

namespace LordSolutions.Data.Entities
{
    public class DetalleDeFactura
    {
        public DetalleDeFactura()
        {
            Producto= new Producto();
            Factura= new Factura();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required,Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Factura Factura { get; set; }

        public static DetalleDeFactura Crear(DetalleDeFacturaRequest detalle)
        => new DetalleDeFactura()
        {
            Id = detalle.Id,
            IdFactura = detalle.IdFactura,
            Cantidad = detalle.Cantidad,
            Precio = detalle.Precio,    
            Producto = detalle.Producto,
            Factura = detalle.Factura,
        };

    }

}
