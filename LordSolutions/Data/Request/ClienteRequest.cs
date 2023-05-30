using LordSolutions.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Request
{
    public class ClienteRequest
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null;

        public string Telefono { get; set; } = null;

        public string Direccion { get; set; } = null;

        public List<FacturaRequest> Facturas { get; set; }
    }
}
