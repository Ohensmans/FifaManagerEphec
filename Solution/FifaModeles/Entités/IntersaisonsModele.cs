using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("Intersaisons")]
    public class IntersaisonsModele
    {
        public IntersaisonsModele(DateTime dateDebut, DateTime dateFin, Guid championnatId)
        {
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.lastUpdate = DateTime.Now;
            this.championnatId = championnatId;
            this.lastUpdate = DateTime.Now;
            this.intersaisonID = Guid.NewGuid();

        }


        [Key]
        public Guid intersaisonID { get; set; }

        public DateTime dateDebut { get; set; }

        public DateTime dateFin { get; set; }

        public DateTime lastUpdate { get; set; }

        public Guid championnatId { get; set; }

        public virtual ChampionnatsModele Championnats { get; set; }
    }
}
