using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Behavior.Models
{
    public partial class BehaviorContext : DbContext
    {
        public BehaviorContext()
        {
        }

        public BehaviorContext(DbContextOptions<BehaviorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Decision> Decisions { get; set; }
        public virtual DbSet<Feeling> Feelings { get; set; }
        public virtual DbSet<Learn> Learns { get; set; }
        public virtual DbSet<Need> Needs { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Regret> Regrets { get; set; }
        public virtual DbSet<Sense> Senses { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Talent> Talents { get; set; }
        public virtual DbSet<Thought> Thoughts { get; set; }
        public virtual DbSet<Want> Wants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=EASTON-DESKTOP;Initial Catalog=Behavior;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("Action");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("Activity");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Choice>(entity =>
            {
                entity.ToTable("Choice");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Decision>(entity =>
            {
                entity.ToTable("Decision");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Feeling>(entity =>
            {
                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Learn>(entity =>
            {
                entity.ToTable("Learn");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Need>(entity =>
            {
                entity.ToTable("Need");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Regret>(entity =>
            {
                entity.ToTable("Regret");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Sense>(entity =>
            {
                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Talent>(entity =>
            {
                entity.ToTable("Talent");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Thought>(entity =>
            {
                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Want>(entity =>
            {
                entity.ToTable("Want");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
