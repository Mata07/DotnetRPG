using DotnetRPG.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetRPG.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
    }
}
