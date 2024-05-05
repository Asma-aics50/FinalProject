using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject.ViewModels;
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



        }
        public DbSet<FinalProject.ViewModels.CreateDoctorAccountViewModel> CreateDoctorAccountViewModel { get; set; } = default!;
        public DbSet<FinalProject.ViewModels.AllDoctorsViewModel> AllDoctorsViewModel { get; set; } = default!;
       
    }
}
