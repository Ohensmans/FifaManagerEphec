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

        public ChampionnatsModele()
        {
            EquipesParticipationHistory = new HashSet<EquipesParticipationModele>();
            Intersaisons = new HashSet<IntersaisonsModele>();
            Quarters = new HashSet<QuartersModele>();
        }

        [Key]
        public Guid championnatId { get; set; }

        public int annee { get; set; }

        public DateTime lastUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipesParticipationModele> EquipesParticipationHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntersaisonsModele> Intersaisons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuartersModele> Quarters { get; set; }
    }
}
