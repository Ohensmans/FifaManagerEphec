namespace TestDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipesParticipationHistory")]
    public partial class EquipesParticipationHistory
    {
        [Key]
        [Column(Order = 0)]
        public Guid equipeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid championnatId { get; set; }

        public DateTime lastUpdate { get; set; }

        public virtual Championnats Championnats { get; set; }

        public virtual Equipes Equipes { get; set; }
    }
}
