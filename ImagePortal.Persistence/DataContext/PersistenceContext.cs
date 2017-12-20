using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImagePortal.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImagePortal.Persistence.DataContext
{
    public class PersistenceContext : DbContext
    {
        public DbSet<Image> Images { get; set; }


        public PersistenceContext()
        {

        }
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ImagePortal64bit;Trusted_Connection=True;");
        }
    }
}
