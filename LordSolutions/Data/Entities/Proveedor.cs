using System.ComponentModel.DataAnnotations;
using LordSolutions.Data.Request;

namespace LordSolutions.Data.Entities
{
    public class Proveedor
    {
        public Proveedor()
        {
            Productos = new List<Producto>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? CorreoElectronico { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }

        public static Proveedor Crear(ProveedorRequest proveedor)
         => new Proveedor()
         {
            Id = proveedor.Id,
            Nombre = proveedor.Nombre,
            Telefono = proveedor.Telefono,
            CorreoElectronico = proveedor.CorreoElectronico,
         };
        public bool Modificar(ProveedorRequest proveedor)
        {
            var cambio = false;
            if (Id != proveedor.Id)
            {
                Id = proveedor.Id;
                cambio = true;
            }
            if (Nombre != proveedor.Nombre)
            {
                Nombre = proveedor.Nombre;
                cambio = true;
            }
            if (Telefono != proveedor.Telefono)
            {
                Telefono = proveedor.Telefono;
                cambio = true;
            }
            if (CorreoElectronico != proveedor.CorreoElectronico)
            {
                CorreoElectronico = proveedor.CorreoElectronico;
                cambio = true;
            }
            return cambio;
        }
        public ProveedorResponse ToResponse()
        => new ProveedorResponse()
        {
            Id = Id,
            Nombre = Nombre,
            Telefono = Telefono,
            CorreoElectronico = CorreoElectronico,
        };
    }

}
