using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("CartonsJaunesHistory")]
    public class CartonsJaunesModele
    {
        [Key]
        public Guid carteJauneId { get; set; }

        public Guid joueurId { get; set; }

        public Guid matchId { get; set; }

        public bool isActive { get; set; }

        public int minuteRecue { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual JoueursModele Joueurs { get; set; }

        public virtual MatchsModele Matchs { get; set; }

    }
}
