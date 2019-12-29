namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Intersaisons
    {
        [Key]
        public Guid intersaisonID { get; set; }

        public DateTime dateDebut { get; set; }

        public DateTime dateFin { get; set; }

        public DateTime lastUpdate { get; set; }

        public Guid championnatId { get; set; }

        public virtual Championnats Championnats { get; set; }
    }
}
