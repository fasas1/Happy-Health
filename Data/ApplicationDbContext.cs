using Happy_Health.Models;
using Microsoft.EntityFrameworkCore;

namespace Happy_Health.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors  { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 1,
                    Name = "Wasiu Ademola",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2007, 2, 15)
                },
                  new Patient
                  {
                      Id = 2,
                      Name = "Charles John",
                      Gender = "Male",
                      DateOfBirth = new DateTime(1999, 5, 2)
                  },
                    new Patient
                    {
                        Id = 3,
                        Name = "Shola Fakuade",
                        Gender = "Female",
                        DateOfBirth = new DateTime(2009, 10, 8)
                    }
                );
          
                  modelBuilder.Entity<Doctor>().HasData(
                 new Doctor { DoctorId = 1, Name = "Dr. Smith", Specialty = "Cardiology",PhoneNumber = "09043892210" },
                 new Doctor { DoctorId = 2, Name = "Dr. Jones", Specialty = "Neurology", PhoneNumber = "08026589420" }
                );
            modelBuilder.Entity<Appointment>().HasData(
    new Appointment
    {
        Id = 1,
        PatientId = 1,
        DoctorId = 2,
        DateTime = new DateTime(2024, 8, 12, 14, 30, 0),
        Description = "Next week"
    }
);

            // Configuring relationships
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
