using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DBGames.Models
{
    public class GameModelContext : DbContext 
    {
        public GameModelContext() : base("GameModelContext")
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Platform> Platforms { get; set; }
    }
}