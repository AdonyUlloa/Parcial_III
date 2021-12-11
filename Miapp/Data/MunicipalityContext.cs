using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Miapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

    public class MunicipalityContext : IdentityDbContext
    {
        public MunicipalityContext (DbContextOptions<MunicipalityContext> options)
            : base(options)
        {
        }

        public DbSet<Miapp.Models.Municipio> Municipio { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(entity=>
            {
                entity.ToTable(name: "User");
            });
             builder.Entity<IdentityRole>(entity=>
            {
                entity.ToTable(name: "Role");
            });
             builder.Entity<IdentityUserRole<string>>(entity=>
            {
                entity.ToTable("UserRoles");
            });
             builder.Entity<IdentityUserClaim<string>>(entity=>
            {
                entity.ToTable("UserClaims");
            });
             builder.Entity<IdentityUserLogin<string>>(entity=>
            {
                entity.ToTable("UserLogins");
            });
             builder.Entity<IdentityRoleClaim<string>>(entity=>
            {
                entity.ToTable("RoleClaims");
            });
             builder.Entity<IdentityUserToken<string>>(entity=>
            {
                entity.ToTable("UserTokens");
            });
    }
}
