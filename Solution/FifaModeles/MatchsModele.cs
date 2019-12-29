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
        [Key]
        public Guid matchId { get; set; }

        public DateTime matchDate { get; set; }

        public Guid equipe1Id { get; set; }

        public Guid equipe2Id { get; set; }

        public int equipe1Points { get; set; }

        public int equipe2Points { get; set; }

        public bool isPlayed { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual EquipesModele Equipes1 { get; set; }

        public virtual EquipesModele Equipes2 { get; set; }
    }
}
