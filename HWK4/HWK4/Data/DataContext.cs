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

<<<<<<< HEAD
        public DbSet<BillsModel> bill { get; set; }
=======

        public DbSet<BillsModel> bill { get; set; }

        public DbSet<Bills> bill { get; set; }

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
    }
    
}
