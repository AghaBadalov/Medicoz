using Medicoz.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanCategory> PlanCategories { get; set; }
        public DbSet<TermandCondition> TermandConditions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        

    }
}
