using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LordSolutions.Data.Request;

namespace LordSolutions.Data.Entities
{
    public class Producto
    {
        public Producto()
        {
            DetallesDeFactura = new List<Cliente>();
            Proveedor = new Proveedor();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdProveedor { get; set; }
        [ForeignKey(nameof(IdProveedor))]
        public virtual Proveedor Proveedor { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        [Required,Column(TypeName ="decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public virtual ICollection<Cliente> DetallesDeFactura { get; set; }

        public static Producto Crear(ProductoRequest producto)
         => new Producto()
         {
            Id = producto.Id,
            IdProveedor = producto.IdProveedor,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Cantidad = producto.Cantidad,
         };
        public bool Modificar(ProductoRequest producto)
        {
            var cambio = false;
            if (Id != producto.Id)
            {
                Id = producto.Id;
                cambio = true;
            }
            if (IdProveedor != producto.IdProveedor)
            {
                IdProveedor = producto.IdProveedor;
                cambio = true;
            }
            if (Nombre != producto.Nombre)
            {
                Nombre = producto.Nombre;
                cambio = true;
            }
            if (Precio != producto.Precio)
            {
                Precio = producto.Precio;
                cambio = true;
            }
            if (Cantidad != producto.Cantidad)
            {
                Cantidad = producto.Cantidad;
                cambio = true;
            }
            return cambio;
        }
        public ProductoResponse ToResponse()
        => new ProductoResponse()
        {
            Id = Id,
            IdProveedor = IdProveedor,
            Nombre = Nombre,
            Precio = Precio,
            Cantidad = Cantidad,
        };
    }

}
