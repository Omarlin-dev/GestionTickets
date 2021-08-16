namespace GestionTickets.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaGeneracion { get; set; }

        public int IdEstado { get; set; }

        public int IdUsuario { get; set; }

        public int IdResponsable { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Solucion { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Responsable Responsable { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
