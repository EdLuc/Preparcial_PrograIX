using Microsoft.EntityFrameworkCore;
using DemoDapperAPI.Models;

namespace DemoDapperAPI.Data
{
    public class DemoDapperAPIConext : DbContext
    {
        public DemoDapperAPIConext (DbContextOptions<DemoDapperAPIConext> options) : base(options)
        {

        }
        public DbSet<DemoDapperAPI.Models.Cliente> Cliente { get; set; }
    }
}
