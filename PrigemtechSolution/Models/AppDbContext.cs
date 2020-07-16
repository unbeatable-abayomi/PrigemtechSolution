using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrigemtechSolution.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //   modelBuilder.Entity<IdentityUserLogin<string>>()
            //   .HasNoKey();
            //   modelBuilder.Entity<IdentityUserRole<string>>()
            //  .HasNoKey();
            //   modelBuilder.Entity<IdentityUserToken<string>>()
            //.HasNoKey();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        } 
    }
}
