using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{ 

    [Table("JoueursParticipationHistory")]
public class JoueursParticipationModele
    {
        [Key]
        [Column(Order = 0)]
        public Guid joueurId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid feuilleId { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual FeuillesDeMatchModele FeuillesDeMatch { get; set; }

        public virtual JoueursModele Joueurs { get; set; }
    }
}
