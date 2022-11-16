using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonkeysVSLive.Models;

namespace MonkeysVSLive.Data
{
    public class MonkeysVSLiveContext : DbContext
    {
        public MonkeysVSLiveContext (DbContextOptions<MonkeysVSLiveContext> options)
            : base(options)
        {
        }

        public DbSet<MonkeysVSLive.Models.Monkey> Monkey { get; set; } = default!;
    }
}
