using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var config = builder.Configuration;

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});






builder.Services.AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<HospitalManagementSystemDbContext>();




builder.Services.AddDbContext<HospitalManagementSystemDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPatientRepositry, PatientRepositry>();
builder.Services.AddScoped<IDoctorRepositry, DoctorRepositry>();
builder.Services.AddScoped<IEmployeeRepositry, EmployeeRepositry>();
builder.Services.AddScoped<IBookedAppointmentsRepositry, BookedAppointmentRepositry>();
builder.Services.AddScoped<IPatientHistoryRepositry, PatientHistoryRepositry>();
builder.Services.AddScoped<IDrugRepositry, DrugRepositry>();
builder.Services.AddScoped<IPrescriptionRepositry, PrescriptionRepository>();
builder.Services.AddScoped<IMedicalAnalysisRepositry, MedicalAnalysisRepositry>();
builder.Services.AddScoped<IPatientHistoryMedicalAnalysisRepository, PatientHistoryMedicalAnalysisRepositry>();
builder.Services.AddScoped<IDoctorPatientRepositry, DoctorPatientRepositry>();
builder.Services.AddScoped<IDepartmentRepositry , DepartmentRepositry>();
builder.Services.AddScoped<IServiceRepositry,ServicesRepositry>();
builder.Services.AddScoped<ICompanyRepositry, CompanyRepositry>();
builder.Services.AddScoped<IBillRepositry, BillRepositry>();
builder.Services.AddScoped<IDepartmentRepositry , DepartmentRepositry>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
