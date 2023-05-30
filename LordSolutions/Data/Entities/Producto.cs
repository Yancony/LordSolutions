using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }

}
