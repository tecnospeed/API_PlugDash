using dashAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace dashAPI.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public DbSet<estado> estado { get; set; }
    }
}
