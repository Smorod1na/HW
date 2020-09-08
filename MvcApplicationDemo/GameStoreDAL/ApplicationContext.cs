using GameStoreDAL.Entities;
using GameStoreDAL.Initializer;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreDAL
{
    public class AplicationContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public DbSet<Game> Games { get; set; }

        public AplicationContext()
            : base("name=GamesConnectionString")
        {
            Database.SetInitializer(new GamesInitializer());
        }

    }
}
