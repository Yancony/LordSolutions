﻿using LordSolutions.Data.Entities;
using System.ComponentModel.DataAnnotations;
using LordSolutions.Data.Request;

namespace LordSolutions.Data.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null;

        public string Telefono { get; set; } = null;

        public string Direccion { get; set; } = null;

        public List<FacturaRequest> Facturas { get; set; }
        public ClienteRequest ToRequest() {
            return new ClienteRequest
            {
                Id = Id,
                Nombre = Nombre,
                Telefono = Telefono,
                Direccion = Direccion
            };
        }
    }
}
