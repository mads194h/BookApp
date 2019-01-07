using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.DataContexts
{
    public class GiftDataContext : DbContext
    {
        public GiftDataContext(DbContextOptions<GiftDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<GiftItem> GiftItem { get; set; }
    }
}
