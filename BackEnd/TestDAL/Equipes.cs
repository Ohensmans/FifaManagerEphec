namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipes()
        {
            EquipesParticipationHistory = new HashSet<EquipesParticipationHistory>();
            FeuillesDeMatch = new HashSet<FeuillesDeMatch>();
            Matchs = new HashSet<Matchs>();
            Matchs1 = new HashSet<Matchs>();
            TransfertsHistory = new HashSet<TransfertsHistory>();
        }

        [Key]
        public Guid equipeId { get; set; }

        [Required]
        [StringLength(50)]
        public string nom { get; set; }

        public DateTime lastUpdate { get; set; }

        [Required]
        public string logoPath { get; set; }

        public bool enoughPlayers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipesParticipationHistory> EquipesParticipationHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeuillesDeMatch> FeuillesDeMatch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matchs> Matchs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matchs> Matchs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransfertsHistory> TransfertsHistory { get; set; }
    }
}
