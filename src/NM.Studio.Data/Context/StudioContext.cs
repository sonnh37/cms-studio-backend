using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using NM.Studio.Domain.Entities;

namespace NM.Studio.Data.Context
{
    public partial class StudioContext : BaseDbContext
    {

        public StudioContext(DbContextOptions<StudioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Outfit> Outfits { get; set; } = null!;
        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", true, true)
             .Build();
            var strConn = /*config["ConnectionStrings:DB"]*/ config.GetConnectionString("DefaultConnection");

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Outfit>(entity =>
            {
                entity.ToTable("Outfit");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });
            
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWID()");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWID()");

                entity.HasOne(photo => photo.Album)
                    .WithMany(album => album.Photos)
                    .HasForeignKey(photo => photo.AlbumId);
            });

            

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWID()");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWID()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
