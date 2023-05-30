using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using LordSolutions.Data.Request;

namespace LordSolutions.Data.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Facturas = new List<Factura>(); 
        }
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public List<Factura> Facturas { get; set; }

        public static Cliente Crear(ClienteRequest cliente)
        => new Cliente()
        {
            Id = cliente.Id,
            Nombre = cliente.Nombre,
            Telefono = cliente.Telefono,
            Direccion = cliente.Direccion,
            Facturas = cliente.Facturas,
        };
       
    }

}
