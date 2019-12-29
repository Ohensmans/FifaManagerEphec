namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Joueurs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Joueurs()
        {
            CartonsJaunesHistory = new HashSet<CartonsJaunesHistory>();
            CartonsRougesHistory = new HashSet<CartonsRougesHistory>();
            GoalsHistory = new HashSet<GoalsHistory>();
            JoueursParticipationHistory = new HashSet<JoueursParticipationHistory>();
            TransfertsHistory = new HashSet<TransfertsHistory>();
        }

        [Key]
        public Guid joueurId { get; set; }

        [Required]
        [StringLength(50)]
        public string nom { get; set; }

        [Required]
        [StringLength(50)]
        public string prenom { get; set; }

        public DateTime lastUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartonsJaunesHistory> CartonsJaunesHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartonsRougesHistory> CartonsRougesHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalsHistory> GoalsHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JoueursParticipationHistory> JoueursParticipationHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransfertsHistory> TransfertsHistory { get; set; }
    }
}
