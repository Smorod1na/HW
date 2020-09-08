using GameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreDAL.Initializer
{
    public class GamesInitializer : DropCreateDatabaseAlways<AplicationContext>
    {
        protected override void Seed(AplicationContext context)
        {
            var genre = new List<Genre>
            {
                new Genre{Name="Action"},
                                new Genre{Name="Shooter"},
                                                new Genre{Name="RPG"},
                                                                new Genre{Name="Sport"},
                                                                                new Genre{Name="Strategy"}


            };
            var developer = new List<Developer>
            {
                new Developer{Name="Rockstar"},
                new Developer{Name="EA"},
                new Developer{Name="Ubisoft"},
                new Developer{Name="Epic Games"},
                new Developer{Name="4A Games"},
                new Developer{Name="Playrix"},
                new Developer{Name="Activision"}
            };
            var games = new List<Game>
            {
                new Game{
                    Name="FarCry",
                    Description="FarCry info...",
                    Year=2018,
                    Image="https://images.ua.prom.st/2036233862_far-cry-3.jpg",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Action"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Ubisoft"),
                    Price=40
                },
                new Game{
                    Name="Assassin Creed",
                    Description="Assassin Creed info...",
                    Year=2018,
                    Image="https://ubistatic19-a.akamaihd.net/marketingresource/ru-ru/assassins-creed/assassins-creed-odyssey/assets/images/ack_announce-slide_keyart_361691.jpg",
            Genre =genre.FirstOrDefault(x=>x.Name=="RPG"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Ubisoft"),
                    Price=40
                },
                new Game{
                    Name="GTA 5",
                    Description="GTA info...",
                    Year=2015,
                    Image="https://upload.wikimedia.org/wikipedia/ru/c/c8/GTAV_Official_Cover_Art.jpg",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Action"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Rockstar"),
                    Price=40
                },
                new Game{
                    Name="FIFA",
                    Description="FIFA info...",
                    Year=2015,
                    Image="https://media.contentapi.ea.com/content/dam/ea/fifa/fifa-20/images/2019/09/fifamobile4-hero-medium-keyart-7x2-xl.png.adapt.crop16x9.320w.png",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Sport"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="EA"),
                    Price=40
                },
                  new Game{
                    Name="Metro",
                    Description="Metro info...",
                    Year=2013,
                    Image="https://upload.wikimedia.org/wikipedia/ru/thumb/c/c5/Metro_Exodus.png/1200px-Metro_Exodus.png",
            Genre =genre.FirstOrDefault(x=>x.Name=="Shooter"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Playrix"),
                    Price=40
                },
                 new Game{
                    Name="NFS",
                    Description="Rasing info...",
                    Year=2020,
                    Image="https://media.contentapi.ea.com/content/dam/need-for-speed/nfs-heat/common/nfsh-gamebox-keyart-1x1.jpg.adapt.crop1x1.767w.jpg",
                     Genre=genre.FirstOrDefault(x=>x.Name=="Strategy"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="4A Games"),
                    Price=40
                },


                   new Game{
                    Name="FarCry",
                    Description="FarCry info...",
                    Year=2018,
                    Image="https://images.ua.prom.st/2036233862_far-cry-3.jpg",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Action"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Ubisoft"),
                    Price=40
                },
                new Game{
                    Name="Assassin Creed",
                    Description="Assassin Creed info...",
                    Year=2018,
                    Image="https://ubistatic19-a.akamaihd.net/marketingresource/ru-ru/assassins-creed/assassins-creed-odyssey/assets/images/ack_announce-slide_keyart_361691.jpg",
            Genre =genre.FirstOrDefault(x=>x.Name=="RPG"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Ubisoft"),
                    Price=40
                },
                new Game{
                    Name="GTA 5",
                    Description="GTA info...",
                    Year=2015,
                    Image="https://upload.wikimedia.org/wikipedia/ru/c/c8/GTAV_Official_Cover_Art.jpg",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Action"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Rockstar"),
                    Price=40
                },
                new Game{
                    Name="FIFA",
                    Description="FIFA info...",
                    Year=2015,
                    Image="https://media.contentapi.ea.com/content/dam/ea/fifa/fifa-20/images/2019/09/fifamobile4-hero-medium-keyart-7x2-xl.png.adapt.crop16x9.320w.png",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Sport"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="EA"),
                    Price=40
                },
                  new Game{
                    Name="Metro",
                    Description="Metro info...",
                    Year=2013,
                    Image="https://upload.wikimedia.org/wikipedia/ru/thumb/c/c5/Metro_Exodus.png/1200px-Metro_Exodus.png",
            Genre =genre.FirstOrDefault(x=>x.Name=="Shooter"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Playrix"),
                    Price=40
                },
                 new Game{
                    Name="NFS",
                    Description="Rasing info...",
                    Year=2020,
                    Image="https://media.contentapi.ea.com/content/dam/need-for-speed/nfs-heat/common/nfsh-gamebox-keyart-1x1.jpg.adapt.crop1x1.767w.jpg",
                     Genre=genre.FirstOrDefault(x=>x.Name=="Strategy"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="4A Games"),
                    Price=40
                },


                   new Game{
                    Name="FarCry",
                    Description="FarCry info...",
                    Year=2018,
                    Image="https://images.ua.prom.st/2036233862_far-cry-3.jpg",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Action"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Ubisoft"),
                    Price=40
                },
                new Game{
                    Name="Assassin Creed",
                    Description="Assassin Creed info...",
                    Year=2018,
                    Image="https://ubistatic19-a.akamaihd.net/marketingresource/ru-ru/assassins-creed/assassins-creed-odyssey/assets/images/ack_announce-slide_keyart_361691.jpg",
            Genre =genre.FirstOrDefault(x=>x.Name=="RPG"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Ubisoft"),
                    Price=40
                },
                new Game{
                    Name="GTA 5",
                    Description="GTA info...",
                    Year=2015,
                    Image="https://upload.wikimedia.org/wikipedia/ru/c/c8/GTAV_Official_Cover_Art.jpg",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Action"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Rockstar"),
                    Price=40
                },
                new Game{
                    Name="FIFA",
                    Description="FIFA info...",
                    Year=2015,
                    Image="https://media.contentapi.ea.com/content/dam/ea/fifa/fifa-20/images/2019/09/fifamobile4-hero-medium-keyart-7x2-xl.png.adapt.crop16x9.320w.png",
                    Genre=genre.FirstOrDefault(x=>x.Name=="Sport"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="EA"),
                    Price=40
                },
                  new Game{
                    Name="Metro",
                    Description="Metro info...",
                    Year=2013,
                    Image="https://upload.wikimedia.org/wikipedia/ru/thumb/c/c5/Metro_Exodus.png/1200px-Metro_Exodus.png",
            Genre =genre.FirstOrDefault(x=>x.Name=="Shooter"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="Playrix"),
                    Price=40
                },
                 new Game{
                    Name="NFS",
                    Description="Rasing info...",
                    Year=2020,
                    Image="https://media.contentapi.ea.com/content/dam/need-for-speed/nfs-heat/common/nfsh-gamebox-keyart-1x1.jpg.adapt.crop1x1.767w.jpg",
                     Genre=genre.FirstOrDefault(x=>x.Name=="Strategy"),
                    Developer=developer.FirstOrDefault(x=>x.Name=="4A Games"),
                    Price=40
                },
            };
            context.Genres.AddRange(genre);
            context.Games.AddRange(games);
            context.Developers.AddRange(developer);
            context.SaveChanges();


            base.Seed(context);
        }
    }
}
