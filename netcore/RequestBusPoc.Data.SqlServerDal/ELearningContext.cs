using Microsoft.EntityFrameworkCore;
using RequestBusPoc.Domain;

namespace RequestBusPoc.Data.SqlServerDal
{
    public class ELearningContext : DbContext
    {
        public DbSet<Bookmark> Bookmarks { get; set; }

        public ELearningContext(DbContextOptions<ELearningContext> options)
            : base(options)
        {
        }
    }
}