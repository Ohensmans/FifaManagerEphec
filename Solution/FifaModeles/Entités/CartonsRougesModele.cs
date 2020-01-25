using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("CartonsRougesHistory")]
    public class CartonsRougesModele
    {
        [Key]
        public Guid carteRougeId { get; set; }

        public Guid joueurId { get; set; }

        public Guid matchId { get; set; }

        public int nombreSuspensionsRestantes { get; set; }

        public int minuteRecue { get; set; }

        public DateTime lastUpdate { get; set; }

        public Guid equipeId { get; set; }

        public virtual EquipesModele Equipes { get; set; }

        public virtual JoueursModele Joueurs { get; set; }

        public virtual MatchsModele Matchs { get; set; }
    }
}
