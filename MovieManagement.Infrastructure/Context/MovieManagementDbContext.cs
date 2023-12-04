using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Infrastructure.Context
{
     public class MovieManagementDbContext : DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Biography> Biographies { get; set; }   
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Chuck", LastName = "Norris" },
                new Actor { Id = 2, FirstName = "Jane", LastName = "Doe" },
                new Actor { Id = 3, FirstName = "Van", LastName = "Damme" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Wakand Forever", Description = "Box Office Recorded Wakand forever", ActorId = 1 },
                new Movie { Id = 2, Name = "Avengers", Description = "Box Office Recorded Avengers", ActorId = 2 }
            );
       
        }

    }
}
