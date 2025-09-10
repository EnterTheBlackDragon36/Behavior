using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Behavior.Models;

public partial class BehaviorContext : DbContext
{
    public BehaviorContext()
    {
    }

    public BehaviorContext(DbContextOptions<BehaviorContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public virtual DbSet<Action> Actions { get; set; }

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
        var connString = Configuration.GetConnectionString("BehaviorConnection");
        optionsBuilder.UseSqlServer(connString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.Property(e => e.Action1)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Action");
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
            entity.HasKey(e => e.Id).HasName("PK_Feelings1");

            entity.Property(e => e.Feeling1)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Feeling");
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
            entity.Property(e => e.Talent1)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Talent");
        });

        modelBuilder.Entity<Thought>(entity =>
        {
            entity.Property(e => e.Thought1)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Thought");
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
