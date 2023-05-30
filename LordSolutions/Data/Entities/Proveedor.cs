﻿using System.ComponentModel.DataAnnotations;

namespace LordSolutions.Data.Entities
{
    public class Proveedor
    {
        public Proveedor()
        {
            Productos = new List<Producto>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? CorreoElectronico { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }

}
