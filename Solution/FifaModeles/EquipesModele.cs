using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("Equipes")]
    public class EquipesModele
    {
        public EquipesModele()
        {
            CartonsJaunesHistory = new HashSet<CartonsJaunesModele>();
            CartonsRougesHistory = new HashSet<CartonsRougesModele>();
            EquipesParticipationHistory = new HashSet<EquipesParticipationModele>();
            FeuillesDeMatch = new HashSet<FeuillesDeMatchModele>();
            GoalsHistory = new HashSet<GoalsModele>();
            Matchs1 = new HashSet<MatchsModele>();
            Matchs2 = new HashSet<MatchsModele>();
            TransfertsHistory = new HashSet<TransfertsModele>();
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
        public virtual ICollection<CartonsJaunesModele> CartonsJaunesHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartonsRougesModele> CartonsRougesHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipesParticipationModele> EquipesParticipationHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeuillesDeMatchModele> FeuillesDeMatch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalsModele> GoalsHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchsModele> Matchs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchsModele> Matchs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransfertsModele> TransfertsHistory { get; set; }
    }
}
