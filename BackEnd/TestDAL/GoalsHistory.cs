namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoalsHistory")]
    public partial class GoalsHistory
    {
        [Key]
        public Guid goalId { get; set; }

        public Guid joueurId { get; set; }

        public Guid matchId { get; set; }

        public DateTime lastUpdate { get; set; }

        public int minuteMarque { get; set; }

        public virtual Joueurs Joueurs { get; set; }

        public virtual Matchs Matchs { get; set; }
    }
}
