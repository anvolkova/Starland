using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StarLand.Models;

namespace StarLand.Services
{
    public class StarLandDbContext: IdentityDbContext
    {
        public DbSet<Profile> TblProfile { get; set; }
        public DbSet<Planet> TblPlanet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            //option.UseSqlServer(@"Server=tcp:starlandsqlserver.database.windows.net,1433;Database=starlandsql;Initial Catalog=starlandsql;Persist Security Info=False;User ID=sqladmin;Password=adminpassw0rd!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            option.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StarLandDatabase;Trusted_Connection=True");

        }
    }
}
