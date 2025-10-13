using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Data;

public partial class MoviedbContext : DbContext
{
    public MoviedbContext()
    {
    }

    public MoviedbContext(DbContextOptions<MoviedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblActor> TblActors { get; set; }

    public virtual DbSet<TblCinema> TblCinemas { get; set; }

    public virtual DbSet<TblMovie> TblMovies { get; set; }

    public virtual DbSet<TblMovieCategory> TblMovieCategories { get; set; }

    public virtual DbSet<TblProducer> TblProducers { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=moviedb;User Id=root;Password=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblActor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_actor");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Bio).HasMaxLength(45);
            entity.Property(e => e.FullName).HasMaxLength(45);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(45);
        });

        modelBuilder.Entity<TblCinema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_cinema");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Description).HasMaxLength(45);
            entity.Property(e => e.Logo).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<TblMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_movie");

            entity.HasIndex(e => e.CategoryId, "fk_movie_tbl_movie_category");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CategoryId).HasMaxLength(36);
            entity.Property(e => e.Genre).HasMaxLength(45);
            entity.Property(e => e.ImageUrl).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(45);

            entity.HasOne(d => d.Category).WithMany(p => p.TblMovies)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_movie_tbl_movie_category");
        });

        modelBuilder.Entity<TblMovieCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_movie_category");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TblProducer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_producer");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Bio).HasMaxLength(45);
            entity.Property(e => e.FullName).HasMaxLength(45);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(45);
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_role");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.RoleName).HasMaxLength(45);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_user");

            entity.HasIndex(e => e.RoleId, "fk_tbl_role");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Pasword).HasMaxLength(45);
            entity.Property(e => e.RoleId).HasMaxLength(36);
            entity.Property(e => e.UserName).HasMaxLength(45);

            entity.HasOne(d => d.Role).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_tbl_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
