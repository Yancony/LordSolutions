﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LordSolutions.Data.Request;
using LordSolutions.Data.Response;

namespace LordSolutions.Data.Entities
{
    public class Factura
    {
        public Factura()
        {
            //Cliente = new Cliente();
            //DetallesDeFactura = new List<DetalleDeFactura>();
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
        public bool Modificar(FacturaRequest factura)
        {
            var cambio = false;
            if (Id != factura.Id)
            {
                Id = factura.Id;
                cambio = true;
            }
            if (IdCliente != factura.IdCliente)
            {
                IdCliente = factura.IdCliente;
                cambio = true;
            }
            if (Fecha != factura.Fecha)
            {
                Fecha = factura.Fecha;
                cambio = true;
            }
            return cambio;
        }
        public FacturaResponse ToResponse()
        => new FacturaResponse()
        {
            Id = Id,
            IdCliente = IdCliente,
            Fecha = Fecha,
        };
    }

}
