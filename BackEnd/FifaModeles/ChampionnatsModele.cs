using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{

    [Table("Championnats")]
    public class ChampionnatsModele
    {

        [Key]
        public Guid championnatId { get; set; }

        public int annee { get; set; }

        public DateTime lastUpdate { get; set; }
    }
}
