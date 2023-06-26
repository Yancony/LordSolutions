using LordSolutions.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Response
{
    public class FacturaResponse
    {
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(IdCliente))]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Cliente> DetallesDeFactura { get; set; }
    }
}
