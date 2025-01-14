using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infra
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) 
        {
        }

        public DbConnection Dapper => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
