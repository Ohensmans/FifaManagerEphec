using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("EquipesParticipationHistory")]
    public class EquipesParticipationModele
    {

        public EquipesParticipationModele(Guid equipeId, Guid championnatId)
        {
            this.championnatId = championnatId;
            this.equipeId = equipeId;
            this.lastUpdate = DateTime.Now;
        }


        [Key]
        [Column(Order = 0)]
        public Guid equipeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid championnatId { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual ChampionnatsModele Championnats { get; set; }

        public virtual EquipesModele Equipes { get; set; }
    }
}
