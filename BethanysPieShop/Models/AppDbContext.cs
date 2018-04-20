using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        // Internediate between code and DB

        //Must have an instance of BDContextOptions otherwise doesn't work
        //To achieve this you can override method on-Configuring
        //or can do it via the construct argument and DInjection
        // In this method we are sending DBContextOption to AppDbContext
        //and passing that to the base class
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        //Making EF - core know about the table
        //DbSet for every entity that you want to be managed by EF-Core
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
    
}