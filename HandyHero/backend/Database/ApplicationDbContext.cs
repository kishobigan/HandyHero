using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<FieldWorker> FieldWorker { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}
