using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var config = builder.Configuration;

builder.Services.AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<HospitalManagementSystemDbContext>();




builder.Services.AddDbContext<HospitalManagementSystemDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPatientRepositry, PatientRepositry>();
builder.Services.AddScoped<IDoctorRepositry, DoctorRepositry>();
builder.Services.AddScoped<IEmployeeRepositry, EmployeeRepositry>();
builder.Services.AddScoped<IBookedAppointmentsRepositry, BookedAppointmentRepositry>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
