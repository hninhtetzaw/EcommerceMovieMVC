using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieMVC.Data;

public partial class MoviedbContext : DbContext
{
    public MoviedbContext()
    {
    }

    public MoviedbContext(DbContextOptions<MoviedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblMovie> TblMovies { get; set; }

    public virtual DbSet<TblMovieCategory> TblMovieCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=moviedb;User Id=root;Password=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_movie");

            entity.HasIndex(e => e.CategoryId, "fk_movie_tbl_movie_category");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CategoryId).HasMaxLength(36);
            entity.Property(e => e.Genre).HasMaxLength(45);
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
