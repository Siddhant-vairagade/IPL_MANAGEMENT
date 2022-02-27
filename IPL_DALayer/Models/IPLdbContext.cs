using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IPL_DALayer.Models
{
    public partial class IPLdbContext : DbContext
    {
        public IPLdbContext()
        {
        }

        public IPLdbContext(DbContextOptions<IPLdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketCategory> TicketCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-7D46EU5M;database=IPLdb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("fk_Schedule");

                entity.HasOne(d => d.TeamOne)
                    .WithMany(p => p.MatchTeamOnes)
                    .HasForeignKey(d => d.TeamOneId)
                    .HasConstraintName("fk_Team2");

                entity.HasOne(d => d.TeamTwo)
                    .WithMany(p => p.MatchTeamTwos)
                    .HasForeignKey(d => d.TeamTwoId)
                    .HasConstraintName("fk_Team1");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("fk_Venue1");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewsDate).HasColumnType("date");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("fk_Match3");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Player_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("fk_Specialty");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("fk_Team");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MatchDate).HasColumnType("date");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("fk_Venue");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasKey(e => e.SpecialityId)
                    .HasName("pk_Specialty");

                entity.ToTable("Specialty");

                entity.Property(e => e.SpecialityId).ValueGeneratedNever();

                entity.Property(e => e.SpecialityDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("Statistic");

                entity.Property(e => e.TeamId).ValueGeneratedNever();

                entity.Property(e => e.NR)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("N_R");

                entity.Property(e => e.NetRr)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("NetRR");

                entity.HasOne(d => d.Team)
                    .WithOne(p => p.Statistic)
                    .HasForeignKey<Statistic>(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Team3");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Franchises)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GroundName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

         

                entity.Property(e => e.TeamName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Team_Name");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_TicketCategory");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("fk_Schedule1");
            });

            modelBuilder.Entity<TicketCategory>(entity =>
            {
                entity.ToTable("TicketCategory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_Role");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserRole)
                    .HasForeignKey<UserRole>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("Venue");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
