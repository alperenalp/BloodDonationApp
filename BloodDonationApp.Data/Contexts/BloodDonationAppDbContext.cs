using System;
using System.Collections.Generic;
using BloodDonationApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationApp.Data.Contexts;

public partial class BloodDonationAppDbContext : DbContext
{
    public BloodDonationAppDbContext()
    {
    }

    public BloodDonationAppDbContext(DbContextOptions<BloodDonationAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blood> Bloods { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<HospitalBlood> HospitalBloods { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blood>(entity =>
        {
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HospitalBlood>(entity =>
        {
            entity.HasKey(e => new { e.BloodId, e.HospitalId }).HasName("PK_HospitalBloods_1");

            entity.HasOne(d => d.Blood).WithMany(p => p.HospitalBloods)
                .HasForeignKey(d => d.BloodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HospitalBloods_Bloods");

            entity.HasOne(d => d.Hospital).WithMany(p => p.HospitalBloods)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HospitalBloods_Hospitals1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Type)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Blood).WithMany(p => p.Users)
                .HasForeignKey(d => d.BloodId)
                .HasConstraintName("FK_Users_Bloods");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Users)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK_Users_Hospitals");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
