using AspnetCoreMvcFull.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
        public DbSet<Tickets> Tickets { get; set; }
    }
}
