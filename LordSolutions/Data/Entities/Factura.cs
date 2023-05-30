using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LordSolutions.Data.Request;

namespace LordSolutions.Data.Entities
{
    public class Factura
    {
        public Factura()
        {
            Cliente= new DetalleDeFactura();
            DetallesDeFactura = new List<Cliente>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(IdCliente))]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Cliente> DetallesDeFactura { get; set; }

        public static Factura Crear(FacturaRequest factura)
       => new Factura()
       {
           Id = factura.Id,
           IdCliente = factura.IdCliente,
           Fecha = factura.Fecha,
       };

    }

}
