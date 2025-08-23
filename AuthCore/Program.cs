using ShoppyWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppyWeb.Models.Repositories.IRepository;
using ShoppyWeb.Models.Repositories;
using ShoppyWeb.Programs;
using Microsoft.AspNetCore.Http;
using System.Text;
using ShoppyWeb.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login"; // Your custom login path
    //options.AccessDeniedPath = "/Account/AccessDenied";
});
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartDetailsRepository , CartDetailsRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

var app = builder.Build();
var serviceProvider = app.Services;

await SeedData.SeedRole(serviceProvider);
app.Map("/programs", a =>
{
    a.Run(async (context) =>
    {
        
        await context.Response.WriteAsync("********** ");
        Programs program = new Programs();
         int outputString = program.printMaxNumber();
        //List<KeyValuePair<int, string>> outputStringq = await program.Collections();
        //await context.Response.WriteAsync(outputString +"**********");
        //StringBuilder htmlBuilder = new StringBuilder();
        //foreach (var item in outputStringq)
        //{
        //    await context.Response.WriteAsync(item.Key + "**********"+ item.Value+"/n");
        //}
       await context.Response.WriteAsync(outputString + " **********");
    });
});
//tamilselven
//to seed 
//UpdateDatabaseAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
