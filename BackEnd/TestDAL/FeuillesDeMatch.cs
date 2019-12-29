namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeuillesDeMatch")]
    public partial class FeuillesDeMatch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FeuillesDeMatch()
        {
            JoueursParticipationHistory = new HashSet<JoueursParticipationHistory>();
        }

        [Key]
        public Guid feuilleId { get; set; }

        public Guid matchId { get; set; }

        public Guid equipeId { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual Equipes Equipes { get; set; }

        public virtual Matchs Matchs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JoueursParticipationHistory> JoueursParticipationHistory { get; set; }
    }
}
