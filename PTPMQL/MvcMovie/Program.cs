using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models.Entities;
using MvcMovie.Models;
using MvcMovie.Models.Process;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using VicemMVCIdentity.Models.Process;
var builder = WebApplication.CreateBuilder(args);
 builder.Services.AddOptions();
        var mailSettings = builder.Configuration.GetSection("MailSettings");
        builder.Services.Configure<MailSettings>(mailSettings);
        builder.Services.AddTransient<IEmailSender, SendMailService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddRazorPages();
builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
{
    foreach (var permission in Enum.GetValues(typeof(SystemPermissions)).Cast<SystemPermissions>())
    {
        options.AddPolicy(permission.ToString(), policy =>
            policy.RequireClaim("Permission", permission.ToString()));
        /*options.AddPolicy("Role", policy => policy.RequireClaim("Role", "AdminOnly"));
        options.AddPolicy("Permission", policy => policy.RequireClaim("Permission", "EmployeeecOnly"));
        options.AddPolicy("PolicyAdmin", policy => policy.RequireRole("Admin"));
        options.AddPolicy("PolicyEmployee", policy => policy.RequireRole("Employee"));*/
    }
});

builder.Services.AddTransient<EmployeeSeeder>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
   var seeder = services.GetRequiredService<EmployeeSeeder>();
   seeder.SeedEmployees(1000);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

app.Run();
