using EFCore6_MigrationBundle.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore6_MigrationBundle.Context
{
    public class DatContext : DbContext
    {
        public DatContext(DbContextOptions<DatContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}