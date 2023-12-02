using Core.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Repository
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>()  
             .HasOne(b => b.Patient)
             .WithMany()
             .HasForeignKey(b => b.PatientId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Doctor)
                .WithMany()
                .HasForeignKey(b => b.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<AppointmentDay> AppointmentDays { get; set; }
        public DbSet<AppointmentHour> AppointmentHours { get; set; }




    }
}