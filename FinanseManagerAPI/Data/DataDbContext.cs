using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace FinanseManagerAPI.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> opt) : base(opt) { }

        
    }
}
