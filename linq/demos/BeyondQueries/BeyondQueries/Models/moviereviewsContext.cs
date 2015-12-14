using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BeyondQueries.Models.Mapping;

namespace BeyondQueries.Models
{
    public partial class moviereviewsContext : DbContext
    {
        static moviereviewsContext()
        {
            Database.SetInitializer<moviereviewsContext>(null);
        }

        public moviereviewsContext()
            : base("Name=moviereviewsContext")
        {
        }

        public DbSet<movie> movies { get; set; }
        public DbSet<review> reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new movieMap());
            modelBuilder.Configurations.Add(new reviewMap());
        }
    }
}
