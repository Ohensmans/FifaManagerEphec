using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("Matchs")]
    public class MatchsModele
    {
        public MatchsModele()
        {
            CartonsJaunesHistory = new HashSet<CartonsJaunesModele>();
            CartonsRougesHistory = new HashSet<CartonsRougesModele>();
            FeuillesDeMatch = new HashSet<FeuillesDeMatchModele>();
            GoalsHistory = new HashSet<GoalsModele>();
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
        public virtual ICollection<CartonsJaunesModele> CartonsJaunesHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartonsRougesModele> CartonsRougesHistory { get; set; }

        public virtual EquipesModele Equipes1 { get; set; }

        public virtual EquipesModele Equipes2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeuillesDeMatchModele> FeuillesDeMatch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoalsModele> GoalsHistory { get; set; }
    }
}
