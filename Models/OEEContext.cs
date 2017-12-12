using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace OEEWebAPI.Models
{
    public partial class OEEContext : DbContext
    {
        //public IConfigurationRoot Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=VMSQLDEV;Database=DataMart_DEV;user=oeeService;password=Serviceoee1");
            //optionsBuilder.UseSqlServer(@"Server=a5470001;Initial Catalog=OEE;Integrated Security=True");

            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                  .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("OeeDbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Availability>(entity =>
            {
                entity.HasOne(d => d.UnPlanned)
                    .WithMany(p => p.Availability)
                    .HasForeignKey(d => d.UnPlannedId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Availability_UnPlanned");
            });

            modelBuilder.Entity<CalibrationAlignment>(entity =>
            {
                entity.Property(e => e.CalibrationDate).HasColumnType("datetime");

                entity.Property(e => e.InspectIml).HasColumnName("InspectIML");

                entity.HasOne(d => d.SetupAdjustment)
                    .WithMany(p => p.CalibrationAlignment)
                    .HasForeignKey(d => d.SetupAdjustmentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CalibrationAlignment_SetupAdjustment");
            });

            modelBuilder.Entity<CartMhe>(entity =>
            {
                entity.ToTable("CartMHE");

                entity.Property(e => e.CartMheid).HasColumnName("CartMHEId");

                entity.Property(e => e.CartMhedate)
                    .HasColumnName("CartMHEDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EquipmentFailure)
                    .WithMany(p => p.CartMhe)
                    .HasForeignKey(d => d.EquipmentFailureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CartMHE_EquipmentFailure");
            });

            modelBuilder.Entity<Constraints>(entity =>
            {
                entity.Property(e => e.ConstraintsDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdlingMinorStoppage)
                    .WithMany(p => p.Constraints)
                    .HasForeignKey(d => d.IdlingMinorStoppageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Constraints_IdlingMinorStoppage");
            });

            modelBuilder.Entity<EquipmentFailure>(entity =>
            {
                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.EquipmentFailure)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EquipmentFailure_Availability");
            });

            modelBuilder.Entity<IdlingMinorStoppage>(entity =>
            {
                entity.HasOne(d => d.PerformanceEfficiency)
                    .WithMany(p => p.IdlingMinorStoppage)
                    .HasForeignKey(d => d.PerformanceEfficiencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_IdlingMinorStoppage_PerformanceEfficiency");
            });

            modelBuilder.Entity<It>(entity =>
            {
                entity.ToTable("IT");

                entity.Property(e => e.Itid).HasColumnName("ITId");

                entity.Property(e => e.Itdate)
                    .HasColumnName("ITDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EquipmentFailure)
                    .WithMany(p => p.It)
                    .HasForeignKey(d => d.EquipmentFailureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_IT_EquipmentFailure");
            });

            modelBuilder.Entity<LoadUnload>(entity =>
            {
                entity.Property(e => e.LoadUnloadDate).HasColumnType("datetime");

                entity.HasOne(d => d.SetupAdjustment)
                    .WithMany(p => p.LoadUnload)
                    .HasForeignKey(d => d.SetupAdjustmentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LoadUnload_SetupAdjustment");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.Property(e => e.Fod).HasColumnName("FOD");

                entity.Property(e => e.IrheaterError).HasColumnName("IRHeaterError");

                entity.Property(e => e.MachineDate).HasColumnType("datetime");

                entity.Property(e => e.Oltissue).HasColumnName("OLTIssue");

                entity.Property(e => e.Papissue).HasColumnName("PAPIssue");

                entity.HasOne(d => d.EquipmentFailure)
                    .WithMany(p => p.Machine)
                    .HasForeignKey(d => d.EquipmentFailureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Machine_EquipmentFailure");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.CleanOutFod).HasColumnName("CleanOutFOD");

                entity.Property(e => e.MaterialDate).HasColumnType("datetime");

                entity.Property(e => e.NotStickingIml).HasColumnName("NotStickingIML");

                entity.HasOne(d => d.IdlingMinorStoppage)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.IdlingMinorStoppageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Material_IdlingMinorStoppage");
            });

            modelBuilder.Entity<MinorStop>(entity =>
            {
                entity.Property(e => e.MinorStopDate).HasColumnType("datetime");

                entity.Property(e => e._25minute).HasColumnName("25Minute");

                entity.HasOne(d => d.IdlingMinorStoppage)
                    .WithMany(p => p.MinorStop)
                    .HasForeignKey(d => d.IdlingMinorStoppageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MinorStop_IdlingMinorStoppage");
            });

            modelBuilder.Entity<Ncprogramming>(entity =>
            {
                entity.ToTable("NCProgramming");

                entity.Property(e => e.NcprogrammingId).HasColumnName("NCProgrammingId");

                entity.Property(e => e.NcprogramIssue).HasColumnName("NCProgramIssue");

                entity.Property(e => e.NcprogrammingDate)
                    .HasColumnName("NCProgrammingDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdlingMinorStoppage)
                    .WithMany(p => p.Ncprogramming)
                    .HasForeignKey(d => d.IdlingMinorStoppageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_NCProgramming_IdlingMinorStoppage");
            });

            modelBuilder.Entity<Oee>(entity =>
            {
                entity.ToTable("OEE");

                entity.Property(e => e.Oeeid).HasColumnName("OEEId");

                entity.Property(e => e.Oeename)
                    .HasColumnName("OEEName")
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<PerformanceEfficiency>(entity =>
            {
                entity.HasOne(d => d.UnPlanned)
                    .WithMany(p => p.PerformanceEfficiency)
                    .HasForeignKey(d => d.UnPlannedId)
                    .HasConstraintName("FK_PerformanceEfficiency_UnPlanned");
            });

            modelBuilder.Entity<PersonalPanned>(entity =>
            {
                entity.Property(e => e.PlannedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Planned)
                    .WithMany(p => p.PersonalPanned)
                    .HasForeignKey(d => d.PlannedId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PersonalPanned_Planned");
            });

            modelBuilder.Entity<PersonalUnplanned>(entity =>
            {
                entity.Property(e => e.PersonalUnplannedDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdlingMinorStoppage)
                    .WithMany(p => p.PersonalUnplanned)
                    .HasForeignKey(d => d.IdlingMinorStoppageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PersonalUnplanned_IdlingMinorStoppage");
            });

            modelBuilder.Entity<Planned>(entity =>
            {
                entity.Property(e => e.Oeeid).HasColumnName("OEEId");

                entity.HasOne(d => d.Oee)
                    .WithMany(p => p.Planned)
                    .HasForeignKey(d => d.Oeeid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Planned_OEE");
            });

            modelBuilder.Entity<PlannedDowntime>(entity =>
            {
                entity.Property(e => e.PlannedDownTimeDate).HasColumnType("datetime");

                entity.HasOne(d => d.Planned)
                    .WithMany(p => p.PlannedDowntime)
                    .HasForeignKey(d => d.PlannedId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PlannedDowntime_Planned");
            });

            modelBuilder.Entity<PmplannedMaintenance>(entity =>
            {
                entity.ToTable("PMPlannedMaintenance");

                entity.Property(e => e.PmplannedMaintenanceId).HasColumnName("PMPlannedMaintenanceId");

                entity.Property(e => e.PmplannedMaintenanceDate)
                    .HasColumnName("PMPlannedMaintenanceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tpm).HasColumnName("TPM");

                entity.HasOne(d => d.Planned)
                    .WithMany(p => p.PmplannedMaintenance)
                    .HasForeignKey(d => d.PlannedId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PMPlannedMaintenance_Planned");
            });

            modelBuilder.Entity<ReducedSpeed>(entity =>
            {
                entity.Property(e => e.ReduceSpeedDate).HasColumnType("datetime");

                entity.HasOne(d => d.PerformanceEfficiency)
                    .WithMany(p => p.ReducedSpeed)
                    .HasForeignKey(d => d.PerformanceEfficiencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ReducedSpeed_PerformanceEfficiency");
            });

            modelBuilder.Entity<SetupAdjustment>(entity =>
            {
                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.SetupAdjustment)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SetupAdjustment_Availability");
            });

            modelBuilder.Entity<UnPlanned>(entity =>
            {
                entity.Property(e => e.Oeeid).HasColumnName("OEEId");

                entity.HasOne(d => d.Oee)
                    .WithMany(p => p.UnPlanned)
                    .HasForeignKey(d => d.Oeeid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UnPlanned_OEE");
            });
        }

        public virtual DbSet<Availability> Availability { get; set; }
        public virtual DbSet<CalibrationAlignment> CalibrationAlignment { get; set; }
        public virtual DbSet<CartMhe> CartMhe { get; set; }
        public virtual DbSet<Constraints> Constraints { get; set; }
        public virtual DbSet<EquipmentFailure> EquipmentFailure { get; set; }
        public virtual DbSet<IdlingMinorStoppage> IdlingMinorStoppage { get; set; }
        public virtual DbSet<It> It { get; set; }
        public virtual DbSet<LoadUnload> LoadUnload { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MinorStop> MinorStop { get; set; }
        public virtual DbSet<Ncprogramming> Ncprogramming { get; set; }
        public virtual DbSet<Oee> Oee { get; set; }
        public virtual DbSet<PerformanceEfficiency> PerformanceEfficiency { get; set; }
        public virtual DbSet<PersonalPanned> PersonalPanned { get; set; }
        public virtual DbSet<PersonalUnplanned> PersonalUnplanned { get; set; }
        public virtual DbSet<Planned> Planned { get; set; }
        public virtual DbSet<PlannedDowntime> PlannedDowntime { get; set; }
        public virtual DbSet<PmplannedMaintenance> PmplannedMaintenance { get; set; }
        public virtual DbSet<ReducedSpeed> ReducedSpeed { get; set; }
        public virtual DbSet<SetupAdjustment> SetupAdjustment { get; set; }
        public virtual DbSet<UnPlanned> UnPlanned { get; set; }
    }
}