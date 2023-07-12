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
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Hospitals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hospitals_Users");

            entity.HasMany(d => d.Users).WithMany(p => p.HospitalsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "HospitalUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HospitalUsers_Users"),
                    l => l.HasOne<Hospital>().WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_HospitalUsers_Hospitals"),
                    j =>
                    {
                        j.HasKey("HospitalId", "UserId");
                        j.ToTable("HospitalUsers");
                    });
        });

        modelBuilder.Entity<HospitalBlood>(entity =>
        {
            entity.HasKey(e => new { e.HospitalId, e.BloodId });

            entity.HasOne(d => d.Blood).WithMany(p => p.HospitalBloods)
                .HasForeignKey(d => d.BloodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HospitalBloods_Bloods");

            entity.HasOne(d => d.Hospital).WithMany(p => p.HospitalBloods)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HospitalBloods_Hospitals");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Blood).WithMany(p => p.Users)
                .HasForeignKey(d => d.BloodId)
                .HasConstraintName("FK_Users_Bloods");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
