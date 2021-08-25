using MeetUp.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.DataContext.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}