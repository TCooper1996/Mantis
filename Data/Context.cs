using Mantis.Models;
using Microsoft.EntityFrameworkCore;

namespace Mantis.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            
        }
        
        public DbSet<Project> Project { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<Issue> Issue { get; set; }
    }
}