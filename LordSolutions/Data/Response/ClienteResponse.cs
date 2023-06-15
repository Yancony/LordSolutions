using LordSolutions.Data.Entities;
using System.ComponentModel.DataAnnotations;
using LordSolutions.Data.Request;

namespace LordSolutions.Data.Resquest
{
    public class ClienteResponse
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null;

        public string Telefono { get; set; } = null;

        public string Direccion { get; set; } = null;

        public List<FacturaRequest> Facturas { get; set; }
    }
}
