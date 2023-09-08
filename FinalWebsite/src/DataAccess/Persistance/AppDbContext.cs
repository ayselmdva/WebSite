using FinalWebsite.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JwtExample.Data.DataAccess;


public class AppDbContext:IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Movie> Movies => Set<Movie>();
    /*public DbSet<Settings> Settings => Set<Settings>();*/
   /* public DbSet<Comment> Comments => Set<Comment>();*/



    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
