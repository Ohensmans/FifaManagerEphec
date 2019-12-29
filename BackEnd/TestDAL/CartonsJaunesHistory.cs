namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CartonsJaunesHistory")]
    public partial class CartonsJaunesHistory
    {
        [Key]
        public Guid carteJauneId { get; set; }

        public Guid joueurId { get; set; }

        public Guid matchId { get; set; }

        public bool isActive { get; set; }

        public int minuteRecue { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual Joueurs Joueurs { get; set; }

        public virtual Matchs Matchs { get; set; }
    }
}
