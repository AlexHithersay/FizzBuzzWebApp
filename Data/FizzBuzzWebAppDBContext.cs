using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWebApp.Data;
namespace FizzBuzzWebApp.Data
{
    public class FizzBuzzWebAppDBContext : DbContext
    {
        public FizzBuzzWebAppDBContext(DbContextOptions<FizzBuzzWebAppDBContext> options) : base(options) { }

        public DbSet<DBTableModel> TableRows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite("Data Source=FizzBuzzWebAppDatabase.sqlite");
        }
    }
    
}
