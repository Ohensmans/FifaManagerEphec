using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("FeuillesDeMatch")]
    public class FeuillesDeMatchModele
    {

        [Key]
        public Guid feuilleId { get; set; }

        public Guid matchId { get; set; }

        public Guid equipeId { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual EquipesModele Equipes { get; set; }

        public virtual MatchsModele Matchs { get; set; }
    }
}
