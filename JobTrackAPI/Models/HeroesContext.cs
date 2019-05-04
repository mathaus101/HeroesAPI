using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobTrackAPI.Models
{
    public class HeroesContext : DbContext
    {

        public HeroesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Hero> Hero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().HasData(
            new Models.Hero { ID = 1, Name = "Drax the Destroyer" },
            new Models.Hero { ID= 11, Name= "Groot"},
            new Models.Hero { ID= 12, Name= "Star Lord"},
            new Models.Hero { ID = 13, Name= "Gamora"},
            new Models.Hero { ID = 14, Name= "Drax the Destroyer"},
            new Models.Hero { ID = 15, Name= "Wolverine"},
            new Models.Hero { ID = 16, Name= "Magneto"},
            new Models.Hero { ID = 17, Name= "Thor"},
            new Models.Hero { ID = 18, Name= "Rocket Raccoon"},
            new Models.Hero { ID = 19, Name= "Nebula"},
            new Models.Hero { ID = 20, Name= "Loki"}

        );
        }
    }
}
