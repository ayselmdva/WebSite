namespace FinalWebsite.DataAccess.Repositories.Concrete
{
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public DirectorRepository(AppDbContext context) : base(context)
        {
        }
    }
}

