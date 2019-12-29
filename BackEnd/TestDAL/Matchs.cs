namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Matchs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matchs()
        {
            CartonsJaunesHistory = new HashSet<CartonsJaunesHistory>();
            CartonsRougesHistory = new HashSet<CartonsRougesHistory>();
            FeuillesDeMatch = new HashSet<FeuillesDeMatch>();
            GoalsHistory = new HashSet<GoalsHistory>();
        }

        [Key]
        public Guid matchId { get; set; }

        public DateTime matchDate { get; set; }

        public Guid equipe1Id { get; set; }

        public Guid equipe2Id { get; set; }

        public int equipe1Points { get; set; }

        public int equipe2Points { get; set; }

        public bool isPlayed { get; set; }

        public DateTime lastUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartonsJaunesHistory> CartonsJaunesHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartonsRougesHistory> CartonsRougesHistory { get; set; }

        public virtual Equipes Equipes { get; set; }

        public virtual Equipes Equipes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeuillesDeMatch> FeuillesDeMatch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalsHistory> GoalsHistory { get; set; }
    }
}
