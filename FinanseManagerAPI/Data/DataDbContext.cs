using FinanseManagerAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace FinanseManagerAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> opt) : base(opt) { }
        public DbSet<Transaction> Transactions { get; set; }
        
    }
    
}
