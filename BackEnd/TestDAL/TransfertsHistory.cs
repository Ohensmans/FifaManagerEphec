namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransfertsHistory")]
    public partial class TransfertsHistory
    {
        [Key]
        [Column(Order = 0)]
        public Guid joueurId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid equipeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime dateDebut { get; set; }

        public DateTime? dateFin { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual Equipes Equipes { get; set; }

        public virtual Joueurs Joueurs { get; set; }
    }
}
