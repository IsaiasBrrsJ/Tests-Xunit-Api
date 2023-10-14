using Microsoft.EntityFrameworkCore;
using WebApiAndTestsxUnit.Domain.Model.User;

namespace WebApiAndTestsxUnit.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
