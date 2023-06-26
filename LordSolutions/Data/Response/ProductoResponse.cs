using LordSolutions.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Response
{
    public class ProductoResponse
    {
        public int Id { get; set; }

        [Required]
        public int IdProveedor { get; set; }
        [ForeignKey(nameof(IdProveedor))]
        public virtual Proveedor Proveedor { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public virtual ICollection<Cliente> DetallesDeFactura { get; set; }
    }
}
