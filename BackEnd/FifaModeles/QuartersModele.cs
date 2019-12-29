using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("Quarters")]
    public class QuartersModele
    {
        public Guid quartersId { get; set; }

        public DateTime dateDebut { get; set; }

        public DateTime dateFin { get; set; }

        public DateTime lastUpdate { get; set; }

        public Guid championnatId { get; set; }

        public virtual ChampionnatsModele Championnats { get; set; }
    }
}
