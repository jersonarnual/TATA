using Microsoft.EntityFrameworkCore;
using TATA.Data.Models;

namespace TATA.Data.Context
{
    public class TATAContext : DbContext
    {
        public TATAContext()
        {

        }
        public TATAContext(DbContextOptions<TATAContext> options) : base(options)
        {

        }

        public virtual DbSet<LogResult> LogResults { get; set; }
        public virtual DbSet<DetailsLog> DetailsLog { get; set; }
    }
}
