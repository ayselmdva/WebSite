namespace FinalWebsite.DataAccess.Repositories.Concrete
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        public ActorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
