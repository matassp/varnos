using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Varnos.Models
{
    public partial class varnosContext : DbContext
    {
        public varnosContext()
        {
        }

        public varnosContext(DbContextOptions<varnosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemPointMap> ItemPointMap { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Points> Points { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPointMap>(entity =>
            {
                entity.HasKey(e => new { e.FkItemidItem, e.FkPointidPoint });

                entity.ToTable("item_point_map", "varnos");

                entity.HasIndex(e => e.FkPointidPoint)
                    .HasName("fk_pointid_point");

                entity.Property(e => e.FkItemidItem)
                    .HasColumnName("fk_itemid_item")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPointidPoint)
                    .HasColumnName("fk_pointid_point")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.FkItemidItemNavigation)
                    .WithMany(p => p.ItemPointMap)
                    .HasForeignKey(d => d.FkItemidItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_point_map_ibfk_1");

                entity.HasOne(d => d.FkPointidPointNavigation)
                    .WithMany(p => p.ItemPointMap)
                    .HasForeignKey(d => d.FkPointidPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_point_map_ibfk_2");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.IdItem);

                entity.ToTable("items", "varnos");

                entity.Property(e => e.IdItem)
                    .HasColumnName("id_item")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<Points>(entity =>
            {
                entity.HasKey(e => e.IdPoint);

                entity.ToTable("points", "varnos");

                entity.HasIndex(e => e.FkRegionidRegion)
                    .HasName("fk_regionid_region");

                entity.HasIndex(e => e.FkUseridUser)
                    .HasName("fk_userid_user");

                entity.Property(e => e.IdPoint)
                    .HasColumnName("id_point")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FkRegionidRegion)
                    .HasColumnName("fk_regionid_region")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkUseridUser)
                    .HasColumnName("fk_userid_user")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(14,10)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(14,10)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.FkRegionidRegionNavigation)
                    .WithMany(p => p.Points)
                    .HasForeignKey(d => d.FkRegionidRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("points_ibfk_2");

                entity.HasOne(d => d.FkUseridUserNavigation)
                    .WithMany(p => p.Points)
                    .HasForeignKey(d => d.FkUseridUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("points_ibfk_1");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.IdRegion);

                entity.ToTable("regions", "varnos");

                entity.Property(e => e.IdRegion)
                    .HasColumnName("id_region")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(14,10)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(14,10)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Zoom)
                    .HasColumnName("zoom")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("users", "varnos");

                entity.HasIndex(e => e.FkRegionidRegion)
                    .HasName("fk_regionid_region");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FkRegionidRegion)
                    .HasColumnName("fk_regionid_region")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.FkRegionidRegionNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkRegionidRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_ibfk_1");
            });
        }
    }
}
