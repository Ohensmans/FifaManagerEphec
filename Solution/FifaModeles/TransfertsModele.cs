using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("TransfertsHistory")]
    public class TransfertsModele
    {
        [Key]
        [Column(Order = 0)]
        public Guid joueurId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid equipeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime dateDebut { get; set; }

        public DateTime? dateFin { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual EquipesModele Equipes { get; set; }

        public virtual JoueursModele Joueurs { get; set; }
    }
}
