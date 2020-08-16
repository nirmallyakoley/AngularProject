using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GtaaVmCatalog.Models
{
    public partial class VMCatalogDBContext : DbContext
    {
        public VMCatalogDBContext()
        {
        }

        public VMCatalogDBContext(DbContextOptions<VMCatalogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBackupRate> TblBackupRate { get; set; }
        public virtual DbSet<TblCapexCostDetail> TblCapexCostDetail { get; set; }
        public virtual DbSet<TblCpuRate> TblCpuRate { get; set; }
        public virtual DbSet<TblDirectorQueue> TblDirectorQueue { get; set; }
        public virtual DbSet<TblMiscallenousRate> TblMiscallenousRate { get; set; }
        public virtual DbSet<TblOpexCostDetail> TblOpexCostDetail { get; set; }
        public virtual DbSet<TblPdmQueue> TblPdmQueue { get; set; }
        public virtual DbSet<TblRamRate> TblRamRate { get; set; }
        public virtual DbSet<TblStorageRate> TblStorageRate { get; set; }
        public virtual DbSet<TblTapQueue> TblTapQueue { get; set; }
        public virtual DbSet<TblVmCpuType> TblVmCpuType { get; set; }
        public virtual DbSet<TblVmEnvironmentType> TblVmEnvironmentType { get; set; }
        public virtual DbSet<TblVmMonitoringType> TblVmMonitoringType { get; set; }
        public virtual DbSet<TblVmOsType> TblVmOsType { get; set; }
        public virtual DbSet<TblVmRamType> TblVmRamType { get; set; }
        public virtual DbSet<TblVmRequisitionDetails> TblVmRequisitionDetails { get; set; }
        public virtual DbSet<TblVmStorageType> TblVmStorageType { get; set; }
        public virtual DbSet<TblVmapprovalRejection> TblVmapprovalRejection { get; set; }
        public virtual DbSet<TblVmdocument> TblVmdocument { get; set; }
        public virtual DbSet<TblVmproject> TblVmproject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:gtaadbserver.database.windows.net,1433;Initial Catalog=VMCatalogDB;Persist Security Info=False;User ID=gtaadbadmin;Password=November@2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBackupRate>(entity =>
            {
                entity.Property(e => e.BackupEnvironment).IsUnicode(false);
            });

            modelBuilder.Entity<TblCapexCostDetail>(entity =>
            {
                entity.Property(e => e.CapexCost).HasComputedColumnSql("([Capex_Per_Unit_Cost]*[Capex_Unit])");

                entity.Property(e => e.CapexType).IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VmenvironmentTypeId).IsUnicode(false);
            });

            modelBuilder.Entity<TblCpuRate>(entity =>
            {
                entity.Property(e => e.CpuEnvironment).IsUnicode(false);
            });

            modelBuilder.Entity<TblDirectorQueue>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMiscallenousRate>(entity =>
            {
                entity.Property(e => e.CostDetail).IsUnicode(false);

                entity.Property(e => e.CostType).IsUnicode(false);
            });

            modelBuilder.Entity<TblOpexCostDetail>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpexType).IsUnicode(false);
            });

            modelBuilder.Entity<TblPdmQueue>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblRamRate>(entity =>
            {
                entity.Property(e => e.RamEnvironment).IsUnicode(false);
            });

            modelBuilder.Entity<TblStorageRate>(entity =>
            {
                entity.Property(e => e.StorEnvironment).IsUnicode(false);
            });

            modelBuilder.Entity<TblTapQueue>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblVmCpuType>(entity =>
            {
                entity.Property(e => e.Vmcpuid).IsUnicode(false);

                entity.Property(e => e.Vmcputype).IsUnicode(false);
            });

            modelBuilder.Entity<TblVmEnvironmentType>(entity =>
            {
                entity.Property(e => e.VmenvironmentTypeId).IsUnicode(false);

                entity.Property(e => e.Vmenvironment).IsUnicode(false);
            });

            modelBuilder.Entity<TblVmMonitoringType>(entity =>
            {
                entity.Property(e => e.VmmonitoringId).IsUnicode(false);

                entity.Property(e => e.VmmonitoringType).IsUnicode(false);
            });

            modelBuilder.Entity<TblVmOsType>(entity =>
            {
                entity.Property(e => e.VmostypeId).IsUnicode(false);

                entity.Property(e => e.Vmos).IsUnicode(false);
            });

            modelBuilder.Entity<TblVmRamType>(entity =>
            {
                entity.Property(e => e.Vmramid).IsUnicode(false);

                entity.Property(e => e.Vmramtype).IsUnicode(false);
            });

            modelBuilder.Entity<TblVmRequisitionDetails>(entity =>
            {
                entity.Property(e => e.LoggedTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Vmcpuid).IsUnicode(false);

                entity.Property(e => e.VmenvironmentTypeId).IsUnicode(false);

                entity.Property(e => e.VmmonitoringId).IsUnicode(false);

                entity.Property(e => e.VmostypeId).IsUnicode(false);

                entity.Property(e => e.Vmramid).IsUnicode(false);

                entity.Property(e => e.Vmstorid).IsUnicode(false);

                entity.HasOne(d => d.Vmcpu)
                    .WithMany(p => p.TblVmRequisitionDetails)
                    .HasForeignKey(d => d.Vmcpuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_VM_RequisitionDetails_tbl_VM_CPU_Type");

                entity.HasOne(d => d.VmenvironmentType)
                    .WithMany(p => p.TblVmRequisitionDetails)
                    .HasForeignKey(d => d.VmenvironmentTypeId)
                    .HasConstraintName("FK_tbl_VM_RequisitionDetails_tbl_VM_RequisitionDetails");

                entity.HasOne(d => d.Vmostype)
                    .WithMany(p => p.TblVmRequisitionDetails)
                    .HasForeignKey(d => d.VmostypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_VM_RequisitionDetails_tbl_VM_OS_Type");

                entity.HasOne(d => d.Vmram)
                    .WithMany(p => p.TblVmRequisitionDetails)
                    .HasForeignKey(d => d.Vmramid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_VM_RequisitionDetails_tbl_VM_RAM_Type");

                entity.HasOne(d => d.Vmstor)
                    .WithMany(p => p.TblVmRequisitionDetails)
                    .HasForeignKey(d => d.Vmstorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_VM_RequisitionDetails_tbl_VM_Storage_Type");
            });

            modelBuilder.Entity<TblVmStorageType>(entity =>
            {
                entity.Property(e => e.Vmstorid).IsUnicode(false);

                entity.Property(e => e.VmstorageType).IsUnicode(false);
            });

            modelBuilder.Entity<TblVmapprovalRejection>(entity =>
            {
                entity.Property(e => e.ApprovalLevel).IsUnicode(false);

                entity.Property(e => e.ApprovedOrRejectedBy).IsUnicode(false);

                entity.Property(e => e.ApprovedOrRejectedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TblVmapprovalRejection)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_VMApprovalRejection_tbl_VMProject");
            });

            modelBuilder.Entity<TblVmdocument>(entity =>
            {
                entity.Property(e => e.DocumentUrl).IsUnicode(false);

                entity.Property(e => e.LoggedTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TblVmdocument)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_VMDocument_tbl_VMDocument");
            });

            modelBuilder.Entity<TblVmproject>(entity =>
            {
                entity.Property(e => e.AgreementNumber).IsUnicode(false);

                entity.Property(e => e.ApplicationCriticality).IsUnicode(false);

                entity.Property(e => e.ArchitectName).IsUnicode(false);

                entity.Property(e => e.BriefDescription).IsUnicode(false);

                entity.Property(e => e.BuildSheetDoc).IsUnicode(false);

                entity.Property(e => e.BuildSheetDocUrl).IsUnicode(false);

                entity.Property(e => e.ChangeOrderNumber).IsUnicode(false);

                entity.Property(e => e.ChangeRequestNumber).IsUnicode(false);

                entity.Property(e => e.GrowthFactor).IsUnicode(false);

                entity.Property(e => e.LoggedTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OtherCriteria).IsUnicode(false);

                entity.Property(e => e.Pdmname).IsUnicode(false);

                entity.Property(e => e.ProjectName).IsUnicode(false);

                entity.Property(e => e.ProjectNumber).IsUnicode(false);

                entity.Property(e => e.QuoteIdnumber).IsUnicode(false);

                entity.Property(e => e.ReleaseNumber).IsUnicode(false);

                entity.Property(e => e.RequesterLoggedId).IsUnicode(false);

                entity.Property(e => e.RequesterName).IsUnicode(false);

                entity.Property(e => e.RequesterUserId).IsUnicode(false);

                entity.Property(e => e.SecurityApprovalDoc).IsUnicode(false);

                entity.Property(e => e.SecurityApprovalDocUrl).IsUnicode(false);

                entity.Property(e => e.Siem).IsUnicode(false);

                entity.Property(e => e.SolutionDesignDoc).IsUnicode(false);

                entity.Property(e => e.SolutionDesignDocUrl).IsUnicode(false);

                entity.Property(e => e.TapApprovalDoc).IsUnicode(false);

                entity.Property(e => e.TapApprovalDocUrl).IsUnicode(false);

                entity.Property(e => e.VmType).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
