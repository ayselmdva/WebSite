using FinalWebsite.Business.Services.Abstract;
using FinalWebsite.Business.Services.Concrete;
using FinalWebsite.Data.Entities;
using FinalWebsite.DataAccess;
using FinalWebsite.Business;
using JwtExample.Data.DataAccess;
using Microsoft.AspNetCore.Identity;
using Stripe;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
	opt.User.RequireUniqueEmail = true;

    opt.SignIn.RequireConfirmedEmail = true;

	opt.Password.RequiredLength = 8;
	opt.Password.RequireNonAlphanumeric = false;
});

builder.Services.Configure<StripeOptions>(builder.Configuration.GetSection("Stripe"));


var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Director}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
