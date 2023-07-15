using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment8July.Model
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CityTable12> CityTable12s { get; set; } = null!;
        public virtual DbSet<CountryTable12> CountryTable12s { get; set; } = null!;
        public virtual DbSet<EmployeTable12> EmployeTable12s { get; set; } = null!;
        public virtual DbSet<GenderTable12> GenderTable12s { get; set; } = null!;
        public virtual DbSet<StateTable12> StateTable12s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;UID=sdirectdb;PWD=sdirectdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityTable12>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("CityTable12");

                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.CityTable12s)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__CityTable__State__11C12B64");
            });

            modelBuilder.Entity<CountryTable12>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("CountryTable12");

                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeTable12>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__EmployeT__AF2DBB99793F6A51");

                entity.ToTable("EmployeTable12");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phonenum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.EmployeTable12s)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__EmployeTa__CityI__0995F9B7");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.EmployeTable12s)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__EmployeTa__Count__07ADB145");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.EmployeTable12s)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__EmployeTa__Gende__06B98D0C");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EmployeTable12s)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__EmployeTa__State__08A1D57E");
            });

            modelBuilder.Entity<GenderTable12>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.ToTable("GenderTable12");

                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StateTable12>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("StateTable12");

                entity.Property(e => e.StateId)
                    .ValueGeneratedNever()
                    .HasColumnName("StateID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.State)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StateTable12s)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__StateTabl__Count__10CD072B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
