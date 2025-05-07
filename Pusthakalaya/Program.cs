using Microsoft.EntityFrameworkCore;          // ? add
using Pusthakalaya.Data;
using Pusthakalaya.Models;
using Microsoft.AspNetCore.Identity;          // ? add

var builder = WebApplication.CreateBuilder(args);

// services
builder.Services.AddControllersWithViews();

// ? tell DI how to build ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? register Identity so UserManager<ApplicationUser> can be injected
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();                      // ? add
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
