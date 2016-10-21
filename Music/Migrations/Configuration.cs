namespace Music.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Music.Models.MusicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Music.Models.MusicContext";
        }

        protected override void Seed(Music.Models.MusicContext context)
        {
          
            context.Genres.AddOrUpdate(
                g => g.Name,
                new Genre { Name = "Disco" },
                new Genre { Name = "Classical" },
                new Genre { Name = "Pop" }
                );

            context.Artists.AddOrUpdate(
                a => a.Name,
                new Artist { Name = "Bee Gees" }
                );
        }
    }
}
