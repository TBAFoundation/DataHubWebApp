using Microsoft.EntityFrameworkCore;
using DataHUBWebApplication.Data;
using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataHubContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DHConnectionStrings")
    ?? throw new InvalidOperationException("Connection string 'DHConnectionStrings' not found.")));

builder.Services.AddControllersWithViews();

// Add application services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
