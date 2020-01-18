using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaModeles;

namespace FifaDAL.BackEnd
{
    public class FifaManagerContext : DbContext
    {
        
        public FifaManagerContext(String _Connection) : base(_Connection)
            {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<FifaManagerContext>(null);
            
            }

        public virtual DbSet<CartonsJaunesModele> CartonsJaunes { get; set; }
        public virtual DbSet<CartonsRougesModele> CartonsRouges { get; set; }
        public virtual DbSet<ChampionnatsModele> Championnats { get; set; }
        public virtual DbSet<EquipesModele> Equipes { get; set; }
        public virtual DbSet<EquipesParticipationModele> EquipesParticipation { get; set; }
        public virtual DbSet<FeuillesDeMatchModele> FeuillesDeMatch { get; set; }
        public virtual DbSet<GoalsModele> GoalsHistory { get; set; }
        public virtual DbSet<IntersaisonsModele> Intersaisons { get; set; }
        public virtual DbSet<JoueursModele> Joueurs { get; set; }
        public virtual DbSet<JoueursParticipationModele> JoueursParticipation { get; set; }
        public virtual DbSet<MatchsModele> Matchs { get; set; }
        public virtual DbSet<QuartersModele> Quarters { get; set; }
        public virtual DbSet<TransfertsModele> Transferts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("BackEnd");
            //modelBuilder.Entity<ChampionnatsModele>()
                   // .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("BackEnd.Championnats_Add").Parameter(pm => pm.annee, "@Annee")));
                             
        }
    }
}
