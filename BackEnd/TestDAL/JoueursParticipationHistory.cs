namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JoueursParticipationHistory")]
    public partial class JoueursParticipationHistory
    {
        [Key]
        [Column(Order = 0)]
        public Guid joueurId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid feuilleId { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual FeuillesDeMatch FeuillesDeMatch { get; set; }

        public virtual Joueurs Joueurs { get; set; }
    }
}
