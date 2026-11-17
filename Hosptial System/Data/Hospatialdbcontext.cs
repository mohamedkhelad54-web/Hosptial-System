using Hosptial_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hosptial_System.Data
{
    public class Hospatialdbcontext:DbContext
    {
       public DbSet<Appontimant>appontimants { get; set; }
      public  DbSet<Doctor> doctors { get; set; }
       public DbSet<Patient> patients { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;initial catalog=HospitalSystem;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
