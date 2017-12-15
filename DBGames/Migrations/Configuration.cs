namespace DBGames.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using DBGames.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DBGames.Models.GameModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DBGames.Models.GameModelContext";
        }

        protected override void Seed(DBGames.Models.GameModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var developers = new List<Developer>
            {
                new Developer {DeveloperName = "404 Games", HQ = "Dublin"},
                new Developer {DeveloperName = "KetchApp", HQ = "Boston"},
                new Developer {DeveloperName = "Electronic Arts", HQ = "Hell"}
            };

            developers.ForEach(s => context.Developers.Add(s));
            context.SaveChanges();

            var engines = new List<Engine>
            {
                new Engine {EngineName = "Frostbite", WrittenIn = "C++"},
                new Engine {EngineName = "Unity", WrittenIn = "C#"}
            };

            engines.ForEach(s => context.Engines.Add(s));
            context.SaveChanges();

            var platforms = new List<Platform>
            {
                new Platform {PlatformName = "PS4", Type = "Console"},
                new Platform {PlatformName = "IOS", Type = "Mobile"}
            };

            platforms.ForEach(s => context.Platforms.Add(s));
            context.SaveChanges();


      

            var games = new List<Game>
            {

                new Game
                { Title = "FIFA 18", Genre = "Sport", Mode = "MultiPlayer",  DeveloperId = 1, EngineId = 1, PlatformId = 1},

                new Game
                {Title = "Virginia", Genre = "RPG", Mode = "Single Player", DeveloperId = 2, EngineId = 2, PlatformId = 2}

            };

            games.ForEach(s => context.Games.Add(s));
            context.SaveChanges();


        }
    }
}
