using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaModeles
{
    [Table("Equipes")]
    public class EquipesModele
    {
        [Key]
        public Guid equipeId { get; set; }

        [Required]
        [StringLength(50)]
        public string nom { get; set; }

        public DateTime lastUpdate { get; set; }

        [Required]
        public string logoPath { get; set; }

        public bool enoughPlayers { get; set; }
    }
}
