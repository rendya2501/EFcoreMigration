using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MigrationBundleConsoleAppExample.Models;

namespace MigrationBundleConsoleAppExample.Context
{
    public class DatContext : DbContext
    {
        // Contextクラスにおいて直接、接続情報を記述した場合
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=BundleDB2;Integrated Security=True");
        //}

        public DatContext(DbContextOptions<DatContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
    }
}