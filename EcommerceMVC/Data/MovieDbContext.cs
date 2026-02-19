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

    public virtual DbSet<TblActorMovie> TblActorMovies { get; set; }

    public virtual DbSet<TblCinema> TblCinemas { get; set; }

    public virtual DbSet<TblMovie> TblMovies { get; set; }

    public virtual DbSet<TblMovieCategory> TblMovieCategories { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblOrderItem> TblOrderItems { get; set; }

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
            entity.Property(e => e.ActorId)
                .HasMaxLength(36)
                .HasColumnName("Actor_Id");
            entity.Property(e => e.Bio).HasMaxLength(45);
            entity.Property(e => e.FullName).HasMaxLength(45);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(45);
        });

        modelBuilder.Entity<TblActorMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_actor_movie");

            entity.HasIndex(e => e.ActorId, "fk_tbl_actor");

            entity.HasIndex(e => e.MovieId, "fk_tbl_movie");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ActorId)
                .HasMaxLength(45)
                .HasColumnName("Actor_Id");
            entity.Property(e => e.MovieId)
                .HasMaxLength(45)
                .HasColumnName("Movie_Id");

            entity.HasOne(d => d.Actor).WithMany(p => p.TblActorMovies)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_actor");

            entity.HasOne(d => d.Movie).WithMany(p => p.TblActorMovies)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_tbl_movie");
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

            entity.HasIndex(e => e.CinemaId, "fk_tbl_cinema");

            entity.HasIndex(e => e.ProducerId, "fk_tbl_producer");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CategoryId).HasMaxLength(36);
            entity.Property(e => e.CinemaId)
                .HasMaxLength(36)
                .HasColumnName("Cinema_Id");
            entity.Property(e => e.Genre).HasMaxLength(45);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.ProducerId)
                .HasMaxLength(36)
                .HasColumnName("Producer_Id");
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(45);

            entity.HasOne(d => d.Category).WithMany(p => p.TblMovies)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_movie_tbl_movie_category");

            entity.HasOne(d => d.Cinema).WithMany(p => p.TblMovies)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("fk_tbl_cinema");

            entity.HasOne(d => d.Producer).WithMany(p => p.TblMovies)
                .HasForeignKey(d => d.ProducerId)
                .HasConstraintName("fk_tbl_producer");
        });

        modelBuilder.Entity<TblMovieCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_movie_category");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_order");

            entity.HasIndex(e => e.UserId, "fk_tbl_user");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasPrecision(10);
            entity.Property(e => e.UserId).HasMaxLength(36);

            entity.HasOne(d => d.User).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_tbl_user");
        });

        modelBuilder.Entity<TblOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_order_items");

            entity.HasIndex(e => e.OrderId, "fk_tbl_order");

            entity.HasIndex(e => e.MovieId, "fk_tbl_order_items_movie");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.MovieId).HasMaxLength(36);
            entity.Property(e => e.OrderId).HasMaxLength(36);
            entity.Property(e => e.Price).HasPrecision(10);

            entity.HasOne(d => d.Movie).WithMany(p => p.TblOrderItems)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_tbl_order_items_movie");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_tbl_order");
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
            entity.Property(e => e.Password).HasMaxLength(256);
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
