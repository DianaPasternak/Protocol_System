using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProtocolSystem.Models.DB
{
    public partial class ProtocolSystemContext : DbContext
    {
        public ProtocolSystemContext()
        {
        }

        public ProtocolSystemContext(DbContextOptions<ProtocolSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Insurants> Insurants { get; set; }
        public virtual DbSet<Protocols> Protocols { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-M60I3S0;Database=ProtocolSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insurants>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Protocols>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConsiderationDate)
                    .HasColumnName("consideration_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConsiderationPlace)
                    .HasColumnName("consideration_place")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Damage1)
                    .HasColumnName("damage_1")
                    .HasMaxLength(100);

                entity.Property(e => e.Damage2)
                    .HasColumnName("damage_2")
                    .HasMaxLength(100);

                entity.Property(e => e.IncidentDate)
                    .HasColumnName("incident_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentDescription)
                    .HasColumnName("incident_description")
                    .HasMaxLength(350);

                entity.Property(e => e.IncidentPlace)
                    .IsRequired()
                    .HasColumnName("incident_place")
                    .HasMaxLength(50);

                entity.Property(e => e.InsurantId1).HasColumnName("insurant_id1");

                entity.Property(e => e.InsurantId2).HasColumnName("insurant_id2");

                entity.Property(e => e.LawArticle)
                    .HasColumnName("law_article")
                    .HasMaxLength(50);

                entity.Property(e => e.ProtocolDate)
                    .HasColumnName("protocol_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProtocolPlace)
                    .HasColumnName("protocol_place")
                    .HasMaxLength(100);

                entity.Property(e => e.RegistrationCountry1)
                    .HasColumnName("registration_country1")
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationCountry2)
                    .HasColumnName("registration_country2")
                    .HasMaxLength(50);

                entity.Property(e => e.RuleId).HasColumnName("rule_id");

                entity.Property(e => e.Series)
                    .HasColumnName("series")
                    .HasMaxLength(50);

                entity.Property(e => e.User1Id).HasColumnName("user_1_id");

                entity.Property(e => e.User2Id).HasColumnName("user_2_id");

                entity.Property(e => e.VehicleBrand1)
                    .IsRequired()
                    .HasColumnName("vehicle_brand1")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleBrand2)
                    .HasColumnName("vehicle_brand2")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleId1)
                    .IsRequired()
                    .HasColumnName("vehicle_id1")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleId2)
                    .HasColumnName("vehicle_id2")
                    .HasMaxLength(50);

                entity.Property(e => e.WitnessData)
                    .IsRequired()
                    .HasColumnName("witness_data")
                    .HasMaxLength(250);

                entity.HasOne(d => d.InsurantId1Navigation)
                    .WithMany(p => p.ProtocolsInsurantId1Navigation)
                    .HasForeignKey(d => d.InsurantId1)
                    .HasConstraintName("FK_Protocols_Insurants");

                entity.HasOne(d => d.InsurantId2Navigation)
                    .WithMany(p => p.ProtocolsInsurantId2Navigation)
                    .HasForeignKey(d => d.InsurantId2)
                    .HasConstraintName("FK_Protocols_Insurants1");

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.ProtocolsUser1)
                    .HasForeignKey(d => d.User1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Protocols_Users");

                entity.HasOne(d => d.User2)
                    .WithMany(p => p.ProtocolsUser2)
                    .HasForeignKey(d => d.User2Id)
                    .HasConstraintName("FK_Protocols_Users1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Citizenship)
                    .HasColumnName("citizenship")
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.DrivingLicenceData)
                    .HasColumnName("driving_licence_data")
                    .HasMaxLength(50);

                entity.Property(e => e.DrivingLicenceId)
                    .HasColumnName("driving_licence_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.PassportData)
                    .HasColumnName("passport_data")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.PlaceOfWork)
                    .HasColumnName("place_of_work")
                    .HasMaxLength(50);

                entity.Property(e => e.Post)
                    .HasColumnName("post")
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });
        }
    }
}
