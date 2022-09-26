using FalconTech.Challenge.DataLayer.Entities.Identity;
using FalconTech.Challenge.DataLayer.Entities.Movies;
using Microsoft.EntityFrameworkCore;
using System;

namespace FalconTech.Challenge.DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invitation>()
                .HasKey(c => new { c.UserId, c.MovieId });

            modelBuilder.Entity<Role>()
                .HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "SuperAdmin",
                        SYSUSER = "Init",
                        SYSDATE = DateTime.Now
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "Director",
                        SYSUSER = "Init",
                        SYSDATE = DateTime.Now
                    },
                    new Role
                    {
                        Id = 3,
                        Name = "Actor",
                        SYSUSER = "Init",
                        SYSDATE = DateTime.Now
                    });

            modelBuilder.Entity<Genre>()
                .HasData(
                    new Genre { Id = 1, Name = "Action", Description = "Action movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 2, Name = "Adventure", Description = "Adventure movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 3, Name = "Comedy", Description = "Comedy movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 4, Name = "Crime", Description = "Crime movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 5, Name = "Drama", Description = "Drama movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 6, Name = "Fantasy", Description = "Fantasy movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 7, Name = "Historical", Description = "Historical movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 8, Name = "Horror", Description = "Horror movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 9, Name = "Romance", Description = "Romantic movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 10, Name = "Satire", Description = "Satire movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 11, Name = "Sci-Fi", Description = "Science fiction movie", SYSUSER = "Init", SYSDATE = DateTime.Now },
                    new Genre { Id = 12, Name = "Thriller", Description = "Action movie", SYSUSER = "Init", SYSDATE = DateTime.Now });
        }
    }
}