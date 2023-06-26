using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using LordSolutions.Data.Request;
using LordSolutions.Data.Response;

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

		[NotMapped]
        public List<Factura> Facturas { get; set; }

        public static Cliente Crear(ClienteRequest cliente)
        => new Cliente()
        {
            Id = cliente.Id,
            Nombre = cliente.Nombre,
            Telefono = cliente.Telefono,
            Direccion = cliente.Direccion,
        };
        public bool Modificar(ClienteRequest cliente)
        {
            var cambio = false;
            if (Id != cliente.Id)
            {
                Id = cliente.Id;
                cambio = true;            
            }
            if (Nombre != cliente.Nombre)
            {
                Nombre = cliente.Nombre;
                cambio = true;
            }
            if (Telefono != cliente.Telefono)
            {
                Telefono = cliente.Telefono;
                cambio = true;
            }
            if (Direccion != cliente.Direccion)
            {
                Direccion = cliente.Direccion;
                cambio = true;
            }
            return cambio;
        }
        public ClienteResponse ToResponse()
        => new ClienteResponse()
        {
           Id = Id,
           Nombre = Nombre,
           Telefono = Telefono,
           Direccion = Direccion,
        };
           
    }

}
