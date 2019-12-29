using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaModeles;

namespace FifaDAL.MatchManagement
{
    public class FifaManagerContext : DbContext
    {
        
        public FifaManagerContext(String _Connection) : base(_Connection)
            {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<FifaManagerContext>(null);
            }

        private String _Connection = "Data Source=(local);Initial Catalog=FifaManagerEphec;Persist Security Info=True;User ID=MatchManagement;Password=ephec";

        public virtual DbSet<CartonsJaunesModele> CartonsJaunesHistory { get; set; }
        public virtual DbSet<CartonsRougesModele> CartonsRougesHistory { get; set; }
        public virtual DbSet<ChampionnatsModele> Championnats { get; set; }
        public virtual DbSet<EquipesModele> Equipes { get; set; }
        public virtual DbSet<EquipesParticipationModele> EquipesParticipationHistory { get; set; }
        public virtual DbSet<FeuillesDeMatchModele> FeuillesDeMatch { get; set; }
        public virtual DbSet<GoalsModele> GoalsHistory { get; set; }
        public virtual DbSet<IntersaisonsModele> Intersaisons { get; set; }
        public virtual DbSet<JoueursModele> Joueurs { get; set; }
        public virtual DbSet<JoueursParticipationModele> JoueursParticipationHistory { get; set; }
        public virtual DbSet<MatchsModele> Matchs { get; set; }
        public virtual DbSet<QuartersModele> Quarters { get; set; }
        public virtual DbSet<TransfertsModele> TransfertsHistory { get; set; }
    }
}
