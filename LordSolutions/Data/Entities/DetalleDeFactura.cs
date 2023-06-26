using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LordSolutions.Data.Request;
using LordSolutions.Data.Response;

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

        public bool Modificar(DetalleDeFacturaRequest detalle)
        {
            var cambio = false;
            if (Id != detalle.Id)
            {
                Id = detalle.Id;
                cambio = true;
            }
            if (IdFactura != detalle.IdFactura)
            {
                IdFactura = detalle.IdFactura;
                cambio = true;
            }
            if (Cantidad != detalle.Cantidad)
            {
                Cantidad = detalle.Cantidad;
                cambio = true;
            }
            if (Precio != detalle.Precio)
            {
                Precio = detalle.Precio;
                cambio = true;
            }
            if (Producto != detalle.Producto)
            {
                Producto = detalle.Producto;
                cambio = true;
            }
            if (Factura != detalle.Factura)
            {
                Factura = detalle.Factura;
                cambio = true;
            }
            return cambio;
        }
        public DetalleDeFacturaResponse ToResponse()
        => new DetalleDeFacturaResponse()
        {
            Id = Id,
            IdFactura = IdFactura,
            Cantidad = Cantidad,
            Precio = Precio,
            Producto = Producto,
            Factura = Factura,
        };

    }

}
