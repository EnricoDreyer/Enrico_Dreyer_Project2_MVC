﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Enrico_Dreyer_Project2.Models;

namespace Enrico_Dreyer_Project2.Data
{
    public partial class enricodreyerContext : DbContext
    {
        public enricodreyerContext()
        {

        }

        public enricodreyerContext(DbContextOptions<enricodreyerContext> options)
            : base(options)
        {

        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:enricodreyer.database.windows.net,1433;Initial Catalog=enricodreyer;Persist Security Info=False;User ID=enricodreyer;Password=enrico!123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Trusted_Connection=true;Integrated Security=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber);

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Age)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Attrition)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessTravel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DailyRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceFromHome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Education)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EducationField)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnvironmentSatisfaction)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HourlyRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobInvolvement)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobRole)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobSatisfaction)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonthlyIncome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonthlyRate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumCompaniesWorked)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Over18)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OverTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PercentSalaryHike)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PerformanceRating)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipSatisfaction)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StandardHours)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StockOptionLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalWorkingYears)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrainingTimesLastYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkLifeBalance)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearsAtCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearsInCurrentRole)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearsSinceLastPromotion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearsWithCurrManager)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
