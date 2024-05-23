using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject.ViewModels;
using FinalProject.ViewModels.Appointment;
using FinalProject.ViewModels.Prescreption;
namespace FinalProject.Data
{
    public class HospitalManagementSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<ApplicationUser> Users {  get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BookedAppointment> BookedAppointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientHistory> PatientHistories { get; set; }


        public DbSet<MedicalAnaylsis> MedicalAnaylses { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PatientHistoryMedicalAnalysis> PatientHistoryMedicalAnalyses { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BillItems> BillItems { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        
        public HospitalManagementSystemDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Bill Items Many to Many relationship
            modelBuilder.Entity<BillItems>()
                .HasKey(e => new { e.ServiceId, e.BillId });

            modelBuilder.Entity<BillItems>()
                .HasOne(e => e.Bill)
                .WithMany(e => e.BillItems)
                .HasForeignKey(e => e.BillId);

            modelBuilder.Entity<BillItems>()
                .HasOne(e => e.Service)
                .WithMany(e => e.BillItems)
                .HasForeignKey(e => e.ServiceId);

            //PatientHistoryMedicalAnalyses  many to many relationship

            modelBuilder.Entity<PatientHistoryMedicalAnalysis>()
                .HasKey(p => new { p.PatientHistoryId, p.MedicalAnaylsisId });

              modelBuilder.Entity<DoctorPatient>()
                .HasKey(p => new { p.DoctorId, p.PatientId });
            

            modelBuilder.Entity<PatientHistoryMedicalAnalysis>()
                .HasOne(p => p.MedicalAnaylsis)
                .WithMany(p => p.PatientHistoryMedicalAnalyses)
                .HasForeignKey(p => p.MedicalAnaylsisId);

            modelBuilder.Entity<PatientHistoryMedicalAnalysis>()
                .HasOne(p => p.PatientHistory)
                .WithMany(p => p.PatientHistoryMedicalAnalyses)
                .HasForeignKey(p => p.PatientHistoryId);

            // prescription many to many relationship
            modelBuilder.Entity<Prescription>()
                .HasKey(pre => new { pre.DrugId, pre.PatientHistoryId });

            modelBuilder.Entity<Prescription>()
                .HasOne(pre => pre.Drug)
                .WithMany(pre => pre.Prescriptions)
                .HasForeignKey(pre => pre.DrugId);

            modelBuilder.Entity<Prescription>()
                .HasOne(pre => pre.PatientHistory)
                .WithMany(pre => pre.Prescriptions)
                .HasForeignKey(pre => pre.PatientHistoryId);


            modelBuilder.Entity<Patient>().Property(e => e.BloodGroup).IsRequired(false);
            modelBuilder.Entity<BookedAppointment>()
          .HasOne(ba => ba.Patient)
          .WithMany(p => p.BookedAppointments)
          .HasForeignKey(ba => ba.PatientId)
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PatientHistory>().Property(e => e.BloodPressure).IsRequired(false);
            modelBuilder.Entity<PatientHistory>().Property(e => e.Note).IsRequired(false);
            
            modelBuilder.Entity<DoctorPatient>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.DoctorPatients)

                .OnDelete(DeleteBehavior.Restrict);
             

        }
        public DbSet<FinalProject.ViewModels.Prescreption.PrescreptionDetailsViewModel> PrescreptionDetailsViewModel { get; set; } = default!;
        public DbSet<FinalProject.ViewModels.PatientDetailsViewModel> PatientDetailsViewModel { get; set; } = default!;
        public DbSet<FinalProject.ViewModels.CreateServiceViewModel> CreateServiceViewModel { get; set; } = default!;
        public DbSet<FinalProject.ViewModels.CreateCompanyViewModel> CreateCompanyViewModel { get; set; } = default!;
        public DbSet<FinalProject.ViewModels.CreateMedicalAnalysisViewModel> CreateMedicalAnalysisViewModel { get; set; } = default!;

    }
}
