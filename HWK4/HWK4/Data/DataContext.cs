using Microsoft.EntityFrameworkCore;
using HWK4.Models;

namespace HWK4.Data
{
    /// <summary>
    /// Mapping data with the database
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<BillsModel> bill { get; set; }

    }
    
}
