namespace TestDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelTest : DbContext
    {
        public ModelTest()
            : base("name=ModelTest")
        {
        }

        public virtual DbSet<CartonsJaunesHistory> CartonsJaunesHistory { get; set; }
        public virtual DbSet<CartonsRougesHistory> CartonsRougesHistory { get; set; }
        public virtual DbSet<Championnats> Championnats { get; set; }
        public virtual DbSet<Equipes> Equipes { get; set; }
        public virtual DbSet<EquipesParticipationHistory> EquipesParticipationHistory { get; set; }
        public virtual DbSet<FeuillesDeMatch> FeuillesDeMatch { get; set; }
        public virtual DbSet<GoalsHistory> GoalsHistory { get; set; }
        public virtual DbSet<Intersaisons> Intersaisons { get; set; }
        public virtual DbSet<Joueurs> Joueurs { get; set; }
        public virtual DbSet<JoueursParticipationHistory> JoueursParticipationHistory { get; set; }
        public virtual DbSet<Matchs> Matchs { get; set; }
        public virtual DbSet<Quarters> Quarters { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TransfertsHistory> TransfertsHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Championnats>()
                .HasMany(e => e.EquipesParticipationHistory)
                .WithRequired(e => e.Championnats)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Championnats>()
                .HasMany(e => e.Intersaisons)
                .WithRequired(e => e.Championnats)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Championnats>()
                .HasMany(e => e.Quarters)
                .WithRequired(e => e.Championnats)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipes>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Equipes>()
                .Property(e => e.logoPath)
                .IsUnicode(false);

            modelBuilder.Entity<Equipes>()
                .HasMany(e => e.EquipesParticipationHistory)
                .WithRequired(e => e.Equipes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipes>()
                .HasMany(e => e.FeuillesDeMatch)
                .WithRequired(e => e.Equipes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipes>()
                .HasMany(e => e.Matchs)
                .WithRequired(e => e.Equipes)
                .HasForeignKey(e => e.equipe1Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipes>()
                .HasMany(e => e.Matchs1)
                .WithRequired(e => e.Equipes1)
                .HasForeignKey(e => e.equipe2Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipes>()
                .HasMany(e => e.TransfertsHistory)
                .WithRequired(e => e.Equipes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FeuillesDeMatch>()
                .HasMany(e => e.JoueursParticipationHistory)
                .WithRequired(e => e.FeuillesDeMatch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Joueurs>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Joueurs>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Joueurs>()
                .HasMany(e => e.CartonsJaunesHistory)
                .WithRequired(e => e.Joueurs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Joueurs>()
                .HasMany(e => e.CartonsRougesHistory)
                .WithRequired(e => e.Joueurs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Joueurs>()
                .HasMany(e => e.GoalsHistory)
                .WithRequired(e => e.Joueurs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Joueurs>()
                .HasMany(e => e.JoueursParticipationHistory)
                .WithRequired(e => e.Joueurs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Joueurs>()
                .HasMany(e => e.TransfertsHistory)
                .WithRequired(e => e.Joueurs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matchs>()
                .HasMany(e => e.CartonsJaunesHistory)
                .WithRequired(e => e.Matchs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matchs>()
                .HasMany(e => e.CartonsRougesHistory)
                .WithRequired(e => e.Matchs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matchs>()
                .HasMany(e => e.FeuillesDeMatch)
                .WithRequired(e => e.Matchs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matchs>()
                .HasMany(e => e.GoalsHistory)
                .WithRequired(e => e.Matchs)
                .WillCascadeOnDelete(false);
        }
    }
}
