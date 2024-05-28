using Microsoft.EntityFrameworkCore;
using DataHUBWebApplication.Data;
using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddDbContext<DataHubContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DHConnectionStrings")
    ?? throw new InvalidOperationException("Connection string 'DHConnectionStrings' not found.")));

// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Users/SignIn";
        options.LogoutPath = "/Users/SignOut";
    });
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourseService, CourseService>();
// builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
// builder.Services.AddScoped<IMaterialService, MaterialService>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
