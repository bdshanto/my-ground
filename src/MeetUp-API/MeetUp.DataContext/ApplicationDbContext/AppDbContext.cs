﻿using MeetUp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.DataContext.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}