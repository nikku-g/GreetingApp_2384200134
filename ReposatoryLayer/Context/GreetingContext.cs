using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReposatoryLayer.Entity;

namespace ReposatoryLayer.Context
{
    public class GreetingContext : DbContext
    {
        public GreetingContext(DbContextOptions<GreetingContext> options) : base(options) { }

        // DbSet for GreetingMessage entity
        public DbSet<GreetingMessage> GreetingMessages { get; set; }
    }
}
