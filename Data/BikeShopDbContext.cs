

using BikeShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Data
{
    public class BikeShopDbContext : IdentityDbContext<IdentityUser>
    {
        public BikeShopDbContext(DbContextOptions<BikeShopDbContext> options) : base(options)
        {

        }


        public DbSet<Model> models { get; set; }
        public DbSet<Make> makes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
